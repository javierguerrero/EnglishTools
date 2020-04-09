using AutoMapper;
using Catalog.Domain;
using Catalog.Service.Queries.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog.Api.Config
{
    public static class AutoMapperConfig
    {
        public static void Config()
        {
            Mapper.Initialize(cfg => {
                cfg.CreateMap<LessonDto, Lesson>();
            });
        }
    }
}
