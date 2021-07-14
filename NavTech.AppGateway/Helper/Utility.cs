/************************************************************************************************************
************************************************************************************************************
    File Name     :   Utility.cs
    Created By    :   @Naga Visaradha
    Created On    :   14-JUL-2021
    Modified By   :
    Modified On   :
    Version       :   1.0  
    Utility file to store most commonly used methods related to AppGateway Project
************************************************************************************************************
************************************************************************************************************/
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace NavTech.AppGateway.Helper
{
    public static class Utility
    {
        /// <summary>
        /// Serializes object to a string
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string SerializeObjectValue(object value)
        {
            return JsonConvert.SerializeObject(value, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            });
        }
    }
}
