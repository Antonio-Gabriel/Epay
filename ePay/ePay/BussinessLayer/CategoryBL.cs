using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
using ePay.Entity;
using ePay.DataAccessLayer;
using ePay.Contracts;

namespace ePay.BussinessLayer
{
    public class CategoryBL: DataAccess, IGenericRepository<Category>
    {
        public CategoryBL(string StrCon = "datasource=localhost; username=root; password=; database=db_sales;") 
            : base(StrCon)
        { }

        public int Create(Category entity)
        {
            MySqlParameter[] param = new MySqlParameter[] {
                new MySqlParameter("@categoryName", entity.CategoryName)
            };
            return ExNonQuery(
                    cmdText: "INSERT INTO tb_category (name, date_created) values (@categoryName, NOW())",
                    parameter: param
                );
        }

        public DataTable Read()
        {
            return ExReader(
                   cmdText: "SELECT * FROM tb_category"
               );
        }

        public int Update(Category entity)
        {
            MySqlParameter[] param = new MySqlParameter[] {
                new MySqlParameter("@idCategory", entity.IdCategory),
                new MySqlParameter("@categoryName", entity.CategoryName),
            };
            return ExNonQuery(
                    cmdText: "UPDATE tb_category SET name = @categoryName WHERE id_category = @idCategory",
                    parameter: param
                );
        }

        public int Delete(int id)
        {
            MySqlParameter[] param = new MySqlParameter[] {
                new MySqlParameter("@idCategory", id)
            };
            return ExNonQuery(
                    cmdText: "DELETE FROM tb_category WHERE id_category = @idCategory",
                    parameter: param
                );
        }

        public DataTable Search(string name)
        {
            MySqlParameter[] param = new MySqlParameter[] {
                new MySqlParameter("@categoryName", name)
            };
            return ExReader(
                    cmdText: "SELECT * FROM tb_category WHERE name LIKE (concat(@categoryName, '%'))",
                    parameter: param
                );
        }
    }
}
