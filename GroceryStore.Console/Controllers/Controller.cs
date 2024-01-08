using GroceryStore.Logic.Dto;

namespace GroceryStore.Console.Controllers;

public class Controller<TDto> where TDto : IDto
{
    public Controller(string[] command, IServiceManager services)
    {
        _command = command;
        _services = services;
    }

    public bool ExecuteCommand() => _command[0] switch
    {
        "add" => Add((TDto)_parser.Parse(_command[1..^0])),
        _ => false
    };

    private bool Add(TDto dto) => _services.Add(dto);

    private string[] _command;

    private Parser _parser = new Parser();

    private IServiceManager _services;
}
