using System;
using System.Buffers.Binary;
using System.Runtime.CompilerServices;
using Kozmos.Constants;

namespace Kozmos.Helpers
{
	public static class KozmosBinaryPrimitivesHelper
	{
        #region Read / TryRead

        #region Read

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Byte ReadByteLittleEndian(ReadOnlySpan<Byte> source)
        {
            if (source.Length < KozmosTypeHelper<Byte>.UnsafeSize) KozmosArgumentOutOfRangeExceptionHelper.Throw(nameof(source));
            return source[0];
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Byte ReadByteBigEndian(ReadOnlySpan<Byte> source)
        {
            if (source.Length < KozmosTypeHelper<Byte>.UnsafeSize) KozmosArgumentOutOfRangeExceptionHelper.Throw(nameof(source));
            return source[0];
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SByte ReadSByteLittleEndian(ReadOnlySpan<Byte> source)
        {
            if (source.Length < KozmosTypeHelper<SByte>.UnsafeSize) KozmosArgumentOutOfRangeExceptionHelper.Throw(nameof(source));
            return KozmosNumberHelper<SByte>.Convert(source[0]);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SByte ReadSByteBigEndian(ReadOnlySpan<Byte> source)
        {
            if (source.Length < KozmosTypeHelper<SByte>.UnsafeSize) KozmosArgumentOutOfRangeExceptionHelper.Throw(nameof(source));
            return KozmosNumberHelper<SByte>.Convert(source[0]);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Decimal ReadDecimalLittleEndian(ReadOnlySpan<Byte> source)
        {
            if (source.Length < KozmosTypeHelper<Decimal>.UnsafeSize) KozmosArgumentOutOfRangeExceptionHelper.Throw(nameof(source));
            return __ReadDecimalLittleEndian(source);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Decimal ReadDecimalBigEndian(ReadOnlySpan<Byte> source)
        {
            if (source.Length < KozmosTypeHelper<Decimal>.UnsafeSize) KozmosArgumentOutOfRangeExceptionHelper.Throw(nameof(source));
            return __ReadDecimalBigEndian(source);
        }

        #endregion

        #region TryRead

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean TryReadByteLittleEndian(ReadOnlySpan<Byte> source, out Byte result)
        {
            if (source.Length < KozmosTypeHelper<Byte>.UnsafeSize) { result = default; return false; }
            result = source[0]; return true;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean TryReadByteBigEndian(ReadOnlySpan<Byte> source, out Byte result)
        {
            if (source.Length < KozmosTypeHelper<Byte>.UnsafeSize) { result = default; return false; }
            result = source[0]; return true;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean TryReadSByteLittleEndian(ReadOnlySpan<Byte> source, out SByte result)
        {
            if (source.Length < KozmosTypeHelper<SByte>.UnsafeSize) { result = default; return false; }
            return KozmosSByteHelper.TryConvert(source[0], out result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean TryReadSByteBigEndian(ReadOnlySpan<Byte> source, out SByte result)
        {
            if (source.Length < KozmosTypeHelper<SByte>.UnsafeSize) { result = default; return false; }
            return KozmosSByteHelper.TryConvert(source[0], out result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean TryReadUInt16LittleEndian(ReadOnlySpan<Byte> source, out UInt16 result)
        {
            if (source.Length < KozmosTypeHelper<UInt16>.UnsafeSize) { result = default; return false; }
            result = BinaryPrimitives.ReadUInt16LittleEndian(source); return true;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean TryReadUInt16BigEndian(ReadOnlySpan<Byte> source, out UInt16 result)
        {
            if (source.Length < KozmosTypeHelper<UInt16>.UnsafeSize) { result = default; return false; }
            result = BinaryPrimitives.ReadUInt16BigEndian(source); return true;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean TryReadInt16LittleEndian(ReadOnlySpan<Byte> source, out Int16 result)
        {
            if (source.Length < KozmosTypeHelper<Int16>.UnsafeSize) { result = default; return false; }
            result = BinaryPrimitives.ReadInt16LittleEndian(source); return true;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean TryReadInt16BigEndian(ReadOnlySpan<Byte> source, out Int16 result)
        {
            if (source.Length < KozmosTypeHelper<Int16>.UnsafeSize) { result = default; return false; }
            result = BinaryPrimitives.ReadInt16BigEndian(source); return true;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean TryReadUInt32LittleEndian(ReadOnlySpan<Byte> source, out UInt32 result)
        {
            if (source.Length < KozmosTypeHelper<UInt32>.UnsafeSize) { result = default; return false; }
            result = BinaryPrimitives.ReadUInt32LittleEndian(source); return true;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean TryReadUInt32BigEndian(ReadOnlySpan<Byte> source, out UInt32 result)
        {
            if (source.Length < KozmosTypeHelper<UInt32>.UnsafeSize) { result = default; return false; }
            result = BinaryPrimitives.ReadUInt32BigEndian(source); return true;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean TryReadInt32LittleEndian(ReadOnlySpan<Byte> source, out Int32 result)
        {
            if (source.Length < KozmosTypeHelper<Int32>.UnsafeSize) { result = default; return false; }
            result = BinaryPrimitives.ReadInt32LittleEndian(source); return true;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean TryReadInt32BigEndian(ReadOnlySpan<Byte> source, out Int32 result)
        {
            if (source.Length < KozmosTypeHelper<Int32>.UnsafeSize) { result = default; return false; }
            result = BinaryPrimitives.ReadInt32BigEndian(source); return true;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean TryReadUInt64LittleEndian(ReadOnlySpan<Byte> source, out UInt64 result)
        {
            if (source.Length < KozmosTypeHelper<UInt64>.UnsafeSize) { result = default; return false; }
            result = BinaryPrimitives.ReadUInt64LittleEndian(source); return true;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean TryReadUInt64BigEndian(ReadOnlySpan<Byte> source, out UInt64 result)
        {
            if (source.Length < KozmosTypeHelper<UInt64>.UnsafeSize) { result = default; return false; }
            result = BinaryPrimitives.ReadUInt64BigEndian(source); return true;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean TryReadInt64LittleEndian(ReadOnlySpan<Byte> source, out Int64 result)
        {
            if (source.Length < KozmosTypeHelper<Int64>.UnsafeSize) { result = default; return false; }
            result = BinaryPrimitives.ReadInt64LittleEndian(source); return true;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean TryReadInt64BigEndian(ReadOnlySpan<Byte> source, out Int64 result)
        {
            if (source.Length < KozmosTypeHelper<Int64>.UnsafeSize) { result = default; return false; }
            result = BinaryPrimitives.ReadInt64BigEndian(source); return true;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean TryReadUInt128LittleEndian(ReadOnlySpan<Byte> source, out UInt128 result)
        {
            if (source.Length < KozmosTypeHelper<UInt128>.UnsafeSize) { result = default; return false; }
            result = BinaryPrimitives.ReadUInt128LittleEndian(source); return true;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean TryReadUInt128BigEndian(ReadOnlySpan<Byte> source, out UInt128 result)
        {
            if (source.Length < KozmosTypeHelper<UInt128>.UnsafeSize) { result = default; return false; }
            result = BinaryPrimitives.ReadUInt128BigEndian(source); return true;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean TryReadInt128LittleEndian(ReadOnlySpan<Byte> source, out Int128 result)
        {
            if (source.Length < KozmosTypeHelper<Int128>.UnsafeSize) { result = default; return false; }
            result = BinaryPrimitives.ReadInt128LittleEndian(source); return true;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean TryReadInt128BigEndian(ReadOnlySpan<Byte> source, out Int128 result)
        {
            if (source.Length < KozmosTypeHelper<Int128>.UnsafeSize) { result = default; return false; }
            result = BinaryPrimitives.ReadInt128BigEndian(source); return true;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean TryReadSingleLittleEndian(ReadOnlySpan<Byte> source, out Single result)
        {
            if (source.Length < KozmosTypeHelper<Single>.UnsafeSize) { result = default; return false; }
            result = BinaryPrimitives.ReadSingleLittleEndian(source); return true;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean TryReadSingleBigEndian(ReadOnlySpan<Byte> source, out Single result)
        {
            if (source.Length < KozmosTypeHelper<Single>.UnsafeSize) { result = default; return false; }
            result = BinaryPrimitives.ReadSingleBigEndian(source); return true;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean TryReadDoubleLittleEndian(ReadOnlySpan<Byte> source, out Double result)
        {
            if (source.Length < KozmosTypeHelper<Double>.UnsafeSize) { result = default; return false; }
            result = BinaryPrimitives.ReadDoubleLittleEndian(source); return true;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean TryReadDoubleBigEndian(ReadOnlySpan<Byte> source, out Double result)
        {
            if (source.Length < KozmosTypeHelper<Double>.UnsafeSize) { result = default; return false; }
            result = BinaryPrimitives.ReadDoubleBigEndian(source); return true;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean TryReadDecimalLittleEndian(ReadOnlySpan<Byte> source, out Decimal result)
        {
            if (source.Length < KozmosTypeHelper<Decimal>.UnsafeSize) { result = default; return false; }
            result = __ReadDecimalLittleEndian(source); return true;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean TryReadDecimalBigEndian(ReadOnlySpan<Byte> source, out Decimal result)
        {
            if (source.Length < KozmosTypeHelper<Decimal>.UnsafeSize) { result = default; return false; }
            result = __ReadDecimalBigEndian(source); return true;
        }

        #endregion

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static Decimal __ReadDecimalLittleEndian(ReadOnlySpan<Byte> source)
        {
            Int32 lo = BinaryPrimitives.ReadInt32LittleEndian(source[0..4]);
            Int32 mid = BinaryPrimitives.ReadInt32LittleEndian(source[4..8]);
            Int32 hi = BinaryPrimitives.ReadInt32LittleEndian(source[8..12]);
            Int32 flags = BinaryPrimitives.ReadInt32LittleEndian(source[12..16]);

            Boolean isNegative = (flags & 0x80000000) != 0;
            Byte scale = (Byte)((flags >> 16) & 0xFF);

            // Costruttore ufficiale ad alte prestazioni di .NET
            return new Decimal(lo, mid, hi, isNegative, scale);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static Decimal __ReadDecimalBigEndian(ReadOnlySpan<Byte> source)
        {
            Int32 flags = BinaryPrimitives.ReadInt32BigEndian(source[0..4]);
            Int32 hi = BinaryPrimitives.ReadInt32BigEndian(source[4..8]);
            Int32 mid = BinaryPrimitives.ReadInt32BigEndian(source[8..12]);
            Int32 lo = BinaryPrimitives.ReadInt32BigEndian(source[12..16]);

            Boolean isNegative = (flags & 0x80000000) != 0;
            Byte scale = (Byte)((flags >> 16) & 0xFF);

            // Costruttore ufficiale ad alte prestazioni di .NET
            return new Decimal(lo, mid, hi, isNegative, scale);
        }

        #endregion
    }
}