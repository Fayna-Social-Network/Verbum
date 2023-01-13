﻿using Verbum.Domain.UserFilesTable;

namespace Verbum.Domain.Common
{
    public class ImageMessage
    {
        public Guid id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }

        public List<UserFile>? userFiles { get; set; }
    }
}