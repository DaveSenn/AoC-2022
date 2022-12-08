using System.Diagnostics.CodeAnalysis;

[SuppressMessage( "ReSharper", "UnusedType.Global" )]
public sealed partial class Day4
{
    private static void V1()
    {
        var result = Input
                     .Split( Environment.NewLine )
                     .Select( x => x.Split( ',', '-' ) )
                     .Select( x => new
                     {
                         E0 = new Range( Int32.Parse( x[0] ), Int32.Parse( x[1] ) ),
                         E1 = new Range( Int32.Parse( x[2] ), Int32.Parse( x[3] ) )
                     } )
                     .Count( x => x.E0.Start.Value <= x.E1.Start.Value && x.E0.End.Value >= x.E1.End.Value
                                  || x.E1.Start.Value <= x.E0.Start.Value && x.E1.End.Value >= x.E0.End.Value );

        Console.WriteLine( $"Overlapping groups {result}" );
    }
}