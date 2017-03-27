using Microsoft.AspNetCore.Mvc;

namespace DotNetClub.Web.ViewComponents
{
    public class NewTopicPanelViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return this.View();
        }
    }
}
