using DotNetClub.Core.Model.Topic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DotNetClub.Web.ViewModels.Topic
{
    public class PostViewModel
    {
        public SelectList CategoryList { get; set; }

        public SaveTopicModel Model { get; set; }

        public bool IsNew { get; set; }
    }
}
