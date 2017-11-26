using HtmlAgilityPack;
using System;
using System.Diagnostics;

namespace StackoverflowQuesionMiner
{
    [HasXPath]
    [DebuggerDisplay("UserID={UserID} , ReputationScore={ReputationScore}")]
    public class UserBox
    {
        [XPath("/a[1]/span","title")]
        public DateTime ExactTime { get; set; }

        [XPath("/a[1]/span")]
        public string RelativeTime { get; set; }

        [XPath("/a[2]")]
        public string UserID { get; set; }

        [XPath("a[2]","href")]
        public string UserLink { get; set; }

        [XPath("/span[@class='reputation-score']")]
        public string ReputationScore { get; set; }
    }
}