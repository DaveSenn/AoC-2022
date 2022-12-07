public static class StringEx
{
    public static LineSplitEnumerator SplitLines2( this String str ) =>
        new(str.AsSpan());

    public ref struct LineSplitEnumerator
    {
        private ReadOnlySpan<Char> _str;

        public LineSplitEnumerator( ReadOnlySpan<Char> str )
        {
            _str = str;
            Current = default;
        }

        public Boolean MoveNext()
        {
            var span = _str;
            if ( span.Length == 0 )
                return false;

            var index = span.IndexOfAny( '\r', '\n' );
            if ( index == -1 )
            {
                _str = ReadOnlySpan<Char>.Empty;
                Current = span;
                return true;
            }

            if ( index < span.Length - 1 && span[index] == '\r' )
            {
                var next = span[index + 1];
                if ( next == '\n' )
                {
                    Current = span[..index];
                    _str = span[( index + 2 )..];
                    return true;
                }
            }

            Current = span[..index];
            _str = span[( index + 1 )..];
            return true;
        }

        public ReadOnlySpan<Char> Current { get; private set; }
    }
}