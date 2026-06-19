using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using Kozmos.Constants;

namespace Kozmos.Helpers.Exceptions
{
    public static class KozmosArgumentOutOfRangeExceptionHelper
    {
        #region public static void Throw...(...)

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Throw() { Throw(null); }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void Throw
        (
            Object? source,
            [CallerArgumentExpression(nameof(source))] String? paramName = null
        )
        {
            Throw(paramName);
        }

        [DoesNotReturn]
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void Throw(String? paramName) { throw new ArgumentOutOfRangeException(paramName); }

        [DoesNotReturn]
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void Throw(String? paramName, String? message)
        {
            if (message is not null) message = KozmosMessages.LogPrefix + KozmosStrings.Space + message;
            throw new ArgumentOutOfRangeException(paramName, message);
        }

        [DoesNotReturn]
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void Throw(String? paramName, String? message, Object? arg)
        {
            if (message is not null) message = KozmosMessages.LogPrefix + KozmosStrings.Space + message;
            KozmosStringHelper.TryFormat(message, arg, out var formatted);
            throw new ArgumentOutOfRangeException(paramName, formatted);
        }

        [DoesNotReturn]
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void Throw(String? paramName, String? message, Object? arg0, Object? arg1)
        {
            if (message is not null) message = KozmosMessages.LogPrefix + KozmosStrings.Space + message;
            KozmosStringHelper.TryFormat(message, arg0, arg1, out var formatted);
            throw new ArgumentOutOfRangeException(paramName, formatted);
        }

        [DoesNotReturn]
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void Throw(String? paramName, String? message, Object? arg0, Object? arg1, Object? arg2)
        {
            if (message is not null) message = KozmosMessages.LogPrefix + KozmosStrings.Space + message;
            KozmosStringHelper.TryFormat(message, arg0, arg1, arg2, out var formatted);
            throw new ArgumentOutOfRangeException(paramName, formatted);
        }

        [DoesNotReturn]
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void Throw(String? paramName, String? message, params Object?[] args)
        {
            if (message is not null) message = KozmosMessages.LogPrefix + KozmosStrings.Space + message;
            KozmosStringHelper.TryFormat(message, args, out var formatted);
            throw new ArgumentOutOfRangeException(paramName, formatted);
        }

        #endregion
    }
}

