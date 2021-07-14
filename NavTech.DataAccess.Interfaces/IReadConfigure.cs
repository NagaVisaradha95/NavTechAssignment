/************************************************************************************************************
************************************************************************************************************
    File Name     :   IReadConfigure.cs
    Created By    :   @Naga Visaradha
    Created On    :   14-JUL-2021
    Modified By   :
    Modified On   :
    Version       :   1.0  
    Data Access interface for read configuration dl methods
************************************************************************************************************
************************************************************************************************************/

using System.Threading.Tasks;

namespace NavTech.DataAccess.Interfaces
{
    public interface IReadConfigure
    {
        Task<object> GetDefaultFieldsDl(string entityName);
        Task<object> GetCustomFieldsDl(string entityName);
    }
}
