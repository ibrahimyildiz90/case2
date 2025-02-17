﻿using AutoMapper;

namespace MikroServices.UI.Obilet.MVC.Mapping
{
    public static class ObjectMapper
    {
        private static readonly Lazy<IMapper> lazy = new Lazy<IMapper>(() =>
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<CustomMapping>();
            });

            return config.CreateMapper();

        });

        public static IMapper Mapper => lazy.Value;

    }
}
