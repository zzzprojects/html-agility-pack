using HtmlAgilityPack;
using System.Diagnostics;

namespace StackoverflowQuesionMiner
{
    [HasXPath]
    [DebuggerDisplay("Votes={Votes} , Answers={Answers} , Views={Views}")]
    public class StatisticsBox
    {
        [XPath("/div[1]/div/span")]
        public int Votes { get; set; }

        [XPath("/div[2]/div/span")]
        public int Answers { get; set; }

        [XPath("/div[3]/div/span")]
        public string Views { get; set; }


    }
}