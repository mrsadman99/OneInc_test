using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneInc_test.Web.Mapping
{
    static class MapperBuilder
    {
        internal static Mapper Build(ConfigurationBuilder.ConfigType type)
        {
            return new Mapper(ConfigurationBuilder.GetConfiguration(type));
        } 
    }
}
