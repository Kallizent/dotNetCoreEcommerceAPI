using System.ComponentModel.DataAnnotations;

namespace EcommerceAPI.Model
{
    public class Voucher
    {
        public int id { get; set; }
        [MaxLength(50), MinLength(5)]
        public string nama { get; set; }
        public string foto { get; set; }
        [MaxLength(25), MinLength(5)]
        public string kategori { get; set; }
        public bool status { get; set; }
    }
}
