using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using NewBase.Services.Interfaces;
using NewBase.Core.Entities;
using NewBase.Helpers.HelperModels;
using NewBase.Core.Entities.Shared;
using NewBase.Core.Helpers.IO;
using Newtonsoft.Json;
using NewBase.Core.Enums;
using NewBase.Core.Helpers.Security;
using System.Security.Claims;
using NewBase.Core.ExtensionsMethods;
using NewBase.Core.Models;
using NewBase.Core.Helpers.Localization;
using NewBase.Helpers;
using NewBase.Services;
using NewBase.Core.Helpers;
using NewBase.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace NewBase.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    [ValidationError]
    [Route("api/[controller]")]
    public abstract class BaseController : Controller
    {
        public BaseController()
        {
            ProjectTypeService.IsApi = true;

        }
        protected Language Language
        {
            get
            {
                Request.Headers.TryGetValue("Language", out var Lang).ToString();
                var lang = Lang.FirstOrDefault().ToUpper();
                return lang == "AR" ? Language.Ar : Language.En;
            }
        }

        protected string UserId
        {
            get
            {
                //return (JwtManager.GetClaimValue(HttpContext.User.Identity as ClaimsIdentity, "userId").Decrypt() ?? "");
                return HttpContext.User.Claims.FirstOrDefault(x => x.Type == "userId")?.Value.Decrypt()??"";

            }
        }

        protected string UserIdentity
        {
            get
            {
                //return JwtManager.GetClaimValue(HttpContext.User.Identity as ClaimsIdentity, ClaimTypes.NameIdentifier).Decrypt();
                return HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value.Decrypt()??"";
            }
        }


        [NonAction]
        protected OkObjectResult _OK(string successMessage = null)
        {
            return new OkObjectResult(GlobalResponse.Init().Success(null, Localize(successMessage)));
        }

        [NonAction]
        protected OkObjectResult _OK(object data = null, string successMessage = null)
        {
            return new OkObjectResult(GlobalResponse.Init().Success(data, Localize(successMessage)));
            
        }

        [NonAction]
        protected BadRequestObjectResult _BadRequest(string errorMessage = "BadRequest")
        {
            return new BadRequestObjectResult(GlobalResponse.Init().BadRequest(Localize(errorMessage)));
        }
        [NonAction]
        protected string Localize(string key)
        {
            return LocalizerHelper.Localize(key, Language, MyConstants.GeneralLocalizationPath);
        }
    }


    [ApiController]
    [Route("api/[controller]")]
    public abstract class BaseController<TEntity, TListDto, TCreateDto, TUpdateDto> : BaseController where TEntity : Entity
    {
        private readonly IBaseService<TEntity, TListDto, TCreateDto, TUpdateDto> _baseService;

        public BaseController(IBaseService<TEntity, TListDto, TCreateDto, TUpdateDto> baseService)
        {
            _baseService = baseService;
        }


        //[HttpGet("GetAll")]
        //public virtual async Task<IActionResult> GetAll([FromQuery] int pageNumber = 1, [FromQuery] int PageSize = 10)
        //{
        //    return Success(await _baseService.GetListWithPagingAsync(pageNumber, PageSize));
        //}


        //[HttpGet("GetById/{Id}")]
        //public virtual async Task<IActionResult> GetById([FromHeader] long Id)
        //{
        //    return Success(await _baseService.FindAsync(Id));
        //}


        //[HttpPost("Create")]
        //public virtual async Task<IActionResult> Create([FromBody] TCreateDto dto)
        //{
        //    return Success(await _baseService.AddAndCommitAsync(dto), "Item Created Successfully");
        //}


        //[HttpPut("Update")]
        //public virtual async Task<IActionResult> Update([FromBody] TUpdateDto dto)
        //{
        //    return Success(await _baseService.UpdateAndCommitAsync(dto), "Item Updated Successfully");
        //}



        //[HttpDelete("Delete/{id}")]
        //public virtual async Task<IActionResult> Delete(long Id)//[FromHeader]
        //{
        //    return Success(await _baseService.SoftRemoveAndCommitAsync(Id), "Item Deleted Successfully");
        //}


        //[HttpDelete("HardDelete/{id}")]
        //public virtual async Task<IActionResult> HardDelete(long id)
        //{
        //    //var allowed = JsonConvert.DeserializeObject<List<string>>(IOHelper.ReadFile(MyConstants.HardDeletePath));
        //    //if (!allowed.Any(x => x == UserIdentity))
        //    //    throw new BussinessRuleException("NOT ALLOWED!!");

        //    return Success(await _baseService.RemoveAndCommitAsync(id), "Item Deleted Successfully");
        //}

        //protected OkObjectResult Success()
        //{
        //    return new OkObjectResult(new Response().SuccessResult());
        //}

        //protected OkObjectResult Success(object data = null, string successMessage = null)
        //{
        //    return new OkObjectResult(new Response().SuccessResult(data, successMessage));
        //}

        [HttpGet("GetList")]
        public virtual async Task<IActionResult> GetList(string filter = "{'search':null}", [FromQuery] int pageNumber = 1, [FromQuery] int PageSize = 10)
        {
            return _OK(await _baseService.GetListWithPagingAsync(pageNumber, PageSize));
        }

        [HttpGet("GetById/{id}")]
        public virtual async Task<IActionResult> GetById(long id)
        {
            return _OK(await _baseService.FindAsync(id));
        }

        [HttpPost("Create")]
        public virtual async Task<IActionResult> Create([FromBody] TCreateDto dto)
        {
            return _OK(await _baseService.AddAndCommitAsync(dto), Localize("ItemCreatedSuccessfully"));
        }

        [HttpPut("Update")]
        public virtual async Task<IActionResult> Update([FromBody] TUpdateDto dto)
        {
            return _OK(await _baseService.UpdateAndCommitAsync(dto), Localize("ItemUpdatedSuccessfully"));
        }

        [HttpDelete("Delete/{id}")]
        public virtual async Task<IActionResult> Delete(long id)
        {
            return _OK(await _baseService.SoftRemoveAndCommitAsync(id), Localize("ItemDeletedSuccessfully"));
        }

        [HttpDelete("HardDelete/{id}")]
        public virtual async Task<IActionResult> HardDelete(long id)
        {
            var allowed = JsonConvert.DeserializeObject<List<string>>(IOHelper.ReadFile(MyConstants.HardDeletePath));
            if (!allowed.Any(x => x == UserIdentity))
                throw new BussinessRuleException("NOT ALLOWED!!");

            return _OK(await _baseService.RemoveAndCommitAsync(id), Localize("ItemDeletedSuccessfully"));
        }

    }
}
