using nexus.core;
using nexus.protocols.ble;
using nexus.protocols.ble.scan;
using nexus.protocols.ble.scan.advertisement;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GrayDog.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BlePage : ContentPage
    {
        IBluetoothLowEnergyAdapter ble;

        public BlePage()
        {
            InitializeComponent();
            ble = App.Adapter;
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            if (ble.AdapterCanBeDisabled && ble.CurrentState.IsDisabledOrDisabling())
            {
                await ble.EnableAdapter();
            }

            ble.CurrentState.Subscribe(state => Debug.WriteLine("New State: {0}", state));

            var cts = new CancellationTokenSource(TimeSpan.FromSeconds(30));
            await App.Adapter.ScanForBroadcasts(
               // providing ScanSettings is optional
               new ScanSettings()
               {
                   // Setting the scan mode is currently only applicable to Android and has no effect on other platforms.
                   // If not provided, defaults to ScanMode.Balanced
                   Mode = ScanMode.LowPower,

                   // Optional scan filter to ensure that the observer will only receive peripherals
                   // that pass the filter. If you want to scan for everything around, omit the filter.
                   //Filter = new ScanFilter()
                   //{
                   //    AdvertisedDeviceName = "foobar",
                   //    AdvertisedManufacturerCompanyId = 76,
                   //    // peripherals must advertise at-least-one of any GUIDs in this list
                   //    AdvertisedServiceIsInList = new List<Guid>() { Guid.NewGuid() },
                   //},

                   // ignore repeated advertisements from the same device during this scan
                   IgnoreRepeatBroadcasts = false
               },
               // Your IObserver<IBlePeripheral> or Action<IBlePeripheral> will be triggered for each discovered
               // peripheral based on the provided scan settings and filter (if any).

               (IBlePeripheral peripheral) =>
               {
                   // read the advertising data
                   var adv = peripheral.Advertisement;
                   Debug.WriteLine("****" + adv.DeviceName);
                   Debug.WriteLine("****" + adv.Services.Select(x => x.ToString()).Join(","));
                   Debug.WriteLine("****" + adv.ManufacturerSpecificData.FirstOrDefault().CompanyName());
                   Debug.WriteLine("****" + adv.ServiceData);

                   // if we found what we needed, stop the scan manually
                   cts.Cancel();

                   // perhaps connect to the device (see next example)...
               },
               // Provide a CancellationToken to stop the scan, or use the overload that takes a TimeSpan.
               // If you omit this argument, the scan will timeout after BluetoothLowEnergyUtils.DefaultScanTimeout
               cts.Token
            );

            // scanning has stopped when code reached this point since the scan was awaited


        }
    }
}