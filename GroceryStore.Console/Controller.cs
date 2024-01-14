using System.Linq.Expressions;
using GroceryStore.Logic.Interfaces;

namespace GroceryStore.Console;

public class Controller<TEntity, TDto> where TDto : IDto where TEntity : IEntity
{
    public Controller(string[] command, IUnitOfWork unitOfWork, Parser parser, Printer printer)
    {
        _command = command;
        _unitOfWork = unitOfWork;
        _parser = parser;
        _parser.Lexemes = _command[1..];
        _printer = printer;
    }

    public bool ExecuteCommand() => _command[0] switch
    {
        "Add" => Add(),
        "GetByCriterion" => GetByCriterion(),
        "GetAll" => GetAll(),
        "GetByKey" => GetByKey(),
        "Update" => Update(),
        _ => Default()
    };

    private bool GetByCriterion()
    {
        var filter = (Expression<Func<TEntity, bool>>)_parser.ParseFilter(typeof(TDto));
        var orderBy = _parser.ParseSorting(typeof(TDto));

        var dtos = _unitOfWork.Get<TEntity, TDto>(filter, orderBy);

        foreach (var dto in dtos)
            _printer.Print(dto);

        return true;
    }

    private bool Add()
    {
        var dto = (TDto)_parser.Parse(typeof(TDto));
        var ret = _unitOfWork.Add<TEntity, TDto>(dto);
        ret = ret && _unitOfWork.SaveChanges<TEntity, TDto>();
                
        System.Console.WriteLine(ret);

        return ret;
    }

    private bool GetAll()
    {
        var dtos = _unitOfWork.GetAll<TEntity, TDto>();

        foreach (var dto in dtos)
            _printer.Print(dto);

        return true;
    }
    
    private bool GetByKey()
    {
        var key = _parser.ParseKey(typeof(TDto));
        var dto = _unitOfWork.GetByKey<TEntity, TDto>(key);
        var ret = !dto.IsEmpty();

        if (ret)
            _printer.Print(dto);

        return ret;
    }

    private bool Update()
    {
        var dto = (TDto)_parser.Parse(typeof(TDto));
        var ret = _unitOfWork.Update<TEntity, TDto>(dto);
        ret = ret && _unitOfWork.SaveChanges<TEntity, TDto>();
                
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

    private readonly IUnitOfWork _unitOfWork;
}
