using UAR.Services;
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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace UAR
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class FrontPage : Page
    {
        public FrontPage()
        {
            this.InitializeComponent();
        }

        //Click event, for å direkte gå til "Møre og Romsdal".
        private void btn_ShowFylke(object sender, RoutedEventArgs e) 
        {
            var fylke = FakeService.GetFylkeByName("Møre og Romsdal");      //"MR" som parameter, i GetFylkeByName metoden i FakeService klassen

            if(fylke != null)
            {
                var kommuner = FakeService.GetAllKommunerByFylkeId(fylke.Id); //Henter ut kommuner med samme id som MR
                this.Frame.Navigate(typeof(KommuneListPage), kommuner);     //Navigerer til KommuneListPage, med MR sine kommuner
            }
            else
            {
                //Ingen fylker funnet, omdirigert til "MainPage"
                this.Frame.Navigate(typeof(MainPage));
            }
        }

        //Click event for å navigere til "MainPage"
        private void btn_ShowFylker(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }
    }
}
