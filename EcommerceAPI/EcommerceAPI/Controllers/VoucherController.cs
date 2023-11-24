using EcommerceAPI.Interface;
using EcommerceAPI.Model;
using EcommerceAPI.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VoucherController : ControllerBase
    {
        private readonly IVoucherRepository _voucherRepository;
        private readonly IVoucher_ClaimRepository _voucher_ClaimRepository;

        public VoucherController(IVoucherRepository voucherRepository,IVoucher_ClaimRepository voucher_ClaimRepository)
        {
            _voucherRepository = voucherRepository;
            _voucher_ClaimRepository = voucher_ClaimRepository;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Voucher>))]
        public IActionResult GetVouchers() 
        {
        
            var voucher = _voucherRepository.GetVouchers();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(voucher);
        }

        [HttpGet("GetKategoriesList")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<SideKategori>))]
        public IActionResult GetKategories() 
        {
            var kategories = _voucherRepository.GetSideKategori(true);
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(kategories);
        }

        [HttpGet("GetClaimKategoriesList")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<SideKategori>))]
        public IActionResult GetClaimKategories()
        {
            var kategories = _voucherRepository.GetSideKategori(false);
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(kategories);
        }

        [HttpGet("GetByKategori")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Voucher>))]
        public IActionResult GetVouchersByKategori(string kategori) 
        {
            var vouchers = _voucherRepository.GetVouchersByKategori(kategori);
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(vouchers);
        }
        
        [HttpPut("UpdateVoucher")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public IActionResult ClaimVoucher(int id) 
        {
            Response result = new Response();
            
            if (!_voucherRepository.CheckIfExist(id))
            {
                result.message = "Data Tidak ada";
                result.status = "error";
                result.success = false;
                //ModelState.AddModelError("", "data tidak ada");
                //return StatusCode(500, ModelState);
                return Ok(result);
            }

            var GetVoucher = _voucherRepository.GetById(id);

            GetVoucher.status = false;

            if (!_voucherRepository.UpdateVoucher(GetVoucher))
            {
                result.message = "ada yang salah pada proses Claim Voucher";
                result.status = "error";
                result.success = false;
                return Ok(result);
                //ModelState.AddModelError("", "ada yang salah pada proses Claim Voucher");
                //return StatusCode(500, ModelState);
            }

            Voucher_Claim data = new Voucher_Claim();
            data.tanggal_Claim = DateTime.Now;
            data.voucher = GetVoucher;

            if (!_voucher_ClaimRepository.CreateVoucher_Claim(data))
            {
                result.message = "ada yang salah pada proses simpan data";
                result.status = "error";
                result.success = false;
                return Ok(result);
                //ModelState.AddModelError("", "ada yang salah pada proses simpan data");
                //return StatusCode(500, ModelState);
            }

            result.message = "proses berhasil";
            result.status = "ok";
            result.success = true;
            return Ok(result);
        }

        [HttpGet("GetVoucherHistory")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<HistoryList>))]
        public IActionResult GetHistoryVouchersList()
        {
            var GetVouchers = _voucherRepository.GetVoucherByStatus(false);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(GetVouchers);
        }
    }
}
