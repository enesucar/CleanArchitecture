using Microsoft.EntityFrameworkCore;

namespace Application.Common.Models.Paging
{
    public static class IQueryableExtensions
    {
        public static IPaginateList<T> ToPaginateList<T>(
            this IQueryable<T> source,
            int page,
            int size,
            CancellationToken cancellationToken = default)
        {
            var totalCount = source.Count();
            var items = source.Skip((page - 1) * size).Take(size).ToList();
            return new PaginateList<T>(items, page, size, totalCount);
        }

        public async static Task<PaginateList<T>> ToPaginateListAsync<T>(
            this IQueryable<T> source,
            int page,
            int size,
            CancellationToken cancellationToken = default)
        {
            var totalCount = await source.CountAsync(cancellationToken);
            var items = await source.Skip((page - 1) * size).Take(size).ToListAsync(cancellationToken);
            return new PaginateList<T>(items, page, size, totalCount);
        }
    }
}
