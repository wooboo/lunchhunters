using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.ServiceHosting.ServiceRuntime;
using System.Configuration;

namespace lunchhunters
{
    public static class Utils
    {
        public static string GetConfigSetting(string key)
        {
            var res = TryGetConfigurationSetting(key);
            if (res == null)
            {
                res = TryGetAppSetting(key);
            }
            return res;
        }

        private static string TryGetConfigurationSetting(string configName)
        {
            string ret = null;
            try
            {
                ret = RoleManager.GetConfigurationSetting(configName);
            }
            catch (RoleException)
            {
                return null;
            }
            return ret;
        }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes",
            Justification = "Make sure that no error condition prevents environment from reading service configuration.")]
        private static string TryGetAppSetting(string configName)
        {
            string ret = null;
            try
            {
                ret = ConfigurationSettings.AppSettings[configName];
            }
            // some exception happened when accessing the app settings section
            // most likely this is because there is no app setting file
            // this is not an error because configuration settings can also be located in the cscfg file, and explicitly 
            // all exceptions are captured here
            catch (Exception)
            {
                return null;
            }
            return ret;
        }

    }
}
