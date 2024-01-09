using GroceryStore.Logic.Interfaces;

namespace GroceryStore.Console.Controllers;

public class Controller<TDto> where TDto : IDto
{
    public Controller(string[] command, IServiceManager services, Parser parser)
    {
        _command = command;
        _services = services;
        _parser = parser;
    }

    public bool ExecuteCommand() => _command[0] switch
    {
        "add" => Add((TDto)_parser.Parse(_command[1..^0])),
        _ => false
    };

    private bool Add(TDto dto) => _services.Add(dto);

    private string[] _command;

    private Parser _parser;

    private IServiceManager _services;
}
