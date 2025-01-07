namespace Crowdfunding.Application.Models
{
    public class ResponseData<T>: Response
    {
        public T Data { get; set; }
        public ResponseData(T data)
        {
            this.Data = data;
        }

        public ResponseData(bool isSuccess,string message) {
            this.IsSuccess = isSuccess;
            this.Message = message; 
        }

        
    }
}
