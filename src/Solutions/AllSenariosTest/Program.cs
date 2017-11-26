using System;
using HtmlAgilityPack;

namespace AllSenariosTest
{
    class Program
    {
        static void Main(string[] args)
        {

            #region TesterPage
            HtmlWeb stackoverflowSite = new HtmlWeb();
            HtmlDocument htmlDocument = stackoverflowSite.Load("https://stackoverflow.com/");
            //htmlDocument.Save(@"C:\Users\Parsa\Desktop\1.html");
            Senarios testerPage = htmlDocument.DocumentNode.GetEncapsulatedData<Senarios>();
            #endregion TesterPage
            
            Console.ReadKey();
        }
    }
}
