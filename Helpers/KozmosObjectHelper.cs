using System;
using System.Runtime.CompilerServices;

namespace Kozmos.Helpers
{
	public static class KozmosObjectHelper
	{
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean TryCast<T>(Object? source, out T result) { return KozmosObjectHelper<T>.TryCast(source, out result); }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T Cast<T>(Object source) { return KozmosObjectHelper<T>.Cast(source); }
    }
}