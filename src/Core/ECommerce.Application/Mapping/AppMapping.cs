using AutoMapper;
using AutoMapper.Configuration.Conventions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Mapping
{
    public class AppMapping
    {
        private readonly IMapper _mapper;

        public AppMapping()
        {
            var configuration = new MapperConfiguration(config =>
            {
                config.AddProfile(typeof(MappingProfile));
            });

            _mapper = configuration.CreateMapper();
        }

        public TDestination Mapping<TDestination,TSource>(TSource source)
        {
            return _mapper.Map<TDestination>(source);
        }
    }
}
