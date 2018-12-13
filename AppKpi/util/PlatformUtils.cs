using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace AppKpi.util
{
    public class PlatformUtils
    {
        public static string GetProjectPath()
        {
            var path = "AppContagem.";

            switch (Device.RuntimePlatform)
            {
                case Device.iOS:
                    path += "iOS";
                    break;
                case Device.Android:
                    path += "Droid";
                    break;
            }

            return path;
        }
    }
}
