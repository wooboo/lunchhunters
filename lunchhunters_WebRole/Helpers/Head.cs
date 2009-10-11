using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace System.Web.Mvc
{
    public class Head
    {
        public static string Stylesheet(string href)
        {
            return string.Format("<link href=\"{0}\" rel=\"stylesheet\" type=\"text/css\" />\n", href);
        }
        public static string Script(string href)
        {
            return string.Format("<script src=\"{0}\" type=\"text/javascript\" ></script>", href);
        }
    }
    public enum LinkTypes
    {
        Stylesheet
    }
}
