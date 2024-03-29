﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Metadata;
using Xunit;

namespace HtmlAgilityPack.Tests.NetStandard2_0
{
    public class EncapsulatorTests
    {
        //[Fact]
        //public void StackOverFlow_Test()
        //{
        //    HtmlWeb stackoverflowSite = new HtmlWeb();
        //    HtmlDocument htmlDocument = stackoverflowSite.Load("https://stackoverflow.com/questions");

        //    StackOverflowPage stackOverflowPage = htmlDocument.DocumentNode.GetEncapsulatedData<StackOverflowPage>();

        //    Assert.NotNull(stackOverflowPage);
        //}

        //[Fact]
        //public void Dictionary_Test()
        //{
        //    HtmlWeb wortSite = new HtmlWeb();
        //    HtmlDocument htmlDocument = wortSite.Load("https://wort.ir/woerterbuch/deutsch-persisch/Buch");

        //    Word wort = htmlDocument.DocumentNode.GetEncapsulatedData<Word>();

        //    Assert.NotNull(wort);
        //}

        [Fact]
        public void EncapsulatedOuterHtml_Test()
        {
            var html = @"
<div>
<a href='3.html' class='single'>3</a>
<div>hello
<a href='1.html'>1</a>
<a href='2.html'>2</a>
</div>
<div>world</div>
</div>
";
            var document = new HtmlDocument();
            document.LoadHtml(html);
            var outerHtml = document.DocumentNode.GetEncapsulatedData<OuterHtml>();
            Assert.True(outerHtml.Item3.Href == "3.html");
            Assert.True(outerHtml.Item3.Name == "3");

            Assert.True(outerHtml.Items.Count == 3);
            Assert.True(outerHtml.Items.All(o => o.Href != null));
        }

        [Fact]
        public void Encapsulation_Test2()
        {
            var docoument = new HtmlDocument();
            docoument.LoadHtml(EncapsulationTestHtml.Html);
            var testHtml = docoument.DocumentNode.GetEncapsulatedData<EncapsulationTestHtml>();

            Assert.True(testHtml.Title == "Test");
            Assert.True(testHtml.H1 == "Test");
            Assert.NotEmpty(testHtml.Link1);
            Assert.NotEmpty(testHtml.Link2);
            Assert.NotNull(testHtml.Link3);

            Assert.NotNull(testHtml.Form);

            Assert.True(testHtml.Articles.Count == 2);
            Assert.True(testHtml.Articles.All(o => o.Id != null));
        }
    }


    #region StackOverFlow_TestClasses

    [HasXPath]
    public class StackOverflowPage
    {
        
        [XPath("//*[@id='questions']/div")]
        public IEnumerable<StackOverflowQuestion> Questions { get; set; }
        
        
        
        [XPath("//*[@id='hot-network-questions']/ul//li")]
        public IEnumerable<HotNetworkQuestion> GetHotNetworkQuestions { get; set; }
        
    }

    [HasXPath]
    [DebuggerDisplay("StackOverflowQuestion : {Question.QuestionTitle}")]
    public class StackOverflowQuestion
    {

        [XPath("/div[@class='statscontainer']")]
        public StatisticsBox Statistics { get; set; }


        [XPath("/div[@class='summary']")]
        public QuestionBox Question { get; set; }
       
        // The XPath below is an alternativ XPath if the uncommented one does not work
        // [XPath("/div[@class='summary']/div[3]/div")]
        [XPath("/div[@class='summary']/div[@class='started fr']/div")]
        public UserBox User { get; set; }
    }



    [HasXPath]
    [DebuggerDisplay("Votes={Votes} , Answers={Answers} , Views={Views}")]
    public class StatisticsBox
    {
        [XPath("/div[1]/div[1]/div/span/strong")]
        public int Votes { get; set; }

        [XPath("/div[1]/div[2]/strong")]
        public int Answers { get; set; }

        [XPath("/div[2]")]
        public string Views { get; set; }


    }





    [HasXPath]
    [DebuggerDisplay("QuestionTitle={QuestionTitle}")]
    public class QuestionBox
    {
        [XPath("/h3/a")]
        public string QuestionTitle { get; set; }

        [XPath("/h3/a", "href")]
        public string QuestionLink { get; set; }

        [XPath("/div[starts-with(@class,'tags')]//a")]
        public IEnumerable<string> Tags { get; set; }
    }



    [HasXPath]
    [DebuggerDisplay("UserID={UserID} , ReputationScore={ReputationScore}")]
    public class UserBox
    {
        [XPath("/div[@class='user-action-time']/span", "title")]
        public DateTime ExactTime { get; set; }

        [XPath("/div[@class='user-action-time']/span")]
        public string RelativeTime { get; set; }

        [XPath("/div[@class='user-details']/a","href")]
        public string UserLink { get; set; }

        [XPath("/div[@class='user-details']/a")]
        public string UserName { get; set; }

        [XPath("/div[@class='user-details']/div[1]")]
        public string ReputationScore { get; set; }
    }

    [HasXPath]
    [DebuggerDisplay("Question Title={QuestionTitle}")]
    public class HotNetworkQuestion
    {
        [XPath("/div", "title")]
        public string QuestionCategory { get; set; }

        [XPath("/a")]
        public string QuestionTitle { get; set; }

        [XPath("/a", "href")]
        public string QuestionLink { get; set; }
    }

    #endregion #region StackOverFlow_TestClasses



    #region Dictionary_TestClasses

    [HasXPath]
    [DebuggerDisplay("Word={Text}")]
    public class Word
    {
        [XPath("//*[@id='content-wrapper']/div/h1/text()")]
        public string Text { get; set; }

        [XPath("//*[@id='accordion']/div")]
        public List<Def> Defs { get; set; } = new List<Def>();
    }

    [HasXPath]
    [DebuggerDisplay("{Deu} : {Fa}")]
    public class Def
    {        

        [XPath("/div[1]/div[@class='panel-title definition']/a/span[@class='de']")]
        public string Deu { get; set; }


        
        [XPath("/div[1]/div[@class='panel-title definition']/a/span[@class='fa']")]
        public string Fa { get; set; }

        [SkipNodeNotFound]
        [XPath("/div[2]/div[@class='panel-body']/div")]
        public string FirstExampleAsString { get; set; }

        [SkipNodeNotFound]
        [XPath("/div[2]/div[@class='panel-body']/div")]
        public Example FirstExample { get; set; }

        [SkipNodeNotFound]
        [XPath("/div[2]/div[@class='panel-body']/div")]
        public IEnumerable<String> ExamplesAsString { get; set; }

        [SkipNodeNotFound]
        [XPath("/div[2]/div[@class='panel-body']/div")]
        public IEnumerable<Example> Examples { get; set; }
        
    }



    [HasXPath]
    [DebuggerDisplay("{DeuEx} : {Fa}")]
    public class Example
    {


        [XPath("/div[@class='row']/div/p[@class='fa text-right']")]
        public string Fa { get; set; }


        [XPath("/div[@class='row']/div/p[@class='de text-left']")]
        public string DeuEx { get; set; }

    }

    #endregion Dictionary_TestClasses

    #region Encapsulated outer html test classes

    [HasXPath]
    public class OuterHtml
    {
        [XPath("//a", ReturnType.OuterHtml)]
        public List<OuterHtmlItem> Items { get; set; }

        [XPath("//a[@class='single']", ReturnType.OuterHtml)]
        public OuterHtmlItem Item3 { get; set; }


        [HasXPath]
        public class OuterHtmlItem
        {
            [XPath("a", "href")]
            [SkipNodeNotFound]
            public string Href { get; set; }

            [XPath("a")]
            [SkipNodeNotFound]
            public string Name { get; set; }
        }
    }
    #endregion
}
