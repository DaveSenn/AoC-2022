using System.Diagnostics.CodeAnalysis;
using System.Text.RegularExpressions;

[SuppressMessage( "ReSharper", "UnusedType.Global" )]
public sealed partial class Day5
{
    [GeneratedRegex( @"move (.*) from (.*) to (.*)", RegexOptions.IgnoreCase | RegexOptions.Compiled )]
    private static partial Regex MoveRegex();

    private static void V1()
    {
        var instructionParts = Input.Split( $"{Environment.NewLine}{Environment.NewLine}" );
        Stack<Char>[]? stacks = null;
        foreach ( var line in instructionParts[0]
                              .Split( Environment.NewLine )
                              .Reverse()
                              .Skip( 1 ) )
        {
            stacks ??= Enumerable.Range( 0,
                                         line
                                             .Chunk( 4 )
                                             .Count() )
                                 .Select( _ => new Stack<Char>() )
                                 .ToArray();

            foreach ( var (stack, container) in stacks
                                                .Zip( line.Chunk( 4 ) )
                                                .Where( x => x.Second[1] != ' ' ) )
                stack.Push( container[1] );
        }

        foreach ( var matches in instructionParts[1]
                                 .Split( Environment.NewLine )
                                 .Select( x => MoveRegex()
                                              .Match( x ) ) )
        {
            var source = stacks![Int32.Parse( matches.Groups[2]
                                                     .Value ) - 1];
            var target = stacks[Int32.Parse( matches.Groups[3]
                                                    .Value ) - 1];
            for ( var i = 0; i < Int32.Parse( matches.Groups[1]
                                                     .Value ); i++ )
                target.Push( source.Pop() );
        }

        var result = new String( stacks!.Select( x => x.Pop() )
                                        .ToArray() );
        Console.WriteLine( $"Container sequence: {result}" );
    }
}
