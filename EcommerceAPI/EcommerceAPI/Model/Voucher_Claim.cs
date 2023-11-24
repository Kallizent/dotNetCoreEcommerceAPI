namespace EcommerceAPI.Model
{
    public class Voucher_Claim
    {
        public int id { get; set; }
        public virtual Voucher voucher { get; set; }
        public DateTime tanggal_Claim { get; set; }
    }
}
