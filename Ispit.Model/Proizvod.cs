using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ispit.Model
{
    internal class Proizvod
        {
            public Proizvod(int ProizvodID, string Naziv)
            {
                this.ProizvodID = ProizvodID;
                this.Naziv = Naziv;
            }

            public int ProizvodID { get; set; }
            public string Naziv { get; set; }
        }
    }


