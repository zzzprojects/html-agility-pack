using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackoverflowQuesionMiner
{
    class Program
    {
        static void Main(string[] args)
        {
            //*[@id='question-mini-list']/div//div/div[@class='summary']/h3/a

            //htmlDocument.Save(@"C:\Users\Parsa\Desktop\1.html");
            Stopwatch stopwatch = new Stopwatch();


            stopwatch = Stopwatch.StartNew();
            HtmlWeb stackoverflowSite = new HtmlWeb();
            HtmlDocument htmlDocument = stackoverflowSite.Load("https://stackoverflow.com/");
            

            stopwatch.Stop();
            Console.WriteLine("Time it took to load page :" + stopwatch.Elapsed);


            stopwatch = Stopwatch.StartNew();
            StackOverflowPage stackOverflowPage = htmlDocument.DocumentNode.GetEncapsulatedData<StackOverflowPage>();
            stopwatch.Stop();
            Console.WriteLine("Time it took to parse and Reflect data :" + stopwatch.Elapsed);

            IEnumerable<StackOverflowQuestion> filtered = stackOverflowPage.Questions.OrderBy(new Func<StackOverflowQuestion, int>(x => x.Statistics.Votes));

            Console.WriteLine();

            int a = 1;

            Console.ReadKey();
        }
    }
}
