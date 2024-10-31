using Api.Models;
using Api.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Numerics;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SmartPhoneController : ControllerBase
    {
        ISmartPhone _info;

        private readonly ILogger<SmartPhoneController> _logger;

        public SmartPhoneController(ILogger<SmartPhoneController> logger, ISmartPhone info)
        {
            _info = info;
            _logger = logger;
        }

        [HttpGet("ListOFAllObjects")]
        [Authorize]
        public async Task<IEnumerable<Phone>?> ListOFAllObjects()
        {
            return await _info.ListOFAllObjects();
        }

        [HttpPost("ListOfObjectsByIds")]
        public async Task<IEnumerable<Phone>?> ListOfObjectsByIds(List<string> list)
        {
            return await _info.ListOfObjectsByIds(list);
        }

        [HttpGet("SingleObject")]
        public async Task<Phone?> SingleObject(string Id)
        {
            return await _info.SingleObject(Id);
        }

        [HttpPost("AddObject")]
        public async Task<Phone?> AddObject(Phone phone)
        {
            return await _info.AddObject(phone);
        }

        [HttpPut("UpdateObject")]
        public async Task<Phone?> UpdateObject(Phone phone)
        {
            return await _info.UpdateObject(phone);
        }

        [HttpDelete("DeleteObject")]
        public async Task<Dictionary<string, string>?> DeleteObject(string Id)
        {
            return await _info.DeleteObject(Id);
        }
    }
}
