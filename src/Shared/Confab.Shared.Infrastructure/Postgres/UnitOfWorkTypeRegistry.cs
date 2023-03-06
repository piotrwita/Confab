using System;
using System.Collections.Generic;

namespace Confab.Shared.Infrastructure.Postgres;

//rejestr ktory mowi ze dla typu znajduje sie w obrebie danego modulu i  w tym module jest zarejestrowany taki unitofwork ktoy moge wyciagnac
internal class UnitOfWorkTypeRegistry
{
    private readonly Dictionary<string, Type> _types = new();

    //rekestracka nitofwork
    public void Register<T>() where T : IUnitOfWork => _types[GetKey<T>()] = typeof(T);

    //chce dostac typ unitofwork
    public Type Resolve<T>() => _types.TryGetValue(GetKey<T>(), out var type) ? type : null;

    private static string GetKey<T>() => $"{typeof(T).GetModuleName()}";
}