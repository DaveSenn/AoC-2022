using System.Diagnostics.CodeAnalysis;

[SuppressMessage( "ReSharper", "UnusedType.Global" )]
public sealed partial class Day4 : IDay
{
    #region Implementation of IDay

    public ValueTask Run()
    {
        V1();
        V2();

        return ValueTask.CompletedTask;
    }

    public Int32 Day => 4;

    #endregion
}