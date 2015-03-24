﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace CliqueCab
{
	/// <summary>
	/// An empty page that can be used on its own or navigated to within a Frame.
	/// </summary>
	public sealed partial class Login : Page
	{
		string Client_ID = "h2CYRccylaZtoCRBJrv7OjqbUsJ9kkxR"
		public Login()
		{
			this.InitializeComponent();
		}

		/// <summary>
		/// Invoked when this page is about to be displayed in a Frame.
		/// </summary>
		/// <param name="e">Event data that describes how this page was reached.
		/// This parameter is typically used to configure the page.</param>
		protected override void OnNavigatedTo(NavigationEventArgs e)
		{
			string auth_url = string.Format("https://login.uber.com/oauth/authorize?response_type=token&client_id={0}", Client_ID);

			LoginWeb.NavigationCompleted += LoginWeb_NavigationCompleted;
			
			LoginWeb.Navigate(new Uri(auth_url));
			
		}

		void LoginWeb_NavigationCompleted(WebView sender, WebViewNavigationCompletedEventArgs args)
		{
			string Uri = sender.Source.ToString();
 			if(Uri.Contains("access_token"))
			{
				// Reference Uri: https://www.uber.com/#access_token=vStdOf7brqdEYoiOBx7k9kLhDFBX9m&token_type=Bearer&expires_in=2592000&scope=profile+history_lite
				string parameters = Uri.Substring(Uri.IndexOf("#") + 1);

				string[] kvps = parameters.Split('&');
			}
		}
	}
}
