namespace RollingDiceApi.Services.Models.Common
{
    using System;
    using System.Linq;

    internal static class Extensions
    {
        public static IQueryable<T> ApplyPagination<T>(this IQueryable<T> query, ServicePagination pagination)
        {
            if(pagination is null || pagination.Page < 1 || pagination.PageSize < 1)
            {
                throw new ArgumentException($"Invalid pagination object: {pagination}.");
            }

            return query.Skip((pagination.Page - 1) * pagination.PageSize).Take(pagination.PageSize);
        }
        public static int GetTotalPages(this int totalItems, int pageSize)
        {
            return (int)Math.Ceiling((double)totalItems / pageSize);
        }
    }
}
