using GroceryStore.Logic.Interfaces;

namespace GroceryStore.Console;

public class Controller<TDto> where TDto : IDto
{
    public Controller(string[] command, IServiceManager services, Parser parser, Printer printer)
    {
        _command = command;
        _services = services;
        _parser = parser;
        _parser.Lexemes = _command[1..];
        _printer = printer;
    }

    public bool ExecuteCommand() => _command[0] switch
    {
        "add" => Add(),
        "getall" => GetAll(),
        "get" => GetByKey(),
        "update" => Update(),
        _ => Default()
    };

    private bool Add()
    {
        var dto = (TDto)_parser.Parse(typeof(TDto));
        var ret = _services.Add(dto);
        ret = ret && _services.SaveChanges<TDto>();
                
        System.Console.WriteLine(ret);

        return ret;
    }

    private bool GetAll()
    {
        var dtos = _services.GetAll<TDto>();

        foreach (var dto in dtos)
            _printer.Print(dto);

        return true;
    }
    
    private bool GetByKey()
    {
        var key = (TDto)_parser.ParseKey(typeof(TDto));
        var dto = _services.GetByKey<TDto>(key);
        var ret = !dto.IsEmpty();

        if (ret)
            _printer.Print(dto);

        return ret;
    }

    private bool Update()
    {
        var dto = (TDto)_parser.Parse(typeof(TDto));
        var ret = _services.Update(dto);
        ret = ret && _services.SaveChanges<TDto>();
                
        System.Console.WriteLine(ret);

        return ret;
    }

    private bool Default()
    {
        System.Console.WriteLine(false);

        return false;
    }

    private readonly string[] _command;

    private readonly Parser _parser;

    private readonly Printer _printer;

    private readonly IServiceManager _services;
}
