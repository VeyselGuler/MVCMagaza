using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MVC_Magaza.Models;

namespace MVC_Magaza.Controllers;

public class HomeController : Controller
{

    public IActionResult Index()
    {
        using StreamReader reader = new StreamReader($"AppData/items/banner.txt");
        ViewData["content"] = reader.ReadToEnd();
        
        var items = getAllItems();
        
        return View(items);
    }

    public List<Shop> getAllItems()
    {
        var items = new List<Shop>();
        using StreamReader reader = new StreamReader("AppData/items/index.txt");
        var itemsTxt = reader.ReadToEnd();

        var itemsLines = itemsTxt.Split('\n');
        foreach (var item in itemsLines)
        {
            var itemParts = item.Split('|');
            items.Add(new Shop()
            {
                Item = itemParts[0],
                Price = itemParts[1],
                ImgUrl = itemParts[2]
                
            });
        }

        return items;
    }
}