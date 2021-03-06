﻿namespace Oisys.Service.Helpers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// <see cref="SummaryList{T}"/> class represents the items, total pages object.
    /// </summary>
    /// <typeparam name="T">The first generic type parameter.</typeparam>
    public class SummaryList<T>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SummaryList{T}"/> class.
        /// </summary>
        /// <param name="items">Items</param>
        /// <param name="count">Count</param>
        /// <param name="pageIndex">PageIndex</param>
        /// <param name="pageSize">PageSize</param>
        public SummaryList(IEnumerable<T> items, int count, int pageIndex, int pageSize)
        {
            this.PageIndex = pageIndex;
            this.TotalPages = (int)Math.Ceiling(count / (double)pageSize);

            this.Items = items;
        }

        /// <summary>
        /// Gets property PageIndex.
        /// </summary>
        public int PageIndex { get; private set; }

        /// <summary>
        /// Gets property TotalPages.
        /// </summary>
        public int TotalPages { get; private set; }

        /// <summary>
        /// Gets a value indicating whether gets property HasPreviousPage.
        /// </summary>
        public bool HasPreviousPage
        {
            get
            {
                return this.PageIndex > 1;
            }
        }

        /// <summary>
        /// Gets a value indicating whether gets property HasNextPage.
        /// </summary>
        public bool HasNextPage
        {
            get
            {
                return this.PageIndex < this.TotalPages;
            }
        }

        /// <summary>
        /// Gets the items of the <see cref="SummaryList{T}"/> object.
        /// </summary>
        public IEnumerable<T> Items { get; private set; }

        /// <summary>
        /// Method to page list input
        /// </summary>
        /// <param name="source">Source</param>
        /// <param name="pageIndex">PageIndex</param>
        /// <param name="pageSize">PageSize</param>
        /// <returns>None</returns>
        public static async Task<SummaryList<T>> CreateAsync(IQueryable<T> source, int pageIndex, int pageSize)
        {
            var count = await source.CountAsync();
            var items = await source.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();
            return new SummaryList<T>(items, count, pageIndex, pageSize);
        }
    }
}
