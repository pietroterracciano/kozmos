using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using Kozmos.Constants;

namespace Kozmos.Helpers.Exceptions
{
    public static class KozmosNotSupportedExceptionHelper
    {
        #region public static void Throw...(...)

        [DoesNotReturn]
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void Throw() { throw new NotSupportedException(); }

        [DoesNotReturn]
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void Throw(String? message)
        {
            if (message is not null) message = KozmosMessages.LogPrefix + KozmosStrings.Space + message;
            throw new NotSupportedException(message);
        }

        [DoesNotReturn]
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void Throw(String? message, Object? arg)
        {
            if (message is not null) message = KozmosMessages.LogPrefix + KozmosStrings.Space + message;
            KozmosStringHelper.TryFormat(message, arg, out var formatted);
            throw new NotSupportedException(formatted);
        }

        [DoesNotReturn]
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void Throw(String? message, Object? arg0, Object? arg1)
        {
            if (message is not null) message = KozmosMessages.LogPrefix + KozmosStrings.Space + message;
            KozmosStringHelper.TryFormat(message, arg0, arg1, out var formatted);
            throw new NotSupportedException(formatted);
        }

        [DoesNotReturn]
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void Throw(String? message, Object? arg0, Object? arg1, Object? arg2)
        {
            if (message is not null) message = KozmosMessages.LogPrefix + KozmosStrings.Space + message;
            KozmosStringHelper.TryFormat(message, arg0, arg1, arg2, out var formatted);
            throw new NotSupportedException(formatted);
        }

        [DoesNotReturn]
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void Throw(String? message, params Object?[] args)
        {
            if (message is not null) message = KozmosMessages.LogPrefix + KozmosStrings.Space + message;
            KozmosStringHelper.TryFormat(message, args, out var formatted);
            throw new NotSupportedException(formatted);
        }

        #endregion
    }
}

