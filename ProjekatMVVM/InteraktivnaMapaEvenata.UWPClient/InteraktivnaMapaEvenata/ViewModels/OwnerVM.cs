using InteraktivnaMapaEvenata.Helpers;
using InteraktivnaMapaEvenata.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Windows.Devices.Enumeration;
using Windows.Devices.SerialCommunication;
using Windows.Storage.Streams;
using Windows.UI.Popups;

namespace InteraktivnaMapaEvenata.ViewModels
{
    public class OwnerVM : BaseVM, INavigable
    {
        public IOwnerService OwnerService { get; set; }

        CancellationTokenSource tokenSource;
        public OwnerVM(IOwnerService ownerService)
        {
            OwnerService = ownerService;
        }
        private SerialDevice device;
        DataWriter writer = null;

        public async void Activate(object parameter)
        {
            tokenSource = new CancellationTokenSource();
            CancellationToken ct = tokenSource.Token;
            await Task.Run(async () =>
            {
                //ct.ThrowIfCancellationRequested();
                while (true)
                {


                    string selector = SerialDevice.GetDeviceSelector("COM4");
                    DeviceInformationCollection devices = await DeviceInformation.FindAllAsync(selector);
                    if (devices.Count > 0)
                    {
                        DeviceInformation deviceInfo = devices[0];
                        SerialDevice serialDevice = await SerialDevice.FromIdAsync(deviceInfo.Id);
                        serialDevice.BaudRate = 9600;
                        serialDevice.DataBits = 8;
                        serialDevice.StopBits = SerialStopBitCount.Two;
                        serialDevice.Parity = SerialParity.None;

                        DataWriter dataWriter = new DataWriter(serialDevice.OutputStream);
                        dataWriter.WriteString("your message here");
                        await dataWriter.StoreAsync();
                        dataWriter.DetachStream();
                        dataWriter = null;
                    }
                    else
                    {
                        MessageDialog popup = new MessageDialog("Sorry, no device found.");
                        await popup.ShowAsync();
                    }
                }
            }, tokenSource.Token);
        }

        public void Deactivate(object parameter)
        {
            throw new NotImplementedException();
        }
    }
}
