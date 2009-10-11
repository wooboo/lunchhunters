using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace System.Web.Mvc.Html
{
    public class MenuTab
    {
        private MenuTab(string text, string action, string controller)
        {
            Text = text;
            Action = action;
            Controller = controller;
        }

        public static MenuTab Create(string text, string action, string controller)
        {
            return new MenuTab(text, action, controller);
        }

        public string Text { get; private set; }
        public string Action { get; private set; }
        public string Controller { get; private set; }
    }
}
