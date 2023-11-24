using System.ComponentModel.DataAnnotations;

namespace EcommerceAPI.Model
{
    public class User
    {
        public int id { get; set; }
        [MaxLength(50),MinLength(5)]
        public string username { get; set; }
        [MaxLength(50), MinLength(5)]
        public string password { get; set; }
        [MaxLength(50)]
        public string email { get; set; }
        [MaxLength(50)]
        public string nama { get; set; }
        public DateTime tanggal_daftar { get; set; }
    }
}
