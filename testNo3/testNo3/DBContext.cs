using MySql.Data.MySqlClient;
using SqlKata.Compilers;
using SqlKata.Execution;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace testNo3
{
    public static class DBContext
    {
        //static Connection con = new Connection();
        //static MySqlConnection connection = new MySqlConnection("server=192.168.1.3;user id = smsadmin; password=SmsEonbotz2016!;database=smsdb;port=3306");
        //static MySqlConnection connection = new MySqlConnection("server=192.168.0.100; user id=drpsms; password=eonbotz2016!a;database=smsdb;port=3306");
        //static MySqlConnection connection = new MySqlConnection("server=localhost;user id=root; password=;database=smsdbv2;port=3306");
        // =======  Dr P
        //static MySqlConnection connection = new MySqlConnection("server=192.168.1.3;user id=smsadmin; password=SmsEonbotz2016!;database=smsdbv2;port=3306;SSL Mode=None");

        // static MySqlConnection connection = new MySqlConnection("server=192.168.1.9;user id=Randel; password=RandelEonbotz2021;database=smsdbv2;port=3306;SSL Mode=None");
        // == Developer ===
        //static MySqlConnection connection = new MySqlConnection("server=192.168.1.2;user id=Randel; password=RandelEonbotz2021;database=smsdbv2;port=3306;SSL Mode=None");

        static MySqlConnection connection = new MySqlConnection(holder.connectionstring);

        static MySqlCompiler compiler = new MySqlCompiler();

        public static QueryFactory GetContext() => new QueryFactory(connection, compiler);
    }
}
