using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;

[SuppressMessage( "ReSharper", "UnusedType.Global" )]
public sealed partial class Day3
{
    private static void V1()
    {
        var result = Input
                     .Split( Environment.NewLine )
                     .Select( x => x.ToArray() )
                     .Select( x => x
                                   .Select( y => y - ( Char.IsUpper( y ) ? 38 : 96 ) )
                                   .Chunk( x.Length / 2 )
                                   .Select( y => new HashSet<Int32>( y ).ToImmutableHashSet() )
                                   .Aggregate( ( y, z ) => y.Intersect( z ) )
                                   .Sum() )
                     .Sum( x => x );

        Console.WriteLine( $"Sum of priorities {result}" );
    }
}