using UAR.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels;
using UAR.Models;

namespace ViewModels
{
    public class KommuneViewModel : NotificationBase<Kommuner>
    {
        public string Name { get; set; }
        public string Fylke { get; set; }
        public int Id { get; set; }
        public int AntallPostNr { get; set; }

    }
}
