using Microsoft.AspNetCore.Http;
using onlineShopSolution.Data.Enum;
using onlineShopSolution.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace onlineShopSolution.ViewModel.Utilities.Slides
{
    public class SlideCreateRequest
    {
        [Display(Name="Tên")]
        public string Name { set; get; }
        [Display(Name = "Ảnh")]
        public IFormFile ThumbnailImage { get; set; }
        [Display(Name = "Mô tả")]
        public string Description { set; get; }
        [Display(Name = "Thứ tự")]
        public int SortOrder { set; get; }
        public Status Status { set; get; }
    }
}
