/* Script# jQuery Handler Functions v0.1
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

//using jQuery;
using jQueryInterfaces;

namespace jQueryFunctions
{
    /// <summary>
    /// Simple, chainable string builder wrapper.
    /// </summary>
    public class StringChain
    {
        private StringBuilder builder;

        public StringChain(string text)
        {
            builder = new StringBuilder(text);
        }

        public StringChain Add(string text)
        {
            builder.Append(text);
            return this;
        }

        public override string ToString()
        {
            return builder.ToString();
        }
    }

    /// <summary>
    /// Base class for argument wrappers of dynamic function targets called via Create methods.
    /// </summary>
    public abstract class FunctionContext
    {
        /// <summary>
        /// Creates a dynamic function targetting a static method from type with signature:
        /// public static anyReturnTypeOrVoid Method(OftenDOMElement handlerThis, object[] arguments) 
        /// </summary>
        public static Function Create(Type type, string staticMethodName)
        {
            return new Function(new StringChain("return ").Add(type.FullName).
                Add(".").Add(staticMethodName).Add("(this, arguments);").ToString());
        }

        /// <summary>
        /// Creates a dynamic function targetting a static method that does not pass handler arguments.
        /// </summary>
        public static Function CreateEmpty(Type type, string staticMethodName)
        {
            return new Function(new StringChain("return ").Add(type.FullName).
                Add(".").Add(staticMethodName).Add("(this);").ToString());
        }

        /// <summary>
        /// Creates a dynamic function targetting a static method from type with signature but wraps arguments:
        /// public static anyReturnTypeOrVoid Method(OftenDOMElement handlerThis, FunctionContext context)
        /// </summary>
        public static Function CreateForContext(Type type, string staticMethodName, Type contextType)
        {
            return new Function(new StringChain("return ").Add(type.FullName).Add(".").
                Add(staticMethodName).Add("(this, new ").Add(contextType.FullName).Add("(arguments));").ToString());
        }

        /// <summary>
        /// Creates a dynamic function like others, but allows passing arguments in addition to the standard signature.
        /// The arguments are passed in the function body literally, so must be in the global scope or fully qualified.
        /// </summary>
        public static Function CreateWithArguments(Type type, string staticMethodName, string literalArgumentList)
        {
            return new Function(new StringChain("return ").Add(type.FullName).Add(".").
                Add(staticMethodName).Add("(this, arguments, ").Add(literalArgumentList).Add(");").ToString());
        }

        /// <summary>
        /// Creates a dynamic function like others, with an additional literal argument list and wrapped arguments.
        /// </summary>
        public static Function CreateWithArgumentsForContext(Type type,
            string staticMethodName, string literalArgumentList, Type contextType)
        {
            return new Function(new StringChain("return ").Add(type.FullName).
                Add(".").Add(staticMethodName).Add("(this, new ").Add(contextType.FullName).
                Add("(arguments), ").Add(literalArgumentList).Add(");").ToString());
        }

        public object[] Arguments;

        public FunctionContext(object[] functionArguments)
        {
            Arguments = functionArguments;
        }
    }

    public class EventFunctionContext : FunctionContext
    {
        public EventFunctionContext(object[] arguments) : base(arguments) { }

        public EventState Event
        {
            get
            {
                return (EventState)Arguments[0];
            }
        }
    }

    public class ReadyFunctionContext : FunctionContext
    {
        public ReadyFunctionContext(object[] arguments) : base(arguments) { }

        public Function jQueryFunction
        {
            get
            {
                return (Function)Arguments[0];
            }
        }
    }

    public class EachFunctionContext : FunctionContext
    {
        public EachFunctionContext(object[] arguments) : base(arguments) { }

        public int Index
        {
            get
            {
                return (int)Arguments[0];
            }
        }

        public DOMElement Element
        {
            get
            {
                return (DOMElement)Arguments[1];
            }
        }
    }

    public class EachValueFunctionContext : FunctionContext
    {
        public EachValueFunctionContext(object[] arguments) : base(arguments) { }

        public int Index
        {
            get
            {
                return (int)Arguments[0];
            }
        }

        public object Value
        {
            get
            {
                return Arguments[1];
            }
        }
    }

    public class AttrFunctionContext : FunctionContext
    {
        public AttrFunctionContext(object[] arguments) : base(arguments) { }

        public int Index
        {
            get
            {
                return (int)Arguments[0];
            }
        }
    }

    public class FilterFunctionContext : FunctionContext
    {
        public FilterFunctionContext(object[] arguments) : base(arguments) { }

        public int Index
        {
            get
            {
                return (int)Arguments[0];
            }
        }
    }

    public class MapFunctionContext : FunctionContext
    {
        public MapFunctionContext(object[] arguments) : base(arguments) { }

        public int Index
        {
            get
            {
                return (int)Arguments[0];
            }
        }

        public DOMElement Element
        {
            get
            {
                return (DOMElement)Arguments[1];
            }
        }
    }

    public class AjaxGlobalFunctionContext : EventFunctionContext
    {
        public AjaxGlobalFunctionContext(object[] arguments) : base(arguments) { }

        public XMLHttpRequest XMLHttpRequest
        {
            get
            {
                return (XMLHttpRequest)Arguments[1];
            }
        }

        public AjaxOptions AjaxOptions
        {
            get
            {
                return (AjaxOptions)Arguments[2];
            }
        }
    }

    public class AjaxGlobalErrorFunctionContext : AjaxGlobalFunctionContext
    {
        public AjaxGlobalErrorFunctionContext(object[] arguments) : base(arguments) { }

        public bool ThrownOnError
        {
            get
            {
                return (bool)Arguments[3];
            }
        }
    }

    public class AjaxLocalFunctionContext : FunctionContext
    {
        public AjaxLocalFunctionContext(object[] arguments) : base(arguments) { }

        public XMLHttpRequest XMLHttpRequest
        {
            get
            {
                return (XMLHttpRequest)Arguments[0];
            }
        }
    }

    public class AjaxLocalStatusFunctionContext : AjaxLocalFunctionContext
    {
        public AjaxLocalStatusFunctionContext(object[] arguments) : base(arguments) { }

        public string TextStatus
        {
            get
            {
                return (string)Arguments[1];
            }
        }
    }

    public class AjaxLocalErrorFunctionContext : AjaxLocalStatusFunctionContext
    {
        public AjaxLocalErrorFunctionContext(object[] arguments) : base(arguments) { }

        public bool ErrorThrown
        {
            get
            {
                return (bool)Arguments[2];
            }
        }
    }

    public class AjaxDataFilterFunctionContext : FunctionContext
    {
        public AjaxDataFilterFunctionContext(object[] arguments) : base(arguments) { }

        public object Data
        {
            get
            {
                return Arguments[0];
            }
        }

        public string DataType
        {
            get
            {
                return (string)Arguments[1];
            }
        }
    }

    public class AjaxSuccessFunctionContext : FunctionContext
    {
        public AjaxSuccessFunctionContext(object[] arguments) : base(arguments) { }

        public object Data
        {
            get
            {
                return Arguments[0];
            }
        }

        public string TextStatus
        {
            get
            {
                return (string)Arguments[1];
            }
        }
    }
    
    public class AjaxLoadFunctionContext : FunctionContext
    {
        public AjaxLoadFunctionContext(object[] arguments) : base(arguments) { }

        public string ResponseText
        {
            get
            {
                return (string)Arguments[0];
            }
        }

        public string TextStatus
        {
            get
            {
                return (string)Arguments[1];
            }
        }

        public XMLHttpRequest XMLHttpRequest
        {
            get
            {
                return (XMLHttpRequest)Arguments[2];
            }
        }
    }

    public class ArrayFunctionContext : FunctionContext
    {
        public ArrayFunctionContext(object[] arguments) : base(arguments) { }

        public object Element
        {
            get
            {
                return Arguments[0];
            }
        }

        public int Index
        {
            get
            {
                return (int)Arguments[1];
            }
        }
    }
}
