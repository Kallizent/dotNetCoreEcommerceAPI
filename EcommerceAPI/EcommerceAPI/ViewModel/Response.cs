namespace EcommerceAPI.ViewModel
{
    public class Response
    {
        public string status { get; set; }
        public bool success { get; set; }
        public string message { get; set; }
        public object data { get; set; }
    }
    public class RegisterResponse :Response 
    {
        public List<FormMessage> MessageList { get; set; }
    }
    public class FormMessage 
    {
        public string Column { get; set; }
        public string Message { get; set; }
    }
}
