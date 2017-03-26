using AutoMapper;
using DotNetClub.Core.Model.Topic;
using DotNetClub.Core.Model.User;
using DotNetClub.Domain.Entity;

namespace DotNetClub.Core
{
    /// <summary>
    /// AutoMapper配置
    /// </summary>
    public sealed class AutoMapperConfig
    {
        public static void Configure()
        {
            Mapper.Initialize(configuration =>
            {
                configuration.CreateMap<User, UserBasicModel>();
                configuration.CreateMap<User, UserModel>();
                configuration.CreateMap<Topic, TopicModel>();
                configuration.CreateMap<Topic, TopicBasicModel>();
            });
        }
    }
}
