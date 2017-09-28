using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Net.Wifi;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Java.Lang;
using Java.Lang.Reflect;

namespace UsbTethering.Controllers
{
    public class Tethering
    {
        private Context _context;
        public Tethering(Context context)
        {
            _context = context;
        }

        //public Boolean setHotspot(Boolean On)
        //{

        //    if (On)
        //    {
        //        // disable WiFi, this method i have works fine
        //        setWifi(false);

        //        try
        //        {
        //            Java.Lang.Boolean boolean = (Java.Lang.Boolean)On;
        //            //WifiConfiguration wifiConfig = new WifiConfiguration();
        //            WifiConfiguration wifiConfig = (WifiConfiguration)GetSystemService(Context.WifiService);
        //            wifiConfig.Ssid = device.Replace(" ", "");  //This is the network name based on which device run it (Office, eth)
        //            var wifiManager = Application.Context.GetSystemService(Context.WifiService) as WifiManager;
        //            var method = wifiManager.Class.GetMethod("setWifiApEnabled", wifiConfig.Class, boolean.Class);

        //            return (Boolean)method.Invoke(wifiManager, wifiConfig, boolean);
        //        }
        //        catch (Exception e)
        //        {
        //            Log.Error(this.ToString(), e.Message);
        //            return false;
        //        }
        //    }
        //    return false;
        //}
        public void SetWifiTetheringEnabled(bool enable)
        {
            Java.Lang.Boolean boolean = (Java.Lang.Boolean)enable;
            
            WifiManager wifiManager = (WifiManager)_context.GetSystemService(Context.WifiService);
            WifiConfiguration wifiConfig =new WifiConfiguration();
            if (enable)
            {
                wifiManager.SetWifiEnabled(false);
            }

            Method[] methods = wifiManager.Class.GetDeclaredMethods();
            foreach (Method method in methods)
            {
                if (method.Name.Equals("setWifiApEnabled"))
                {
                    Class[] parameterTypes = method.GetParameterTypes();
                    ITypeVariable[] typeParameters = method.GetTypeParameters();
                    method.Invoke(wifiManager,wifiConfig, boolean);
                    break;
                }
            }
        }
    }
}