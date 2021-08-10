using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ePay.DataAccessLayer;
using ePay.Contracts;
using ePay.Entity;
using System.Data;
using MySql.Data.MySqlClient;

namespace ePay.BussinessLayer
{
    public class ProductBL : DataAccess, IGenericRepository<Product>
    {
        public ProductBL(string StrCon = "datasource=localhost; username=root; password=; database=db_sales;") 
            : base(StrCon)
        {}

        public int Create(Product entity)
        {
            MySqlParameter[] param = new MySqlParameter[] {
                new MySqlParameter("@fk_id_user", entity.User.User.Id),
                new MySqlParameter("@fk_id_category", entity.Category.IdCategory),
                new MySqlParameter("@fk_id_brand", entity.Brand.Id_brand),
                new MySqlParameter("@name", entity.ProductName),
                new MySqlParameter("@price", entity.Price),
                new MySqlParameter("@code_product", entity.ProductCode),
                new MySqlParameter("@image", entity.ProductImage),
                new MySqlParameter("@description", entity.Description)
            };
            return ExNonQuery(
                    cmdText: "sp_CreateProduct",
                    cmdType: CommandType.StoredProcedure,
                    parameter: param
                );
        }

        public int Delete(int id)
        {
            MySqlParameter[] param = new MySqlParameter[] {
                new MySqlParameter("@id_product", id)               
            };
            return ExNonQuery(
                    cmdText: "DELETE FROM tb_product WHERE id_product = @id_product",                    
                    parameter: param
                );
        }

        public DataTable Read()
        {
            return ExReader(
                    cmdText: "SELECT * FROM vw_product;"
                );
        }

        public DataTable Search(string name)
        {
            MySqlParameter[] param = new MySqlParameter[] {
                new MySqlParameter("@productName", name),
            };
            return ExReader(
                   cmdText: "SELECT * FROM vw_product WHERE product LIKE (concat(@productName, '%')) OR brand LIKE (concat(@productName, '%'))",
                   parameter: param
               );
        }

        public int Update(Product entity)
        {
            MySqlParameter[] param = new MySqlParameter[] {
                new MySqlParameter("@id_product", entity.IdProduct),
                new MySqlParameter("@fk_id_user", entity.User.User.Id),
                new MySqlParameter("@fk_id_category", entity.Category.IdCategory),
                new MySqlParameter("@fk_id_brand", entity.Brand.Id_brand),
                new MySqlParameter("@name", entity.ProductName),
                new MySqlParameter("@price", entity.Price),
                new MySqlParameter("@code_product", entity.ProductCode),
                new MySqlParameter("@image", entity.ProductImage),
                new MySqlParameter("@description", entity.Description)
            };
            return ExNonQuery(
                    cmdText: "sp_UpdateProduct",
                    cmdType: CommandType.StoredProcedure,
                    parameter: param
                );
        }

        public object Count()
        {
            throw new NotImplementedException();
        }

        public DataTable FindByCode(int code)
        {
            MySqlParameter[] param = new MySqlParameter[] { 
                new MySqlParameter("@code_product", code),
            };
            return ExReader(
                   cmdText: "SELECT * FROM vw_product WHERE code_product = @code_product",
                   parameter: param
               );
        }
    }
}
