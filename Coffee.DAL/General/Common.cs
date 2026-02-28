using System;
using System.Collections.Generic;
using System.Text;

namespace Coffee.General
{
    public static class Common
    {
        public enum OrderStatus
        {
            Pending,            // PN
            Processing,         // PR
            Completed,          // CP
            Cancelled,          // CA
            Delivered           // DL
        }

        public enum MenuStatus
        {
            Available,      //AV
            OutOfStock,     //OS
            Discontinued,   //DC
            Hidden          //HI
        }

    }


}
