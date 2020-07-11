using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UAR.Models
{
    public class Kommuner
    {
        public string Name { get; set; }
        public int Id { get; set; }

        public List<int> PostNr { get; set; }
        public string Fylke { get; set; }

    }
}
