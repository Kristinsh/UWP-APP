using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UAR.Models;
using UAR.Services;

namespace ViewModels
{
    public class FylkeViewModel : NotificationBase<Fylker>
    {
        public int Id { get; set; }
        
        public string Name
        {
            get { return This.Name; }
            set { SetProperty(This.Name, value, () => This.Name = value); }
        }
    }
}
