using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL_WGPlaner
{
    public class WochenplanerItem
    {
        internal WochenplanerItem() { }

        private string mWID;
        private string mtitel;
        private DateTime merstellung;
        private int mhaeufigkeit;
        private string mGID;
        private string mPID;
        private string mperson;

        public string person
        {
            get { return mperson; }
            internal set { mperson = value; }
        }
        public string WID
        {
            get { return mWID; }
            internal set { mWID = value; }
        }
        public string titel
        {
            get { return mtitel; }
            internal set { mtitel = value; }
        }
        public DateTime erstellung
        {
            get { return merstellung; }
            internal set { merstellung = value; }
        }
        public int haeufigkeit
        {
            get { return mhaeufigkeit; }
            internal set { mhaeufigkeit = value; }
        }
        public string GID
        {
            get { return mGID; }
            internal set { mGID = value; }
        }
        public string PID
        {
            get { return mPID; }
            internal set { mPID = value; }
        }

        

    }
}
