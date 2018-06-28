using System;
using System.Collections.Generic;
using ImageGrabberServices;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net.Http;
using System.Net.Http.Headers;
using HtmlAgilityPack;

namespace ImageGrabberTests
{
    [TestClass]
    public class DataFetcherTests
    {
        static string testUrl = "https://imgur.com/gallery";

        [TestMethod]
        public void TestBasicGet()
        {
            HttpResponseMessage webResponse = DataFetcher.HttpGet(testUrl);
            Assert.IsTrue(webResponse.IsSuccessStatusCode, "Http get request failed.");

        }

        [TestMethod]
        public void TestGetAndParse()
        {
            HttpResponseMessage webResponse = DataFetcher.HttpGet(testUrl);
            if (webResponse.IsSuccessStatusCode)
            {
                HtmlDocument html = HtmlProcessor.ExtractHtml(webResponse);
            }
        }

        [TestMethod]
        public void TestCountElements()
        {
            HttpResponseMessage webResponse = DataFetcher.HttpGet(testUrl);
            if (webResponse.IsSuccessStatusCode)
            {
                HtmlDocument html = HtmlProcessor.ExtractHtml(webResponse);
                Dictionary<string, int> elements = HtmlProcessor.CountElements(html);
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
    }
}
