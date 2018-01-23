using System;
using System.Collections.Generic;
using HtmlAgilityPack;
using System.Diagnostics;

namespace AllSenariosTest
{
    [HasXPath]
    public class Senarios
    {
        #region NoneIEnumerableProperties

        [XPath("//*[@id='question-mini-list']/div/div[1]/div[@class='cp']")]
        public StatisticsBox Statistics1 { get; set; }

        [XPath("//*[@id='question-mini-list']/div/div[1]/div[@class='summary']/div[@class='started']/a[1]/span", "title")]
        public DateTime DateCreated1 { get; set; }

        [XPath("//*[@id='question-mini-list']/div/div[1]/div[@class='cp']/div[1]/div/span")]
        public int Votes1 { get; set; }

        [XPath("//*[@id='question-mini-list']/div/div[1]/div[@class='summary']/h3/a")]
        public string Quesion1 { get; set; }

        

        #endregion NoneIEnumerableProperties

        #region IEnumerableProperties

        [XPath("//*[@id='question-mini-list']/div//div/div[@class='cp']")]
        public IEnumerable<StatisticsBox> AllStatistics { get; set; }

        [XPath("//*[@id='question-mini-list']/div//div/div[@class='summary']/div[@class='started']/a[1]/span", "title")]
        public IEnumerable<DateTime> AllDatesCreated { get; set; }

        [XPath("//*[@id='question-mini-list']/div//div/div[@class='cp']/div[1]/div/span")]
        public IEnumerable<int> AllVotes { get; set; }

        [XPath("//*[@id='question-mini-list']/div//div/div[@class='summary']/h3/a")]
        public IEnumerable<string> AllQuestions { get; set; }

        #endregion IEnumerableProperties
    }

}
