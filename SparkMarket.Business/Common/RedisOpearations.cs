using Newtonsoft.Json;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparkMarket.Business.Common
{
    public static class RedisOpearations
    {
        static readonly ConnectionMultiplexer redis;
        static RedisOpearations()
        {
            string host = "127.0.0.1";
            int port = 6379;
            var configurationOptions = new ConfigurationOptions
            {
                EndPoints =
                    {
                        {host, port }
                    },
                KeepAlive = 180,
                DefaultDatabase = 1,
                AbortOnConnectFail = false,
                SyncTimeout = 15000,
                //AllowAdmin = true
            };
            redis = ConnectionMultiplexer.Connect(configurationOptions);
        }

        public static void SetObject<T>(
         string cacheKey,
         T _object,
         int timeoutsecond)
        {

            try
            {

                JsonSerializerSettings serializerSettings = new JsonSerializerSettings();
                //serializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                serializerSettings.MaxDepth = 4;


                var jsonData = CompressString(JsonConvert.SerializeObject(_object, serializerSettings));



                var db = redis.GetDatabase(2);
                if (timeoutsecond == 0)
                    db.StringSet(cacheKey, jsonData);
                else
                    db.StringSet(cacheKey, jsonData, TimeSpan.FromSeconds(timeoutsecond));

            }
            catch { }

        }

        public static T GetObjectRedisCache<T>(string cacheKey)
        {

            try
            {
                var db = redis.GetDatabase(2);

                string jsonData = DecompressString(db.StringGet(cacheKey));
                if (jsonData == null) return default(T);
                return JsonConvert.DeserializeObject<T>(jsonData);
            }
            catch
            {
                return default(T);
            }

        }


        static byte[] CompressString(string input)
        {
            if (input == null)
            {
                return null;
            }
            using (var outputStream = new MemoryStream())
            {
                using (var gzipStream = new GZipStream(outputStream, CompressionMode.Compress))
                using (var writer = new StreamWriter(gzipStream))
                {
                    writer.Write(input);
                }
                return outputStream.ToArray();
            }
        }

        static string DecompressString(byte[] inputBytes)
        {
            if (inputBytes == null)
            {
                return null;
            }

            using (var inputStream = new MemoryStream(inputBytes))
            using (var gzipStream = new GZipStream(inputStream, CompressionMode.Decompress))
            using (var reader = new StreamReader(gzipStream))
            {
                return reader.ReadToEnd();
            }
        }




    }
}
