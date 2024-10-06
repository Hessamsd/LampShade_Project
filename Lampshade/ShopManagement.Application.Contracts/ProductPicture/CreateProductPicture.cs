﻿using _0_Framework.Application;
using Microsoft.AspNetCore.Http;
using ShopManagement.Application.Contracts.Product;
using System.ComponentModel.DataAnnotations;

namespace ShopManagement.Application.Contracts.ProductPicture
{
    public  class CreateProductPicture
    {
        [Range(1,100000,ErrorMessage =ValidationMessages.IsRequired)]
        public int ProductId { get; set; }

        [MaxFileSizeAtrribute(1 * 1024 * 1024,ErrorMessage = ValidationMessages.MaxFileSize)]
        [Required(ErrorMessage =ValidationMessages.IsRequired)]
        public IFormFile Picture { get; set; }

        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string PictureAlt { get; set; }
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string PictureTitle { get; set; }
        public List<ProductViewModel> Products { get; set; }
    }
}
