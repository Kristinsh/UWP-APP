using UAR.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using ViewModels;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using UAR.Models;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace UAR
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class KommuneListPage : Page
    {
        public KommuneListPage()
        {
            this.InitializeComponent();
        }

        //Filtrerer kommunene for oss etter hvilket fylke som har blitt valgt
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            var kommuner = (List<Kommuner>)e.Parameter;
            VM = new KommuneListViewModel();
            VM.Kommuner = VM.Kommuner ?? new List<KommuneViewModel>(); //kopierer VM.Kommuner, dersom den er null blir det laget en ny liste

            if (kommuner != null)
            {
                foreach (var kommune in kommuner)
                {
                    var kommuneViewModel = new KommuneViewModel() { Fylke = kommune.Fylke, Id = kommune.Id, Name = kommune.Name };
                    VM.Kommuner.Add(kommuneViewModel);
                }
            }
            base.OnNavigatedTo(e);  
        }

        //For å ta i bruk fra KommuneViewModel -> VM
        public KommuneListViewModel VM { get; set; } 

        //Lagrer Id på knappen som ble trykket i kommunerId.
        //Konverterer så til int for å legge inn som parameter i GetKommuneById, lagres i "kommuner"
        //Naviger til KommunePage som svarer til "kommune"
        public void Button_Click(object sender, RoutedEventArgs e)
        {
            var kommunerId = ((Button)sender).Tag;
            var kommune = FakeService.GetKommuneById((int)kommunerId);
            this.Frame.Navigate(typeof(KommunePage), kommune);
        }

        //Naviger til forrige side.
        public void GoBack(object sender, RoutedEventArgs e)
        {
            this.Frame.GoBack();
        }
    }
}
