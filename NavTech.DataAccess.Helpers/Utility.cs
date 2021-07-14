/************************************************************************************************************
************************************************************************************************************
    File Name     :   Utility.cs
    Created By    :   @Naga Visaradha
    Created On    :   14-JUL-2021
    Modified By   :
    Modified On   :
    Version       :   1.0  
    Common methods that are used in data layer will be present here
************************************************************************************************************
************************************************************************************************************/



using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Authentication;
using System.Threading.Tasks;

namespace NavTech.DataAccess.Helpers
{
    public static class Utility
    {
        /// <summary>
        /// Using httpclient calling the respective method based on method type and api url passed
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="client"></param>
        /// <param name="methodType"></param>
        /// <param name="requestUrl"></param>
        /// <param name="apiRoute"></param>
        /// <param name="requestBody"></param>
        /// <returns></returns>
        public static async Task<HttpResponseMessage> InitializeHttpsRequest<T>(HttpClient client, 
            string methodType, Uri requestUrl,
            string apiRoute, T requestBody)
        {
            var response = new HttpResponseMessage();
            using (var handler = new HttpClientHandler())
            {
                handler.ClientCertificateOptions = ClientCertificateOption.Manual;
                handler.SslProtocols = SslProtocols.Tls12 | SslProtocols.Tls11 | SslProtocols.Tls;
                handler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true;
                client.BaseAddress = requestUrl;
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(Constant.CONTENTTYPE));
                
                switch (methodType.ToUpper())
                {
                    case Constant.GET:                        
                        response = await client.GetAsync(apiRoute).ConfigureAwait(false);                        
                        break;
                    case Constant.POST:          
                        
                        response = await client.PostAsJsonAsync(apiRoute, requestBody).ConfigureAwait(false);                        
                        break;
                    case Constant.PUT:
                        response = await client.PutAsJsonAsync(apiRoute, requestBody).ConfigureAwait(false);
                        break;                    
                    default:
                        break;
                }

            }

            return response;
        }
        /// <summary>
        /// Conerting HttpResponseMessage to JObject /JArray
        /// </summary>
        /// <param name="response"></param>
        /// <param name="isArray"></param>
        /// <returns></returns>
        public static async Task<object> MapResponse(HttpResponseMessage response, bool isArray = true)
        {
            var json = string.Empty;
            if (response.Content != null)
            {
                using (var content = response.Content)
                {
                    json = await content.ReadAsStringAsync().ConfigureAwait(false);
                }
            }
            if(isArray)
            {
                var jArray = JArray.Parse(json);
                return jArray;

            }
            else
            {
                var jsonStr = JObject.FromObject(json);
                return jsonStr;

            }
        }

        
    }
}
