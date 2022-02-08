using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace serverSide.Pages;

public class HomeModel : PageModel
{
    private readonly ILogger<HomeModel> _logger;

    public string Time { get; private set; } = string.Empty;
    public string DataString { get; private set; } = string.Empty;

    public HomeModel(ILogger<HomeModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {
        Time = $"{DateTime.Now}";
        DataString = string.Join(',', Data.GetData());
    }
}
