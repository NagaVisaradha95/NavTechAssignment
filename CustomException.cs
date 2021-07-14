using System;

public class CustomException:Exception
{
    
    public CustomException(ResponseMessage responseMessage) : base(responseMessage)
    {
        Description = "Postman mock api exception";
    }
}
