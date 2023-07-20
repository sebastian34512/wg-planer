using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL_WGPlaner
{
    public class ToDolistenitem
    {
        internal ToDolistenitem() { }

        private string mTDID;
        private string maufgabe;
        private string mdatum;
        private string mPID;
        private string mGID;
        private string mbenutzername;

        public string TDID
        {
            get { return mTDID; }
            internal set { mTDID = value; }
        }

        public string aufgabe
        {
            get { return maufgabe; }
            set { maufgabe = value; }
        }

        public string datum
        {
            get { return mdatum; }
            set { mdatum = value; }
        }
        public string PID
        {
            get { return mPID; }
            set { mPID = value; }
        }

        public string GID
        {
            get { return mGID; }
            set { mGID = value; }
        }

        public string benutzername
        {
            get { return mbenutzername; }
            set { mbenutzername = value; }
        }
    }
}
