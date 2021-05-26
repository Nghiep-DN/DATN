﻿using Microsoft.AspNetCore.Mvc;
using onlineShopSolution.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace onlineShopSolution.WebApp.Controllers.Components
{
    
        public class PagerViewComponent : ViewComponent
        {
            public Task<IViewComponentResult> InvokeAsync(PagedResultBase result)
            {
                return Task.FromResult((IViewComponentResult)View("Default", result));
            }
        }
    
}
