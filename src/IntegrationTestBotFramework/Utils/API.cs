using System;
using System.Text;
using System.Net;
using Newtonsoft.Json;

namespace IntegrationTestBotFramework.Utils
{
    public class API
    {
        /// <summary>
        /// Uploads to an URL and gets result
        /// </summary>
        /// <typeparam name="T">Type of object you are receiving</typeparam>
        /// <param name="bearer">Token</param>
        /// <param name="url">Url</param>
        /// <param name="serializedJson">Serialized JSON to send</param>
        /// <returns></returns>
        public static T uploadString<T>(string bearer, string url, string serializedJson)
        {
            string serializedResult = "";

            /// Webclient
            using (var client = new WebClient())
            {
                /// Looks like it goes wrong when uplading UTF8 words

                try
                {
                    /// Add headers
                    client.Headers.Add("Content-Type", "application/json");
                    client.Headers.Add("Authorization", $"Bearer {bearer}");

                    /// Upload string
                    serializedResult = client.UploadString(url, Encoding.Default.GetString(Encoding.UTF8.GetBytes(serializedJson)));
                }
                catch (Exception e)
                {
                    string a = e.Message;
                }
            }

            /// Get result and return it as an object
            return JsonConvert.DeserializeObject<T>(serializedResult);
        }

        /// <summary>
        /// Downloads from URL
        /// </summary>
        /// <typeparam name="T">Type of object you are receiving</typeparam>
        /// <param name="bearer">Token</param>
        /// <param name="url">Url</param>
        /// <returns></returns>
        public static T downloadString<T>(string bearer, string url)
        {
            string serializedResult = "";

            /// Webclient
            using (var client = new WebClient())
            {
                /// Add headers
                client.Headers.Add("Content-Type", "application/json");
                client.Headers.Add("Authorization", $"Bearer {bearer}");

                /// Download string
                serializedResult = client.DownloadString(url);

                /// Fix for UTF8 when downloading string, strage characters 
                /// appear if this is not done
                byte[] bytes = Encoding.Default.GetBytes(serializedResult);
                serializedResult = Encoding.UTF8.GetString(bytes);
            }

            /// Get result and return it as an object
            return JsonConvert.DeserializeObject<T>(serializedResult);
        }

    }
}
