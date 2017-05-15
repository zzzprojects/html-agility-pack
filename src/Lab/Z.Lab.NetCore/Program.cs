using System;
using System.Linq;
using HtmlAgilityPack;

namespace Z.Lab.NetCore
{
    class Program
    {
        static void Main(string[] args)
        {
            {
                HtmlWeb web = new HtmlWeb();
                HtmlDocument document = web.Load("http://www.c-sharpcorner.com");
            }
            {
                var html = @"<TD class=texte width=""50%"">
<DIV align=right>Name :<B> </B></DIV></TD>
<TD width=""50%"">
    <INPUT class=box value=John maxLength=16 size=16 name=user_name>
</TD>
<TR vAlign=center>";

                var htmlDoc = new HtmlDocument();
                htmlDoc.LoadHtml(html);

                string name = htmlDoc.DocumentNode
                    .SelectNodes("//td/input")
                    .First()
                    .Attributes["value"].Value;
            }
            Console.WriteLine("Hello World!");
        }
    }
}