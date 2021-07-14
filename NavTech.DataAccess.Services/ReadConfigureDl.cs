/************************************************************************************************************
************************************************************************************************************
    File Name     :   ReadConfigureDl.cs
    Created By    :   @Naga Visaradha
    Created On    :   14-JUL-2021
    Modified By   :
    Modified On   :
    Version       :   1.0  
    Data layer for API calls related to Read Configuration from source1,source2
************************************************************************************************************
************************************************************************************************************/
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using NavTech.AppGateway.Model.ExceptionModel;
using NavTech.DataAccess.Helpers;
using NavTech.DataAccess.Interfaces;

namespace NavTech.DataAccess.Services
{
    public class ReadConfigureDl : IReadConfigure
    {
        #region Variables

        private IConfigurationSection _configuration;
        private readonly IHttpClientFactory _clientFactory;

        #endregion
        public ReadConfigureDl(IConfiguration configuration, IHttpClientFactory clientFactory)
        {
            _configuration = configuration?.GetSection(Constant.PARAMSETTINGS);
            _clientFactory = clientFactory;
        }
        /// <summary>
        /// Dl method to get the api response from source1
        /// </summary>
        /// <param name="entityName"></param>
        /// <returns></returns>
        public async Task<object> GetDefaultFieldsDl(string entityName)
        {
            var postmanMockUrl = _configuration[Constant.POSTMANMOCKSERVERENDPOINT];
            var apiRoute = string.Empty;
            var response = await Utility.InitializeHttpsRequest(_clientFactory.CreateClient(), Constant.GET,
                new Uri(postmanMockUrl + Constant.SLASH + Constant.DEFAULTFIELDS + Constant.SLASH + entityName),
                apiRoute, string.Empty).ConfigureAwait(false);
            if (response.IsSuccessStatusCode)
            {
                var jObj = await Utility.MapResponse(response);
                return jObj;
            }
            throw new CustomException(response);
        }
        /// <summary>
        ///  Dl method to get the api response from source2
        /// </summary>
        /// <param name="entityName"></param>
        /// <returns></returns>
        public async Task<object> GetCustomFieldsDl(string entityName)
        {
            var postmanMockUrl = _configuration[Constant.POSTMANMOCKSERVERENDPOINT];
            var apiRoute = string.Empty;
            var response = await Utility.InitializeHttpsRequest(_clientFactory.CreateClient(), Constant.GET,
                new Uri(postmanMockUrl + Constant.SLASH + Constant.CUSTOMFIELDS + Constant.SLASH + entityName),
                apiRoute, string.Empty).ConfigureAwait(false);
            if (response.IsSuccessStatusCode)
            {
                var jObj = await Utility.MapResponse(response);
                return jObj;
            }
            throw new CustomException(response);

        }
    }
}
