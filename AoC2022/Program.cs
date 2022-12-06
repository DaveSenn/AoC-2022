var days = AppDomain
           .CurrentDomain.GetAssemblies()
           .SelectMany( x => x.GetTypes() )
           .Where( x => typeof(IDay).IsAssignableFrom( x ) && x.IsClass )
           .Select( x => (IDay) Activator.CreateInstance( x )! )
           .OrderBy( x => x.Day );
foreach ( var day in days )
{
    Console.WriteLine( "***************************************************" );
    Console.WriteLine( $"Day {day.Day}" );
    Console.WriteLine( "***************************************************" );
    await day.Run();

    Console.WriteLine();
    Console.WriteLine();
    Console.WriteLine();
}

try
{
    Console.WriteLine( "Done..." );
    Console.ReadLine();
}
catch
{
    // ignored
}