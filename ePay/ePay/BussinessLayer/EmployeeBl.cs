using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ePay.DataAccessLayer;
using ePay.Entity;
using System.Data;
using MySql.Data.MySqlClient;

namespace ePay.BussinessLayer
{
    public class EmployeeBL : DataAccess
    {        
        public EmployeeBL(string StrCon = "datasource=localhost; username=root; password=; database=db_sales;") 
            : base(StrCon)
        { }

        public int EmployeeCreate(Auth auth)
        {            
            MySqlParameter[] param = new MySqlParameter[] {
                new MySqlParameter("@name", auth.User.Name),
                new MySqlParameter("@phone", auth.User.Phone),
                new MySqlParameter("@username", auth.Username),
                new MySqlParameter("@password", auth.Password),
                new MySqlParameter("@inadmin", auth.InAdmin)
            };

            return ExNonQuery("sp_EmployeeCreate",
                    cmdType: CommandType.StoredProcedure,
                    parameter: param);
        }

        public int EmployeeUpdate(Auth auth)
        {            
            MySqlParameter[] param = new MySqlParameter[] {
                new MySqlParameter("@name", auth.User.Name),
                new MySqlParameter("@phone", auth.User.Phone),
                new MySqlParameter("@username", auth.Username),
                new MySqlParameter("@password", auth.Password),
                new MySqlParameter("@inadmin", auth.InAdmin)
            };

            return ExNonQuery("sp_EmployeeCreate",
                   cmdType: CommandType.StoredProcedure,
                   parameter: param);
        }
    }
}
