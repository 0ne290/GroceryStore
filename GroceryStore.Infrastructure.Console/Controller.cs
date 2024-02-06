using System.Linq.Expressions;
using GroceryStore.Core.Application.Interfaces;
using GroceryStore.Core.Domain.Interfaces;
using GroceryStore.Infrastructure.Console.Interfaces;

namespace GroceryStore.Infrastructure.Console;

public class Controller<TEntity, TDto> : IController where TEntity : class, IEntity where TDto : IDto, new()
{
    public Controller(string[] command, IEntityService entityService, Parser parser, Printer printer)
    {
        _command = command;
        _entityService = entityService;
        _parser = parser;
        _parser.Lexemes = _command[1..];
        _printer = printer;
    }

    public bool ExecuteCommand()
    {
        System.Console.WriteLine("Ждем 10 секунд");
        Thread.Sleep(10000);
        System.Console.WriteLine("Закончили ждать 10 секунд");

        return _command[0] switch
        {
            "Add" => Add(),
            "GetByCriterion" => GetByCriterion(),
            "GetAll" => GetAll(),
            "GetByKey" => GetByKey(),
            "Update" => Update(),
            "Remove" => Remove(),
            _ => Default()
        };
    }

    private bool GetByCriterion()
    {
        var filter = (Expression<Func<TEntity, bool>>)_parser.ParseFilter(typeof(TDto));
        //var orderBy = _parser.ParseSorting(typeof(TDto));

        var dtos = _entityService.Get<TEntity, TDto>(filter);

        foreach (var dto in dtos)
            _printer.Print(new[] { dto });

        return true;
    }

    private bool Add()
    {
        var entity = (TEntity)_parser.Parse(typeof(TEntity));
        
        var result = _entityService.Add(entity);
        
        var exception = _entityService.SaveChanges<TEntity>();
                
        System.Console.WriteLine($"Is the entry accepted for adding? {result}. Error message about saving changes: {exception?.InnerException?.Message ?? ""}");

        return result;
    }

    private bool GetAll()
    {
        var dtos = _entityService.GetAll<TEntity, TDto>();

        _printer.Print(dtos);

        return true;
    }
    
    private bool GetByKey()
    {
        var key = _parser.ParseKey(typeof(TEntity));
        
        var dto = _entityService.GetByKey<TEntity, TDto>(key);
        
        var result = !dto.IsEmpty;

        if (result)
            _printer.Print(new[] { dto });

        return result;
    }

    private bool Update()
    {
        var entity = (TEntity)_parser.Parse(typeof(TEntity));
        
        var result = _entityService.Update(entity);
        
        var exception = _entityService.SaveChanges<TEntity>();
                
        System.Console.WriteLine($"Is the entry accepted for updating? {result}. Error message about saving changes: {exception?.InnerException?.Message ?? ""}");

        return result;
    }
    
    private bool Remove()
    {
        var entity = (TEntity)_parser.Parse(typeof(TEntity));
        
        var result = _entityService.Remove(entity);
        
        var exception = _entityService.SaveChanges<TEntity>();
                
        System.Console.WriteLine($"Is the entry accepted for deletion? {result}. Error message about saving changes: {exception?.InnerException?.Message ?? ""}");

        return result;
    }

    private bool Default()
    {
        System.Console.WriteLine(false);

        return false;
    }

    private readonly string[] _command;

    private readonly Parser _parser;

    private readonly Printer _printer;

    private readonly IEntityService _entityService;
}
