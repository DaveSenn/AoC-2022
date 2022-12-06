using System.Diagnostics.CodeAnalysis;

[SuppressMessage( "ReSharper", "UnusedType.Global" )]
public sealed partial class Day1
{
    private static void V2()
    {
        var totals = new List<Int32>();
        var subTotal = 0;
        foreach ( var line in Input.Split( Environment.NewLine ) )
        {
            if ( line == String.Empty )
            {
                totals.Add( subTotal );
                subTotal = 0;
                continue;
            }

            subTotal += Int32.Parse( line );
        }

        var top3Total = totals
                        .OrderByDescending( x => x )
                        .Take( 3 )
                        .Sum();

        Console.WriteLine( $"V2: {top3Total} calories" );
    }
}