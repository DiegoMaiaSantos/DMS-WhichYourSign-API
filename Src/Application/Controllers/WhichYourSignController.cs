using DMS_WhichYourSign_API.Src.Application.Errors;
using DMS_WhichYourSign_API.Src.Domain.DTOs;
using DMS_WhichYourSign_API.Src.Domain.Interfaces.Services;
using DMS_WhichYourSign_API.Src.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace DMS_WhichYourSign_API.Src.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WhichYourSignController : ControllerBase
    {
        private readonly IWhichYourSignService _whichYourSignService;

        public WhichYourSignController(IWhichYourSignService whichYourSignService)
        {
            _whichYourSignService = whichYourSignService;
        }

        /// <summary>
        /// Realiza a busca do signo, utilizando da data de nascimento informada.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetYourSign([FromQuery] WhichYourSignModel model)
        {            
            try
            {
                WhichYourSignResponseDTO responseDTO = _whichYourSignService.ValidationOfReceivedData(model);

                return Ok(responseDTO);
            }
            catch (AppException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
