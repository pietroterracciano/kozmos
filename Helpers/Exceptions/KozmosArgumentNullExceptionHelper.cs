using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using Kozmos.Constants;

namespace Kozmos.Helpers.Exceptions
{
    public static class KozmosArgumentNullExceptionHelper
    {
        #region Throw

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Throw<T>(T source, [CallerArgumentExpression(nameof(source))] String? paramName = null)
            where T : struct
        {
            ThrowCore(paramName);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Throw(Object? source, [CallerArgumentExpression(nameof(source))] String? paramName = null)
        {
            ThrowCore(paramName);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ThrowIfNull<T>(T? source, [CallerArgumentExpression(nameof(source))] String? paramName = null)
            where T : struct
        {
            if (source.HasValue) return;
            ThrowCore(paramName);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ThrowIfNull(Object? source, [CallerArgumentExpression(nameof(source))] String? paramName = null)
        {
            if (source is null) ThrowCore(paramName);
        }

        #endregion

        #region ThrowCore

        [DoesNotReturn]
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void ThrowCore()
        {
            throw new ArgumentNullException();
        }

        [DoesNotReturn]
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void ThrowCore(String? paramName) { throw new ArgumentNullException(paramName); }

        [DoesNotReturn]
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void ThrowCore(String? paramName, String? message)
        {
            throw new ArgumentNullException(paramName, message);
        }

        [DoesNotReturn]
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void ThrowCore(String? paramName, String? message, Object? arg)
        {
            KozmosStringHelper.TryFormat(message, arg, out String? formatted);
            throw new ArgumentNullException(paramName, formatted);
        }

        [DoesNotReturn]
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void ThrowCore(String? paramName, String? message, Object? arg0, Object? arg1)
        {
            KozmosStringHelper.TryFormat(message, arg0, arg1, out String? formatted);
            throw new ArgumentNullException(paramName, formatted);
        }

        [DoesNotReturn]
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void ThrowCore(String? paramName, String? message, Object? arg0, Object? arg1, Object? arg2)
        {
            KozmosStringHelper.TryFormat(message, arg0, arg1, arg2, out String? formatted);
            throw new ArgumentNullException(paramName, formatted);
        }

        [DoesNotReturn]
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void ThrowCore(String? paramName, String? message, params Object?[] args)
        {
            KozmosStringHelper.TryFormat(message, args, out String? formatted);
            throw new ArgumentNullException(paramName, formatted);
        }

        #endregion
    }
}