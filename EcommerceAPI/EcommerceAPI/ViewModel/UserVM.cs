using System.ComponentModel.DataAnnotations;

namespace EcommerceAPI.ViewModel
{
    public class UserLogin
    {
        public string username { get; set; }
        public string password { get; set; }
    }
    public class UserVM 
    {
        public string username { get; set; }
        public string password { get; set; }
        public string nama { get; set; }
    }
    public class Register 
    {
        [MinLength(5)]
        public string username { get; set; }
        [MinLength(5)]
        public string password { get; set; }
        [MinLength(3)]
        public string name { get; set; }
        [EmailAddress]
        public string email { get; set; }
    }
}
