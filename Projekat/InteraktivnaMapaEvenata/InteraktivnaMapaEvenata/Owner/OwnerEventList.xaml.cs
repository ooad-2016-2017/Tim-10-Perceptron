using InteraktivnaMapaEvenata.UWP.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace InteraktivnaMapaEvenata
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class OwnerEventList : Page
    {

        List<Event> Events { get; set; }
        string CreatedEvents { get; set; }
        public Frame frame { get; set; }

        public OwnerEventList()
        {
            this.InitializeComponent();
            frame = new Frame();
            Events = new List<Event>();
            for (int i = 0; i < 10; i++)
            {
                Events.Add(new Event()
                {
                    EventId = i,
                    Name = "event",
                    Description = "opis",
                    Owner = new UWP.Models.Owner()
                    {
                        Name = "owner"
                    }
                });
            }

            CreatedEvents = "Imate " + Events.Count + " kreiranih evenata"; 
            
        }
        
    }
}
