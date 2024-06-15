using System.Diagnostics;
using System.Net;
using AdminFe.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebOrderFilter.Controllers;

namespace AdminFe.Controllers
{
    public class HomeController : BaseController
    {

        private readonly ILogger<HomeController> _logger;
        private readonly HttpClient _httpClient;

        public HomeController(ILogger<HomeController> logger, IHttpClientFactory httpClientFactory)
        {
            _logger = logger;
            _httpClient = httpClientFactory.CreateClient();
        }
       

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(LoginViewModel model)
        {
            var url = "https://calofit.azurewebsites.net/api/User/login";
            var response = await PushData(url, model);

            if (response == HttpStatusCode.OK)
            {
                return RedirectToAction("Home");
            }
            else
            {
                ViewBag.ErrorMessage = "Invalid email or password.";
                return View();
            }
        }
        public async Task<IActionResult> Detail()
        {
            var url = "https://calofit.azurewebsites.net/api/User";
            var response = await _httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                var users = JsonConvert.DeserializeObject<List<User>>(data);
                return View(users);
            }
            else
            {
                ViewBag.ErrorMessage = "Failed to retrieve user list.";
                return View();
            }
        }
        public async Task<IActionResult> DetailOrder()
        {
            var url = "https://calofit.azurewebsites.net/api/Order";
            var response = await _httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                var users = JsonConvert.DeserializeObject<List<Order>>(data);
                return View(users);
            }
            else
            {
                ViewBag.ErrorMessage = "Failed to retrieve user list.";
                return View();
            }
        }

        public async Task<IActionResult> OrderDetail(int orderId)
        {
            var url = $"https://calofit.azurewebsites.net/api/Order/{orderId}"; // Sử dụng orderId trong URL
            var response = await _httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                var orderDetails = JsonConvert.DeserializeObject<List<OrderDetail>>(data);
                return View(orderDetails);
            }
            else
            {
                ViewBag.ErrorMessage = "Failed to retrieve order details.";
                return View();
            }
        }


        public async Task<IActionResult> Home()
        {
            var urlUsers = "https://calofit.azurewebsites.net/api/User/total";
            var urlOrders = "https://calofit.azurewebsites.net/api/Order/total";

            var responseUsersTask = _httpClient.GetAsync(urlUsers);
            var responseOrdersTask = _httpClient.GetAsync(urlOrders);

            await Task.WhenAll(responseUsersTask, responseOrdersTask);

            var responseUsers = await responseUsersTask;
            var responseOrders = await responseOrdersTask;

            if (responseUsers.IsSuccessStatusCode && responseOrders.IsSuccessStatusCode)
            {
                var dataUsers = await responseUsers.Content.ReadAsStringAsync();
                var dataOrders = await responseOrders.Content.ReadAsStringAsync();

                var totalUsers = JsonConvert.DeserializeObject<int>(dataUsers);
                var totalOrders = JsonConvert.DeserializeObject<int>(dataOrders);

                ViewBag.TotalUsers = totalUsers;
                ViewBag.TotalOrders = totalOrders;

                return View();
            }
            else
            {
                ViewBag.ErrorMessage = "Failed to retrieve total data.";
                return View();
            }
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
