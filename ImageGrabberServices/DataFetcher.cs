using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using HtmlAgilityPack;



namespace ImageGrabberServices
{
    public static class DataFetcher
    {

        public static async void DownloadImagesFromPageAsync(string url, string destinationPath)
        {
            var imageTasks = new List<Task<ImageFile>>();

            HttpResponseMessage pageResponse = HttpGet(url);
            HtmlDocument html = HtmlProcessor.ExtractHtml(pageResponse);
            foreach (HtmlNode n in html.DocumentNode.SelectNodes("//descendant::img"))
            {
                if (n.Attributes["src"] != null)
                {
                    imageTasks.Add(DownloadImageAsync(n.Attributes["src"].Value, url));
                }
                
            }

            //wait for all image download threads to finish
            Task.WaitAll(imageTasks.ToArray());

            foreach(Task<ImageFile> ft in imageTasks)
            {
                ImageFile f = ft.Result;
                FileStream stream = new FileStream(Path.Combine(destinationPath, f.FileName), FileMode.Create);
                BinaryWriter writer = new BinaryWriter(stream);
                writer.Write(f.ImageData);
                stream.Close();
                writer.Close();
            }
    
        }

        private static async Task<ImageFile> DownloadImageAsync(string imageUrl, string baseUrl)
        {
            HttpResponseMessage imageResponse = HttpGet(imageUrl, baseUrl);
            ImageFile file = new ImageFile();
            if (imageResponse.IsSuccessStatusCode)
            {                 
                    file.FileName = RemoveInvalidFilenameCharacters(Path.GetFileName(imageUrl));
                    file.ImageData =  await imageResponse.Content.ReadAsByteArrayAsync();
            }
            return file;
        }

        public static PageInfo FetchPageInfo(string url)
        {
            
            HttpResponseMessage pageResponse = HttpGet(url);
            PageInfo info = new PageInfo();
            info.URL = url;
            info.RequestSuccess = pageResponse.IsSuccessStatusCode;
            if (info.RequestSuccess)
            {
                HtmlDocument html = HtmlProcessor.ExtractHtml(pageResponse);
                HtmlNode titleNode = html.DocumentNode.SelectSingleNode("//title");
                if (titleNode != null)
                {
                    info.PageTitle = titleNode.InnerText;
                }
                
                info.ImageCount = html.DocumentNode.SelectNodes("//descendant::img").Count;
                info.IncludesJavascript = true; 
            }
            return info;
        }

        public static HttpResponseMessage HttpGet(string url, string baseAddress = null)
        {
            HttpClient client = new HttpClient();
            if (baseAddress != null)
            {
                client.BaseAddress = new Uri(baseAddress);
            }
            HttpResponseMessage response = client.GetAsync(url).Result;
            return response;
        }

        private static bool CheckUrlAbsolute(string url)
        {
            //return true if an abolute uri can be formed using the given url
            return Uri.TryCreate(url, UriKind.Absolute, out Uri u);
        }

        public static string RemoveInvalidFilenameCharacters(string filename)
        {
            //remove all invalid file name characters from the given string
            string newFilename = filename.Replace("?", "");
            foreach (char invalidChar in Path.GetInvalidPathChars())
            {
                newFilename = newFilename.Replace(invalidChar.ToString(), "");
            }
            return newFilename;
        }

    }
    
}
