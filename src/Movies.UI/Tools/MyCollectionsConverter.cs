using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Movies.BusinessLogic.Collections;
using Movies.BusinessLogic.Tools;
using Movies.BusinessLogic;
using Movies.UI.ViewModel;
using Movies.UI.ViewModel.Collections;

namespace Movies.UI.Tools
{
	public static class MyCollectionsConverter
	{
		public static MyCollection<Film> ObsToReg(MyObservableCollection<FilmViewModel> coll)
		{
			MyCollection<Film> newColl = new MyCollection<Film>();
			foreach (var filmViewModel in coll)
			{
				newColl.Add(filmViewModel.Source);
			}
			return newColl;
		}
		public static MyCollection<Actor> ObsToReg(MyObservableCollection<ActorViewModel> coll)
		{
			MyCollection<Actor> newColl = new MyCollection<Actor>();
			foreach (var actorViewModel in coll)
			{
				newColl.Add(actorViewModel.SourceActor);
			}
			return newColl;
		}
		public static MyCollection<Producer> ObsToReg(MyObservableCollection<ProducerViewModel> coll)
		{
			MyCollection<Producer> newColl = new MyCollection<Producer>();
			foreach (var prodViewModel in coll)
			{
				newColl.Add(prodViewModel.Source);
			}
			return newColl;
		}
	}
}
