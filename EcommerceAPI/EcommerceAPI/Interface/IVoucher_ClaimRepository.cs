using EcommerceAPI.Model;
using EcommerceAPI.ViewModel;

namespace EcommerceAPI.Interface
{
    public interface IVoucher_ClaimRepository
    {

        ICollection<VoucherClaimVM> GetVoucher_Claims();
        VoucherClaimVM GetVoucher_Claim(int id);
        Voucher_Claim GetVoucher_ClaimByVoucherId(int VoucherId);
        bool CreateVoucher_Claim(Voucher_Claim voucher_Claim);
        bool DeleteVoucher_Claim(Voucher_Claim voucher_Claim);
        bool Save();

    }
}
