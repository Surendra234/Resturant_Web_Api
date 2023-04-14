using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ResturantWebApi.Data;
using ResturantWebApi.Models;

namespace ResturantWebApi.Controllers;


[Route(template: "api")]
public class HomeController : Controller
{
    MySqlConnector.MySqlConnection connection = new MySqlConnector.MySqlConnection(connectionString: "Server=localhost;port=3306;Database=ResturantDatabase;user=root;password=root@1234;Persist security Info=true");

    private readonly ResturantDbContext _context;

    public HomeController(ResturantDbContext context)
    {
        _context = context;
    }

    [HttpGet("/get/All-orders")]
    public async Task<ActionResult<IEnumerable<OrderMaster>>> GetOrderMaster()
    {
        return await _context.OrderMasters.ToListAsync();
    }

    [HttpGet("/get/order-by-id={id}")]
    public async Task<ActionResult<OrderMaster>> GetOrderById(long id)
    {
        var order = await _context.OrderMasters.FindAsync(id);

        if (order == null)
        {
            return NotFound();
        }

        return order;
    }

    [HttpPost("/add_customer")]
    public IActionResult AddCustomer([FromBody] string cName)
    {
        connection.Open();

        MySqlConnector.MySqlCommand cmd = new MySqlConnector.MySqlCommand("AddCustomer", connection);

        cmd.CommandType = System.Data.CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@c_name", cName);
        cmd.ExecuteNonQuery();

        connection.Close();

        var responce = new Responce
        {
            sucsses = true,
            message = $"{cName} added successfully"
        };

        return Ok(responce);
    }

    [HttpPost("/add_foodItem")]
    public IActionResult AddFoodItem([FromBody] foodItem_body food)
    {
        connection.Open();
        MySqlConnector.MySqlCommand command = new MySqlConnector.MySqlCommand("AddFood", connection);
        command.CommandType = System.Data.CommandType.StoredProcedure;
        command.Parameters.AddWithValue("@f_item", food.foodItemName);
        command.Parameters.AddWithValue("@f_price", food.price);
        command.ExecuteNonQuery();
        connection.Close();

        var responce = new Responce
        {
            sucsses = true,
            message = $"{food.foodItemName} added successfully"
        };

        return Ok(responce);
    }

    [HttpGet("/get/food_items")]
    public IActionResult GetFoodItem()
    {
        var foodItem = _context.FoodItems.ToList();
        return Ok(foodItem);
    } 
}

public class Responce
{
    public bool sucsses { get; set; }
    public string message { get; set; }
}

public class foodItem_body
{
    public string foodItemName { get; set; }
    public decimal price { get; set; }
}        
