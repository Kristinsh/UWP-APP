using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UAR.Models;
using ViewModels;

namespace ViewModels
{
    public class KommuneListViewModel
    {
        public string Name { get; set; }
        
        public List<KommuneViewModel> Kommuner { get; set; }
 
    }
}
