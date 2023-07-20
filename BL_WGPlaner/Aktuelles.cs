using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL_WGPlaner
{
    public class Aktuelles
    {
        internal Aktuelles () { }

        //Membervariablen

        private string mbezeichnung;
        private string mdatum;

        //Properties

        public string bezeichnung
        {
            get { return mbezeichnung; }
            internal set { mbezeichnung = value; }
        }

        public string datum
        {
            get { return mdatum; }
            internal set { mdatum = value; }
        }
    }
}
