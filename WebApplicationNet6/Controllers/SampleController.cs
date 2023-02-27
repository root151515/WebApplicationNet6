using Microsoft.AspNetCore.Mvc;
using System.Data;
using WebApplicationNet6.Class;
using WebApplicationNet6.Interface;
using WebApplicationNet6.Service;

namespace WebApplicationNet6.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SampleController : ControllerBase
    {
        private readonly IScoped _scoped;
        private readonly ISingleton _singleton;
        private readonly ITransient _transient;
        private readonly SampleService _sampleService;

        /// <summary>
        /// 建構子
        /// </summary>
        /// <param name="scoped"></param>
        /// <param name="singleton"></param>
        /// <param name="transient"></param>
        public SampleController(IScoped scoped, ISingleton singleton, ITransient transient, SampleService sampleService) 
        {
            _scoped = scoped;
            _singleton = singleton;
            _transient = transient;
            _sampleService = sampleService;

        }

        [HttpGet]
        public IActionResult GetTwoWayHashCode()
        {

            var controllerHashCode = new SampleClass()
            {
                SampleScoped = _scoped.GetHashCode(),
                SampleSingleton = _singleton.GetHashCode(),
                SampleTransient = _transient.GetHashCode(),
            };

            return Ok(new
            {
                ControllerHashCode = controllerHashCode,
                SerivceHashCode = _sampleService.GetSampleServiceHashCode(),
            });
        }

        [HttpGet("GetUserInfoAndData")]
        public IActionResult GetUserInfoAndData()
        {
            return Ok(_sampleService.GetUserInfoAndData());
        }

        [HttpGet("GetUserInfoAndDataInterpolated/{Id}")]
        public IActionResult GetUserInfoAndDataInterpolated(Guid Id)
        {
            return Ok(_sampleService.GetUserInfoAndDataByInterpolated(Id));
        }
    }
}
