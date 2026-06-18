using System;
using System.Runtime.CompilerServices;

namespace Kozmos.Helpers
{
	public sealed class KozmosStringHelper
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean TryFormat(String? source, Object? arg, out String? formatted)
        {
            if (source is null) { formatted = null; return false; }
            formatted = String.Format(source, arg);
            return true;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean TryFormat(String? source, Object? arg0, Object? arg1, out String? formatted)
        {
            if (source is null) { formatted = null; return false; }
            formatted = String.Format(source, arg0, arg1);
            return true;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean TryFormat(String? source, Object? arg0, Object? arg1, Object? arg2, out String? formatted)
        {
            if (source is null) { formatted = null; return false; }
            formatted = String.Format(source, arg0, arg1, arg2);
            return true;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean TryFormat(String? source, Object?[]? args, out String? formatted)
        {
            if(source is null) { formatted = null; return false; }
            formatted = args is not null && args.Length > 0 ? String.Format(source, args) : source;
            return true;
        }
    }
}