namespace EcommerceAPI.ViewModel
{
    public class HistoryList
    {
        public int id { get; set; }
        public string nama { get; set; }
        public string tanggal_claim { get; set; }

    }
    public class VoucherClaimVM 
    {
        public int id { get; set; }
        public int VoucherId { get; set; }
        public DateTime Tanggal_Claim { get; set; }
    }
}
