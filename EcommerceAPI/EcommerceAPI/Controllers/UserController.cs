using EcommerceAPI.Interface;
using EcommerceAPI.Model;
using EcommerceAPI.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<User>))]
        public IActionResult GetUsers() 
        {
            var Users = _userRepository.GetUsers();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(Users);
        }

        [HttpPost("Login")]
        [ProducesResponseType(200, Type = typeof(UserVM))]

        public IActionResult CheckLogin([FromBody] UserLogin userLogin ) 
        {
            Response result = new Response();

            var GetUser = _userRepository.GetUserByUsername(userLogin.username);

            if(GetUser == null)
            {
                
                result.message = "Username anda tidak ditemukan";
                result.status = "error";
                result.success = false;
                //ModelState.AddModelError("", "data tidak ada");
                //return StatusCode(500, ModelState);
                return Ok(result);
            }

            if(GetUser.password != userLogin.password)
            {
                
                result.message = "Password anda salah";
                result.status = "error";
                result.success = false;
                //ModelState.AddModelError("", "data tidak ada");
                //return StatusCode(500, ModelState);
                return Ok(result);
            }
            GetUser.password = null;
            result.message = "Login berhasil";
            result.status = "success";
            result.success = false;
            result.data = GetUser;
            return Ok(result);
        }

        [HttpPost("Register")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult RegisterData([FromBody] Register register) 
        {
            RegisterResponse result = new RegisterResponse();




            var GetUser = _userRepository.GetUserByUsername(register.username);
            if(GetUser != null)
            {
                
                result.message = "Username Sudah ada";
                result.status = "error";
                result.success = false;
                return Ok(result);
            }

            User user = new User();
            user.username = register.username;
            user.password = register.password;
            user.email = register.email;
            user.nama = register.name;
            user.tanggal_daftar = DateTime.Now;


                

            if (!_userRepository.CreateUser(user))
            {
                
                result.message = "ada yang salah pada proses simpan data";
                result.status = "error";
                result.success = false;
                return Ok(result);
            }

            result.message = "Register Berhasil";
            result.status = "success";
            result.success = false;
            
            return Ok(result);
        }

    }
 }

