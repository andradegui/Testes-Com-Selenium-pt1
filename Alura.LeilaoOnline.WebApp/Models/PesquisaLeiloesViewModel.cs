using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Alura.LeilaoOnline.WebApp.Models
{
    public class PesquisaLeiloesViewModel
    {
        public string Termo { get; set; }
        public string[] Categorias { get; set; }
        public string Andamento { get; set; }
    }
}
