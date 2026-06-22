using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using Kozmos.Constants;

namespace Kozmos.Helpers.Exceptions
{
    public static class KozmosInvalidOperationExceptionHelper
    {
        #region public static void Throw(...)

        [DoesNotReturn]
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void Throw()
        {
            throw new InvalidOperationException();
        }

        [DoesNotReturn]
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void Throw(String? message)
        {
            throw new InvalidOperationException(message);
        }

        [DoesNotReturn]
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void Throw(String? message, Object? arg)
        {
            KozmosStringHelper.TryFormat(message, arg, out var formatted);
            throw new InvalidOperationException(formatted);
        }

        [DoesNotReturn]
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void Throw(String? message, Object? arg0, Object? arg1)
        {
            KozmosStringHelper.TryFormat(message, arg0, arg1, out var formatted);
            throw new InvalidOperationException(formatted);
        }

        [DoesNotReturn]
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void Throw(String? message, Object? arg0, Object? arg1, Object? arg2)
        {
            KozmosStringHelper.TryFormat(message, arg0, arg1, arg2, out var formatted);
            throw new InvalidOperationException(formatted);
        }

        [DoesNotReturn]
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void Throw(String? message, params Object?[] args)
        {
            KozmosStringHelper.TryFormat(message, args, out var formatted);
            throw new InvalidOperationException(formatted);
        }

        #endregion

        #region public static void ThrowIfNull(...)

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ThrowIfNull<T>(T? source)
        {
            if (source is not null) return;
            Throw();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ThrowIfNull<T>(T? source, String? message)
        {
            if (source is not null) return;
            Throw(message);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ThrowIfNull<T>(T? source, String? message, Object? arg)
        {
            if (source is not null) return;
            Throw(message, arg);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ThrowIfNull<T>(T? source, String? message, Object? arg0, Object? arg1)
        {
            if (source is not null) return;
            Throw(message, arg0, arg1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ThrowIfNull<T>(T? source, String? message, Object? arg0, Object? arg1, Object? arg2)
        {
            if (source is not null) return;
            Throw(message, arg0, arg1, arg2);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ThrowIfNull<T>(T? source, String? message, params Object?[] args)
        {
            if (source is not null) return;
            Throw(message, args);
        }

        #endregion
    }
}