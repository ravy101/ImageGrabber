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
    //DataFetcher class provides basic http get and html processing services for the downloading/caching of website data. 
    //Includes methods demonstrating the advantages of asynchronous task multithreading over lazy threading and forced sync
    public static class DataFetcher
    {

        //method downloads image files referenced on a given url and saves them to supplied path using async tasks
        public static async Task<bool> DownloadImagesFromPageAsync(string url, string destinationPath)
        {
            bool success = true;
            var imageTasks = new List<Task<ImageFile>>();

            //download base page and convert to html
            HttpResponseMessage pageResponse = HttpGetSync(url);
            HtmlDocument html = ExtractHtml(pageResponse);
            
            //extract image elements and initiate resource download tasks 
            foreach (HtmlNode n in html.DocumentNode.SelectNodes("//descendant::img"))
            {
                if (n.Attributes["src"] != null)
                {
                    imageTasks.Add(DownloadImageAsync(n.Attributes["src"].Value, url));
                }
                
            }

            //save files to specified folder
            FileStream stream = null;
            BinaryWriter writer = null;
            foreach (Task<ImageFile> ft in imageTasks)
            {
                try
                {
                    //await download task if not finished
                    ImageFile f = await ft;
                    stream = new FileStream(Path.Combine(destinationPath, f.FileName), FileMode.Create);
                    writer = new BinaryWriter(stream);
                    writer.Write(f.ImageData);
                } catch
                {
                    success = false;
                } finally { 
                    stream.Close();
                    writer.Close();
                }
            }
            return success;
        }

        //Deliberately slow method demonstrating the cost of lazy threading
        public static bool DownloadImagesFromPageSync(string url, string destinationPath)
        {
            List<ImageFile> images = new List<ImageFile>();
            bool success = true;
            HttpResponseMessage pageResponse = HttpGetSync(url);
            HtmlDocument html = ExtractHtml(pageResponse);
            foreach (HtmlNode n in html.DocumentNode.SelectNodes("//descendant::img"))
            {
                if (n.Attributes["src"] != null)
                {
                    string imageUrl = n.Attributes["src"].Value;
                    //lazy threading awaits each http response in sequence. Significantly slower at this stage
                    HttpResponseMessage imageResponse = HttpGetSync(imageUrl, url);               
                    if (imageResponse.IsSuccessStatusCode)
                    {
                        ImageFile file = new ImageFile();
                        file.FileName = RemoveInvalidFilenameCharacters(Path.GetFileName(imageUrl));
                        file.ImageData = imageResponse.Content.ReadAsByteArrayAsync().Result;
                        images.Add(file);
                    }
                    
                }

            }

            //lazy threading method works with images instead of tasks
            foreach (ImageFile f in images)
            {
                FileStream stream = new FileStream(Path.Combine(destinationPath, f.FileName), FileMode.Create);
                BinaryWriter writer = new BinaryWriter(stream);
                try
                {
                    writer.Write(f.ImageData);
                }
                catch
                {
                    success = false;
                }
                finally
                {

                    stream.Close();
                    writer.Close();
                }
            }
            return success;
        }

        //method downloads a specified image file and creates a waitable task
        private static async Task<ImageFile> DownloadImageAsync(string imageUrl, string baseUrl)
        {
            HttpResponseMessage imageResponse = await HttpGetAsync(imageUrl, baseUrl);
            ImageFile file = new ImageFile();
            if (imageResponse.IsSuccessStatusCode)
            {                 
                    file.FileName = RemoveInvalidFilenameCharacters(Path.GetFileName(imageUrl));
                    file.ImageData =  await imageResponse.Content.ReadAsByteArrayAsync();
            }
            return file;
        }

        //fetches a website and provides basic information on the returned html
        public static PageInfo FetchPageInfo(string url)
        {          
            HttpResponseMessage pageResponse = HttpGetSync(url);
            PageInfo info = new PageInfo();
            info.URL = url;
            info.RequestSuccess = pageResponse.IsSuccessStatusCode;
            if (info.RequestSuccess)
            {
                HtmlDocument html = ExtractHtml(pageResponse);
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

        //method retrieves the response from a given url sync
        public static HttpResponseMessage HttpGetSync(string url, string baseAddress = null)
        {
            HttpClient client = new HttpClient();
            if (baseAddress != null)
            {
                client.BaseAddress = new Uri(baseAddress);
            }
            HttpResponseMessage response = client.GetAsync(url).Result;
            return response;
        }

        //method retrieves the response from a given url asynchronously
        public static Task<HttpResponseMessage> HttpGetAsync(string url, string baseAddress = null)
        {
            HttpClient client = new HttpClient();
            if (baseAddress != null)
            {
                client.BaseAddress = new Uri(baseAddress);
            }
            Task<HttpResponseMessage> response = client.GetAsync(url);
            return response;
        }

        //return true if an abolute uri can be formed using the given url
        public static bool CheckUrlAbsolute(string url)
        {         
            return Uri.TryCreate(url, UriKind.Absolute, out Uri u);
        }

        //remove all invalid file name characters from the given string
        public static string RemoveInvalidFilenameCharacters(string filename)
        {         
            string newFilename = filename.Replace("?", "");
            foreach (char invalidChar in Path.GetInvalidPathChars())
            {
                newFilename = newFilename.Replace(invalidChar.ToString(), "");
            }
            return newFilename;
        }

        //parses the html content of an http response message
        public static HtmlDocument ExtractHtml(HttpResponseMessage response)
        {
            HtmlDocument html = new HtmlDocument();
            html.Load(response.Content.ReadAsStreamAsync().Result);
            return html;
        }

        //Takes a recursive count of the element types contained in a given html document
        public static Dictionary<string, int> CountElements(HtmlDocument html)
        {
            Dictionary<string, int> elements = new Dictionary<string, int>();
            //every node and child node in html document
            foreach (HtmlNode n in html.DocumentNode.SelectNodes("//*"))
            {
                if (elements.ContainsKey(n.Name))
                {
                    //increment existing element count
                    elements[n.Name]++;
                }
                else
                {
                    //initialise new element type count
                    elements.Add(n.Name, 1);
                }
            }
            return elements;
        }

    }
    
}
