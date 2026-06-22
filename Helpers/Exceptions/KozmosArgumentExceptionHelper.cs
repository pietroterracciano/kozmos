using System;
using System.Runtime.CompilerServices;
using System.Diagnostics.CodeAnalysis;
using Kozmos.Constants;

namespace Kozmos.Helpers.Exceptions
{
    public static class KozmosArgumentExceptionHelper
    {
        #region public static void Throw...(...)

        [DoesNotReturn]
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void Throw()
        {
            throw new ArgumentException();
        }

        [DoesNotReturn]
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void Throw(String? message)
        {
            throw new ArgumentException(message);
        }

        [DoesNotReturn]
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void Throw(String? message, Object? arg)
        {
            KozmosStringHelper.TryFormat(message, arg, out var formatted);
            throw new ArgumentException(formatted);
        }

        [DoesNotReturn]
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void Throw(String? message, Object? arg0, Object? arg1)
        {
            KozmosStringHelper.TryFormat(message, arg0, arg1, out var formatted);
            throw new ArgumentException(formatted);
        }

        [DoesNotReturn]
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void Throw(String? message, Object? arg0, Object? arg1, Object? arg2)
        {
            KozmosStringHelper.TryFormat(message, arg0, arg1, arg2, out var formatted);
            throw new ArgumentException(formatted);
        }

        [DoesNotReturn]
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void Throw(String? message, params Object?[] args)
        {
            KozmosStringHelper.TryFormat(message, args, out var formatted);
            throw new ArgumentException(formatted);
        }

        #endregion

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void ThrowValue_0_OfArgument_1_2_IsNotSupported
        (
            Object? value,
            [CallerArgumentExpression(nameof(value))] String? argumentName = null
        )
        {
            Throw
            (
                KozmosMessages.Exceptions.Value_0_OfArgument_1_2_IsNotSupported,
                value?.ToString() ?? KozmosStrings.Null,
                argumentName ?? KozmosStrings.Null,
                KozmosTypeHelper.TryGetFullNameOrName(value, out String valueTypeName) ? valueTypeName : KozmosStrings.Null
            );
        }
    }
}

