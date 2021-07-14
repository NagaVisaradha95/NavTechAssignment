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
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace NavTech.AppGateway.Model.DataBaseModel
{
    public class ResponseMessage
    {
        
        /// <summary>
        /// Name of the StatusCode
        /// </summary>
        public int StatusCode { get; set; }
        /// <summary>
        /// Name of the ErrorCode
        /// </summary>
        public string ErrorCode { get; set; }
        /// <summary>
        /// Name of the Message
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        /// Name of the Message
        /// </summary>
        public string ErrorMessage { get; set; }
        /// <summary>
        /// Response object
        /// </summary>
        public JObject Response { get; set; }        
        /// <summary>
        /// Byte array object to return xml file
        /// </summary>
        public byte[] ByteResponse { get; set; }
        /// <summary>
        /// request uri for getting error provider
        /// </summary>
        public string RequestUri { get; set; }
        /// <summary>
        /// Http Response Message
        /// </summary>
        public HttpResponseMessage HttpResponseMessage { get; set; }
        /// <summary>
        /// Http Request Message
        /// </summary>
        public HttpRequestMessage HttpRequestMessage { get; set; }
        /// <summary>
        /// Error description
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// IsSuccessStatusCode
        /// </summary>
        public bool IsSuccessStatusCode { get; set; }
        /// <summary>
        /// IsSuccessStatusCode
        /// </summary>
        public JArray ResponseArray { get; set; }
        
    }
}

