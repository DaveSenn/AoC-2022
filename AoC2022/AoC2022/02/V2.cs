using System.Diagnostics.CodeAnalysis;

[SuppressMessage( "ReSharper", "UnusedType.Global" )]
public sealed partial class Day2
{
    private static void V2()
    {
        var points = 0;
        foreach ( var line in Input.Split( Environment.NewLine, StringSplitOptions.RemoveEmptyEntries ) )
        {
            var signs = line.Split( ' ', StringSplitOptions.RemoveEmptyEntries );

            var expectedResult = signs[1] switch
            {
                "X" => GameResult.Lose,
                "Y" => GameResult.Draw,
                "Z" => GameResult.Win,
                _ => throw new ArgumentOutOfRangeException()
            };
            points += GetGameResultPoints( expectedResult );

            var mySign = GetSignBasedOnResult( signs[0], expectedResult );
            points += GetSignValue( mySign );
        }

        Console.WriteLine( $"Points: {points}" );
    }
}