/************************************************************************************************************
************************************************************************************************************
    File Name     :   ExceptionHandlingMiddleware.cs
    Created By    :   @Naga Visaradha
    Created On    :   14-JUL-2021
    Modified By   :
    Modified On   :
    Version       :   1.0  
    Custom Exception Handling Middleware to handle custom exceptions and messages
************************************************************************************************************
************************************************************************************************************/


using Microsoft.AspNetCore.Http;
using NavTech.AppGateway.Helper;
using NavTech.AppGateway.Model.ExceptionModel;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace NavTech.AppGateway
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate next;
        public ExceptionHandlingMiddleware(RequestDelegate next)
        {
            this.next = next;
        }
        public async Task Invoke(HttpContext context /* other dependencies */)
        {
            try
            {
                await next(context).ConfigureAwait(false);
            }
            catch (CustomException ex)
            {
                await HandleExceptionAsync(context, ex).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex).ConfigureAwait(false);
            }
        }
        private static Task HandleExceptionAsync<T>(HttpContext context, T exception)
        {
            var defaultException = (Exception)(object)exception;
            var result = new HttpResponseMessage();
            var code = HttpStatusCode.InternalServerError; // 500 if unexpected
            if (defaultException is CustomException customException)
            {
                
            }
            else
            {

                //result = new HttpResponseMessage
                //{
                //    Message = defaultException.Message,
                //    Description = Helper.Constant.SOMETHINGWENTWRONG,
                //    StatusCode = (int)code
                //};
                //if (result.Message.Contains(Constant.NOAUTHENTICATIONSCHEME))
                //{
                //    result.StatusCode = Constant.FORBIDDEN;
                //    result.Message = Constant.INVALIDEXCEPTIONLOGGING;
                //    result.Description = Constant.SOMETHINGWENTWRONG;
                //}
            }

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)result.StatusCode;
            var response = Utility.SerializeObjectValue(result);
            return context.Response.WriteAsync(response);
        }
    }
}
