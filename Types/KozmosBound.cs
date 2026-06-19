using System;
using System.Runtime.CompilerServices;
using Kozmos.Helpers;
using Kozmos.Helpers.Exceptions;

namespace Kozmos.Types
{
    public readonly ref struct KozmosBound
    {
        public readonly Int32 Size, RequestedStartIndex, RequestedSize;
        public readonly Boolean IsValid;

        private KozmosBound(Int32 size, Int32 requestedStartIndex, Int32 requestedSize, Boolean isValid)
        {
            Size = size;
            RequestedStartIndex = requestedStartIndex;
            RequestedSize = requestedSize;
            IsValid = isValid;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static KozmosBound From(String source, Int32 requestedStartIndex) { return From(source, requestedStartIndex, -1); }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static KozmosBound From(String source, Int32 requestedStartIndex, Int32 requestedSize)
        {
            KozmosArgumentNullExceptionHelper.ThrowIfNull(source);
            return From(source.Length, requestedStartIndex, requestedSize);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static KozmosBound From<T>(Span<T> source, Int32 requestedStartIndex) { return From(source, requestedStartIndex, -1); }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static KozmosBound From<T>(Span<T> source, Int32 requestedStartIndex, Int32 requestedSize) { return From(source.Length, requestedStartIndex, requestedSize); }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static KozmosBound From<T>(ReadOnlySpan<T> source, Int32 requestedStartIndex) { return From(source, requestedStartIndex, -1); }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static KozmosBound From<T>(ReadOnlySpan<T> source, Int32 requestedStartIndex, Int32 requestedSize) { return From(source.Length, requestedStartIndex, requestedSize); }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static KozmosBound From<T>(Memory<T> source, Int32 requestedStartIndex) { return From(source, requestedStartIndex, -1); }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static KozmosBound From<T>(Memory<T> source, Int32 requestedStartIndex, Int32 requestedSize) { return From(source.Length, requestedStartIndex, requestedSize); }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static KozmosBound From<T>(ReadOnlyMemory<T> source, Int32 requestedStartIndex) { return From(source, requestedStartIndex, -1); }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static KozmosBound From<T>(ReadOnlyMemory<T> source, Int32 requestedStartIndex, Int32 requestedSize) { return From(source.Length, requestedStartIndex, requestedSize); }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static KozmosBound From<T>(T[] source, Int32 requestedStartIndex) { return From(source, requestedStartIndex, -1); }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static KozmosBound From<T>(T[] source, Int32 requestedStartIndex, Int32 requestedSize)
        {
            KozmosArgumentNullExceptionHelper.ThrowIfNull(source);
            return From(source.Length, requestedStartIndex, requestedSize);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static KozmosBound From(Array source, Int32 requestedStartIndex) { return From(source, requestedStartIndex, -1); }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static KozmosBound From(Array source, Int32 requestedStartIndex, Int32 requestedSize)
        {
            KozmosArgumentNullExceptionHelper.ThrowIfNull(source);
            return From(source.Length, requestedStartIndex, requestedSize);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static KozmosBound From(Int32 source, Int32 requestedStartIndex) { return From(source, requestedStartIndex, -1); }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static KozmosBound From(Int32 source, Int32 requestedStartIndex, Int32 requestedSize)
        {
            Int32 requestedSize0 = requestedSize < 0 ? source - requestedStartIndex : requestedSize;
            return
                new KozmosBound
                (
                    source,
                    requestedStartIndex,
                    requestedSize0,
                    (UInt32)requestedStartIndex <= (UInt32)source
                    && (UInt32)requestedSize0 <= (UInt32)(source - requestedStartIndex)
                );
        }
    }
}

