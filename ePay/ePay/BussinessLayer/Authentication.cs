using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;
using ePay.DataAccessLayer;
using ePay.Entity;

namespace ePay.BussinessLayer
{    
    public class Authentication : DataAccess
    {        
        public Authentication(string StrCon = "datasource=localhost; username=root; password=; database=db_sales;") 
            : base(StrCon)
        { }

        public Auth VerifyAccess(string username, string password)
        {            
            MySqlParameter[] param = new MySqlParameter[] 
            {
                new MySqlParameter("@username_auth", username),
                new MySqlParameter("@passsword_auth", password)
            };

            DataTable table = ExReader("sp_auth",
                    cmdType:   CommandType.StoredProcedure,
                    parameter: param);
            
            return (table.Rows.Count > 0) ?
                new Auth()
                {
                    Id_auth = (int)table.Rows[0][0],
                    User = new Employee()
                    {
                        Id = (int)table.Rows[0][1],
                        Name = table.Rows[0][6].ToString(),
                        Phone = (int)table.Rows[0][7]
                    },
                    Username = table.Rows[0][2].ToString(),
                    InAdmin = (int)table.Rows[0][4]
                } 
                : null;
        }        
    }
}
