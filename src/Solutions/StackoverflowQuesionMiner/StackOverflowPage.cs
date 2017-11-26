using HtmlAgilityPack;
using System.Collections.Generic;
using System.Diagnostics;

namespace StackoverflowQuesionMiner
{
    [HasXPath]
    public class StackOverflowPage
    {
        [XPath("//*[@id='question-mini-list']/div/div")]
        public IEnumerable<StackOverflowQuestion> Questions { get; set; }

        [XPath("//*[@id='hot-network-questions']/ul//li")]
        public IEnumerable<HotNetworkQuestion> GetHotNetworkQuestions { get; set; }
        
    }
}
