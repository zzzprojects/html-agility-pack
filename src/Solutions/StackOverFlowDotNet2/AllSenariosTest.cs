using System;
using System.Collections.Generic;
using HtmlAgilityPack;
using System.Diagnostics;

namespace StackOverFlowDotNet2
{
    [HasXPath]
    public class TesterPage
    {
        #region NoneIEnumerableProperties

        [XPath("//*[@id='question-mini-list']/div/div[1]/div[@class='cp']")]
        public StatisticsBox Statistics1 { get; set; }

        [XPath("//*[@id='question-mini-list']/div/div[1]/div[@class='summary']/div[@class='started']/a[1]/span", "title")]
        public DateTime DateCreated1 { get; set; }

        [XPath("//*[@id='question-mini-list']/div/div[1]/div[@class='cp']/div[1]/div/span")]
        public int Votes1 { get; set; }

        [XPath("//*[@id='question-mini-list']/div/div[1]/div[@class='cp']/div[3]/div/span")]
        public string Views1 { get; set; }

        #endregion NoneIEnumerableProperties

        #region IEnumerableProperties

        [XPath("//*[@id='question-mini-list']/div//div/div[@class='cp']")]
        public IEnumerable<StatisticsBox> StatisticsAll { get; set; }

        [XPath("//*[@id='question-mini-list']/div//div/div[@class='summary']/div[@class='started']/a[1]/span", "title")]
        public IEnumerable<DateTime> DateCreatedAll { get; set; }

        [XPath("//*[@id='question-mini-list']/div//div/div[@class='cp']/div[1]/div/span")]
        public IEnumerable<int> VotesAll { get; set; }

        [XPath("//*[@id='question-mini-list']/div//div/div[@class='cp']/div[3]/div/span")]
        public IEnumerable<string> ViewsAll { get; set; }

        #endregion IEnumerableProperties
    }


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
