using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testNo3
{
    public class SOAdata
    {



        public class Matr
        {
            public string ctgry { get; set; }

            public double amts { get; set; }
            public double ttl { get; set; }

        }

        public class studinfo
        {
            public string studentID { get; set; }
            public string Name { get; set; }

            public string gender { get; set; }
            public string course { get; set; }

            public string yrlvl { get; set; }
            public string term { get; set; }
            public string studentstatus { get; set; }
            public string status { get; set; }


        }
        public class tuitionfee
        {
            public double downpayment { get; set; }
            public double prelim { get; set; }
            public double midterm { get; set; }
            public double semi { get; set; }
            public double final { get; set; }
            public double total { get; set; }

            public double currentbalance { get; set; }
            public double amountpaid { get; set; }

        }

    }


}
