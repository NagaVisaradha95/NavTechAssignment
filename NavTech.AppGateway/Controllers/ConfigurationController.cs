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
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using NavTech.BusinessProcess.Interfaces;
using NavTech.AppGateway.Model.DataBaseModel;

namespace NavTech.AppGateway.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConfigurationController : Controller
    {
        #region Variables
        public IConfigure _configure;
        #endregion
        public ConfigurationController(IConfigure configure)
        {
            _configure = configure;
        }
        
        /// <summary>
        /// This controller is used to call the corresponding business and data layer methods to 
        /// retrieve the information based on entity passed
        /// </summary>
        /// <param name="entityName"></param>
        /// <returns></returns>
        [Route("~/api/readConfiguration")]
        [HttpGet]
        public async Task<IActionResult> ReadConfiguration(string entityName)
        {            
            var readConfigurationResponse = await _configure
                                .ReadConfigurationBl(entityName).ConfigureAwait(false);
            return Ok(readConfigurationResponse.Response);
        }
        /// <summary>
        /// This controller is used to call the corresponding business and data layer methods to 
        /// save the information based list of products passed
        /// </summary>
        /// <param name="productObj"></param>
        /// <returns></returns>
        [Route("~/api/saveConfiguration")]
        [HttpPost]
        public async Task<IActionResult> SaveConfiguration(Products productObj)
        {
            var readConfigurationResponse = await _configure
                                .SaveConfigurationBl(productObj).ConfigureAwait(false);
            return Ok(readConfigurationResponse.Response);
        }
    }
}
