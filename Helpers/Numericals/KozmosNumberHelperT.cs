using System;
using System.Buffers.Binary;
using System.Globalization;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text.Json;
using Kozmos.Enums;
using Kozmos.Helpers.Exceptions;
using Kozmos.Options;

namespace Kozmos.Helpers.Numericals
{
	public abstract class
		KozmosNumberHelper<T>
    where
        T : struct, INumber<T>
    {
        public static readonly Boolean IsNullable;
        public static readonly T Zero, One, MinValue, MaxValue;

		static KozmosNumberHelper()
		{
            IsNullable = KozmosTypeHelper<T>.IsNullable;
            Zero = T.Zero;
			One = T.One;
            MinValue = (T)KozmosNumberHelper.GetMinValue(KozmosTypeHelper<T>._);
            MaxValue = (T)KozmosNumberHelper.GetMaxValue(KozmosTypeHelper<T>._);
        }

        #region WillOverflow

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean WillOverflow<TSource>(TSource? source)
            where TSource : struct, INumber<TSource>
        {
            return source.HasValue && WillOverflow(source!.Value);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean WillOverflow<TSource>(TSource source)
            where TSource : struct, INumber<TSource>
        {
            return
                !TSource.IsFinite(source)
                //|| T.CreateTruncating(KozmosNumberHelper<TSource>.MinValue) < MinValue
                //|| T.CreateTruncating(KozmosNumberHelper<TSource>.MaxValue) > MaxValue
                || source < TSource.CreateSaturating(MinValue)
                || source > TSource.CreateSaturating(MaxValue);
        }

        [MethodImpl(MethodImplOptions.AggressiveOptimization)]
        public static Boolean WillOverflow(Object? source)
        {
            switch (source)
            {
                case Byte by: return WillOverflow(by);
                case SByte sby: return WillOverflow(sby);
                case UInt16 ui16: return WillOverflow(ui16);
                case Int16 i16: return WillOverflow(i16);
                case UInt32 ui32: return WillOverflow(ui32);
                case Int32 i32: return WillOverflow(i32);
                case UInt64 ui64: return WillOverflow(ui64);
                case Int64 i64: return WillOverflow(i64);
                case UInt128 ui128: return WillOverflow(ui128);
                case Int128 i128: return WillOverflow(i128);
                case BigInteger bi: return WillOverflow(bi);
                case Decimal m: return WillOverflow(m);
                case Single f: return WillOverflow(f);
                case Double d: return WillOverflow(d);
                case null: return false;
                default:
                    KozmosArgumentExceptionHelper.ThrowValue_0_OfArgument_1_2_IsNotSupported(source);
                    return false;
            }
        }

        #endregion

        #region public static Boolean IsInRange(...)

        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        //public static Boolean IsInRange(T source, T minSource, T maxSource)
        //{
        //    if (minSource > maxSource) return false;
        //    return T.CreateTruncating(source - minSource) <= T.CreateTruncating(maxSource - minSource);
        //

        public static Boolean IsInRange<T>(T source, T minSource, T maxSource)
            where T : INumber<T> 
        {
            return minSource < maxSource && source >= minSource && source <= maxSource;
        }

        #endregion

        #region public static Boolean IsOne(...)

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean IsOne(T source) { return source == One; }

        #endregion

        #region public static Boolean IsNotOne(...)

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean IsNotOne(T source) { return source != One; }

        #endregion

        #region public static Boolean IsZero(...)

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean IsZero(T source) { return source == Zero; }

        #endregion

        #region public static Boolean IsNotZero(...)

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean IsNotZero(T source) { return source != Zero; }

        #endregion

        #region Convert / TryConvert

        #region Convert

        #region Conditionals

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T Convert(Boolean? source)
        {
            if (__AssertConvert(source)) return default;
            return Convert(source.Value);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T Convert(Boolean source)
        {
            return source ? One : Zero;
        }

        #endregion

        #region Codeds

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T Convert(Char? source)
        {
            return Convert(source, KozmosNumberConvertOptions.Default.CharComponent);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T Convert(Char? source, EKozmosCharComponent component)
        {
            if (__AssertConvert(source)) return default;
            return Convert(source.Value);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T Convert(Char source)
        {
            return Convert(source, KozmosNumberConvertOptions.Default.CharComponent);
        }

        [MethodImpl(MethodImplOptions.AggressiveOptimization)]
        public static T Convert(Char source, EKozmosCharComponent component)
        {
            KozmosTypeHelper<T>.AssertTypeParameterCache(nameof(T));

            switch (component)
            {
                case EKozmosCharComponent.Numeric:
                    UInt32 ui32 = (UInt32)source - '0';
                    if (ui32 <= 9)
                    {
                        switch(KozmosTypeHelper<T>.Enum.Value)
                        {
                            case EKozmosType.UInt32:
                                return Unsafe.As<UInt32, T>(ref ui32);
                            case EKozmosType.NullableUInt32:
                                UInt32? nui32 = ui32; return Unsafe.As<UInt32?, T>(ref nui32);
                            default:
                                return Convert(ui32);
                        }
                    }
                    Double d = Char.GetNumericValue(source);
                    if (d < 0.0d)
                    {
                        KozmosArgumentOutOfRangeExceptionHelper.Throw(nameof(source));
                        return default;
                    }
                    switch (KozmosTypeHelper<T>.Enum.Value)
                    {
                        case EKozmosType.Double:
                            return Unsafe.As<Double, T>(ref d);
                        case EKozmosType.NullableDouble:
                            Double? nd = d; return Unsafe.As<Double?, T>(ref nd);
                        default:
                            return Convert(d);
                    }
                case EKozmosCharComponent.CodePoint:
                    UInt16 ui16 = (UInt16)source;
                    switch (KozmosTypeHelper<T>.Enum.Value)
                    {
                        case EKozmosType.UInt16:
                            return Unsafe.As<UInt16, T>(ref ui16);
                        case EKozmosType.NullableUInt16:
                            UInt16? nui16 = ui16; return Unsafe.As<UInt16?, T>(ref nui16);
                        default:
                            return Convert(ui16);
                    }
                default:
                    KozmosArgumentExceptionHelper.ThrowValue_0_OfArgument_1_2_IsNotSupported(component);
                    return default;
            }
        }

        #endregion

        #region Fluidized

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T Convert(Byte[]? source)
        {
            if (__AssertConvert(source)) return default;
            return Convert(source.AsSpan());
        }

        [MethodImpl(MethodImplOptions.AggressiveOptimization)]
        public static T Convert(ReadOnlySpan<Byte> source)
        {
            KozmosTypeHelper<T>.AssertTypeParameterCache(nameof(T));

            switch (KozmosTypeHelper<T>.Enum.Value)
            {
                case EKozmosType.Byte:
                    Byte by = KozmosBinaryPrimitivesHelper.ReadByteLittleEndian(source);
                    return Unsafe.As<Byte, T>(ref by);
                case EKozmosType.NullableByte:
                    Byte? nby = KozmosBinaryPrimitivesHelper.ReadByteLittleEndian(source);
                    return Unsafe.As<Byte?, T>(ref nby);

                case EKozmosType.SByte:
                    SByte sby = KozmosBinaryPrimitivesHelper.ReadSByteLittleEndian(source);
                    return Unsafe.As<SByte, T>(ref sby);
                case EKozmosType.NullableSByte:
                    SByte? nsby = KozmosBinaryPrimitivesHelper.ReadSByteLittleEndian(source);
                    return Unsafe.As<SByte?, T>(ref nsby);

                case EKozmosType.UInt16:
                    UInt16 ui16 = BinaryPrimitives.ReadUInt16LittleEndian(source);
                    return Unsafe.As<UInt16, T>(ref ui16);
                case EKozmosType.NullableUInt16:
                    UInt16? nui16 = BinaryPrimitives.ReadUInt16LittleEndian(source);
                    return Unsafe.As<UInt16?, T>(ref nui16);

                case EKozmosType.Int16:
                    Int16 i16 = BinaryPrimitives.ReadInt16LittleEndian(source);
                    return Unsafe.As<Int16, T>(ref i16);
                case EKozmosType.NullableInt16:
                    Int16? ni16 = BinaryPrimitives.ReadInt16LittleEndian(source);
                    return Unsafe.As<Int16?, T>(ref ni16);

                case EKozmosType.UInt32:
                    UInt32 ui32 = BinaryPrimitives.ReadUInt32LittleEndian(source);
                    return Unsafe.As<UInt32, T>(ref ui32);
                case EKozmosType.NullableUInt32:
                    UInt32? nui32 = BinaryPrimitives.ReadUInt32LittleEndian(source);
                    return Unsafe.As<UInt32?, T>(ref nui32);

                case EKozmosType.Int32:
                    Int32 i32 = BinaryPrimitives.ReadInt32LittleEndian(source);
                    return Unsafe.As<Int32, T>(ref i32);
                case EKozmosType.NullableInt32:
                    Int32? ni32 = BinaryPrimitives.ReadInt32LittleEndian(source);
                    return Unsafe.As<Int32?, T>(ref ni32);

                case EKozmosType.UInt64:
                    UInt64 ui64 = BinaryPrimitives.ReadUInt64LittleEndian(source);
                    return Unsafe.As<UInt64, T>(ref ui64);
                case EKozmosType.NullableUInt64:
                    UInt64? nui64 = BinaryPrimitives.ReadUInt64LittleEndian(source);
                    return Unsafe.As<UInt64?, T>(ref nui64);

                case EKozmosType.Int64:
                    Int64 i64 = BinaryPrimitives.ReadInt64LittleEndian(source);
                    return Unsafe.As<Int64, T>(ref i64);
                case EKozmosType.NullableInt64:
                    Int64? ni64 = BinaryPrimitives.ReadInt64LittleEndian(source);
                    return Unsafe.As<Int64?, T>(ref ni64);

                case EKozmosType.UInt128:
                    UInt128 ui128 = BinaryPrimitives.ReadUInt128LittleEndian(source);
                    return Unsafe.As<UInt128, T>(ref ui128);
                case EKozmosType.NullableUInt128:
                    UInt128? nui128 = BinaryPrimitives.ReadUInt128LittleEndian(source);
                    return Unsafe.As<UInt128?, T>(ref nui128);

                case EKozmosType.Int128:
                    Int128 i128 = BinaryPrimitives.ReadInt128LittleEndian(source);
                    return Unsafe.As<Int128, T>(ref i128);
                case EKozmosType.NullableInt128:
                    Int128? ni128 = BinaryPrimitives.ReadInt128LittleEndian(source);
                    return Unsafe.As<Int128?, T>(ref ni128);

                case EKozmosType.Single:
                    Single f = BinaryPrimitives.ReadSingleLittleEndian(source);
                    return Unsafe.As<Single, T>(ref f);
                case EKozmosType.NullableSingle:
                    Single? nf = BinaryPrimitives.ReadSingleLittleEndian(source);
                    return Unsafe.As<Single?, T>(ref nf);

                case EKozmosType.Double:
                    Double d = BinaryPrimitives.ReadDoubleLittleEndian(source);
                    return Unsafe.As<Double, T>(ref d);
                case EKozmosType.NullableDouble:
                    Double? nd = BinaryPrimitives.ReadDoubleLittleEndian(source);
                    return Unsafe.As<Double?, T>(ref nd);

                case EKozmosType.Decimal:
                    Decimal m = KozmosBinaryPrimitivesHelper.ReadDecimalLittleEndian(source);
                    return Unsafe.As<Decimal, T>(ref m);
                case EKozmosType.NullableDecimal:
                    Decimal? nm = KozmosBinaryPrimitivesHelper.ReadDecimalLittleEndian(source);
                    return Unsafe.As<Decimal?, T>(ref nm);

                default:
                    KozmosExceptionHelper<T>.ThrowTheTypeParameter_0_1_IsNotSupported(nameof(T));
                    return default;
            }
        }

        #endregion

        #region Lizatings

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T Convert(JsonElement? source)
        {
            return Convert(source, KozmosNumberIParsableConvertOptions.Default);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T Convert(JsonElement? source, KozmosNumberIParsableConvertOptions options)
        {
            if (__AssertConvert(source)) return default;
            return Convert(source.Value, options);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T Convert(JsonElement source)
        { 
            return Convert(source, KozmosNumberIParsableConvertOptions.Default);
        }

        [MethodImpl(MethodImplOptions.AggressiveOptimization)]
        public static T Convert(JsonElement source, KozmosNumberIParsableConvertOptions options)
        {
            switch (source.ValueKind)
            {
                // Conditionals >
                case JsonValueKind.True: return One;
                case JsonValueKind.False: return Zero;
                // < Conditionals

                // Numericals >
                case JsonValueKind.Number:
                    KozmosTypeHelper<T>.AssertTypeParameterCache(nameof(T));

                    switch (KozmosTypeHelper<T>.Enum!.Value)
                    {
                        case EKozmosType.Byte:
                            Byte by = source.GetByte();
                            return Unsafe.As<Byte, T>(ref by);

                        case EKozmosType.NullableByte:
                            Byte? nby = source.GetByte();
                            return Unsafe.As<Byte?, T>(ref nby);

                        case EKozmosType.SByte:
                            SByte sby = source.GetSByte();
                            return Unsafe.As<SByte, T>(ref sby);

                        case EKozmosType.NullableSByte:
                            SByte? nsby = source.GetSByte();
                            return Unsafe.As<SByte?, T>(ref nsby);

                        case EKozmosType.UInt16:
                            UInt16 ui16 = source.GetUInt16();
                            return Unsafe.As<UInt16, T>(ref ui16);

                        case EKozmosType.NullableUInt16:
                            UInt16? nui16 = source.GetUInt16();
                            return Unsafe.As<UInt16?, T>(ref nui16);

                        case EKozmosType.Int16:
                            Int16 i16 = source.GetInt16();
                            return Unsafe.As<Int16, T>(ref i16);

                        case EKozmosType.NullableInt16:
                            Int16? ni16 = source.GetInt16();
                            return Unsafe.As<Int16?, T>(ref ni16);

                        case EKozmosType.UInt32:
                            UInt32 ui32 = source.GetUInt32();
                            return Unsafe.As<UInt32, T>(ref ui32);

                        case EKozmosType.NullableUInt32:
                            UInt32? nui32 = source.GetUInt32();
                            return Unsafe.As<UInt32?, T>(ref nui32);

                        case EKozmosType.Int32:
                            Int32 i32 = source.GetInt32();
                            return Unsafe.As<Int32, T>(ref i32);

                        case EKozmosType.NullableInt32:
                            Int32? ni32 = source.GetInt32();
                            return Unsafe.As<Int32?, T>(ref ni32);

                        case EKozmosType.UInt64:
                            UInt64 ui64 = source.GetUInt64();
                            return Unsafe.As<UInt64, T>(ref ui64);

                        case EKozmosType.NullableUInt64:
                            UInt64? nui64 = source.GetUInt64();
                            return Unsafe.As<UInt64?, T>(ref nui64);

                        case EKozmosType.Int64:
                            Int64 i64 = source.GetInt64();
                            return Unsafe.As<Int64, T>(ref i64);

                        case EKozmosType.NullableInt64:
                            Int64? ni64 = source.GetInt64();
                            return Unsafe.As<Int64?, T>(ref ni64);

                        case EKozmosType.UInt128:
                            UInt128 ui128 = source.GetUInt128();
                            return Unsafe.As<UInt128, T>(ref ui128);

                        case EKozmosType.NullableUInt128:
                            UInt128? nui128 = source.GetUInt128();
                            return Unsafe.As<UInt128?, T>(ref nui128);

                        case EKozmosType.Int128:
                            Int128 i128 = source.GetInt128();
                            return Unsafe.As<Int128, T>(ref i128);

                        case EKozmosType.NullableInt128:
                            Int128? ni128 = source.GetInt128();
                            return Unsafe.As<Int128?, T>(ref ni128);

                        case EKozmosType.Single:
                            Single s = source.GetSingle();
                            return Unsafe.As<Single, T>(ref s);

                        case EKozmosType.NullableSingle:
                            Single? ns = source.GetSingle();
                            return Unsafe.As<Single?, T>(ref ns);

                        case EKozmosType.Double:
                            Double d = source.GetDouble();
                            return Unsafe.As<Double, T>(ref d);

                        case EKozmosType.NullableDouble:
                            Double? nd = source.GetDouble();
                            return Unsafe.As<Double?, T>(ref nd);

                        case EKozmosType.Decimal:
                            Decimal m = source.GetDecimal();
                            return Unsafe.As<Decimal, T>(ref m);

                        case EKozmosType.NullableDecimal:
                            Decimal? nm = source.GetDecimal();
                            return Unsafe.As<Decimal?, T>(ref nm);

                        default:
                            KozmosExceptionHelper<T>.ThrowTheTypeParameter_0_1_IsNotSupported(nameof(T));
                            return default;
                    }
                // < Numericals

                // Textuals >
                case JsonValueKind.String:
                    return Convert(source.ToString(), options);
                // < Textuals

                // Others >
                case JsonValueKind.Undefined:
                case JsonValueKind.Null:
                    if (IsNullable) return default;
                    break;
                // < Others
            }

            KozmosExceptionHelper.ThrowValue_0_OfMember_1_2_OfArgument_3_4_IsNotSupported
            (
                source.ValueKind,
                nameof(source.ValueKind),
                source
            );
            return default;
        }

        #endregion

        #region Numericals

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T Convert<TSource>(TSource? source)
            where TSource : struct, INumber<TSource>
        {
            if (__AssertConvert(source)) return default;
            return Convert(source.Value);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T Convert<TSource>(TSource source)
            where TSource : struct, INumber<TSource>
        {
            return T.CreateChecked(source);
        }

        #endregion

        #region Temporals

        #region DateOnly

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T Convert(DateOnly? source)
        {
            return Convert(source, KozmosNumberConvertOptions.Default.DateOnlyComponent);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T Convert(DateOnly? source, EKozmosDateOnlyComponent component)
        {
            if (__AssertConvert(source)) return default;
            return Convert(source!.Value, component);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T Convert(DateOnly source)
        {
            return Convert(source, KozmosNumberConvertOptions.Default.DateOnlyComponent);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T Convert(DateOnly source, EKozmosDateOnlyComponent component)
        {
            switch (component)
            {
                case EKozmosDateOnlyComponent.DayNumber: return Convert(source.DayNumber);
                case EKozmosDateOnlyComponent.Day: return Convert(source.Day);
                case EKozmosDateOnlyComponent.DayOfWeek: return Convert(source.DayOfWeek);
                case EKozmosDateOnlyComponent.DayOfYear: return Convert(source.DayOfYear);
                case EKozmosDateOnlyComponent.Month: return Convert(source.Month);
                case EKozmosDateOnlyComponent.Year: return Convert(source.Year);
                default:
                    KozmosArgumentExceptionHelper.ThrowValue_0_OfArgument_1_2_IsNotSupported(component);
                    return default;
            }
        }

        #endregion

        #region DateTime

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T Convert(DateTime? source)
        {
            return Convert(source, KozmosNumberConvertOptions.Default.DateTimeComponent);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T Convert(DateTime? source, EKozmosDateTimeComponent component)
        {
            if (__AssertConvert(source)) return default;
            return Convert(source!.Value, component);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T Convert(DateTime source)
        {
            return Convert(source, KozmosNumberConvertOptions.Default.DateTimeComponent);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T Convert(DateTime source, EKozmosDateTimeComponent component)
        {
            switch (component)
            {
                case EKozmosDateTimeComponent.Nanosecond: return Convert(source.Nanosecond);
                case EKozmosDateTimeComponent.Microsecond: return Convert(source.Microsecond);
                case EKozmosDateTimeComponent.Millisecond: return Convert(source.Millisecond);
                case EKozmosDateTimeComponent.Second: return Convert(source.Second);
                case EKozmosDateTimeComponent.Minute: return Convert(source.Minute);
                case EKozmosDateTimeComponent.Hour: return Convert(source.Hour);
                case EKozmosDateTimeComponent.Day: return Convert(source.Day);
                case EKozmosDateTimeComponent.DayOfWeek: return Convert(source.DayOfWeek);
                case EKozmosDateTimeComponent.DayOfYear: return Convert(source.DayOfYear);
                case EKozmosDateTimeComponent.Month: return Convert(source.Month);
                case EKozmosDateTimeComponent.Year: return Convert(source.Year);
                case EKozmosDateTimeComponent.Ticks: return Convert(source.Ticks);
                default:
                    KozmosArgumentExceptionHelper.ThrowValue_0_OfArgument_1_2_IsNotSupported(component);
                    return default;
            }
        }

        #endregion

        #region DateTimeOffset

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T Convert(DateTimeOffset? source)
        {
            return Convert(source, KozmosNumberConvertOptions.Default.DateTimeOffsetComponent);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T Convert(DateTimeOffset? source, EKozmosDateTimeOffsetComponent component)
        {
            if (__AssertConvert(source)) return default;
            return Convert(source!.Value, component);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T Convert(DateTimeOffset source)
        {
            return Convert(source, KozmosNumberConvertOptions.Default.DateTimeOffsetComponent);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T Convert(DateTimeOffset source, EKozmosDateTimeOffsetComponent component)
        {
            switch (component)
            {
                case EKozmosDateTimeOffsetComponent.Nanosecond: return Convert(source.Nanosecond);
                case EKozmosDateTimeOffsetComponent.Microsecond: return Convert(source.Microsecond);
                case EKozmosDateTimeOffsetComponent.Millisecond: return Convert(source.Millisecond);
                case EKozmosDateTimeOffsetComponent.Second: return Convert(source.Second);
                case EKozmosDateTimeOffsetComponent.Minute: return Convert(source.Minute);
                case EKozmosDateTimeOffsetComponent.Hour: return Convert(source.Hour);
                case EKozmosDateTimeOffsetComponent.Day: return Convert(source.Day);
                case EKozmosDateTimeOffsetComponent.DayOfWeek: return Convert(source.DayOfWeek);
                case EKozmosDateTimeOffsetComponent.DayOfYear: return Convert(source.DayOfYear);
                case EKozmosDateTimeOffsetComponent.Month: return Convert(source.Month);
                case EKozmosDateTimeOffsetComponent.Year: return Convert(source.Year);
                case EKozmosDateTimeOffsetComponent.Ticks: return Convert(source.Ticks);
                default:
                    KozmosArgumentExceptionHelper.ThrowValue_0_OfArgument_1_2_IsNotSupported(component);
                    return default;
            }
        }

        #endregion

        #region TimeOnly

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T Convert(TimeOnly? source)
        {
            return Convert(source, KozmosNumberConvertOptions.Default.TimeOnlyComponent);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T Convert(TimeOnly? source, EKozmosTimeOnlyComponent component)
        {
            if (__AssertConvert(source)) return default;
            return Convert(source!.Value, component);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T Convert(TimeOnly source)
        {
            return Convert(source, KozmosNumberConvertOptions.Default.TimeOnlyComponent);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T Convert(TimeOnly source, EKozmosTimeOnlyComponent component)
        {
            switch (component)
            {
                case EKozmosTimeOnlyComponent.Nanosecond: return Convert(source.Nanosecond);
                case EKozmosTimeOnlyComponent.Microsecond: return Convert(source.Microsecond);
                case EKozmosTimeOnlyComponent.Millisecond: return Convert(source.Millisecond);
                case EKozmosTimeOnlyComponent.Second: return Convert(source.Second);
                case EKozmosTimeOnlyComponent.Minute: return Convert(source.Minute);
                case EKozmosTimeOnlyComponent.Hour: return Convert(source.Hour);
                case EKozmosTimeOnlyComponent.Ticks: return Convert(source.Ticks);
                default:
                    KozmosArgumentExceptionHelper.ThrowValue_0_OfArgument_1_2_IsNotSupported(component);
                    return default;
            }
        }

        #endregion

        #region TimeSpan

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T Convert(TimeSpan? source)
        {
            return Convert(source, KozmosNumberConvertOptions.Default.TimeSpanComponent);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T Convert(TimeSpan? source, EKozmosTimeSpanComponent component)
        {
            if (__AssertConvert(source)) return default;
            return Convert(source!.Value, component);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T Convert(TimeSpan source)
        {
            return Convert(source, KozmosNumberConvertOptions.Default.TimeSpanComponent);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T Convert(TimeSpan source, EKozmosTimeSpanComponent component)
        {
            switch (component)
            {
                case EKozmosTimeSpanComponent.Ticks: return Convert(source.Ticks);
                case EKozmosTimeSpanComponent.Nanoseconds: return Convert(source.Nanoseconds);
                case EKozmosTimeSpanComponent.TotalNanoseconds: return Convert(source.TotalNanoseconds);
                case EKozmosTimeSpanComponent.Microseconds: return Convert(source.Microseconds);
                case EKozmosTimeSpanComponent.TotalMicroseconds: return Convert(source.TotalMicroseconds);
                case EKozmosTimeSpanComponent.Milliseconds: return Convert(source.Milliseconds);
                case EKozmosTimeSpanComponent.TotalMilliseconds: return Convert(source.TotalMilliseconds);
                case EKozmosTimeSpanComponent.Seconds: return Convert(source.Seconds);
                case EKozmosTimeSpanComponent.TotalSeconds: return Convert(source.TotalSeconds);
                case EKozmosTimeSpanComponent.Minutes: return Convert(source.Minutes);
                case EKozmosTimeSpanComponent.TotalMinutes: return Convert(source.TotalMinutes);
                case EKozmosTimeSpanComponent.Hours: return Convert(source.Hours);
                case EKozmosTimeSpanComponent.TotalHours: return Convert(source.TotalHours);
                case EKozmosTimeSpanComponent.Days: return Convert(source.Days);
                case EKozmosTimeSpanComponent.TotalDays: return Convert(source.TotalDays);
                default:
                    KozmosArgumentExceptionHelper.ThrowValue_0_OfArgument_1_2_IsNotSupported(component);
                    return default;
            }
        }

        #endregion

        #endregion

        #region Textuals

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T Convert(String source)
        {
            return Convert(source, KozmosNumberIParsableConvertOptions.Default);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T Convert(String source, KozmosNumberIParsableConvertOptions options)
        {
            if (__AssertConvert(source)) return default;
            KozmosArgumentNullExceptionHelper.ThrowIfNull(options);
            return T.Parse(source, options.NumberStyles, options.FormatProvider);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T Convert(ReadOnlySpan<Char> source)
        {
            return Convert(source, KozmosNumberIParsableConvertOptions.Default);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T Convert(ReadOnlySpan<Char> source, KozmosNumberIParsableConvertOptions options)
        {
            KozmosArgumentNullExceptionHelper.ThrowIfNull(options);
            return T.Parse(source, options.NumberStyles, options.FormatProvider);
        }

        #endregion

        #region Objects

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T Convert(Object? source) { return Convert(source, KozmosNumberConvertOptions.Default); }

        [MethodImpl(MethodImplOptions.AggressiveOptimization)]
        public static T Convert(Object? source, KozmosNumberConvertOptions options)
        {
            switch (source)
            {
                // HotPath >
                case T o: return o;
                // < HotPath

                // Conditionals >
                case Boolean b: return Convert(b);
                // < Conditionals

                // Codeds >
                case Char c:
                    KozmosArgumentNullExceptionHelper.ThrowIfNull(options);
                    return Convert(c, options.CharComponent);
                // < Codeds

                // Fluidized >
                case Byte[] ba: return Convert(ba);
                // < Fluidized

                // Lizatings >
                case JsonElement je:
                    KozmosArgumentNullExceptionHelper.ThrowIfNull(options);
                    return Convert(je, options.IParsableConvertOptions);
                // < Lizatings

                // Numericals >
                case Byte by: return Convert(by);
                case SByte sby: return Convert(sby);
                case UInt16 ui16: return Convert(ui16);
                case Int16 i16: return Convert(i16);
                case UInt32 ui32: return Convert(ui32);
                case Int32 i32: return Convert(i32);
                case UInt64 ui64: return Convert(ui64);
                case Int64 i64: return Convert(i64);
                case UInt128 ui128: return Convert(ui128);
                case Int128 i128: return Convert(i128);
                case BigInteger bi: return Convert(bi);
                case Decimal m: return Convert(m);
                case Single f: return Convert(f);
                case Double d: return Convert(d);
                // < Numericals

                // Temporals >
                case DateOnly don:
                    KozmosArgumentNullExceptionHelper.ThrowIfNull(options);
                    return Convert(don, options.DateOnlyComponent);
                case DateTime dt:
                    KozmosArgumentNullExceptionHelper.ThrowIfNull(options);
                    return Convert(dt, options.DateTimeComponent);
                case DateTimeOffset dto:
                    KozmosArgumentNullExceptionHelper.ThrowIfNull(options);
                    return Convert(dto, options.DateTimeOffsetComponent);
                case TimeOnly to:
                    KozmosArgumentNullExceptionHelper.ThrowIfNull(options);
                    return Convert(to, options.TimeOnlyComponent);
                case TimeSpan ts:
                    KozmosArgumentNullExceptionHelper.ThrowIfNull(options);
                    return Convert(ts, options.TimeSpanComponent);
                // < Temporals

                // Textuals >
                case String s:
                    KozmosArgumentNullExceptionHelper.ThrowIfNull(options);
                    return Convert(s, options.IParsableConvertOptions);
                // < Textuals

                case null:
                    if (!IsNullable) KozmosArgumentNullExceptionHelper.Throw(source);
                    return default;

                default:
                    return default;
            }
        }

        #endregion

        #endregion

        #region TryConvert

        #region Conditionals

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean TryConvert(Boolean? source, out T result)
        {
            if (__TryAssertConvert(source)) { result = default; return IsNullable; }
            return TryConvert(source.Value, out result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean TryConvert(Boolean source, out T result)
        {
            result = source ? One : Zero; return true;
        }

        #endregion

        #region Codeds

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean TryConvert(Char? source, out T result)
        {
            return TryConvert(source, KozmosNumberConvertOptions.Default.CharComponent, out result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean TryConvert(Char? source, EKozmosCharComponent component, out T result)
        {
            if(__TryAssertConvert(source)) { result = default; return IsNullable; }
            return TryConvert(source.Value, component, out result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean TryConvert(Char source, out T result)
        {
            return TryConvert(source, KozmosNumberConvertOptions.Default.CharComponent, out result);
        }

        [MethodImpl(MethodImplOptions.AggressiveOptimization)]
        public static Boolean TryConvert(Char source, EKozmosCharComponent component, out T result)
        {
            KozmosTypeHelper<T>.AssertTypeParameterCache(nameof(T));

            switch (component)
            {
                case EKozmosCharComponent.Numeric:
                    UInt32 ui32 = (UInt32)source - '0';
                    if (ui32 <= 9)
                    {
                        switch (KozmosTypeHelper<T>.Enum.Value)
                        {
                            case EKozmosType.UInt32:
                                result = Unsafe.As<UInt32, T>(ref ui32);
                                return true;
                            case EKozmosType.NullableUInt32:
                                UInt32? nui32 = ui32; result = Unsafe.As<UInt32?, T>(ref nui32);
                                return true;
                            default:
                                return TryConvert(ui32, out result);
                        }
                    }
                    Double d = Char.GetNumericValue(source);
                    if (d < 0.0d) { result = default; return false; }
                    switch (KozmosTypeHelper<T>.Enum.Value)
                    {
                        case EKozmosType.Double:
                            result = Unsafe.As<Double, T>(ref d);
                            return true;
                        case EKozmosType.NullableDouble:
                            Double? nd = d; result = Unsafe.As<Double?, T>(ref nd);
                            return true;
                        default:
                            return TryConvert(d, out result);
                    }
                case EKozmosCharComponent.CodePoint:
                    UInt16 ui16 = (UInt16)source;
                    switch (KozmosTypeHelper<T>.Enum.Value)
                    {
                        case EKozmosType.UInt16:
                            result = Unsafe.As<UInt16, T>(ref ui16);
                            return true;
                        case EKozmosType.NullableUInt16:
                            UInt16? nui16 = ui16; result = Unsafe.As<UInt16?, T>(ref nui16);
                            return true;
                        default:
                            return TryConvert(ui16, out result);
                    }
                default:
                    KozmosArgumentExceptionHelper.ThrowValue_0_OfArgument_1_2_IsNotSupported(component);
                    result = default;
                    return false;
            }
        }

        #endregion

        #region Fluidized

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean TryConvert(Byte[]? source, out T result)
        {
            if (__AssertConvert(source)) { result = default; return IsNullable; }
            return TryConvert(source.AsSpan(), out result);
        }

        [MethodImpl(MethodImplOptions.AggressiveOptimization)]
        public static Boolean TryConvert(ReadOnlySpan<Byte> source, out T result)
        {
            KozmosTypeHelper<T>.AssertTypeParameterCache(nameof(T));

            switch (KozmosTypeHelper<T>.Enum.Value)
            {
                case EKozmosType.Byte:
                case EKozmosType.NullableByte:
                    if (!KozmosBinaryPrimitivesHelper.TryReadByteLittleEndian(source, out Byte by)) break;
                    else if (KozmosTypeHelper<T>.Enum.Value == EKozmosType.Byte) result = Unsafe.As<Byte, T>(ref by);
                    else { Byte? nby = by; result = Unsafe.As<Byte?, T>(ref nby); }
                    return true;

                case EKozmosType.SByte:
                case EKozmosType.NullableSByte:
                    if (!KozmosBinaryPrimitivesHelper.TryReadSByteLittleEndian(source, out SByte sby)) break;
                    else if (KozmosTypeHelper<T>.Enum.Value == EKozmosType.SByte) result = Unsafe.As<SByte, T>(ref sby);
                    else { SByte? nsby = sby; result = Unsafe.As<SByte?, T>(ref nsby); }
                    return true;

                case EKozmosType.UInt16:
                case EKozmosType.NullableUInt16:
                    if (!KozmosBinaryPrimitivesHelper.TryReadUInt16LittleEndian(source, out UInt16 ui16)) break;
                    else if (KozmosTypeHelper<T>.Enum.Value == EKozmosType.UInt16) result = Unsafe.As<UInt16, T>(ref ui16);
                    else { UInt16? nui16 = ui16; result = Unsafe.As<UInt16?, T>(ref nui16); }
                    return true;

                case EKozmosType.Int16:
                case EKozmosType.NullableInt16:
                    if (!KozmosBinaryPrimitivesHelper.TryReadInt16LittleEndian(source, out Int16 i16)) break;
                    else if (KozmosTypeHelper<T>.Enum.Value == EKozmosType.Int16) result = Unsafe.As<Int16, T>(ref i16);
                    else { Int16? ni16 = i16; result = Unsafe.As<Int16?, T>(ref ni16); }
                    return true;

                case EKozmosType.UInt32:
                case EKozmosType.NullableUInt32:
                    if (!KozmosBinaryPrimitivesHelper.TryReadUInt32LittleEndian(source, out UInt32 ui32)) break;
                    else if (KozmosTypeHelper<T>.Enum.Value == EKozmosType.UInt32) result = Unsafe.As<UInt32, T>(ref ui32);
                    else { UInt32? nui32 = ui32; result = Unsafe.As<UInt32?, T>(ref nui32); }
                    return true;

                case EKozmosType.Int32:
                case EKozmosType.NullableInt32:
                    if (!KozmosBinaryPrimitivesHelper.TryReadInt32LittleEndian(source, out Int32 i32)) break;
                    else if (KozmosTypeHelper<T>.Enum.Value == EKozmosType.Int32) result = Unsafe.As<Int32, T>(ref i32);
                    else { Int32? ni32 = i32; result = Unsafe.As<Int32?, T>(ref ni32); }
                    return true;

                case EKozmosType.UInt64:
                case EKozmosType.NullableUInt64:
                    if (!KozmosBinaryPrimitivesHelper.TryReadUInt64LittleEndian(source, out UInt64 ui64)) break;
                    else if (KozmosTypeHelper<T>.Enum.Value == EKozmosType.UInt64) result = Unsafe.As<UInt64, T>(ref ui64);
                    else { UInt64? nui64 = ui64; result = Unsafe.As<UInt64?, T>(ref nui64); }
                    return true;

                case EKozmosType.Int64:
                case EKozmosType.NullableInt64:
                    if (!KozmosBinaryPrimitivesHelper.TryReadInt64LittleEndian(source, out Int64 i64)) break;
                    else if (KozmosTypeHelper<T>.Enum.Value == EKozmosType.Int64) result = Unsafe.As<Int64, T>(ref i64);
                    else { Int64? ni64 = i64; result = Unsafe.As<Int64?, T>(ref ni64); }
                    return true;

                case EKozmosType.UInt128:
                case EKozmosType.NullableUInt128:
                    if (!BinaryPrimitives.TryReadUInt128LittleEndian(source, out UInt128 ui128)) break;
                    else if (KozmosTypeHelper<T>.Enum.Value == EKozmosType.UInt128) result = Unsafe.As<UInt128, T>(ref ui128);
                    else { UInt128? nui128 = ui128; result = Unsafe.As<UInt128?, T>(ref nui128); }
                    return true;

                case EKozmosType.Int128:
                case EKozmosType.NullableInt128:
                    if (!BinaryPrimitives.TryReadInt128LittleEndian(source, out Int128 i128)) break;
                    else if (KozmosTypeHelper<T>.Enum.Value == EKozmosType.Int128) result = Unsafe.As<Int128, T>(ref i128);
                    else { Int128? ni128 = i128; result = Unsafe.As<Int128?, T>(ref ni128); }
                    return true;

                case EKozmosType.Single:
                case EKozmosType.NullableSingle:
                    if (!BinaryPrimitives.TryReadSingleLittleEndian(source, out Single f)) break;
                    else if (KozmosTypeHelper<T>.Enum.Value == EKozmosType.Single) result = Unsafe.As<Single, T>(ref f);
                    else { Single? nf = f; result = Unsafe.As<Single?, T>(ref nf); }
                    return true;

                case EKozmosType.Double:
                case EKozmosType.NullableDouble:
                    if (!BinaryPrimitives.TryReadDoubleLittleEndian(source, out Double d)) break;
                    else if (KozmosTypeHelper<T>.Enum.Value == EKozmosType.Double) result = Unsafe.As<Double, T>(ref d);
                    else { Double? nd = d; result = Unsafe.As<Double?, T>(ref nd); }
                    return true;

                case EKozmosType.Decimal:
                case EKozmosType.NullableDecimal:
                    if (!KozmosBinaryPrimitivesHelper.TryReadDecimalLittleEndian(source, out Decimal m)) break;
                    else if (KozmosTypeHelper<T>.Enum.Value == EKozmosType.Decimal) result = Unsafe.As<Decimal, T>(ref m);
                    else { Decimal? nm = m; result = Unsafe.As<Decimal?, T>(ref nm); }
                    return true;

                default:
                    KozmosExceptionHelper<T>.ThrowTheTypeParameter_0_1_IsNotSupported(nameof(T));
                    break;
            }

            result = default; return false;
        }

        #endregion

        #region Lizatings

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean TryConvert(JsonElement? source, out T result)
        {
            return TryConvert(source, KozmosNumberIParsableConvertOptions.Default, out result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean TryConvert(JsonElement? source, KozmosNumberIParsableConvertOptions option, out T result)
        {
            if (__TryAssertConvert(source)) { result = default; return IsNullable; }
            return TryConvert(source.Value, option, out result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean TryConvert(JsonElement source, out T result)
        {
            return TryConvert(source, KozmosNumberIParsableConvertOptions.Default, out result);
        }

        [MethodImpl(MethodImplOptions.AggressiveOptimization)]
        public static Boolean TryConvert(JsonElement source, KozmosNumberIParsableConvertOptions options, out T result)
        {
            switch(source.ValueKind)
            {
                // Conditionals >
                case JsonValueKind.True:
                    result = One; return true;
                case JsonValueKind.False:
                    result = Zero; return true;
                // < Conditionals

                // Numericals >
                case JsonValueKind.Number:
                    KozmosTypeHelper<T>.AssertTypeParameterCache(nameof(T));

                    switch (KozmosTypeHelper<T>.Enum.Value)
                    {
                        case EKozmosType.Byte:
                        case EKozmosType.NullableByte:
                            if (!source.TryGetByte(out Byte by)) break;
                            else if (KozmosTypeHelper<T>.Enum.Value == EKozmosType.Byte) result = Unsafe.As<Byte, T>(ref by);
                            else { Byte? nby = by; result = Unsafe.As<Byte?, T>(ref nby); }
                            return true;

                        case EKozmosType.SByte:
                        case EKozmosType.NullableSByte:
                            if (!source.TryGetSByte(out SByte sby)) break;
                            else if (KozmosTypeHelper<T>.Enum.Value == EKozmosType.SByte) result = Unsafe.As<SByte, T>(ref sby);
                            else { SByte? nsby = sby; result = Unsafe.As<SByte?, T>(ref nsby); }
                            return true;

                        case EKozmosType.UInt16:
                        case EKozmosType.NullableUInt16:
                            if (!source.TryGetUInt16(out UInt16 ui16)) break;
                            else if (KozmosTypeHelper<T>.Enum.Value == EKozmosType.UInt16) result = Unsafe.As<UInt16, T>(ref ui16);
                            else { UInt16? nui16 = ui16; result = Unsafe.As<UInt16?, T>(ref nui16); }
                            return true;

                        case EKozmosType.Int16:
                        case EKozmosType.NullableInt16:
                            if (!source.TryGetInt16(out Int16 i16)) break;
                            else if (KozmosTypeHelper<T>.Enum.Value == EKozmosType.Int16) result = Unsafe.As<Int16, T>(ref i16);
                            else { Int16? ni16 = i16; result = Unsafe.As<Int16?, T>(ref ni16); }
                            return true;

                        case EKozmosType.UInt32:
                        case EKozmosType.NullableUInt32:
                            if (!source.TryGetUInt32(out UInt32 ui32)) break;
                            else if (KozmosTypeHelper<T>.Enum.Value == EKozmosType.UInt32) result = Unsafe.As<UInt32, T>(ref ui32);
                            else { UInt32? nui32 = ui32; result = Unsafe.As<UInt32?, T>(ref nui32); }
                            return true;

                        case EKozmosType.Int32:
                        case EKozmosType.NullableInt32:
                            if (!source.TryGetInt32(out Int32 i32)) break;
                            else if (KozmosTypeHelper<T>.Enum.Value == EKozmosType.Int32) result = Unsafe.As<Int32, T>(ref i32);
                            else { Int32? ni32 = i32; result = Unsafe.As<Int32?, T>(ref ni32); }
                            return true;

                        case EKozmosType.UInt64:
                        case EKozmosType.NullableUInt64:
                            if (!source.TryGetUInt64(out UInt64 ui64)) break;
                            else if (KozmosTypeHelper<T>.Enum.Value == EKozmosType.UInt64) result = Unsafe.As<UInt64, T>(ref ui64);
                            else { UInt64? nui64 = ui64; result = Unsafe.As<UInt64?, T>(ref nui64); }
                            return true;

                        case EKozmosType.Int64:
                        case EKozmosType.NullableInt64:
                            if (!source.TryGetInt64(out Int64 i64)) break;
                            else if (KozmosTypeHelper<T>.Enum.Value == EKozmosType.Int64) result = Unsafe.As<Int64, T>(ref i64);
                            else { Int64? ni64 = i64; result = Unsafe.As<Int64?, T>(ref ni64); }
                            return true;

                        case EKozmosType.UInt128:
                        case EKozmosType.NullableUInt128:
                            if (!source.TryGetUInt128(out UInt128 ui128)) break;
                            else if (KozmosTypeHelper<T>.Enum.Value == EKozmosType.UInt128) result = Unsafe.As<UInt128, T>(ref ui128);
                            else { UInt128? nui128 = ui128; result = Unsafe.As<UInt128?, T>(ref nui128); }
                            return true;

                        case EKozmosType.Int128:
                        case EKozmosType.NullableInt128:
                            if (!source.TryGetInt128(out Int128 i128)) break;
                            else if (KozmosTypeHelper<T>.Enum.Value == EKozmosType.Int128) result = Unsafe.As<Int128, T>(ref i128);
                            else { Int128? ni128 = i128; result = Unsafe.As<Int128?, T>(ref ni128); }
                            return true;

                        case EKozmosType.Single:
                        case EKozmosType.NullableSingle:
                            if (!source.TryGetSingle(out Single s)) break;
                            else if (KozmosTypeHelper<T>.Enum.Value == EKozmosType.Single) result = Unsafe.As<Single, T>(ref s);
                            else { Single? ns = s; result = Unsafe.As<Single?, T>(ref ns); }
                            return true;

                        case EKozmosType.Double:
                        case EKozmosType.NullableDouble:
                            if (!source.TryGetDouble(out Double d)) break;
                            else if (KozmosTypeHelper<T>.Enum.Value == EKozmosType.Double) result = Unsafe.As<Double, T>(ref d);
                            else { Double? nd = d; result = Unsafe.As<Double?, T>(ref nd); }
                            return true;

                        case EKozmosType.Decimal:
                        case EKozmosType.NullableDecimal:
                            if (!source.TryGetDecimal(out Decimal m)) break;
                            else if (KozmosTypeHelper<T>.Enum.Value == EKozmosType.Decimal) result = Unsafe.As<Decimal, T>(ref m);
                            else { Decimal? nm = m; result = Unsafe.As<Decimal?, T>(ref nm); }
                            return true;

                        default:
                            KozmosExceptionHelper<T>.ThrowTheTypeParameter_0_1_IsNotSupported(nameof(T));
                            break;
                    }

                    result = default;
                    return false;

                // < Numericals

                // Textuals >
                case JsonValueKind.String:
                    return TryConvert(source.ToString(), options, out result);
                // < Textuals

                // Others >
                case JsonValueKind.Undefined:
                case JsonValueKind.Null:
                    result = default; return IsNullable;
                // < Others

                default:
                    KozmosExceptionHelper.ThrowValue_0_OfMember_1_2_OfArgument_3_4_IsNotSupported
                    (
                        source.ValueKind,
                        nameof(source.ValueKind),
                        source
                    );
                    result = default;
                    return false;
            }
        }

        #endregion

        #region Numericals

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean TryConvert<TSource>(TSource? source, out T result)
            where TSource : struct, INumber<TSource>
        {
            if (__TryAssertConvert(source)) { result = default; return IsNullable; }
            return TryConvert(source.Value, out result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean TryConvert<TSource>(TSource source, out T result)
            where TSource : struct, INumber<TSource>
        {
            if(WillOverflow(source)) { result = default; return false; }
            result = T.CreateTruncating(source); return true;
        }

        #endregion

        #region Temporals

        #region DateOnly

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean TryConvert(DateOnly? source, out T result)
        {
            return TryConvert(source, KozmosNumberConvertOptions.Default.DateOnlyComponent, out result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean TryConvert(DateOnly? source, EKozmosDateOnlyComponent component, out T result)
        {
            if(__TryAssertConvert(source)) { result = default; return IsNullable; }
            return TryConvert(source.Value, component, out result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean TryConvert(DateOnly source, out T result)
        {
            return TryConvert(source, KozmosNumberConvertOptions.Default.DateOnlyComponent, out result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean TryConvert(DateOnly source, EKozmosDateOnlyComponent component, out T result)
        {
            switch (component)
            {
                case EKozmosDateOnlyComponent.DayNumber: return TryConvert(source.DayNumber, out result);
                case EKozmosDateOnlyComponent.Day: return TryConvert(source.Day, out result);
                case EKozmosDateOnlyComponent.DayOfWeek: return TryConvert(source.DayOfWeek, out result);
                case EKozmosDateOnlyComponent.DayOfYear: return TryConvert(source.DayOfYear, out result);
                case EKozmosDateOnlyComponent.Month: return TryConvert(source.Month, out result);
                case EKozmosDateOnlyComponent.Year: return TryConvert(source.Year, out result);
                default:
                    KozmosArgumentExceptionHelper.ThrowValue_0_OfArgument_1_2_IsNotSupported(component);
                    result = default; return false;
            }
        }

        #endregion

        #region DateTime

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean TryConvert(DateTime? source, out T result)
        {
            return TryConvert(source, KozmosNumberConvertOptions.Default.DateTimeComponent, out result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean TryConvert(DateTime? source, EKozmosDateTimeComponent component, out T result)
        {
            if (__TryAssertConvert(source)) { result = default; return IsNullable; }
            return TryConvert(source.Value, component, out result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean TryConvert(DateTime source, out T result)
        {
            return TryConvert(source, KozmosNumberConvertOptions.Default.DateTimeComponent, out result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean TryConvert(DateTime source, EKozmosDateTimeComponent component, out T result)
        {
            switch (component)
            {
                case EKozmosDateTimeComponent.Nanosecond: return TryConvert(source.Nanosecond, out result);
                case EKozmosDateTimeComponent.Microsecond: return TryConvert(source.Microsecond, out result);
                case EKozmosDateTimeComponent.Millisecond: return TryConvert(source.Millisecond, out result);
                case EKozmosDateTimeComponent.Second: return TryConvert(source.Second, out result);
                case EKozmosDateTimeComponent.Minute: return TryConvert(source.Minute, out result);
                case EKozmosDateTimeComponent.Hour: return TryConvert(source.Hour, out result);
                case EKozmosDateTimeComponent.Day: return TryConvert(source.Day, out result);
                case EKozmosDateTimeComponent.DayOfWeek: return TryConvert(source.DayOfWeek, out result);
                case EKozmosDateTimeComponent.DayOfYear: return TryConvert(source.DayOfYear, out result);
                case EKozmosDateTimeComponent.Month: return TryConvert(source.Month, out result);
                case EKozmosDateTimeComponent.Year: return TryConvert(source.Year, out result);
                case EKozmosDateTimeComponent.Ticks: return TryConvert(source.Ticks, out result);
                default:
                    KozmosArgumentExceptionHelper.ThrowValue_0_OfArgument_1_2_IsNotSupported(component);
                    result = default; return false;
            }
        }

        #endregion

        #region DateTimeOffset

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean TryConvert(DateTimeOffset? source, out T result)
        {
            return TryConvert(source, KozmosNumberConvertOptions.Default.DateTimeOffsetComponent, out result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean TryConvert(DateTimeOffset? source, EKozmosDateTimeOffsetComponent component, out T result)
        {
            if (__TryAssertConvert(source)) { result = default; return IsNullable; }
            return TryConvert(source.Value, component, out result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean TryConvert(DateTimeOffset source, out T result)
        {
            return TryConvert(source, KozmosNumberConvertOptions.Default.DateTimeOffsetComponent, out result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean TryConvert(DateTimeOffset source, EKozmosDateTimeOffsetComponent component, out T result)
        {
            switch (component)
            {
                case EKozmosDateTimeOffsetComponent.Nanosecond: return TryConvert(source.Nanosecond, out result);
                case EKozmosDateTimeOffsetComponent.Microsecond: return TryConvert(source.Microsecond, out result);
                case EKozmosDateTimeOffsetComponent.Millisecond: return TryConvert(source.Millisecond, out result);
                case EKozmosDateTimeOffsetComponent.Second: return TryConvert(source.Second, out result);
                case EKozmosDateTimeOffsetComponent.Minute: return TryConvert(source.Minute, out result);
                case EKozmosDateTimeOffsetComponent.Hour: return TryConvert(source.Hour, out result);
                case EKozmosDateTimeOffsetComponent.Day: return TryConvert(source.Day, out result);
                case EKozmosDateTimeOffsetComponent.DayOfWeek: return TryConvert(source.DayOfWeek, out result);
                case EKozmosDateTimeOffsetComponent.DayOfYear: return TryConvert(source.DayOfYear, out result);
                case EKozmosDateTimeOffsetComponent.Month: return TryConvert(source.Month, out result);
                case EKozmosDateTimeOffsetComponent.Year: return TryConvert(source.Year, out result);
                case EKozmosDateTimeOffsetComponent.Ticks: return TryConvert(source.Ticks, out result);
                default:
                    KozmosArgumentExceptionHelper.ThrowValue_0_OfArgument_1_2_IsNotSupported(component);
                    result = default; return false;
            }
        }

        #endregion

        #region TimeOnly

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean TryConvert(TimeOnly? source, out T result)
        {
            return TryConvert(source, KozmosNumberConvertOptions.Default.TimeOnlyComponent, out result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean TryConvert(TimeOnly? source, EKozmosTimeOnlyComponent component, out T result)
        {
            if (__TryAssertConvert(source)) { result = default; return IsNullable; }
            return TryConvert(source.Value, component, out result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean TryConvert(TimeOnly source, out T result)
        {
            return TryConvert(source, KozmosNumberConvertOptions.Default.TimeOnlyComponent, out result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean TryConvert(TimeOnly source, EKozmosTimeOnlyComponent component, out T result)
        {
            switch (component)
            {
                case EKozmosTimeOnlyComponent.Nanosecond: return TryConvert(source.Nanosecond, out result);
                case EKozmosTimeOnlyComponent.Microsecond: return TryConvert(source.Microsecond, out result);
                case EKozmosTimeOnlyComponent.Millisecond: return TryConvert(source.Millisecond, out result);
                case EKozmosTimeOnlyComponent.Second: return TryConvert(source.Second, out result);
                case EKozmosTimeOnlyComponent.Minute: return TryConvert(source.Minute, out result);
                case EKozmosTimeOnlyComponent.Hour: return TryConvert(source.Hour, out result);
                case EKozmosTimeOnlyComponent.Ticks: return TryConvert(source.Ticks, out result);
                default:
                    KozmosArgumentExceptionHelper.ThrowValue_0_OfArgument_1_2_IsNotSupported(component);
                    result = default; return false;
            }
        }

        #endregion

        #region TimeSpan

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean TryConvert(TimeSpan? source, out T result)
        {
            return TryConvert(source, KozmosNumberConvertOptions.Default.TimeSpanComponent, out result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean TryConvert(TimeSpan? source, EKozmosTimeSpanComponent component, out T result)
        {
            if (__TryAssertConvert(source)) { result = default; return IsNullable; }
            return TryConvert(source.Value, component, out result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean TryConvert(TimeSpan source, out T result)
        {
            return TryConvert(source, KozmosNumberConvertOptions.Default.TimeSpanComponent, out result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean TryConvert(TimeSpan source, EKozmosTimeSpanComponent component, out T result)
        {
            switch (component)
            {
                case EKozmosTimeSpanComponent.Ticks: return TryConvert(source.Ticks, out result);
                case EKozmosTimeSpanComponent.Nanoseconds: return TryConvert(source.Nanoseconds, out result);
                case EKozmosTimeSpanComponent.TotalNanoseconds: return TryConvert(source.TotalNanoseconds, out result);
                case EKozmosTimeSpanComponent.Microseconds: return TryConvert(source.Microseconds, out result);
                case EKozmosTimeSpanComponent.TotalMicroseconds: return TryConvert(source.TotalMicroseconds, out result);
                case EKozmosTimeSpanComponent.Milliseconds: return TryConvert(source.Milliseconds, out result);
                case EKozmosTimeSpanComponent.TotalMilliseconds: return TryConvert(source.TotalMilliseconds, out result);
                case EKozmosTimeSpanComponent.Seconds: return TryConvert(source.Seconds, out result);
                case EKozmosTimeSpanComponent.TotalSeconds: return TryConvert(source.TotalSeconds, out result);
                case EKozmosTimeSpanComponent.Minutes: return TryConvert(source.Minutes, out result);
                case EKozmosTimeSpanComponent.TotalMinutes: return TryConvert(source.TotalMinutes, out result);
                case EKozmosTimeSpanComponent.Hours: return TryConvert(source.Hours, out result);
                case EKozmosTimeSpanComponent.TotalHours: return TryConvert(source.TotalHours, out result);
                case EKozmosTimeSpanComponent.Days: return TryConvert(source.Days, out result);
                case EKozmosTimeSpanComponent.TotalDays: return TryConvert(source.TotalDays, out result);
            }

            result = default; return false;
        }

        #endregion

        #endregion

        #region Textuals

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean TryConvert(String? source, out T result)
        {
            return TryConvert(source, KozmosNumberIParsableConvertOptions.Default, out result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean TryConvert(String? source, KozmosNumberIParsableConvertOptions options, out T result)
        {
            if (__TryAssertConvert(source)) { result = default; return IsNullable; }
            KozmosArgumentNullExceptionHelper.ThrowIfNull(options);
            return T.TryParse(source, options.NumberStyles, options.FormatProvider, out result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean TryConvert(ReadOnlySpan<Char> source, out T result)
        {
            return TryConvert(source, KozmosNumberIParsableConvertOptions.Default, out result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean TryConvert(ReadOnlySpan<Char> source, KozmosNumberIParsableConvertOptions options, out T result)
        {
            KozmosArgumentNullExceptionHelper.ThrowIfNull(options);
            return T.TryParse(source, options.NumberStyles, options.FormatProvider, out result);
        }

        #endregion

        #region Objects

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean TryConvert(Object? source, out T result) { return TryConvert(source, KozmosNumberConvertOptions.Default, out result); }

        [MethodImpl(MethodImplOptions.AggressiveOptimization)]
        public static Boolean TryConvert(Object? source, KozmosNumberConvertOptions options, out T result)
        {
            switch (source)
            {
                // HotPath >
                case T result0: result = result0; return true;
                // < HotPath

                // Conditionals >
                case Boolean b: return TryConvert(b, out result);
                // < Conditionals

                // Codeds >
                case Char c:
                    KozmosArgumentNullExceptionHelper.ThrowIfNull(options);
                    return TryConvert(c, options.CharComponent, out result);
                // < Codeds

                // Fluidized >
                case Byte[] ba: return TryConvert(ba, out result);
                // < Fluidized

                // Lizatings >
                case JsonElement je:
                    KozmosArgumentNullExceptionHelper.ThrowIfNull(options);
                    return TryConvert(je, options.IParsableConvertOptions, out result);
                // < Lizatings

                // Numericals >
                case Byte by: return TryConvert(by, out result);
                case SByte sby: return TryConvert(sby, out result);
                case UInt16 ui16: return TryConvert(ui16, out result);
                case Int16 i16: return TryConvert(i16, out result);
                case UInt32 ui32: return TryConvert(ui32, out result);
                case Int32 i32: return TryConvert(i32, out result);
                case UInt64 ui64: return TryConvert(ui64, out result);
                case Int64 i64: return TryConvert(i64, out result);
                case UInt128 ui128: return TryConvert(ui128, out result);
                case Int128 i128: return TryConvert(i128, out result);
                case BigInteger bi: return TryConvert(bi, out result);
                case Decimal m: return TryConvert(m, out result);
                case Single f: return TryConvert(f, out result);
                case Double d: return TryConvert(d, out result);
                // < Numericals

                // Temporals >
                case DateOnly don:
                    KozmosArgumentNullExceptionHelper.ThrowIfNull(options);
                    return TryConvert(don, options.DateOnlyComponent, out result);
                case DateTime dt:
                    KozmosArgumentNullExceptionHelper.ThrowIfNull(options);
                    return TryConvert(dt, options.DateTimeComponent, out result);
                case DateTimeOffset dto:
                    KozmosArgumentNullExceptionHelper.ThrowIfNull(options);
                    return TryConvert(dto, options.DateTimeOffsetComponent, out result);
                case TimeOnly to:
                    KozmosArgumentNullExceptionHelper.ThrowIfNull(options);
                    return TryConvert(to, options.TimeOnlyComponent, out result);
                case TimeSpan ts:
                    KozmosArgumentNullExceptionHelper.ThrowIfNull(options);
                    return TryConvert(ts, options.TimeSpanComponent, out result);
                // < Temporals

                // Textuals >
                case String s:
                    KozmosArgumentNullExceptionHelper.ThrowIfNull(options);
                    return TryConvert(s, options.IParsableConvertOptions, out result);
                // < Textuals

                case null:
                    result = default;
                    return IsNullable;

                default:
                    result = default;
                    return false;
            }
        }

        #endregion

        #endregion

        #region __Convert

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static Boolean __AssertConvert(Object? source, [CallerArgumentExpression(nameof(source))] String? paramName = null)
        {
            if (source is not null) return false;
            else if (IsNullable) return true;
            KozmosArgumentNullExceptionHelper.Throw(paramName);
            return false;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static Boolean __AssertConvert<TSource>(TSource? source, [CallerArgumentExpression(nameof(source))] String? paramName = null) where TSource : struct
        {
            if (source.HasValue) return false;
            else if (IsNullable) return true;
            KozmosArgumentNullExceptionHelper.Throw(paramName);
            return false;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static Boolean __TryAssertConvert(Object? source) { return source is null; }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static Boolean __TryAssertConvert<TSource>(TSource? source) where TSource : struct { return !source.HasValue; }

        #endregion

        #endregion
    }

    public sealed class KozmosByteHelper : KozmosNumberHelper<Byte> { }
    //public sealed class KozmosNullableByteHelper : KozmosNumberHelper<Byte?, Byte> { }

    public sealed class KozmosSByteHelper : KozmosNumberHelper<SByte> { }
    //public sealed class KozmosNullableSByteHelper : KozmosNumberHelper<SByte?, SByte> { }

    public sealed class KozmosUInt16Helper : KozmosNumberHelper<UInt16> { }
    //public sealed class KozmosNullableUInt16Helper : KozmosNumberHelper<UInt16?, UInt16> { }

    public sealed class KozmosInt16Helper : KozmosNumberHelper<Int16> { }
    //public sealed class KozmosNullableInt16Helper : KozmosNumberHelper<Int16?, Int16> { }

    public sealed class KozmosUInt32Helper : KozmosNumberHelper<UInt32> { }
    //public sealed class KozmosNullableUInt32Helper : KozmosNumberHelper<UInt32?, UInt32> { }

    public sealed class KozmosInt32Helper : KozmosNumberHelper<Int32> { }
    //public sealed class KozmosNullableInt32Helper : KozmosNumberHelper<Int32?, Int32> { }

    public sealed class KozmosUInt64Helper : KozmosNumberHelper<UInt64> { }
    //public sealed class KozmosNullableUInt64Helper : KozmosNumberHelper<UInt64?, UInt64> { }

    public sealed class KozmosInt64Helper : KozmosNumberHelper<Int64> { }
    //public sealed class KozmosNullableInt64Helper : KozmosNumberHelper<Int64?, Int64> { }

    public sealed class KozmosUInt128Helper : KozmosNumberHelper<UInt128> { }
    //public sealed class KozmosNullableUInt128Helper : KozmosNumberHelper<UInt128?, UInt128> { }

    public sealed class KozmosInt128Helper : KozmosNumberHelper<Int128> { }
    //public sealed class KozmosNullableInt128Helper : KozmosNumberHelper<Int128?, Int128> { }

    public sealed class KozmosBigIntegerHelper : KozmosNumberHelper<BigInteger> { }
    //public sealed class KozmosNullableBigIntegerHelper : KozmosNumberHelper<BigInteger?, BigInteger> { }

    public sealed class KozmosDecimalHelper : KozmosNumberHelper<Decimal> { }
    //public sealed class KozmosNullableDecimalHelper : KozmosNumberHelper<Decimal?, Decimal> { }

    public sealed class KozmosSingleHelper : KozmosNumberHelper<Single> { }
    //public sealed class KozmosNullableSingleHelper : KozmosNumberHelper<Single?, Single> { }

    public sealed class KozmosDoubleHelper : KozmosNumberHelper<Double> { }
    //public sealed class KozmosNullableDoubleHelper : KozmosNumberHelper<Double?, Double> { }
}