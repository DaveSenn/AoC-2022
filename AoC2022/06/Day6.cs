using System.Diagnostics.CodeAnalysis;

[SuppressMessage( "ReSharper", "UnusedType.Global" )]
public sealed partial class Day6 : IDay
{
    private static Int32 GetResult( Int32 length )
    {
        var set = new HashSet<Char>( length );
        for ( var i = length; i < Input.Length; i++ )
        {
            set.UnionWith( Input.Substring( i - length, length ) );
            if ( set.Count == length )
                return i;

            set.Clear();
        }

        return -1;
    }

    #region Implementation of IDay

    public ValueTask Run()
    {
        Console.WriteLine( $"Index of first unique sequence: {GetResult( 4 )}" );
        Console.WriteLine( $"Index of first unique sequence: {GetResult( 14 )}" );

        return ValueTask.CompletedTask;
    }

    public Int32 Day => 6;

    #endregion
}