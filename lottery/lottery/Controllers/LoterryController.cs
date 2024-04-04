using lottery.Application.DTOS;
using lottery.Application.InterfaceLotteryUseCase;
using lottery.Application.LotteryUseCaseImpl;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace lottery.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoterryController : ControllerBase
    {
        private readonly ILotteryProductUseCase _lotteryProductUseCase;
        private readonly ILotteryTicketUseCase _lotteryTicketUseCase;
        public LoterryController(ILotteryProductUseCase lotteryProductUseCase, ILotteryTicketUseCase lotteryTicketUseCase)
        {
            _lotteryProductUseCase = lotteryProductUseCase;
            _lotteryTicketUseCase = lotteryTicketUseCase;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var eventDtos = await _lotteryProductUseCase.GetProductList();
            return Ok(eventDtos);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] ProductDto request)
        {
            try
            {
                _lotteryProductUseCase.AddProdct(request);
                
                return Ok(); // Devuelve un 200 OK si la operación fue exitosa
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message); // Devuelve un 500 Internal Server Error si hay una excepción
            }
        }


        [HttpPost("{idProduct}")]
        public async Task<IActionResult> AddTicket( int idProduct)
        {
            try
            {
                
                
                return Ok(_lotteryTicketUseCase.AddTicket(idProduct)); // Devuelve un 200 OK si la operación fue exitosa
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message); // Devuelve un 500 Internal Server Error si hay una excepción
            }
        }
    }
}
