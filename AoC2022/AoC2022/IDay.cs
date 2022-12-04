public interface IDay
{
    Int32 Day { get; }
    ValueTask Run();
}