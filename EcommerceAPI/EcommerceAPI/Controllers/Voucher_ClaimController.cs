using EcommerceAPI.Interface;
using EcommerceAPI.Model;
using EcommerceAPI.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Voucher_ClaimController : ControllerBase
    {
        private readonly IVoucher_ClaimRepository _voucher_ClaimRepository;
        private readonly IVoucherRepository _voucherRepository;

        public Voucher_ClaimController(IVoucher_ClaimRepository voucher_ClaimRepository, IVoucherRepository voucherRepository)
        {
            _voucher_ClaimRepository = voucher_ClaimRepository;
            _voucherRepository = voucherRepository;
        }
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Voucher_Claim>))]
        public IActionResult GetVoucherClaims()
        {
            var voucherClaim = _voucher_ClaimRepository.GetVoucher_Claims();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(voucherClaim);
        }

        [HttpGet("GetVoucherClaim")]
        [ProducesResponseType(200, Type = typeof(VoucherClaimVM))]
        public IActionResult GetVoucherClaim(int id)
        {
            var claims = _voucher_ClaimRepository.GetVoucher_Claim(id);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(claims);
        }

        [HttpDelete("DeleteVoucherClaim")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public IActionResult DeleteVoucherClaim(int id) 
        {
            Response result = new Response();
            if (_voucherRepository.CheckIfExist(id))
            {
                result.message = "Data Tidak ada";
                result.status = "error";
                result.success = false;
                //ModelState.AddModelError("", "data tidak ada");
                //return StatusCode(500, ModelState);
                return Ok(result);
            }
                

            var voucherClaim = _voucher_ClaimRepository.GetVoucher_ClaimByVoucherId(id);

            if (voucherClaim == null)
            {
                
                result.message = "Voucher tidak ada";
                result.status = "error";
                result.success = false;
                return Ok(result);
            }

            if (!_voucher_ClaimRepository.DeleteVoucher_Claim(voucherClaim))
            {
                
                result.message = "ada yang salah pada proses delete voucher claim";
                result.status = "error";
                result.success = false;
                return Ok(result);
            }

            var voucher = _voucherRepository.GetById(id);
            voucher.status = true;

            if (!_voucherRepository.UpdateVoucher(voucher))
            {

                result.message = "ada yang salah pada proses Update voucher";
                result.status = "error";
                result.success = false;
                return Ok(result);
            }

            result.message = "proses berhasil";
            result.status = "ok";
            result.success = true;
            return Ok(result);
        }

    }
}
