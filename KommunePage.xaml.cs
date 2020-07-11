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
    public sealed partial class KommunePage : Page
    {
        public KommunePage()
        {
            this.InitializeComponent();
        }
        //Event som blir trigget, viser antall Postnr for valgt kommune
        //Returnerer 0 dersom det ikke er registrert noen postnummere der
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            var kommuner = (Kommuner)e.Parameter;
            VM = new KommuneViewModel() { Name = kommuner.Name, Fylke = kommuner.Fylke, Id = kommuner.Id};

            if (kommuner.PostNr != null)
                VM.AntallPostNr = kommuner.PostNr.Count();
            else
                VM.AntallPostNr = 0;
                
            base.OnNavigatedTo(e);  
        }

        //Naviger til forrige side
        public void GoBack(object sender, RoutedEventArgs e)
        {
            this.Frame.GoBack();    
        }

        //Lag VM for å ta i bruk ViewModels
        public KommuneViewModel VM { get; set; }

    }
}
