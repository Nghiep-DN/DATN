using onlineShopSolution.ViewModel.Catalog.Products;
using onlineShopSolution.ViewModel.Common;
using onlineShopSolution.ViewModel.Utilities.Slides;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace onlineShopSolution.WebApp.Models
{
    public class HomeViewModel
    {
        public List<SlideViewModel> Slides { get; set; }
        public List<ProductViewModel> FeaturedProducts { get; set; }
        public List<ProductViewModel> LatestProducts { get; set; }
        public PagedResult<ProductViewModel> RelevantProducts { get; set; }
      

    }
}
