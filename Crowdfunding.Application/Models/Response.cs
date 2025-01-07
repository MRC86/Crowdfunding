namespace Crowdfunding.Application.Models
{
    public class Response
    {
        public int Code { get; set; } = 200;
        public String Message { get; set; } = "";
        public bool IsSuccess { get; set; } = true;

        public Response() { }
        public Response(int code, bool isSuccess, String message)
        {
            this.Code = code;
            this.Message = message;
            this.IsSuccess = isSuccess;
        }

        public Response(bool isSuccess, string message)
        {
            this.IsSuccess = isSuccess;
            this.Message = message;
        }
        public Response(string message) {  this.Message = message; }
    }
}
