namespace ES.Services.DataTransferObjects.Response
{
    public class BaseResponse
    {
        public short ServiceResponseStatus { get; set; }

        public string ErrorMessage { get; set; }

        public int ErrorCode { get; set; }
    } 
}