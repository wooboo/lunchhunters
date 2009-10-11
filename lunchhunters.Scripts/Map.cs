// Class1.cs
//

using System;
using System.DHTML;
using ScriptFX;
using ScriptFX.UI;
using jQueryFunctions;

namespace lunchhunters.Scripts
{

    public static class MyClass
    {
        static MyClass()
        {
            Global.jQuery(FunctionContext.CreateEmpty(typeof(MyClass), "documentReady"));
        }

        public static void DocumentReady()
        {
            
        }
    }
}
