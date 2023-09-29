using AutoMapper;
using Portfolio.Business.Mappings.AutoMapper;

namespace Portfolio.Business.Extensions
{
    public static class MapperExtensions
    {
        public static void MapperProfileExpression<T>(this IProfileExpression profile, MapProfileSourceAndDestination[] mapProfileSourceAndDestinations)
        {
            // Döngü ile eşleşmeleri sağlayacağız
            foreach (var mapProfileSourceAndDestination in mapProfileSourceAndDestinations)
            {
                if (mapProfileSourceAndDestination.reverse)
                    profile.CreateMap(mapProfileSourceAndDestination.source, mapProfileSourceAndDestination.destination).ReverseMap();
                else
                    profile.CreateMap(mapProfileSourceAndDestination.source, mapProfileSourceAndDestination.destination);
            }
        }
    }
}