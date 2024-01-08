using GroceryStore.Logic.Dto;

namespace GroceryStore.Console.Controllers;

public class CityController
{
    public CityController(string[] command) => _command = command;

    public bool ExecuteCommand() => _command[0] switch
    {
        "add" => Add(Parse()),
        _ => false
    };

    private CityDto Parse()
    {
        
    }

    private bool Add(CityDto cityDto)
    {
        return false;
    }

    private string[] _command;
}