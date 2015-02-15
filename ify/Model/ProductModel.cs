using System;
using Xamarin.Forms;
using System.ComponentModel;
using System.Collections.Generic;


namespace ify.Model
{
	public class ProductModel: INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;

		public string product { get; set; }
		public string resultSize { get; set; }
		public string version { get; set; }
		public List<QuestionModel> items { get; set; }

		public ProductModel ()
		{
		}

		protected virtual void OnPropertyChanged(string name)
		{
			var ev = PropertyChanged;
			if (ev != null)
			{
				ev(this, new PropertyChangedEventArgs(name));
			}
		}
	}
}

