﻿using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;

namespace T034_Dapper.Data
{
	internal class DataContextDapper
	{
		private readonly string _connectionString = "Server=(localdb)\\MSSQLLocalDB;Database=DotNetCourseDatabase;TrustServerCertificate=true;Trusted_Connection=true;";

		public IEnumerable<T> LoadData<T>(string sql)
		{
			IDbConnection dbConnection = new SqlConnection(_connectionString);
			return dbConnection.Query<T>(sql);
		}

		public T LoadDataSingle<T>(string sql)
		{
			IDbConnection dbConnection = new SqlConnection(_connectionString);
			return dbConnection.QuerySingle<T>(sql);
		}

		public bool ExecuteSql(string sql)
		{
			IDbConnection dbConnection = new SqlConnection(_connectionString);
			return dbConnection.Execute(sql) > 0;
		}

		public int ExecuteSqlWithRowCount(string sql)
		{
			IDbConnection dbConnection = new SqlConnection(_connectionString);
			return dbConnection.Execute(sql);
		}
	}
}
