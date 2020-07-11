using UAR.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using UAR.ViewModels;
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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace UAR
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            VM = new MainPageViewModel();
            this.InitializeComponent();
        }

        //Lager VM for å bruke ViewModels
        public MainPageViewModel VM { get; set; }

        //Knappen med Id blir lagret i fylkeId.
        //Konverterer over til int (for parameter), henter alle kommuner med den Id'en og lagres i "kommuner"
        //Navigerer til KommuneListPage med kommunene som svarer til spørringen
        public void Button_Click(object sender, RoutedEventArgs e)
        {
            var fylkeId = ((Button)sender).Tag;

            var kommuner = FakeService.GetAllKommunerByFylkeId((int)fylkeId);

            
            this.Frame.Navigate(typeof(KommuneListPage), kommuner);
        }

        //Event som blir trigges når man navigerer til KommuneListPage. 
        //Siden er tom, så denne eventen populerer siden...
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (VM.Fylker == null)
                VM.Fylker = new List<FylkeViewModel>();

            var fylker = FakeService.GetFylker();

            foreach(var fylke in fylker)
            {
                VM.Fylker.Add(new FylkeViewModel { Id = fylke.Id, Name = fylke.Name });
            }


            base.OnNavigatedTo(e);
        }

        //Naviger til forrige side
        public void GoBack(object sender, RoutedEventArgs e)
        {
            this.Frame.GoBack();
        }

    }
}
