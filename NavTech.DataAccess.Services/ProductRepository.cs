/************************************************************************************************************
************************************************************************************************************
    File Name     :   ProductRepository.cs
    Created By    :   @Naga Visaradha
    Created On    :   14-JUL-2021
    Modified By   :
    Modified On   :
    Version       :   1.0  
    EF core API calls related to Read/Save Configuration from SQL server db
************************************************************************************************************
************************************************************************************************************/

using NavTech.AppGateway.DataAccess.Services;
using NavTech.AppGateway.Model.DatabaseModel;
using NavTech.DataAccess.Interfaces;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace NavTech.DataAccess.Services
{
    public class ProductRepository: IProductRepository
    {
        public ProductRepository()
        {

        }
        /// <summary>
        /// To get the records from sql server db using ef core
        /// </summary>
        /// <param name="fieldName"></param>
        /// <returns></returns>
        public Product GetProducts(string fieldName)
        {
            var productContext = new ProductDbContext();
            var productsWithFielName = productContext.Products
                                      .Where(s => s.FieldName == fieldName)
                                      .FirstOrDefault();
            return productsWithFielName;
        }
        /// <summary>
        /// to insert/update using stored procedure using ef core
        /// </summary>
        /// <param name="products"></param>
        /// <returns></returns>
        public Product InsertOrUpdateProducts(List<Product> products)
        {
            var productContext = new ProductDbContext();
            foreach(var product in products)
            {
                var productResult = productContext.Products.FromSqlRaw<Product>("Masterinsertupdatedelete " +
                    "@p0,@p1,@p2,@p3,@p4,@p5"
                    , product.EntityName, product.FieldName, product.IsRequired, product.MaxLength, product.FieldSource
                    , "Select")
                    .ToList();
                if(productResult.Any())
                {
                    productContext.Database.ExecuteSqlRaw("Masterinsertupdatedelete" +
                        "@p0,@p1,@p2,@p3,@p4,@p5"
                    , parameters : new object[] {product.EntityName, product.FieldName, product.IsRequired, 
                        product.MaxLength, product.FieldSource
                    , "Update" });
                }
                else
                {
                    var productResult2 = productContext.Products.FromSqlRaw("Masterinsertupdatedelete " +
                        "@p0,@p1,@p2,@p3,@p4,@p5"
                    , product.EntityName, product.FieldName, product.IsRequired, product.MaxLength, product.FieldSource
                    , "Insert")
                    .ToList();
                }
            }
            
            return null;


        }
    }
}
