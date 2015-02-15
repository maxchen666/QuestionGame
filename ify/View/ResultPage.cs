using System;
using Xamarin.Forms;
using System.Collections.Generic;
using ify.Model;
using ify.ViewModel;
using ify;

namespace ify.View
{
	public class ResultPage: ContentPage
	{
		Image score;
		Image img;
		Label answer;

		Button article;
		Button next;
		Label standfirst;

		public ResultPage ()
		{
			score = new Image {
			};

			img = new Image {
			};

			answer = new Label {
				TextColor = App.skyblue,
				BackgroundColor = Color.Transparent,
				FontSize = 11
			};

			article = new Button {
				BorderColor = App.skyblue,
				TextColor = App.skyblue,
				BorderWidth = 1,
				BackgroundColor = Color.White,
				FontSize = 11
			};

			next = new Button {
				BorderColor = Color.Silver,
				TextColor = App.skyblue,
				BorderWidth = 1,
				BackgroundColor = Color.White,
				FontSize = 11
			};

			standfirst = new Label {
				BackgroundColor = Color.Gray,
				FontSize = 11
			};

			RelativeLayout layer = new RelativeLayout {
			};

			layer.Children.Add (score,
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
					return parent.Height / 3 - 10;
				})
			);

			layer.Children.Add (img,
				Constraint.RelativeToParent ((parent) => {
					return 20;
				}),
				Constraint.RelativeToParent ((parent) => {
					return parent.Height / 3;
				}),
				Constraint.RelativeToParent ((parent) => {
					return parent.Width - 40;
				}),
				Constraint.RelativeToParent ((parent) => {
					return parent.Height / 3 - 10;
				})
			);

			layer.Children.Add (answer,
				Constraint.RelativeToParent ((parent) => {
					return 40;
				}),
				Constraint.RelativeToParent ((parent) => {
					return parent.Height / 2;
				}),
				Constraint.RelativeToParent ((parent) => {
					return parent.Width - 80;
				}),
				Constraint.RelativeToParent ((parent) => {
					return parent.Height / 6 - 10;
				})
			);

			layer.Children.Add (article,
				Constraint.RelativeToParent ((parent) => {
					return parent.Width / 2 + 20;
				}),
				Constraint.RelativeToParent ((parent) => {
					return parent.Height * 2 / 3;
				}),
				Constraint.RelativeToParent ((parent) => {
					return parent.Width / 2 - 40;
				}),
				Constraint.RelativeToParent ((parent) => {
					return parent.Height / 9 - 10;
				})
			);

			layer.Children.Add (next,
				Constraint.RelativeToParent ((parent) => {
					return 20;
				}),
				Constraint.RelativeToParent ((parent) => {
					return parent.Height * 2 / 3 + parent.Height / 9;
				}),
				Constraint.RelativeToParent ((parent) => {
					return parent.Width - 40;
				}),
				Constraint.RelativeToParent ((parent) => {
					return parent.Height / 9 - 10;
				})
			);

			layer.Children.Add (standfirst,
				Constraint.RelativeToParent ((parent) => {
					return 20;
				}),
				Constraint.RelativeToParent ((parent) => {
					return parent.Height * 2 / 3 + parent.Height * 2 / 9;
				}),
				Constraint.RelativeToParent ((parent) => {
					return parent.Width - 40;
				}),
				Constraint.RelativeToParent ((parent) => {
					return parent.Height / 9 - 10;
				})
			);

			Content = layer;
		}

		public void Load(List<QuestionModel> questions, int current)
		{
			switch (App.score) {
			case 9:
				score.Source = "round9.png";
				break;
			case 8:
				score.Source = "round8.png";
				break;
			case 7:
				score.Source = "round7.png";
				break;
			case 6:
				score.Source = "round6.png";
				break;
			case 5:
				score.Source = "round5.png";
				break;
			case 4:
				score.Source = "round4.png";
				break;
			case 3:
				score.Source = "round3.png";
				break;
			case 2:
				score.Source = "round2.png";
				break;
			case 1:
				score.Source = "round1.png";
				break;
			case 0:
				score.Source = "round0.png";
				break;
			}

			img.Source = questions [current].imageUrl;
			answer.Text = questions [current].headlines [questions [current].correctAnswerIndex];

			article.Text = "Read Article";
			article.Clicked += (sender, e) => {
				Device.OpenUri(new Uri(questions [current].storyUrl));
			};

			next.Text = "Next Question";
			next.Clicked += (sender, e) => {
				App.questionPage.Next();
				App.Current.MainPage = App.questionPage;
			};

			int total = questions.Count;
			int nextOffset = current + 1;
			if (nextOffset >= total) {
				nextOffset = 0;
			}
			standfirst.Text = questions [nextOffset].standFirst;
		}
	}
}

