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
using System;
using System.Collections.Generic;

#nullable disable

namespace NavTech.AppGateway.Model.DatabaseModel
{
    public class Product
    {
        public string EntityName { get; set; }
        public string FieldName { get; set; }
        public bool? IsRequired { get; set; }
        public int? MaxLength { get; set; }
        public string FieldSource { get; set; }
    }
}
