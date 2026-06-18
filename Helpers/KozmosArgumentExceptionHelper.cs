using System;
using System.Runtime.CompilerServices;
using System.Diagnostics.CodeAnalysis;
using Kozmos.Constants;

namespace Kozmos.Helpers
{
    public static class KozmosArgumentExceptionHelper
    {
        #region public static void Throw...(...)

        [DoesNotReturn]
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void Throw() { throw new ArgumentException(); }

        [DoesNotReturn]
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void Throw(String? message)
        {
            if (message is not null) message = KozmosMessages.LogPrefix + KozmosStrings.Space + message;
            throw new ArgumentException(message); }

        [DoesNotReturn]
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void Throw(String? message, Object? arg)
        {
            if (message is not null) message = KozmosMessages.LogPrefix + KozmosStrings.Space + message;
            KozmosStringHelper.TryFormat(message, arg, out var formatted);
            throw new ArgumentException(formatted);
        }

        [DoesNotReturn]
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void Throw(String? message, Object? arg0, Object? arg1)
        {
            if (message is not null) message = KozmosMessages.LogPrefix + KozmosStrings.Space + message;
            KozmosStringHelper.TryFormat(message, arg0, arg1, out var formatted);
            throw new ArgumentException(formatted);
        }

        [DoesNotReturn]
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void Throw(String? message, Object? arg0, Object? arg1, Object? arg2)
        {
            if (message is not null) message = KozmosMessages.LogPrefix + KozmosStrings.Space + message;
            KozmosStringHelper.TryFormat(message, arg0, arg1, arg2, out var formatted);
            throw new ArgumentException(formatted);
        }

        [DoesNotReturn]
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void Throw(String? message, params Object?[] args)
        {
            if (message is not null) message = KozmosMessages.LogPrefix + KozmosStrings.Space + message;
            KozmosStringHelper.TryFormat(message, args, out var formatted);
            throw new ArgumentException(formatted);
        }

        #endregion
    }
}

