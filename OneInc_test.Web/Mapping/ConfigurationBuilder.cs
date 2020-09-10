using AutoMapper;
using OneInc_test.Core.Entities;
using OneInc_test.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OneInc_test.Web.Mapping
{
    static class ConfigurationBuilder
    {
        internal enum ConfigType { 
            In, Out,OutModified,Owner
        }
        internal static MapperConfiguration GetConfiguration(ConfigType type)
        {
            switch (type)
            {
                case ConfigType.In:
                    return new MapperConfiguration(cfg =>
                        cfg.CreateMap<Policy, PolicyDtoCreated>()
                        .ConstructUsing(e =>
                            new PolicyDtoCreated(
                                e.Id
                            , e.StartDate
                            , e.EndDate
                            , e.BirthDate
                            , e.PolicyNumber
                            , e.UpdateDate){
                                NameOwner=e.NameOwner,
                                ObjectName=e.ObjectName,
                                SurnameOwner=e.SurnameOwner,
                                ObjectType=e.ObjectType
                            }
                        )
                    .ForMember(dest => dest.PolicyState, input => input.Ignore())) ;


                case ConfigType.Out:
                    return new MapperConfiguration(cfg => cfg
                        .CreateMap<PolicyDtoCreate, Policy>()
                    .ForMember(dest => dest.Id, input => input.Ignore())
                    .ForMember(dest => dest.PolicyNumber, input => input.Ignore())
                    .ForMember(dest=>dest.MonthCreated,input=>input.MapFrom(src=>src.UpdateDate.Month))
                    );

                case ConfigType.OutModified:
                    return new MapperConfiguration(cfg => cfg
                        .CreateMap<PolicyDtoCreated, Policy>()
                        .ForMember(dest => dest.MonthCreated, input => 
                            input.MapFrom(src => src.UpdateDate.Month))
                        .ForMember(dest=>dest.PolicyNumber,input=>
                            input.Ignore())
                    );

                case ConfigType.Owner:
                    return new MapperConfiguration(cfg =>
                        cfg.CreateMap<Policy, Owner>()
                            .ConvertUsing(e =>
                                new Owner(e.NameOwner, e.SurnameOwner, e.BirthDate)));

                default:
                    throw new NotImplementedException("Cannot find configuration type");
            }
        }
    }
}