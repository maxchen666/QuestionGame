using System;
using ify.Model;
using ify.ViewModel;
using ify.View;
using Xamarin.Forms;
using System.Collections.Generic;

namespace ify
{
	public class App : Application
	{
		public static QuestionViewModel viewModel = new QuestionViewModel();
		public static MainPage mainPage;
		public static QuestionPage questionPage;
		public static ResultPage resultPage;
		public static int totalscore;
		public static int score;
		public static Color skyblue = Color.FromRgb(0, 191, 255);
		public App ()
		{
			viewModel.Load ();
			totalscore = 0;
			mainPage = new MainPage ();
			questionPage = new QuestionPage ();
			resultPage = new ResultPage ();

			MainPage = mainPage;					
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}

