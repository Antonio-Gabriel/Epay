using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace ePay.DataAccessLayer
{
    public class DataAccess
    {
        private readonly string _StrCon;

        public string StrCon
        {
            get => _StrCon;
        }
        public DataAccess(string StrCon)
        {
            this._StrCon = StrCon;
        }

        // Execute Non Query
        protected int ExNonQuery(string cmdText, CommandType cmdType = CommandType.Text, MySqlParameter[] parameter = null)
        {
            using (MySqlConnection conection = new MySqlConnection(StrCon))
            {
                conection.Open();

                MySqlCommand command = new MySqlCommand(cmdText, conection);
                if(cmdType == CommandType.StoredProcedure)                
                    command.CommandType = CommandType.StoredProcedure;
                if(parameter != null)
                {
                    for (int i = 0; i < parameter.Length; i++)
                    {
                        command.Parameters.Add(parameter[i]);
                    }
                }
                int result = command.ExecuteNonQuery();
                return result;
            }
        }

        // Execute Reader
        protected DataTable ExReader( string cmdText, CommandType cmdType = CommandType.Text, MySqlParameter[] parameter = null)
        {
            using (MySqlConnection conection = new MySqlConnection(StrCon))
            {
                conection.Open();

                MySqlCommand command = new MySqlCommand(cmdText, conection);
                if (cmdType == CommandType.StoredProcedure)
                    command.CommandType = CommandType.StoredProcedure;
                if (parameter != null)
                {
                    for (int i = 0; i < parameter.Length; i++)
                    {
                        command.Parameters.Add(parameter[i]);
                    }
                }
                DataTable table = new DataTable();
                table.Load(command.ExecuteReader());
                return table;
            }
        }

        // Execute Scalar
        protected object ExScalar(string cmdText, CommandType cmdType = CommandType.Text, MySqlParameter[] parameter = null)
        {
            using (MySqlConnection conection = new MySqlConnection(StrCon))
            {
                conection.Open();

                MySqlCommand command = new MySqlCommand(cmdText, conection);
                if (cmdType == CommandType.StoredProcedure)
                    command.CommandType = CommandType.StoredProcedure;
                if (parameter != null)
                {
                    for (int i = 0; i < parameter.Length; i++)
                    {
                        command.Parameters.Add(parameter[i]);
                    }
                }
                object scalar = command.ExecuteScalar();                
                return scalar;
            }
        }

        protected MySqlDataReader ExAuth(string cmdText, CommandType cmdType = CommandType.Text, MySqlParameter[] parameter = null)
        {
            using (MySqlConnection conection = new MySqlConnection(StrCon))
            {
                conection.Open();

                MySqlCommand command = new MySqlCommand(cmdText, conection);
                if (cmdType == CommandType.StoredProcedure)
                    command.CommandType = CommandType.StoredProcedure;
                if (parameter != null)
                {
                    for (int i = 0; i < parameter.Length; i++)
                    {
                        command.Parameters.Add(parameter[i]);
                    }
                }

                MySqlDataReader reader = command.ExecuteReader();                  
                
                return (reader);
            }
        }
    }
}
