﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sagicor.Access.Application.Features.PLCategory.Queries.GetAllPLCategories
{
    public class PLCategoryDto
    {
        public Guid Id { get; set; }
        public string Code { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}
