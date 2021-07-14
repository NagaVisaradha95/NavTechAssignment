/************************************************************************************************************
************************************************************************************************************
    File Name     :   ConfigurationController.cs
    Created By    :   @Naga Visaradha
    Created On    :   14-JUL-2021
    Modified By   :
    Modified On   :
    Version       :   1.0  
    Controller file for API calls related to Read/Save Configuration
************************************************************************************************************
************************************************************************************************************/
using NavTech.AppGateway.Model.DatabaseModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace NavTech.AppGateway.Model.DataBaseModel
{
    public class Products
    {
        public List<Product> Fields { get; set; }
        public string EntityName { get; set; }
    }
}
