﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Samson.Web.Application.Api.ViewModels.GymPassType
{
    /// <summary>
    /// GymPassType view model
    /// </summary>
    public class GymPassTypeViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Duration { get; set; }
    }
}
