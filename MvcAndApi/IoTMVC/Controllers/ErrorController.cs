using DataAccessLayer;
using EntityLayer.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IoTMVC.Controllers
{
    public class ErrorController : BaseController
    {
        public ErrorController(
            IUnitOfWork<MDataPublish> unitOfWorkMDataPublish,
            IUnitOfWork<Result> unitOfWorkResult) : base(unitOfWorkMDataPublish, unitOfWorkResult)
        {}

        [AllowAnonymous]
        public IActionResult HttpStatusCodeHandler(int statusCode)
        {
            ViewBag.StatusCode = statusCode;
            switch (statusCode)
            {
                case 300:
                    ViewBag.ErrorMessage = "Sorry, try to do that again.";
                    ViewBag.ErrorMessageTr = "Tekrardan deneyiniz.";
                    ViewBag.ErrorTitle = "300 Multiple Choices";
                    break;
                case 304:
                    ViewBag.ErrorMessage = "Sorry, try to do that again.";
                    ViewBag.ErrorMessageTr = "Tekrardan deneyiniz.";
                    ViewBag.ErrorTitle = "304 Not Modified";
                    break;
                case 400:
                    ViewBag.ErrorMessage = "Sorry, it's a bad request. Try again.";
                    ViewBag.ErrorMessageTr = "Kötü bir istek yolladınız, tekrardan deneyin.";
                    ViewBag.ErrorTitle = "400 Bad Request";
                    break;
                case 401:
                    ViewBag.ErrorMessage = "Sorry, you are unauthorize to see that page.";
                    ViewBag.ErrorMessageTr = "Bu sayfayı görmek için giriş yapmanız gerekmektedir.";
                    ViewBag.ErrorTitle = "401 Unauthorized";
                    break;
                case 403:
                    ViewBag.ErrorMessage = "Sorry, you are not able to reach that page for now.";
                    ViewBag.ErrorMessageTr = "Bu sayfaya şu anlık ulaşılamıyor.";
                    ViewBag.ErrorTitle = "403 Forbidden";
                    break;
                case 404:
                    ViewBag.ErrorMessage = "Sorry, we couldn't find the page you were trying to reach.";
                    ViewBag.ErrorMessageTr = "Ulaşmaya çalıştığınız sayfayı bulamadık.";
                    ViewBag.ErrorTitle = "404 Not Found";
                    break;
                case 408:
                    ViewBag.ErrorMessage = "Sorry, your request has been time out.";
                    ViewBag.ErrorMessageTr = "İsteğiniz zaman aşımına uğradı.";
                    ViewBag.ErrorTitle = "408 Request Timeout";
                    break;
                case 500:
                    ViewBag.ErrorMessage = "Sorry, there is an internal server error.";
                    ViewBag.ErrorMessageTr = "Tekrardan deneyiniz.";
                    ViewBag.ErrorTitle = "500 Internal Server Error";
                    break;
            }
            return View("NotFound404");
        }
    }
}
