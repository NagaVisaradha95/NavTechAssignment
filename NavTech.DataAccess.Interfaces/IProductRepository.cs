/************************************************************************************************************
************************************************************************************************************
    File Name     :   IProductRepository.cs
    Created By    :   @Naga Visaradha
    Created On    :   14-JUL-2021
    Modified By   :
    Modified On   :
    Version       :   1.0  
    Interface for DataAccess methods
************************************************************************************************************
************************************************************************************************************/
using NavTech.AppGateway.Model.DatabaseModel;
using System.Collections.Generic;

namespace NavTech.DataAccess.Interfaces
{
    public interface IProductRepository
    {
        Product GetProducts(string fieldName);
        Product InsertOrUpdateProducts(List<Product> products);
    }
}
