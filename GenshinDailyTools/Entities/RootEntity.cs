using System;
using System.Threading;
using System.Threading.Tasks;
using GenshinDailyTools.Exception;
using Newtonsoft.Json;

namespace GenshinDailyTools.Entities
{
    /// <summary>
    /// 返回头部信息
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class RootEntity<T>
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("retcode")]
        public int Retcode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("message")]
        public string Message { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("data")]
        public T Data { get; set; } = Activator.CreateInstance<T>();

        /// <summary>
        /// 判断返回码并延迟
        /// </summary>
        /// <returns></returns>
        public string CheckOutCodeAndSleep()
        {
            Task.Delay(3 * 1000).Wait();

            return Retcode switch
            {
                0 => "执行成功",
                -5003 => $"{Message}",
                _ => throw new GenShinException($"请求异常{Message}")
            };
        }

        public override string ToString()
        {
            return $"返回码为{Retcode}";
        }
    }
}
