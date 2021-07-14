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
using System.Net.Http;

namespace NavTech.AppGateway.Model.ExceptionModel
{
    public class CustomException:Exception
    {
        /// <summary>
        /// Description
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Http Response Message
        /// </summary>
        public HttpResponseMessage HttpResponseMessage { get; set; }
        
        public CustomException(HttpResponseMessage responseMessage) //: base(responseMessage)
        {
            Description = "Something went wrong with the Postman Mock Server :(";
        }
    }
}
