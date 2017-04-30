using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using HtmlAgilityPack;
using Microsoft.Phone.Controls;

namespace HAPPhoneTest
{
	public partial class MainPage : PhoneApplicationPage
	{
		// Constructor
		public MainPage()
		{
			InitializeComponent();
		}

		private void FetchSite(object sender, RoutedEventArgs e)
		{
			HtmlWeb.LoadAsync("http://www.google.com", (s, args) =>
			                                           	{
			                                           		Results.Text = String.Join(Environment.NewLine,
			                                           		                           args.Document.DocumentNode.Descendants("a").
			                                           		                           	Select(
			                                           		                           		x =>
			                                           		                           		x.GetAttributeValue("href", "")).ToArray());
			                                           	});
		}
	}
}