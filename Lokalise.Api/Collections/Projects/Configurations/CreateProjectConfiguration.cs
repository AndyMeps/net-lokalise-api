﻿using Lokalise.Api.Models;
using System.Collections.Generic;

namespace Lokalise.Api.Collections.Projects.Configurations
{
    public class CreateProjectConfiguration
    {
        public long? TeamId { get; set; }
        public string? Description { get; set; }
        public string? BaseLangIso { get; set; }
        public string? ProjectType { get; set; }

        internal CreateProjectConfiguration()
        {

        }
    }
}