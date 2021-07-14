/************************************************************************************************************
************************************************************************************************************
    File Name     :   ConfigureBl.cs
    Created By    :   @Naga Visaradha
    Created On    :   14-JUL-2021
    Modified By   :
    Modified On   :
    Version       :   1.0  
   Contains the business logic for API calls related to Read/Save Configuration
************************************************************************************************************
************************************************************************************************************/

using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using NavTech.AppGateway.Model.DatabaseModel;
using NavTech.AppGateway.Model.DataBaseModel;
using NavTech.BusinessProcess.Interfaces;
using NavTech.DataAccess.Interfaces;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;

namespace NavTech.BusinessProcess.Services
{
    public class ConfigureBl:IConfigure
    {
        #region Variables
        public IReadConfigure _readConfigure;
        public IProductRepository _productRepository;
        #endregion
        public ConfigureBl(IReadConfigure readConfigure,IProductRepository productRepository)
        {
            _readConfigure = readConfigure;
            _productRepository = productRepository;
        }
        /// <summary>
        /// Get the data from source 1 and source 2 apis
        /// Created using postman mock servers
        /// Using the combined data to get the respective information from sql server db using ef core
        /// returning the combined response back to controller
        /// </summary>
        /// <param name="entityName"></param>
        /// <returns></returns>
        public async Task<ResponseMessage> ReadConfigurationBl(string entityName)
        {
            //Calling dl to get data from source1 api
            var defFields = await _readConfigure.GetDefaultFieldsDl(entityName).ConfigureAwait(false);
            var allFields = new List<string>();

            if (defFields!=null)
            {
                var defFieldsResponse = JArray.FromObject(defFields).ToObject<List<string>>();
                allFields.AddRange(defFieldsResponse);
            }
            //Calling dl to get data from source1 api
            var customFields = await _readConfigure.GetCustomFieldsDl(entityName).ConfigureAwait(false);
            if (customFields!=null)
            {
                var custFieldsResponse = JArray.FromObject(customFields).ToObject<List<string>>();
                allFields.AddRange(custFieldsResponse);
            }

            //Looping through the combined data to get the respective information from db
            //Calling getProducts data layer
            var productObjList = new List<Product>();
            if(allFields!=null)
            {
                allFields.ForEach(field =>
                {
                    var productObj = _productRepository.GetProducts(field);
                    if (productObj != null)
                    {
                        productObjList.Add(productObj);
                    }
                });
            }
            
            var products = new Products();
            products.EntityName = entityName;
            products.Fields = productObjList;
            //returning the response back as per the expected output
            return new ResponseMessage
            {
                StatusCode = StatusCodes.Status200OK,
                Response = FilterNullValues(products)
            };
        }
        /// <summary>
        /// Gets the list of products to be inserted/updated in db as part of request body
        /// calls the dl layer for insert/update operation
        /// returns the reponse after successful insertion
        /// </summary>
        /// <param name="productObj"></param>
        /// <returns></returns>
        public async Task<ResponseMessage> SaveConfigurationBl(Products productObj)
        {
            _productRepository.InsertOrUpdateProducts(productObj.Fields);
            var resp = new ResponseMessage();
            return resp;
        }
        /// <summary>
        /// Removes null values from the object
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static JObject FilterNullValues(object obj)
        {
            var filteredJsonString = JsonConvert.SerializeObject(obj,
                new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore,
                    ContractResolver = new CamelCasePropertyNamesContractResolver()
                });
            return JObject.Parse(filteredJsonString);
        }
    }
}
