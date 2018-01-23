using HtmlAgilityPack;
using System.Diagnostics;

namespace StackoverflowQuesionMiner
{
    [HasXPath]
    [DebuggerDisplay("StackOverflowQuestion : {Question.QuestionTitle}")]
    public class StackOverflowQuestion
    {
        [XPath("/div[@class='cp']")]
        public StatisticsBox Statistics { get; set; }


        [XPath("/div[@class='summary']")]
        public QuestionBox Question { get; set; }


        [XPath("/div[@class='summary']/div[@class='started']")]
        public UserBox User { get; set; }

    }

}
