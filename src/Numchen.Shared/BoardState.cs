using System.Collections.Immutable;

namespace Numchen.Shared;

public record BoardState(
    IImmutableList<IImmutableStack<int>> Columns,
    IImmutableList<int> Goals);
