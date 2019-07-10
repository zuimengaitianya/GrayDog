using nexus.core;
using nexus.protocols.ble;
using nexus.protocols.ble.gatt.adopted;
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
        List<IBlePeripheral> blePeripherals;

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

            ble.CurrentState.Subscribe(state => Debug.WriteLine("************New State: {0}", state));

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

        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            var connection = await ble.ConnectToDevice(
                   // The IBlePeripheral to connect to
                   blePeripherals[0],
                   // TimeSpan or CancellationToken to stop the
                   // connection attempt.
                   // If you omit this argument, it will use
                   // BluetoothLowEnergyUtils.DefaultConnectionTimeout
                   TimeSpan.FromSeconds(15),
                   // Optional IProgress<ConnectionProgress>
                   progress => Debug.WriteLine(progress)
                );
            /*
             * Connect to a specific device without manually scanning
             * In use-cases where you are not scanning for advertisements but rather looking to connect to a specific, known, device:
             */
            //var connection = await ble.FindAndConnectToDevice(
            //   new ScanFilter()
            //      .SetAdvertisedDeviceName("foo")
            //      .SetAdvertisedManufacturerCompanyId(0xffff)
            //      .AddAdvertisedService(guid),
            //   TimeSpan.FromSeconds(30));

            if (connection.IsSuccessful())
            {
                var gattServer = connection.GattServer;
                // ... do things with gattServer here... (see later examples...)

                /*
                 * See & Observe server connection Status
                 */
                Debug.WriteLine(gattServer.State); // e.g. ConnectionState.Connected
                                                   // the server implements IObservable<ConnectionState> so you can subscribe to its state
                gattServer.Subscribe(state =>
                {
                    if (state == ConnectionState.Disconnected)
                    {
                        Debug.WriteLine("Connection Lost");
                    }
                });

                var known = new KnownAttributes();

                foreach (var guid in await gattServer.ListAllServices())
                {
                    Debug.WriteLine($"service: {known.GetDescriptionOrGuid(guid)}");
                }

                //Debug.WriteLine($"service: {serviceGuid}");
                //foreach (var guid in await gattServer.ListServiceCharacteristics(serviceGuid))
                //{
                //    Debug.WriteLine($"characteristic: {known.GetDescriptionOrGuid(guid)}");
                //}

                //Be sure to disconnect when you are done:
                await gattServer.Disconnect();

            }
            else
            {
                // Do something to inform user or otherwise handle unsuccessful connection.
                Debug.WriteLine("Error connecting to device. result={0:g}", connection.ConnectionResult);
                // e.g., "Error connecting to device. result=ConnectionAttemptCancelled"
            }
        }

        public void GATTAGUIDSFun()
        {
            var known = new KnownAttributes();

            //// You can add descriptions for any desired
            //// characteristics, services, and descriptors
            //known.AddService(myGuid1, "Foo");
            //known.AddCharacteristic(myGuid2, "Bar");
            //known.AddDescriptor(myGuid3, "Baz");
        }

    }
}