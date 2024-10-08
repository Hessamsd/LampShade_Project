using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopManagement.Application.Contracts.ProductPicture;
using ShopManagement.Application.Contracts.Slide;

namespace ServiceHost.Areas.Administration.Pages.Shop.Slides
{
    public class IndexModel : PageModel
    {

        [TempData]

        public string Message { get; set; }
        public List<SlideViewModel> Slides;
        private readonly ISlideApplication _slideApplication;


        public IndexModel(ISlideApplication slideApplication)
        {
            _slideApplication = slideApplication;
        }

        public void OnGet(ProductPictureSearchModel searchModel)
        {
            Slides = _slideApplication.GetList();
        }


        public IActionResult OnGetCreate()
        {
            var command = new CreateSlide();
            return Partial("./Create", command);
        }


        public JsonResult OnPostCreate(CreateSlide command)
        {
            var result = _slideApplication.Create(command);
            return new JsonResult(result);
        }


        public IActionResult OnGetEdit(int id)
        {
            var slide = _slideApplication.GetDetails(id);
            return Partial("Edit", slide);
        }


        public JsonResult OnPostEdit(EditSlide command)
        {
            var result = _slideApplication.Edit(command);
            return new JsonResult(result);
        }

        public IActionResult OnGetRemove(int id)
        {
            var result = _slideApplication.Remove(id);

            TempData["Message"] = result.Message;
            if (result.IsSuccedded)
                return RedirectToPage("./Index");
            Message = result.Message;
            return RedirectToPage("./Index");

        }

        public IActionResult OnGetRestore(int id)
        {
            var result = _slideApplication.Restore(id);

            TempData["Message"] = result.Message;
            if (result.IsSuccedded)
                return RedirectToPage("./Index");

            Message = result.Message;
            return RedirectToPage("./Index");

        }
    }
}
