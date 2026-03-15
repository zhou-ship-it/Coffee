using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System;


namespace Mapper
{
    public static class BuildMap
    {
        private static MapperConfiguration _mapperConfig = null;
        private static IMapper _mapper = null;
        private static IServiceProvider _serviceProvider = null;

        public static IMapper Mapper
        {
            get
            {
                try
                {
                    if (_mapper == null)
                    {
                        var services = new ServiceCollection();
                        services.AddAutoMapper(typeof(BizOMapper));
                        _serviceProvider = services.BuildServiceProvider();
                        //
                        //
                        _mapperConfig = new MapperConfiguration(cfg =>
                        {
                            cfg.AddProfile<BizOMapper>();
                        });
                        _mapperConfig.AssertConfigurationIsValid();
                        _mapper = _mapperConfig.CreateMapper();
                    }
                    return _mapper;
                }
                catch (Exception ex)
                {
                    throw new Exception(Globals.Common.GetDetailError(ex));
                }
            }
        }
    }
}
