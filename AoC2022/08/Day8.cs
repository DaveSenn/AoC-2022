using System.Diagnostics.CodeAnalysis;

[SuppressMessage( "ReSharper", "UnusedType.Global" )]
public sealed partial class Day8 : IDay
{
    private static readonly Direction Down = new(1, 0);

    private static readonly Direction Left = new(0, -1);
    private static readonly Direction Right = new(0, 1);
    private static readonly Direction Up = new(-1, 0);

    private Int32 V1()
    {
        var forest = Parse();

        return forest.Trees()
                     .Count( tree =>
                                 forest.IsTallest( tree, Left ) || forest.IsTallest( tree, Right ) ||
                                 forest.IsTallest( tree, Up ) || forest.IsTallest( tree, Down )
                     );
    }

    private Int32 V2()
    {
        var forest = Parse();

        return forest.Trees()
                     .Select( tree =>
                                  forest.ViewDistance( tree, Left ) * forest.ViewDistance( tree, Right ) *
                                  forest.ViewDistance( tree, Up ) * forest.ViewDistance( tree, Down )
                     )
                     .Max();
    }

    private Forest Parse()
    {
        var items = Input.Split( Environment.NewLine );
        var (ccol, crow) = ( items[0]
            .Length, items.Length );
        return new(items, crow, ccol);
    }

    internal record Direction( Int32 Drow, Int32 Dcol );

    internal record Forest( String[] Items, Int32 Crow, Int32 Ccol )
    {
        public Boolean IsTallest( Tree tree, Direction dir ) =>
            TreesInDirection( tree, dir )
                .All( treeT => treeT.Height < tree.Height );

        public IEnumerable<Tree> Trees() =>
            Enumerable.Range( 0, Crow )
                      .SelectMany( irow => Enumerable.Range( 0, Ccol ), ( irow, icol ) => new Tree( Items[irow][icol], irow, icol ) );

        public Int32 ViewDistance( Tree tree, Direction dir ) =>
            IsTallest( tree, dir )
                ? TreesInDirection( tree, dir )
                    .Count()
                : SmallerTrees( tree, dir )
                    .Count() + 1;

        private IEnumerable<Tree> SmallerTrees( Tree tree, Direction dir ) =>
            TreesInDirection( tree, dir )
                .TakeWhile( treeT => treeT.Height < tree.Height );

        private IEnumerable<Tree> TreesInDirection( Tree tree, Direction dir )
        {
            var (first, irow, icol) = ( true, irow: tree.Irow, icol: tree.Icol );
            while ( irow >= 0 && irow < Crow && icol >= 0 && icol < Ccol )
            {
                if ( !first )
                    yield return new(Items[irow][icol], irow, icol);
                ( first, irow, icol ) = ( false, irow + dir.Drow, icol + dir.Dcol );
            }
        }
    }

    internal record Tree( Int32 Height, Int32 Irow, Int32 Icol );

    #region Implementation of IDay

    public ValueTask Run()
    {
        Console.WriteLine( V1() );
        Console.WriteLine( V2() );

        return ValueTask.CompletedTask;
    }

    public Int32 Day => 8;

    #endregion
}