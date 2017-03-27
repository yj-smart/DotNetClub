using DotNetClub.Core.Model.Topic;
using DotNetClub.Domain.Model;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace DotNetClub.Web.ViewModels.Home
{
    public class IndexViewModel
    {
        public PagedResult<TopicModel> TopicList { get; set; }

        public List<SelectListItem> TabList { get; set; }

        public string Tab { get; set; }
    }
}
