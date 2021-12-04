using System;
using AutoMapper;
using Samson.Web.Application.Infrastructure.ViewModels;

namespace Samson.Web.Application.Infrastructure
{
    /// <summary>
    /// Mapping profile to map Infrastructure project related objects.
    /// </summary>
    public class InfrastructureMapperProfile : Profile
    {
        /// <summary>
        /// Default constructor.
        /// </summary>
        public InfrastructureMapperProfile()
        {
            CreateMap<DimensionViewModel, Tuple<int, int>>()
                .ConstructUsing(dimension => new Tuple<int, int>(dimension.Height, dimension.Width));
            CreateMap<Tuple<int, int>, DimensionViewModel>()
                .ConstructUsing(tuple => new DimensionViewModel(tuple.Item1, tuple.Item2));
            CreateMap<DateTime, string>()
                .ConstructUsing(datetime => datetime.ToString("s"));
        }
    }
}
