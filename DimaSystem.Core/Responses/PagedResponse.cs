﻿using System.Text.Json.Serialization;

namespace DimaSystem.Core.Responses
{
    public class PagedResponse<TData> : Response<TData>
    {
        [JsonConstructor]
        public PagedResponse(
            TData? data,
            int totalCount,
            int currentPage = Configuration.DefaultPageCurrent,
            int pageSize = Configuration.DefaultPageSize)
            :base(data)
        {
            Data = data;
            TotalCount = totalCount;
            CurrentPage = currentPage;
            PageSize = pageSize;
        }
        public PagedResponse(
            TData data, 
            int code = Configuration.DefaultStatusCode, 
            string message = null)
            : base(data, code, message) 
        {
            
        }

        public int CurrentPage { get; set; }
        public int TotalPages => (int)Math.Ceiling(TotalPages / (double)PageSize);
        public int PageSize { get; set; } = Configuration.DefaultPageSize;
        public int TotalCount { get; set; }
    }
}
