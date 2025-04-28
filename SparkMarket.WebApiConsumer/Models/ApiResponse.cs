namespace SparkMarket.WebApiConsumer.Models
{
    public class ApiResponse<T>
    {
        public bool success { get; set; }
        public string HataMesaji { get; set; }
        public T Data { get; set; }


        public ApiResponse()
        {

        }

        public ApiResponse(bool success, string HataMesaji, T Data)
        {
            this.success = success;
            this.HataMesaji = HataMesaji;
            this.Data = Data;
        }
    }
}
