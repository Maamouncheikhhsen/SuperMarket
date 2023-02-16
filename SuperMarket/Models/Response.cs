namespace _Eaton_IMRSYS_Kernel.Models
{
    public class Response
    {
        public Response() {
            data = null;
        }
        public string Message { get; set; }
        public int Status { get; set; }
        public object data { get; set; }

    }
}
