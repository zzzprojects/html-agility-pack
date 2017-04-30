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
			//HtmlWeb.LoadAsync("http://www.google.com", (s, args) =>
			//                                            {
			//                                                Results.Text = String.Join(Environment.NewLine,
			//                                                                           args.Document.DocumentNode.Descendants("a").
			//                                                                            Select(
			//                                                                                x =>
			//                                                                                x.GetAttributeValue("href", "")).ToArray());
			//                                            });
		    var web = new HtmlWeb();
		    web.LoadCompleted += SiteLoaded;
		    web.LoadAsync("http://www.google.com");
//			HtmlWeb.LoadAsync("http://www.google.com", SiteLoaded);
		}
		public void SiteLoaded(object sender, HtmlDocumentLoadCompleted args)
		{
            /*var nodes = args.Document.DocumentNode.SelectNodes("//a");
            Results.Text = String.Join(Environment.NewLine, nodes.ToList()
                                                            .Select(x=>x.GetAttributeValue("href",string.Empty))
                                                            .ToList());
             * */
        }
	}
}