using EcommerceAPI.Data;
using EcommerceAPI.Interface;
using EcommerceAPI.Model;
using EcommerceAPI.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace EcommerceAPI.Repository
{
    public class Voucher_ClaimRepository : IVoucher_ClaimRepository
    {
        private readonly DataContext _context;

        public Voucher_ClaimRepository(DataContext context)
        {
            _context = context;
        }
        public bool CreateVoucher_Claim(Voucher_Claim voucher_Claim)
        {
            _context.voucher_Claims.Add(voucher_Claim);
            return Save();
        }

        public bool DeleteVoucher_Claim(Voucher_Claim voucher_Claim)
        {
             _context.voucher_Claims.Remove(voucher_Claim);
            return Save();
        }

        public VoucherClaimVM GetVoucher_Claim(int id)
        {
            return _context.voucher_Claims.Include(x => x.voucher).Where(x => x.id == id).Select(x => new VoucherClaimVM { id = x.id, Tanggal_Claim = x.tanggal_Claim, VoucherId = x.voucher.id }).FirstOrDefault();
        }

        public Voucher_Claim GetVoucher_ClaimByVoucherId(int VoucherId)
        {
            return _context.voucher_Claims.Include(x => x.voucher).Where(x => x.voucher.id == VoucherId).FirstOrDefault(); 
        }

        public ICollection<VoucherClaimVM> GetVoucher_Claims()
        {
            return _context.voucher_Claims.Include(x => x.voucher).Select(x => new VoucherClaimVM { id = x.id, Tanggal_Claim = x.tanggal_Claim, VoucherId = x.voucher.id }).OrderBy(x => x.id).ToList();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
