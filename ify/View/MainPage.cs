using System;
using Xamarin.Forms;
using System.Collections.Generic;
using ify.Model;
using ify.ViewModel;
using ify;

namespace ify.View
{
	public class MainPage : ContentPage
	{
		List<string> categories = new List<string> ();
		public MainPage ()
		{
			foreach (var item in App.viewModel.product.items) {
				if (!categories.Contains (item.section)) {
					categories.Add (item.section);
				}
			}

	
			List<Button> buttons = new List<Button> ();

			StackLayout layer = new StackLayout {
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.CenterAndExpand,
				Orientation = StackOrientation.Vertical 
			};

			foreach (var item in categories) {
				Button button = new Button {
					Text = item,
					TextColor = App.skyblue,
					BorderColor = Color.Gray,
					BorderWidth = 1,
					BackgroundColor = Color.White,
					WidthRequest = 240
				};

				button.Clicked += (sender, e) => {
					App.questionPage.Load(button.Text);
					App.Current.MainPage = App.questionPage;
				};

				buttons.Add (button);
				layer.Children.Add (button);
			}

			Content = layer;
		}
	}
}

