﻿namespace Application.Common.Models.Paging
{
    public interface IPaginateList
    {
        int Page { get; }
        int Size { get; }
        int TotalPages { get; }
        int TotalCount { get; }
        bool HasPreviousPage { get; }
        bool HasNextPage { get; }
        bool IsFirstPage { get; }
        bool IsLastPage { get; }
    }

    public interface IPaginateList<T> : IPaginateList
    {
        IEnumerable<T> Items { get; }
    }
}
