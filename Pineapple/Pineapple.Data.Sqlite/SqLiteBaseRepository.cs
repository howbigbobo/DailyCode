﻿using System;
using System.Data.SQLite;
using System.IO;
using Dapper;
using log4net;

namespace Pineapple.Data.Sqlite
{
    internal class SqLiteBaseRepository
    {
        private static readonly ILog logger = LogManager.GetLogger(typeof(SqLiteBaseRepository));

        private static string DbFile
        {
            get { return System.AppDomain.CurrentDomain.BaseDirectory.TrimEnd('\\') + "\\App_Data\\Pineapple.sqlite"; }
        }

        internal static SQLiteConnection DbConnection()
        {
            string connectionString = string.Format("Data Source=\"{0}\";Pooling=True;", DbFile);
            logger.Debug(connectionString);
            var cnn = new SQLiteConnection(string.Format("Data Source=\"{0}\";Pooling=True;", DbFile));
            cnn.Open();
            return cnn;
        }

        internal static void InitDataBase()
        {
            //if (!File.Exists(DbFile))
            //{
            //    CreateDatabase();
            //}
            CreateDatabase();
        }

        private static void CreateDatabase()
        {
            using (var cnn = DbConnection())
            {
                cnn.Execute(
                    @"Create table if not exists Visitor
              (
                 ID                                  integer primary key AUTOINCREMENT,
                 VisitDate                           varchar(30) not null
              )");
            }

            SqliteTables st = new SqliteTables();
            st.CreateTables();
        }
    }
}