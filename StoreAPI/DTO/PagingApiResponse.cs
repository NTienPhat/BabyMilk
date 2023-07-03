using System.Net;

namespace StoreAPI.DTO
{
    public class PagingApiResponse
    {
        public PagingApiResponse()
        {
            ErrorMessages = new List<string>();
        }

        public HttpStatusCode StatusCode { get; set; }
        public bool IsSuccess { get; set; } = true;
        public List<string> ErrorMessages { get; set; }
        public int total { get; set; }
        public int pageNum { get; set; }
        public object Result { get; set; }
        
    }
}
