using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageGrabberServices
{
    public class PageInfo
    {
        public String URL { get; set; }
        public bool RequestSuccess { get; set; }
        public String PageTitle { get; set; }
        public bool IncludesJavascript { get; set; }
        public int ImageCount { get; set; }
    }
}
