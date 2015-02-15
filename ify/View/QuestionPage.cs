using System;
using Xamarin.Forms;
using System.Collections.Generic;
using ify.Model;
using ify.ViewModel;
using ify;

namespace ify.View
{
	public class QuestionPage: ContentPage
	{
		List<QuestionModel> questions = new List<QuestionModel> ();
		int current = 0;
		int total  = 0;

		Image img;
		ProgressBar lefttime;
		Button answer1;
		Button answer2;
		Button answer3;
		Button skip;
		public QuestionPage ()
		{
			img = new Image {
			};

			lefttime = new ProgressBar {
				Progress = 1
			};

			answer1 = new Button {
				BorderColor = Color.Gray,
				TextColor = App.skyblue,
				BorderWidth = 1,
				BackgroundColor = Color.White,
				FontSize = 11
			};

			answer2 = new Button {
				BorderColor = Color.Gray,
				TextColor = App.skyblue,
				BorderWidth = 1,
				BackgroundColor = Color.White,
				FontSize = 11
			};

			answer3 = new Button {
				BorderColor = Color.Gray,
				TextColor = App.skyblue,
				BorderWidth = 1,
				BackgroundColor = Color.White,
				FontSize = 11
			};

			skip = new Button {
				BorderColor = Color.Gray,
				BorderWidth = 1,
				BackgroundColor = Color.Gray,
				FontSize = 11
			};
			skip.Clicked += (sender, e) => {
				Next();
			};


			RelativeLayout layer = new RelativeLayout {
			};

			layer.Children.Add (img,
				Constraint.RelativeToParent ((parent) => {
					return 20;
				}),
				Constraint.RelativeToParent ((parent) => {
					return 0;
				}),
				Constraint.RelativeToParent ((parent) => {
					return parent.Width - 40;
				}),
				Constraint.RelativeToParent ((parent) => {
					return parent.Height / 2;
				})
			);

			layer.Children.Add (lefttime,
				Constraint.RelativeToParent ((parent) => {
					return 20;
				}),
				Constraint.RelativeToParent ((parent) => {
					return parent.Height / 2;
				}),
				Constraint.RelativeToParent ((parent) => {
					return parent.Width - 40;
				}),
				Constraint.RelativeToParent ((parent) => {
					return parent.Height / 16 - 10;
				})
			);
				
			layer.Children.Add (answer1,
				Constraint.RelativeToParent ((parent) => {
					return 20;
				}),
				Constraint.RelativeToParent ((parent) => {
					return parent.Height / 2 + parent.Height / 16;
				}),
				Constraint.RelativeToParent ((parent) => {
					return parent.Width - 40;
				}),
				Constraint.RelativeToParent ((parent) => {
					return parent.Height / 8 - 10;
				})
			);

			layer.Children.Add (answer2,
				Constraint.RelativeToParent ((parent) => {
					return 20;
				}),
				Constraint.RelativeToParent ((parent) => {
					return parent.Height / 2 + parent.Height / 8 + parent.Height / 16;
				}),
				Constraint.RelativeToParent ((parent) => {
					return parent.Width - 40;
				}),
				Constraint.RelativeToParent ((parent) => {
					return parent.Height / 8 - 10;
				})
			);

			layer.Children.Add (answer3,
				Constraint.RelativeToParent ((parent) => {
					return 20;
				}),
				Constraint.RelativeToParent ((parent) => {
					return parent.Height / 2 + parent.Height / 4 + parent.Height / 16;
				}),
				Constraint.RelativeToParent ((parent) => {
					return parent.Width - 40;
				}),
				Constraint.RelativeToParent ((parent) => {
					return parent.Height / 8 - 10;
				})
			);

			layer.Children.Add (skip,
				Constraint.RelativeToParent ((parent) => {
					return 20;
				}),
				Constraint.RelativeToParent ((parent) => {
					return parent.Height / 2 + parent.Height * 3 / 8 + parent.Height / 16;
				}),
				Constraint.RelativeToParent ((parent) => {
					return parent.Width - 40;
				}),
				Constraint.RelativeToParent ((parent) => {
					return parent.Height / 16 - 10;
				})
			);

			Content = layer;
		}

		public void Load(string category)
		{
			questions = App.viewModel.product.items.FindAll (delegate(QuestionModel question) {
				return question.section == category;
			});

			App.score = 0;
			current = -1;
			total = questions.Count;

			if (total > 0) {
				Next ();
			}

			skip.Text = "skip";
		}

		public void Next()
		{
			current++;
			if (current >= total) {
				current = 0;
			}

			App.score = 0;
			img.Source = questions [current].imageUrl;
			answer1.Text = questions [current].headlines [0];
			answer2.Text = questions [current].headlines [1];
			answer3.Text = questions [current].headlines [2];
			lefttime.Progress = 1;
			lefttime.ProgressTo (0, 10000, Easing.Linear);

			answer1.Clicked += (sender, e) => {
				if(questions [current].correctAnswerIndex == 0)
				{
					App.score = (int)(lefttime.Progress * 10);
				}
				else
				{
					App.score = 0;
				}

				App.resultPage.Load(questions, current);
				App.Current.MainPage = App.resultPage;
			};
			answer2.Clicked += (sender, e) => {
				if(questions [current].correctAnswerIndex == 1)
				{
					App.score = (int)(lefttime.Progress * 10);
				}
				else
				{
					App.score = 0;
				}
				App.resultPage.Load(questions, current);
				App.Current.MainPage = App.resultPage;
			};
			answer3.Clicked += (sender, e) => {
				if(questions [current].correctAnswerIndex == 2)
				{
					App.score = (int)(lefttime.Progress * 10);
				}
				else
				{
					App.score = 0;
				}
				App.resultPage.Load(questions, current);
				App.Current.MainPage = App.resultPage;
			};
		}


	}
}

