using System.Net.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace ZenExtensions.Configuration.Ec2Metadata
{
    public class Ec2MetadataConfigurationProvider : ConfigurationProvider
    {
        public override void Load()
        {
            Data = new Dictionary<string,string>();
            using HttpClient client = new();
            client.BaseAddress = new("http://169.254.169.254");


            var tokenRequest = new HttpRequestMessage(HttpMethod.Put, $"latest/api/token");
            tokenRequest.Headers.Add("X-aws-ec2-metadata-token-ttl-seconds","3600");
            var tokenResponse = client.Send(tokenRequest);
            using var streamReader = new StreamReader(tokenResponse.Content.ReadAsStream());
                var token = streamReader.ReadToEnd();
                client.DefaultRequestHeaders.Add("X-aws-ec2-metadata-token", token);
            var tagsRequest = new HttpRequestMessage(HttpMethod.Get, "latest/meta-data/tags/instance");
            var tagsResponse = client.Send(tagsRequest);
            var tagsText = tagsResponse.Content.ReadAsStringAsync()
                                            .GetAwaiter()
                                            .GetResult();
            var tags = tagsText.Split('\n');

            foreach(var tag in tags)
            {
                var tagValueRequest = new HttpRequestMessage(HttpMethod.Get, $"latest/meta-data/tags/instance/{tag}");
                var tagValueResponse = client.Send(tagValueRequest);
                var tagValue = tagValueResponse.Content.ReadAsStringAsync()
                                    .GetAwaiter()
                                    .GetResult();
                Data[$"Tags:{tag}"] = tagValue;
            }
        }
    }
}