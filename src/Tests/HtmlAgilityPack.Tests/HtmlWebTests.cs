using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using Moq;
using NUnit.Framework;

namespace HtmlAgilityPack.Tests
{
    [TestFixture]
    class HtmlWebTests
    {
        private string _contentDir;

        [OneTimeSetUp]
        public void Setup()
        {
            _contentDir = Path.Combine(
                Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
                "files");
        }

        [Test]
        public void TestLoad()
        {
            var factoryMock = new Mock<IHttpWebRequestFactory>();
            factoryMock.Setup(x => x.Create(It.IsAny<Uri>()))
                .Returns<Uri>(u =>
                {
                    var reqMock = new Mock<IHttpWebRequest>();
                    reqMock.Setup(x => x.Request).Returns(null as HttpWebRequest);
                    reqMock.Setup(x => x.GetResponse()).Returns(() =>
                    {
                        var resMock = new Mock<IHttpWebResponse>();
                        resMock.Setup(x => x.ResponseUri).Returns(u);
                        resMock.Setup(x => x.StatusCode).Returns(HttpStatusCode.OK);
                        resMock.Setup(x => x.ContentType).Returns("text/html; charset=utf-8");
                        resMock.Setup(x => x.ContentEncoding).Returns("");
                        resMock.Setup(x => x.Headers).Returns(() =>
                        {
                            var headers = new WebHeaderCollection();
                            headers.Add("Cache-Control", "no-store, no-transform, no-cache");
                            headers.Add("Pragma", "no-cache");
                            headers.Add("X-Activity-Id", "ec46db78-0cbf-40c4-97a2-a2420cd8e1ca");
                            headers.Add("MS-CV", "wjoFJw0sEE+jo45O.0");
                            headers.Add("X-AppVersion", "1.0.7257.410");
                            headers.Add("X-Az", "{did:92e7dc58ca2143cfb2c818b047cc5cd1, rid: OneDeployContainer, sn: marketingsites-prod-odeastasia, dt: 2018-05-03T20:14:23.4188992Z, bt: 2019-11-14T08:13:40.0000000Z}");
                            headers.Add("ms-operation-id", "1be30902be694b4c86c5a401f0bb91fb");
                            headers.Add("P3P", "CP=\"CAO CONi OTR OUR DEM ONL\"");
                            headers.Add("X-UA-Compatible", "IE=Edge;chrome=1");
                            headers.Add("X-Content-Type-Options", "nosniff");
                            headers.Add("X-Frame-Options", "SAMEORIGIN");
                            headers.Add("Access-Control-Allow-Methods", "HEAD,GET,POST,PATCH,PUT,OPTIONS");
                            headers.Add("X-XSS-Protection", "1; mode=block");
                            headers.Add("X-EdgeConnect-MidMile-RTT", "41");
                            headers.Add("X-EdgeConnect-Origin-MEX-Latency", "282");
                            headers.Add("Date", "Sat, 16 Nov 2019 20:09:49 GMT");
                            headers.Add("Transfer-Encoding", "chunked");
                            headers.Add("Connection", "keep-alive, Transfer-Encoding");
                            headers.Add("Set-Cookie", "isFirstSession=1; path=/; secure; HttpOnly, MUID=054E212C88D965E415702F3A89116462; domain=.microsoft.com; expires=Tue, 16-Nov-2021 20:09:48 GMT; path=/;SameSite=None; secure, X-FD-FEATURES=ids=1690t1%2csfwaab%2catperf680t2%2c1786t1a%2c969t1%2c882c%2c936ca%2ctasmigration010%2ccartemberpl&imp=ec46db78-0cbf-40c4-97a2-a2420cd8e1ca; expires=Mon, 16-Nov-2020 20:09:48 GMT; path=/; secure; HttpOnly, X-FD-Time=1; expires=Sat, 16-Nov-2019 20:14:48 GMT; path=/; secure; HttpOnly, akacd_OneRF=1581710989~rv=77~id=b1ce48559f2a627f15dc2e792b7d9740; path=/; Expires=Fri, 14 Feb 2020 20:09:49 GMT, akacd_OneRF=1581710989~rv=77~id=b1ce48559f2a627f15dc2e792b7d9740; path=/; Expires=Fri, 14 Feb 2020 20:09:49 GMT");
                            headers.Add("TLS_version", "tls1.2");
                            headers.Add("Strict-Transport-Security", "max-age=31536000");
                            headers.Add("X-RTag", "RT");
                            headers.Add("Content-Type", "text/html; charset=utf-8");
                            headers.Add("Expires", "-1");
                            return headers;
                        });
                        resMock.Setup(x => x.GetResponseStream())
                            .Returns(() => new FileStream(
                                Path.Combine(_contentDir, "mshome.htm"),
                                FileMode.Open,
                                FileAccess.Read));
                        resMock.Setup(x => x.LastModified).Returns(DateTime.UtcNow);
                        return resMock.Object;
                    });
                    return reqMock.Object;
                });

            var htmlWeb = new HtmlWeb(factoryMock.Object);
            var doc = htmlWeb.Load(new Uri("https://www.microsoft.com/"));
            Assert.IsTrue(doc.DocumentNode.Descendants().Count() > 0);
        }

        [Test]
        public void TestLoadThrowsEncodingNotSupportedException()
        {
            var factoryMock = new Mock<IHttpWebRequestFactory>();
            factoryMock.Setup(x => x.Create(It.IsAny<Uri>()))
                .Returns<Uri>(u =>
                {
                    var reqMock = new Mock<IHttpWebRequest>();
                    reqMock.Setup(x => x.Request).Returns(null as HttpWebRequest);
                    reqMock.Setup(x => x.GetResponse()).Returns(() =>
                    {
                        var resMock = new Mock<IHttpWebResponse>();
                        resMock.Setup(x => x.ResponseUri).Returns(u);
                        resMock.Setup(x => x.StatusCode).Returns(HttpStatusCode.OK);
                        resMock.Setup(x => x.ContentType).Returns("text/html; charset=UTF-8");
                        resMock.Setup(x => x.ContentEncoding).Returns("identity");
                        resMock.Setup(x => x.Headers).Returns(() =>
                        {
                            var headers = new WebHeaderCollection();
                            headers.Add("Transfer-Encoding", "chunked");
                            headers.Add("Connection", "keep-alive");
                            headers.Add("X-Cache-Hits", "4");
                            headers.Add("Cache-Control", "no-store, must-revalidate, no-cache, max-age=0");
                            headers.Add("X-Chef", "Gennaro");
                            headers.Add("Pragma", "public");
                            headers.Add("X-Cache-Keep", "3600.000");
                            headers.Add("Vary", "Accept-Encoding");
                            headers.Add("X-Country-Code", "NZ");
                            headers.Add("X-Cache-Status", "MISS");
                            headers.Add("X-Backend", "i_04400f0cd28e027e7_10_170_21_65");
                            headers.Add("Date", "Fri, 15 Nov 2019 07:44:42 GMT");
                            headers.Add("X-Cache-TTL-Remaining", "595.653");
                            headers.Add("Server", "ZENEDGE");
                            headers.Add("X-Zen-Fury", "efadaddb4a91c6f51faaa477a91c047faa84f52d");
                            headers.Add("X-Cache", "FoodCache");
                            headers.Add("Accept-Ranges", "bytes");
                            headers.Add("Age", "3004");
                            headers.Add("X-Cache-Age", "3004.347");
                            headers.Add("X-Cdn", "Served-By-Zenedge");
                            headers.Add("Content-Type", "text/html; charset=UTF-8");
                            headers.Add("Last-Modified", "Thu, 01 Jan 1970 00:00:00 GMT");
                            headers.Add("Expires", "Fri, 15 Nov 2019 08:44:41 GMT");
                            headers.Add("Content-Encoding", "identity");
                            return headers;
                        });
                        resMock.Setup(x => x.GetResponseStream()).Returns(
                            () => new MemoryStream());
                        resMock.Setup(x => x.LastModified).Returns(DateTime.UtcNow);
                        return resMock.Object;
                    });
                    return reqMock.Object;
                });

            var htmlWeb = new HtmlWeb(factoryMock.Object);
            Exception exception = null;
            try
            {
                htmlWeb.Load(new Uri("https://www.jamieoliver.com/recipes/chicken-recipes/chicken-tofu-noodle-soup/"));
            }
            catch (Exception e)
            {
                exception = e;
            }
            Assert.That(exception, Is.InstanceOf(typeof(EncodingNotSupportedException)));
        }
    }
}

