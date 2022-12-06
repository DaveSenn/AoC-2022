using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;

[SuppressMessage( "ReSharper", "UnusedType.Global" )]
public sealed partial class Day3
{
    private static void V2()
    {
        var result = Input
                     .Split( Environment.NewLine )
                     .Select( x => x
                                   .ToArray()
                                   .Select( y => y - ( Char.IsUpper( y ) ? 38 : 96 ) )
                                   .ToImmutableHashSet() )
                     .Chunk( 3 )
                     .Select( x => x[0]
                                   .Intersect( x[1] )
                                   .Intersect( x[2] )
                                   .Single() )
                     .Sum();

        Console.WriteLine( $"Sum of badge items: {result}" );
    }
}