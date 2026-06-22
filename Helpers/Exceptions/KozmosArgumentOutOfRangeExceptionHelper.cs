using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Numerics;
using System.Runtime.CompilerServices;
using Kozmos.Constants;
using Kozmos.Helpers.Numericals;

namespace Kozmos.Helpers.Exceptions
{
    public static class KozmosArgumentOutOfRangeExceptionHelper
    {
        #region public static void Throw...(...)

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ThrowIfEqual<T>(T value, T other)
        {
            ThrowIfEqual(value, other, null);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ThrowIfEqual<T>(T value, T other, String? paramName)
        {
            if (EqualityComparer<T>.Default.Equals(value, other)) Throw(paramName);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ThrowIfNotEqual<T>(T value, T other)
        {
            ThrowIfNotEqual(value, other, null);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ThrowIfNotEqual<T>(T value, T other, String? paramName)
        {
            if (!EqualityComparer<T>.Default.Equals(value, other)) Throw(paramName);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ThrowIfLessThan<T>(T value, T other)
            where T : INumber<T>
        {
            ThrowIfLessThan(value, other, null);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ThrowIfLessThan<T>(T value, T other, String? paramName)
            where T : INumber<T>
        {
            if (value < other) Throw(paramName);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ThrowIfLessThanOrEqual<T>(T value, T other)
            where T : INumber<T>
        {
            ThrowIfLessThanOrEqual(value, other, null);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ThrowIfLessThanOrEqual<T>(T value, T other, String? paramName)
            where T : INumber<T>
        {
            if (value > other) return;
            Throw(paramName);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ThrowIfGreaterThan<T>(T x, T y)
            where T : INumber<T>
        {
            ThrowIfGreaterThan(x, y, null);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ThrowIfGreaterThan<T>(T x, T y, String? paramName)
            where T : INumber<T>
        {
            if (x > y) Throw(paramName);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ThrowIfGreaterThanOrEqual<T>(T x, T y)
            where T : INumber<T>
        {
            ThrowIfGreaterThanOrEqual(x, y, null);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ThrowIfGreaterThanOrEqual<T>(T x, T y, String? paramName)
            where T : INumber<T>
        {
            if (x < y) return;
            Throw(paramName);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ThrowIfNotInRange<T>(T value, T minimum, T maximum)
            where T : struct, INumber<T>
        {
            ThrowIfNotInRange(value, minimum, maximum, null);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ThrowIfNotInRange<T>(T value, T minimum, T maximum, String? paramName)
            where T : struct, INumber<T>
        {
            if (KozmosNumberHelper.IsInRange(value, minimum, maximum)) return;
            Throw(paramName);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ThrowIfInRange<T>(T value, T minimum, T maximum)
            where T : struct, INumber<T>
        {
            ThrowIfInRange(value, minimum, maximum, null);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ThrowIfInRange<T>(T value, T minimum, T maximum, String? paramName)
            where T : struct, INumber<T>
        {
            if (!KozmosNumberHelper.IsInRange(value, minimum, maximum)) return;
            Throw(paramName);
        }

        [DoesNotReturn]
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void Throw()
        {
            throw new ArgumentOutOfRangeException();
        }

        [DoesNotReturn]
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void Throw(String? paramName)
        {
            throw new ArgumentOutOfRangeException(paramName);
        }

        [DoesNotReturn]
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void Throw(String? paramName, String? message)
        {
            throw new ArgumentOutOfRangeException(paramName, message);
        }

        [DoesNotReturn]
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void Throw(String? paramName, String? message, Object? arg)
        {
            KozmosStringHelper.TryFormat(message, arg, out var formatted);
            throw new ArgumentOutOfRangeException(paramName, formatted);
        }

        [DoesNotReturn]
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void Throw(String? paramName, String? message, Object? arg0, Object? arg1)
        {
            KozmosStringHelper.TryFormat(message, arg0, arg1, out var formatted);
            throw new ArgumentOutOfRangeException(paramName, formatted);
        }

        [DoesNotReturn]
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void Throw(String? paramName, String? message, Object? arg0, Object? arg1, Object? arg2)
        {
            KozmosStringHelper.TryFormat(message, arg0, arg1, arg2, out var formatted);
            throw new ArgumentOutOfRangeException(paramName, formatted);
        }

        [DoesNotReturn]
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void Throw(String? paramName, String? message, params Object?[] args)
        {
            KozmosStringHelper.TryFormat(message, args, out var formatted);
            throw new ArgumentOutOfRangeException(paramName, formatted);
        }

        #endregion
    }
}

