using System.Diagnostics.CodeAnalysis;

[SuppressMessage( "ReSharper", "UnusedType.Global" )]
public sealed partial class Day7 : IDay
{
    private static Dictionary<String, UInt32> GetDirSizes()
    {
        var lines = Input.SplitLines2();

        var dirs = new Dictionary<String, UInt32>( 256 );
        var currentLocation = String.Empty;
        var dirLocations = new Stack<String>( 16 );
        while ( lines.MoveNext() )
        {
            var currentLine = lines.Current;

            if ( currentLine.Length == 7
                 && currentLine[0] == '$'
                 && currentLine[1] == ' '
                 && currentLine[2] == 'c'
                 && currentLine[3] == 'd'
                 && currentLine[4] == ' '
                 && currentLine[5] == '.'
                 && currentLine[6] == '.' )
            {
                dirLocations.Pop();
                var end = currentLocation.LastIndexOf( '/' );
                currentLocation = currentLocation[..( end + 1 )];
                continue;
            }

            if ( currentLine.Length >= 6
                 && currentLine[0] == '$'
                 && currentLine[1] == ' '
                 && currentLine[2] == 'c'
                 && currentLine[3] == 'd' )
            {
                var dirName = currentLine[5..];
                currentLocation = $"{currentLocation}/{dirName}";
                dirLocations.Push( currentLocation );
                continue;
            }

            // ReSharper disable once InvertIf
            if ( Char.IsNumber( currentLine[0] ) )
            {
                var size = UInt32.Parse( currentLine[..currentLine.IndexOf( ' ' )] );

                foreach ( var dir in dirLocations )
                    if ( dirs.TryGetValue( dir, out var subTotal ) )
                        dirs[dir] = subTotal + size;
                    else
                        dirs[dir] = size;
            }
        }

        return dirs;
    }

    #region Implementation of IDay

    public ValueTask Run()
    {
        var dirs = GetDirSizes();

        UInt32 result0 = 0;
        foreach ( var (_, x) in dirs )
            if ( x < 100_000 )
                result0 += x;

        var current = 70000000 - dirs.Max( x => x.Value );
        var result1 = dirs
                      .Where( x => x.Value + current >= 30000000 )
                      .Min( x => x.Value );

        Console.WriteLine( $"Index of first unique sequence: {result0}" );
        Console.WriteLine( $"Index of first unique sequence: {result1}" );

        return ValueTask.CompletedTask;
    }

    public Int32 Day => 7;

    #endregion
}