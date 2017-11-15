using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Newtonsoft.Json;
using System.IO;
using System.Diagnostics;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO.Compression;

namespace Movies.DataAcsessLayer
{
	public static class Accessor
	{
		private static FileInfo file;
		private static string reserveFile;
		
		public static void WriteColl(FilmModel[] films, string path, int mode)
		{
			if (File.Exists(path))
			{
				using (FileStream s1 = File.Open(path, FileMode.Open))
				{
					using (FileStream s2 = File.Create(path + ".copy"))
					{
						reserveFile = path + ".copy";
						s1.CopyTo(s2);
					}
				}
			}
			file = new FileInfo(path);
			if (mode == 1)
			{
				try
				{
					BinaryFormatter bf = new BinaryFormatter();
					bf.Serialize(file.Open(FileMode.Create), films);
				}
				catch
				{
					if (File.Exists(path + ".copy"))
					{
						using (FileStream s2 = File.Create(path + ".copy"))
						{
							using (FileStream s1 = File.Open(path, FileMode.Open))
							{
								s2.CopyTo(s1);
							}
						}
					}
				}
				return;
			}

			try
			{
				string json = JsonConvert.SerializeObject(films);
				using (StreamWriter sw = new StreamWriter(path))
				{
					sw.WriteLine(json);
				}
			}
			catch
			{
				if (File.Exists(path + ".copy"))
				{
					using (FileStream s2 = File.Create(path + ".copy"))
					{
						using (FileStream s1 = File.Open(path, FileMode.Open))
						{
							s2.CopyTo(s1);
						}
					}
				}
			}
			if (mode == 2)
			{
				Compress(path);
				File.Delete(path);
			}
			
		}
		public static FilmModel[] ReadColl(string path, int mode)
		{
			string json = null;
			if (mode == 2)
			{
				Decompress(path);
				path = path.Replace(".gz", "");
				if (Path.GetExtension(path) == ".dat")
				{
					mode = 1;
				}
				else mode = 0;
			}
			if (File.Exists(path))
			{
				file = new FileInfo(path);
			}
			else if (File.Exists(path + ".copy"))
			{
				file = new FileInfo(path + ".copy");
			}
			else if (File.Exists(reserveFile))
			{
				file = new FileInfo(reserveFile);
			}
			else return null;
			if (mode == 1)
			{
				BinaryFormatter bf = new BinaryFormatter();
				FilmModel[] films = (FilmModel[])bf.Deserialize(file.Open(FileMode.Open));
				return films;
			}
			using (var reader = file.OpenText())
			{
				json = reader.ReadLine();
			}
			if (json != null)
			{
				FilmModel[] films = new FilmModel[0];
				try
				{
					films = JsonConvert.DeserializeObject<FilmModel[]>(json);
				}
				catch (Exception e)
				{
					Debug.Print(e.Message);
					if (File.Exists(path + ".copy"))
					{
						using (FileStream s2 = File.OpenRead(path + ".copy"))
						{
							using (FileStream s1 = File.Open(path, FileMode.Open))
							{
								s2.CopyTo(s1);
							}
						}
						File.Delete(path + ".copy");
						films = ReadColl(path, mode);
					}
				}
				return films;
			}
			else
			{
				return null;
			}
		}
		public static void Compress(string path)
		{
			file = new FileInfo(path);
			using (FileStream originalFileStream = file.OpenRead())
			{
				if ((File.GetAttributes(file.FullName) &
				   FileAttributes.Hidden) != FileAttributes.Hidden & file.Extension != ".gz")
				{
					using (FileStream compressedFileStream = File.Create(file.FullName + ".gz"))
					{
						using (GZipStream compressionStream = new GZipStream(compressedFileStream,
						   CompressionMode.Compress))
						{
							originalFileStream.CopyTo(compressionStream);
						}
					}
				}

			}
		}
		public static void Decompress(string path)
		{
			file = new FileInfo(path);
			using (FileStream originalFileStream = file.OpenRead())
			{
				string currentFileName = file.FullName;
				string newFileName = currentFileName.Remove(currentFileName.Length - file.Extension.Length);

				using (FileStream decompressedFileStream = File.Create(newFileName))
				{
					using (GZipStream decompressionStream = new GZipStream(originalFileStream, CompressionMode.Decompress))
					{
						decompressionStream.CopyTo(decompressedFileStream);
					}
				}
			}
		}
	}
}
