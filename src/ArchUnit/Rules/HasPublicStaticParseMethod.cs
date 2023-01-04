﻿namespace ArchUnit.Rules;

public class HasPublicStaticParseMethod : ITypeConvention
{
    private const string _methodName = nameof(int.Parse);

    public void Assert(Type type, ConventionContext context)
    {
        var method = type.GetMethod(_methodName, System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Static, new[] { typeof(string) });
        if (method == null || method.ReturnType != type)
        {
            context.Fail(type, $"must have a public static method with signature: {type.Name} {_methodName}({nameof(String)})");
        }
    }
}
