using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using Dapper;
using System.Data;
using Dapper.Contrib.Extensions;
using System.Threading.Tasks;
using System.Configuration;
using Npgsql;

namespace SpotifyFinder.db {
    class DbConnector : IDbConnector {

        internal IDbConnection Connection {
            get {
                return new NpgsqlConnection(ConfigurationManager.ConnectionStrings["database"].ConnectionString);
            }
        }

        public string Add( string val ) {
            using (IDbConnection dbConnection = Connection) {
                dbConnection.Open();
                dbConnection.Execute("INSERT INTO \"Dappert\" ( wartosc ) " 
                                   + "VALUES ( @val )"
                                   , new { val });
                return val;
            }
        }
    }
}
