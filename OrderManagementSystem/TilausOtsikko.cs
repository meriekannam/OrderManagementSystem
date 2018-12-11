using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagementSystem
{
    class TilausOtsikko
    {
            private DateTime tilausPvm;
            private DateTime toimitusPvm;
            public int TilausNumero { get; set; }
            public string AsiakkaanNimi { get; set; }
            public int AsiakasNumero { get; set; }
            public string ToimitusOsoite { get; set; }
            public DateTime TilausPvm
            {
                get
                {
                    return tilausPvm;
                }
                set
                {
                    if (value <= DateTime.Today) //Dates can be checked as if it is a number
                    {
                        tilausPvm = value;
                    }

                    else
                    {
                        throw new ArgumentOutOfRangeException("Tilauspvm ei voi olla tulevaisuudessa");
                    }
                }
            }
            public DateTime ToimitusPvm
            {
                get
                {
                    return toimitusPvm;
                }
                set
                {
                    if (value > DateTime.Today) //Dates can be checked as if it is a number
                    {
                        toimitusPvm = value;
                    }

                    else
                    {
                        throw new ArgumentOutOfRangeException("ToimitusPvm ei voi olla menniesyydessa");
                    }
                }
            }

            internal string LaskeToimitusAika()
            {
                TimeSpan erotus;
                erotus = ToimitusPvm.Subtract(tilausPvm);
                return erotus.ToString();
            }

    }
}

