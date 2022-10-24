using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectService.Contracts;

namespace ProjectService.Controllers
{
    public class DocumentController : ApiController
    {
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IHttpClientFactory _clientFactory;
        private readonly HttpClient _httpClient;


        public DocumentController(IHttpContextAccessor contextAccessor, IHttpClientFactory clientFactory)
        {
            _contextAccessor = contextAccessor;
            _httpClient = clientFactory.CreateClient("GetProductInfo");
            _httpClient.BaseAddress = new Uri("https://localhost:7172/");
        }
        [HttpGet, Route(ApiRoutes.DocumentRoute.GetProductInfo)]
        public ActionResult<object> GetProducts()
        {
            // return "hello world";
            
            return new { Amount = 108, Message = "Hello" };
        }
        
        [HttpGet, Route(ApiRoutes.DocumentRoute.GetTestInfo)]
        public async Task<object> GetTest()
        {
            var result = await _httpClient.GetAsync("api/v1/document/getProductInfo");
            var x = _contextAccessor;

            // var yes = await result.Content.ReadAsStringAsync();
            var yes = await result.Content.ReadFromJsonAsync<ResponseModel>();
            return yes;
        }
    }

    public class ResponseModel
    {
        public int Amount { get; set; }
        public string Message { get; set; }
    }
}
