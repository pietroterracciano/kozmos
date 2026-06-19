using System;
using System.Runtime.CompilerServices;
using Kozmos.Constants;
using Kozmos.Helpers.Exceptions;

namespace Kozmos.Helpers
{
	public static class KozmosObjectHelper
	{
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean TryCast<T>(Object? source, out T result)
        {
            // HotPath >
            if (source is T o) { result = o; return true; }
            // < HotPath
            else if (source is null) { result = default!; return KozmosTypeHelper<T>.IsNullable; }
            else { result = default!; return false; }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T Cast<T>(Object source)
        {
            // HotPath >
            if (source is T o) return o;
            // < HotPath
            KozmosArgumentNullExceptionHelper.ThrowIfNull(source);
            KozmosArgumentExceptionHelper.Throw
            (
                KozmosMessages.Exceptions.UnableToCastArgument_0_OfType_1_ToType_2,
                nameof(source),
                source.GetType(),
                KozmosTypeHelper<T>._
            );
            return default!;
        }
    }
}