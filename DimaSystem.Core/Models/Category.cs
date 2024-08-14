﻿namespace DimaSystem.Core.Models
{
    public class Category : ModelBase
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string UserId { get; set; } = string.Empty;
    }
}
