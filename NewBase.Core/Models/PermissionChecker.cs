﻿using System.Collections.Generic;

namespace NewBase.Core.Models
{
    public class PermissionChecker
    {
        public long Key { get; set; }
        public List<string> PermissionCodes { get; set; }
        public List<string> PermissionUrls { get; set; }
    }
}
