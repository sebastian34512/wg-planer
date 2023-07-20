using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace BL_WGPlaner
{
    public class Einkaufslistenitem
    {
        internal Einkaufslistenitem () { }

        //Membervariablen

        private string mEID;
        private string martikel;
        private int manzahl;
        private string meinheit;
        private string mGID;

        //Properties

        public string EID
        {
            get { return mEID; }
            internal set { mEID = value; }
        }

        public string artikel
        {
            get { return martikel; }
            internal set { martikel = value; }
        }

        public int anzahl
        {
            get { return manzahl; }
            internal set { manzahl = value; }
        }

        public string einheit
        {
            get { return meinheit; }
            internal set { meinheit = value; }
        }

        public string GID
        {
            get { return mGID; }
            internal set { mGID = value; }
        }        
    }
}
