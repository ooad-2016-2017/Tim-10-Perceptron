using InteraktivnaMapaEvenata.Helpers;
using InteraktivnaMapaEvenata.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

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

        public async void Activate(object parameter)
        {
            tokenSource = new CancellationTokenSource();
            CancellationToken ct = tokenSource.Token;
            await Task.Run(async () =>
            {
                //ct.ThrowIfCancellationRequested();
                while (true)
                {
                    // Kod za Arduino ide ovdje
                }
            }, tokenSource.Token);
        }

        public void Deactivate(object parameter)
        {
            throw new NotImplementedException();
        }
    }
}
