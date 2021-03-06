﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.DataAcsessLayer
{
	[Serializable]
	public class ProducerModel
	{
		private string name;
		private string surname;
		private DateTime birthDate;
		//private string biography;
		private string[] films;

		public ProducerModel()
		{
			films = new string[0];
		}

		public string Name { get => name; set => name = value; }
		public string Surname { get => surname; set => surname = value; }
		public DateTime BirthDate { get => birthDate; set => birthDate = value; }
		public string[] Films { get => films; set => films = value; }
	}
}
