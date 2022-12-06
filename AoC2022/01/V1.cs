using System.Diagnostics.CodeAnalysis;

[SuppressMessage( "ReSharper", "UnusedType.Global" )]
public sealed partial class Day1
{
    private static void V1()
    {
        var maxCalories = 0;
        var subTotal = 0;
        foreach ( var line in Input.Split( Environment.NewLine ) )
        {
            if ( line == String.Empty )
            {
                if ( subTotal > maxCalories )
                    maxCalories = subTotal;

                subTotal = 0;
                continue;
            }

            subTotal += Int32.Parse( line );
        }

        Console.WriteLine( $"V1: {maxCalories} calories" );
    }
}