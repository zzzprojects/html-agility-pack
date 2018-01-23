using HtmlAgilityPack;
using System.Diagnostics;

namespace StackoverflowQuesionMiner
{
    [HasXPath]
    [DebuggerDisplay("Question Title={QuestionTitle}")]
    public class HotNetworkQuestion
    {
        [XPath("/div","title")]
        public string QuestionCategory { get; set; }

        [XPath("/a")]
        public string QuestionTitle { get; set; }

        [XPath("/a","href")]
        public string QuestionLink { get; set; }
    }
}