using DotNetClub.Core.Model.Comment;
using DotNetClub.Core.Model.Topic;
using System.Collections.Generic;

namespace DotNetClub.Web.ViewModels.Topic
{
    public class IndexViewModel
    {
        public TopicModel Topic { get; set; }

        public List<CommentModel> CommentList { get; set; }

        public bool CanOperate { get; set; }

        public bool IsCollected { get; set; }
    }
}
