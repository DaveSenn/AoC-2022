using System.Diagnostics.CodeAnalysis;
using System.Text;

[SuppressMessage( "ReSharper", "UnusedType.Global" )]
public sealed partial class Day10 : IDay
{
    private static IEnumerable<(Int32 cycle, Int32 x)> ParseInput( String input )
    {
        var (cycle, x) = ( 1, 1 );
        foreach ( var z in input
                           .Split( Environment.NewLine )
                           .Select( value => value switch
                           {
                               not null when value.StartsWith( "addx", StringComparison.Ordinal ) => (Int32?) Int32.Parse( value.Split( ' ' )[1] ),
                               _ => null
                           } ) )
            switch ( z )
            {
                case null:
                    yield return ( cycle++, x );
                    break;
                default:
                    yield return ( cycle++, x );
                    yield return ( cycle++, x );
                    x += z.Value;
                    break;
            }
    }

    private static Int32 V1() =>
        ParseInput( Input )
            .Sum( x => x.cycle switch
            {
                20 or 60 or 100 or 140 or 180 or 220 => x.cycle * x.x,
                _ => 0
            } );

    private static String V2()
    {
        var sb = new StringBuilder( 6 * 40 );
        foreach ( var (cycle, x) in ParseInput( Input ) )
        {
            var col = ( cycle - 1 ) % 40;
            sb.Append( Math.Abs( x - col ) < 3 - 1 ? "#" : "." );
            if ( col == 39 )
                sb.AppendLine();
        }

        return sb.ToString();
    }

    #region Implementation of IDay

    public ValueTask Run()
    {
        Console.WriteLine( V1() );
        Console.WriteLine( V2() );

        return ValueTask.CompletedTask;
    }

    public Int32 Day => 10;

    #endregion
}