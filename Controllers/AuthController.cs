using Microsoft.AspNetCore.Mvc;
using Ecommerece.Data;
using Ecommerece.Models;
using Microsoft.EntityFrameworkCore;

namespace Ecommerece.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AuthController(AppDbContext context)
        {
            _context = context;
        }

        // POST: api/auth/send-otp
        [HttpPost("send-otp")]
        public async Task<IActionResult> SendOtp(
            SendOtpRequest request)
        {
            if (string.IsNullOrEmpty(request.MobileNumber))
                return BadRequest("Mobile number is required");

            // Generate random 4-digit OTP
            var otp = new Random()
                .Next(1000, 9999)
                .ToString();

            var user = await _context.Users
                .FirstOrDefaultAsync(x =>
                    x.MobileNumber ==
                    request.MobileNumber);

            if (user == null)
            {
                user = new User
                {
                    MobileNumber =
                        request.MobileNumber,
                    Otp = otp,
                    IsVerified = false,
                    CreatedDate = DateTime.Now
                };

                _context.Users.Add(user);
            }
            else
            {
                user.Otp = otp;
                user.IsVerified = false;
            }

            await _context.SaveChangesAsync();

            return Ok(new
            {
                message = "OTP sent successfully",
                otp = otp
            });
        }

        // POST: api/auth/verify-otp
        [HttpPost("verify-otp")]
        public async Task<IActionResult> VerifyOtp(
            VerifyOtpRequest request)
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(x =>
                    x.MobileNumber ==
                    request.MobileNumber);

            if (user == null)
                return NotFound("User not found");

            if (user.Otp != request.Otp)
                return BadRequest("Invalid OTP");

            user.IsVerified = true;

            await _context.SaveChangesAsync();

            return Ok("Login successful");
        }
    }
}