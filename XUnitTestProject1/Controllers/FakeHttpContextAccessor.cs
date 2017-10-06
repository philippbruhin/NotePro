using Microsoft.AspNetCore.Http;
using Moq;

namespace NotePro.Tests.Controllers
{
    public class FakeHttpContextAccessor : IHttpContextAccessor
    {
        public HttpContext HttpContext { get; set; }

        public FakeHttpContextAccessor()
        {
            HttpContext = new Mock<HttpContext>().Object;
        }
    }
}