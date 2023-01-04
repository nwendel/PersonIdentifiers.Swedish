﻿using System;
using System.Collections.Generic;
using System.Linq;
using ArchUnit;
using ArchUnit.Rules;
using PersonIdentifiers.Swedish.LocalReserveNumbers;
using Xunit;

namespace PersonIdentifiers.Swedish.Tests.Conventions;

public class PersonIdentifiersParseConventionTests
{
    private static readonly IEnumerable<Type> _personIdentifierTypes = typeof(PersonIdentifier).Assembly
        .GetTypes()
        .Where(x => x.IsAssignableTo(typeof(PersonIdentifier)) && x != typeof(LocalReserveNumber))
        .ToList();

    [Fact]
    public void HasPublicStaticParseMethod()
    {
        ConventionAssert.TypesFollow<HasPublicStaticParseMethod>(_personIdentifierTypes);
    }

    [Fact]
    public void HasStaticTryParseMethod()
    {
        ConventionAssert.TypesFollow<HasPublicStaticTryParseMethod>(_personIdentifierTypes);
    }
}
