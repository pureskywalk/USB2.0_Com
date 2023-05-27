using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HIDTester
{
    public class Report : EventArgs
    {
        public readonly byte reportID;
        public readonly byte[] reportBuff;
        public Report(byte id, byte[] arrayBuff)
        {
            reportID = id;
            reportBuff = arrayBuff;
        }

    }
}
