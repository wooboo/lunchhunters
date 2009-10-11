/* Script# jQuery Object Interfaces & Constants v0.1
 * Author: Christopher Crooker (chrisc@schakra.com)
 * Copyright: (c) 2009, Schakra Inc.

Permission is hereby granted, free of charge, to any person
obtaining a copy of this software and associated documentation
files (the "Software"), to deal in the Software without
restriction, including without limitation the rights to use,
copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the
Software is furnished to do so, subject to the following
conditions:

The above copyright notice and this permission notice shall be
included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES
OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT
HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY,
WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
OTHER DEALINGS IN THE SOFTWARE. */

using System;
using System.DHTML;

//using jQuery;

namespace jQueryInterfaces
{
    public static class Easing
    {
        public const string Linear = "linear";
        public const string Swing = "swing";
    }

    public static class Speed
    {
        public const string Slow = "slow";
        public const string Normal = "normal";
        public const string Fast = "fast";
    }

    public static class EventType
    {
        public const string Blur = "blur";
        public const string Focus = "focus";
        public const string Load = "load";
        public const string Resize = "resize";
        public const string Scroll = "scroll";
        public const string Unload = "unload";
        public const string BeforeUnload = "beforeunload";
        public const string Click = "click";
        public const string DoubleClick = "dblclick";
        public const string MouseDown = "mouseDown";
        public const string MouseUp = "mouseup";
        public const string MouseMove = "mousemove";
        public const string MouseOver = "mouseover";
        public const string MouseOut = "mouseout";
        public const string MouseEnter = "mouseenter";
        public const string MouseLeave = "mouseleave";
        public const string Change = "change";
        public const string Select = "select";
        public const string Submit = "submit";
        public const string KeyDown = "keydown";
        public const string KeyPress = "keypress";
        public const string KeyUp = "keyup";
        public const string Error = "error";
    }

    public static class LiveEventType
    {
        public const string Click = "click";
        public const string DoubleClick = "dblclick";
        public const string MouseDown = "mouseDown";
        public const string MouseUp = "mouseup";
        public const string MouseMove = "mousemove";
        public const string MouseOver = "mouseover";
        public const string MouseOut = "mouseout";
        public const string KeyDown = "keydown";
        public const string KeyPress = "keypress";
        public const string KeyUp = "keyup";
    }

    public static class DataType
    {
        public const string Xml = "xml";
        public const string Html = "html";
        public const string Script = "script";
        public const string Json = "json";
        public const string JsonP = "jsonp";
        public const string Text = "text";
    }

    // This generates basically pointless code but it was the best option I could come up with to avoid
    // ugly casts all over the place or actually having to include script definitions for the interfaces
    // because empty method implementations or fields with default values could possibly cause problems

    public static class ObjectFactory
    {
        public static Position CreatePosition(Dictionary data)
        {
            return (Position)((object)(data ?? new Dictionary()));
        }

        public static Position CreateEventState(Dictionary data)
        {
            return (Position)((object)(data ?? new Dictionary()));
        }

        public static Position CreateAjaxOptions(Dictionary data)
        {
            return (Position)((object)(data ?? new Dictionary()));
        }
    }

    /// <summary>
    /// Interface of the jQuery position object.
    /// </summary>
    [Imported]
    public abstract class Position
    {
        public int Top;
        public int Left;
    }

    /// <summary>
    /// Inteface of the jQuery Event object.
    /// </summary>
    [Imported]
    public abstract class EventState
    {
        public string Type;
        public DOMElement Target;
        public Dictionary Data;
        public DOMElement RelatedTarget;
        public DOMElement CurrentTarget;
        public int PageX;
        public int PageY;
        public object Result;
        public int TimeStamp;

        public abstract void PreventDefault();
        public abstract bool IsDefaultPrevented();
        public abstract void StopPropagation();
        public abstract bool IsPropagationStopped();
        public abstract void StopImmediatePropagation();
        public abstract bool IsImmediatePropagationStopped();
    }

    /// <summary>
    /// Inteface of the jQuery AJAX options object.
    /// </summary>
    [Imported]
    public abstract class AjaxOptions
    {
        public bool Async;
        public Function BeforeSend;
        public bool Cache;
        public Function Complete;
        public string ContentType;
        public Dictionary Data;
        public Function DataFilter;
        public string DataType;
        public Function Error;
        public bool Global;
        public bool IfModified;
        public string Jsonp;
        public string Password;
        public bool ProcessData;
        public string ScriptCharset;
        public Function Success;
        public int Timeout;
        public string Type;
        public string Url;
        public string Username;
        public Function Xhr;
    }

    /// <summary>
    /// Inteface of the jQuery support object.
    /// </summary>
    [Imported]
    public abstract class Support
    {
        public bool BoxModel;
        public bool CssFloat;
        public bool HrefNormalized;
        public bool HtmlSerialize;
        public bool LeadingWhitespace;
        public bool NoCloneEvent;
        public bool ObjectAll;
        public bool Opacity;
        public bool ScriptEval;
        public bool Style;
        public bool Tbody;
    }
}
