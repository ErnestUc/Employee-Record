namespace employeeRecord.Responsess
{                        //configure the ServiceResponse class to accept a generic type
    public class ServiceResponse<T> where T : class
    {                                   //specifying what to return
        public T Data { set; get; }
        public int StatusCode { set; get; }
        public bool Success { set; get; }
        public string Message { set; get; }


    }
}
