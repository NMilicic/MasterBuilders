using AutoMapper;
using Data.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApi.Models;

namespace WebApi.App_Start
{
    public class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<User, UserApi>();

                cfg.CreateMap<UserApi, User>()
                .ForMember(dest => dest.Parts, opt => opt.Ignore())
                .ForMember(dest => dest.Mocs, opt => opt.Ignore())
                .ForMember(dest => dest.LSets, opt => opt.Ignore());

                cfg.CreateMap<Theme, ThemeApi>();

                cfg.CreateMap<UserLSet, UserLSetApi>();

                cfg.CreateMap<LSet, LSetApi>()
                  .ForMember(dest => dest.BaseTheme, opt => opt.MapFrom(src => src.Theme.BaseTheme));

                cfg.CreateMap<LSet, SetDetailedApi>()
                .ForMember(dest => dest.BaseTheme, opt => opt.MapFrom(src => src.Theme.BaseTheme))
                .ForMember(dest => dest.LSetParts, opt => opt.MapFrom(src => src.LSetParts));

                cfg.CreateMap<Wishlist, WishlistApi>()
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.User.Id))
                .ForMember(dest => dest.LSetId, opt => opt.MapFrom(src => src.LSet.Id));

                cfg.CreateMap<Color, ColorApi>();

                cfg.CreateMap<ColorApi, Color>()
                .ForMember(dest => dest.MocParts, opt => opt.Ignore())
                .ForMember(dest => dest.LSetParts, opt => opt.Ignore());

                cfg.CreateMap<Part, PartApi>();
                cfg.CreateMap<PartApi, Part>()
                .ForMember(dest => dest.Users, opt => opt.Ignore())
                .ForMember(dest => dest.LSetParts, opt => opt.Ignore());

                cfg.CreateMap<LSetPart, LSetPartApi>();

                cfg.CreateMap<Moc, MocApi>();

                cfg.CreateMap<MocApi, Moc>()
                .ForMember(dest => dest.UserMoc, opt => opt.Ignore());

                cfg.CreateMap<MocPart, MocPartApi>();

                cfg.CreateMap<MocPartApi, MocPart>()
                .ForMember(dest => dest.Moc, opt => opt.Ignore());

                cfg.CreateMap<Category, CategoryApi>();
                cfg.CreateMap<CategoryApi, Category>()
                .ForMember(dest => dest.Parts, opt => opt.Ignore()); ;
            });

        }
    }
}