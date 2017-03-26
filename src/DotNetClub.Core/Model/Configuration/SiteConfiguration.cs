namespace DotNetClub.Core.Model.Configuration
{
    /// <summary>
    /// 网站配置
    /// </summary>
    public class SiteConfiguration
    {
        /// <summary>
        /// 主机
        /// </summary>
        public string Host { get; set; }

        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; set; }
        
        /// <summary>
        /// 管理员账户集合
        /// </summary>
        public string[] AdminUserList { get; set; }

        /// <summary>
        /// 是否允许注册
        /// </summary>
        public bool AllowRegister { get; set; }

        /// <summary>
        /// 是否已验证注册用户
        /// </summary>
        public bool VerifyRegisterUser { get; set; }
    }
}
