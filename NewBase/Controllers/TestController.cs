using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewBase.Services;

namespace NewBase.Controllers
{

    public class TestController : BaseController
    {
        [HttpGet]
        public IActionResult TestApi()
        {
            var x = System.Reflection.Assembly.GetEntryAssembly().GetName().Name;
            var lang = Language.ToString();

            var ss = ProjectTypeService.IsApi;

            return Ok("test");
        }
    }
}
