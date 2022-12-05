using System.Diagnostics.CodeAnalysis;

[SuppressMessage( "ReSharper", "UnusedType.Global" )]
public sealed partial class Day5
{
    private static void V2()
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

            foreach ( var container in Enumerable
                                       .Range( 0,
                                               Int32.Parse( matches.Groups[1]
                                                                   .Value ) )
                                       .Select( x => source.Pop() )
                                       .Reverse() )
                target.Push( container );
        }

        var result = new String( stacks!.Select( x => x.Pop() )
                                        .ToArray() );
        Console.WriteLine( $"Container sequence: {result} Mover 9001" );
    }
}