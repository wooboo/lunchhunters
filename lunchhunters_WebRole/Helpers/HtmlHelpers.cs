using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace System.Web.Mvc.Html
{
    public static class HtmlHelpers
    {
        public static string MenuItem(this HtmlHelper helper, string text, string action, string controller)
        {
            var route = helper.ViewContext.RequestContext.RouteData;
            var currentcontroller = route.GetRequiredString("controller");
            var currentaction = route.GetRequiredString("action");
            string menu = "";
            if (currentcontroller == controller && currentaction == action)
                menu += "\n\t<li value=\"1\">" + helper.ActionLink(text, action, controller) + "</li>";
            else
                menu += "\n\t<li>" + helper.ActionLink(text, action, controller) + "</li>";
            return menu;
            
        }
        public static string TabbedMenu(this HtmlHelper helper, params MenuTab[] tabs)
        {
            var route = helper.ViewContext.RequestContext.RouteData;
            var controller = route.GetRequiredString("controller");
            var action = route.GetRequiredString("action");
            var menu = "\n\n<ul id=\"menu\">";

            foreach (var tab in tabs)
            {
                if (controller == tab.Controller && action == tab.Action)
                    menu += "\n\t<li value=\"1\">" + helper.ActionLink(tab.Text, tab.Action, tab.Controller) + "</li>";
                else
                    menu += "\n\t<li>" + helper.ActionLink(tab.Text, tab.Action, tab.Controller) + "</li>";
            }
            menu += "\n</ul>\n\n";
            return menu;
        }
    }

}
