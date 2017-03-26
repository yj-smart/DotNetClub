using Microsoft.Extensions.Options;
using StackExchange.Redis;
using System;
using System.Linq;
using System.Net;

namespace DotNetClub.Core.Redis
{
    /// <summary>
    /// Redis提供程序
    /// </summary>
    public sealed class RedisProvider : IRedisProvider, IDisposable
    {
        private static readonly object _sync = new object();

        private ConnectionMultiplexer _pool;

        private IOptions<RedisOptions> RedisOptions { get; set; }

        private ConnectionMultiplexer Pool
        {
            get
            {
                if (_pool == null)
                {
                    lock (_sync)
                    {
                        if (_pool == null)
                        {
                            Connect();
                        }
                    }
                }

                return _pool;
            }
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="redisOptions"></param>
        public RedisProvider(IOptions<RedisOptions> redisOptions)
        {
            RedisOptions = redisOptions;
        }

        /// <summary>
        /// 销毁
        /// </summary>
        public void Dispose()
        {
            if (Pool != null)
            {
                Pool.Dispose();
            }
        }

        /// <summary>
        /// 获取数据库
        /// </summary>
        /// <param name="db"></param>
        /// <returns></returns>
        public IDatabase GetDatabase(int? db = -1)
        {
            return Pool.GetDatabase(db ?? -1);
        }

        /// <summary>
        /// 获取服务器
        /// </summary>
        /// <param name="endPoint"></param>
        /// <returns></returns>
        public IServer GetServer(EndPoint endPoint = null)
        {
            if (endPoint == null)
            {
                endPoint = Pool.GetEndPoints().First();
            }

            return Pool.GetServer(endPoint);
        }

        /// <summary>
        /// 连接
        /// </summary>
        private void Connect()
        {
            var configuration = new ConfigurationOptions
            {
                Password = RedisOptions.Value.Password,
                DefaultDatabase = RedisOptions.Value.Db
            };
            foreach (string endPoint in RedisOptions.Value.EndPoints)
            {
                configuration.EndPoints.Add(EndPointCollection.TryParse(endPoint));
            }

            _pool = ConnectionMultiplexer.Connect(configuration);
        }

        /// <summary>
        /// 获取选项
        /// </summary>
        /// <returns></returns>
        public RedisOptions GetOptions()
        {
            return RedisOptions.Value;
        }
    }
}
