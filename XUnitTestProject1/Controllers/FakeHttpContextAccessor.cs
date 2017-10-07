using Microsoft.AspNetCore.Http;
using XUnitTestNotePro.Controllers;


namespace NotePro.Tests.Controllers
{
    public class FakeHttpContextAccessor : IHttpContextAccessor
    {
        public HttpContext HttpContext { get; set; }

        public FakeHttpContextAccessor()
        {
            HttpContext = new FakeHttpContext();
        }
    }

}