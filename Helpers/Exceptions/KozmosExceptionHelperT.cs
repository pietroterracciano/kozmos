using System;
using Kozmos.Constants;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Xml.Linq;

namespace Kozmos.Helpers.Exceptions
{
	public static class KozmosExceptionHelper<T>
	{
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void ThrowTheTypeParameter_0_1_IsNotSupported()
        {
            ThrowTheTypeParameter_0_1_IsNotSupported(null);
        }

        [DoesNotReturn]
        [MethodImpl(MethodImplOptions.NoInlining)]
        internal static void ThrowTheTypeParameter_0_1_IsNotSupported(String? name)
        {
            KozmosExceptionHelper.ThrowTheTypeParameter_0_1_IsNotSupported(name, KozmosTypeHelper<T>._);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void ThrowTheTypeParameter_0_1_IsNotRegisteredInTheCache()
        {
            ThrowTheTypeParameter_0_1_IsNotRegisteredInTheCache(null);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void ThrowTheTypeParameter_0_1_IsNotRegisteredInTheCache(String? name)
        {
            KozmosExceptionHelper.ThrowTheTypeParameter_0_1_IsNotRegisteredInTheCache(name, KozmosTypeHelper<T>._);
        }
    }
}