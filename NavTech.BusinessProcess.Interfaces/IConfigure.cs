/************************************************************************************************************
************************************************************************************************************
    File Name     :   IConfigure.cs
    Created By    :   @Naga Visaradha
    Created On    :   14-JUL-2021
    Modified By   :
    Modified On   :
    Version       :   1.0  
    Interface for ConfigureBl business class. Contains only the methods declarations
************************************************************************************************************
************************************************************************************************************/

using NavTech.AppGateway.Model.DataBaseModel;
using System.Threading.Tasks;

namespace NavTech.BusinessProcess.Interfaces
{
    public interface IConfigure
    {
        Task<ResponseMessage> ReadConfigurationBl(string entityName);
        Task<ResponseMessage> SaveConfigurationBl(Products productObj);
    }
}
