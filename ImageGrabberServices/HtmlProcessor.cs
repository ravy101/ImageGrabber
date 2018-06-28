using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using HtmlAgilityPack;

namespace ImageGrabberServices
{
    public static class HtmlProcessor
    {
        public static HtmlDocument ExtractHtml(HttpResponseMessage response)
        {
            HtmlDocument html = new HtmlDocument();
            html.Load(response.Content.ReadAsStreamAsync().Result);
            return html;
        }

        public static Dictionary<string, int> CountElements(HtmlDocument html)
        {
            Dictionary<string, int> elements = new Dictionary<string, int>();
            foreach (HtmlNode n in html.DocumentNode.SelectNodes("//*"))
            {
                if (elements.ContainsKey(n.Name))
                {
                    elements[n.Name]++;
                } else {
                    elements.Add(n.Name, 1);
                }
            }
            return elements;

        }
    }
}
