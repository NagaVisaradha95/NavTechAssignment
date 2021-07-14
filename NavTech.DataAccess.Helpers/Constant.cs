/************************************************************************************************************
************************************************************************************************************
    File Name     :   Constant.cs
    Created By    :   @Naga Visaradha
    Created On    :   14-JUL-2021
    Modified By   :
    Modified On   :
    Version       :   1.0  
    Constants related to data access layer are present here
************************************************************************************************************
************************************************************************************************************/

namespace NavTech.DataAccess.Helpers
{
    public class Constant
    {
        public static readonly string PARAMSETTINGS = "ParamSettings";
        public static readonly string POSTMANMOCKSERVERENDPOINT = "PostmanMockServerEndpoint";

        #region HttpRequest related constants
        public static readonly string CONTENTTYPE = "application/json";        
        public const string POST = "POST";
        public const string GET = "GET";
        public const string PUT = "PUT";
        public const string PATCH = "PATCH";
        #endregion

        #region Special characters related Constants

        public static readonly string SLASH = "/";
        public static readonly string DEFAULTFIELDS = "defaultFields";
        public static readonly string CUSTOMFIELDS = "customFields";
        #endregion
    }
}
