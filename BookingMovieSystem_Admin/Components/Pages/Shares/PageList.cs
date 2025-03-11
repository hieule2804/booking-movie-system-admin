using Microsoft.AspNetCore.Http.Features;
using Microsoft.CodeAnalysis;

namespace BookingMovieSystem_Admin.Components.Pages.Shares
{
    public class PageList<T>
    {
        public Metadata Metadata { get; set; }

        public List<T> Items { get; set; }

        public PageList() { }

        public PageList(List<T> items, int count, int pageNumber, int pageSize)
        {
            Metadata = new Metadata
            {
                TotalCount = count,
                PageSize = pageSize,
                CurrentPage = pageNumber,
                TotalPages = (int)Math.Ceiling(count / (double)pageSize)
            };
            Items = items;
        }
    }
}
