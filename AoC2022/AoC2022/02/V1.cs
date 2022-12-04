using System.Diagnostics.CodeAnalysis;

[SuppressMessage( "ReSharper", "UnusedType.Global" )]
public sealed partial class Day2
{
    private static void V1()
    {
        var points = 0;
        foreach ( var line in Input.Split( Environment.NewLine, StringSplitOptions.RemoveEmptyEntries ) )
        {
            var signs = line.Split( ' ', StringSplitOptions.RemoveEmptyEntries );
            var gameResult = GetGameResult( signs[0], signs[1] );
            points += GetGameResultPoints( gameResult );
            points += GetSignValue( signs[1] );
        }

        Console.WriteLine( $"Points: {points}" );
    }
}