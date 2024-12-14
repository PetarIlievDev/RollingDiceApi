namespace RollingDiceApi.Controllers
{
    using System.Security.Claims;
    using AutoMapper;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using RollingDiceApi.Models;
    using RollingDiceApi.Models.RollDice;
    using RollingDiceApi.Services.Interfaces;
    using RollingDiceApi.Services.Models.RollDice;
    using RollingDiceApi.Services.Models.RolledDiceGetData;

    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class RollDiceController(IMapper mapper, IRollDiceService rollDiceService) : Controller
    {

        [HttpGet]
        public async Task<IActionResult> GetAsync([FromQuery] RolledDiceGetDataRequest rolledDiceGetDataRequest, CancellationToken ct)
        {
            ResponseModel<RolledDiceGetDataServiceResponse> response = new();

            try
            {
                var claim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email);
                var serviceRequest = mapper.Map<RolledDiceGetDataServiceRequest>(rolledDiceGetDataRequest);
                serviceRequest.Email = claim?.Value ?? throw new Exception("Email not found");
                var result = await rollDiceService.GetRolledDiceDataAsync(serviceRequest, ct);

                response.Status = true;
                response.Message = "success";
                response.Data = result;
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = ex.Message;
                return BadRequest(response);
            }
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(CancellationToken ct)
        {
            ResponseModel<RollDiceServiceResponse> response = new();

            try
            {
                var claim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email);
                var serviceRequest = new RollDiceServiceRequest
                {
                    Email = claim?.Value ?? throw new Exception("Email not found")
                };

                var result = await rollDiceService.RollDiceAsync(serviceRequest, ct);

                response.Status = true;
                response.Message = "success";
                response.Data = result;
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = ex.Message;
                return BadRequest(response);
            }
        }
    }
}
