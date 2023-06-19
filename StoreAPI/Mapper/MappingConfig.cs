﻿using AutoMapper;
using BusinessObject.Models;
using StoreAPI.DTO;

namespace StoreAPI.Mapper
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<Product, ProductCreateDTO>().ReverseMap();
                config.CreateMap<ProductUpdateDTO, Product>().ForMember(dest => dest.Img, act => act.Ignore());
                config.CreateMap<Account, AccountLoginDTO>().ReverseMap();
                config.CreateMap<RegisterDTO, Account>().ForSourceMember(source => source.ConfirmPassword, opt => opt.DoNotValidate());
                config.CreateMap<Baby, BabyCreateDTO>().ReverseMap();
                config.CreateMap<ProductBabyDevelopment, ProductBabyDevelopmentCreateDTO>().ReverseMap();
                config.CreateMap<MilestonesByMonth, MilestonesByMonthCreateDTO>().ReverseMap();
                config.CreateMap<Order, OrderCreateDTO>().ReverseMap();
                config.CreateMap<BabyDevelopment, BabyDevelopmentCreateDTO>().ReverseMap();
                config.CreateMap<Development, DevelopmentCreateDTO>().ReverseMap();
                config.CreateMap<TakeCareDevelopment, TakeCareDevelopmentCreateDTO>().ReverseMap();
                config.CreateMap<BabyTakeCare, BabyTakeCareCreateDTO>().ReverseMap();
                config.CreateMap<Brand, BrandCreateDTO>().ReverseMap();

            });
            return mappingConfig;
        }
    }
}