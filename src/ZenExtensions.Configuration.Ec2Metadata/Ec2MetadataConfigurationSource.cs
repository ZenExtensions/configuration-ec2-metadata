using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace ZenExtensions.Configuration.Ec2Metadata
{
    public class Ec2MetadataConfigurationSource : IConfigurationSource
    {
        public IConfigurationProvider Build(IConfigurationBuilder builder)
        {
            return new Ec2MetadataConfigurationProvider();
        }
    }
}