using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using Kozmos.Constants;

namespace Kozmos.Helpers.Exceptions
{
	public static class KozmosExceptionHelper
	{
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static TResult MakeSafe<TContext, TResult>(TContext context, Func<TContext, TResult> func)
		{
			KozmosArgumentNullExceptionHelper.ThrowIfNull(func);
			try { return func.Invoke(context); } catch { return default(TResult); }
		}

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void ThrowValue_0_OfMember_1_2_OfArgument_3_4_IsNotSupported<TValue, TArgument>
        (
            TValue? value,
            TArgument? argument,
            [CallerArgumentExpression(nameof(value))] String? memberName = null,
            [CallerArgumentExpression(nameof(argument))] String? argumentName = null
        )
        {
            ThrowValue_0_OfMember_1_2_OfArgument_3_4_IsNotSupported
            (
                value,
                memberName,
                argument,
                argumentName
            );
        }

        [DoesNotReturn]
        [MethodImpl(MethodImplOptions.NoInlining)]
        internal static void ThrowValue_0_OfMember_1_2_OfArgument_3_4_IsNotSupported<TValue, TArgument>
        (
            TValue? value,
            String? memberName,
            TArgument? argument,
            [CallerArgumentExpression(nameof(argument))] String? argumentName = null
        )
        {
            KozmosArgumentExceptionHelper.Throw
            (
                KozmosMessages.Exceptions.Value_0_OfMember_1_2_OfArgument_3_4_IsNotSupported,
                value?.ToString() ?? KozmosStrings.Null,
                memberName ?? KozmosStrings.Null,
                KozmosTypeHelper.TryGetFullNameOrName(value, out String memberTypeFullNameOrName) ? memberTypeFullNameOrName : KozmosStrings.Null,
                argumentName ?? KozmosStrings.Null,
                KozmosTypeHelper.TryGetFullNameOrName(argument, out String argumentTypeFullNameOrName) ? argumentTypeFullNameOrName : KozmosStrings.Null
            );
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void ThrowTheTypeParameter_0_1_IsNotSupported<T>()
        {
            KozmosExceptionHelper<T>.ThrowTheTypeParameter_0_1_IsNotSupported();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void ThrowTheTypeParameter_0_1_IsNotSupported<T>(String? typeParameterName)
        {
            KozmosExceptionHelper<T>.ThrowTheTypeParameter_0_1_IsNotSupported(typeParameterName);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void ThrowTheTypeParameter_0_1_IsNotRegisteredInTheCache<T>()
        {
            KozmosExceptionHelper<T>.ThrowTheTypeParameter_0_1_IsNotRegisteredInTheCache();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void ThrowTheTypeParameter_0_1_IsNotRegisteredInTheCache<T>(String? typeParameterName)
        {
            KozmosExceptionHelper<T>.ThrowTheTypeParameter_0_1_IsNotRegisteredInTheCache(typeParameterName);
        }

        [DoesNotReturn]
        [MethodImpl(MethodImplOptions.NoInlining)]
        internal static void ThrowTheTypeParameter_0_1_IsNotSupported(String? name, Type? type)
        {
            KozmosNotSupportedExceptionHelper.Throw
            (
                KozmosMessages.Exceptions.TheTypeParameter_0_1_IsNotSupported,
                name ?? KozmosStrings.Null,
                KozmosTypeHelper.TryGetFullNameOrName(type, out String typeFullNameOrName) ? typeFullNameOrName : KozmosStrings.Null
            );
        }

        [DoesNotReturn]
        [MethodImpl(MethodImplOptions.NoInlining)]
        internal static void ThrowTheTypeParameter_0_1_IsNotRegisteredInTheCache(String? name, Type? type)
        {
            KozmosNotSupportedExceptionHelper.Throw
            (
                KozmosMessages.Exceptions.TheTypeParameter_0_1_IsNotRegisteredInTheCache,
                name ?? KozmosStrings.Null,
                KozmosTypeHelper.TryGetFullNameOrName(type, out String typeFullNameOrName) ? typeFullNameOrName : KozmosStrings.Null
            );
        }
    }
}

