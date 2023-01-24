using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testNo3
{
    class ConnectionWeb
    {
        public MySqlConnection conn;
        public MySqlCommand cmd;
        public MySqlDataReader mdr;
        public string res;


        public MySqlConnection getwebcon()
        {

            //conn = new MySqlConnection("server=192.168.1.3;user id=smsadmin; password=SmsEonbotz2016!;database=smsdbv2;port=3306;SSL Mode=None");
            //conn = new MySqlConnection("server=192.168.1.12;user id=Randel; password=RandelEonbotz2021;database=smsdbv2;port=3306;SSL Mode=None");
            //conn = new MySqlConnection("server=192.168.0.100;user id=drpsms; password=eonbotz2016!a;database=smsdbv2;port=3306;SSL Mode=None");
            conn = new MySqlConnection("server=192.185.236.177;user id=eonbosms_smsdbv2; password=EonBotzsms2016!;database=eonbosms_smsdbv2;port=3306;SSL Mode=None");

            return conn;
        }
    }
}
