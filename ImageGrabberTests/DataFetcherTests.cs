using System;
using System.Collections.Generic;
using ImageGrabberServices;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace ImageGrabberTests
{
    [TestClass]
    public class DataFetcherTests
    {
        static string testUrl = "https://imgur.com/gallery";
        static string testUrlWithImages = "https://en.wikipedia.org/wiki/Microsoft";
        static string downloadPath = "C:\\Test\\";

        [TestMethod]
        public void TestBasicGet()
        {
            HttpResponseMessage webResponse = DataFetcher.HttpGetSync(testUrl);
            Assert.IsTrue(webResponse.IsSuccessStatusCode, "Http get request failed.");

        }

        [TestMethod]
        public void TestAsyncGet()
        {
            HttpResponseMessage webResponse = DataFetcher.HttpGetAsync(testUrl).Result;
            Assert.IsTrue(webResponse.IsSuccessStatusCode, "Http get async request failed.");

        }


        [TestMethod]
        public void TestGetAndParse()
        {
            HttpResponseMessage webResponse = DataFetcher.HttpGetSync(testUrl);
            HtmlDocument html = null;
            if (webResponse.IsSuccessStatusCode)
            {
                html = DataFetcher.ExtractHtml(webResponse);
            }
            Assert.IsNotNull(html);
        }

        [TestMethod]
        public void TestFetchPageInfo()
        {
            PageInfo p = DataFetcher.FetchPageInfo(testUrl);

            Assert.IsNotNull(p.PageTitle);
            Assert.IsTrue(p.ImageCount > 0);
        }

        [TestMethod]
        public void TestCountElements()
        {
            HttpResponseMessage webResponse = DataFetcher.HttpGetSync(testUrl);
            if (webResponse.IsSuccessStatusCode)
            {
                HtmlDocument html = DataFetcher.ExtractHtml(webResponse);
                Dictionary<string, int> elements = DataFetcher.CountElements(html);
                Assert.IsTrue(elements.Count > 0);
                foreach (KeyValuePair<string, int> kvp in elements)
                {
                    Console.WriteLine("{0}:  {1}\n", kvp.Key, kvp.Value);
                }
            }
        }

        [TestMethod]
        public void TestRemoveInvalidCharacters()
        {
            string illegalFilename = "asdf?g.gif";
            string newFilename = DataFetcher.RemoveInvalidFilenameCharacters(illegalFilename);
            Assert.AreEqual("asdfg.gif", newFilename);
        }

        [TestMethod, Timeout(15000)]
        public void TestImageGet()
        {
            bool success = DataFetcher.DownloadImagesFromPageAsync(testUrlWithImages, downloadPath).Result;        
            Assert.IsTrue(success);

        }

        [TestMethod]
        [ExpectedException(typeof(TimeoutException))]
        public void TestSlowImageGetIsSlow()
        {
            var task = Task.Run(() => DataFetcher.DownloadImagesFromPageSync(testUrlWithImages, downloadPath));
            if (task.Wait(15000))
            {

            } else
            {
                throw new TimeoutException();
            }

        }

        [TestMethod]
        public void TestCheckAbsoluteUriRelative()
        {
            string relativeUri = "/images/relative.gif";
            bool isAbsolute = DataFetcher.CheckUrlAbsolute(relativeUri);
            Assert.IsFalse(isAbsolute, "check failed to identify relative uri");
        }

        [TestMethod]
        public void TestCheckAbsoluteUriAbsolute()
        {
            string absoluteUri = "http://www.google.com.au";
            bool isAbsolute = DataFetcher.CheckUrlAbsolute(absoluteUri);
            Assert.IsTrue(isAbsolute, "check failed to identify absolute uri");

        }

    }
}
