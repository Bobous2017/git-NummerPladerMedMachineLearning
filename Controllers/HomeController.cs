using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NummerPlader.Models;
using System.Diagnostics;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly HttpClient _httpClient;

    public HomeController(ILogger<HomeController> logger, HttpClient httpClient)
    {
        _logger = logger;
        _httpClient = httpClient;
    }

    // Existing action for Index page
    public IActionResult Index()
    {
        return View();
    }

    // Action to fetch vehicle data (you already have this)
    public async Task<IActionResult> NummerPlate(string registrationNumber)
    {
        if (string.IsNullOrEmpty(registrationNumber))
        {
            _logger.LogError("No registration number provided.");
            var errorViewModel = new ErrorViewModel
            {
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            };
            return View("Error", errorViewModel);
        }

        string apiUrl = $"https://v1.motorapi.dk/vehicles/{registrationNumber}";

        try
        {
            _httpClient.DefaultRequestHeaders.Clear();
            _httpClient.DefaultRequestHeaders.Add("X-AUTH-TOKEN", "6u57x6u2uutyy88di30xrppoprwhrefn");

            var response = await _httpClient.GetStringAsync(apiUrl);

            if (!string.IsNullOrEmpty(response))
            {
                var vehicleData = JsonConvert.DeserializeObject<dynamic>(response);
                return View(vehicleData);
            }
            else
            {
                _logger.LogError("API Request failed: No data returned.");
                var errorViewModel = new ErrorViewModel
                {
                    RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
                };
                return View("Error", errorViewModel);
            }
        }
        catch (HttpRequestException ex)
        {
            _logger.LogError($"Error calling API: {ex.Message}");
            var errorViewModel = new ErrorViewModel
            {
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            };
            return View("Error", errorViewModel);
        }
    }

    // Action to fetch Environment data
    public async Task<IActionResult> Environment(string registrationNumber)
    {
        string apiUrl = $"https://v1.motorapi.dk/vehicles/{registrationNumber}/environment";

        try
        {
            _httpClient.DefaultRequestHeaders.Clear();
            _httpClient.DefaultRequestHeaders.Add("X-AUTH-TOKEN", "6u57x6u2uutyy88di30xrppoprwhrefn");

            var response = await _httpClient.GetStringAsync(apiUrl);

            if (!string.IsNullOrEmpty(response))
            {
                var environmentData = JsonConvert.DeserializeObject<NummerPlader.Models.Environment>(response);
                var model = new
                {
                    registration_number = registrationNumber,
                    environment = environmentData
                };
                return View(model);
            }
            else
            {
                _logger.LogError("API Request failed: No data returned.");
                var errorViewModel = new ErrorViewModel
                {
                    RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
                };
                return PartialView("Error", errorViewModel);
            }
        }
        catch (HttpRequestException ex)
        {
            _logger.LogError($"Error calling API: {ex.Message}");
            var errorViewModel = new ErrorViewModel
            {
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            };
            return PartialView("Error", errorViewModel);
        }
    }

    // Action to fetch Equipment data
    public async Task<IActionResult> Equipment(string registrationNumber)
    {
        if (string.IsNullOrEmpty(registrationNumber))
        {
            _logger.LogError("No registration number provided.");
            var errorViewModel = new ErrorViewModel
            {
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            };
            return View("Error", errorViewModel);
        }

        string apiUrl = $"https://v1.motorapi.dk/vehicles/{registrationNumber}/equipment";

        try
        {
            _httpClient.DefaultRequestHeaders.Clear();
            _httpClient.DefaultRequestHeaders.Add("X-AUTH-TOKEN", "6u57x6u2uutyy88di30xrppoprwhrefn");

            var response = await _httpClient.GetStringAsync(apiUrl);

            if (!string.IsNullOrEmpty(response))
            {
                var equipmentData = JsonConvert.DeserializeObject<List<Equipment>>(response);

                var model = new
                {
                    registration_number = registrationNumber,
                    equipment = equipmentData
                };
                return View(model);
            }
            else
            {
                _logger.LogError("API Request failed: No data returned.");
                var errorViewModel = new ErrorViewModel
                {
                    RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
                };
                return View("Error", errorViewModel);
            }
        }
        catch (HttpRequestException ex)
        {
            _logger.LogError($"Error calling API: {ex.Message}");
            var errorViewModel = new ErrorViewModel
            {
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            };
            return View("Error", errorViewModel);
        }
    }








    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }



}
