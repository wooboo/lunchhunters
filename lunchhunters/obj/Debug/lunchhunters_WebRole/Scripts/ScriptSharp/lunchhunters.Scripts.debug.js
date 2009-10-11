// lunchhunters.Scripts.js
//


Type.createNamespace('jQueryFunctions');

////////////////////////////////////////////////////////////////////////////////
// jQueryFunctions.StringChain

jQueryFunctions.StringChain = function jQueryFunctions_StringChain(text) {
    /// <summary>
    /// Simple, chainable string builder wrapper.
    /// </summary>
    /// <param name="text" type="String">
    /// </param>
    /// <field name="_builder" type="StringBuilder">
    /// </field>
    this._builder = new StringBuilder(text);
}
jQueryFunctions.StringChain.prototype = {
    _builder: null,
    
    add: function jQueryFunctions_StringChain$add(text) {
        /// <param name="text" type="String">
        /// </param>
        /// <returns type="jQueryFunctions.StringChain"></returns>
        this._builder.append(text);
        return this;
    },
    
    toString: function jQueryFunctions_StringChain$toString() {
        /// <returns type="String"></returns>
        return this._builder.toString();
    }
}


////////////////////////////////////////////////////////////////////////////////
// jQueryFunctions.FunctionContext

jQueryFunctions.FunctionContext = function jQueryFunctions_FunctionContext(functionArguments) {
    /// <summary>
    /// Base class for argument wrappers of dynamic function targets called via Create methods.
    /// </summary>
    /// <param name="functionArguments" type="Array" elementType="Object">
    /// </param>
    /// <field name="arguments" type="Array" elementType="Object">
    /// </field>
    this.arguments = functionArguments;
}
jQueryFunctions.FunctionContext.create = function jQueryFunctions_FunctionContext$create(type, staticMethodName) {
    /// <summary>
    /// Creates a dynamic function targetting a static method from type with signature:
    /// public static anyReturnTypeOrVoid Method(OftenDOMElement handlerThis, object[] arguments)
    /// </summary>
    /// <param name="type" type="Type">
    /// </param>
    /// <param name="staticMethodName" type="String">
    /// </param>
    /// <returns type="Function"></returns>
    return new Function(new jQueryFunctions.StringChain('return ').add(type.get_fullName()).add('.').add(staticMethodName).add('(this, arguments);').toString());
}
jQueryFunctions.FunctionContext.createEmpty = function jQueryFunctions_FunctionContext$createEmpty(type, staticMethodName) {
    /// <summary>
    /// Creates a dynamic function targetting a static method that does not pass handler arguments.
    /// </summary>
    /// <param name="type" type="Type">
    /// </param>
    /// <param name="staticMethodName" type="String">
    /// </param>
    /// <returns type="Function"></returns>
    return new Function(new jQueryFunctions.StringChain('return ').add(type.get_fullName()).add('.').add(staticMethodName).add('(this);').toString());
}
jQueryFunctions.FunctionContext.createForContext = function jQueryFunctions_FunctionContext$createForContext(type, staticMethodName, contextType) {
    /// <summary>
    /// Creates a dynamic function targetting a static method from type with signature but wraps arguments:
    /// public static anyReturnTypeOrVoid Method(OftenDOMElement handlerThis, FunctionContext context)
    /// </summary>
    /// <param name="type" type="Type">
    /// </param>
    /// <param name="staticMethodName" type="String">
    /// </param>
    /// <param name="contextType" type="Type">
    /// </param>
    /// <returns type="Function"></returns>
    return new Function(new jQueryFunctions.StringChain('return ').add(type.get_fullName()).add('.').add(staticMethodName).add('(this, new ').add(contextType.get_fullName()).add('(arguments));').toString());
}
jQueryFunctions.FunctionContext.createWithArguments = function jQueryFunctions_FunctionContext$createWithArguments(type, staticMethodName, literalArgumentList) {
    /// <summary>
    /// Creates a dynamic function like others, but allows passing arguments in addition to the standard signature.
    /// The arguments are passed in the function body literally, so must be in the global scope or fully qualified.
    /// </summary>
    /// <param name="type" type="Type">
    /// </param>
    /// <param name="staticMethodName" type="String">
    /// </param>
    /// <param name="literalArgumentList" type="String">
    /// </param>
    /// <returns type="Function"></returns>
    return new Function(new jQueryFunctions.StringChain('return ').add(type.get_fullName()).add('.').add(staticMethodName).add('(this, arguments, ').add(literalArgumentList).add(');').toString());
}
jQueryFunctions.FunctionContext.createWithArgumentsForContext = function jQueryFunctions_FunctionContext$createWithArgumentsForContext(type, staticMethodName, literalArgumentList, contextType) {
    /// <summary>
    /// Creates a dynamic function like others, with an additional literal argument list and wrapped arguments.
    /// </summary>
    /// <param name="type" type="Type">
    /// </param>
    /// <param name="staticMethodName" type="String">
    /// </param>
    /// <param name="literalArgumentList" type="String">
    /// </param>
    /// <param name="contextType" type="Type">
    /// </param>
    /// <returns type="Function"></returns>
    return new Function(new jQueryFunctions.StringChain('return ').add(type.get_fullName()).add('.').add(staticMethodName).add('(this, new ').add(contextType.get_fullName()).add('(arguments), ').add(literalArgumentList).add(');').toString());
}
jQueryFunctions.FunctionContext.prototype = {
    arguments: null
}


////////////////////////////////////////////////////////////////////////////////
// jQueryFunctions.EventFunctionContext

jQueryFunctions.EventFunctionContext = function jQueryFunctions_EventFunctionContext(arguments) {
    /// <param name="arguments" type="Array" elementType="Object">
    /// </param>
    jQueryFunctions.EventFunctionContext.constructBase(this, [ arguments ]);
}
jQueryFunctions.EventFunctionContext.prototype = {
    
    get_event: function jQueryFunctions_EventFunctionContext$get_event() {
        /// <value type="jQueryInterfaces.EventState"></value>
        return this.arguments[0];
    }
}


////////////////////////////////////////////////////////////////////////////////
// jQueryFunctions.ReadyFunctionContext

jQueryFunctions.ReadyFunctionContext = function jQueryFunctions_ReadyFunctionContext(arguments) {
    /// <param name="arguments" type="Array" elementType="Object">
    /// </param>
    jQueryFunctions.ReadyFunctionContext.constructBase(this, [ arguments ]);
}
jQueryFunctions.ReadyFunctionContext.prototype = {
    
    get_jQueryFunction: function jQueryFunctions_ReadyFunctionContext$get_jQueryFunction() {
        /// <value type="Function"></value>
        return this.arguments[0];
    }
}


////////////////////////////////////////////////////////////////////////////////
// jQueryFunctions.EachFunctionContext

jQueryFunctions.EachFunctionContext = function jQueryFunctions_EachFunctionContext(arguments) {
    /// <param name="arguments" type="Array" elementType="Object">
    /// </param>
    jQueryFunctions.EachFunctionContext.constructBase(this, [ arguments ]);
}
jQueryFunctions.EachFunctionContext.prototype = {
    
    get_index: function jQueryFunctions_EachFunctionContext$get_index() {
        /// <value type="Number" integer="true"></value>
        return this.arguments[0];
    },
    
    get_element: function jQueryFunctions_EachFunctionContext$get_element() {
        /// <value type="Object" domElement="true"></value>
        return this.arguments[1];
    }
}


////////////////////////////////////////////////////////////////////////////////
// jQueryFunctions.EachValueFunctionContext

jQueryFunctions.EachValueFunctionContext = function jQueryFunctions_EachValueFunctionContext(arguments) {
    /// <param name="arguments" type="Array" elementType="Object">
    /// </param>
    jQueryFunctions.EachValueFunctionContext.constructBase(this, [ arguments ]);
}
jQueryFunctions.EachValueFunctionContext.prototype = {
    
    get_index: function jQueryFunctions_EachValueFunctionContext$get_index() {
        /// <value type="Number" integer="true"></value>
        return this.arguments[0];
    },
    
    get_value: function jQueryFunctions_EachValueFunctionContext$get_value() {
        /// <value type="Object"></value>
        return this.arguments[1];
    }
}


////////////////////////////////////////////////////////////////////////////////
// jQueryFunctions.AttrFunctionContext

jQueryFunctions.AttrFunctionContext = function jQueryFunctions_AttrFunctionContext(arguments) {
    /// <param name="arguments" type="Array" elementType="Object">
    /// </param>
    jQueryFunctions.AttrFunctionContext.constructBase(this, [ arguments ]);
}
jQueryFunctions.AttrFunctionContext.prototype = {
    
    get_index: function jQueryFunctions_AttrFunctionContext$get_index() {
        /// <value type="Number" integer="true"></value>
        return this.arguments[0];
    }
}


////////////////////////////////////////////////////////////////////////////////
// jQueryFunctions.FilterFunctionContext

jQueryFunctions.FilterFunctionContext = function jQueryFunctions_FilterFunctionContext(arguments) {
    /// <param name="arguments" type="Array" elementType="Object">
    /// </param>
    jQueryFunctions.FilterFunctionContext.constructBase(this, [ arguments ]);
}
jQueryFunctions.FilterFunctionContext.prototype = {
    
    get_index: function jQueryFunctions_FilterFunctionContext$get_index() {
        /// <value type="Number" integer="true"></value>
        return this.arguments[0];
    }
}


////////////////////////////////////////////////////////////////////////////////
// jQueryFunctions.MapFunctionContext

jQueryFunctions.MapFunctionContext = function jQueryFunctions_MapFunctionContext(arguments) {
    /// <param name="arguments" type="Array" elementType="Object">
    /// </param>
    jQueryFunctions.MapFunctionContext.constructBase(this, [ arguments ]);
}
jQueryFunctions.MapFunctionContext.prototype = {
    
    get_index: function jQueryFunctions_MapFunctionContext$get_index() {
        /// <value type="Number" integer="true"></value>
        return this.arguments[0];
    },
    
    get_element: function jQueryFunctions_MapFunctionContext$get_element() {
        /// <value type="Object" domElement="true"></value>
        return this.arguments[1];
    }
}


////////////////////////////////////////////////////////////////////////////////
// jQueryFunctions.AjaxGlobalFunctionContext

jQueryFunctions.AjaxGlobalFunctionContext = function jQueryFunctions_AjaxGlobalFunctionContext(arguments) {
    /// <param name="arguments" type="Array" elementType="Object">
    /// </param>
    jQueryFunctions.AjaxGlobalFunctionContext.constructBase(this, [ arguments ]);
}
jQueryFunctions.AjaxGlobalFunctionContext.prototype = {
    
    get_xmlHttpRequest: function jQueryFunctions_AjaxGlobalFunctionContext$get_xmlHttpRequest() {
        /// <value type="XMLHttpRequest"></value>
        return this.arguments[1];
    },
    
    get_ajaxOptions: function jQueryFunctions_AjaxGlobalFunctionContext$get_ajaxOptions() {
        /// <value type="jQueryInterfaces.AjaxOptions"></value>
        return this.arguments[2];
    }
}


////////////////////////////////////////////////////////////////////////////////
// jQueryFunctions.AjaxGlobalErrorFunctionContext

jQueryFunctions.AjaxGlobalErrorFunctionContext = function jQueryFunctions_AjaxGlobalErrorFunctionContext(arguments) {
    /// <param name="arguments" type="Array" elementType="Object">
    /// </param>
    jQueryFunctions.AjaxGlobalErrorFunctionContext.constructBase(this, [ arguments ]);
}
jQueryFunctions.AjaxGlobalErrorFunctionContext.prototype = {
    
    get_thrownOnError: function jQueryFunctions_AjaxGlobalErrorFunctionContext$get_thrownOnError() {
        /// <value type="Boolean"></value>
        return this.arguments[3];
    }
}


////////////////////////////////////////////////////////////////////////////////
// jQueryFunctions.AjaxLocalFunctionContext

jQueryFunctions.AjaxLocalFunctionContext = function jQueryFunctions_AjaxLocalFunctionContext(arguments) {
    /// <param name="arguments" type="Array" elementType="Object">
    /// </param>
    jQueryFunctions.AjaxLocalFunctionContext.constructBase(this, [ arguments ]);
}
jQueryFunctions.AjaxLocalFunctionContext.prototype = {
    
    get_xmlHttpRequest: function jQueryFunctions_AjaxLocalFunctionContext$get_xmlHttpRequest() {
        /// <value type="XMLHttpRequest"></value>
        return this.arguments[0];
    }
}


////////////////////////////////////////////////////////////////////////////////
// jQueryFunctions.AjaxLocalStatusFunctionContext

jQueryFunctions.AjaxLocalStatusFunctionContext = function jQueryFunctions_AjaxLocalStatusFunctionContext(arguments) {
    /// <param name="arguments" type="Array" elementType="Object">
    /// </param>
    jQueryFunctions.AjaxLocalStatusFunctionContext.constructBase(this, [ arguments ]);
}
jQueryFunctions.AjaxLocalStatusFunctionContext.prototype = {
    
    get_textStatus: function jQueryFunctions_AjaxLocalStatusFunctionContext$get_textStatus() {
        /// <value type="String"></value>
        return this.arguments[1];
    }
}


////////////////////////////////////////////////////////////////////////////////
// jQueryFunctions.AjaxLocalErrorFunctionContext

jQueryFunctions.AjaxLocalErrorFunctionContext = function jQueryFunctions_AjaxLocalErrorFunctionContext(arguments) {
    /// <param name="arguments" type="Array" elementType="Object">
    /// </param>
    jQueryFunctions.AjaxLocalErrorFunctionContext.constructBase(this, [ arguments ]);
}
jQueryFunctions.AjaxLocalErrorFunctionContext.prototype = {
    
    get_errorThrown: function jQueryFunctions_AjaxLocalErrorFunctionContext$get_errorThrown() {
        /// <value type="Boolean"></value>
        return this.arguments[2];
    }
}


////////////////////////////////////////////////////////////////////////////////
// jQueryFunctions.AjaxDataFilterFunctionContext

jQueryFunctions.AjaxDataFilterFunctionContext = function jQueryFunctions_AjaxDataFilterFunctionContext(arguments) {
    /// <param name="arguments" type="Array" elementType="Object">
    /// </param>
    jQueryFunctions.AjaxDataFilterFunctionContext.constructBase(this, [ arguments ]);
}
jQueryFunctions.AjaxDataFilterFunctionContext.prototype = {
    
    get_data: function jQueryFunctions_AjaxDataFilterFunctionContext$get_data() {
        /// <value type="Object"></value>
        return this.arguments[0];
    },
    
    get_dataType: function jQueryFunctions_AjaxDataFilterFunctionContext$get_dataType() {
        /// <value type="String"></value>
        return this.arguments[1];
    }
}


////////////////////////////////////////////////////////////////////////////////
// jQueryFunctions.AjaxSuccessFunctionContext

jQueryFunctions.AjaxSuccessFunctionContext = function jQueryFunctions_AjaxSuccessFunctionContext(arguments) {
    /// <param name="arguments" type="Array" elementType="Object">
    /// </param>
    jQueryFunctions.AjaxSuccessFunctionContext.constructBase(this, [ arguments ]);
}
jQueryFunctions.AjaxSuccessFunctionContext.prototype = {
    
    get_data: function jQueryFunctions_AjaxSuccessFunctionContext$get_data() {
        /// <value type="Object"></value>
        return this.arguments[0];
    },
    
    get_textStatus: function jQueryFunctions_AjaxSuccessFunctionContext$get_textStatus() {
        /// <value type="String"></value>
        return this.arguments[1];
    }
}


////////////////////////////////////////////////////////////////////////////////
// jQueryFunctions.AjaxLoadFunctionContext

jQueryFunctions.AjaxLoadFunctionContext = function jQueryFunctions_AjaxLoadFunctionContext(arguments) {
    /// <param name="arguments" type="Array" elementType="Object">
    /// </param>
    jQueryFunctions.AjaxLoadFunctionContext.constructBase(this, [ arguments ]);
}
jQueryFunctions.AjaxLoadFunctionContext.prototype = {
    
    get_responseText: function jQueryFunctions_AjaxLoadFunctionContext$get_responseText() {
        /// <value type="String"></value>
        return this.arguments[0];
    },
    
    get_textStatus: function jQueryFunctions_AjaxLoadFunctionContext$get_textStatus() {
        /// <value type="String"></value>
        return this.arguments[1];
    },
    
    get_xmlHttpRequest: function jQueryFunctions_AjaxLoadFunctionContext$get_xmlHttpRequest() {
        /// <value type="XMLHttpRequest"></value>
        return this.arguments[2];
    }
}


////////////////////////////////////////////////////////////////////////////////
// jQueryFunctions.ArrayFunctionContext

jQueryFunctions.ArrayFunctionContext = function jQueryFunctions_ArrayFunctionContext(arguments) {
    /// <param name="arguments" type="Array" elementType="Object">
    /// </param>
    jQueryFunctions.ArrayFunctionContext.constructBase(this, [ arguments ]);
}
jQueryFunctions.ArrayFunctionContext.prototype = {
    
    get_element: function jQueryFunctions_ArrayFunctionContext$get_element() {
        /// <value type="Object"></value>
        return this.arguments[0];
    },
    
    get_index: function jQueryFunctions_ArrayFunctionContext$get_index() {
        /// <value type="Number" integer="true"></value>
        return this.arguments[1];
    }
}


Type.createNamespace('jQueryInterfaces');

////////////////////////////////////////////////////////////////////////////////
// jQueryInterfaces.Easing

jQueryInterfaces.Easing = function jQueryInterfaces_Easing() {
    /// <field name="linear" type="String" static="true">
    /// </field>
    /// <field name="swing" type="String" static="true">
    /// </field>
}


////////////////////////////////////////////////////////////////////////////////
// jQueryInterfaces.Speed

jQueryInterfaces.Speed = function jQueryInterfaces_Speed() {
    /// <field name="slow" type="String" static="true">
    /// </field>
    /// <field name="normal" type="String" static="true">
    /// </field>
    /// <field name="fast" type="String" static="true">
    /// </field>
}


////////////////////////////////////////////////////////////////////////////////
// jQueryInterfaces.EventType

jQueryInterfaces.EventType = function jQueryInterfaces_EventType() {
    /// <field name="blur" type="String" static="true">
    /// </field>
    /// <field name="focus" type="String" static="true">
    /// </field>
    /// <field name="load" type="String" static="true">
    /// </field>
    /// <field name="resize" type="String" static="true">
    /// </field>
    /// <field name="scroll" type="String" static="true">
    /// </field>
    /// <field name="unload" type="String" static="true">
    /// </field>
    /// <field name="beforeUnload" type="String" static="true">
    /// </field>
    /// <field name="click" type="String" static="true">
    /// </field>
    /// <field name="doubleClick" type="String" static="true">
    /// </field>
    /// <field name="mouseDown" type="String" static="true">
    /// </field>
    /// <field name="mouseUp" type="String" static="true">
    /// </field>
    /// <field name="mouseMove" type="String" static="true">
    /// </field>
    /// <field name="mouseOver" type="String" static="true">
    /// </field>
    /// <field name="mouseOut" type="String" static="true">
    /// </field>
    /// <field name="mouseEnter" type="String" static="true">
    /// </field>
    /// <field name="mouseLeave" type="String" static="true">
    /// </field>
    /// <field name="change" type="String" static="true">
    /// </field>
    /// <field name="select" type="String" static="true">
    /// </field>
    /// <field name="submit" type="String" static="true">
    /// </field>
    /// <field name="keyDown" type="String" static="true">
    /// </field>
    /// <field name="keyPress" type="String" static="true">
    /// </field>
    /// <field name="keyUp" type="String" static="true">
    /// </field>
    /// <field name="error" type="String" static="true">
    /// </field>
}


////////////////////////////////////////////////////////////////////////////////
// jQueryInterfaces.LiveEventType

jQueryInterfaces.LiveEventType = function jQueryInterfaces_LiveEventType() {
    /// <field name="click" type="String" static="true">
    /// </field>
    /// <field name="doubleClick" type="String" static="true">
    /// </field>
    /// <field name="mouseDown" type="String" static="true">
    /// </field>
    /// <field name="mouseUp" type="String" static="true">
    /// </field>
    /// <field name="mouseMove" type="String" static="true">
    /// </field>
    /// <field name="mouseOver" type="String" static="true">
    /// </field>
    /// <field name="mouseOut" type="String" static="true">
    /// </field>
    /// <field name="keyDown" type="String" static="true">
    /// </field>
    /// <field name="keyPress" type="String" static="true">
    /// </field>
    /// <field name="keyUp" type="String" static="true">
    /// </field>
}


////////////////////////////////////////////////////////////////////////////////
// jQueryInterfaces.DataType

jQueryInterfaces.DataType = function jQueryInterfaces_DataType() {
    /// <field name="xml" type="String" static="true">
    /// </field>
    /// <field name="html" type="String" static="true">
    /// </field>
    /// <field name="script" type="String" static="true">
    /// </field>
    /// <field name="json" type="String" static="true">
    /// </field>
    /// <field name="jsonP" type="String" static="true">
    /// </field>
    /// <field name="text" type="String" static="true">
    /// </field>
}


////////////////////////////////////////////////////////////////////////////////
// jQueryInterfaces.ObjectFactory

jQueryInterfaces.ObjectFactory = function jQueryInterfaces_ObjectFactory() {
}
jQueryInterfaces.ObjectFactory.createPosition = function jQueryInterfaces_ObjectFactory$createPosition(data) {
    /// <param name="data" type="Object">
    /// </param>
    /// <returns type="jQueryInterfaces.Position"></returns>
    return ((data || {}));
}
jQueryInterfaces.ObjectFactory.createEventState = function jQueryInterfaces_ObjectFactory$createEventState(data) {
    /// <param name="data" type="Object">
    /// </param>
    /// <returns type="jQueryInterfaces.Position"></returns>
    return ((data || {}));
}
jQueryInterfaces.ObjectFactory.createAjaxOptions = function jQueryInterfaces_ObjectFactory$createAjaxOptions(data) {
    /// <param name="data" type="Object">
    /// </param>
    /// <returns type="jQueryInterfaces.Position"></returns>
    return ((data || {}));
}


Type.createNamespace('lunchhunters.Scripts');

////////////////////////////////////////////////////////////////////////////////
// lunchhunters.Scripts.MyClass

lunchhunters.Scripts.MyClass = function lunchhunters_Scripts_MyClass() {
}
lunchhunters.Scripts.MyClass.documentReady = function lunchhunters_Scripts_MyClass$documentReady() {
    alert('The document is ready!');
}


jQueryFunctions.StringChain.createClass('jQueryFunctions.StringChain');
jQueryFunctions.FunctionContext.createClass('jQueryFunctions.FunctionContext');
jQueryFunctions.EventFunctionContext.createClass('jQueryFunctions.EventFunctionContext', jQueryFunctions.FunctionContext);
jQueryFunctions.ReadyFunctionContext.createClass('jQueryFunctions.ReadyFunctionContext', jQueryFunctions.FunctionContext);
jQueryFunctions.EachFunctionContext.createClass('jQueryFunctions.EachFunctionContext', jQueryFunctions.FunctionContext);
jQueryFunctions.EachValueFunctionContext.createClass('jQueryFunctions.EachValueFunctionContext', jQueryFunctions.FunctionContext);
jQueryFunctions.AttrFunctionContext.createClass('jQueryFunctions.AttrFunctionContext', jQueryFunctions.FunctionContext);
jQueryFunctions.FilterFunctionContext.createClass('jQueryFunctions.FilterFunctionContext', jQueryFunctions.FunctionContext);
jQueryFunctions.MapFunctionContext.createClass('jQueryFunctions.MapFunctionContext', jQueryFunctions.FunctionContext);
jQueryFunctions.AjaxGlobalFunctionContext.createClass('jQueryFunctions.AjaxGlobalFunctionContext', jQueryFunctions.EventFunctionContext);
jQueryFunctions.AjaxGlobalErrorFunctionContext.createClass('jQueryFunctions.AjaxGlobalErrorFunctionContext', jQueryFunctions.AjaxGlobalFunctionContext);
jQueryFunctions.AjaxLocalFunctionContext.createClass('jQueryFunctions.AjaxLocalFunctionContext', jQueryFunctions.FunctionContext);
jQueryFunctions.AjaxLocalStatusFunctionContext.createClass('jQueryFunctions.AjaxLocalStatusFunctionContext', jQueryFunctions.AjaxLocalFunctionContext);
jQueryFunctions.AjaxLocalErrorFunctionContext.createClass('jQueryFunctions.AjaxLocalErrorFunctionContext', jQueryFunctions.AjaxLocalStatusFunctionContext);
jQueryFunctions.AjaxDataFilterFunctionContext.createClass('jQueryFunctions.AjaxDataFilterFunctionContext', jQueryFunctions.FunctionContext);
jQueryFunctions.AjaxSuccessFunctionContext.createClass('jQueryFunctions.AjaxSuccessFunctionContext', jQueryFunctions.FunctionContext);
jQueryFunctions.AjaxLoadFunctionContext.createClass('jQueryFunctions.AjaxLoadFunctionContext', jQueryFunctions.FunctionContext);
jQueryFunctions.ArrayFunctionContext.createClass('jQueryFunctions.ArrayFunctionContext', jQueryFunctions.FunctionContext);
jQueryInterfaces.Easing.createClass('jQueryInterfaces.Easing');
jQueryInterfaces.Speed.createClass('jQueryInterfaces.Speed');
jQueryInterfaces.EventType.createClass('jQueryInterfaces.EventType');
jQueryInterfaces.LiveEventType.createClass('jQueryInterfaces.LiveEventType');
jQueryInterfaces.DataType.createClass('jQueryInterfaces.DataType');
jQueryInterfaces.ObjectFactory.createClass('jQueryInterfaces.ObjectFactory');
lunchhunters.Scripts.MyClass.createClass('lunchhunters.Scripts.MyClass');
jQueryInterfaces.Easing.linear = 'linear';
jQueryInterfaces.Easing.swing = 'swing';
jQueryInterfaces.Speed.slow = 'slow';
jQueryInterfaces.Speed.normal = 'normal';
jQueryInterfaces.Speed.fast = 'fast';
jQueryInterfaces.EventType.blur = 'blur';
jQueryInterfaces.EventType.focus = 'focus';
jQueryInterfaces.EventType.load = 'load';
jQueryInterfaces.EventType.resize = 'resize';
jQueryInterfaces.EventType.scroll = 'scroll';
jQueryInterfaces.EventType.unload = 'unload';
jQueryInterfaces.EventType.beforeUnload = 'beforeunload';
jQueryInterfaces.EventType.click = 'click';
jQueryInterfaces.EventType.doubleClick = 'dblclick';
jQueryInterfaces.EventType.mouseDown = 'mouseDown';
jQueryInterfaces.EventType.mouseUp = 'mouseup';
jQueryInterfaces.EventType.mouseMove = 'mousemove';
jQueryInterfaces.EventType.mouseOver = 'mouseover';
jQueryInterfaces.EventType.mouseOut = 'mouseout';
jQueryInterfaces.EventType.mouseEnter = 'mouseenter';
jQueryInterfaces.EventType.mouseLeave = 'mouseleave';
jQueryInterfaces.EventType.change = 'change';
jQueryInterfaces.EventType.select = 'select';
jQueryInterfaces.EventType.submit = 'submit';
jQueryInterfaces.EventType.keyDown = 'keydown';
jQueryInterfaces.EventType.keyPress = 'keypress';
jQueryInterfaces.EventType.keyUp = 'keyup';
jQueryInterfaces.EventType.error = 'error';
jQueryInterfaces.LiveEventType.click = 'click';
jQueryInterfaces.LiveEventType.doubleClick = 'dblclick';
jQueryInterfaces.LiveEventType.mouseDown = 'mouseDown';
jQueryInterfaces.LiveEventType.mouseUp = 'mouseup';
jQueryInterfaces.LiveEventType.mouseMove = 'mousemove';
jQueryInterfaces.LiveEventType.mouseOver = 'mouseover';
jQueryInterfaces.LiveEventType.mouseOut = 'mouseout';
jQueryInterfaces.LiveEventType.keyDown = 'keydown';
jQueryInterfaces.LiveEventType.keyPress = 'keypress';
jQueryInterfaces.LiveEventType.keyUp = 'keyup';
jQueryInterfaces.DataType.xml = 'xml';
jQueryInterfaces.DataType.html = 'html';
jQueryInterfaces.DataType.script = 'script';
jQueryInterfaces.DataType.json = 'json';
jQueryInterfaces.DataType.jsonP = 'jsonp';
jQueryInterfaces.DataType.text = 'text';
jQuery(jQueryFunctions.FunctionContext.createEmpty(lunchhunters.Scripts.MyClass, 'documentReady'));

// ---- Do not remove this footer ----
// Generated using Script# v0.5.1.0 (http://projects.nikhilk.net)
// -----------------------------------
