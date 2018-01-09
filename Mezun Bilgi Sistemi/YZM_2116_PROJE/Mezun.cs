using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YZM_2116_PROJE
{
    public class Mezun
    {
        public string ad { get; set; }
        public string soyad { get; set; }
        public string adres { get; set; }
        public string telefon { get; set; }
        public string ePosta { get; set; }
        public string uyruk { get; set; }
        public DateTime dogumTarihi { get; set; }
        public int ogrenciNo { get; set; }
        public string yabanciDilSeviyesi { get; set; }
        public string ilgiAlanlari { get; set; }
        public string calistigiSirket { get; set; }
        public DateTime stajBaslangic { get; set; }
        public DateTime stajBitis { get; set; }
        public string calistigiDepartman { get; set; }
        public string calistigiGorev { get; set; }
    }
}
