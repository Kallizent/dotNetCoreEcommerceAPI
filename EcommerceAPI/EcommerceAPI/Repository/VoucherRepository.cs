using EcommerceAPI.Data;
using EcommerceAPI.Interface;
using EcommerceAPI.Model;
using EcommerceAPI.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace EcommerceAPI.Repository
{
    public class VoucherRepository : IVoucherRepository
    {
        private readonly DataContext _context;

        public VoucherRepository(DataContext context)
        {
            _context = context;
        }
        public bool CheckIfExist(int id)
        {
            return _context.Vouchers.Any(x => x.status == true && x.id == id);
        }

        public bool CreateVoucher(Voucher voucher)
        {
             _context.Vouchers.Add(voucher);
            return Save();
        }

        public bool DeleteVoucher(Voucher voucher)
        {
            _context.Vouchers.Remove(voucher);
            return Save();
        }

        public Voucher GetById(int id)
        {
            return _context.Vouchers.Where(x => x.id == id ).FirstOrDefault();
        }

        public ICollection<SideKategori> GetSideKategori(bool status)
        {
            return _context.Vouchers.Where(x => x.status == status).GroupBy(x => x.kategori).Select(x => new SideKategori { Kategory = x.FirstOrDefault().kategori, Num = x.Count() }).OrderBy(x => x.Kategory).ToList();
        }

        public ICollection<Voucher> GetVouchersByKategori(string kategori)
        {
            return _context.Vouchers.Where(x => x.kategori == kategori && x.status == true).ToList();
        }
        public ICollection<Voucher> GetVouchers()
        {
            return _context.Vouchers.Where(x => x.status == true).OrderBy(x => x.id).ToList();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateVoucher(Voucher voucher)
        {
            _context.Entry(voucher).State = EntityState.Modified;
            return Save();
        }

        public ICollection<HistoryList> GetVoucherByStatus(bool status)
        {
            return _context.voucher_Claims.Include(x => x.voucher).Where(x => x.voucher.status == status).Select(x => new HistoryList { id = x.voucher.id, nama = x.voucher.nama, tanggal_claim = x.tanggal_Claim.ToString("dd/MM/yyyy")  }).OrderBy(x => x.nama).ToList();
        }
    }
}
