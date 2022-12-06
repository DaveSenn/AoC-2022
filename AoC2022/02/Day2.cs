using System.Diagnostics.CodeAnalysis;

[SuppressMessage( "ReSharper", "UnusedType.Global" )]
public sealed partial class Day2 : IDay
{
    public enum GameResult
    {
        Lose = 0,
        Draw = 1,
        Win = 2
    }

    private static GameResult GetGameResult( String elf, String me ) =>
        ( elf, me ) switch
        {
            ("A", "X") => GameResult.Draw,
            ("B", "X") => GameResult.Lose,
            ("C", "X") => GameResult.Win,

            ("A", "Y") => GameResult.Win,
            ("B", "Y") => GameResult.Draw,
            ("C", "Y") => GameResult.Lose,

            ("A", "Z") => GameResult.Lose,
            ("B", "Z") => GameResult.Win,
            ("C", "Z") => GameResult.Draw,

            _ => throw new ArgumentOutOfRangeException()
        };

    private static Int32 GetGameResultPoints( GameResult gameResult )
        => gameResult switch
        {
            GameResult.Lose => 0,
            GameResult.Draw => 3,
            GameResult.Win => 6,
            _ => throw new ArgumentOutOfRangeException()
        };

    private static String GetSignBasedOnResult( String elf, GameResult result )
        => ( elf, result ) switch
        {
            ("A", GameResult.Lose) => "Z",
            ("A", GameResult.Draw) => "X",
            ("A", GameResult.Win) => "Y",

            ("B", GameResult.Lose) => "X",
            ("B", GameResult.Draw) => "Y",
            ("B", GameResult.Win) => "Z",

            ("C", GameResult.Lose) => "Y",
            ("C", GameResult.Draw) => "Z",
            ("C", GameResult.Win) => "X",

            _ => throw new ArgumentOutOfRangeException()
        };

    private static Int32 GetSignValue( String sign )
        => sign switch
        {
            "X" => 1,
            "Y" => 2,
            "Z" => 3,
            _ => throw new ArgumentOutOfRangeException()
        };

    #region Implementation of IDay

    public ValueTask Run()
    {
        V1();
        V2();

        return ValueTask.CompletedTask;
    }

    public Int32 Day => 2;

    #endregion
}