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
                cfg.CreateMap<Korisnik, KorisnikApi>();

                cfg.CreateMap<KorisnikApi, Korisnik>()
                .ForMember(dest => dest.Kockice, opt => opt.Ignore())
                .ForMember(dest => dest.Moc, opt => opt.Ignore())
                .ForMember(dest => dest.Setovi, opt => opt.Ignore());

                cfg.CreateMap<Tema, TemaApi>();

                cfg.CreateMap<UserSet, UserSetApi>();

                cfg.CreateMap<LSet, SetApi>()
                  .ForMember(dest => dest.NadTema, opt => opt.MapFrom(src => src.Tema.NadTema));

                cfg.CreateMap<LSet, SetDetailedApi>()
                .ForMember(dest => dest.NadTema, opt => opt.MapFrom(src => src.Tema.NadTema))
                .ForMember(dest => dest.Dijelovi, opt => opt.MapFrom(src => src.Dijelovi));

                cfg.CreateMap<Wishlist, WishlistApi>()
                .ForMember(dest => dest.KorisnikId, opt => opt.MapFrom(src => src.Korisnik.Id));

                cfg.CreateMap<Boja, BojaApi>();

                cfg.CreateMap<Kockica, KockicaApi>();

                cfg.CreateMap<SetoviDijelovi, SetDijeloviApi>();
            });

        }
    }
}