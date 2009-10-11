
Type.createNamespace('lunchhunters.Scripts.google.maps');lunchhunters.Scripts.google.maps._Map=function(){}
Type.createNamespace('jQueryFunctions');jQueryFunctions.StringChain=function(text){this.$0=new StringBuilder(text);}
jQueryFunctions.StringChain.prototype={$0:null,add:function(text){this.$0.append(text);return this;},toString:function(){return this.$0.toString();}}
jQueryFunctions.FunctionContext=function(functionArguments){this.arguments=functionArguments;}
jQueryFunctions.FunctionContext.create=function(type,staticMethodName){return new Function(new jQueryFunctions.StringChain('return ').add(type.get_fullName()).add('.').add(staticMethodName).add('(this, arguments);').toString());}
jQueryFunctions.FunctionContext.createEmpty=function(type,staticMethodName){return new Function(new jQueryFunctions.StringChain('return ').add(type.get_fullName()).add('.').add(staticMethodName).add('(this);').toString());}
jQueryFunctions.FunctionContext.createForContext=function(type,staticMethodName,contextType){return new Function(new jQueryFunctions.StringChain('return ').add(type.get_fullName()).add('.').add(staticMethodName).add('(this, new ').add(contextType.get_fullName()).add('(arguments));').toString());}
jQueryFunctions.FunctionContext.createWithArguments=function(type,staticMethodName,literalArgumentList){return new Function(new jQueryFunctions.StringChain('return ').add(type.get_fullName()).add('.').add(staticMethodName).add('(this, arguments, ').add(literalArgumentList).add(');').toString());}
jQueryFunctions.FunctionContext.createWithArgumentsForContext=function(type,staticMethodName,literalArgumentList,contextType){return new Function(new jQueryFunctions.StringChain('return ').add(type.get_fullName()).add('.').add(staticMethodName).add('(this, new ').add(contextType.get_fullName()).add('(arguments), ').add(literalArgumentList).add(');').toString());}
jQueryFunctions.FunctionContext.prototype={arguments:null}
jQueryFunctions.EventFunctionContext=function(arguments){jQueryFunctions.EventFunctionContext.constructBase(this,[arguments]);}
jQueryFunctions.EventFunctionContext.prototype={get_event:function(){return this.arguments[0];}}
jQueryFunctions.ReadyFunctionContext=function(arguments){jQueryFunctions.ReadyFunctionContext.constructBase(this,[arguments]);}
jQueryFunctions.ReadyFunctionContext.prototype={get_jQueryFunction:function(){return this.arguments[0];}}
jQueryFunctions.EachFunctionContext=function(arguments){jQueryFunctions.EachFunctionContext.constructBase(this,[arguments]);}
jQueryFunctions.EachFunctionContext.prototype={get_index:function(){return this.arguments[0];},get_element:function(){return this.arguments[1];}}
jQueryFunctions.EachValueFunctionContext=function(arguments){jQueryFunctions.EachValueFunctionContext.constructBase(this,[arguments]);}
jQueryFunctions.EachValueFunctionContext.prototype={get_index:function(){return this.arguments[0];},get_value:function(){return this.arguments[1];}}
jQueryFunctions.AttrFunctionContext=function(arguments){jQueryFunctions.AttrFunctionContext.constructBase(this,[arguments]);}
jQueryFunctions.AttrFunctionContext.prototype={get_index:function(){return this.arguments[0];}}
jQueryFunctions.FilterFunctionContext=function(arguments){jQueryFunctions.FilterFunctionContext.constructBase(this,[arguments]);}
jQueryFunctions.FilterFunctionContext.prototype={get_index:function(){return this.arguments[0];}}
jQueryFunctions.MapFunctionContext=function(arguments){jQueryFunctions.MapFunctionContext.constructBase(this,[arguments]);}
jQueryFunctions.MapFunctionContext.prototype={get_index:function(){return this.arguments[0];},get_element:function(){return this.arguments[1];}}
jQueryFunctions.AjaxGlobalFunctionContext=function(arguments){jQueryFunctions.AjaxGlobalFunctionContext.constructBase(this,[arguments]);}
jQueryFunctions.AjaxGlobalFunctionContext.prototype={get_xmlHttpRequest:function(){return this.arguments[1];},get_ajaxOptions:function(){return this.arguments[2];}}
jQueryFunctions.AjaxGlobalErrorFunctionContext=function(arguments){jQueryFunctions.AjaxGlobalErrorFunctionContext.constructBase(this,[arguments]);}
jQueryFunctions.AjaxGlobalErrorFunctionContext.prototype={get_thrownOnError:function(){return this.arguments[3];}}
jQueryFunctions.AjaxLocalFunctionContext=function(arguments){jQueryFunctions.AjaxLocalFunctionContext.constructBase(this,[arguments]);}
jQueryFunctions.AjaxLocalFunctionContext.prototype={get_xmlHttpRequest:function(){return this.arguments[0];}}
jQueryFunctions.AjaxLocalStatusFunctionContext=function(arguments){jQueryFunctions.AjaxLocalStatusFunctionContext.constructBase(this,[arguments]);}
jQueryFunctions.AjaxLocalStatusFunctionContext.prototype={get_textStatus:function(){return this.arguments[1];}}
jQueryFunctions.AjaxLocalErrorFunctionContext=function(arguments){jQueryFunctions.AjaxLocalErrorFunctionContext.constructBase(this,[arguments]);}
jQueryFunctions.AjaxLocalErrorFunctionContext.prototype={get_errorThrown:function(){return this.arguments[2];}}
jQueryFunctions.AjaxDataFilterFunctionContext=function(arguments){jQueryFunctions.AjaxDataFilterFunctionContext.constructBase(this,[arguments]);}
jQueryFunctions.AjaxDataFilterFunctionContext.prototype={get_data:function(){return this.arguments[0];},get_dataType:function(){return this.arguments[1];}}
jQueryFunctions.AjaxSuccessFunctionContext=function(arguments){jQueryFunctions.AjaxSuccessFunctionContext.constructBase(this,[arguments]);}
jQueryFunctions.AjaxSuccessFunctionContext.prototype={get_data:function(){return this.arguments[0];},get_textStatus:function(){return this.arguments[1];}}
jQueryFunctions.AjaxLoadFunctionContext=function(arguments){jQueryFunctions.AjaxLoadFunctionContext.constructBase(this,[arguments]);}
jQueryFunctions.AjaxLoadFunctionContext.prototype={get_responseText:function(){return this.arguments[0];},get_textStatus:function(){return this.arguments[1];},get_xmlHttpRequest:function(){return this.arguments[2];}}
jQueryFunctions.ArrayFunctionContext=function(arguments){jQueryFunctions.ArrayFunctionContext.constructBase(this,[arguments]);}
jQueryFunctions.ArrayFunctionContext.prototype={get_element:function(){return this.arguments[0];},get_index:function(){return this.arguments[1];}}
Type.createNamespace('jQueryInterfaces');jQueryInterfaces.Easing=function(){}
jQueryInterfaces.Speed=function(){}
jQueryInterfaces.EventType=function(){}
jQueryInterfaces.LiveEventType=function(){}
jQueryInterfaces.DataType=function(){}
jQueryInterfaces.ObjectFactory=function(){}
jQueryInterfaces.ObjectFactory.createPosition=function(data){return ((data||{}));}
jQueryInterfaces.ObjectFactory.createEventState=function(data){return ((data||{}));}
jQueryInterfaces.ObjectFactory.createAjaxOptions=function(data){return ((data||{}));}
Type.createNamespace('lunchhunters.Scripts');lunchhunters.Scripts.MyClass=function(){}
lunchhunters.Scripts.MyClass.documentReady=function(){alert('The document is ready!');}
lunchhunters.Scripts.google.maps._Map.createClass('lunchhunters.Scripts.google.maps._Map');jQueryFunctions.StringChain.createClass('jQueryFunctions.StringChain');jQueryFunctions.FunctionContext.createClass('jQueryFunctions.FunctionContext');jQueryFunctions.EventFunctionContext.createClass('jQueryFunctions.EventFunctionContext',jQueryFunctions.FunctionContext);jQueryFunctions.ReadyFunctionContext.createClass('jQueryFunctions.ReadyFunctionContext',jQueryFunctions.FunctionContext);jQueryFunctions.EachFunctionContext.createClass('jQueryFunctions.EachFunctionContext',jQueryFunctions.FunctionContext);jQueryFunctions.EachValueFunctionContext.createClass('jQueryFunctions.EachValueFunctionContext',jQueryFunctions.FunctionContext);jQueryFunctions.AttrFunctionContext.createClass('jQueryFunctions.AttrFunctionContext',jQueryFunctions.FunctionContext);jQueryFunctions.FilterFunctionContext.createClass('jQueryFunctions.FilterFunctionContext',jQueryFunctions.FunctionContext);jQueryFunctions.MapFunctionContext.createClass('jQueryFunctions.MapFunctionContext',jQueryFunctions.FunctionContext);jQueryFunctions.AjaxGlobalFunctionContext.createClass('jQueryFunctions.AjaxGlobalFunctionContext',jQueryFunctions.EventFunctionContext);jQueryFunctions.AjaxGlobalErrorFunctionContext.createClass('jQueryFunctions.AjaxGlobalErrorFunctionContext',jQueryFunctions.AjaxGlobalFunctionContext);jQueryFunctions.AjaxLocalFunctionContext.createClass('jQueryFunctions.AjaxLocalFunctionContext',jQueryFunctions.FunctionContext);jQueryFunctions.AjaxLocalStatusFunctionContext.createClass('jQueryFunctions.AjaxLocalStatusFunctionContext',jQueryFunctions.AjaxLocalFunctionContext);jQueryFunctions.AjaxLocalErrorFunctionContext.createClass('jQueryFunctions.AjaxLocalErrorFunctionContext',jQueryFunctions.AjaxLocalStatusFunctionContext);jQueryFunctions.AjaxDataFilterFunctionContext.createClass('jQueryFunctions.AjaxDataFilterFunctionContext',jQueryFunctions.FunctionContext);jQueryFunctions.AjaxSuccessFunctionContext.createClass('jQueryFunctions.AjaxSuccessFunctionContext',jQueryFunctions.FunctionContext);jQueryFunctions.AjaxLoadFunctionContext.createClass('jQueryFunctions.AjaxLoadFunctionContext',jQueryFunctions.FunctionContext);jQueryFunctions.ArrayFunctionContext.createClass('jQueryFunctions.ArrayFunctionContext',jQueryFunctions.FunctionContext);jQueryInterfaces.Easing.createClass('jQueryInterfaces.Easing');jQueryInterfaces.Speed.createClass('jQueryInterfaces.Speed');jQueryInterfaces.EventType.createClass('jQueryInterfaces.EventType');jQueryInterfaces.LiveEventType.createClass('jQueryInterfaces.LiveEventType');jQueryInterfaces.DataType.createClass('jQueryInterfaces.DataType');jQueryInterfaces.ObjectFactory.createClass('jQueryInterfaces.ObjectFactory');lunchhunters.Scripts.MyClass.createClass('lunchhunters.Scripts.MyClass');jQueryInterfaces.Easing.linear='linear';jQueryInterfaces.Easing.swing='swing';jQueryInterfaces.Speed.slow='slow';jQueryInterfaces.Speed.normal='normal';jQueryInterfaces.Speed.fast='fast';jQueryInterfaces.EventType.blur='blur';jQueryInterfaces.EventType.focus='focus';jQueryInterfaces.EventType.load='load';jQueryInterfaces.EventType.resize='resize';jQueryInterfaces.EventType.scroll='scroll';jQueryInterfaces.EventType.unload='unload';jQueryInterfaces.EventType.beforeUnload='beforeunload';jQueryInterfaces.EventType.click='click';jQueryInterfaces.EventType.doubleClick='dblclick';jQueryInterfaces.EventType.mouseDown='mouseDown';jQueryInterfaces.EventType.mouseUp='mouseup';jQueryInterfaces.EventType.mouseMove='mousemove';jQueryInterfaces.EventType.mouseOver='mouseover';jQueryInterfaces.EventType.mouseOut='mouseout';jQueryInterfaces.EventType.mouseEnter='mouseenter';jQueryInterfaces.EventType.mouseLeave='mouseleave';jQueryInterfaces.EventType.change='change';jQueryInterfaces.EventType.select='select';jQueryInterfaces.EventType.submit='submit';jQueryInterfaces.EventType.keyDown='keydown';jQueryInterfaces.EventType.keyPress='keypress';jQueryInterfaces.EventType.keyUp='keyup';jQueryInterfaces.EventType.error='error';jQueryInterfaces.LiveEventType.click='click';jQueryInterfaces.LiveEventType.doubleClick='dblclick';jQueryInterfaces.LiveEventType.mouseDown='mouseDown';jQueryInterfaces.LiveEventType.mouseUp='mouseup';jQueryInterfaces.LiveEventType.mouseMove='mousemove';jQueryInterfaces.LiveEventType.mouseOver='mouseover';jQueryInterfaces.LiveEventType.mouseOut='mouseout';jQueryInterfaces.LiveEventType.keyDown='keydown';jQueryInterfaces.LiveEventType.keyPress='keypress';jQueryInterfaces.LiveEventType.keyUp='keyup';jQueryInterfaces.DataType.xml='xml';jQueryInterfaces.DataType.html='html';jQueryInterfaces.DataType.script='script';jQueryInterfaces.DataType.json='json';jQueryInterfaces.DataType.jsonP='jsonp';jQueryInterfaces.DataType.text='text';jQuery(jQueryFunctions.FunctionContext.createEmpty(lunchhunters.Scripts.MyClass,'documentReady'));
// ---- Do not remove this footer ----
// Generated using Script# v0.5.1.0 (http://projects.nikhilk.net)
// -----------------------------------