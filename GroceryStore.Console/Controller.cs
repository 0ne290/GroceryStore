using GroceryStore.Logic.Interfaces;

namespace GroceryStore.Console;

public class Controller<TDto> where TDto : IDto
{
    public Controller(string[] command, IServiceManager services, Parser parser)
    {
        _command = command;
        _services = services;
        _parser = parser;
        _parser.Lexemes = _command[1..];
    }

    public bool ExecuteCommand() => _command[0] switch
    {
        "add" => Add((TDto)_parser.Parse(typeof(TDto))),
        _ => false
    };

    private bool Add(TDto dto) => _services.Add(dto);

    private readonly string[] _command;

    private readonly Parser _parser;

    private readonly IServiceManager _services;
}
