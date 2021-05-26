﻿using Microsoft.AspNetCore.Mvc.Rendering;
using onlineShopSolution.ViewModel.System.Languages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace onlineShopSolution.AdminApp.Models
{
    public class NavigationViewModel
    {
        public List<SelectListItem> Languages { get; set; }
        public string CurrentLanguageId { get; set; }
        public string ReturnUrl { set; get; }
    }
}