using System;
using Xamarin.Forms;
using System.ComponentModel;

namespace ify.Model
{
	public class QuestionModel : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;

		public int correctAnswerIndex { get ; set; }
		public string imageUrl { get ; set; }
		public string standFirst { get; set; }
		public string storyUrl { get; set; }
		public string section { get; set; }
		public string [] headlines { get; set; }

		public QuestionModel ()
		{
			correctAnswerIndex = -1;
			imageUrl = "";
			standFirst = "";
			storyUrl = "";
			section = "";
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

