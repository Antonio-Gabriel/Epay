using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ePay.DataAccessLayer;
using ePay.Entity;
using MySql.Data.MySqlClient;
using System.Data;
using ePay.Contracts;

namespace ePay.BussinessLayer
{
    public class BrandBL : DataAccess, IGenericRepository<Brand>
    {
        public BrandBL(string StrCon = "datasource=localhost; username=root; password=; database=db_sales;") 
            : base(StrCon)
        {}        

        public int Create(Brand entity)
        {
            MySqlParameter[] param = new MySqlParameter[] {
                new MySqlParameter("@brandName", entity.BrandName)
            };
            return ExNonQuery(
                    cmdText: "INSERT INTO tb_brand (name, date_created) values (@brandName, NOW())",
                    parameter: param
                );
        }

        public DataTable Read()
        {
            return ExReader(
                   cmdText: "SELECT * FROM tb_brand"
               );
        }

        public int Update(Brand entity)
        {
            MySqlParameter[] param = new MySqlParameter[] {
                new MySqlParameter("@idBrand", entity.Id_brand),
                new MySqlParameter("@brandName", entity.BrandName),
            };
            return ExNonQuery(
                    cmdText: "UPDATE tb_brand SET name = @brandName WHERE id_brand = @idBrand",
                    parameter: param
                );
        }

        public int Delete(int id_brand)
        {
            MySqlParameter[] param = new MySqlParameter[] {
                new MySqlParameter("@idBrand", id_brand)
            };
            return ExNonQuery(
                    cmdText: "DELETE FROM tb_brand WHERE id_brand = @idBrand",
                    parameter: param
                );
        }

        public DataTable Search(string name)
        {
            MySqlParameter[] param = new MySqlParameter[] {
                new MySqlParameter("@brandName", name)
            };
            return ExReader(
                    cmdText: "SELECT * FROM tb_brand WHERE name LIKE (concat(@brandName, '%'))",
                    parameter: param
                );
        }
    }
}
