﻿using DotNetClub.Core.Service;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DotNetClub.Web.ViewComponents
{
    public class UserOtherTopicsPanelViewComponent : ViewComponent
    {
        private TopicService TopicService { get; set; }

        public UserOtherTopicsPanelViewComponent(TopicService topicService)
        {
            this.TopicService = topicService;
        }

        public async Task<IViewComponentResult> InvokeAsync(long userID, int count, params long[] exclude)
        {
            var topicList = await this.TopicService.QueryByUser(userID, count, exclude);

            return this.View(topicList);
        }
    }
}
