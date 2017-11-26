using System;
using HtmlAgilityPack;

namespace StackOverFlowDotNet2
{
    class Program
    {
        static void Main(string[] args)
        {

            #region TesterPage
            HtmlWeb stackoverflowSite = new HtmlWeb();
            HtmlDocument htmlDocument = stackoverflowSite.Load("https://stackoverflow.com/");
            htmlDocument.Save(@"C:\Users\Parsa\Desktop\1.html");
            TesterPage testerPage = htmlDocument.DocumentNode.GetEncapsulatedData<TesterPage>();
            #endregion TesterPage
            
            Console.ReadKey();
        }
    }
}
