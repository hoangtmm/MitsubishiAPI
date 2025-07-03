using Microsoft.AspNetCore.Mvc;
using Misubishi.BLL.Services;
using Misubishi.DAL.DTO;

[Route("api/[controller]")]
[ApiController]
public class QuickQuoteController : ControllerBase
{
    private readonly EmailService _emailService;

    public QuickQuoteController(EmailService emailService)
    {
        _emailService = emailService;
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] QuickQuoteDto dto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            await _emailService.SendLeadEmail(
                toEmail: "hoangtm06@gmail.com",
                fullName: dto.FullName,
                phone: dto.Phone,
                carModel: dto.CarModel
            );

            return Ok(new { message = "Đã gửi báo giá thành công" });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "Gửi email thất bại", error = ex.Message });
        }
    }
}
