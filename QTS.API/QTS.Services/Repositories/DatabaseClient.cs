﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QTS.Services.Interfaces;
namespace QTS.Services.Repositories
{
    public class DatabaseClient : IDatabaseClient
    {
        public SqlTransaction DbTransaction { get; set; }
        public SqlConnection DbConnection { get; set; }
        public string ConnectionString { get; set; }
        public DatabaseClient(string connectionString)
        {
            if (connectionString == null)
                throw new ArgumentNullException("connectionString");
            ConnectionString = connectionString;
            DbTransaction = null;
        }

        public DatabaseClient(SqlConnection connection)
        {
            if (connection == null)
                throw new ArgumentNullException("connection");
            DbConnection = connection;
            DbTransaction = null;
        }
        public DbTransaction BeginTransaction(IsolationLevel level = IsolationLevel.ReadCommitted)
        {
            DbTransaction = DbConnection.BeginTransaction(level);
            return DbTransaction;
        }
    }
}
