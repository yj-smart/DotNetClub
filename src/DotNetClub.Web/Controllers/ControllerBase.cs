using DotNetClub.Core.Security;
using DotNetClub.Web.ViewModels.Notice;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DotNetClub.Web.Controllers
{
    public class ControllerBase : Controller
    {
        protected SecurityManager SecurityManager
        {
            get
            {
                return this.HttpContext.RequestServices.GetService<SecurityManager>();
            }
        }

        protected virtual IActionResult Notice(NoticeViewModel vm)
        {
            return this.View("_Notice", vm);
        }

        protected virtual IActionResult Notice(string message)
        {
            var vm = new NoticeViewModel(message);
            return this.Notice(vm);
        }

        protected new IActionResult Forbid()
        {
            return this.Notice("无权操作");
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var configuration = context.HttpContext.RequestServices.GetService<IConfiguration>();
            ViewBag.Keywords = configuration["SiteKeywords"];
            ViewBag.Description = configuration["SiteDescription"];

            base.OnActionExecuting(context);
        }
    }
}
