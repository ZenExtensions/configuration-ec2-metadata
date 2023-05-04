using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace ZenExtensions.Configuration.Ec2Metadata
{
    public static class ConfigurationBuilderExtensions
    {
        public static IConfigurationBuilder AddEc2Metadata(this IConfigurationBuilder builder)
        {
            return builder.Add(new Ec2MetadataConfigurationSource());
        }
    }
}