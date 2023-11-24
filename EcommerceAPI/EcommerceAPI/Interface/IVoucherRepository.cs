using EcommerceAPI.Model;
using EcommerceAPI.ViewModel;

namespace EcommerceAPI.Interface
{
    public interface IVoucherRepository
    {
        ICollection<Voucher> GetVouchers();
        Voucher GetById(int id);
        ICollection<SideKategori> GetSideKategori(bool status);
        ICollection<Voucher> GetVouchersByKategori(string kategori);
        ICollection<HistoryList> GetVoucherByStatus(bool status);

        //Voucher GetVoucherByUsername(string Username);
        bool CheckIfExist(int id);
        bool CreateVoucher(Voucher voucher);
        bool UpdateVoucher(Voucher voucher);
        bool DeleteVoucher(Voucher voucher);

        bool Save();
    }
}
