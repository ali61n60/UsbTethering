using System;
using Android.App;
using Android.Widget;
using Android.OS;
using UsbTethering.Controllers;

namespace UsbTethering
{
    [Activity(Label = "UsbTethering", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        private Button _buttonChangeWifiApState;
        private TextView _textViewMessage;
        private bool _wifiStateOn;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView (Resource.Layout.Main);
            initComponents();
        }

        private void initComponents()
        {
            _buttonChangeWifiApState = FindViewById<Button>(Resource.Id.buttonChangeWifiApState);
            _buttonChangeWifiApState.Click += _buttonChangeWifiApState_Click;

            _textViewMessage = FindViewById<TextView>(Resource.Id.textViewMessage);
        }

        private void _buttonChangeWifiApState_Click(object sender, System.EventArgs e)
        {
            Tethering tethering=new Tethering(this);
            try
            {
                tethering.SetWifiTetheringEnabled(true);
            }
            catch (Exception ex)
            {
                _textViewMessage.Text = ex.Message;
            }
            
            _wifiStateOn = !_wifiStateOn;
        }
    }
}

