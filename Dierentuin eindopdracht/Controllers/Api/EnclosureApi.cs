using Dierentuin_eindopdracht.Models;
using Dierentuin_eindopdracht.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Dierentuin_eindopdracht.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnclosureApi : ControllerBase
    {
        private readonly EnclosureService _enclosureService;

        public EnclosureApi(EnclosureService enclosureService)
        {
            this._enclosureService = enclosureService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Enclosure>> Get()
        {
            var enclosures = _enclosureService.GetEnclosures();
            return Ok(enclosures);
        }
    }
}
