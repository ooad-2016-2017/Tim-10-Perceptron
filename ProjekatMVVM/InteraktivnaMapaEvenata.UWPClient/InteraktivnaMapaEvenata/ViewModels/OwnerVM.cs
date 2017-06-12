using InteraktivnaMapaEvenata.Helpers;
using InteraktivnaMapaEvenata.Services.Interfaces;
using InteraktivnaMapaEvenata.UWP.Models;
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
        public AuthenticationVM AuthenticationVM { get; set; }
        CancellationTokenSource tokenSource;

        public OwnerVM(IOwnerService ownerService,
            AuthenticationVM authenticationVM)
        {
            AuthenticationVM = authenticationVM;
            OwnerService = ownerService;
        }
        public async void Activate(object parameter)
        {
            tokenSource = new CancellationTokenSource();
            await Task.Run(async () =>
            {
                //ct.ThrowIfCancellationRequested();
                string selector = SerialDevice.GetDeviceSelector("COM7");
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

                    while (true)
                    {
                        Event evnt = await OwnerService.GetLastEvent(AuthenticationVM.Owner.OwnerId);
                        dataWriter.WriteString(evnt.EventId.ToString());
                        await dataWriter.StoreAsync();
                        Task.Delay(TimeSpan.FromSeconds(5)).Wait();
                    }
                    dataWriter.DetachStream();
                }
            });
        }

        public void Deactivate(object parameter)
        {
            throw new NotImplementedException();
        }
    }
}
