using HtmlAgilityPack;
using System.Collections.Generic;
using System.Diagnostics;

namespace StackoverflowQuesionMiner
{
    [HasXPath]
    [DebuggerDisplay("QuestionTitle={QuestionTitle}")]
    public class QuestionBox
    {
        [XPath("/h3/a")]
        public string QuestionTitle { get; set; }

        [XPath("/h3/a","href")]
        public string QuestionLink { get; set; }

        [XPath("/div[starts-with(@class,'tags')]//a")]
        public IEnumerable<string> Tags { get; set; }
    }
}