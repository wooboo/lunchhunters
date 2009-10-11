/* Script# jQuery Import v0.1
 * Author: Christopher Crooker (chrisc@schakra.com)
 * Copyright (c) 2009, Schakra Inc.

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

using jQueryInterfaces;

/// <summary>
/// Interface of the jQuery method exposed as members of an extensible static class whose memebers will be global.
/// </summary>
[Imported]
[GlobalMethods]
public static partial class Global
{
    public static jQuery.Elements jQuery(string expression)
    {
        return null;
    }

    [AlternateSignature]
    public static extern jQuery.Elements jQuery(WindowInstance window);

    [AlternateSignature]
    public static extern jQuery.Elements jQuery(DOMDocument document);

    [AlternateSignature]
    public static extern jQuery.Elements jQuery(DOMElement element);

    [AlternateSignature]
    public static extern jQuery.Elements jQuery(DOMElement[] elements);

    [AlternateSignature]
    public static extern jQuery.Elements jQuery(string expression, jQuery.Elements context);

    [AlternateSignature]
    public static extern jQuery.Elements jQuery(string html, DOMDocument ownerDocument);

    [AlternateSignature]
    public static extern jQuery.Elements jQuery(Function documentReady);
}

namespace jQuery
{
    /// <summary>
    /// Interface of the "static" jQuery method members. References render to jQuery.fn based on namespace.
    /// </summary>
    [Imported]
    public static partial class fn
    {
        #region Core

        public static Elements Extend(Dictionary extension)
        {
            return null;
        }

        #endregion Core

        #region Ajax

        public static XMLHttpRequest Ajax(AjaxOptions options)
        {
            return null;
        }

        public static XMLHttpRequest Get(string url)
        {
            return null;
        }

        [AlternateSignature]
        public static extern XMLHttpRequest Get(string url, Dictionary data);

        [AlternateSignature]
        public static extern XMLHttpRequest Get(string url, Function successHandler);

        [AlternateSignature]
        public static extern XMLHttpRequest Get(string url, Function successHandler, string dataType);

        [AlternateSignature]
        public static extern XMLHttpRequest Get(string url, Dictionary data, Function successHandler);

        [AlternateSignature]
        public static extern XMLHttpRequest Get(string url, Dictionary data, Function successHandler, string dataType);

        public static XMLHttpRequest GetJSON(string url)
        {
            return null;
        }

        [AlternateSignature]
        public static extern XMLHttpRequest GetJSON(string url, Dictionary data);

        [AlternateSignature]
        public static extern XMLHttpRequest GetJSON(string url, Function successHandler);

        [AlternateSignature]
        public static extern XMLHttpRequest GetJSON(string url, Dictionary data, Function successHandler);

        public static XMLHttpRequest GetScript(string url)
        {
            return null;
        }

        [AlternateSignature]
        public static extern XMLHttpRequest GetScript(string url, Function successHandler);

        public static XMLHttpRequest Post(string url)
        {
            return null;
        }

        [AlternateSignature]
        public static extern XMLHttpRequest Post(string url, Dictionary data);

        [AlternateSignature]
        public static extern XMLHttpRequest Post(string url, Function successHandler);

        [AlternateSignature]
        public static extern XMLHttpRequest Post(string url, Function successHandler, string dataType);

        [AlternateSignature]
        public static extern XMLHttpRequest Post(string url, Dictionary data, Function successHandler);

        [AlternateSignature]
        public static extern XMLHttpRequest Post(string url, Dictionary data, Function successHandler, string dataType);

        public static void AjaxSetup(AjaxOptions options) { }

        #endregion Ajax
        
        #region Utilities

        public static Support Support;

        //// Deprecated browser version and support related properties (e.g. boxModel) are not implemented

        public static Array Each(Array array, Function valueHandler)
        {
            return null;
        }

        [AlternateSignature]
        public static extern Dictionary Each(Dictionary data, Function valueHandler);

        [AlternateSignature]
        public static extern object Extend(object target, Dictionary extension);

        [AlternateSignature]
        public static extern object Extend(bool deep, object target, Dictionary extension);

        [AlternateSignature]
        public static extern object Extend(object target, Dictionary firstExtension, Dictionary secondExtension);

        [AlternateSignature]
        public static extern object Extend(bool deep, object target,
            Dictionary firstExtension, Dictionary secondExtension);

        [AlternateSignature]
        public static extern object Extend(object target,
            Dictionary firstExtension, Dictionary secondExtension, Dictionary thirdExtension);

        [AlternateSignature]
        public static extern object Extend(bool deep, object target,
            Dictionary firstExtension, Dictionary secondExtension, Dictionary thirdExtension);

        public static Array Grep(Array array, Function arrayPredicate)
        {
            return null;
        }

        [AlternateSignature]
        public static extern Array Grep(Array array, Function arrayPredicate, bool invert);
        
        public static Array MakeArray(object data)
        {
            return null;
        }

        public static Array Map(Array array, Function arrayTranslator)
        {
            return null;
        }

        public static int InArray(object value, Array array)
        {
            return -1;
        }

        public static Array Merge(Array first, Array second)
        {
            return null;
        }

        public static DOMElement[] Unique(DOMElement[] elements)
        {
            return null;
        }

        public static bool IsArray(object reference)
        {
            return false;
        }

        public static bool IsFunction(object reference)
        {
            return false;
        }

        public static string Trim(string value)
        {
            return null;
        }

        public static string Param(object data)
        {
            return null;
        }

        [AlternateSignature]
        public static extern string Param(Elements elements);

        [AlternateSignature]
        public static extern string Param(DOMElement[] elements);

        #endregion Utilities
    }

    /// <summary>
    /// Provides access to the jQuery.fx.off global effects override.
    /// </summary>
    [Imported]
    public static class fx
    {
        public static bool Off;
    }

    /// <summary>
    /// Interface of the jQuery result object.
    /// </summary>
    [Imported]
    [IgnoreNamespace]
    public abstract partial class Elements
    {
        #region Core

        public abstract Elements Each(Function function);

        [Obsolete("Length is faster.")]
        public abstract int Size();

        public int Length;
        public string Selector;
        public object Context;

        public abstract Elements Eq(int index);

        public abstract DOMElement[] Get();

        [AlternateSignature]
        public extern DOMElement Get(int index);

        public abstract int Index(DOMElement element);

        [AlternateSignature]
        public extern int Index(Elements firstElement);

        public abstract object Data(string name);

        [AlternateSignature]
        public extern Elements Data(string name, object value);

        public abstract Elements RemoveData(string name);

        public abstract Function[] Queue();

        [AlternateSignature]
        public extern Function[] Queue(string name);

        [AlternateSignature]
        public extern Elements Queue(Function addFunction);

        [AlternateSignature]
        public extern Elements Queue(string name, Function addFunction);

        [AlternateSignature]
        public extern Elements Queue(Function[] replacementQueue);

        [AlternateSignature]
        public extern Elements Queue(string name, Function[] replacementQueue);

        public abstract Elements Dequeue();

        [AlternateSignature]
        public extern Elements Dequeue(string name);

        public abstract Elements Extend(Dictionary extension);

        public abstract Elements NoConflict();

        [AlternateSignature]
        public extern Elements NoConflict(bool extreme);

        #endregion Core

        #region Attributes

        public abstract string Attr(string name);

        [AlternateSignature]
        public extern Elements Attr(Dictionary attributes);

        [AlternateSignature]
        public extern Elements Attr(string name, string value);

        [AlternateSignature]
        public extern Elements Attr(string name, Function computedValue);

        public abstract Elements RemoveAttr(string name);

        public abstract Elements AddClass(string classes);

        public abstract Elements HasClass(string className);

        public abstract Elements RemoveClass(string classes);

        public abstract Elements ToggleClass(string className);

        [AlternateSignature]
        public extern Elements ToggleClass(string className, bool condition);

        public abstract string Html();

        [AlternateSignature]
        public extern Elements Html(string html);

        public abstract string Text();

        [AlternateSignature]
        public extern Elements Text(string text);

        public abstract string Val();

        [AlternateSignature]
        public extern string Val(string value);

        [AlternateSignature]
        public extern string Val(string[] chooseValues);

        #endregion Attributes

        #region Traversing

        public abstract Elements Filter(string expression);

        [AlternateSignature]
        public extern Elements Filter(Function predicate);

        public abstract bool Is(string expression);

        public abstract Elements Map(Function translator);

        public abstract Elements Not(string expression);

        public abstract Elements Slice(int begin);

        [AlternateSignature]
        public extern Elements Slice(int begin, int end);

        public abstract Elements Add(string expression);

        public abstract Elements Children();

        [AlternateSignature]
        public extern Elements Children(string expression);

        public abstract Elements Closest(string expression);

        public abstract Elements Contents();

        public abstract Elements Find(string expression);

        public abstract Elements Next();

        [AlternateSignature]
        public extern Elements Next(string expression);

        public abstract Elements NextAll();

        [AlternateSignature]
        public extern Elements NextAll(string expression);

        public abstract Elements OffsetParent();

        public abstract Elements Parent();

        [AlternateSignature]
        public extern Elements Parent(string expression);

        public abstract Elements Parents();

        [AlternateSignature]
        public extern Elements Parents(string expression);

        public abstract Elements Prev();

        [AlternateSignature]
        public extern Elements Prev(string expression);

        public abstract Elements PrevAll();

        [AlternateSignature]
        public extern Elements PrevAll(string expression);

        public abstract Elements Siblings();

        [AlternateSignature]
        public extern Elements Siblings(string expression);

        public abstract Elements AndSelf();

        public abstract Elements End();

        #endregion Traversing

        #region Manipulation

        public abstract Elements Append(string html);

        [AlternateSignature]
        public extern Elements Append(DOMElement element);

        [AlternateSignature]
        public extern Elements Append(Elements elements);

        public abstract Elements AppendTo(string selector);

        public abstract Elements Prepend(string html);

        [AlternateSignature]
        public extern Elements Prepend(DOMElement element);

        [AlternateSignature]
        public extern Elements Prepend(Elements elements);

        public abstract Elements PrependTo(string selector);

        public abstract Elements After(string html);

        [AlternateSignature]
        public extern Elements After(DOMElement element);

        [AlternateSignature]
        public extern Elements After(Elements elements);

        public abstract Elements Before(string html);

        [AlternateSignature]
        public extern Elements Before(DOMElement element);

        [AlternateSignature]
        public extern Elements Before(Elements elements);

        public abstract Elements InsertAfter(string selector);

        public abstract Elements InsertBefore(string selector);

        public abstract Elements Wrap(string html);

        [AlternateSignature]
        public extern Elements Wrap(DOMElement element);

        public abstract Elements WrapAll(string html);

        [AlternateSignature]
        public extern Elements WrapAll(DOMElement element);

        public abstract Elements WrapInner(string html);

        [AlternateSignature]
        public extern Elements WrapInner(DOMElement element);

        public abstract Elements ReplaceWith(string html);

        [AlternateSignature]
        public extern Elements ReplaceWith(DOMElement element);

        [AlternateSignature]
        public extern Elements ReplaceWith(Elements elements);

        public abstract Elements ReplaceAll(string selector);

        public abstract Elements Empty();

        public abstract Elements Remove();

        [AlternateSignature]
        public extern Elements Remove(string expression);

        public abstract Elements Clone();

        [AlternateSignature]
        public extern Elements Clone(bool cloneEventHandlers);

        #endregion Manipulation

        #region CSS

        public abstract string Css(string name);

        [AlternateSignature]
        public extern Elements Css(Dictionary properties);

        [AlternateSignature]
        public extern Elements Css(string name, string value);

        public abstract Position Offset();

        public abstract Position Position();

        public abstract int ScrollTop();

        [AlternateSignature]
        public extern Elements ScrollTop(int top);

        public abstract int ScrollLeft();

        [AlternateSignature]
        public extern Elements ScrollLeft(int left);

        public abstract int Height();

        [AlternateSignature]
        public extern Elements Height(int pixelHeight);

        [AlternateSignature]
        public extern Elements Height(string cssHeight);

        public abstract int Width();

        [AlternateSignature]
        public extern Elements Width(int pixelWidth);

        [AlternateSignature]
        public extern Elements Width(string cssWidth);

        public abstract int InnerHeight();

        public abstract int InnerWidth();

        public abstract int OuterHeight();

        [AlternateSignature]
        public extern int OuterHeight(bool includeMargin);

        public abstract int OuterWidth();

        [AlternateSignature]
        public extern int OuterWidth(bool includeMargin);

        #endregion CSS

        #region Events

        public abstract Elements Ready(Function documentReady);

        public abstract Elements Bind(string eventType, Function eventHandler);

        [AlternateSignature]
        public extern Elements Bind(string eventType, Dictionary data, Function eventHandler);

        public abstract Elements One(string eventType, Function eventHandler);

        [AlternateSignature]
        public extern Elements One(string eventType, Dictionary data, Function eventHandler);

        public abstract Elements Trigger(string eventType);

        [AlternateSignature]
        public extern Elements Trigger(string eventType, object[] additionalHandlerArguments);

        [AlternateSignature]
        public extern Elements Trigger(Dictionary typedEventFields);

        [AlternateSignature]
        public extern Elements Trigger(Dictionary typedEventFields, object[] additionalHandlerArguments);

        [AlternateSignature]
        public extern Elements Trigger(EventState eventState);

        [AlternateSignature]
        public extern Elements Trigger(EventState eventState, object[] additionalHandlerArguments);

        public abstract Elements TriggerHandler(string eventType);

        [AlternateSignature]
        public extern Elements TriggerHandler(string eventType, object[] additionalHandlerArguments);

        [AlternateSignature]
        public extern Elements TriggerHandler(Dictionary typedEventFields);

        [AlternateSignature]
        public extern Elements TriggerHandler(Dictionary typedEventFields, object[] additionalHandlerArguments);

        [AlternateSignature]
        public extern Elements TriggerHandler(EventState eventState);

        [AlternateSignature]
        public extern Elements TriggerHandler(EventState eventState, object[] additionalHandlerArguments);

        public abstract Elements Unbind();

        [AlternateSignature]
        public extern Elements Unbind(string eventType);

        [AlternateSignature]
        public extern Elements Unbind(Dictionary typedEventFields);

        [AlternateSignature]
        public extern Elements Unbind(EventState eventState);

        [AlternateSignature]
        public extern Elements Unbind(Function eventHandler);

        [AlternateSignature]
        public extern Elements Unbind(string eventType, Function eventHandler);

        [AlternateSignature]
        public extern Elements Unbind(Dictionary typedEventFields, Function eventHandler);

        [AlternateSignature]
        public extern Elements Unbind(EventState eventState, Function eventHandler);

        public abstract Elements Live(string eventType, Function eventHandler);

        public abstract Elements Die();

        [AlternateSignature]
        public extern Elements Die(string eventType);

        [AlternateSignature]
        public extern Elements Die(Function eventHandler);

        [AlternateSignature]
        public extern Elements Die(string eventType, Function eventHandler);

        public abstract Elements Hover(Function overHandler, Function outHandler);

        public abstract Elements Toggle(Function firstHandler, Function secondHandler);

        [AlternateSignature]
        public extern Elements Toggle(Function firstHandler, Function secondHandler, Function thirdHandler);

        [AlternateSignature]
        public extern Elements Toggle(Function firstHandler, Function secondHandler,
            Function thirdHandler, Function fourthHandler);

        [AlternateSignature]
        public extern Elements Toggle(Function firstHandler, Function secondHandler,
            Function thirdHandler, Function fourthHandler, Function fifthHandler);

        [AlternateSignature]
        public extern Elements Toggle(Function firstHandler, Function secondHandler,
            Function thirdHandler, Function fourthHandler, Function fifthHandler, Function sixthHandler);

        [AlternateSignature]
        public extern Elements Toggle(Function firstHandler, Function secondHandler, Function thirdHandler,
            Function fourthHandler, Function fifthHandler, Function sixthHandler, Function seventhHandler);

        public abstract Elements Blur();

        [AlternateSignature]
        public extern Elements Blur(Function blurHandler);

        public abstract Elements Change();

        [AlternateSignature]
        public extern Elements Change(Function changeHandler);

        public abstract Elements Click();

        [AlternateSignature]
        public extern Elements Click(Function clickHandler);

        public abstract Elements DblClick();

        [AlternateSignature]
        public extern Elements DblClick(Function doubleClickHandler);

        public abstract Elements Error();

        [AlternateSignature]
        public extern Elements Error(Function errorHandler);

        public abstract Elements Focus();

        [AlternateSignature]
        public extern Elements Focus(Function focusHandler);

        public abstract Elements Keydown();

        [AlternateSignature]
        public extern Elements Keydown(Function keyDownHandler);

        public abstract Elements Keypress();

        [AlternateSignature]
        public extern Elements Keypress(Function keyPressHandler);

        public abstract Elements Keyup();

        [AlternateSignature]
        public extern Elements Keyup(Function keyUpHandler);

        public abstract Elements Load(Function loadHandler);

        public abstract Elements Mousedown(Function mouseDownHandler);

        public abstract Elements Mouseenter(Function mouseEnterHandler);

        public abstract Elements Mouseleave(Function mouseLeaveHandler);

        public abstract Elements Mousemove(Function mouseMoveHandler);

        public abstract Elements Mouseout(Function mouseOutHandler);

        public abstract Elements Mouseover(Function mouseOverHandler);

        public abstract Elements Mouseup(Function mouseUpHandler);

        public abstract Elements Resize(Function resizeHandler);

        public abstract Elements Scroll(Function scrollHandler);

        public abstract Elements Select();

        [AlternateSignature]
        public extern Elements Select(Function selectHandler);

        public abstract Elements Submit();

        [AlternateSignature]
        public extern Elements Submit(Function submitHandler);

        public abstract Elements Unload(Function unloadHandler);

        #endregion Events

        #region Effects
        
        public abstract Elements Show();

        [AlternateSignature]
        public extern Elements Show(string speed);

        [AlternateSignature]
        public extern Elements Show(int milliseconds);

        [AlternateSignature]
        public extern Elements Show(string speed, Function completeHandler);

        [AlternateSignature]
        public extern Elements Show(int milliseconds, Function completeHandler);

        public abstract Elements Hide();

        [AlternateSignature]
        public extern Elements Hide(string speed);

        [AlternateSignature]
        public extern Elements Hide(int milliseconds);

        [AlternateSignature]
        public extern Elements Hide(string speed, Function completeHandler);

        [AlternateSignature]
        public extern Elements Hide(int milliseconds, Function completeHandler);

        public abstract Elements Toggle();

        [AlternateSignature]
        public extern Elements Toggle(bool show);

        [AlternateSignature]
        public extern Elements Toggle(string speed);

        [AlternateSignature]
        public extern Elements Toggle(int milliseconds);

        [AlternateSignature]
        public extern Elements Toggle(string speed, Function completeHandler);

        [AlternateSignature]
        public extern Elements Toggle(int milliseconds, Function completeHandler);

        public abstract Elements SlideDown(string speed);

        [AlternateSignature]
        public extern Elements SlideDown(int milliseconds);

        [AlternateSignature]
        public extern Elements SlideDown(string speed, Function completeHandler);

        [AlternateSignature]
        public extern Elements SlideDown(int milliseconds, Function completeHandler);

        public abstract Elements SlideUp(string speed);

        [AlternateSignature]
        public extern Elements SlideUp(int milliseconds);

        [AlternateSignature]
        public extern Elements SlideUp(string speed, Function completeHandler);

        [AlternateSignature]
        public extern Elements SlideUp(int milliseconds, Function completeHandler);

        public abstract Elements SlideToggle(string speed);

        [AlternateSignature]
        public extern Elements SlideToggle(int milliseconds);

        [AlternateSignature]
        public extern Elements SlideToggle(string speed, Function completeHandler);

        [AlternateSignature]
        public extern Elements SlideToggle(int milliseconds, Function completeHandler);

        public abstract Elements FadeIn(string speed);

        [AlternateSignature]
        public extern Elements FadeIn(int milliseconds);

        [AlternateSignature]
        public extern Elements FadeIn(string speed, Function completeHandler);

        [AlternateSignature]
        public extern Elements FadeIn(int milliseconds, Function completeHandler);

        public abstract Elements FadeOut(string speed);

        [AlternateSignature]
        public extern Elements FadeOut(int milliseconds);

        [AlternateSignature]
        public extern Elements FadeOut(string speed, Function completeHandler);

        [AlternateSignature]
        public extern Elements FadeOut(int milliseconds, Function completeHandler);

        public abstract Elements FadeTo(string speed, decimal opacity);

        [AlternateSignature]
        public extern Elements FadeTo(int milliseconds, decimal opacity);

        [AlternateSignature]
        public extern Elements FadeTo(string speed, decimal opacity, Function completeHandler);

        [AlternateSignature]
        public extern Elements FadeTo(int milliseconds, decimal opacity, Function completeHandler);
        
        public abstract Elements Animate(Dictionary cssProperties);

        [AlternateSignature]
        public extern Elements Animate(Dictionary cssProperties, string speed);

        [AlternateSignature]
        public extern Elements Animate(Dictionary cssProperties, int milliseconds);

        [AlternateSignature]
        public extern Elements Animate(Dictionary cssProperties, Function completeHandler);

        [AlternateSignature]
        public extern Elements Animate(Dictionary cssProperties, string speed, string easing);

        [AlternateSignature]
        public extern Elements Animate(Dictionary cssProperties, int milliseconds, string easing);

        [AlternateSignature]
        public extern Elements Animate(Dictionary cssProperties, string speed, Function completeHandler);

        [AlternateSignature]
        public extern Elements Animate(Dictionary cssProperties, int milliseconds, Function completeHandler);

        [AlternateSignature]
        public extern Elements Animate(Dictionary cssProperties, string speed, string easing, Function completeHandler);

        [AlternateSignature]
        public extern Elements Animate(Dictionary cssProperties, int milliseconds, string easing, Function completeHandler);

        [AlternateSignature]
        public extern Elements Animate(Dictionary cssProperties, Dictionary options);

        public abstract Elements Stop();

        [AlternateSignature]
        public extern Elements Stop(bool clearQueue);

        [AlternateSignature]
        public extern Elements Stop(bool clearQueue, bool goToEnd);

        #endregion Effects
        
        #region Ajax

        public abstract Elements Load(string url);

        [AlternateSignature]
        public extern Elements Load(string url, Dictionary data);

        [AlternateSignature]
        public extern Elements Load(string url, Dictionary data, Function loadHandler);

        public abstract Elements AjaxComplete(Function globalHandler);

        public abstract Elements AjaxError(Function globalErrorHandler);

        public abstract Elements AjaxSend(Function globalHandler);

        public abstract Elements AjaxStart(Function handler);

        public abstract Elements AjaxStop(Function handler);

        public abstract Elements AjaxSuccess(Function globalHandler);

        public abstract string Serialize();

        public abstract Dictionary SerializeArray(); 

        #endregion Ajax
    }
}
