using System;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text.Json;
using Kozmos.Constants;
using Kozmos.Enums;
using Kozmos.Options;

namespace Kozmos.Helpers
{
    public static class KozmosNumberHelper
    {
        #region MinValue

        #region public static ... GetMinValue...(...)

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T GetMinValue<T>() where T : struct, INumber<T>
        {
            return KozmosNumberHelper<T>.MinValue;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Object GetMinValue(Type source)
        {
            KozmosArgumentNullExceptionHelper.ThrowIfNull(source);
            TryGetMinValue(source, out Object? target); return target!;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Object GetMinValue(Object source)
        {
            KozmosArgumentNullExceptionHelper.ThrowIfNull(source);
            __FetchMinValue(source, out Object result); return result;
        }

        #endregion

        #region public static Boolean TryGetMinValue...(...)

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean TryGetMinValue<T>(out T result) where T : struct, INumber<T>
        {
            result = KozmosNumberHelper<T>.MinValue;
            return true;
        }

        [MethodImpl(MethodImplOptions.AggressiveOptimization)]
        public static Boolean TryGetMinValue(Type? source, out Object? target)
        {
            switch (source)
            {
                case Type t when t == KozmosTypeHelper<Byte>._: target = Byte.MinValue; return true;
                case Type t when t == KozmosTypeHelper<Byte?>._: target = null; return true;

                case Type t when t == KozmosTypeHelper<SByte>._: target = SByte.MinValue; return true;
                case Type t when t == KozmosTypeHelper<SByte?>._: target = null; return true;

                case Type t when t == KozmosTypeHelper<UInt16>._: target = UInt16.MinValue; return true;
                case Type t when t == KozmosTypeHelper<UInt16?>._: target = null; return true;

                case Type t when t == KozmosTypeHelper<Int16>._: target = Int16.MinValue; return true;
                case Type t when t == KozmosTypeHelper<Int16?>._: target = null; return true;

                case Type t when t == KozmosTypeHelper<UInt32>._: target = UInt32.MinValue; return true;
                case Type t when t == KozmosTypeHelper<UInt32?>._: target = null; return true;

                case Type t when t == KozmosTypeHelper<Int32>._: target = Int32.MinValue; return true;
                case Type t when t == KozmosTypeHelper<Int32?>._: target = null; return true;

                case Type t when t == KozmosTypeHelper<UInt64>._: target = UInt64.MinValue; return true;
                case Type t when t == KozmosTypeHelper<UInt64?>._: target = null; return true;

                case Type t when t == KozmosTypeHelper<Int64>._: target = Int64.MinValue; return true;
                case Type t when t == KozmosTypeHelper<Int64?>._: target = null; return true;

                case Type t when t == KozmosTypeHelper<UInt128>._: target = UInt128.MinValue; return true;
                case Type t when t == KozmosTypeHelper<UInt128?>._: target = null; return true;

                case Type t when t == KozmosTypeHelper<Int128>._: target = Int128.MinValue; return true;
                case Type t when t == KozmosTypeHelper<Int128?>._: target = null; return true;

                case Type t when t == KozmosTypeHelper<Decimal>._: target = Decimal.MinValue; return true;
                case Type t when t == KozmosTypeHelper<Decimal?>._: target = null; return true;

                case Type t when t == KozmosTypeHelper<Single>._: target = Single.MinValue; return true;
                case Type t when t == KozmosTypeHelper<Single?>._: target = null; return true;

                case Type t when t == KozmosTypeHelper<Double>._: target = Double.MinValue; return true;
                case Type t when t == KozmosTypeHelper<Double?>._: target = null; return true;

                case null:
                    target = null; return false;

                default:
                    KozmosExceptionHelper.ThrowValue_0_OfArgument_1_2_IsNotSupported(source);
                    target = null; return false;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean TryGetMinValue(Object? source, out Object target)
        {
            return __FetchMinValue(source, out target);
        }

        #endregion

        [MethodImpl(MethodImplOptions.AggressiveOptimization)]
        private static Boolean __FetchMinValue(Object? source, out Object target)
        {
            switch (source)
            {
                case Type t: return __FetchMinValue(t, out target);
                case Byte: target = Byte.MinValue; return true;
                case SByte: target = SByte.MinValue; return true;
                case UInt16: target = UInt16.MinValue; return true;
                case Int16: target = Int16.MinValue; return true;
                case UInt32: target = UInt32.MinValue; return true;
                case Int32: target = Int32.MinValue; return true;
                case UInt64: target = UInt64.MinValue; return true;
                case Int64: target = Int64.MinValue; return true;
                case UInt128: target = UInt128.MinValue; return true;
                case Int128: target = Int128.MinValue; return true;
                case Decimal: target = Decimal.MinValue; return true;
                case Single: target = Single.MinValue; return true;
                case Double: target = Double.MinValue; return true;
                case null: target = null!; return false;
                default:
                    KozmosExceptionHelper.ThrowValue_0_OfArgument_1_2_IsNotSupported(source);
                    target = null; return false;
            }
        }

        #endregion

        #region MaxValue

        #region public static ... GetMaxValue...(...)

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T GetMaxValue<T>() where T : struct, INumber<T>
        {
            return KozmosNumberHelper<T>.MaxValue;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Object GetMaxValue(Type source)
        {
            KozmosArgumentNullExceptionHelper.ThrowIfNull(source);
            TryGetMaxValue(source, out Object? target); return target!;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Object GetMaxValue(Object source)
        {
            KozmosArgumentNullExceptionHelper.ThrowIfNull(source);
            __FetchMaxValue(source, out Object? target); return target!;
        }

        #endregion

        #region public static Boolean TryGetMaxValue...(...)

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean TryGetMaxValue<T>(out T result) where T : struct, INumber<T>
        {
            result = KozmosNumberHelper<T>.MaxValue;
            return true;
        }

        [MethodImpl(MethodImplOptions.AggressiveOptimization)]
        public static Boolean TryGetMaxValue(Type? source, out Object? target)
        {
            switch (source)
            {
                case Type t when t == KozmosTypeHelper<Byte>._: target = Byte.MaxValue; return true;
                case Type t when t == KozmosTypeHelper<Byte?>._: target = null; return true;

                case Type t when t == KozmosTypeHelper<SByte>._: target = SByte.MaxValue; return true;
                case Type t when t == KozmosTypeHelper<SByte?>._: target = null; return true;

                case Type t when t == KozmosTypeHelper<UInt16>._: target = UInt16.MaxValue; return true;
                case Type t when t == KozmosTypeHelper<UInt16?>._: target = null; return true;

                case Type t when t == KozmosTypeHelper<Int16>._: target = Int16.MaxValue; return true;
                case Type t when t == KozmosTypeHelper<Int16?>._: target = null; return true;

                case Type t when t == KozmosTypeHelper<UInt32>._: target = UInt32.MaxValue; return true;
                case Type t when t == KozmosTypeHelper<UInt32?>._: target = null; return true;

                case Type t when t == KozmosTypeHelper<Int32>._: target = Int32.MaxValue; return true;
                case Type t when t == KozmosTypeHelper<Int32?>._: target = null; return true;

                case Type t when t == KozmosTypeHelper<UInt64>._: target = UInt64.MaxValue; return true;
                case Type t when t == KozmosTypeHelper<UInt64?>._: target = null; return true;

                case Type t when t == KozmosTypeHelper<Int64>._: target = Int64.MaxValue; return true;
                case Type t when t == KozmosTypeHelper<Int64?>._: target = null; return true;

                case Type t when t == KozmosTypeHelper<UInt128>._: target = UInt128.MaxValue; return true;
                case Type t when t == KozmosTypeHelper<UInt128?>._: target = null; return true;

                case Type t when t == KozmosTypeHelper<Int128>._: target = Int128.MaxValue; return true;
                case Type t when t == KozmosTypeHelper<Int128?>._: target = null; return true;

                case Type t when t == KozmosTypeHelper<Decimal>._: target = Decimal.MaxValue; return true;
                case Type t when t == KozmosTypeHelper<Decimal?>._: target = null; return true;

                case Type t when t == KozmosTypeHelper<Single>._: target = Single.MaxValue; return true;
                case Type t when t == KozmosTypeHelper<Single?>._: target = null; return true;

                case Type t when t == KozmosTypeHelper<Double>._: target = Double.MaxValue; return true;
                case Type t when t == KozmosTypeHelper<Double?>._: target = null; return true;

                case null:
                    target = null; return false;

                default:
                    KozmosExceptionHelper.ThrowValue_0_OfArgument_1_2_IsNotSupported(source);
                    target = null; return false;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean TryGetMaxValue(Object? source, out Object target)
        {
            return __FetchMaxValue(source, out target);
        }

        #endregion

        [MethodImpl(MethodImplOptions.AggressiveOptimization)]
        private static Boolean __FetchMaxValue(Object? source, out Object target)
        {
            switch (source)
            {
                case Type t: return __FetchMaxValue(t, out target);
                case Byte: target = Byte.MaxValue; return true;
                case SByte: target = SByte.MaxValue; return true;
                case UInt16: target = UInt16.MaxValue; return true;
                case Int16: target = Int16.MaxValue; return true;
                case UInt32: target = UInt32.MaxValue; return true;
                case Int32: target = Int32.MaxValue; return true;
                case UInt64: target = UInt64.MaxValue; return true;
                case Int64: target = Int64.MaxValue; return true;
                case UInt128: target = UInt128.MaxValue; return true;
                case Int128: target = Int128.MaxValue; return true;
                case Decimal: target = Decimal.MaxValue; return true;
                case Single: target = Single.MaxValue; return true;
                case Double: target = Double.MaxValue; return true;
                case null: target = null!; return false;
                default:
                    KozmosExceptionHelper.ThrowValue_0_OfArgument_1_2_IsNotSupported(source);
                    target = null; return false;
            }
        }

        #endregion

        #region WillOverflow

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean WillOverflow<TSource, TDestination>(TSource? source)
            where TSource : struct, INumber<TSource>
            where TDestination : struct, INumber<TDestination>
        {
            return KozmosNumberHelper<TDestination>.WillOverflow(source);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean WillOverflow<TSource, TDestination>(TSource source)
            where TSource : struct, INumber<TSource>
            where TDestination : struct, INumber<TDestination>
        {
            return KozmosNumberHelper<TDestination>.WillOverflow(source);
        }

        [MethodImpl(MethodImplOptions.AggressiveOptimization)]
        public static Boolean WillOverflow(Object? source, Type destinationType)
        {
            switch (destinationType)
            {
                case Type t when t == KozmosTypeHelper<Byte>._: return WillOverflow<Byte>(source);
                case Type t when t == KozmosTypeHelper<SByte>._: return WillOverflow<SByte>(source);
                case Type t when t == KozmosTypeHelper<UInt16>._: return WillOverflow<UInt16>(source);
                case Type t when t == KozmosTypeHelper<Int16>._: return WillOverflow<Int16>(source);
                case Type t when t == KozmosTypeHelper<UInt32>._: return WillOverflow<UInt32>(source);
                case Type t when t == KozmosTypeHelper<Int32>._: return WillOverflow<Int32>(source);
                case Type t when t == KozmosTypeHelper<UInt64>._: return WillOverflow<UInt64>(source);
                case Type t when t == KozmosTypeHelper<Int64>._: return WillOverflow<Int64>(source);
                case Type t when t == KozmosTypeHelper<UInt128>._: return WillOverflow<UInt128>(source);
                case Type t when t == KozmosTypeHelper<Int128>._: return WillOverflow<Int128>(source);
                case Type t when t == KozmosTypeHelper<Decimal>._: return WillOverflow<Decimal>(source);
                case Type t when t == KozmosTypeHelper<Single>._: return WillOverflow<Single>(source);
                case Type t when t == KozmosTypeHelper<Double>._: return WillOverflow<Double>(source);

                case null:
                    KozmosArgumentNullExceptionHelper.Throw(destinationType);
                    return false;

                default:
                    KozmosExceptionHelper.ThrowValue_0_OfArgument_1_2_IsNotSupported(source);
                    return false;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveOptimization)]
        public static Boolean WillOverflow<TDestination>(Object? source)
            where TDestination : struct, INumber<TDestination>
        {
            switch (source)
            {
                case Byte by: return WillOverflow<Byte, TDestination>(by);
                case SByte sby: return WillOverflow<SByte, TDestination>(sby);
                case UInt16 ui16: return WillOverflow<UInt16, TDestination>(ui16);
                case Int16 i16: return WillOverflow<Int16, TDestination>(i16);
                case UInt32 ui32: return WillOverflow<UInt32, TDestination>(ui32);
                case Int32 i32: return WillOverflow<Int32, TDestination>(i32);
                case UInt64 ui64: return WillOverflow<UInt64, TDestination>(ui64);
                case Int64 i64: return WillOverflow<Int64, TDestination>(i64);
                case UInt128 ui128: return WillOverflow<UInt128, TDestination>(ui128);
                case Int128 i128: return WillOverflow<Int128, TDestination>(i128);
                case BigInteger bi: return WillOverflow<BigInteger, TDestination>(bi);
                case Decimal m: return WillOverflow<Decimal, TDestination>(m);
                case Single f: return WillOverflow<Single, TDestination>(f);
                case Double d: return WillOverflow<Double, TDestination>(d);
                case null: return false;
                default:
                    KozmosExceptionHelper.ThrowValue_0_OfArgument_1_2_IsNotSupported(source);
                    return false;
            }
        }

        #endregion

        #region public static Boolean IsOne...(...)

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean IsOne<T>(T source) where T : struct, INumber<T> { return KozmosNumberHelper<T>.IsOne(source); }

        [MethodImpl(MethodImplOptions.AggressiveOptimization)]
        public static Boolean IsOne(Object? source)
        {
            switch (source)
            {
                case Byte by: return IsOne(by);
                case SByte sby: return IsOne(sby);
                case UInt16 ui16: return IsOne(ui16);
                case Int16 i16: return IsOne(i16);
                case UInt32 ui32: return IsOne(ui32);
                case Int32 i32: return IsOne(i32);
                case UInt64 ui64: return IsOne(ui64);
                case Int64 i64: return IsOne(i64);
                case UInt128 ui128: return IsOne(ui128);
                case Int128 i128: return IsOne(i128);
                case BigInteger bi: return IsOne(bi);
                case Decimal m: return IsOne(m);
                case Single f: return IsOne(f);
                case Double d: return IsOne(d);
                case null: return false;
                default:
                    KozmosExceptionHelper.ThrowValue_0_OfArgument_1_2_IsNotSupported(source);
                    return false;
            }
        }

        #endregion

        #region public static Boolean IsNotOne...(...)

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean IsNotOne<T>(T source) where T : struct, INumber<T> { return KozmosNumberHelper<T>.IsNotOne(source); }

        [MethodImpl(MethodImplOptions.AggressiveOptimization)]
        public static Boolean IsNotOne(Object? source)
        {
            switch (source)
            {
                case Byte by: return IsNotOne(by);
                case SByte sby: return IsNotOne(sby);
                case UInt16 ui16: return IsNotOne(ui16);
                case Int16 i16: return IsNotOne(i16);
                case UInt32 ui32: return IsNotOne(ui32);
                case Int32 i32: return IsNotOne(i32);
                case UInt64 ui64: return IsNotOne(ui64);
                case Int64 i64: return IsNotOne(i64);
                case UInt128 ui128: return IsNotOne(ui128);
                case Int128 i128: return IsNotOne(i128);
                case BigInteger bi: return IsNotOne(bi);
                case Decimal m: return IsNotOne(m);
                case Single f: return IsNotOne(f);
                case Double d: return IsNotOne(d);
                case null: return false;
                default:
                    KozmosExceptionHelper.ThrowValue_0_OfArgument_1_2_IsNotSupported(source);
                    return false;
            }
        }

        #endregion

        #region public static Boolean IsZero...(...)

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean IsZero<T>(T source) where T : struct, INumber<T> { return KozmosNumberHelper<T>.IsZero(source); }

        [MethodImpl(MethodImplOptions.AggressiveOptimization)]
        public static Boolean IsZero(Object? source)
        {
            switch (source)
            {
                case Byte by: return IsZero(by);
                case SByte sby: return IsZero(sby);
                case UInt16 ui16: return IsZero(ui16);
                case Int16 i16: return IsZero(i16);
                case UInt32 ui32: return IsZero(ui32);
                case Int32 i32: return IsZero(i32);
                case UInt64 ui64: return IsZero(ui64);
                case Int64 i64: return IsZero(i64);
                case UInt128 ui128: return IsZero(ui128);
                case Int128 i128: return IsZero(i128);
                case BigInteger bi: return IsZero(bi);
                case Decimal m: return IsZero(m);
                case Single f: return IsZero(f);
                case Double d: return IsZero(d);
                case null: return false;
                default:
                    KozmosExceptionHelper.ThrowValue_0_OfArgument_1_2_IsNotSupported(source);
                    return false;
            }
        }

        #endregion

        #region public static Boolean IsNotZero...(...)

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean IsNotZero<T>(T source) where T : struct, INumber<T> { return KozmosNumberHelper<T>.IsNotZero(source); }

        [MethodImpl(MethodImplOptions.AggressiveOptimization)]
        public static Boolean IsNotZero(Object? source)
        {
            switch (source)
            {
                case Byte by: return IsNotZero(by);
                case SByte sby: return IsNotZero(sby);
                case UInt16 ui16: return IsNotZero(ui16);
                case Int16 i16: return IsNotZero(i16);
                case UInt32 ui32: return IsNotZero(ui32);
                case Int32 i32: return IsNotZero(i32);
                case UInt64 ui64: return IsNotZero(ui64);
                case Int64 i64: return IsNotZero(i64);
                case UInt128 ui128: return IsNotZero(ui128);
                case Int128 i128: return IsNotZero(i128);
                case BigInteger bi: return IsNotZero(bi);
                case Decimal m: return IsNotZero(m);
                case Single f: return IsNotZero(f);
                case Double d: return IsNotZero(d);
                case null: return false;
                default:
                    KozmosExceptionHelper.ThrowValue_0_OfArgument_1_2_IsNotSupported(source);
                    return false;
            }
        }

        #endregion

        #region public static Boolean Is...(...)

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean Is<T>() where T : INumber<T> { return true; }

        [MethodImpl(MethodImplOptions.AggressiveOptimization)]
        public static Boolean Is(Type? source)
        {
            switch (source)
            {
                case
                    var t
                when
                    t == KozmosTypeHelper<Byte>._ || t == KozmosTypeHelper<Byte?>._
                    || t == KozmosTypeHelper<SByte>._ || t == KozmosTypeHelper<SByte?>._
                    || t == KozmosTypeHelper<UInt16>._ || t == KozmosTypeHelper<UInt16?>._
                    || t == KozmosTypeHelper<Int16>._ || t == KozmosTypeHelper<Int16?>._
                    || t == KozmosTypeHelper<UInt32>._ || t == KozmosTypeHelper<UInt32?>._
                    || t == KozmosTypeHelper<Int32>._ || t == KozmosTypeHelper<Int32?>._
                    || t == KozmosTypeHelper<UInt64>._ || t == KozmosTypeHelper<UInt64?>._
                    || t == KozmosTypeHelper<Int64>._ || t == KozmosTypeHelper<Int64?>._
                    || t == KozmosTypeHelper<UInt128>._ || t == KozmosTypeHelper<UInt128?>._
                    || t == KozmosTypeHelper<Int128>._ || t == KozmosTypeHelper<Int128?>._
                    || t == KozmosTypeHelper<BigInteger>._ || t == KozmosTypeHelper<BigInteger?>._
                    || t == KozmosTypeHelper<Decimal>._ || t == KozmosTypeHelper<Decimal?>._
                    || t == KozmosTypeHelper<Single>._ || t == KozmosTypeHelper<Single?>._
                    || t == KozmosTypeHelper<Double>._ || t == KozmosTypeHelper<Double?>._:
                    return true;

                default:
                    return false;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveOptimization)]
        public static Boolean Is(Object? source)
        {
            switch (source)
            {
                case Type t:
                    return Is(t);

                case Byte:
                case SByte:
                case UInt16:
                case Int16:
                case UInt32:
                case Int32:
                case UInt64:
                case Int64:
                case UInt128:
                case Int128:
                case BigInteger:
                case Decimal:
                case Single:
                case Double:
                    return true;

                default:
                    return false;
            }
        }

        #endregion

        #region public static Boolean IsNullable...(...)

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean IsNullable<T>() where T : struct, INumber<T> { return KozmosNumberHelper<T>.IsNullable; }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean IsNullable<T>(T source) where T : struct, INumber<T> { return KozmosNumberHelper<T>.IsNullable; }

        [MethodImpl(MethodImplOptions.AggressiveOptimization)]
        public static Boolean IsNullable(Type source)
        {
            switch (source)
            {
                case
                    var t
                when
                    t == KozmosTypeHelper<Byte?>._
                    || t == KozmosTypeHelper<SByte?>._
                    || t == KozmosTypeHelper<UInt16?>._
                    || t == KozmosTypeHelper<Int16?>._
                    || t == KozmosTypeHelper<UInt32?>._
                    || t == KozmosTypeHelper<Int32?>._
                    || t == KozmosTypeHelper<UInt64?>._
                    || t == KozmosTypeHelper<Int64?>._
                    || t == KozmosTypeHelper<UInt128?>._
                    || t == KozmosTypeHelper<Int128?>._
                    || t == KozmosTypeHelper<BigInteger?>._
                    || t == KozmosTypeHelper<Decimal?>._
                    || t == KozmosTypeHelper<Single?>._
                    || t == KozmosTypeHelper<Double?>._:
                    return true;

                case
                    var t
                when
                    t == KozmosTypeHelper<Byte>._
                    || t == KozmosTypeHelper<SByte>._
                    || t == KozmosTypeHelper<UInt16>._
                    || t == KozmosTypeHelper<Int16>._
                    || t == KozmosTypeHelper<UInt32>._
                    || t == KozmosTypeHelper<Int32>._
                    || t == KozmosTypeHelper<UInt64>._
                    || t == KozmosTypeHelper<Int64>._
                    || t == KozmosTypeHelper<UInt128>._
                    || t == KozmosTypeHelper<Int128>._
                    || t == KozmosTypeHelper<BigInteger>._
                    || t == KozmosTypeHelper<Decimal>._
                    || t == KozmosTypeHelper<Single>._
                    || t == KozmosTypeHelper<Double>._:
                    return false;

                case null:
                    KozmosArgumentNullExceptionHelper.Throw(source);
                    return false;

                default:
                    KozmosExceptionHelper.ThrowValue_0_OfArgument_1_2_IsNotSupported(source);
                    return false;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveOptimization)]
        public static Boolean IsNullable(Object source)
        {
            switch (source)
            {
                case Type t:
                    return IsNullable(t);

                case Byte:
                case SByte:
                case UInt16:
                case Int16:
                case UInt32:
                case Int32:
                case UInt64:
                case Int64:
                case UInt128:
                case Int128:
                case BigInteger:
                case Decimal:
                case Single:
                case Double:
                    return false;

                case null:
                    KozmosArgumentNullExceptionHelper.Throw(source);
                    return false;

                default:
                    KozmosExceptionHelper.ThrowValue_0_OfArgument_1_2_IsNotSupported(source);
                    return false;
            }
        }

        #endregion

        #region Convert

        #region Conditionals

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TResult Convert<TResult>(Boolean? source)
            where TResult : struct, INumber<TResult>
        { return KozmosNumberHelper<TResult>.Convert(source); }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TResult Convert<TResult>(Boolean source)
            where TResult : struct, INumber<TResult>
        { return KozmosNumberHelper<TResult>.Convert(source); }

        [MethodImpl(MethodImplOptions.AggressiveOptimization)]
        public static Object? Convert(Boolean? source, Type resultType)
        {
            switch (resultType)
            {
                case Type t when t == KozmosTypeHelper<Byte>._: return Convert<Byte>(source);
                //case Type t when t == KozmosTypeHelper<Byte?>._: return Convert<Byte>(source);

                case Type t when t == KozmosTypeHelper<SByte>._: return Convert<SByte>(source);
                //case Type t when t == KozmosTypeHelper<SByte?>._: return Convert<SByte>(source);

                case Type t when t == KozmosTypeHelper<UInt16>._: return Convert<UInt16>(source);
                //case Type t when t == KozmosTypeHelper<UInt16?>._: return Convert<UInt16>(source);

                case Type t when t == KozmosTypeHelper<Int16>._: return Convert<Int16>(source);
                //case Type t when t == KozmosTypeHelper<Int16?>._: return Convert<Int16>(source);

                case Type t when t == KozmosTypeHelper<UInt32>._: return Convert<UInt32>(source);
                //case Type t when t == KozmosTypeHelper<UInt32?>._: return Convert<UInt32>(source);

                case Type t when t == KozmosTypeHelper<Int32>._: return Convert<Int32>(source);
                //case Type t when t == KozmosTypeHelper<Int32?>._: return Convert<Int32>(source);

                case Type t when t == KozmosTypeHelper<UInt64>._: return Convert<UInt64>(source);
                //case Type t when t == KozmosTypeHelper<UInt64?>._: return Convert<UInt64>(source);

                case Type t when t == KozmosTypeHelper<Int64>._: return Convert<Int64>(source);
                //case Type t when t == KozmosTypeHelper<Int64?>._: return Convert<Int64>(source);

                case Type t when t == KozmosTypeHelper<UInt128>._: return Convert<UInt128>(source);
                //case Type t when t == KozmosTypeHelper<UInt128?>._: return Convert<UInt128>(source);

                case Type t when t == KozmosTypeHelper<Int128>._: return Convert<Int128>(source);
                //case Type t when t == KozmosTypeHelper<Int128?>._: return Convert<Int128>(source);

                case Type t when t == KozmosTypeHelper<BigInteger>._: return Convert<BigInteger>(source);
                //case Type t when t == KozmosTypeHelper<BigInteger?>._: return Convert<BigInteger>(source);

                case Type t when t == KozmosTypeHelper<Decimal>._: return Convert<Decimal>(source);
                //case Type t when t == KozmosTypeHelper<Decimal?>._: return Convert<Decimal>(source);

                case Type t when t == KozmosTypeHelper<Single>._: return Convert<Single>(source);
                //case Type t when t == KozmosTypeHelper<Single?>._: return Convert<Single>(source);

                case Type t when t == KozmosTypeHelper<Double>._: return Convert<Double>(source);
                //case Type t when t == KozmosTypeHelper<Double?>._: return Convert<Double>(source);

                case null: KozmosArgumentNullExceptionHelper.Throw(resultType); return null;
            }

            KozmosExceptionHelper.ThrowValue_0_OfArgument_1_2_IsNotSupported(resultType);
            return null;
        }

        [MethodImpl(MethodImplOptions.AggressiveOptimization)]
        public static Object? Convert(Boolean source, Type resultType)
        {
            switch (resultType)
            {
                case Type t when t == KozmosTypeHelper<Byte>._: return Convert<Byte>(source);
                //case Type t when t == KozmosTypeHelper<Byte?>._: return Convert<Byte>(source);

                case Type t when t == KozmosTypeHelper<SByte>._: return Convert<SByte>(source);
                //case Type t when t == KozmosTypeHelper<SByte?>._: return Convert<SByte>(source);

                case Type t when t == KozmosTypeHelper<UInt16>._: return Convert<UInt16>(source);
                //case Type t when t == KozmosTypeHelper<UInt16?>._: return Convert<UInt16>(source);

                case Type t when t == KozmosTypeHelper<Int16>._: return Convert<Int16>(source);
                //case Type t when t == KozmosTypeHelper<Int16?>._: return Convert<Int16>(source);

                case Type t when t == KozmosTypeHelper<UInt32>._: return Convert<UInt32>(source);
                //case Type t when t == KozmosTypeHelper<UInt32?>._: return Convert<UInt32>(source);

                case Type t when t == KozmosTypeHelper<Int32>._: return Convert<Int32>(source);
                //case Type t when t == KozmosTypeHelper<Int32?>._: return Convert<Int32>(source);

                case Type t when t == KozmosTypeHelper<UInt64>._: return Convert<UInt64>(source);
                //case Type t when t == KozmosTypeHelper<UInt64?>._: return Convert<UInt64>(source);

                case Type t when t == KozmosTypeHelper<Int64>._: return Convert<Int64>(source);
                //case Type t when t == KozmosTypeHelper<Int64?>._: return Convert<Int64>(source);

                case Type t when t == KozmosTypeHelper<UInt128>._: return Convert<UInt128>(source);
                //case Type t when t == KozmosTypeHelper<UInt128?>._: return Convert<UInt128>(source);

                case Type t when t == KozmosTypeHelper<Int128>._: return Convert<Int128>(source);
                //case Type t when t == KozmosTypeHelper<Int128?>._: return Convert<Int128>(source);

                case Type t when t == KozmosTypeHelper<BigInteger>._: return Convert<BigInteger>(source);
                //case Type t when t == KozmosTypeHelper<BigInteger?>._: return Convert<BigInteger>(source);

                case Type t when t == KozmosTypeHelper<Decimal>._: return Convert<Decimal>(source);
                //case Type t when t == KozmosTypeHelper<Decimal?>._: return Convert<Decimal>(source);

                case Type t when t == KozmosTypeHelper<Single>._: return Convert<Single>(source);
                //case Type t when t == KozmosTypeHelper<Single?>._: return Convert<Single>(source);

                case Type t when t == KozmosTypeHelper<Double>._: return Convert<Double>(source);
                //case Type t when t == KozmosTypeHelper<Double?>._: return Convert<Double>(source);

                case null: KozmosArgumentNullExceptionHelper.Throw(resultType); return null;
            }

            KozmosExceptionHelper.ThrowValue_0_OfArgument_1_2_IsNotSupported(resultType);
            return null;
        }

        #endregion

        #region Codeds

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TResult Convert<TResult>(Char? source)
           where TResult : struct, INumber<TResult>
        { return KozmosNumberHelper<TResult>.Convert(source); }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TResult Convert<TResult>(Char? source, EKozmosCharComponent component)
           where TResult : struct, INumber<TResult>
        { return KozmosNumberHelper<TResult>.Convert(source, component); }

        [MethodImpl(MethodImplOptions.AggressiveOptimization)]
        public static Object? Convert(Char? source, Type resultType)
        {
            switch (resultType)
            {
                case Type t when t == KozmosTypeHelper<Byte>._: return Convert<Byte>(source);
                //case Type t when t == KozmosTypeHelper<Byte?>._: return Convert<Byte>(source);

                case Type t when t == KozmosTypeHelper<SByte>._: return Convert<SByte>(source);
                //case Type t when t == KozmosTypeHelper<SByte?>._: return Convert<SByte>(source);

                case Type t when t == KozmosTypeHelper<UInt16>._: return Convert<UInt16>(source);
                //case Type t when t == KozmosTypeHelper<UInt16?>._: return Convert<UInt16>(source);

                case Type t when t == KozmosTypeHelper<Int16>._: return Convert<Int16>(source);
                //case Type t when t == KozmosTypeHelper<Int16?>._: return Convert<Int16>(source);

                case Type t when t == KozmosTypeHelper<UInt32>._: return Convert<UInt32>(source);
                //case Type t when t == KozmosTypeHelper<UInt32?>._: return Convert<UInt32>(source);

                case Type t when t == KozmosTypeHelper<Int32>._: return Convert<Int32>(source);
                //case Type t when t == KozmosTypeHelper<Int32?>._: return Convert<Int32>(source);

                case Type t when t == KozmosTypeHelper<UInt64>._: return Convert<UInt64>(source);
                //case Type t when t == KozmosTypeHelper<UInt64?>._: return Convert<UInt64>(source);

                case Type t when t == KozmosTypeHelper<Int64>._: return Convert<Int64>(source);
                //case Type t when t == KozmosTypeHelper<Int64?>._: return Convert<Int64>(source);

                case Type t when t == KozmosTypeHelper<UInt128>._: return Convert<UInt128>(source);
                //case Type t when t == KozmosTypeHelper<UInt128?>._: return Convert<UInt128>(source);

                case Type t when t == KozmosTypeHelper<Int128>._: return Convert<Int128>(source);
                //case Type t when t == KozmosTypeHelper<Int128?>._: return Convert<Int128>(source);

                case Type t when t == KozmosTypeHelper<BigInteger>._: return Convert<BigInteger>(source);
                //case Type t when t == KozmosTypeHelper<BigInteger?>._: return Convert<BigInteger>(source);

                case Type t when t == KozmosTypeHelper<Decimal>._: return Convert<Decimal>(source);
                //case Type t when t == KozmosTypeHelper<Decimal?>._: return Convert<Decimal>(source);

                case Type t when t == KozmosTypeHelper<Single>._: return Convert<Single>(source);
                //case Type t when t == KozmosTypeHelper<Single?>._: return Convert<Single>(source);

                case Type t when t == KozmosTypeHelper<Double>._: return Convert<Double>(source);
                //case Type t when t == KozmosTypeHelper<Double?>._: return Convert<Double>(source);

                case null: KozmosArgumentNullExceptionHelper.Throw(resultType); return null;
            }

            KozmosExceptionHelper.ThrowValue_0_OfArgument_1_2_IsNotSupported(resultType);
            return null;
        }

        [MethodImpl(MethodImplOptions.AggressiveOptimization)]
        public static Object? Convert(Char? source, EKozmosCharComponent component, Type resultType)
        {
            switch (resultType)
            {
                case Type t when t == KozmosTypeHelper<Byte>._: return Convert<Byte>(source, component);
                //case Type t when t == KozmosTypeHelper<Byte?>._: return Convert<Byte>(source, component);

                case Type t when t == KozmosTypeHelper<SByte>._: return Convert<SByte>(source, component);
                //case Type t when t == KozmosTypeHelper<SByte?>._: return Convert<SByte>(source, component);

                case Type t when t == KozmosTypeHelper<UInt16>._: return Convert<UInt16>(source, component);
                //case Type t when t == KozmosTypeHelper<UInt16?>._: return Convert<UInt16>(source, component);

                case Type t when t == KozmosTypeHelper<Int16>._: return Convert<Int16>(source, component);
                //case Type t when t == KozmosTypeHelper<Int16?>._: return Convert<Int16>(source, component);

                case Type t when t == KozmosTypeHelper<UInt32>._: return Convert<UInt32>(source, component);
                //case Type t when t == KozmosTypeHelper<UInt32?>._: return Convert<UInt32>(source, component);

                case Type t when t == KozmosTypeHelper<Int32>._: return Convert<Int32>(source, component);
                //case Type t when t == KozmosTypeHelper<Int32?>._: return Convert<Int32>(source, component);

                case Type t when t == KozmosTypeHelper<UInt64>._: return Convert<UInt64>(source, component);
                //case Type t when t == KozmosTypeHelper<UInt64?>._: return Convert<UInt64>(source, component);

                case Type t when t == KozmosTypeHelper<Int64>._: return Convert<Int64>(source, component);
                //case Type t when t == KozmosTypeHelper<Int64?>._: return Convert<Int64>(source, component);

                case Type t when t == KozmosTypeHelper<UInt128>._: return Convert<UInt128>(source, component);
                //case Type t when t == KozmosTypeHelper<UInt128?>._: return Convert<UInt128>(source, component);

                case Type t when t == KozmosTypeHelper<Int128>._: return Convert<Int128>(source, component);
                //case Type t when t == KozmosTypeHelper<Int128?>._: return Convert<Int128>(source, component);

                case Type t when t == KozmosTypeHelper<BigInteger>._: return Convert<BigInteger>(source, component);
                //case Type t when t == KozmosTypeHelper<BigInteger?>._: return Convert<BigInteger>(source, component);

                case Type t when t == KozmosTypeHelper<Decimal>._: return Convert<Decimal>(source, component);
                //case Type t when t == KozmosTypeHelper<Decimal?>._: return Convert<Decimal>(source, component);

                case Type t when t == KozmosTypeHelper<Single>._: return Convert<Single>(source, component);
                //case Type t when t == KozmosTypeHelper<Single?>._: return Convert<Single>(source, component);

                case Type t when t == KozmosTypeHelper<Double>._: return Convert<Double>(source, component);
                //case Type t when t == KozmosTypeHelper<Double?>._: return Convert<Double>(source, component);

                case null: KozmosArgumentNullExceptionHelper.Throw(resultType); return null;
            }

            KozmosExceptionHelper.ThrowValue_0_OfArgument_1_2_IsNotSupported(resultType);
            return null;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TResult Convert<TResult>(Char source)
           where TResult : struct, INumber<TResult>
        { return KozmosNumberHelper<TResult>.Convert(source); }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TResult Convert<TResult>(Char source, EKozmosCharComponent component)
           where TResult : struct, INumber<TResult>
        { return KozmosNumberHelper<TResult>.Convert(source, component); }

        [MethodImpl(MethodImplOptions.AggressiveOptimization)]
        public static Object? Convert(Char source, Type resultType)
        {
            switch (resultType)
            {
                case Type t when t == KozmosTypeHelper<Byte>._: return Convert<Byte>(source);
                //case Type t when t == KozmosTypeHelper<Byte?>._: return Convert<Byte>(source);

                case Type t when t == KozmosTypeHelper<SByte>._: return Convert<SByte>(source);
                //case Type t when t == KozmosTypeHelper<SByte?>._: return Convert<SByte>(source);

                case Type t when t == KozmosTypeHelper<UInt16>._: return Convert<UInt16>(source);
                //case Type t when t == KozmosTypeHelper<UInt16?>._: return Convert<UInt16>(source);

                case Type t when t == KozmosTypeHelper<Int16>._: return Convert<Int16>(source);
                //case Type t when t == KozmosTypeHelper<Int16?>._: return Convert<Int16>(source);

                case Type t when t == KozmosTypeHelper<UInt32>._: return Convert<UInt32>(source);
                //case Type t when t == KozmosTypeHelper<UInt32?>._: return Convert<UInt32>(source);

                case Type t when t == KozmosTypeHelper<Int32>._: return Convert<Int32>(source);
                //case Type t when t == KozmosTypeHelper<Int32?>._: return Convert<Int32>(source);

                case Type t when t == KozmosTypeHelper<UInt64>._: return Convert<UInt64>(source);
                //case Type t when t == KozmosTypeHelper<UInt64?>._: return Convert<UInt64>(source);

                case Type t when t == KozmosTypeHelper<Int64>._: return Convert<Int64>(source);
                //case Type t when t == KozmosTypeHelper<Int64?>._: return Convert<Int64>(source);

                case Type t when t == KozmosTypeHelper<UInt128>._: return Convert<UInt128>(source);
                //case Type t when t == KozmosTypeHelper<UInt128?>._: return Convert<UInt128>(source);

                case Type t when t == KozmosTypeHelper<Int128>._: return Convert<Int128>(source);
                //case Type t when t == KozmosTypeHelper<Int128?>._: return Convert<Int128>(source);

                case Type t when t == KozmosTypeHelper<BigInteger>._: return Convert<BigInteger>(source);
                //case Type t when t == KozmosTypeHelper<BigInteger?>._: return Convert<BigInteger>(source);

                case Type t when t == KozmosTypeHelper<Decimal>._: return Convert<Decimal>(source);
                //case Type t when t == KozmosTypeHelper<Decimal?>._: return Convert<Decimal>(source);

                case Type t when t == KozmosTypeHelper<Single>._: return Convert<Single>(source);
                //case Type t when t == KozmosTypeHelper<Single?>._: return Convert<Single>(source);

                case Type t when t == KozmosTypeHelper<Double>._: return Convert<Double>(source);
                //case Type t when t == KozmosTypeHelper<Double?>._: return Convert<Double>(source);

                case null: KozmosArgumentNullExceptionHelper.Throw(resultType); return null;
            }

            KozmosExceptionHelper.ThrowValue_0_OfArgument_1_2_IsNotSupported(resultType);
            return null;
        }

        [MethodImpl(MethodImplOptions.AggressiveOptimization)]
        public static Object? Convert(Char source, EKozmosCharComponent component, Type resultType)
        {
            switch (resultType)
            {
                case Type t when t == KozmosTypeHelper<Byte>._: return Convert<Byte>(source, component);
                //case Type t when t == KozmosTypeHelper<Byte?>._: return Convert<Byte>(source, component);

                case Type t when t == KozmosTypeHelper<SByte>._: return Convert<SByte>(source, component);
                //case Type t when t == KozmosTypeHelper<SByte?>._: return Convert<SByte>(source, component);

                case Type t when t == KozmosTypeHelper<UInt16>._: return Convert<UInt16>(source, component);
                //case Type t when t == KozmosTypeHelper<UInt16?>._: return Convert<UInt16>(source, component);

                case Type t when t == KozmosTypeHelper<Int16>._: return Convert<Int16>(source, component);
                //case Type t when t == KozmosTypeHelper<Int16?>._: return Convert<Int16>(source, component);

                case Type t when t == KozmosTypeHelper<UInt32>._: return Convert<UInt32>(source, component);
                //case Type t when t == KozmosTypeHelper<UInt32?>._: return Convert<UInt32>(source, component);

                case Type t when t == KozmosTypeHelper<Int32>._: return Convert<Int32>(source, component);
                //case Type t when t == KozmosTypeHelper<Int32?>._: return Convert<Int32>(source, component);

                case Type t when t == KozmosTypeHelper<UInt64>._: return Convert<UInt64>(source, component);
                //case Type t when t == KozmosTypeHelper<UInt64?>._: return Convert<UInt64>(source, component);

                case Type t when t == KozmosTypeHelper<Int64>._: return Convert<Int64>(source, component);
                //case Type t when t == KozmosTypeHelper<Int64?>._: return Convert<Int64>(source, component);

                case Type t when t == KozmosTypeHelper<UInt128>._: return Convert<UInt128>(source, component);
                //case Type t when t == KozmosTypeHelper<UInt128?>._: return Convert<UInt128>(source, component);

                case Type t when t == KozmosTypeHelper<Int128>._: return Convert<Int128>(source, component);
                //case Type t when t == KozmosTypeHelper<Int128?>._: return Convert<Int128>(source, component);

                case Type t when t == KozmosTypeHelper<BigInteger>._: return Convert<BigInteger>(source, component);
                //case Type t when t == KozmosTypeHelper<BigInteger?>._: return Convert<BigInteger>(source, component);

                case Type t when t == KozmosTypeHelper<Decimal>._: return Convert<Decimal>(source, component);
                //case Type t when t == KozmosTypeHelper<Decimal?>._: return Convert<Decimal>(source, component);

                case Type t when t == KozmosTypeHelper<Single>._: return Convert<Single>(source, component);
                //case Type t when t == KozmosTypeHelper<Single?>._: return Convert<Single>(source, component);

                case Type t when t == KozmosTypeHelper<Double>._: return Convert<Double>(source, component);
                //case Type t when t == KozmosTypeHelper<Double?>._: return Convert<Double>(source, component);

                case null: KozmosArgumentNullExceptionHelper.Throw(resultType); return null;
            }

            KozmosExceptionHelper.ThrowValue_0_OfArgument_1_2_IsNotSupported(resultType);
            return null;
        }

        #endregion

        #region Fluidized

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TResult Convert<TResult>(Byte[]? source)
           where TResult : struct, INumber<TResult>
        { return KozmosNumberHelper<TResult>.Convert(source); }

        [MethodImpl(MethodImplOptions.AggressiveOptimization)]
        public static Object? Convert(Byte[]? source, Type resultType)
        {
            switch (resultType)
            {
                case Type t when t == KozmosTypeHelper<Byte>._: return Convert<Byte>(source);
                //case Type t when t == KozmosTypeHelper<Byte?>._: return Convert<Byte>(source);

                case Type t when t == KozmosTypeHelper<SByte>._: return Convert<SByte>(source);
                //case Type t when t == KozmosTypeHelper<SByte?>._: return Convert<SByte>(source);

                case Type t when t == KozmosTypeHelper<UInt16>._: return Convert<UInt16>(source);
                //case Type t when t == KozmosTypeHelper<UInt16?>._: return Convert<UInt16>(source);

                case Type t when t == KozmosTypeHelper<Int16>._: return Convert<Int16>(source);
                //case Type t when t == KozmosTypeHelper<Int16?>._: return Convert<Int16>(source);

                case Type t when t == KozmosTypeHelper<UInt32>._: return Convert<UInt32>(source);
                //case Type t when t == KozmosTypeHelper<UInt32?>._: return Convert<UInt32>(source);

                case Type t when t == KozmosTypeHelper<Int32>._: return Convert<Int32>(source);
                //case Type t when t == KozmosTypeHelper<Int32?>._: return Convert<Int32>(source);

                case Type t when t == KozmosTypeHelper<UInt64>._: return Convert<UInt64>(source);
                //case Type t when t == KozmosTypeHelper<UInt64?>._: return Convert<UInt64>(source);

                case Type t when t == KozmosTypeHelper<Int64>._: return Convert<Int64>(source);
                //case Type t when t == KozmosTypeHelper<Int64?>._: return Convert<Int64>(source);

                case Type t when t == KozmosTypeHelper<UInt128>._: return Convert<UInt128>(source);
                //case Type t when t == KozmosTypeHelper<UInt128?>._: return Convert<UInt128>(source);

                case Type t when t == KozmosTypeHelper<Int128>._: return Convert<Int128>(source);
                //case Type t when t == KozmosTypeHelper<Int128?>._: return Convert<Int128>(source);

                case Type t when t == KozmosTypeHelper<BigInteger>._: return Convert<BigInteger>(source);
                //case Type t when t == KozmosTypeHelper<BigInteger?>._: return Convert<BigInteger>(source);

                case Type t when t == KozmosTypeHelper<Decimal>._: return Convert<Decimal>(source);
                //case Type t when t == KozmosTypeHelper<Decimal?>._: return Convert<Decimal>(source);

                case Type t when t == KozmosTypeHelper<Single>._: return Convert<Single>(source);
                //case Type t when t == KozmosTypeHelper<Single?>._: return Convert<Single>(source);

                case Type t when t == KozmosTypeHelper<Double>._: return Convert<Double>(source);
                //case Type t when t == KozmosTypeHelper<Double?>._: return Convert<Double>(source);

                case null: KozmosArgumentNullExceptionHelper.Throw(resultType); return null;
            }

            KozmosExceptionHelper.ThrowValue_0_OfArgument_1_2_IsNotSupported(resultType);
            return null;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TResult Convert<TResult>(ReadOnlySpan<Byte> source)
           where TResult : struct, INumber<TResult>
        { return KozmosNumberHelper<TResult>.Convert(source); }

        [MethodImpl(MethodImplOptions.AggressiveOptimization)]
        public static Object? Convert(ReadOnlySpan<Byte> source, Type resultType)
        {
            switch (resultType)
            {
                case Type t when t == KozmosTypeHelper<Byte>._: return Convert<Byte>(source);
                //case Type t when t == KozmosTypeHelper<Byte?>._: return Convert<Byte>(source);

                case Type t when t == KozmosTypeHelper<SByte>._: return Convert<SByte>(source);
                //case Type t when t == KozmosTypeHelper<SByte?>._: return Convert<SByte>(source);

                case Type t when t == KozmosTypeHelper<UInt16>._: return Convert<UInt16>(source);
                //case Type t when t == KozmosTypeHelper<UInt16?>._: return Convert<UInt16>(source);

                case Type t when t == KozmosTypeHelper<Int16>._: return Convert<Int16>(source);
                //case Type t when t == KozmosTypeHelper<Int16?>._: return Convert<Int16>(source);

                case Type t when t == KozmosTypeHelper<UInt32>._: return Convert<UInt32>(source);
                //case Type t when t == KozmosTypeHelper<UInt32?>._: return Convert<UInt32>(source);

                case Type t when t == KozmosTypeHelper<Int32>._: return Convert<Int32>(source);
                //case Type t when t == KozmosTypeHelper<Int32?>._: return Convert<Int32>(source);

                case Type t when t == KozmosTypeHelper<UInt64>._: return Convert<UInt64>(source);
                //case Type t when t == KozmosTypeHelper<UInt64?>._: return Convert<UInt64>(source);

                case Type t when t == KozmosTypeHelper<Int64>._: return Convert<Int64>(source);
                //case Type t when t == KozmosTypeHelper<Int64?>._: return Convert<Int64>(source);

                case Type t when t == KozmosTypeHelper<UInt128>._: return Convert<UInt128>(source);
                //case Type t when t == KozmosTypeHelper<UInt128?>._: return Convert<UInt128>(source);

                case Type t when t == KozmosTypeHelper<Int128>._: return Convert<Int128>(source);
                //case Type t when t == KozmosTypeHelper<Int128?>._: return Convert<Int128>(source);

                case Type t when t == KozmosTypeHelper<BigInteger>._: return Convert<BigInteger>(source);
                //case Type t when t == KozmosTypeHelper<BigInteger?>._: return Convert<BigInteger>(source);

                case Type t when t == KozmosTypeHelper<Decimal>._: return Convert<Decimal>(source);
                //case Type t when t == KozmosTypeHelper<Decimal?>._: return Convert<Decimal>(source);

                case Type t when t == KozmosTypeHelper<Single>._: return Convert<Single>(source);
                //case Type t when t == KozmosTypeHelper<Single?>._: return Convert<Single>(source);

                case Type t when t == KozmosTypeHelper<Double>._: return Convert<Double>(source);
                //case Type t when t == KozmosTypeHelper<Double?>._: return Convert<Double>(source);

                case null: KozmosArgumentNullExceptionHelper.Throw(resultType); return null;
            }

            KozmosExceptionHelper.ThrowValue_0_OfArgument_1_2_IsNotSupported(resultType);
            return null;
        }

        #endregion

        #region Lizatings

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TResult Convert<TResult>(JsonElement? source)
           where TResult : struct, INumber<TResult>
        { return KozmosNumberHelper<TResult>.Convert(source); }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TResult Convert<TResult>(JsonElement? source, KozmosNumberIParsableConvertOptions options)
           where TResult : struct, INumber<TResult>
        { return KozmosNumberHelper<TResult>.Convert(source, options); }

        [MethodImpl(MethodImplOptions.AggressiveOptimization)]
        public static Object? Convert(JsonElement? source, Type resultType)
        {
            switch (resultType)
            {
                case Type t when t == KozmosTypeHelper<Byte>._: return Convert<Byte>(source);
                //case Type t when t == KozmosTypeHelper<Byte?>._: return Convert<Byte>(source);

                case Type t when t == KozmosTypeHelper<SByte>._: return Convert<SByte>(source);
                //case Type t when t == KozmosTypeHelper<SByte?>._: return Convert<SByte>(source);

                case Type t when t == KozmosTypeHelper<UInt16>._: return Convert<UInt16>(source);
                //case Type t when t == KozmosTypeHelper<UInt16?>._: return Convert<UInt16>(source);

                case Type t when t == KozmosTypeHelper<Int16>._: return Convert<Int16>(source);
                //case Type t when t == KozmosTypeHelper<Int16?>._: return Convert<Int16>(source);

                case Type t when t == KozmosTypeHelper<UInt32>._: return Convert<UInt32>(source);
                //case Type t when t == KozmosTypeHelper<UInt32?>._: return Convert<UInt32>(source);

                case Type t when t == KozmosTypeHelper<Int32>._: return Convert<Int32>(source);
                //case Type t when t == KozmosTypeHelper<Int32?>._: return Convert<Int32>(source);

                case Type t when t == KozmosTypeHelper<UInt64>._: return Convert<UInt64>(source);
                //case Type t when t == KozmosTypeHelper<UInt64?>._: return Convert<UInt64>(source);

                case Type t when t == KozmosTypeHelper<Int64>._: return Convert<Int64>(source);
                //case Type t when t == KozmosTypeHelper<Int64?>._: return Convert<Int64>(source);

                case Type t when t == KozmosTypeHelper<UInt128>._: return Convert<UInt128>(source);
                //case Type t when t == KozmosTypeHelper<UInt128?>._: return Convert<UInt128>(source);

                case Type t when t == KozmosTypeHelper<Int128>._: return Convert<Int128>(source);
                //case Type t when t == KozmosTypeHelper<Int128?>._: return Convert<Int128>(source);

                case Type t when t == KozmosTypeHelper<BigInteger>._: return Convert<BigInteger>(source);
                //case Type t when t == KozmosTypeHelper<BigInteger?>._: return Convert<BigInteger>(source);

                case Type t when t == KozmosTypeHelper<Decimal>._: return Convert<Decimal>(source);
                //case Type t when t == KozmosTypeHelper<Decimal?>._: return Convert<Decimal>(source);

                case Type t when t == KozmosTypeHelper<Single>._: return Convert<Single>(source);
                //case Type t when t == KozmosTypeHelper<Single?>._: return Convert<Single>(source);

                case Type t when t == KozmosTypeHelper<Double>._: return Convert<Double>(source);
                //case Type t when t == KozmosTypeHelper<Double?>._: return Convert<Double>(source);

                case null: KozmosArgumentNullExceptionHelper.Throw(resultType); return null;
            }

            KozmosExceptionHelper.ThrowValue_0_OfArgument_1_2_IsNotSupported(resultType);
            return null;
        }

        [MethodImpl(MethodImplOptions.AggressiveOptimization)]
        public static Object? Convert(JsonElement? source, KozmosNumberIParsableConvertOptions options, Type resultType)
        {
            switch (resultType)
            {
                case Type t when t == KozmosTypeHelper<Byte>._: return Convert<Byte>(source, options);
                //case Type t when t == KozmosTypeHelper<Byte?>._: return Convert<Byte>(source, options);

                case Type t when t == KozmosTypeHelper<SByte>._: return Convert<SByte>(source, options);
                //case Type t when t == KozmosTypeHelper<SByte?>._: return Convert<SByte>(source, options);

                case Type t when t == KozmosTypeHelper<UInt16>._: return Convert<UInt16>(source, options);
                //case Type t when t == KozmosTypeHelper<UInt16?>._: return Convert<UInt16>(source, options);

                case Type t when t == KozmosTypeHelper<Int16>._: return Convert<Int16>(source, options);
                //case Type t when t == KozmosTypeHelper<Int16?>._: return Convert<Int16>(source, options);

                case Type t when t == KozmosTypeHelper<UInt32>._: return Convert<UInt32>(source, options);
                //case Type t when t == KozmosTypeHelper<UInt32?>._: return Convert<UInt32>(source, options);

                case Type t when t == KozmosTypeHelper<Int32>._: return Convert<Int32>(source, options);
                //case Type t when t == KozmosTypeHelper<Int32?>._: return Convert<Int32>(source, options);

                case Type t when t == KozmosTypeHelper<UInt64>._: return Convert<UInt64>(source, options);
                //case Type t when t == KozmosTypeHelper<UInt64?>._: return Convert<UInt64>(source, options);

                case Type t when t == KozmosTypeHelper<Int64>._: return Convert<Int64>(source, options);
                //case Type t when t == KozmosTypeHelper<Int64?>._: return Convert<Int64>(source, options);

                case Type t when t == KozmosTypeHelper<UInt128>._: return Convert<UInt128>(source, options);
                //case Type t when t == KozmosTypeHelper<UInt128?>._: return Convert<UInt128>(source, options);

                case Type t when t == KozmosTypeHelper<Int128>._: return Convert<Int128>(source, options);
                //case Type t when t == KozmosTypeHelper<Int128?>._: return Convert<Int128>(source, options);

                case Type t when t == KozmosTypeHelper<BigInteger>._: return Convert<BigInteger>(source, options);
                //case Type t when t == KozmosTypeHelper<BigInteger?>._: return Convert<BigInteger>(source, options);

                case Type t when t == KozmosTypeHelper<Decimal>._: return Convert<Decimal>(source, options);
                //case Type t when t == KozmosTypeHelper<Decimal?>._: return Convert<Decimal>(source, options);

                case Type t when t == KozmosTypeHelper<Single>._: return Convert<Single>(source, options);
                //case Type t when t == KozmosTypeHelper<Single?>._: return Convert<Single>(source, options);

                case Type t when t == KozmosTypeHelper<Double>._: return Convert<Double>(source, options);
                //case Type t when t == KozmosTypeHelper<Double?>._: return Convert<Double>(source, options);

                case null: KozmosArgumentNullExceptionHelper.Throw(resultType); return null;
            }

            KozmosExceptionHelper.ThrowValue_0_OfArgument_1_2_IsNotSupported(resultType);
            return null;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TResult Convert<TResult>(JsonElement source)
           where TResult : struct, INumber<TResult>
        { return KozmosNumberHelper<TResult>.Convert(source); }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TResult Convert<TResult>(JsonElement source, KozmosNumberIParsableConvertOptions options)
           where TResult : struct, INumber<TResult>
        { return KozmosNumberHelper<TResult>.Convert(source, options); }

        [MethodImpl(MethodImplOptions.AggressiveOptimization)]
        public static Object? Convert(JsonElement source, Type resultType)
        {
            switch (resultType)
            {
                case Type t when t == KozmosTypeHelper<Byte>._: return Convert<Byte>(source);
                //case Type t when t == KozmosTypeHelper<Byte?>._: return Convert<Byte>(source);

                case Type t when t == KozmosTypeHelper<SByte>._: return Convert<SByte>(source);
                //case Type t when t == KozmosTypeHelper<SByte?>._: return Convert<SByte>(source);

                case Type t when t == KozmosTypeHelper<UInt16>._: return Convert<UInt16>(source);
                //case Type t when t == KozmosTypeHelper<UInt16?>._: return Convert<UInt16>(source);

                case Type t when t == KozmosTypeHelper<Int16>._: return Convert<Int16>(source);
                //case Type t when t == KozmosTypeHelper<Int16?>._: return Convert<Int16>(source);

                case Type t when t == KozmosTypeHelper<UInt32>._: return Convert<UInt32>(source);
                //case Type t when t == KozmosTypeHelper<UInt32?>._: return Convert<UInt32>(source);

                case Type t when t == KozmosTypeHelper<Int32>._: return Convert<Int32>(source);
                //case Type t when t == KozmosTypeHelper<Int32?>._: return Convert<Int32>(source);

                case Type t when t == KozmosTypeHelper<UInt64>._: return Convert<UInt64>(source);
                //case Type t when t == KozmosTypeHelper<UInt64?>._: return Convert<UInt64>(source);

                case Type t when t == KozmosTypeHelper<Int64>._: return Convert<Int64>(source);
                //case Type t when t == KozmosTypeHelper<Int64?>._: return Convert<Int64>(source);

                case Type t when t == KozmosTypeHelper<UInt128>._: return Convert<UInt128>(source);
                //case Type t when t == KozmosTypeHelper<UInt128?>._: return Convert<UInt128>(source);

                case Type t when t == KozmosTypeHelper<Int128>._: return Convert<Int128>(source);
                //case Type t when t == KozmosTypeHelper<Int128?>._: return Convert<Int128>(source);

                case Type t when t == KozmosTypeHelper<BigInteger>._: return Convert<BigInteger>(source);
                //case Type t when t == KozmosTypeHelper<BigInteger?>._: return Convert<BigInteger>(source);

                case Type t when t == KozmosTypeHelper<Decimal>._: return Convert<Decimal>(source);
                //case Type t when t == KozmosTypeHelper<Decimal?>._: return Convert<Decimal>(source);

                case Type t when t == KozmosTypeHelper<Single>._: return Convert<Single>(source);
                //case Type t when t == KozmosTypeHelper<Single?>._: return Convert<Single>(source);

                case Type t when t == KozmosTypeHelper<Double>._: return Convert<Double>(source);
                //case Type t when t == KozmosTypeHelper<Double?>._: return Convert<Double>(source);

                case null: KozmosArgumentNullExceptionHelper.Throw(resultType); return null;
            }

            KozmosExceptionHelper.ThrowValue_0_OfArgument_1_2_IsNotSupported(resultType);
            return null;
        }

        [MethodImpl(MethodImplOptions.AggressiveOptimization)]
        public static Object? Convert(JsonElement source, KozmosNumberIParsableConvertOptions options, Type resultType)
        {
            switch (resultType)
            {
                case Type t when t == KozmosTypeHelper<Byte>._: return Convert<Byte>(source, options);
                //case Type t when t == KozmosTypeHelper<Byte?>._: return Convert<Byte>(source, options);

                case Type t when t == KozmosTypeHelper<SByte>._: return Convert<SByte>(source, options);
                //case Type t when t == KozmosTypeHelper<SByte?>._: return Convert<SByte>(source, options);

                case Type t when t == KozmosTypeHelper<UInt16>._: return Convert<UInt16>(source, options);
                //case Type t when t == KozmosTypeHelper<UInt16?>._: return Convert<UInt16>(source, options);

                case Type t when t == KozmosTypeHelper<Int16>._: return Convert<Int16>(source, options);
                //case Type t when t == KozmosTypeHelper<Int16?>._: return Convert<Int16>(source, options);

                case Type t when t == KozmosTypeHelper<UInt32>._: return Convert<UInt32>(source, options);
                //case Type t when t == KozmosTypeHelper<UInt32?>._: return Convert<UInt32>(source, options);

                case Type t when t == KozmosTypeHelper<Int32>._: return Convert<Int32>(source, options);
                //case Type t when t == KozmosTypeHelper<Int32?>._: return Convert<Int32>(source, options);

                case Type t when t == KozmosTypeHelper<UInt64>._: return Convert<UInt64>(source, options);
                //case Type t when t == KozmosTypeHelper<UInt64?>._: return Convert<UInt64>(source, options);

                case Type t when t == KozmosTypeHelper<Int64>._: return Convert<Int64>(source, options);
                //case Type t when t == KozmosTypeHelper<Int64?>._: return Convert<Int64>(source, options);

                case Type t when t == KozmosTypeHelper<UInt128>._: return Convert<UInt128>(source, options);
                //case Type t when t == KozmosTypeHelper<UInt128?>._: return Convert<UInt128>(source, options);

                case Type t when t == KozmosTypeHelper<Int128>._: return Convert<Int128>(source, options);
                //case Type t when t == KozmosTypeHelper<Int128?>._: return Convert<Int128>(source, options);

                case Type t when t == KozmosTypeHelper<BigInteger>._: return Convert<BigInteger>(source, options);
                //case Type t when t == KozmosTypeHelper<BigInteger?>._: return Convert<BigInteger>(source, options);

                case Type t when t == KozmosTypeHelper<Decimal>._: return Convert<Decimal>(source, options);
                //case Type t when t == KozmosTypeHelper<Decimal?>._: return Convert<Decimal>(source, options);

                case Type t when t == KozmosTypeHelper<Single>._: return Convert<Single>(source, options);
                //case Type t when t == KozmosTypeHelper<Single?>._: return Convert<Single>(source, options);

                case Type t when t == KozmosTypeHelper<Double>._: return Convert<Double>(source, options);
                //case Type t when t == KozmosTypeHelper<Double?>._: return Convert<Double>(source, options);

                case null: KozmosArgumentNullExceptionHelper.Throw(resultType); return null;
            }

            KozmosExceptionHelper.ThrowValue_0_OfArgument_1_2_IsNotSupported(resultType);
            return null;
        }

        #endregion

        #region Numericals

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TResult Convert<TSource, TResult>(TSource? source)
           where TSource : struct, INumber<TSource>
           where TResult : struct, INumber<TResult>
        { return KozmosNumberHelper<TResult>.Convert(source); }

        [MethodImpl(MethodImplOptions.AggressiveOptimization)]
        public static Object? Convert<TSource>(TSource? source, Type resultType)
           where TSource : struct, INumber<TSource>
        {
            switch (resultType)
            {
                // HotPath >
                case Type t when t == KozmosTypeHelper<TSource?>._: return source;
                case Type t when t == KozmosTypeHelper<TSource>._:
                    KozmosArgumentNullExceptionHelper.ThrowIfNull(source);
                    return source!.Value;
                // < HotPath

                case Type t when t == KozmosTypeHelper<Byte>._: return Convert<Byte>(source);
                //case Type t when t == KozmosTypeHelper<Byte?>._: return Convert<Byte>(source);

                case Type t when t == KozmosTypeHelper<SByte>._: return Convert<SByte>(source);
                //case Type t when t == KozmosTypeHelper<SByte?>._: return Convert<SByte>(source);

                case Type t when t == KozmosTypeHelper<UInt16>._: return Convert<UInt16>(source);
                //case Type t when t == KozmosTypeHelper<UInt16?>._: return Convert<UInt16>(source);

                case Type t when t == KozmosTypeHelper<Int16>._: return Convert<Int16>(source);
                //case Type t when t == KozmosTypeHelper<Int16?>._: return Convert<Int16>(source);

                case Type t when t == KozmosTypeHelper<UInt32>._: return Convert<UInt32>(source);
                //case Type t when t == KozmosTypeHelper<UInt32?>._: return Convert<UInt32>(source);

                case Type t when t == KozmosTypeHelper<Int32>._: return Convert<Int32>(source);
                //case Type t when t == KozmosTypeHelper<Int32?>._: return Convert<Int32>(source);

                case Type t when t == KozmosTypeHelper<UInt64>._: return Convert<UInt64>(source);
                //case Type t when t == KozmosTypeHelper<UInt64?>._: return Convert<UInt64>(source);

                case Type t when t == KozmosTypeHelper<Int64>._: return Convert<Int64>(source);
                //case Type t when t == KozmosTypeHelper<Int64?>._: return Convert<Int64>(source);

                case Type t when t == KozmosTypeHelper<UInt128>._: return Convert<UInt128>(source);
                //case Type t when t == KozmosTypeHelper<UInt128?>._: return Convert<UInt128>(source);

                case Type t when t == KozmosTypeHelper<Int128>._: return Convert<Int128>(source);
                //case Type t when t == KozmosTypeHelper<Int128?>._: return Convert<Int128>(source);

                case Type t when t == KozmosTypeHelper<BigInteger>._: return Convert<BigInteger>(source);
                //case Type t when t == KozmosTypeHelper<BigInteger?>._: return Convert<BigInteger>(source);

                case Type t when t == KozmosTypeHelper<Decimal>._: return Convert<Decimal>(source);
                //case Type t when t == KozmosTypeHelper<Decimal?>._: return Convert<Decimal>(source);

                case Type t when t == KozmosTypeHelper<Single>._: return Convert<Single>(source);
                //case Type t when t == KozmosTypeHelper<Single?>._: return Convert<Single>(source);

                case Type t when t == KozmosTypeHelper<Double>._: return Convert<Double>(source);
                //case Type t when t == KozmosTypeHelper<Double?>._: return Convert<Double>(source);

                case null: KozmosArgumentNullExceptionHelper.Throw(resultType); return null;
            }

            KozmosExceptionHelper.ThrowValue_0_OfArgument_1_2_IsNotSupported(resultType);
            return null;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TResult Convert<TSource, TResult>(TSource source)
           where TSource : struct, INumber<TSource>
           where TResult : struct, INumber<TResult>
        { return KozmosNumberHelper<TResult>.Convert(source); }

        [MethodImpl(MethodImplOptions.AggressiveOptimization)]
        public static Object? Convert<TSource>(TSource source, Type resultType)
            where TSource : struct, INumber<TSource>
        {
            switch (resultType)
            {
                // HotPath >
                case Type t when t == KozmosTypeHelper<TSource>._ || t == KozmosTypeHelper<TSource?>._: return source;
                // < HotPath

                case Type t when t == KozmosTypeHelper<Byte>._: return Convert<TSource, Byte>(source);
                //case Type t when t == KozmosTypeHelper<Byte?>._: return Convert<TSource,Byte>(source);

                case Type t when t == KozmosTypeHelper<SByte>._: return Convert<TSource, SByte>(source);
                //case Type t when t == KozmosTypeHelper<SByte?>._: return Convert<TSource,SByte>(source);

                case Type t when t == KozmosTypeHelper<UInt16>._: return Convert<TSource, UInt16>(source);
                //case Type t when t == KozmosTypeHelper<UInt16?>._: return Convert<TSource,UInt16>(source);

                case Type t when t == KozmosTypeHelper<Int16>._: return Convert<TSource, Int16>(source);
                //case Type t when t == KozmosTypeHelper<Int16?>._: return Convert<TSource,Int16>(source);

                case Type t when t == KozmosTypeHelper<UInt32>._: return Convert<TSource, UInt32>(source);
                //case Type t when t == KozmosTypeHelper<UInt32?>._: return Convert<TSource,UInt32>(source);

                case Type t when t == KozmosTypeHelper<Int32>._: return Convert<TSource, Int32>(source);
                //case Type t when t == KozmosTypeHelper<Int32?>._: return Convert<TSource,Int32>(source);

                case Type t when t == KozmosTypeHelper<UInt64>._: return Convert<TSource, UInt64>(source);
                //case Type t when t == KozmosTypeHelper<UInt64?>._: return Convert<TSource,UInt64>(source);

                case Type t when t == KozmosTypeHelper<Int64>._: return Convert<TSource, Int64>(source);
                //case Type t when t == KozmosTypeHelper<Int64?>._: return Convert<TSource,Int64>(source);

                case Type t when t == KozmosTypeHelper<UInt128>._: return Convert<TSource, UInt128>(source);
                //case Type t when t == KozmosTypeHelper<UInt128?>._: return Convert<TSource,UInt128>(source);

                case Type t when t == KozmosTypeHelper<Int128>._: return Convert<TSource, Int128>(source);
                //case Type t when t == KozmosTypeHelper<Int128?>._: return Convert<TSource,Int128>(source);

                case Type t when t == KozmosTypeHelper<BigInteger>._: return Convert<TSource, BigInteger>(source);
                //case Type t when t == KozmosTypeHelper<BigInteger?>._: return Convert<TSource,BigInteger>(source);

                case Type t when t == KozmosTypeHelper<Decimal>._: return Convert<TSource, Decimal>(source);
                //case Type t when t == KozmosTypeHelper<Decimal?>._: return Convert<TSource,Decimal>(source);

                case Type t when t == KozmosTypeHelper<Single>._: return Convert<TSource, Single>(source);
                //case Type t when t == KozmosTypeHelper<Single?>._: return Convert<TSource,Single>(source);

                case Type t when t == KozmosTypeHelper<Double>._: return Convert<TSource, Double>(source);
                //case Type t when t == KozmosTypeHelper<Double?>._: return Convert<TSource,Double>(source);

                case null: KozmosArgumentNullExceptionHelper.Throw(resultType); return null;
            }

            KozmosExceptionHelper.ThrowValue_0_OfArgument_1_2_IsNotSupported(resultType);
            return null;
        }

        #endregion

        #region Temporals

        #region DateOnly

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TResult Convert<TResult>(DateOnly? source)
           where TResult : struct, INumber<TResult>
        { return KozmosNumberHelper<TResult>.Convert(source); }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TResult Convert<TResult>(DateOnly? source, EKozmosDateOnlyComponent component)
           where TResult : struct, INumber<TResult>
        { return KozmosNumberHelper<TResult>.Convert(source, component); }

        [MethodImpl(MethodImplOptions.AggressiveOptimization)]
        public static Object? Convert(DateOnly? source, Type resultType)
        {
            switch (resultType)
            {
                case Type t when t == KozmosTypeHelper<Byte>._: return Convert<Byte>(source);
                //case Type t when t == KozmosTypeHelper<Byte?>._: return Convert<Byte>(source);

                case Type t when t == KozmosTypeHelper<SByte>._: return Convert<SByte>(source);
                //case Type t when t == KozmosTypeHelper<SByte?>._: return Convert<SByte>(source);

                case Type t when t == KozmosTypeHelper<UInt16>._: return Convert<UInt16>(source);
                //case Type t when t == KozmosTypeHelper<UInt16?>._: return Convert<UInt16>(source);

                case Type t when t == KozmosTypeHelper<Int16>._: return Convert<Int16>(source);
                //case Type t when t == KozmosTypeHelper<Int16?>._: return Convert<Int16>(source);

                case Type t when t == KozmosTypeHelper<UInt32>._: return Convert<UInt32>(source);
                //case Type t when t == KozmosTypeHelper<UInt32?>._: return Convert<UInt32>(source);

                case Type t when t == KozmosTypeHelper<Int32>._: return Convert<Int32>(source);
                //case Type t when t == KozmosTypeHelper<Int32?>._: return Convert<Int32>(source);

                case Type t when t == KozmosTypeHelper<UInt64>._: return Convert<UInt64>(source);
                //case Type t when t == KozmosTypeHelper<UInt64?>._: return Convert<UInt64>(source);

                case Type t when t == KozmosTypeHelper<Int64>._: return Convert<Int64>(source);
                //case Type t when t == KozmosTypeHelper<Int64?>._: return Convert<Int64>(source);

                case Type t when t == KozmosTypeHelper<UInt128>._: return Convert<UInt128>(source);
                //case Type t when t == KozmosTypeHelper<UInt128?>._: return Convert<UInt128>(source);

                case Type t when t == KozmosTypeHelper<Int128>._: return Convert<Int128>(source);
                //case Type t when t == KozmosTypeHelper<Int128?>._: return Convert<Int128>(source);

                case Type t when t == KozmosTypeHelper<BigInteger>._: return Convert<BigInteger>(source);
                //case Type t when t == KozmosTypeHelper<BigInteger?>._: return Convert<BigInteger>(source);

                case Type t when t == KozmosTypeHelper<Decimal>._: return Convert<Decimal>(source);
                //case Type t when t == KozmosTypeHelper<Decimal?>._: return Convert<Decimal>(source);

                case Type t when t == KozmosTypeHelper<Single>._: return Convert<Single>(source);
                //case Type t when t == KozmosTypeHelper<Single?>._: return Convert<Single>(source);

                case Type t when t == KozmosTypeHelper<Double>._: return Convert<Double>(source);
                //case Type t when t == KozmosTypeHelper<Double?>._: return Convert<Double>(source);

                case null: KozmosArgumentNullExceptionHelper.Throw(resultType); return null;
            }

            KozmosExceptionHelper.ThrowValue_0_OfArgument_1_2_IsNotSupported(resultType);
            return null;
        }

        [MethodImpl(MethodImplOptions.AggressiveOptimization)]
        public static Object? Convert(DateOnly? source, EKozmosDateOnlyComponent component, Type resultType)
        {
            switch (resultType)
            {
                case Type t when t == KozmosTypeHelper<Byte>._: return Convert<Byte>(source, component);
                //case Type t when t == KozmosTypeHelper<Byte?>._: return Convert<Byte>(source, component);

                case Type t when t == KozmosTypeHelper<SByte>._: return Convert<SByte>(source, component);
                //case Type t when t == KozmosTypeHelper<SByte?>._: return Convert<SByte>(source, component);

                case Type t when t == KozmosTypeHelper<UInt16>._: return Convert<UInt16>(source, component);
                //case Type t when t == KozmosTypeHelper<UInt16?>._: return Convert<UInt16>(source, component);

                case Type t when t == KozmosTypeHelper<Int16>._: return Convert<Int16>(source, component);
                //case Type t when t == KozmosTypeHelper<Int16?>._: return Convert<Int16>(source, component);

                case Type t when t == KozmosTypeHelper<UInt32>._: return Convert<UInt32>(source, component);
                //case Type t when t == KozmosTypeHelper<UInt32?>._: return Convert<UInt32>(source, component);

                case Type t when t == KozmosTypeHelper<Int32>._: return Convert<Int32>(source, component);
                //case Type t when t == KozmosTypeHelper<Int32?>._: return Convert<Int32>(source, component);

                case Type t when t == KozmosTypeHelper<UInt64>._: return Convert<UInt64>(source, component);
                //case Type t when t == KozmosTypeHelper<UInt64?>._: return Convert<UInt64>(source, component);

                case Type t when t == KozmosTypeHelper<Int64>._: return Convert<Int64>(source, component);
                //case Type t when t == KozmosTypeHelper<Int64?>._: return Convert<Int64>(source, component);

                case Type t when t == KozmosTypeHelper<UInt128>._: return Convert<UInt128>(source, component);
                //case Type t when t == KozmosTypeHelper<UInt128?>._: return Convert<UInt128>(source, component);

                case Type t when t == KozmosTypeHelper<Int128>._: return Convert<Int128>(source, component);
                //case Type t when t == KozmosTypeHelper<Int128?>._: return Convert<Int128>(source, component);

                case Type t when t == KozmosTypeHelper<BigInteger>._: return Convert<BigInteger>(source, component);
                //case Type t when t == KozmosTypeHelper<BigInteger?>._: return Convert<BigInteger>(source, component);

                case Type t when t == KozmosTypeHelper<Decimal>._: return Convert<Decimal>(source, component);
                //case Type t when t == KozmosTypeHelper<Decimal?>._: return Convert<Decimal>(source, component);

                case Type t when t == KozmosTypeHelper<Single>._: return Convert<Single>(source, component);
                //case Type t when t == KozmosTypeHelper<Single?>._: return Convert<Single>(source, component);

                case Type t when t == KozmosTypeHelper<Double>._: return Convert<Double>(source, component);
                //case Type t when t == KozmosTypeHelper<Double?>._: return Convert<Double>(source, component);

                case null: KozmosArgumentNullExceptionHelper.Throw(resultType); return null;
            }

            KozmosExceptionHelper.ThrowValue_0_OfArgument_1_2_IsNotSupported(resultType);
            return null;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TResult Convert<TResult>(DateOnly source)
           where TResult : struct, INumber<TResult>
        { return KozmosNumberHelper<TResult>.Convert(source); }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TResult Convert<TResult>(DateOnly source, EKozmosDateOnlyComponent component)
           where TResult : struct, INumber<TResult>
        { return KozmosNumberHelper<TResult>.Convert(source, component); }

        [MethodImpl(MethodImplOptions.AggressiveOptimization)]
        public static Object? Convert(DateOnly source, Type resultType)
        {
            switch (resultType)
            {
                case Type t when t == KozmosTypeHelper<Byte>._: return Convert<Byte>(source);
                //case Type t when t == KozmosTypeHelper<Byte?>._: return Convert<Byte>(source);

                case Type t when t == KozmosTypeHelper<SByte>._: return Convert<SByte>(source);
                //case Type t when t == KozmosTypeHelper<SByte?>._: return Convert<SByte>(source);

                case Type t when t == KozmosTypeHelper<UInt16>._: return Convert<UInt16>(source);
                //case Type t when t == KozmosTypeHelper<UInt16?>._: return Convert<UInt16>(source);

                case Type t when t == KozmosTypeHelper<Int16>._: return Convert<Int16>(source);
                //case Type t when t == KozmosTypeHelper<Int16?>._: return Convert<Int16>(source);

                case Type t when t == KozmosTypeHelper<UInt32>._: return Convert<UInt32>(source);
                //case Type t when t == KozmosTypeHelper<UInt32?>._: return Convert<UInt32>(source);

                case Type t when t == KozmosTypeHelper<Int32>._: return Convert<Int32>(source);
                //case Type t when t == KozmosTypeHelper<Int32?>._: return Convert<Int32>(source);

                case Type t when t == KozmosTypeHelper<UInt64>._: return Convert<UInt64>(source);
                //case Type t when t == KozmosTypeHelper<UInt64?>._: return Convert<UInt64>(source);

                case Type t when t == KozmosTypeHelper<Int64>._: return Convert<Int64>(source);
                //case Type t when t == KozmosTypeHelper<Int64?>._: return Convert<Int64>(source);

                case Type t when t == KozmosTypeHelper<UInt128>._: return Convert<UInt128>(source);
                //case Type t when t == KozmosTypeHelper<UInt128?>._: return Convert<UInt128>(source);

                case Type t when t == KozmosTypeHelper<Int128>._: return Convert<Int128>(source);
                //case Type t when t == KozmosTypeHelper<Int128?>._: return Convert<Int128>(source);

                case Type t when t == KozmosTypeHelper<BigInteger>._: return Convert<BigInteger>(source);
                //case Type t when t == KozmosTypeHelper<BigInteger?>._: return Convert<BigInteger>(source);

                case Type t when t == KozmosTypeHelper<Decimal>._: return Convert<Decimal>(source);
                //case Type t when t == KozmosTypeHelper<Decimal?>._: return Convert<Decimal>(source);

                case Type t when t == KozmosTypeHelper<Single>._: return Convert<Single>(source);
                //case Type t when t == KozmosTypeHelper<Single?>._: return Convert<Single>(source);

                case Type t when t == KozmosTypeHelper<Double>._: return Convert<Double>(source);
                //case Type t when t == KozmosTypeHelper<Double?>._: return Convert<Double>(source);

                case null: KozmosArgumentNullExceptionHelper.Throw(resultType); return null;
            }

            KozmosExceptionHelper.ThrowValue_0_OfArgument_1_2_IsNotSupported(resultType);
            return null;
        }

        [MethodImpl(MethodImplOptions.AggressiveOptimization)]
        public static Object? Convert(DateOnly source, EKozmosDateOnlyComponent component, Type resultType)
        {
            switch (resultType)
            {
                case Type t when t == KozmosTypeHelper<Byte>._: return Convert<Byte>(source, component);
                //case Type t when t == KozmosTypeHelper<Byte?>._: return Convert<Byte>(source, component);

                case Type t when t == KozmosTypeHelper<SByte>._: return Convert<SByte>(source, component);
                //case Type t when t == KozmosTypeHelper<SByte?>._: return Convert<SByte>(source, component);

                case Type t when t == KozmosTypeHelper<UInt16>._: return Convert<UInt16>(source, component);
                //case Type t when t == KozmosTypeHelper<UInt16?>._: return Convert<UInt16>(source, component);

                case Type t when t == KozmosTypeHelper<Int16>._: return Convert<Int16>(source, component);
                //case Type t when t == KozmosTypeHelper<Int16?>._: return Convert<Int16>(source, component);

                case Type t when t == KozmosTypeHelper<UInt32>._: return Convert<UInt32>(source, component);
                //case Type t when t == KozmosTypeHelper<UInt32?>._: return Convert<UInt32>(source, component);

                case Type t when t == KozmosTypeHelper<Int32>._: return Convert<Int32>(source, component);
                //case Type t when t == KozmosTypeHelper<Int32?>._: return Convert<Int32>(source, component);

                case Type t when t == KozmosTypeHelper<UInt64>._: return Convert<UInt64>(source, component);
                //case Type t when t == KozmosTypeHelper<UInt64?>._: return Convert<UInt64>(source, component);

                case Type t when t == KozmosTypeHelper<Int64>._: return Convert<Int64>(source, component);
                //case Type t when t == KozmosTypeHelper<Int64?>._: return Convert<Int64>(source, component);

                case Type t when t == KozmosTypeHelper<UInt128>._: return Convert<UInt128>(source, component);
                //case Type t when t == KozmosTypeHelper<UInt128?>._: return Convert<UInt128>(source, component);

                case Type t when t == KozmosTypeHelper<Int128>._: return Convert<Int128>(source, component);
                //case Type t when t == KozmosTypeHelper<Int128?>._: return Convert<Int128>(source, component);

                case Type t when t == KozmosTypeHelper<BigInteger>._: return Convert<BigInteger>(source, component);
                //case Type t when t == KozmosTypeHelper<BigInteger?>._: return Convert<BigInteger>(source, component);

                case Type t when t == KozmosTypeHelper<Decimal>._: return Convert<Decimal>(source, component);
                //case Type t when t == KozmosTypeHelper<Decimal?>._: return Convert<Decimal>(source, component);

                case Type t when t == KozmosTypeHelper<Single>._: return Convert<Single>(source, component);
                //case Type t when t == KozmosTypeHelper<Single?>._: return Convert<Single>(source, component);

                case Type t when t == KozmosTypeHelper<Double>._: return Convert<Double>(source, component);
                //case Type t when t == KozmosTypeHelper<Double?>._: return Convert<Double>(source, component);

                case null: KozmosArgumentNullExceptionHelper.Throw(resultType); return null;
            }

            KozmosExceptionHelper.ThrowValue_0_OfArgument_1_2_IsNotSupported(resultType);
            return null;
        }

        #endregion

        #region DateTime

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TResult Convert<TResult>(DateTime? source)
            where TResult : struct, INumber<TResult>
        { return KozmosNumberHelper<TResult>.Convert(source); }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TResult Convert<TResult>(DateTime? source, EKozmosDateTimeComponent component)
           where TResult : struct, INumber<TResult>
        { return KozmosNumberHelper<TResult>.Convert(source, component); }

        [MethodImpl(MethodImplOptions.AggressiveOptimization)]
        public static Object? Convert(DateTime? source, Type resultType)
        {
            switch (resultType)
            {
                case Type t when t == KozmosTypeHelper<Byte>._: return Convert<Byte>(source);
                //case Type t when t == KozmosTypeHelper<Byte?>._: return Convert<Byte>(source);

                case Type t when t == KozmosTypeHelper<SByte>._: return Convert<SByte>(source);
                //case Type t when t == KozmosTypeHelper<SByte?>._: return Convert<SByte>(source);

                case Type t when t == KozmosTypeHelper<UInt16>._: return Convert<UInt16>(source);
                //case Type t when t == KozmosTypeHelper<UInt16?>._: return Convert<UInt16>(source);

                case Type t when t == KozmosTypeHelper<Int16>._: return Convert<Int16>(source);
                //case Type t when t == KozmosTypeHelper<Int16?>._: return Convert<Int16>(source);

                case Type t when t == KozmosTypeHelper<UInt32>._: return Convert<UInt32>(source);
                //case Type t when t == KozmosTypeHelper<UInt32?>._: return Convert<UInt32>(source);

                case Type t when t == KozmosTypeHelper<Int32>._: return Convert<Int32>(source);
                //case Type t when t == KozmosTypeHelper<Int32?>._: return Convert<Int32>(source);

                case Type t when t == KozmosTypeHelper<UInt64>._: return Convert<UInt64>(source);
                //case Type t when t == KozmosTypeHelper<UInt64?>._: return Convert<UInt64>(source);

                case Type t when t == KozmosTypeHelper<Int64>._: return Convert<Int64>(source);
                //case Type t when t == KozmosTypeHelper<Int64?>._: return Convert<Int64>(source);

                case Type t when t == KozmosTypeHelper<UInt128>._: return Convert<UInt128>(source);
                //case Type t when t == KozmosTypeHelper<UInt128?>._: return Convert<UInt128>(source);

                case Type t when t == KozmosTypeHelper<Int128>._: return Convert<Int128>(source);
                //case Type t when t == KozmosTypeHelper<Int128?>._: return Convert<Int128>(source);

                case Type t when t == KozmosTypeHelper<BigInteger>._: return Convert<BigInteger>(source);
                //case Type t when t == KozmosTypeHelper<BigInteger?>._: return Convert<BigInteger>(source);

                case Type t when t == KozmosTypeHelper<Decimal>._: return Convert<Decimal>(source);
                //case Type t when t == KozmosTypeHelper<Decimal?>._: return Convert<Decimal>(source);

                case Type t when t == KozmosTypeHelper<Single>._: return Convert<Single>(source);
                //case Type t when t == KozmosTypeHelper<Single?>._: return Convert<Single>(source);

                case Type t when t == KozmosTypeHelper<Double>._: return Convert<Double>(source);
                //case Type t when t == KozmosTypeHelper<Double?>._: return Convert<Double>(source);

                case null: KozmosArgumentNullExceptionHelper.Throw(resultType); return null;
            }

            KozmosExceptionHelper.ThrowValue_0_OfArgument_1_2_IsNotSupported(resultType);
            return null;
        }

        [MethodImpl(MethodImplOptions.AggressiveOptimization)]
        public static Object? Convert(DateTime? source, EKozmosDateTimeComponent component, Type resultType)
        {
            switch (resultType)
            {
                case Type t when t == KozmosTypeHelper<Byte>._: return Convert<Byte>(source, component);
                //case Type t when t == KozmosTypeHelper<Byte?>._: return Convert<Byte>(source, component);

                case Type t when t == KozmosTypeHelper<SByte>._: return Convert<SByte>(source, component);
                //case Type t when t == KozmosTypeHelper<SByte?>._: return Convert<SByte>(source, component);

                case Type t when t == KozmosTypeHelper<UInt16>._: return Convert<UInt16>(source, component);
                //case Type t when t == KozmosTypeHelper<UInt16?>._: return Convert<UInt16>(source, component);

                case Type t when t == KozmosTypeHelper<Int16>._: return Convert<Int16>(source, component);
                //case Type t when t == KozmosTypeHelper<Int16?>._: return Convert<Int16>(source, component);

                case Type t when t == KozmosTypeHelper<UInt32>._: return Convert<UInt32>(source, component);
                //case Type t when t == KozmosTypeHelper<UInt32?>._: return Convert<UInt32>(source, component);

                case Type t when t == KozmosTypeHelper<Int32>._: return Convert<Int32>(source, component);
                //case Type t when t == KozmosTypeHelper<Int32?>._: return Convert<Int32>(source, component);

                case Type t when t == KozmosTypeHelper<UInt64>._: return Convert<UInt64>(source, component);
                //case Type t when t == KozmosTypeHelper<UInt64?>._: return Convert<UInt64>(source, component);

                case Type t when t == KozmosTypeHelper<Int64>._: return Convert<Int64>(source, component);
                //case Type t when t == KozmosTypeHelper<Int64?>._: return Convert<Int64>(source, component);

                case Type t when t == KozmosTypeHelper<UInt128>._: return Convert<UInt128>(source, component);
                //case Type t when t == KozmosTypeHelper<UInt128?>._: return Convert<UInt128>(source, component);

                case Type t when t == KozmosTypeHelper<Int128>._: return Convert<Int128>(source, component);
                //case Type t when t == KozmosTypeHelper<Int128?>._: return Convert<Int128>(source, component);

                case Type t when t == KozmosTypeHelper<BigInteger>._: return Convert<BigInteger>(source, component);
                //case Type t when t == KozmosTypeHelper<BigInteger?>._: return Convert<BigInteger>(source, component);

                case Type t when t == KozmosTypeHelper<Decimal>._: return Convert<Decimal>(source, component);
                //case Type t when t == KozmosTypeHelper<Decimal?>._: return Convert<Decimal>(source, component);

                case Type t when t == KozmosTypeHelper<Single>._: return Convert<Single>(source, component);
                //case Type t when t == KozmosTypeHelper<Single?>._: return Convert<Single>(source, component);

                case Type t when t == KozmosTypeHelper<Double>._: return Convert<Double>(source, component);
                //case Type t when t == KozmosTypeHelper<Double?>._: return Convert<Double>(source, component);

                case null: KozmosArgumentNullExceptionHelper.Throw(resultType); return null;
            }

            KozmosExceptionHelper.ThrowValue_0_OfArgument_1_2_IsNotSupported(resultType);
            return null;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TResult Convert<TResult>(DateTime source)
           where TResult : struct, INumber<TResult>
        { return KozmosNumberHelper<TResult>.Convert(source); }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TResult Convert<TResult>(DateTime source, EKozmosDateTimeComponent component)
           where TResult : struct, INumber<TResult>
        { return KozmosNumberHelper<TResult>.Convert(source, component); }
        
        [MethodImpl(MethodImplOptions.AggressiveOptimization)]
        public static Object? Convert(DateTime source, Type resultType)
        {
            switch (resultType)
            {
                case Type t when t == KozmosTypeHelper<Byte>._: return Convert<Byte>(source);
                //case Type t when t == KozmosTypeHelper<Byte?>._: return Convert<Byte>(source);

                case Type t when t == KozmosTypeHelper<SByte>._: return Convert<SByte>(source);
                //case Type t when t == KozmosTypeHelper<SByte?>._: return Convert<SByte>(source);

                case Type t when t == KozmosTypeHelper<UInt16>._: return Convert<UInt16>(source);
                //case Type t when t == KozmosTypeHelper<UInt16?>._: return Convert<UInt16>(source);

                case Type t when t == KozmosTypeHelper<Int16>._: return Convert<Int16>(source);
                //case Type t when t == KozmosTypeHelper<Int16?>._: return Convert<Int16>(source);

                case Type t when t == KozmosTypeHelper<UInt32>._: return Convert<UInt32>(source);
                //case Type t when t == KozmosTypeHelper<UInt32?>._: return Convert<UInt32>(source);

                case Type t when t == KozmosTypeHelper<Int32>._: return Convert<Int32>(source);
                //case Type t when t == KozmosTypeHelper<Int32?>._: return Convert<Int32>(source);

                case Type t when t == KozmosTypeHelper<UInt64>._: return Convert<UInt64>(source);
                //case Type t when t == KozmosTypeHelper<UInt64?>._: return Convert<UInt64>(source);

                case Type t when t == KozmosTypeHelper<Int64>._: return Convert<Int64>(source);
                //case Type t when t == KozmosTypeHelper<Int64?>._: return Convert<Int64>(source);

                case Type t when t == KozmosTypeHelper<UInt128>._: return Convert<UInt128>(source);
                //case Type t when t == KozmosTypeHelper<UInt128?>._: return Convert<UInt128>(source);

                case Type t when t == KozmosTypeHelper<Int128>._: return Convert<Int128>(source);
                //case Type t when t == KozmosTypeHelper<Int128?>._: return Convert<Int128>(source);

                case Type t when t == KozmosTypeHelper<BigInteger>._: return Convert<BigInteger>(source);
                //case Type t when t == KozmosTypeHelper<BigInteger?>._: return Convert<BigInteger>(source);

                case Type t when t == KozmosTypeHelper<Decimal>._: return Convert<Decimal>(source);
                //case Type t when t == KozmosTypeHelper<Decimal?>._: return Convert<Decimal>(source);

                case Type t when t == KozmosTypeHelper<Single>._: return Convert<Single>(source);
                //case Type t when t == KozmosTypeHelper<Single?>._: return Convert<Single>(source);

                case Type t when t == KozmosTypeHelper<Double>._: return Convert<Double>(source);
                //case Type t when t == KozmosTypeHelper<Double?>._: return Convert<Double>(source);

                case null: KozmosArgumentNullExceptionHelper.Throw(resultType); return null;
            }

            KozmosExceptionHelper.ThrowValue_0_OfArgument_1_2_IsNotSupported(resultType);
            return null;
        }

        [MethodImpl(MethodImplOptions.AggressiveOptimization)]
        public static Object? Convert(DateTime source, EKozmosDateTimeComponent component, Type resultType)
        {
            switch (resultType)
            {
                case Type t when t == KozmosTypeHelper<Byte>._: return Convert<Byte>(source, component);
                //case Type t when t == KozmosTypeHelper<Byte?>._: return Convert<Byte>(source, component);

                case Type t when t == KozmosTypeHelper<SByte>._: return Convert<SByte>(source, component);
                //case Type t when t == KozmosTypeHelper<SByte?>._: return Convert<SByte>(source, component);

                case Type t when t == KozmosTypeHelper<UInt16>._: return Convert<UInt16>(source, component);
                //case Type t when t == KozmosTypeHelper<UInt16?>._: return Convert<UInt16>(source, component);

                case Type t when t == KozmosTypeHelper<Int16>._: return Convert<Int16>(source, component);
                //case Type t when t == KozmosTypeHelper<Int16?>._: return Convert<Int16>(source, component);

                case Type t when t == KozmosTypeHelper<UInt32>._: return Convert<UInt32>(source, component);
                //case Type t when t == KozmosTypeHelper<UInt32?>._: return Convert<UInt32>(source, component);

                case Type t when t == KozmosTypeHelper<Int32>._: return Convert<Int32>(source, component);
                //case Type t when t == KozmosTypeHelper<Int32?>._: return Convert<Int32>(source, component);

                case Type t when t == KozmosTypeHelper<UInt64>._: return Convert<UInt64>(source, component);
                //case Type t when t == KozmosTypeHelper<UInt64?>._: return Convert<UInt64>(source, component);

                case Type t when t == KozmosTypeHelper<Int64>._: return Convert<Int64>(source, component);
                //case Type t when t == KozmosTypeHelper<Int64?>._: return Convert<Int64>(source, component);

                case Type t when t == KozmosTypeHelper<UInt128>._: return Convert<UInt128>(source, component);
                //case Type t when t == KozmosTypeHelper<UInt128?>._: return Convert<UInt128>(source, component);

                case Type t when t == KozmosTypeHelper<Int128>._: return Convert<Int128>(source, component);
                //case Type t when t == KozmosTypeHelper<Int128?>._: return Convert<Int128>(source, component);

                case Type t when t == KozmosTypeHelper<BigInteger>._: return Convert<BigInteger>(source, component);
                //case Type t when t == KozmosTypeHelper<BigInteger?>._: return Convert<BigInteger>(source, component);

                case Type t when t == KozmosTypeHelper<Decimal>._: return Convert<Decimal>(source, component);
                //case Type t when t == KozmosTypeHelper<Decimal?>._: return Convert<Decimal>(source, component);

                case Type t when t == KozmosTypeHelper<Single>._: return Convert<Single>(source, component);
                //case Type t when t == KozmosTypeHelper<Single?>._: return Convert<Single>(source, component);

                case Type t when t == KozmosTypeHelper<Double>._: return Convert<Double>(source, component);
                //case Type t when t == KozmosTypeHelper<Double?>._: return Convert<Double>(source, component);

                case null: KozmosArgumentNullExceptionHelper.Throw(resultType); return null;
            }

            KozmosExceptionHelper.ThrowValue_0_OfArgument_1_2_IsNotSupported(resultType);
            return null;
        }

        #endregion

        #region DateTimeOffset

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TResult Convert<TResult>(DateTimeOffset? source)
            where TResult : struct, INumber<TResult>
        { return KozmosNumberHelper<TResult>.Convert(source); }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TResult Convert<TResult>(DateTimeOffset? source, EKozmosDateTimeOffsetComponent component)
           where TResult : struct, INumber<TResult>
        { return KozmosNumberHelper<TResult>.Convert(source, component); }

        [MethodImpl(MethodImplOptions.AggressiveOptimization)]
        public static Object? Convert(DateTimeOffset? source, Type resultType)
        {
            switch (resultType)
            {
                case Type t when t == KozmosTypeHelper<Byte>._: return Convert<Byte>(source);
                //case Type t when t == KozmosTypeHelper<Byte?>._: return Convert<Byte>(source);

                case Type t when t == KozmosTypeHelper<SByte>._: return Convert<SByte>(source);
                //case Type t when t == KozmosTypeHelper<SByte?>._: return Convert<SByte>(source);

                case Type t when t == KozmosTypeHelper<UInt16>._: return Convert<UInt16>(source);
                //case Type t when t == KozmosTypeHelper<UInt16?>._: return Convert<UInt16>(source);

                case Type t when t == KozmosTypeHelper<Int16>._: return Convert<Int16>(source);
                //case Type t when t == KozmosTypeHelper<Int16?>._: return Convert<Int16>(source);

                case Type t when t == KozmosTypeHelper<UInt32>._: return Convert<UInt32>(source);
                //case Type t when t == KozmosTypeHelper<UInt32?>._: return Convert<UInt32>(source);

                case Type t when t == KozmosTypeHelper<Int32>._: return Convert<Int32>(source);
                //case Type t when t == KozmosTypeHelper<Int32?>._: return Convert<Int32>(source);

                case Type t when t == KozmosTypeHelper<UInt64>._: return Convert<UInt64>(source);
                //case Type t when t == KozmosTypeHelper<UInt64?>._: return Convert<UInt64>(source);

                case Type t when t == KozmosTypeHelper<Int64>._: return Convert<Int64>(source);
                //case Type t when t == KozmosTypeHelper<Int64?>._: return Convert<Int64>(source);

                case Type t when t == KozmosTypeHelper<UInt128>._: return Convert<UInt128>(source);
                //case Type t when t == KozmosTypeHelper<UInt128?>._: return Convert<UInt128>(source);

                case Type t when t == KozmosTypeHelper<Int128>._: return Convert<Int128>(source);
                //case Type t when t == KozmosTypeHelper<Int128?>._: return Convert<Int128>(source);

                case Type t when t == KozmosTypeHelper<BigInteger>._: return Convert<BigInteger>(source);
                //case Type t when t == KozmosTypeHelper<BigInteger?>._: return Convert<BigInteger>(source);

                case Type t when t == KozmosTypeHelper<Decimal>._: return Convert<Decimal>(source);
                //case Type t when t == KozmosTypeHelper<Decimal?>._: return Convert<Decimal>(source);

                case Type t when t == KozmosTypeHelper<Single>._: return Convert<Single>(source);
                //case Type t when t == KozmosTypeHelper<Single?>._: return Convert<Single>(source);

                case Type t when t == KozmosTypeHelper<Double>._: return Convert<Double>(source);
                //case Type t when t == KozmosTypeHelper<Double?>._: return Convert<Double>(source);

                case null: KozmosArgumentNullExceptionHelper.Throw(resultType); return null;
            }

            KozmosExceptionHelper.ThrowValue_0_OfArgument_1_2_IsNotSupported(resultType);
            return null;
        }

        [MethodImpl(MethodImplOptions.AggressiveOptimization)]
        public static Object? Convert(DateTimeOffset? source, EKozmosDateTimeOffsetComponent component, Type resultType)
        {
            switch (resultType)
            {
                case Type t when t == KozmosTypeHelper<Byte>._: return Convert<Byte>(source, component);
                //case Type t when t == KozmosTypeHelper<Byte?>._: return Convert<Byte>(source, component);

                case Type t when t == KozmosTypeHelper<SByte>._: return Convert<SByte>(source, component);
                //case Type t when t == KozmosTypeHelper<SByte?>._: return Convert<SByte>(source, component);

                case Type t when t == KozmosTypeHelper<UInt16>._: return Convert<UInt16>(source, component);
                //case Type t when t == KozmosTypeHelper<UInt16?>._: return Convert<UInt16>(source, component);

                case Type t when t == KozmosTypeHelper<Int16>._: return Convert<Int16>(source, component);
                //case Type t when t == KozmosTypeHelper<Int16?>._: return Convert<Int16>(source, component);

                case Type t when t == KozmosTypeHelper<UInt32>._: return Convert<UInt32>(source, component);
                //case Type t when t == KozmosTypeHelper<UInt32?>._: return Convert<UInt32>(source, component);

                case Type t when t == KozmosTypeHelper<Int32>._: return Convert<Int32>(source, component);
                //case Type t when t == KozmosTypeHelper<Int32?>._: return Convert<Int32>(source, component);

                case Type t when t == KozmosTypeHelper<UInt64>._: return Convert<UInt64>(source, component);
                //case Type t when t == KozmosTypeHelper<UInt64?>._: return Convert<UInt64>(source, component);

                case Type t when t == KozmosTypeHelper<Int64>._: return Convert<Int64>(source, component);
                //case Type t when t == KozmosTypeHelper<Int64?>._: return Convert<Int64>(source, component);

                case Type t when t == KozmosTypeHelper<UInt128>._: return Convert<UInt128>(source, component);
                //case Type t when t == KozmosTypeHelper<UInt128?>._: return Convert<UInt128>(source, component);

                case Type t when t == KozmosTypeHelper<Int128>._: return Convert<Int128>(source, component);
                //case Type t when t == KozmosTypeHelper<Int128?>._: return Convert<Int128>(source, component);

                case Type t when t == KozmosTypeHelper<BigInteger>._: return Convert<BigInteger>(source, component);
                //case Type t when t == KozmosTypeHelper<BigInteger?>._: return Convert<BigInteger>(source, component);

                case Type t when t == KozmosTypeHelper<Decimal>._: return Convert<Decimal>(source, component);
                //case Type t when t == KozmosTypeHelper<Decimal?>._: return Convert<Decimal>(source, component);

                case Type t when t == KozmosTypeHelper<Single>._: return Convert<Single>(source, component);
                //case Type t when t == KozmosTypeHelper<Single?>._: return Convert<Single>(source, component);

                case Type t when t == KozmosTypeHelper<Double>._: return Convert<Double>(source, component);
                //case Type t when t == KozmosTypeHelper<Double?>._: return Convert<Double>(source, component);

                case null: KozmosArgumentNullExceptionHelper.Throw(resultType); return null;
            }

            KozmosExceptionHelper.ThrowValue_0_OfArgument_1_2_IsNotSupported(resultType);
            return null;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TResult Convert<TResult>(DateTimeOffset source)
           where TResult : struct, INumber<TResult>
        { return KozmosNumberHelper<TResult>.Convert(source); }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TResult Convert<TResult>(DateTimeOffset source, EKozmosDateTimeOffsetComponent component)
           where TResult : struct, INumber<TResult>
        { return KozmosNumberHelper<TResult>.Convert(source, component); }

        [MethodImpl(MethodImplOptions.AggressiveOptimization)]
        public static Object? Convert(DateTimeOffset source, Type resultType)
        {
            switch (resultType)
            {
                case Type t when t == KozmosTypeHelper<Byte>._: return Convert<Byte>(source);
                //case Type t when t == KozmosTypeHelper<Byte?>._: return Convert<Byte>(source);

                case Type t when t == KozmosTypeHelper<SByte>._: return Convert<SByte>(source);
                //case Type t when t == KozmosTypeHelper<SByte?>._: return Convert<SByte>(source);

                case Type t when t == KozmosTypeHelper<UInt16>._: return Convert<UInt16>(source);
                //case Type t when t == KozmosTypeHelper<UInt16?>._: return Convert<UInt16>(source);

                case Type t when t == KozmosTypeHelper<Int16>._: return Convert<Int16>(source);
                //case Type t when t == KozmosTypeHelper<Int16?>._: return Convert<Int16>(source);

                case Type t when t == KozmosTypeHelper<UInt32>._: return Convert<UInt32>(source);
                //case Type t when t == KozmosTypeHelper<UInt32?>._: return Convert<UInt32>(source);

                case Type t when t == KozmosTypeHelper<Int32>._: return Convert<Int32>(source);
                //case Type t when t == KozmosTypeHelper<Int32?>._: return Convert<Int32>(source);

                case Type t when t == KozmosTypeHelper<UInt64>._: return Convert<UInt64>(source);
                //case Type t when t == KozmosTypeHelper<UInt64?>._: return Convert<UInt64>(source);

                case Type t when t == KozmosTypeHelper<Int64>._: return Convert<Int64>(source);
                //case Type t when t == KozmosTypeHelper<Int64?>._: return Convert<Int64>(source);

                case Type t when t == KozmosTypeHelper<UInt128>._: return Convert<UInt128>(source);
                //case Type t when t == KozmosTypeHelper<UInt128?>._: return Convert<UInt128>(source);

                case Type t when t == KozmosTypeHelper<Int128>._: return Convert<Int128>(source);
                //case Type t when t == KozmosTypeHelper<Int128?>._: return Convert<Int128>(source);

                case Type t when t == KozmosTypeHelper<BigInteger>._: return Convert<BigInteger>(source);
                //case Type t when t == KozmosTypeHelper<BigInteger?>._: return Convert<BigInteger>(source);

                case Type t when t == KozmosTypeHelper<Decimal>._: return Convert<Decimal>(source);
                //case Type t when t == KozmosTypeHelper<Decimal?>._: return Convert<Decimal>(source);

                case Type t when t == KozmosTypeHelper<Single>._: return Convert<Single>(source);
                //case Type t when t == KozmosTypeHelper<Single?>._: return Convert<Single>(source);

                case Type t when t == KozmosTypeHelper<Double>._: return Convert<Double>(source);
                //case Type t when t == KozmosTypeHelper<Double?>._: return Convert<Double>(source);

                case null: KozmosArgumentNullExceptionHelper.Throw(resultType); return null;
            }

            KozmosExceptionHelper.ThrowValue_0_OfArgument_1_2_IsNotSupported(resultType);
            return null;
        }

        [MethodImpl(MethodImplOptions.AggressiveOptimization)]
        public static Object? Convert(DateTimeOffset source, EKozmosDateTimeOffsetComponent component, Type resultType)
        {
            switch (resultType)
            {
                case Type t when t == KozmosTypeHelper<Byte>._: return Convert<Byte>(source, component);
                //case Type t when t == KozmosTypeHelper<Byte?>._: return Convert<Byte>(source, component);

                case Type t when t == KozmosTypeHelper<SByte>._: return Convert<SByte>(source, component);
                //case Type t when t == KozmosTypeHelper<SByte?>._: return Convert<SByte>(source, component);

                case Type t when t == KozmosTypeHelper<UInt16>._: return Convert<UInt16>(source, component);
                //case Type t when t == KozmosTypeHelper<UInt16?>._: return Convert<UInt16>(source, component);

                case Type t when t == KozmosTypeHelper<Int16>._: return Convert<Int16>(source, component);
                //case Type t when t == KozmosTypeHelper<Int16?>._: return Convert<Int16>(source, component);

                case Type t when t == KozmosTypeHelper<UInt32>._: return Convert<UInt32>(source, component);
                //case Type t when t == KozmosTypeHelper<UInt32?>._: return Convert<UInt32>(source, component);

                case Type t when t == KozmosTypeHelper<Int32>._: return Convert<Int32>(source, component);
                //case Type t when t == KozmosTypeHelper<Int32?>._: return Convert<Int32>(source, component);

                case Type t when t == KozmosTypeHelper<UInt64>._: return Convert<UInt64>(source, component);
                //case Type t when t == KozmosTypeHelper<UInt64?>._: return Convert<UInt64>(source, component);

                case Type t when t == KozmosTypeHelper<Int64>._: return Convert<Int64>(source, component);
                //case Type t when t == KozmosTypeHelper<Int64?>._: return Convert<Int64>(source, component);

                case Type t when t == KozmosTypeHelper<UInt128>._: return Convert<UInt128>(source, component);
                //case Type t when t == KozmosTypeHelper<UInt128?>._: return Convert<UInt128>(source, component);

                case Type t when t == KozmosTypeHelper<Int128>._: return Convert<Int128>(source, component);
                //case Type t when t == KozmosTypeHelper<Int128?>._: return Convert<Int128>(source, component);

                case Type t when t == KozmosTypeHelper<BigInteger>._: return Convert<BigInteger>(source, component);
                //case Type t when t == KozmosTypeHelper<BigInteger?>._: return Convert<BigInteger>(source, component);

                case Type t when t == KozmosTypeHelper<Decimal>._: return Convert<Decimal>(source, component);
                //case Type t when t == KozmosTypeHelper<Decimal?>._: return Convert<Decimal>(source, component);

                case Type t when t == KozmosTypeHelper<Single>._: return Convert<Single>(source, component);
                //case Type t when t == KozmosTypeHelper<Single?>._: return Convert<Single>(source, component);

                case Type t when t == KozmosTypeHelper<Double>._: return Convert<Double>(source, component);
                //case Type t when t == KozmosTypeHelper<Double?>._: return Convert<Double>(source, component);

                case null: KozmosArgumentNullExceptionHelper.Throw(resultType); return null;
            }

            KozmosExceptionHelper.ThrowValue_0_OfArgument_1_2_IsNotSupported(resultType);
            return null;
        }

        #endregion

        #region TimeOnly

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TResult Convert<TResult>(TimeOnly? source)
            where TResult : struct, INumber<TResult>
        { return KozmosNumberHelper<TResult>.Convert(source); }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TResult Convert<TResult>(TimeOnly? source, EKozmosTimeOnlyComponent component)
           where TResult : struct, INumber<TResult>
        { return KozmosNumberHelper<TResult>.Convert(source, component); }

        [MethodImpl(MethodImplOptions.AggressiveOptimization)]
        public static Object? Convert(TimeOnly? source, Type resultType)
        {
            switch (resultType)
            {
                case Type t when t == KozmosTypeHelper<Byte>._: return Convert<Byte>(source);
                //case Type t when t == KozmosTypeHelper<Byte?>._: return Convert<Byte>(source);

                case Type t when t == KozmosTypeHelper<SByte>._: return Convert<SByte>(source);
                //case Type t when t == KozmosTypeHelper<SByte?>._: return Convert<SByte>(source);

                case Type t when t == KozmosTypeHelper<UInt16>._: return Convert<UInt16>(source);
                //case Type t when t == KozmosTypeHelper<UInt16?>._: return Convert<UInt16>(source);

                case Type t when t == KozmosTypeHelper<Int16>._: return Convert<Int16>(source);
                //case Type t when t == KozmosTypeHelper<Int16?>._: return Convert<Int16>(source);

                case Type t when t == KozmosTypeHelper<UInt32>._: return Convert<UInt32>(source);
                //case Type t when t == KozmosTypeHelper<UInt32?>._: return Convert<UInt32>(source);

                case Type t when t == KozmosTypeHelper<Int32>._: return Convert<Int32>(source);
                //case Type t when t == KozmosTypeHelper<Int32?>._: return Convert<Int32>(source);

                case Type t when t == KozmosTypeHelper<UInt64>._: return Convert<UInt64>(source);
                //case Type t when t == KozmosTypeHelper<UInt64?>._: return Convert<UInt64>(source);

                case Type t when t == KozmosTypeHelper<Int64>._: return Convert<Int64>(source);
                //case Type t when t == KozmosTypeHelper<Int64?>._: return Convert<Int64>(source);

                case Type t when t == KozmosTypeHelper<UInt128>._: return Convert<UInt128>(source);
                //case Type t when t == KozmosTypeHelper<UInt128?>._: return Convert<UInt128>(source);

                case Type t when t == KozmosTypeHelper<Int128>._: return Convert<Int128>(source);
                //case Type t when t == KozmosTypeHelper<Int128?>._: return Convert<Int128>(source);

                case Type t when t == KozmosTypeHelper<BigInteger>._: return Convert<BigInteger>(source);
                //case Type t when t == KozmosTypeHelper<BigInteger?>._: return Convert<BigInteger>(source);

                case Type t when t == KozmosTypeHelper<Decimal>._: return Convert<Decimal>(source);
                //case Type t when t == KozmosTypeHelper<Decimal?>._: return Convert<Decimal>(source);

                case Type t when t == KozmosTypeHelper<Single>._: return Convert<Single>(source);
                //case Type t when t == KozmosTypeHelper<Single?>._: return Convert<Single>(source);

                case Type t when t == KozmosTypeHelper<Double>._: return Convert<Double>(source);
                //case Type t when t == KozmosTypeHelper<Double?>._: return Convert<Double>(source);

                case null: KozmosArgumentNullExceptionHelper.Throw(resultType); return null;
            }

            KozmosExceptionHelper.ThrowValue_0_OfArgument_1_2_IsNotSupported(resultType);
            return null;
        }

        [MethodImpl(MethodImplOptions.AggressiveOptimization)]
        public static Object? Convert(TimeOnly? source, EKozmosTimeOnlyComponent component, Type resultType)
        {
            switch (resultType)
            {
                case Type t when t == KozmosTypeHelper<Byte>._: return Convert<Byte>(source, component);
                //case Type t when t == KozmosTypeHelper<Byte?>._: return Convert<Byte>(source, component);

                case Type t when t == KozmosTypeHelper<SByte>._: return Convert<SByte>(source, component);
                //case Type t when t == KozmosTypeHelper<SByte?>._: return Convert<SByte>(source, component);

                case Type t when t == KozmosTypeHelper<UInt16>._: return Convert<UInt16>(source, component);
                //case Type t when t == KozmosTypeHelper<UInt16?>._: return Convert<UInt16>(source, component);

                case Type t when t == KozmosTypeHelper<Int16>._: return Convert<Int16>(source, component);
                //case Type t when t == KozmosTypeHelper<Int16?>._: return Convert<Int16>(source, component);

                case Type t when t == KozmosTypeHelper<UInt32>._: return Convert<UInt32>(source, component);
                //case Type t when t == KozmosTypeHelper<UInt32?>._: return Convert<UInt32>(source, component);

                case Type t when t == KozmosTypeHelper<Int32>._: return Convert<Int32>(source, component);
                //case Type t when t == KozmosTypeHelper<Int32?>._: return Convert<Int32>(source, component);

                case Type t when t == KozmosTypeHelper<UInt64>._: return Convert<UInt64>(source, component);
                //case Type t when t == KozmosTypeHelper<UInt64?>._: return Convert<UInt64>(source, component);

                case Type t when t == KozmosTypeHelper<Int64>._: return Convert<Int64>(source, component);
                //case Type t when t == KozmosTypeHelper<Int64?>._: return Convert<Int64>(source, component);

                case Type t when t == KozmosTypeHelper<UInt128>._: return Convert<UInt128>(source, component);
                //case Type t when t == KozmosTypeHelper<UInt128?>._: return Convert<UInt128>(source, component);

                case Type t when t == KozmosTypeHelper<Int128>._: return Convert<Int128>(source, component);
                //case Type t when t == KozmosTypeHelper<Int128?>._: return Convert<Int128>(source, component);

                case Type t when t == KozmosTypeHelper<BigInteger>._: return Convert<BigInteger>(source, component);
                //case Type t when t == KozmosTypeHelper<BigInteger?>._: return Convert<BigInteger>(source, component);

                case Type t when t == KozmosTypeHelper<Decimal>._: return Convert<Decimal>(source, component);
                //case Type t when t == KozmosTypeHelper<Decimal?>._: return Convert<Decimal>(source, component);

                case Type t when t == KozmosTypeHelper<Single>._: return Convert<Single>(source, component);
                //case Type t when t == KozmosTypeHelper<Single?>._: return Convert<Single>(source, component);

                case Type t when t == KozmosTypeHelper<Double>._: return Convert<Double>(source, component);
                //case Type t when t == KozmosTypeHelper<Double?>._: return Convert<Double>(source, component);

                case null: KozmosArgumentNullExceptionHelper.Throw(resultType); return null;
            }

            KozmosExceptionHelper.ThrowValue_0_OfArgument_1_2_IsNotSupported(resultType);
            return null;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TResult Convert<TResult>(TimeOnly source)
          where TResult : struct, INumber<TResult>
        { return KozmosNumberHelper<TResult>.Convert(source); }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TResult Convert<TResult>(TimeOnly source, EKozmosTimeOnlyComponent component)
           where TResult : struct, INumber<TResult>
        { return KozmosNumberHelper<TResult>.Convert(source, component); }

        [MethodImpl(MethodImplOptions.AggressiveOptimization)]
        public static Object? Convert(TimeOnly source, Type resultType)
        {
            switch (resultType)
            {
                case Type t when t == KozmosTypeHelper<Byte>._: return Convert<Byte>(source);
                //case Type t when t == KozmosTypeHelper<Byte?>._: return Convert<Byte>(source);

                case Type t when t == KozmosTypeHelper<SByte>._: return Convert<SByte>(source);
                //case Type t when t == KozmosTypeHelper<SByte?>._: return Convert<SByte>(source);

                case Type t when t == KozmosTypeHelper<UInt16>._: return Convert<UInt16>(source);
                //case Type t when t == KozmosTypeHelper<UInt16?>._: return Convert<UInt16>(source);

                case Type t when t == KozmosTypeHelper<Int16>._: return Convert<Int16>(source);
                //case Type t when t == KozmosTypeHelper<Int16?>._: return Convert<Int16>(source);

                case Type t when t == KozmosTypeHelper<UInt32>._: return Convert<UInt32>(source);
                //case Type t when t == KozmosTypeHelper<UInt32?>._: return Convert<UInt32>(source);

                case Type t when t == KozmosTypeHelper<Int32>._: return Convert<Int32>(source);
                //case Type t when t == KozmosTypeHelper<Int32?>._: return Convert<Int32>(source);

                case Type t when t == KozmosTypeHelper<UInt64>._: return Convert<UInt64>(source);
                //case Type t when t == KozmosTypeHelper<UInt64?>._: return Convert<UInt64>(source);

                case Type t when t == KozmosTypeHelper<Int64>._: return Convert<Int64>(source);
                //case Type t when t == KozmosTypeHelper<Int64?>._: return Convert<Int64>(source);

                case Type t when t == KozmosTypeHelper<UInt128>._: return Convert<UInt128>(source);
                //case Type t when t == KozmosTypeHelper<UInt128?>._: return Convert<UInt128>(source);

                case Type t when t == KozmosTypeHelper<Int128>._: return Convert<Int128>(source);
                //case Type t when t == KozmosTypeHelper<Int128?>._: return Convert<Int128>(source);

                case Type t when t == KozmosTypeHelper<BigInteger>._: return Convert<BigInteger>(source);
                //case Type t when t == KozmosTypeHelper<BigInteger?>._: return Convert<BigInteger>(source);

                case Type t when t == KozmosTypeHelper<Decimal>._: return Convert<Decimal>(source);
                //case Type t when t == KozmosTypeHelper<Decimal?>._: return Convert<Decimal>(source);

                case Type t when t == KozmosTypeHelper<Single>._: return Convert<Single>(source);
                //case Type t when t == KozmosTypeHelper<Single?>._: return Convert<Single>(source);

                case Type t when t == KozmosTypeHelper<Double>._: return Convert<Double>(source);
                //case Type t when t == KozmosTypeHelper<Double?>._: return Convert<Double>(source);

                case null: KozmosArgumentNullExceptionHelper.Throw(resultType); return null;
            }

            KozmosExceptionHelper.ThrowValue_0_OfArgument_1_2_IsNotSupported(resultType);
            return null;
        }

        [MethodImpl(MethodImplOptions.AggressiveOptimization)]
        public static Object? Convert(TimeOnly source, EKozmosTimeOnlyComponent component, Type resultType)
        {
            switch (resultType)
            {
                case Type t when t == KozmosTypeHelper<Byte>._: return Convert<Byte>(source, component);
                //case Type t when t == KozmosTypeHelper<Byte?>._: return Convert<Byte>(source, component);

                case Type t when t == KozmosTypeHelper<SByte>._: return Convert<SByte>(source, component);
                //case Type t when t == KozmosTypeHelper<SByte?>._: return Convert<SByte>(source, component);

                case Type t when t == KozmosTypeHelper<UInt16>._: return Convert<UInt16>(source, component);
                //case Type t when t == KozmosTypeHelper<UInt16?>._: return Convert<UInt16>(source, component);

                case Type t when t == KozmosTypeHelper<Int16>._: return Convert<Int16>(source, component);
                //case Type t when t == KozmosTypeHelper<Int16?>._: return Convert<Int16>(source, component);

                case Type t when t == KozmosTypeHelper<UInt32>._: return Convert<UInt32>(source, component);
                //case Type t when t == KozmosTypeHelper<UInt32?>._: return Convert<UInt32>(source, component);

                case Type t when t == KozmosTypeHelper<Int32>._: return Convert<Int32>(source, component);
                //case Type t when t == KozmosTypeHelper<Int32?>._: return Convert<Int32>(source, component);

                case Type t when t == KozmosTypeHelper<UInt64>._: return Convert<UInt64>(source, component);
                //case Type t when t == KozmosTypeHelper<UInt64?>._: return Convert<UInt64>(source, component);

                case Type t when t == KozmosTypeHelper<Int64>._: return Convert<Int64>(source, component);
                //case Type t when t == KozmosTypeHelper<Int64?>._: return Convert<Int64>(source, component);

                case Type t when t == KozmosTypeHelper<UInt128>._: return Convert<UInt128>(source, component);
                //case Type t when t == KozmosTypeHelper<UInt128?>._: return Convert<UInt128>(source, component);

                case Type t when t == KozmosTypeHelper<Int128>._: return Convert<Int128>(source, component);
                //case Type t when t == KozmosTypeHelper<Int128?>._: return Convert<Int128>(source, component);

                case Type t when t == KozmosTypeHelper<BigInteger>._: return Convert<BigInteger>(source, component);
                //case Type t when t == KozmosTypeHelper<BigInteger?>._: return Convert<BigInteger>(source, component);

                case Type t when t == KozmosTypeHelper<Decimal>._: return Convert<Decimal>(source, component);
                //case Type t when t == KozmosTypeHelper<Decimal?>._: return Convert<Decimal>(source, component);

                case Type t when t == KozmosTypeHelper<Single>._: return Convert<Single>(source, component);
                //case Type t when t == KozmosTypeHelper<Single?>._: return Convert<Single>(source, component);

                case Type t when t == KozmosTypeHelper<Double>._: return Convert<Double>(source, component);
                //case Type t when t == KozmosTypeHelper<Double?>._: return Convert<Double>(source, component);

                case null: KozmosArgumentNullExceptionHelper.Throw(resultType); return null;
            }

            KozmosExceptionHelper.ThrowValue_0_OfArgument_1_2_IsNotSupported(resultType);
            return null;
        }

        #endregion

        #region TimeSpan

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TResult Convert<TResult>(TimeSpan? source)
            where TResult : struct, INumber<TResult>
        { return KozmosNumberHelper<TResult>.Convert(source); }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TResult Convert<TResult>(TimeSpan? source, EKozmosTimeSpanComponent component)
           where TResult : struct, INumber<TResult>
        { return KozmosNumberHelper<TResult>.Convert(source, component); }

        [MethodImpl(MethodImplOptions.AggressiveOptimization)]
        public static Object? Convert(TimeSpan? source, Type resultType)
        {
            switch (resultType)
            {
                case Type t when t == KozmosTypeHelper<Byte>._: return Convert<Byte>(source);
                //case Type t when t == KozmosTypeHelper<Byte?>._: return Convert<Byte>(source);

                case Type t when t == KozmosTypeHelper<SByte>._: return Convert<SByte>(source);
                //case Type t when t == KozmosTypeHelper<SByte?>._: return Convert<SByte>(source);

                case Type t when t == KozmosTypeHelper<UInt16>._: return Convert<UInt16>(source);
                //case Type t when t == KozmosTypeHelper<UInt16?>._: return Convert<UInt16>(source);

                case Type t when t == KozmosTypeHelper<Int16>._: return Convert<Int16>(source);
                //case Type t when t == KozmosTypeHelper<Int16?>._: return Convert<Int16>(source);

                case Type t when t == KozmosTypeHelper<UInt32>._: return Convert<UInt32>(source);
                //case Type t when t == KozmosTypeHelper<UInt32?>._: return Convert<UInt32>(source);

                case Type t when t == KozmosTypeHelper<Int32>._: return Convert<Int32>(source);
                //case Type t when t == KozmosTypeHelper<Int32?>._: return Convert<Int32>(source);

                case Type t when t == KozmosTypeHelper<UInt64>._: return Convert<UInt64>(source);
                //case Type t when t == KozmosTypeHelper<UInt64?>._: return Convert<UInt64>(source);

                case Type t when t == KozmosTypeHelper<Int64>._: return Convert<Int64>(source);
                //case Type t when t == KozmosTypeHelper<Int64?>._: return Convert<Int64>(source);

                case Type t when t == KozmosTypeHelper<UInt128>._: return Convert<UInt128>(source);
                //case Type t when t == KozmosTypeHelper<UInt128?>._: return Convert<UInt128>(source);

                case Type t when t == KozmosTypeHelper<Int128>._: return Convert<Int128>(source);
                //case Type t when t == KozmosTypeHelper<Int128?>._: return Convert<Int128>(source);

                case Type t when t == KozmosTypeHelper<BigInteger>._: return Convert<BigInteger>(source);
                //case Type t when t == KozmosTypeHelper<BigInteger?>._: return Convert<BigInteger>(source);

                case Type t when t == KozmosTypeHelper<Decimal>._: return Convert<Decimal>(source);
                //case Type t when t == KozmosTypeHelper<Decimal?>._: return Convert<Decimal>(source);

                case Type t when t == KozmosTypeHelper<Single>._: return Convert<Single>(source);
                //case Type t when t == KozmosTypeHelper<Single?>._: return Convert<Single>(source);

                case Type t when t == KozmosTypeHelper<Double>._: return Convert<Double>(source);
                //case Type t when t == KozmosTypeHelper<Double?>._: return Convert<Double>(source);

                case null: KozmosArgumentNullExceptionHelper.Throw(resultType); return null;
            }

            KozmosExceptionHelper.ThrowValue_0_OfArgument_1_2_IsNotSupported(resultType);
            return null;
        }

        [MethodImpl(MethodImplOptions.AggressiveOptimization)]
        public static Object? Convert(TimeSpan? source, EKozmosTimeSpanComponent component, Type resultType)
        {
            switch (resultType)
            {
                case Type t when t == KozmosTypeHelper<Byte>._: return Convert<Byte>(source, component);
                //case Type t when t == KozmosTypeHelper<Byte?>._: return Convert<Byte>(source, component);

                case Type t when t == KozmosTypeHelper<SByte>._: return Convert<SByte>(source, component);
                //case Type t when t == KozmosTypeHelper<SByte?>._: return Convert<SByte>(source, component);

                case Type t when t == KozmosTypeHelper<UInt16>._: return Convert<UInt16>(source, component);
                //case Type t when t == KozmosTypeHelper<UInt16?>._: return Convert<UInt16>(source, component);

                case Type t when t == KozmosTypeHelper<Int16>._: return Convert<Int16>(source, component);
                //case Type t when t == KozmosTypeHelper<Int16?>._: return Convert<Int16>(source, component);

                case Type t when t == KozmosTypeHelper<UInt32>._: return Convert<UInt32>(source, component);
                //case Type t when t == KozmosTypeHelper<UInt32?>._: return Convert<UInt32>(source, component);

                case Type t when t == KozmosTypeHelper<Int32>._: return Convert<Int32>(source, component);
                //case Type t when t == KozmosTypeHelper<Int32?>._: return Convert<Int32>(source, component);

                case Type t when t == KozmosTypeHelper<UInt64>._: return Convert<UInt64>(source, component);
                //case Type t when t == KozmosTypeHelper<UInt64?>._: return Convert<UInt64>(source, component);

                case Type t when t == KozmosTypeHelper<Int64>._: return Convert<Int64>(source, component);
                //case Type t when t == KozmosTypeHelper<Int64?>._: return Convert<Int64>(source, component);

                case Type t when t == KozmosTypeHelper<UInt128>._: return Convert<UInt128>(source, component);
                //case Type t when t == KozmosTypeHelper<UInt128?>._: return Convert<UInt128>(source, component);

                case Type t when t == KozmosTypeHelper<Int128>._: return Convert<Int128>(source, component);
                //case Type t when t == KozmosTypeHelper<Int128?>._: return Convert<Int128>(source, component);

                case Type t when t == KozmosTypeHelper<BigInteger>._: return Convert<BigInteger>(source, component);
                //case Type t when t == KozmosTypeHelper<BigInteger?>._: return Convert<BigInteger>(source, component);

                case Type t when t == KozmosTypeHelper<Decimal>._: return Convert<Decimal>(source, component);
                //case Type t when t == KozmosTypeHelper<Decimal?>._: return Convert<Decimal>(source, component);

                case Type t when t == KozmosTypeHelper<Single>._: return Convert<Single>(source, component);
                //case Type t when t == KozmosTypeHelper<Single?>._: return Convert<Single>(source, component);

                case Type t when t == KozmosTypeHelper<Double>._: return Convert<Double>(source, component);
                //case Type t when t == KozmosTypeHelper<Double?>._: return Convert<Double>(source, component);

                case null: KozmosArgumentNullExceptionHelper.Throw(resultType); return null;
            }

            KozmosExceptionHelper.ThrowValue_0_OfArgument_1_2_IsNotSupported(resultType);
            return null;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TResult Convert<TResult>(TimeSpan source)
           where TResult : struct, INumber<TResult>
        { return KozmosNumberHelper<TResult>.Convert(source); }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TResult Convert<TResult>(TimeSpan source, EKozmosTimeSpanComponent component)
           where TResult : struct, INumber<TResult>
        { return KozmosNumberHelper<TResult>.Convert(source, component); }

        [MethodImpl(MethodImplOptions.AggressiveOptimization)]
        public static Object? Convert(TimeSpan source, Type resultType)
        {
            switch (resultType)
            {
                case Type t when t == KozmosTypeHelper<Byte>._: return Convert<Byte>(source);
                //case Type t when t == KozmosTypeHelper<Byte?>._: return Convert<Byte>(source);

                case Type t when t == KozmosTypeHelper<SByte>._: return Convert<SByte>(source);
                //case Type t when t == KozmosTypeHelper<SByte?>._: return Convert<SByte>(source);

                case Type t when t == KozmosTypeHelper<UInt16>._: return Convert<UInt16>(source);
                //case Type t when t == KozmosTypeHelper<UInt16?>._: return Convert<UInt16>(source);

                case Type t when t == KozmosTypeHelper<Int16>._: return Convert<Int16>(source);
                //case Type t when t == KozmosTypeHelper<Int16?>._: return Convert<Int16>(source);

                case Type t when t == KozmosTypeHelper<UInt32>._: return Convert<UInt32>(source);
                //case Type t when t == KozmosTypeHelper<UInt32?>._: return Convert<UInt32>(source);

                case Type t when t == KozmosTypeHelper<Int32>._: return Convert<Int32>(source);
                //case Type t when t == KozmosTypeHelper<Int32?>._: return Convert<Int32>(source);

                case Type t when t == KozmosTypeHelper<UInt64>._: return Convert<UInt64>(source);
                //case Type t when t == KozmosTypeHelper<UInt64?>._: return Convert<UInt64>(source);

                case Type t when t == KozmosTypeHelper<Int64>._: return Convert<Int64>(source);
                //case Type t when t == KozmosTypeHelper<Int64?>._: return Convert<Int64>(source);

                case Type t when t == KozmosTypeHelper<UInt128>._: return Convert<UInt128>(source);
                //case Type t when t == KozmosTypeHelper<UInt128?>._: return Convert<UInt128>(source);

                case Type t when t == KozmosTypeHelper<Int128>._: return Convert<Int128>(source);
                //case Type t when t == KozmosTypeHelper<Int128?>._: return Convert<Int128>(source);

                case Type t when t == KozmosTypeHelper<BigInteger>._: return Convert<BigInteger>(source);
                //case Type t when t == KozmosTypeHelper<BigInteger?>._: return Convert<BigInteger>(source);

                case Type t when t == KozmosTypeHelper<Decimal>._: return Convert<Decimal>(source);
                //case Type t when t == KozmosTypeHelper<Decimal?>._: return Convert<Decimal>(source);

                case Type t when t == KozmosTypeHelper<Single>._: return Convert<Single>(source);
                //case Type t when t == KozmosTypeHelper<Single?>._: return Convert<Single>(source);

                case Type t when t == KozmosTypeHelper<Double>._: return Convert<Double>(source);
                //case Type t when t == KozmosTypeHelper<Double?>._: return Convert<Double>(source);

                case null: KozmosArgumentNullExceptionHelper.Throw(resultType); return null;
            }

            KozmosExceptionHelper.ThrowValue_0_OfArgument_1_2_IsNotSupported(resultType);
            return null;
        }

        [MethodImpl(MethodImplOptions.AggressiveOptimization)]
        public static Object? Convert(TimeSpan source, EKozmosTimeSpanComponent component, Type resultType)
        {
            switch (resultType)
            {
                case Type t when t == KozmosTypeHelper<Byte>._: return Convert<Byte>(source, component);
                //case Type t when t == KozmosTypeHelper<Byte?>._: return Convert<Byte>(source, component);

                case Type t when t == KozmosTypeHelper<SByte>._: return Convert<SByte>(source, component);
                //case Type t when t == KozmosTypeHelper<SByte?>._: return Convert<SByte>(source, component);

                case Type t when t == KozmosTypeHelper<UInt16>._: return Convert<UInt16>(source, component);
                //case Type t when t == KozmosTypeHelper<UInt16?>._: return Convert<UInt16>(source, component);

                case Type t when t == KozmosTypeHelper<Int16>._: return Convert<Int16>(source, component);
                //case Type t when t == KozmosTypeHelper<Int16?>._: return Convert<Int16>(source, component);

                case Type t when t == KozmosTypeHelper<UInt32>._: return Convert<UInt32>(source, component);
                //case Type t when t == KozmosTypeHelper<UInt32?>._: return Convert<UInt32>(source, component);

                case Type t when t == KozmosTypeHelper<Int32>._: return Convert<Int32>(source, component);
                //case Type t when t == KozmosTypeHelper<Int32?>._: return Convert<Int32>(source, component);

                case Type t when t == KozmosTypeHelper<UInt64>._: return Convert<UInt64>(source, component);
                //case Type t when t == KozmosTypeHelper<UInt64?>._: return Convert<UInt64>(source, component);

                case Type t when t == KozmosTypeHelper<Int64>._: return Convert<Int64>(source, component);
                //case Type t when t == KozmosTypeHelper<Int64?>._: return Convert<Int64>(source, component);

                case Type t when t == KozmosTypeHelper<UInt128>._: return Convert<UInt128>(source, component);
                //case Type t when t == KozmosTypeHelper<UInt128?>._: return Convert<UInt128>(source, component);

                case Type t when t == KozmosTypeHelper<Int128>._: return Convert<Int128>(source, component);
                //case Type t when t == KozmosTypeHelper<Int128?>._: return Convert<Int128>(source, component);

                case Type t when t == KozmosTypeHelper<BigInteger>._: return Convert<BigInteger>(source, component);
                //case Type t when t == KozmosTypeHelper<BigInteger?>._: return Convert<BigInteger>(source, component);

                case Type t when t == KozmosTypeHelper<Decimal>._: return Convert<Decimal>(source, component);
                //case Type t when t == KozmosTypeHelper<Decimal?>._: return Convert<Decimal>(source, component);

                case Type t when t == KozmosTypeHelper<Single>._: return Convert<Single>(source, component);
                //case Type t when t == KozmosTypeHelper<Single?>._: return Convert<Single>(source, component);

                case Type t when t == KozmosTypeHelper<Double>._: return Convert<Double>(source, component);
                //case Type t when t == KozmosTypeHelper<Double?>._: return Convert<Double>(source, component);

                case null: KozmosArgumentNullExceptionHelper.Throw(resultType); return null;
            }

            KozmosExceptionHelper.ThrowValue_0_OfArgument_1_2_IsNotSupported(resultType);
            return null;
        }

        #endregion

        #endregion

        #region Textuals

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TResult Convert<TResult>(String source)
           where TResult : struct, INumber<TResult>
        { return KozmosNumberHelper<TResult>.Convert(source); }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TResult Convert<TResult>(String source, KozmosNumberIParsableConvertOptions options)
           where TResult : struct, INumber<TResult>
        { return KozmosNumberHelper<TResult>.Convert(source, options); }

        [MethodImpl(MethodImplOptions.AggressiveOptimization)]
        public static Object? Convert(String source, Type resultType)
        {
            switch (resultType)
            {
                case Type t when t == KozmosTypeHelper<Byte>._: return Convert<Byte>(source);
                //case Type t when t == KozmosTypeHelper<Byte?>._: return Convert<Byte>(source);

                case Type t when t == KozmosTypeHelper<SByte>._: return Convert<SByte>(source);
                //case Type t when t == KozmosTypeHelper<SByte?>._: return Convert<SByte>(source);

                case Type t when t == KozmosTypeHelper<UInt16>._: return Convert<UInt16>(source);
                //case Type t when t == KozmosTypeHelper<UInt16?>._: return Convert<UInt16>(source);

                case Type t when t == KozmosTypeHelper<Int16>._: return Convert<Int16>(source);
                //case Type t when t == KozmosTypeHelper<Int16?>._: return Convert<Int16>(source);

                case Type t when t == KozmosTypeHelper<UInt32>._: return Convert<UInt32>(source);
                //case Type t when t == KozmosTypeHelper<UInt32?>._: return Convert<UInt32>(source);

                case Type t when t == KozmosTypeHelper<Int32>._: return Convert<Int32>(source);
                //case Type t when t == KozmosTypeHelper<Int32?>._: return Convert<Int32>(source);

                case Type t when t == KozmosTypeHelper<UInt64>._: return Convert<UInt64>(source);
                //case Type t when t == KozmosTypeHelper<UInt64?>._: return Convert<UInt64>(source);

                case Type t when t == KozmosTypeHelper<Int64>._: return Convert<Int64>(source);
                //case Type t when t == KozmosTypeHelper<Int64?>._: return Convert<Int64>(source);

                case Type t when t == KozmosTypeHelper<UInt128>._: return Convert<UInt128>(source);
                //case Type t when t == KozmosTypeHelper<UInt128?>._: return Convert<UInt128>(source);

                case Type t when t == KozmosTypeHelper<Int128>._: return Convert<Int128>(source);
                //case Type t when t == KozmosTypeHelper<Int128?>._: return Convert<Int128>(source);

                case Type t when t == KozmosTypeHelper<BigInteger>._: return Convert<BigInteger>(source);
                //case Type t when t == KozmosTypeHelper<BigInteger?>._: return Convert<BigInteger>(source);

                case Type t when t == KozmosTypeHelper<Decimal>._: return Convert<Decimal>(source);
                //case Type t when t == KozmosTypeHelper<Decimal?>._: return Convert<Decimal>(source);

                case Type t when t == KozmosTypeHelper<Single>._: return Convert<Single>(source);
                //case Type t when t == KozmosTypeHelper<Single?>._: return Convert<Single>(source);

                case Type t when t == KozmosTypeHelper<Double>._: return Convert<Double>(source);
                //case Type t when t == KozmosTypeHelper<Double?>._: return Convert<Double>(source);

                case null: KozmosArgumentNullExceptionHelper.Throw(resultType); return null;
            }

            KozmosExceptionHelper.ThrowValue_0_OfArgument_1_2_IsNotSupported(resultType);
            return null;
        }

        [MethodImpl(MethodImplOptions.AggressiveOptimization)]
        public static Object? Convert(String source, KozmosNumberIParsableConvertOptions options, Type resultType)
        {
            switch (resultType)
            {
                case Type t when t == KozmosTypeHelper<Byte>._: return Convert<Byte>(source, options);
                //case Type t when t == KozmosTypeHelper<Byte?>._: return Convert<Byte>(source, options);

                case Type t when t == KozmosTypeHelper<SByte>._: return Convert<SByte>(source, options);
                //case Type t when t == KozmosTypeHelper<SByte?>._: return Convert<SByte>(source, options);

                case Type t when t == KozmosTypeHelper<UInt16>._: return Convert<UInt16>(source, options);
                //case Type t when t == KozmosTypeHelper<UInt16?>._: return Convert<UInt16>(source, options);

                case Type t when t == KozmosTypeHelper<Int16>._: return Convert<Int16>(source, options);
                //case Type t when t == KozmosTypeHelper<Int16?>._: return Convert<Int16>(source, options);

                case Type t when t == KozmosTypeHelper<UInt32>._: return Convert<UInt32>(source, options);
                //case Type t when t == KozmosTypeHelper<UInt32?>._: return Convert<UInt32>(source, options);

                case Type t when t == KozmosTypeHelper<Int32>._: return Convert<Int32>(source, options);
                //case Type t when t == KozmosTypeHelper<Int32?>._: return Convert<Int32>(source, options);

                case Type t when t == KozmosTypeHelper<UInt64>._: return Convert<UInt64>(source, options);
                //case Type t when t == KozmosTypeHelper<UInt64?>._: return Convert<UInt64>(source, options);

                case Type t when t == KozmosTypeHelper<Int64>._: return Convert<Int64>(source, options);
                //case Type t when t == KozmosTypeHelper<Int64?>._: return Convert<Int64>(source, options);

                case Type t when t == KozmosTypeHelper<UInt128>._: return Convert<UInt128>(source, options);
                //case Type t when t == KozmosTypeHelper<UInt128?>._: return Convert<UInt128>(source, options);

                case Type t when t == KozmosTypeHelper<Int128>._: return Convert<Int128>(source, options);
                //case Type t when t == KozmosTypeHelper<Int128?>._: return Convert<Int128>(source, options);

                case Type t when t == KozmosTypeHelper<BigInteger>._: return Convert<BigInteger>(source, options);
                //case Type t when t == KozmosTypeHelper<BigInteger?>._: return Convert<BigInteger>(source, options);

                case Type t when t == KozmosTypeHelper<Decimal>._: return Convert<Decimal>(source, options);
                //case Type t when t == KozmosTypeHelper<Decimal?>._: return Convert<Decimal>(source, options);

                case Type t when t == KozmosTypeHelper<Single>._: return Convert<Single>(source, options);
                //case Type t when t == KozmosTypeHelper<Single?>._: return Convert<Single>(source, options);

                case Type t when t == KozmosTypeHelper<Double>._: return Convert<Double>(source, options);
                //case Type t when t == KozmosTypeHelper<Double?>._: return Convert<Double>(source, options);

                case null: KozmosArgumentNullExceptionHelper.Throw(resultType); return null;
            }

            KozmosExceptionHelper.ThrowValue_0_OfArgument_1_2_IsNotSupported(resultType);
            return null;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TResult Convert<TResult>(ReadOnlySpan<Char> source)
           where TResult : struct, INumber<TResult>
        { return KozmosNumberHelper<TResult>.Convert(source); }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TResult Convert<TResult>(ReadOnlySpan<Char> source, KozmosNumberIParsableConvertOptions options)
           where TResult : struct, INumber<TResult>
        { return KozmosNumberHelper<TResult>.Convert(source, options); }

        [MethodImpl(MethodImplOptions.AggressiveOptimization)]
        public static Object? Convert(ReadOnlySpan<Char> source, Type resultType)
        {
            switch (resultType)
            {
                case Type t when t == KozmosTypeHelper<Byte>._: return Convert<Byte>(source);
                //case Type t when t == KozmosTypeHelper<Byte?>._: return Convert<Byte>(source);

                case Type t when t == KozmosTypeHelper<SByte>._: return Convert<SByte>(source);
                //case Type t when t == KozmosTypeHelper<SByte?>._: return Convert<SByte>(source);

                case Type t when t == KozmosTypeHelper<UInt16>._: return Convert<UInt16>(source);
                //case Type t when t == KozmosTypeHelper<UInt16?>._: return Convert<UInt16>(source);

                case Type t when t == KozmosTypeHelper<Int16>._: return Convert<Int16>(source);
                //case Type t when t == KozmosTypeHelper<Int16?>._: return Convert<Int16>(source);

                case Type t when t == KozmosTypeHelper<UInt32>._: return Convert<UInt32>(source);
                //case Type t when t == KozmosTypeHelper<UInt32?>._: return Convert<UInt32>(source);

                case Type t when t == KozmosTypeHelper<Int32>._: return Convert<Int32>(source);
                //case Type t when t == KozmosTypeHelper<Int32?>._: return Convert<Int32>(source);

                case Type t when t == KozmosTypeHelper<UInt64>._: return Convert<UInt64>(source);
                //case Type t when t == KozmosTypeHelper<UInt64?>._: return Convert<UInt64>(source);

                case Type t when t == KozmosTypeHelper<Int64>._: return Convert<Int64>(source);
                //case Type t when t == KozmosTypeHelper<Int64?>._: return Convert<Int64>(source);

                case Type t when t == KozmosTypeHelper<UInt128>._: return Convert<UInt128>(source);
                //case Type t when t == KozmosTypeHelper<UInt128?>._: return Convert<UInt128>(source);

                case Type t when t == KozmosTypeHelper<Int128>._: return Convert<Int128>(source);
                //case Type t when t == KozmosTypeHelper<Int128?>._: return Convert<Int128>(source);

                case Type t when t == KozmosTypeHelper<BigInteger>._: return Convert<BigInteger>(source);
                //case Type t when t == KozmosTypeHelper<BigInteger?>._: return Convert<BigInteger>(source);

                case Type t when t == KozmosTypeHelper<Decimal>._: return Convert<Decimal>(source);
                //case Type t when t == KozmosTypeHelper<Decimal?>._: return Convert<Decimal>(source);

                case Type t when t == KozmosTypeHelper<Single>._: return Convert<Single>(source);
                //case Type t when t == KozmosTypeHelper<Single?>._: return Convert<Single>(source);

                case Type t when t == KozmosTypeHelper<Double>._: return Convert<Double>(source);
                //case Type t when t == KozmosTypeHelper<Double?>._: return Convert<Double>(source);

                case null: KozmosArgumentNullExceptionHelper.Throw(resultType); return null;
            }

            KozmosExceptionHelper.ThrowValue_0_OfArgument_1_2_IsNotSupported(resultType);
            return null;
        }

        [MethodImpl(MethodImplOptions.AggressiveOptimization)]
        public static Object? Convert(ReadOnlySpan<Char> source, KozmosNumberIParsableConvertOptions options, Type resultType)
        {
            switch (resultType)
            {
                case Type t when t == KozmosTypeHelper<Byte>._: return Convert<Byte>(source, options);
                //case Type t when t == KozmosTypeHelper<Byte?>._: return Convert<Byte>(source, options);

                case Type t when t == KozmosTypeHelper<SByte>._: return Convert<SByte>(source, options);
                //case Type t when t == KozmosTypeHelper<SByte?>._: return Convert<SByte>(source, options);

                case Type t when t == KozmosTypeHelper<UInt16>._: return Convert<UInt16>(source, options);
                //case Type t when t == KozmosTypeHelper<UInt16?>._: return Convert<UInt16>(source, options);

                case Type t when t == KozmosTypeHelper<Int16>._: return Convert<Int16>(source, options);
                //case Type t when t == KozmosTypeHelper<Int16?>._: return Convert<Int16>(source, options);

                case Type t when t == KozmosTypeHelper<UInt32>._: return Convert<UInt32>(source, options);
                //case Type t when t == KozmosTypeHelper<UInt32?>._: return Convert<UInt32>(source, options);

                case Type t when t == KozmosTypeHelper<Int32>._: return Convert<Int32>(source, options);
                //case Type t when t == KozmosTypeHelper<Int32?>._: return Convert<Int32>(source, options);

                case Type t when t == KozmosTypeHelper<UInt64>._: return Convert<UInt64>(source, options);
                //case Type t when t == KozmosTypeHelper<UInt64?>._: return Convert<UInt64>(source, options);

                case Type t when t == KozmosTypeHelper<Int64>._: return Convert<Int64>(source, options);
                //case Type t when t == KozmosTypeHelper<Int64?>._: return Convert<Int64>(source, options);

                case Type t when t == KozmosTypeHelper<UInt128>._: return Convert<UInt128>(source, options);
                //case Type t when t == KozmosTypeHelper<UInt128?>._: return Convert<UInt128>(source, options);

                case Type t when t == KozmosTypeHelper<Int128>._: return Convert<Int128>(source, options);
                //case Type t when t == KozmosTypeHelper<Int128?>._: return Convert<Int128>(source, options);

                case Type t when t == KozmosTypeHelper<BigInteger>._: return Convert<BigInteger>(source, options);
                //case Type t when t == KozmosTypeHelper<BigInteger?>._: return Convert<BigInteger>(source, options);

                case Type t when t == KozmosTypeHelper<Decimal>._: return Convert<Decimal>(source, options);
                //case Type t when t == KozmosTypeHelper<Decimal?>._: return Convert<Decimal>(source, options);

                case Type t when t == KozmosTypeHelper<Single>._: return Convert<Single>(source, options);
                //case Type t when t == KozmosTypeHelper<Single?>._: return Convert<Single>(source, options);

                case Type t when t == KozmosTypeHelper<Double>._: return Convert<Double>(source, options);
                //case Type t when t == KozmosTypeHelper<Double?>._: return Convert<Double>(source, options);

                case null: KozmosArgumentNullExceptionHelper.Throw(resultType); return null;
            }

            KozmosExceptionHelper.ThrowValue_0_OfArgument_1_2_IsNotSupported(resultType);
            return null;
        }
        #endregion

        #region Objects

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TResult Convert<TResult>(Object? source)
            where TResult : struct, INumber<TResult>
        {
            return KozmosNumberHelper<TResult>.Convert(source);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TResult Convert<TResult>(Object? source, KozmosNumberConvertOptions options)
            where TResult : struct, INumber<TResult>
        {
            return KozmosNumberHelper<TResult>.Convert(source, options);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Object? Convert(Object? source, Type resultType)
        {
            return Convert(source, KozmosNumberConvertOptions.Default, resultType);
        }

        [MethodImpl(MethodImplOptions.AggressiveOptimization)]
        public static Object? Convert(Object? source, KozmosNumberConvertOptions options, Type resultType)
        {
            if (source is null)
            {
                if (IsNullable(resultType)) return null;
                KozmosArgumentNullExceptionHelper.Throw(source);
            }

            switch (source)
            {
                // Conditionals >
                case Boolean b: return Convert(b, resultType);
                // < Conditionals

                // Codeds >
                case Char c:
                    KozmosArgumentNullExceptionHelper.ThrowIfNull(options);
                    return Convert(c, options.CharComponent, resultType);
                // < Codeds

                // Fluidized >
                case Byte[] ba: return Convert(ba, resultType);
                // < Fluidized

                // Lizatings >
                case JsonElement je:
                    KozmosArgumentNullExceptionHelper.ThrowIfNull(options);
                    return Convert(je, options.IParsableConvertOptions, resultType);
                // < Lizatings

                // Numericals >
                case Byte by: return Convert(by, resultType);
                case SByte sby: return Convert(sby, resultType);
                case UInt16 ui16: return Convert(ui16, resultType);
                case Int16 i16: return Convert(i16, resultType);
                case UInt32 ui32: return Convert(ui32, resultType);
                case Int32 i32: return Convert(i32, resultType);
                case UInt64 ui64: return Convert(ui64, resultType);
                case Int64 i64: return Convert(i64, resultType);
                case UInt128 ui128: return Convert(ui128, resultType);
                case Int128 i128: return Convert(i128, resultType);
                case BigInteger bi: return Convert(bi, resultType);
                case Decimal m: return Convert(m, resultType);
                case Single f: return Convert(f, resultType);
                case Double d: return Convert(d, resultType);
                // < Numericals

                // Temporals >
                case DateOnly don:
                    KozmosArgumentNullExceptionHelper.ThrowIfNull(options);
                    return Convert(don, options.DateOnlyComponent, resultType);
                case DateTime dt:
                    KozmosArgumentNullExceptionHelper.ThrowIfNull(options);
                    return Convert(dt, options.DateTimeComponent, resultType);
                case DateTimeOffset dto:
                    KozmosArgumentNullExceptionHelper.ThrowIfNull(options);
                    return Convert(dto, options.DateTimeOffsetComponent, resultType);
                case TimeOnly to:
                    KozmosArgumentNullExceptionHelper.ThrowIfNull(options);
                    return Convert(to, options.TimeOnlyComponent, resultType);
                case TimeSpan ts:
                    KozmosArgumentNullExceptionHelper.ThrowIfNull(options);
                    return Convert(ts, options.TimeSpanComponent, resultType);
                // < Temporals

                // Textuals >
                case String s:
                    KozmosArgumentNullExceptionHelper.ThrowIfNull(options);
                    return Convert(s, options.IParsableConvertOptions, resultType);
                // < Textuals

                case null:
                    if (!IsNullable(resultType)) KozmosArgumentNullExceptionHelper.Throw(source);
                    return null;
            }

            KozmosExceptionHelper.ThrowValue_0_OfArgument_1_2_IsNotSupported(source);
            return null;
        }

        #endregion

        #endregion

        #region TryConvert

        #region Conditionals

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean TryConvert<TResult>(Boolean? source, out TResult result)
            where TResult : struct, INumber<TResult>
        { return KozmosNumberHelper<TResult>.TryConvert(source, out result); }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean TryConvert<TResult>(Boolean source, out TResult result)
            where TResult : struct, INumber<TResult>
        { return KozmosNumberHelper<TResult>.TryConvert(source, out result); }

        [MethodImpl(MethodImplOptions.AggressiveOptimization)]
        public static Boolean TryConvert(Boolean? source, Type resultType, out Object? result)
        {
            Boolean b;

            switch (resultType)
            {
                case Type t when t == KozmosTypeHelper<Byte>._:
                    b = TryConvert(source, out Byte by); result = by; return b;
                case Type t when t == KozmosTypeHelper<Byte?>._:
                    b = TryConvert(source, out Byte nby); result = b ? nby : null; return b;

                case Type t when t == KozmosTypeHelper<SByte>._:
                    b = TryConvert(source, out SByte sby); result = sby; return b;
                case Type t when t == KozmosTypeHelper<SByte?>._:
                    b = TryConvert(source, out SByte nsby); result = b ? nsby : null; return b;

                case Type t when t == KozmosTypeHelper<UInt16>._:
                    b = TryConvert(source, out UInt16 ui16); result = ui16; return b;
                case Type t when t == KozmosTypeHelper<UInt16?>._:
                    b = TryConvert(source, out UInt16 nui16); result = b ? nui16 : null; return b;

                case Type t when t == KozmosTypeHelper<Int16>._:
                    b = TryConvert(source, out Int16 i16); result = i16; return b;
                case Type t when t == KozmosTypeHelper<Int16?>._:
                    b = TryConvert(source, out Int16 ni16); result = b ? ni16 : null; return b;

                case Type t when t == KozmosTypeHelper<UInt32>._:
                    b = TryConvert(source, out UInt32 ui32); result = ui32; return b;
                case Type t when t == KozmosTypeHelper<UInt32?>._:
                    b = TryConvert(source, out UInt32 nui32); result = b ? nui32 : null; return b;

                case Type t when t == KozmosTypeHelper<Int32>._:
                    b = TryConvert(source, out Int32 i32); result = i32; return b;
                case Type t when t == KozmosTypeHelper<Int32?>._:
                    b = TryConvert(source, out Int32 ni32); result = b ? ni32 : null; return b;

                case Type t when t == KozmosTypeHelper<UInt64>._:
                    b = TryConvert(source, out UInt64 ui64); result = ui64; return b;
                case Type t when t == KozmosTypeHelper<UInt64?>._:
                    b = TryConvert(source, out UInt64 nui64); result = b ? nui64 : null; return b;

                case Type t when t == KozmosTypeHelper<Int64>._:
                    b = TryConvert(source, out Int64 i64); result = i64; return b;
                case Type t when t == KozmosTypeHelper<Int64?>._:
                    b = TryConvert(source, out Int64 ni64); result = b ? ni64 : null; return b;

                case Type t when t == KozmosTypeHelper<UInt128>._:
                    b = TryConvert(source, out UInt128 ui128); result = ui128; return b;
                case Type t when t == KozmosTypeHelper<UInt128?>._:
                    b = TryConvert(source, out UInt128 nui128); result = b ? nui128 : null; return b;

                case Type t when t == KozmosTypeHelper<Int128>._:
                    b = TryConvert(source, out Int128 i128); result = i128; return b;
                case Type t when t == KozmosTypeHelper<Int128?>._:
                    b = TryConvert(source, out Int128 ni128); result = b ? ni128 : null; return b;

                case Type t when t == KozmosTypeHelper<BigInteger>._:
                    b = TryConvert(source, out BigInteger bi); result = bi; return b;
                case Type t when t == KozmosTypeHelper<BigInteger?>._:
                    b = TryConvert(source, out BigInteger nbi); result = b ? nbi : null; return b;

                case Type t when t == KozmosTypeHelper<Decimal>._:
                    b = TryConvert(source, out Decimal m); result = m; return b;
                case Type t when t == KozmosTypeHelper<Decimal?>._:
                    b = TryConvert(source, out Decimal nm); result = b ? nm : null; return b;

                case Type t when t == KozmosTypeHelper<Single>._:
                    b = TryConvert(source, out Single f); result = f; return b;
                case Type t when t == KozmosTypeHelper<Single?>._:
                    b = TryConvert(source, out Single nf); result = b ? nf : null; return b;

                case Type t when t == KozmosTypeHelper<Double>._:
                    b = TryConvert(source, out Double d); result = d; return b;
                case Type t when t == KozmosTypeHelper<Double?>._:
                    b = TryConvert(source, out Double nd); result = b ? nd : null; return b;
            }

            KozmosExceptionHelper.ThrowValue_0_OfArgument_1_2_IsNotSupported(resultType);
            result = default; return false;
        }

        [MethodImpl(MethodImplOptions.AggressiveOptimization)]
        public static Boolean TryConvert(Boolean source, Type resultType, out Object? result)
        {
            Boolean b;

            switch (resultType)
            {
                case Type t when t == KozmosTypeHelper<Byte>._:
                    b = TryConvert(source, out Byte by); result = by; return b;
                case Type t when t == KozmosTypeHelper<Byte?>._:
                    b = TryConvert(source, out Byte nby); result = b ? nby : null; return b;

                case Type t when t == KozmosTypeHelper<SByte>._:
                    b = TryConvert(source, out SByte sby); result = sby; return b;
                case Type t when t == KozmosTypeHelper<SByte?>._:
                    b = TryConvert(source, out SByte nsby); result = b ? nsby : null; return b;

                case Type t when t == KozmosTypeHelper<UInt16>._:
                    b = TryConvert(source, out UInt16 ui16); result = ui16; return b;
                case Type t when t == KozmosTypeHelper<UInt16?>._:
                    b = TryConvert(source, out UInt16 nui16); result = b ? nui16 : null; return b;

                case Type t when t == KozmosTypeHelper<Int16>._:
                    b = TryConvert(source, out Int16 i16); result = i16; return b;
                case Type t when t == KozmosTypeHelper<Int16?>._:
                    b = TryConvert(source, out Int16 ni16); result = b ? ni16 : null; return b;

                case Type t when t == KozmosTypeHelper<UInt32>._:
                    b = TryConvert(source, out UInt32 ui32); result = ui32; return b;
                case Type t when t == KozmosTypeHelper<UInt32?>._:
                    b = TryConvert(source, out UInt32 nui32); result = b ? nui32 : null; return b;

                case Type t when t == KozmosTypeHelper<Int32>._:
                    b = TryConvert(source, out Int32 i32); result = i32; return b;
                case Type t when t == KozmosTypeHelper<Int32?>._:
                    b = TryConvert(source, out Int32 ni32); result = b ? ni32 : null; return b;

                case Type t when t == KozmosTypeHelper<UInt64>._:
                    b = TryConvert(source, out UInt64 ui64); result = ui64; return b;
                case Type t when t == KozmosTypeHelper<UInt64?>._:
                    b = TryConvert(source, out UInt64 nui64); result = b ? nui64 : null; return b;

                case Type t when t == KozmosTypeHelper<Int64>._:
                    b = TryConvert(source, out Int64 i64); result = i64; return b;
                case Type t when t == KozmosTypeHelper<Int64?>._:
                    b = TryConvert(source, out Int64 ni64); result = b ? ni64 : null; return b;

                case Type t when t == KozmosTypeHelper<UInt128>._:
                    b = TryConvert(source, out UInt128 ui128); result = ui128; return b;
                case Type t when t == KozmosTypeHelper<UInt128?>._:
                    b = TryConvert(source, out UInt128 nui128); result = b ? nui128 : null; return b;

                case Type t when t == KozmosTypeHelper<Int128>._:
                    b = TryConvert(source, out Int128 i128); result = i128; return b;
                case Type t when t == KozmosTypeHelper<Int128?>._:
                    b = TryConvert(source, out Int128 ni128); result = b ? ni128 : null; return b;

                case Type t when t == KozmosTypeHelper<BigInteger>._:
                    b = TryConvert(source, out BigInteger bi); result = bi; return b;
                case Type t when t == KozmosTypeHelper<BigInteger?>._:
                    b = TryConvert(source, out BigInteger nbi); result = b ? nbi : null; return b;

                case Type t when t == KozmosTypeHelper<Decimal>._:
                    b = TryConvert(source, out Decimal m); result = m; return b;
                case Type t when t == KozmosTypeHelper<Decimal?>._:
                    b = TryConvert(source, out Decimal nm); result = b ? nm : null; return b;

                case Type t when t == KozmosTypeHelper<Single>._:
                    b = TryConvert(source, out Single f); result = f; return b;
                case Type t when t == KozmosTypeHelper<Single?>._:
                    b = TryConvert(source, out Single nf); result = b ? nf : null; return b;

                case Type t when t == KozmosTypeHelper<Double>._:
                    b = TryConvert(source, out Double d); result = d; return b;
                case Type t when t == KozmosTypeHelper<Double?>._:
                    b = TryConvert(source, out Double nd); result = b ? nd : null; return b;
            }

            KozmosExceptionHelper.ThrowValue_0_OfArgument_1_2_IsNotSupported(resultType);
            result = default; return false;
        }

        #endregion

        #region Codeds

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean TryConvert<TResult>(Char? source, out TResult result)
           where TResult : struct, INumber<TResult>
        { return KozmosNumberHelper<TResult>.TryConvert(source, out result); }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean TryConvert<TResult>(Char? source, EKozmosCharComponent component, out TResult result)
          where TResult : struct, INumber<TResult>
        { return KozmosNumberHelper<TResult>.TryConvert(source, component, out result); }

        [MethodImpl(MethodImplOptions.AggressiveOptimization)]
        public static Boolean TryConvert(Char? source, Type resultType, out Object? result)
        {
            Boolean b;

            switch (resultType)
            {
                case Type t when t == KozmosTypeHelper<Byte>._:
                    b = TryConvert(source, out Byte by); result = by; return b;
                case Type t when t == KozmosTypeHelper<Byte?>._:
                    b = TryConvert(source, out Byte nby); result = b ? nby : null; return b;

                case Type t when t == KozmosTypeHelper<SByte>._:
                    b = TryConvert(source, out SByte sby); result = sby; return b;
                case Type t when t == KozmosTypeHelper<SByte?>._:
                    b = TryConvert(source, out SByte nsby); result = b ? nsby : null; return b;

                case Type t when t == KozmosTypeHelper<UInt16>._:
                    b = TryConvert(source, out UInt16 ui16); result = ui16; return b;
                case Type t when t == KozmosTypeHelper<UInt16?>._:
                    b = TryConvert(source, out UInt16 nui16); result = b ? nui16 : null; return b;

                case Type t when t == KozmosTypeHelper<Int16>._:
                    b = TryConvert(source, out Int16 i16); result = i16; return b;
                case Type t when t == KozmosTypeHelper<Int16?>._:
                    b = TryConvert(source, out Int16 ni16); result = b ? ni16 : null; return b;

                case Type t when t == KozmosTypeHelper<UInt32>._:
                    b = TryConvert(source, out UInt32 ui32); result = ui32; return b;
                case Type t when t == KozmosTypeHelper<UInt32?>._:
                    b = TryConvert(source, out UInt32 nui32); result = b ? nui32 : null; return b;

                case Type t when t == KozmosTypeHelper<Int32>._:
                    b = TryConvert(source, out Int32 i32); result = i32; return b;
                case Type t when t == KozmosTypeHelper<Int32?>._:
                    b = TryConvert(source, out Int32 ni32); result = b ? ni32 : null; return b;

                case Type t when t == KozmosTypeHelper<UInt64>._:
                    b = TryConvert(source, out UInt64 ui64); result = ui64; return b;
                case Type t when t == KozmosTypeHelper<UInt64?>._:
                    b = TryConvert(source, out UInt64 nui64); result = b ? nui64 : null; return b;

                case Type t when t == KozmosTypeHelper<Int64>._:
                    b = TryConvert(source, out Int64 i64); result = i64; return b;
                case Type t when t == KozmosTypeHelper<Int64?>._:
                    b = TryConvert(source, out Int64 ni64); result = b ? ni64 : null; return b;

                case Type t when t == KozmosTypeHelper<UInt128>._:
                    b = TryConvert(source, out UInt128 ui128); result = ui128; return b;
                case Type t when t == KozmosTypeHelper<UInt128?>._:
                    b = TryConvert(source, out UInt128 nui128); result = b ? nui128 : null; return b;

                case Type t when t == KozmosTypeHelper<Int128>._:
                    b = TryConvert(source, out Int128 i128); result = i128; return b;
                case Type t when t == KozmosTypeHelper<Int128?>._:
                    b = TryConvert(source, out Int128 ni128); result = b ? ni128 : null; return b;

                case Type t when t == KozmosTypeHelper<BigInteger>._:
                    b = TryConvert(source, out BigInteger bi); result = bi; return b;
                case Type t when t == KozmosTypeHelper<BigInteger?>._:
                    b = TryConvert(source, out BigInteger nbi); result = b ? nbi : null; return b;

                case Type t when t == KozmosTypeHelper<Decimal>._:
                    b = TryConvert(source, out Decimal m); result = m; return b;
                case Type t when t == KozmosTypeHelper<Decimal?>._:
                    b = TryConvert(source, out Decimal nm); result = b ? nm : null; return b;

                case Type t when t == KozmosTypeHelper<Single>._:
                    b = TryConvert(source, out Single f); result = f; return b;
                case Type t when t == KozmosTypeHelper<Single?>._:
                    b = TryConvert(source, out Single nf); result = b ? nf : null; return b;

                case Type t when t == KozmosTypeHelper<Double>._:
                    b = TryConvert(source, out Double d); result = d; return b;
                case Type t when t == KozmosTypeHelper<Double?>._:
                    b = TryConvert(source, out Double nd); result = b ? nd : null; return b;
            }

            KozmosExceptionHelper.ThrowValue_0_OfArgument_1_2_IsNotSupported(resultType);
            result = default; return false;
        }

        [MethodImpl(MethodImplOptions.AggressiveOptimization)]
        public static Boolean TryConvert(Char? source, EKozmosCharComponent component, Type resultType, out Object? result)
        {
            Boolean b;

            switch (resultType)
            {
                case Type t when t == KozmosTypeHelper<Byte>._:
                    b = TryConvert(source, component, out Byte by); result = by; return b;
                case Type t when t == KozmosTypeHelper<Byte?>._:
                    b = TryConvert(source, component, out Byte nby); result = b ? nby : null; return b;

                case Type t when t == KozmosTypeHelper<SByte>._:
                    b = TryConvert(source, component, out SByte sby); result = sby; return b;
                case Type t when t == KozmosTypeHelper<SByte?>._:
                    b = TryConvert(source, component, out SByte nsby); result = b ? nsby : null; return b;

                case Type t when t == KozmosTypeHelper<UInt16>._:
                    b = TryConvert(source, component, out UInt16 ui16); result = ui16; return b;
                case Type t when t == KozmosTypeHelper<UInt16?>._:
                    b = TryConvert(source, component, out UInt16 nui16); result = b ? nui16 : null; return b;

                case Type t when t == KozmosTypeHelper<Int16>._:
                    b = TryConvert(source, component, out Int16 i16); result = i16; return b;
                case Type t when t == KozmosTypeHelper<Int16?>._:
                    b = TryConvert(source, component, out Int16 ni16); result = b ? ni16 : null; return b;

                case Type t when t == KozmosTypeHelper<UInt32>._:
                    b = TryConvert(source, component, out UInt32 ui32); result = ui32; return b;
                case Type t when t == KozmosTypeHelper<UInt32?>._:
                    b = TryConvert(source, component, out UInt32 nui32); result = b ? nui32 : null; return b;

                case Type t when t == KozmosTypeHelper<Int32>._:
                    b = TryConvert(source, component, out Int32 i32); result = i32; return b;
                case Type t when t == KozmosTypeHelper<Int32?>._:
                    b = TryConvert(source, component, out Int32 ni32); result = b ? ni32 : null; return b;

                case Type t when t == KozmosTypeHelper<UInt64>._:
                    b = TryConvert(source, component, out UInt64 ui64); result = ui64; return b;
                case Type t when t == KozmosTypeHelper<UInt64?>._:
                    b = TryConvert(source, component, out UInt64 nui64); result = b ? nui64 : null; return b;

                case Type t when t == KozmosTypeHelper<Int64>._:
                    b = TryConvert(source, component, out Int64 i64); result = i64; return b;
                case Type t when t == KozmosTypeHelper<Int64?>._:
                    b = TryConvert(source, component, out Int64 ni64); result = b ? ni64 : null; return b;

                case Type t when t == KozmosTypeHelper<UInt128>._:
                    b = TryConvert(source, component, out UInt128 ui128); result = ui128; return b;
                case Type t when t == KozmosTypeHelper<UInt128?>._:
                    b = TryConvert(source, component, out UInt128 nui128); result = b ? nui128 : null; return b;

                case Type t when t == KozmosTypeHelper<Int128>._:
                    b = TryConvert(source, component, out Int128 i128); result = i128; return b;
                case Type t when t == KozmosTypeHelper<Int128?>._:
                    b = TryConvert(source, component, out Int128 ni128); result = b ? ni128 : null; return b;

                case Type t when t == KozmosTypeHelper<BigInteger>._:
                    b = TryConvert(source, component, out BigInteger bi); result = bi; return b;
                case Type t when t == KozmosTypeHelper<BigInteger?>._:
                    b = TryConvert(source, component, out BigInteger nbi); result = b ? nbi : null; return b;

                case Type t when t == KozmosTypeHelper<Decimal>._:
                    b = TryConvert(source, component, out Decimal m); result = m; return b;
                case Type t when t == KozmosTypeHelper<Decimal?>._:
                    b = TryConvert(source, component, out Decimal nm); result = b ? nm : null; return b;

                case Type t when t == KozmosTypeHelper<Single>._:
                    b = TryConvert(source, component, out Single f); result = f; return b;
                case Type t when t == KozmosTypeHelper<Single?>._:
                    b = TryConvert(source, component, out Single nf); result = b ? nf : null; return b;

                case Type t when t == KozmosTypeHelper<Double>._:
                    b = TryConvert(source, component, out Double d); result = d; return b;
                case Type t when t == KozmosTypeHelper<Double?>._:
                    b = TryConvert(source, component, out Double nd); result = b ? nd : null; return b;
            }

            KozmosExceptionHelper.ThrowValue_0_OfArgument_1_2_IsNotSupported(resultType);
            result = default; return false;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean TryConvert<TResult>(Char source, out TResult result)
            where TResult : struct, INumber<TResult>
        { return KozmosNumberHelper<TResult>.TryConvert(source, out result); }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean TryConvert<TResult>(Char source, EKozmosCharComponent component, out TResult result)
            where TResult : struct, INumber<TResult>
        { return KozmosNumberHelper<TResult>.TryConvert(source, component, out result); }

        [MethodImpl(MethodImplOptions.AggressiveOptimization)]
        public static Boolean TryConvert(Char source, Type resultType, out Object? result)
        {
            Boolean b;

            switch (resultType)
            {
                case Type t when t == KozmosTypeHelper<Byte>._:
                    b = TryConvert(source, out Byte by); result = by; return b;
                case Type t when t == KozmosTypeHelper<Byte?>._:
                    b = TryConvert(source, out Byte nby); result = b ? nby : null; return b;

                case Type t when t == KozmosTypeHelper<SByte>._:
                    b = TryConvert(source, out SByte sby); result = sby; return b;
                case Type t when t == KozmosTypeHelper<SByte?>._:
                    b = TryConvert(source, out SByte nsby); result = b ? nsby : null; return b;

                case Type t when t == KozmosTypeHelper<UInt16>._:
                    b = TryConvert(source, out UInt16 ui16); result = ui16; return b;
                case Type t when t == KozmosTypeHelper<UInt16?>._:
                    b = TryConvert(source, out UInt16 nui16); result = b ? nui16 : null; return b;

                case Type t when t == KozmosTypeHelper<Int16>._:
                    b = TryConvert(source, out Int16 i16); result = i16; return b;
                case Type t when t == KozmosTypeHelper<Int16?>._:
                    b = TryConvert(source, out Int16 ni16); result = b ? ni16 : null; return b;

                case Type t when t == KozmosTypeHelper<UInt32>._:
                    b = TryConvert(source, out UInt32 ui32); result = ui32; return b;
                case Type t when t == KozmosTypeHelper<UInt32?>._:
                    b = TryConvert(source, out UInt32 nui32); result = b ? nui32 : null; return b;

                case Type t when t == KozmosTypeHelper<Int32>._:
                    b = TryConvert(source, out Int32 i32); result = i32; return b;
                case Type t when t == KozmosTypeHelper<Int32?>._:
                    b = TryConvert(source, out Int32 ni32); result = b ? ni32 : null; return b;

                case Type t when t == KozmosTypeHelper<UInt64>._:
                    b = TryConvert(source, out UInt64 ui64); result = ui64; return b;
                case Type t when t == KozmosTypeHelper<UInt64?>._:
                    b = TryConvert(source, out UInt64 nui64); result = b ? nui64 : null; return b;

                case Type t when t == KozmosTypeHelper<Int64>._:
                    b = TryConvert(source, out Int64 i64); result = i64; return b;
                case Type t when t == KozmosTypeHelper<Int64?>._:
                    b = TryConvert(source, out Int64 ni64); result = b ? ni64 : null; return b;

                case Type t when t == KozmosTypeHelper<UInt128>._:
                    b = TryConvert(source, out UInt128 ui128); result = ui128; return b;
                case Type t when t == KozmosTypeHelper<UInt128?>._:
                    b = TryConvert(source, out UInt128 nui128); result = b ? nui128 : null; return b;

                case Type t when t == KozmosTypeHelper<Int128>._:
                    b = TryConvert(source, out Int128 i128); result = i128; return b;
                case Type t when t == KozmosTypeHelper<Int128?>._:
                    b = TryConvert(source, out Int128 ni128); result = b ? ni128 : null; return b;

                case Type t when t == KozmosTypeHelper<BigInteger>._:
                    b = TryConvert(source, out BigInteger bi); result = bi; return b;
                case Type t when t == KozmosTypeHelper<BigInteger?>._:
                    b = TryConvert(source, out BigInteger nbi); result = b ? nbi : null; return b;

                case Type t when t == KozmosTypeHelper<Decimal>._:
                    b = TryConvert(source, out Decimal m); result = m; return b;
                case Type t when t == KozmosTypeHelper<Decimal?>._:
                    b = TryConvert(source, out Decimal nm); result = b ? nm : null; return b;

                case Type t when t == KozmosTypeHelper<Single>._:
                    b = TryConvert(source, out Single f); result = f; return b;
                case Type t when t == KozmosTypeHelper<Single?>._:
                    b = TryConvert(source, out Single nf); result = b ? nf : null; return b;

                case Type t when t == KozmosTypeHelper<Double>._:
                    b = TryConvert(source, out Double d); result = d; return b;
                case Type t when t == KozmosTypeHelper<Double?>._:
                    b = TryConvert(source, out Double nd); result = b ? nd : null; return b;
            }

            KozmosExceptionHelper.ThrowValue_0_OfArgument_1_2_IsNotSupported(resultType);
            result = default; return false;
        }

        [MethodImpl(MethodImplOptions.AggressiveOptimization)]
        public static Boolean TryConvert(Char source, EKozmosCharComponent component, Type resultType, out Object? result)
        {
            Boolean b;

            switch (resultType)
            {
                case Type t when t == KozmosTypeHelper<Byte>._:
                    b = TryConvert(source, component, out Byte by); result = by; return b;
                case Type t when t == KozmosTypeHelper<Byte?>._:
                    b = TryConvert(source, component, out Byte nby); result = b ? nby : null; return b;

                case Type t when t == KozmosTypeHelper<SByte>._:
                    b = TryConvert(source, component, out SByte sby); result = sby; return b;
                case Type t when t == KozmosTypeHelper<SByte?>._:
                    b = TryConvert(source, component, out SByte nsby); result = b ? nsby : null; return b;

                case Type t when t == KozmosTypeHelper<UInt16>._:
                    b = TryConvert(source, component, out UInt16 ui16); result = ui16; return b;
                case Type t when t == KozmosTypeHelper<UInt16?>._:
                    b = TryConvert(source, component, out UInt16 nui16); result = b ? nui16 : null; return b;

                case Type t when t == KozmosTypeHelper<Int16>._:
                    b = TryConvert(source, component, out Int16 i16); result = i16; return b;
                case Type t when t == KozmosTypeHelper<Int16?>._:
                    b = TryConvert(source, component, out Int16 ni16); result = b ? ni16 : null; return b;

                case Type t when t == KozmosTypeHelper<UInt32>._:
                    b = TryConvert(source, component, out UInt32 ui32); result = ui32; return b;
                case Type t when t == KozmosTypeHelper<UInt32?>._:
                    b = TryConvert(source, component, out UInt32 nui32); result = b ? nui32 : null; return b;

                case Type t when t == KozmosTypeHelper<Int32>._:
                    b = TryConvert(source, component, out Int32 i32); result = i32; return b;
                case Type t when t == KozmosTypeHelper<Int32?>._:
                    b = TryConvert(source, component, out Int32 ni32); result = b ? ni32 : null; return b;

                case Type t when t == KozmosTypeHelper<UInt64>._:
                    b = TryConvert(source, component, out UInt64 ui64); result = ui64; return b;
                case Type t when t == KozmosTypeHelper<UInt64?>._:
                    b = TryConvert(source, component, out UInt64 nui64); result = b ? nui64 : null; return b;

                case Type t when t == KozmosTypeHelper<Int64>._:
                    b = TryConvert(source, component, out Int64 i64); result = i64; return b;
                case Type t when t == KozmosTypeHelper<Int64?>._:
                    b = TryConvert(source, component, out Int64 ni64); result = b ? ni64 : null; return b;

                case Type t when t == KozmosTypeHelper<UInt128>._:
                    b = TryConvert(source, component, out UInt128 ui128); result = ui128; return b;
                case Type t when t == KozmosTypeHelper<UInt128?>._:
                    b = TryConvert(source, component, out UInt128 nui128); result = b ? nui128 : null; return b;

                case Type t when t == KozmosTypeHelper<Int128>._:
                    b = TryConvert(source, component, out Int128 i128); result = i128; return b;
                case Type t when t == KozmosTypeHelper<Int128?>._:
                    b = TryConvert(source, component, out Int128 ni128); result = b ? ni128 : null; return b;

                case Type t when t == KozmosTypeHelper<BigInteger>._:
                    b = TryConvert(source, component, out BigInteger bi); result = bi; return b;
                case Type t when t == KozmosTypeHelper<BigInteger?>._:
                    b = TryConvert(source, component, out BigInteger nbi); result = b ? nbi : null; return b;

                case Type t when t == KozmosTypeHelper<Decimal>._:
                    b = TryConvert(source, component, out Decimal m); result = m; return b;
                case Type t when t == KozmosTypeHelper<Decimal?>._:
                    b = TryConvert(source, component, out Decimal nm); result = b ? nm : null; return b;

                case Type t when t == KozmosTypeHelper<Single>._:
                    b = TryConvert(source, component, out Single f); result = f; return b;
                case Type t when t == KozmosTypeHelper<Single?>._:
                    b = TryConvert(source, component, out Single nf); result = b ? nf : null; return b;

                case Type t when t == KozmosTypeHelper<Double>._:
                    b = TryConvert(source, component, out Double d); result = d; return b;
                case Type t when t == KozmosTypeHelper<Double?>._:
                    b = TryConvert(source, component, out Double nd); result = b ? nd : null; return b;
            }

            KozmosExceptionHelper.ThrowValue_0_OfArgument_1_2_IsNotSupported(resultType);
            result = default; return false;
        }

        #endregion

        #region Fluidized

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean TryConvert<TResult>(Byte[]? source, out TResult result)
           where TResult : struct, INumber<TResult>
        { return KozmosNumberHelper<TResult>.TryConvert(source, out result); }

        [MethodImpl(MethodImplOptions.AggressiveOptimization)]
        public static Boolean TryConvert(Byte[]? source, Type resultType, out Object? result)
        {
            Boolean b;

            switch (resultType)
            {
                case Type t when t == KozmosTypeHelper<Byte>._:
                    b = TryConvert(source, out Byte by); result = by; return b;
                case Type t when t == KozmosTypeHelper<Byte?>._:
                    b = TryConvert(source, out Byte nby); result = b ? nby : null; return b;

                case Type t when t == KozmosTypeHelper<SByte>._:
                    b = TryConvert(source, out SByte sby); result = sby; return b;
                case Type t when t == KozmosTypeHelper<SByte?>._:
                    b = TryConvert(source, out SByte nsby); result = b ? nsby : null; return b;

                case Type t when t == KozmosTypeHelper<UInt16>._:
                    b = TryConvert(source, out UInt16 ui16); result = ui16; return b;
                case Type t when t == KozmosTypeHelper<UInt16?>._:
                    b = TryConvert(source, out UInt16 nui16); result = b ? nui16 : null; return b;

                case Type t when t == KozmosTypeHelper<Int16>._:
                    b = TryConvert(source, out Int16 i16); result = i16; return b;
                case Type t when t == KozmosTypeHelper<Int16?>._:
                    b = TryConvert(source, out Int16 ni16); result = b ? ni16 : null; return b;

                case Type t when t == KozmosTypeHelper<UInt32>._:
                    b = TryConvert(source, out UInt32 ui32); result = ui32; return b;
                case Type t when t == KozmosTypeHelper<UInt32?>._:
                    b = TryConvert(source, out UInt32 nui32); result = b ? nui32 : null; return b;

                case Type t when t == KozmosTypeHelper<Int32>._:
                    b = TryConvert(source, out Int32 i32); result = i32; return b;
                case Type t when t == KozmosTypeHelper<Int32?>._:
                    b = TryConvert(source, out Int32 ni32); result = b ? ni32 : null; return b;

                case Type t when t == KozmosTypeHelper<UInt64>._:
                    b = TryConvert(source, out UInt64 ui64); result = ui64; return b;
                case Type t when t == KozmosTypeHelper<UInt64?>._:
                    b = TryConvert(source, out UInt64 nui64); result = b ? nui64 : null; return b;

                case Type t when t == KozmosTypeHelper<Int64>._:
                    b = TryConvert(source, out Int64 i64); result = i64; return b;
                case Type t when t == KozmosTypeHelper<Int64?>._:
                    b = TryConvert(source, out Int64 ni64); result = b ? ni64 : null; return b;

                case Type t when t == KozmosTypeHelper<UInt128>._:
                    b = TryConvert(source, out UInt128 ui128); result = ui128; return b;
                case Type t when t == KozmosTypeHelper<UInt128?>._:
                    b = TryConvert(source, out UInt128 nui128); result = b ? nui128 : null; return b;

                case Type t when t == KozmosTypeHelper<Int128>._:
                    b = TryConvert(source, out Int128 i128); result = i128; return b;
                case Type t when t == KozmosTypeHelper<Int128?>._:
                    b = TryConvert(source, out Int128 ni128); result = b ? ni128 : null; return b;

                case Type t when t == KozmosTypeHelper<BigInteger>._:
                    b = TryConvert(source, out BigInteger bi); result = bi; return b;
                case Type t when t == KozmosTypeHelper<BigInteger?>._:
                    b = TryConvert(source, out BigInteger nbi); result = b ? nbi : null; return b;

                case Type t when t == KozmosTypeHelper<Decimal>._:
                    b = TryConvert(source, out Decimal m); result = m; return b;
                case Type t when t == KozmosTypeHelper<Decimal?>._:
                    b = TryConvert(source, out Decimal nm); result = b ? nm : null; return b;

                case Type t when t == KozmosTypeHelper<Single>._:
                    b = TryConvert(source, out Single f); result = f; return b;
                case Type t when t == KozmosTypeHelper<Single?>._:
                    b = TryConvert(source, out Single nf); result = b ? nf : null; return b;

                case Type t when t == KozmosTypeHelper<Double>._:
                    b = TryConvert(source, out Double d); result = d; return b;
                case Type t when t == KozmosTypeHelper<Double?>._:
                    b = TryConvert(source, out Double nd); result = b ? nd : null; return b;
            }

            KozmosExceptionHelper.ThrowValue_0_OfArgument_1_2_IsNotSupported(resultType);
            result = default; return false;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean TryConvert<TResult>(ReadOnlySpan<Byte> source, out TResult result)
           where TResult : struct, INumber<TResult>
        { return KozmosNumberHelper<TResult>.TryConvert(source, out result); }

        [MethodImpl(MethodImplOptions.AggressiveOptimization)]
        public static Boolean TryConvert(ReadOnlySpan<Byte> source, Type resultType, out Object? result)
        {
            Boolean b;

            switch (resultType)
            {
                case Type t when t == KozmosTypeHelper<Byte>._:
                    b = TryConvert(source, out Byte by); result = by; return b;
                case Type t when t == KozmosTypeHelper<Byte?>._:
                    b = TryConvert(source, out Byte nby); result = b ? nby : null; return b;

                case Type t when t == KozmosTypeHelper<SByte>._:
                    b = TryConvert(source, out SByte sby); result = sby; return b;
                case Type t when t == KozmosTypeHelper<SByte?>._:
                    b = TryConvert(source, out SByte nsby); result = b ? nsby : null; return b;

                case Type t when t == KozmosTypeHelper<UInt16>._:
                    b = TryConvert(source, out UInt16 ui16); result = ui16; return b;
                case Type t when t == KozmosTypeHelper<UInt16?>._:
                    b = TryConvert(source, out UInt16 nui16); result = b ? nui16 : null; return b;

                case Type t when t == KozmosTypeHelper<Int16>._:
                    b = TryConvert(source, out Int16 i16); result = i16; return b;
                case Type t when t == KozmosTypeHelper<Int16?>._:
                    b = TryConvert(source, out Int16 ni16); result = b ? ni16 : null; return b;

                case Type t when t == KozmosTypeHelper<UInt32>._:
                    b = TryConvert(source, out UInt32 ui32); result = ui32; return b;
                case Type t when t == KozmosTypeHelper<UInt32?>._:
                    b = TryConvert(source, out UInt32 nui32); result = b ? nui32 : null; return b;

                case Type t when t == KozmosTypeHelper<Int32>._:
                    b = TryConvert(source, out Int32 i32); result = i32; return b;
                case Type t when t == KozmosTypeHelper<Int32?>._:
                    b = TryConvert(source, out Int32 ni32); result = b ? ni32 : null; return b;

                case Type t when t == KozmosTypeHelper<UInt64>._:
                    b = TryConvert(source, out UInt64 ui64); result = ui64; return b;
                case Type t when t == KozmosTypeHelper<UInt64?>._:
                    b = TryConvert(source, out UInt64 nui64); result = b ? nui64 : null; return b;

                case Type t when t == KozmosTypeHelper<Int64>._:
                    b = TryConvert(source, out Int64 i64); result = i64; return b;
                case Type t when t == KozmosTypeHelper<Int64?>._:
                    b = TryConvert(source, out Int64 ni64); result = b ? ni64 : null; return b;

                case Type t when t == KozmosTypeHelper<UInt128>._:
                    b = TryConvert(source, out UInt128 ui128); result = ui128; return b;
                case Type t when t == KozmosTypeHelper<UInt128?>._:
                    b = TryConvert(source, out UInt128 nui128); result = b ? nui128 : null; return b;

                case Type t when t == KozmosTypeHelper<Int128>._:
                    b = TryConvert(source, out Int128 i128); result = i128; return b;
                case Type t when t == KozmosTypeHelper<Int128?>._:
                    b = TryConvert(source, out Int128 ni128); result = b ? ni128 : null; return b;

                case Type t when t == KozmosTypeHelper<BigInteger>._:
                    b = TryConvert(source, out BigInteger bi); result = bi; return b;
                case Type t when t == KozmosTypeHelper<BigInteger?>._:
                    b = TryConvert(source, out BigInteger nbi); result = b ? nbi : null; return b;

                case Type t when t == KozmosTypeHelper<Decimal>._:
                    b = TryConvert(source, out Decimal m); result = m; return b;
                case Type t when t == KozmosTypeHelper<Decimal?>._:
                    b = TryConvert(source, out Decimal nm); result = b ? nm : null; return b;

                case Type t when t == KozmosTypeHelper<Single>._:
                    b = TryConvert(source, out Single f); result = f; return b;
                case Type t when t == KozmosTypeHelper<Single?>._:
                    b = TryConvert(source, out Single nf); result = b ? nf : null; return b;

                case Type t when t == KozmosTypeHelper<Double>._:
                    b = TryConvert(source, out Double d); result = d; return b;
                case Type t when t == KozmosTypeHelper<Double?>._:
                    b = TryConvert(source, out Double nd); result = b ? nd : null; return b;
            }

            KozmosExceptionHelper.ThrowValue_0_OfArgument_1_2_IsNotSupported(resultType);
            result = default; return false;
        }

        #endregion

        #region Lizatings

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean TryConvert<TResult>(JsonElement? source, out TResult result)
           where TResult : struct, INumber<TResult>
        { return KozmosNumberHelper<TResult>.TryConvert(source, out result); }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean TryConvert<TResult>(JsonElement? source, KozmosNumberIParsableConvertOptions options, out TResult result)
           where TResult : struct, INumber<TResult>
        { return KozmosNumberHelper<TResult>.TryConvert(source, options, out result); }

        [MethodImpl(MethodImplOptions.AggressiveOptimization)]
        public static Boolean TryConvert(JsonElement? source, Type resultType, out Object? result)
        {
            Boolean b;

            switch (resultType)
            {
                case Type t when t == KozmosTypeHelper<Byte>._:
                    b = TryConvert(source, out Byte by); result = by; return b;
                case Type t when t == KozmosTypeHelper<Byte?>._:
                    b = TryConvert(source, out Byte nby); result = b ? nby : null; return b;

                case Type t when t == KozmosTypeHelper<SByte>._:
                    b = TryConvert(source, out SByte sby); result = sby; return b;
                case Type t when t == KozmosTypeHelper<SByte?>._:
                    b = TryConvert(source, out SByte nsby); result = b ? nsby : null; return b;

                case Type t when t == KozmosTypeHelper<UInt16>._:
                    b = TryConvert(source, out UInt16 ui16); result = ui16; return b;
                case Type t when t == KozmosTypeHelper<UInt16?>._:
                    b = TryConvert(source, out UInt16 nui16); result = b ? nui16 : null; return b;

                case Type t when t == KozmosTypeHelper<Int16>._:
                    b = TryConvert(source, out Int16 i16); result = i16; return b;
                case Type t when t == KozmosTypeHelper<Int16?>._:
                    b = TryConvert(source, out Int16 ni16); result = b ? ni16 : null; return b;

                case Type t when t == KozmosTypeHelper<UInt32>._:
                    b = TryConvert(source, out UInt32 ui32); result = ui32; return b;
                case Type t when t == KozmosTypeHelper<UInt32?>._:
                    b = TryConvert(source, out UInt32 nui32); result = b ? nui32 : null; return b;

                case Type t when t == KozmosTypeHelper<Int32>._:
                    b = TryConvert(source, out Int32 i32); result = i32; return b;
                case Type t when t == KozmosTypeHelper<Int32?>._:
                    b = TryConvert(source, out Int32 ni32); result = b ? ni32 : null; return b;

                case Type t when t == KozmosTypeHelper<UInt64>._:
                    b = TryConvert(source, out UInt64 ui64); result = ui64; return b;
                case Type t when t == KozmosTypeHelper<UInt64?>._:
                    b = TryConvert(source, out UInt64 nui64); result = b ? nui64 : null; return b;

                case Type t when t == KozmosTypeHelper<Int64>._:
                    b = TryConvert(source, out Int64 i64); result = i64; return b;
                case Type t when t == KozmosTypeHelper<Int64?>._:
                    b = TryConvert(source, out Int64 ni64); result = b ? ni64 : null; return b;

                case Type t when t == KozmosTypeHelper<UInt128>._:
                    b = TryConvert(source, out UInt128 ui128); result = ui128; return b;
                case Type t when t == KozmosTypeHelper<UInt128?>._:
                    b = TryConvert(source, out UInt128 nui128); result = b ? nui128 : null; return b;

                case Type t when t == KozmosTypeHelper<Int128>._:
                    b = TryConvert(source, out Int128 i128); result = i128; return b;
                case Type t when t == KozmosTypeHelper<Int128?>._:
                    b = TryConvert(source, out Int128 ni128); result = b ? ni128 : null; return b;

                case Type t when t == KozmosTypeHelper<BigInteger>._:
                    b = TryConvert(source, out BigInteger bi); result = bi; return b;
                case Type t when t == KozmosTypeHelper<BigInteger?>._:
                    b = TryConvert(source, out BigInteger nbi); result = b ? nbi : null; return b;

                case Type t when t == KozmosTypeHelper<Decimal>._:
                    b = TryConvert(source, out Decimal m); result = m; return b;
                case Type t when t == KozmosTypeHelper<Decimal?>._:
                    b = TryConvert(source, out Decimal nm); result = b ? nm : null; return b;

                case Type t when t == KozmosTypeHelper<Single>._:
                    b = TryConvert(source, out Single f); result = f; return b;
                case Type t when t == KozmosTypeHelper<Single?>._:
                    b = TryConvert(source, out Single nf); result = b ? nf : null; return b;

                case Type t when t == KozmosTypeHelper<Double>._:
                    b = TryConvert(source, out Double d); result = d; return b;
                case Type t when t == KozmosTypeHelper<Double?>._:
                    b = TryConvert(source, out Double nd); result = b ? nd : null; return b;
            }

            KozmosExceptionHelper.ThrowValue_0_OfArgument_1_2_IsNotSupported(resultType);
            result = default; return false;
        }

        [MethodImpl(MethodImplOptions.AggressiveOptimization)]
        public static Boolean TryConvert(JsonElement? source, KozmosNumberIParsableConvertOptions options, Type resultType, out Object? result)
        {
            Boolean b;

            switch (resultType)
            {
                case Type t when t == KozmosTypeHelper<Byte>._:
                    b = TryConvert(source, options, out Byte by); result = by; return b;
                case Type t when t == KozmosTypeHelper<Byte?>._:
                    b = TryConvert(source, options, out Byte nby); result = b ? nby : null; return b;

                case Type t when t == KozmosTypeHelper<SByte>._:
                    b = TryConvert(source, options, out SByte sby); result = sby; return b;
                case Type t when t == KozmosTypeHelper<SByte?>._:
                    b = TryConvert(source, options, out SByte nsby); result = b ? nsby : null; return b;

                case Type t when t == KozmosTypeHelper<UInt16>._:
                    b = TryConvert(source, options, out UInt16 ui16); result = ui16; return b;
                case Type t when t == KozmosTypeHelper<UInt16?>._:
                    b = TryConvert(source, options, out UInt16 nui16); result = b ? nui16 : null; return b;

                case Type t when t == KozmosTypeHelper<Int16>._:
                    b = TryConvert(source, options, out Int16 i16); result = i16; return b;
                case Type t when t == KozmosTypeHelper<Int16?>._:
                    b = TryConvert(source, options, out Int16 ni16); result = b ? ni16 : null; return b;

                case Type t when t == KozmosTypeHelper<UInt32>._:
                    b = TryConvert(source, options, out UInt32 ui32); result = ui32; return b;
                case Type t when t == KozmosTypeHelper<UInt32?>._:
                    b = TryConvert(source, options, out UInt32 nui32); result = b ? nui32 : null; return b;

                case Type t when t == KozmosTypeHelper<Int32>._:
                    b = TryConvert(source, options, out Int32 i32); result = i32; return b;
                case Type t when t == KozmosTypeHelper<Int32?>._:
                    b = TryConvert(source, options, out Int32 ni32); result = b ? ni32 : null; return b;

                case Type t when t == KozmosTypeHelper<UInt64>._:
                    b = TryConvert(source, options, out UInt64 ui64); result = ui64; return b;
                case Type t when t == KozmosTypeHelper<UInt64?>._:
                    b = TryConvert(source, options, out UInt64 nui64); result = b ? nui64 : null; return b;

                case Type t when t == KozmosTypeHelper<Int64>._:
                    b = TryConvert(source, options, out Int64 i64); result = i64; return b;
                case Type t when t == KozmosTypeHelper<Int64?>._:
                    b = TryConvert(source, options, out Int64 ni64); result = b ? ni64 : null; return b;

                case Type t when t == KozmosTypeHelper<UInt128>._:
                    b = TryConvert(source, options, out UInt128 ui128); result = ui128; return b;
                case Type t when t == KozmosTypeHelper<UInt128?>._:
                    b = TryConvert(source, options, out UInt128 nui128); result = b ? nui128 : null; return b;

                case Type t when t == KozmosTypeHelper<Int128>._:
                    b = TryConvert(source, options, out Int128 i128); result = i128; return b;
                case Type t when t == KozmosTypeHelper<Int128?>._:
                    b = TryConvert(source, options, out Int128 ni128); result = b ? ni128 : null; return b;

                case Type t when t == KozmosTypeHelper<BigInteger>._:
                    b = TryConvert(source, options, out BigInteger bi); result = bi; return b;
                case Type t when t == KozmosTypeHelper<BigInteger?>._:
                    b = TryConvert(source, options, out BigInteger nbi); result = b ? nbi : null; return b;

                case Type t when t == KozmosTypeHelper<Decimal>._:
                    b = TryConvert(source, options, out Decimal m); result = m; return b;
                case Type t when t == KozmosTypeHelper<Decimal?>._:
                    b = TryConvert(source, options, out Decimal nm); result = b ? nm : null; return b;

                case Type t when t == KozmosTypeHelper<Single>._:
                    b = TryConvert(source, options, out Single f); result = f; return b;
                case Type t when t == KozmosTypeHelper<Single?>._:
                    b = TryConvert(source, options, out Single nf); result = b ? nf : null; return b;

                case Type t when t == KozmosTypeHelper<Double>._:
                    b = TryConvert(source, options, out Double d); result = d; return b;
                case Type t when t == KozmosTypeHelper<Double?>._:
                    b = TryConvert(source, options, out Double nd); result = b ? nd : null; return b;
            }

            KozmosExceptionHelper.ThrowValue_0_OfArgument_1_2_IsNotSupported(resultType);
            result = default; return false;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean TryConvert<TResult>(JsonElement source, out TResult result)
           where TResult : struct, INumber<TResult>
        { return KozmosNumberHelper<TResult>.TryConvert(source, out result); }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean TryConvert<TResult>(JsonElement source, KozmosNumberIParsableConvertOptions options, out TResult result)
           where TResult : struct, INumber<TResult>
        { return KozmosNumberHelper<TResult>.TryConvert(source, options, out result); }

        [MethodImpl(MethodImplOptions.AggressiveOptimization)]
        public static Boolean TryConvert(JsonElement source, Type resultType, out Object? result)
        {
            Boolean b;

            switch (resultType)
            {
                case Type t when t == KozmosTypeHelper<Byte>._:
                    b = TryConvert(source, out Byte by); result = by; return b;
                case Type t when t == KozmosTypeHelper<Byte?>._:
                    b = TryConvert(source, out Byte nby); result = b ? nby : null; return b;

                case Type t when t == KozmosTypeHelper<SByte>._:
                    b = TryConvert(source, out SByte sby); result = sby; return b;
                case Type t when t == KozmosTypeHelper<SByte?>._:
                    b = TryConvert(source, out SByte nsby); result = b ? nsby : null; return b;

                case Type t when t == KozmosTypeHelper<UInt16>._:
                    b = TryConvert(source, out UInt16 ui16); result = ui16; return b;
                case Type t when t == KozmosTypeHelper<UInt16?>._:
                    b = TryConvert(source, out UInt16 nui16); result = b ? nui16 : null; return b;

                case Type t when t == KozmosTypeHelper<Int16>._:
                    b = TryConvert(source, out Int16 i16); result = i16; return b;
                case Type t when t == KozmosTypeHelper<Int16?>._:
                    b = TryConvert(source, out Int16 ni16); result = b ? ni16 : null; return b;

                case Type t when t == KozmosTypeHelper<UInt32>._:
                    b = TryConvert(source, out UInt32 ui32); result = ui32; return b;
                case Type t when t == KozmosTypeHelper<UInt32?>._:
                    b = TryConvert(source, out UInt32 nui32); result = b ? nui32 : null; return b;

                case Type t when t == KozmosTypeHelper<Int32>._:
                    b = TryConvert(source, out Int32 i32); result = i32; return b;
                case Type t when t == KozmosTypeHelper<Int32?>._:
                    b = TryConvert(source, out Int32 ni32); result = b ? ni32 : null; return b;

                case Type t when t == KozmosTypeHelper<UInt64>._:
                    b = TryConvert(source, out UInt64 ui64); result = ui64; return b;
                case Type t when t == KozmosTypeHelper<UInt64?>._:
                    b = TryConvert(source, out UInt64 nui64); result = b ? nui64 : null; return b;

                case Type t when t == KozmosTypeHelper<Int64>._:
                    b = TryConvert(source, out Int64 i64); result = i64; return b;
                case Type t when t == KozmosTypeHelper<Int64?>._:
                    b = TryConvert(source, out Int64 ni64); result = b ? ni64 : null; return b;

                case Type t when t == KozmosTypeHelper<UInt128>._:
                    b = TryConvert(source, out UInt128 ui128); result = ui128; return b;
                case Type t when t == KozmosTypeHelper<UInt128?>._:
                    b = TryConvert(source, out UInt128 nui128); result = b ? nui128 : null; return b;

                case Type t when t == KozmosTypeHelper<Int128>._:
                    b = TryConvert(source, out Int128 i128); result = i128; return b;
                case Type t when t == KozmosTypeHelper<Int128?>._:
                    b = TryConvert(source, out Int128 ni128); result = b ? ni128 : null; return b;

                case Type t when t == KozmosTypeHelper<BigInteger>._:
                    b = TryConvert(source, out BigInteger bi); result = bi; return b;
                case Type t when t == KozmosTypeHelper<BigInteger?>._:
                    b = TryConvert(source, out BigInteger nbi); result = b ? nbi : null; return b;

                case Type t when t == KozmosTypeHelper<Decimal>._:
                    b = TryConvert(source, out Decimal m); result = m; return b;
                case Type t when t == KozmosTypeHelper<Decimal?>._:
                    b = TryConvert(source, out Decimal nm); result = b ? nm : null; return b;

                case Type t when t == KozmosTypeHelper<Single>._:
                    b = TryConvert(source, out Single f); result = f; return b;
                case Type t when t == KozmosTypeHelper<Single?>._:
                    b = TryConvert(source, out Single nf); result = b ? nf : null; return b;

                case Type t when t == KozmosTypeHelper<Double>._:
                    b = TryConvert(source, out Double d); result = d; return b;
                case Type t when t == KozmosTypeHelper<Double?>._:
                    b = TryConvert(source, out Double nd); result = b ? nd : null; return b;
            }

            KozmosExceptionHelper.ThrowValue_0_OfArgument_1_2_IsNotSupported(resultType);
            result = default; return false;
        }

        [MethodImpl(MethodImplOptions.AggressiveOptimization)]
        public static Boolean TryConvert(JsonElement source, KozmosNumberIParsableConvertOptions options, Type resultType, out Object? result)
        {
            Boolean b;

            switch (resultType)
            {
                case Type t when t == KozmosTypeHelper<Byte>._:
                    b = TryConvert(source, options, out Byte by); result = by; return b;
                case Type t when t == KozmosTypeHelper<Byte?>._:
                    b = TryConvert(source, options, out Byte nby); result = b ? nby : null; return b;

                case Type t when t == KozmosTypeHelper<SByte>._:
                    b = TryConvert(source, options, out SByte sby); result = sby; return b;
                case Type t when t == KozmosTypeHelper<SByte?>._:
                    b = TryConvert(source, options, out SByte nsby); result = b ? nsby : null; return b;

                case Type t when t == KozmosTypeHelper<UInt16>._:
                    b = TryConvert(source, options, out UInt16 ui16); result = ui16; return b;
                case Type t when t == KozmosTypeHelper<UInt16?>._:
                    b = TryConvert(source, options, out UInt16 nui16); result = b ? nui16 : null; return b;

                case Type t when t == KozmosTypeHelper<Int16>._:
                    b = TryConvert(source, options, out Int16 i16); result = i16; return b;
                case Type t when t == KozmosTypeHelper<Int16?>._:
                    b = TryConvert(source, options, out Int16 ni16); result = b ? ni16 : null; return b;

                case Type t when t == KozmosTypeHelper<UInt32>._:
                    b = TryConvert(source, options, out UInt32 ui32); result = ui32; return b;
                case Type t when t == KozmosTypeHelper<UInt32?>._:
                    b = TryConvert(source, options, out UInt32 nui32); result = b ? nui32 : null; return b;

                case Type t when t == KozmosTypeHelper<Int32>._:
                    b = TryConvert(source, options, out Int32 i32); result = i32; return b;
                case Type t when t == KozmosTypeHelper<Int32?>._:
                    b = TryConvert(source, options, out Int32 ni32); result = b ? ni32 : null; return b;

                case Type t when t == KozmosTypeHelper<UInt64>._:
                    b = TryConvert(source, options, out UInt64 ui64); result = ui64; return b;
                case Type t when t == KozmosTypeHelper<UInt64?>._:
                    b = TryConvert(source, options, out UInt64 nui64); result = b ? nui64 : null; return b;

                case Type t when t == KozmosTypeHelper<Int64>._:
                    b = TryConvert(source, options, out Int64 i64); result = i64; return b;
                case Type t when t == KozmosTypeHelper<Int64?>._:
                    b = TryConvert(source, options, out Int64 ni64); result = b ? ni64 : null; return b;

                case Type t when t == KozmosTypeHelper<UInt128>._:
                    b = TryConvert(source, options, out UInt128 ui128); result = ui128; return b;
                case Type t when t == KozmosTypeHelper<UInt128?>._:
                    b = TryConvert(source, options, out UInt128 nui128); result = b ? nui128 : null; return b;

                case Type t when t == KozmosTypeHelper<Int128>._:
                    b = TryConvert(source, options, out Int128 i128); result = i128; return b;
                case Type t when t == KozmosTypeHelper<Int128?>._:
                    b = TryConvert(source, options, out Int128 ni128); result = b ? ni128 : null; return b;

                case Type t when t == KozmosTypeHelper<BigInteger>._:
                    b = TryConvert(source, options, out BigInteger bi); result = bi; return b;
                case Type t when t == KozmosTypeHelper<BigInteger?>._:
                    b = TryConvert(source, options, out BigInteger nbi); result = b ? nbi : null; return b;

                case Type t when t == KozmosTypeHelper<Decimal>._:
                    b = TryConvert(source, options, out Decimal m); result = m; return b;
                case Type t when t == KozmosTypeHelper<Decimal?>._:
                    b = TryConvert(source, options, out Decimal nm); result = b ? nm : null; return b;

                case Type t when t == KozmosTypeHelper<Single>._:
                    b = TryConvert(source, options, out Single f); result = f; return b;
                case Type t when t == KozmosTypeHelper<Single?>._:
                    b = TryConvert(source, options, out Single nf); result = b ? nf : null; return b;

                case Type t when t == KozmosTypeHelper<Double>._:
                    b = TryConvert(source, options, out Double d); result = d; return b;
                case Type t when t == KozmosTypeHelper<Double?>._:
                    b = TryConvert(source, options, out Double nd); result = b ? nd : null; return b;
            }

            KozmosExceptionHelper.ThrowValue_0_OfArgument_1_2_IsNotSupported(resultType);
            result = default; return false;
        }

        #endregion

        #region Numericals

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean TryConvert<TSource, TResult>(TSource? source, out TResult result)
           where TSource : struct, INumber<TSource>
           where TResult : struct, INumber<TResult>
        { return KozmosNumberHelper<TResult>.TryConvert(source, out result); }

        [MethodImpl(MethodImplOptions.AggressiveOptimization)]
        public static Boolean TryConvert<TSource>(TSource? source, Type resultType, out Object? result)
            where TSource : struct, INumber<TSource>
        {
            Boolean b;

            switch (resultType)
            {
                // HotPath >
                case Type t when t == KozmosTypeHelper<TSource>._:
                    b = TryConvert(source, out TSource result0); result = result0; return b;
                case Type t when t == KozmosTypeHelper<TSource?>._:
                    b = TryConvert(source, out TSource nresult0); result = b ? nresult0 : null; return b;
                // < HotPath

                case Type t when t == KozmosTypeHelper<Byte>._:
                    b = TryConvert(source, out Byte by); result = by; return b;
                case Type t when t == KozmosTypeHelper<Byte?>._:
                    b = TryConvert(source, out Byte nby); result = b ? nby : null; return b;

                case Type t when t == KozmosTypeHelper<SByte>._:
                    b = TryConvert(source, out SByte sby); result = sby; return b;
                case Type t when t == KozmosTypeHelper<SByte?>._:
                    b = TryConvert(source, out SByte nsby); result = b ? nsby : null; return b;

                case Type t when t == KozmosTypeHelper<UInt16>._:
                    b = TryConvert(source, out UInt16 ui16); result = ui16; return b;
                case Type t when t == KozmosTypeHelper<UInt16?>._:
                    b = TryConvert(source, out UInt16 nui16); result = b ? nui16 : null; return b;

                case Type t when t == KozmosTypeHelper<Int16>._:
                    b = TryConvert(source, out Int16 i16); result = i16; return b;
                case Type t when t == KozmosTypeHelper<Int16?>._:
                    b = TryConvert(source, out Int16 ni16); result = b ? ni16 : null; return b;

                case Type t when t == KozmosTypeHelper<UInt32>._:
                    b = TryConvert(source, out UInt32 ui32); result = ui32; return b;
                case Type t when t == KozmosTypeHelper<UInt32?>._:
                    b = TryConvert(source, out UInt32 nui32); result = b ? nui32 : null; return b;

                case Type t when t == KozmosTypeHelper<Int32>._:
                    b = TryConvert(source, out Int32 i32); result = i32; return b;
                case Type t when t == KozmosTypeHelper<Int32?>._:
                    b = TryConvert(source, out Int32 ni32); result = b ? ni32 : null; return b;

                case Type t when t == KozmosTypeHelper<UInt64>._:
                    b = TryConvert(source, out UInt64 ui64); result = ui64; return b;
                case Type t when t == KozmosTypeHelper<UInt64?>._:
                    b = TryConvert(source, out UInt64 nui64); result = b ? nui64 : null; return b;

                case Type t when t == KozmosTypeHelper<Int64>._:
                    b = TryConvert(source, out Int64 i64); result = i64; return b;
                case Type t when t == KozmosTypeHelper<Int64?>._:
                    b = TryConvert(source, out Int64 ni64); result = b ? ni64 : null; return b;

                case Type t when t == KozmosTypeHelper<UInt128>._:
                    b = TryConvert(source, out UInt128 ui128); result = ui128; return b;
                case Type t when t == KozmosTypeHelper<UInt128?>._:
                    b = TryConvert(source, out UInt128 nui128); result = b ? nui128 : null; return b;

                case Type t when t == KozmosTypeHelper<Int128>._:
                    b = TryConvert(source, out Int128 i128); result = i128; return b;
                case Type t when t == KozmosTypeHelper<Int128?>._:
                    b = TryConvert(source, out Int128 ni128); result = b ? ni128 : null; return b;

                case Type t when t == KozmosTypeHelper<BigInteger>._:
                    b = TryConvert(source, out BigInteger bi); result = bi; return b;
                case Type t when t == KozmosTypeHelper<BigInteger?>._:
                    b = TryConvert(source, out BigInteger nbi); result = b ? nbi : null; return b;

                case Type t when t == KozmosTypeHelper<Decimal>._:
                    b = TryConvert(source, out Decimal m); result = m; return b;
                case Type t when t == KozmosTypeHelper<Decimal?>._:
                    b = TryConvert(source, out Decimal nm); result = b ? nm : null; return b;

                case Type t when t == KozmosTypeHelper<Single>._:
                    b = TryConvert(source, out Single f); result = f; return b;
                case Type t when t == KozmosTypeHelper<Single?>._:
                    b = TryConvert(source, out Single nf); result = b ? nf : null; return b;

                case Type t when t == KozmosTypeHelper<Double>._:
                    b = TryConvert(source, out Double d); result = d; return b;
                case Type t when t == KozmosTypeHelper<Double?>._:
                    b = TryConvert(source, out Double nd); result = b ? nd : null; return b;
            }

            KozmosExceptionHelper.ThrowValue_0_OfArgument_1_2_IsNotSupported(resultType);
            result = default; return false;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean TryConvert<TSource, TResult>(TSource source, out TResult result)
           where TSource : struct, INumber<TSource>
           where TResult : struct, INumber<TResult>
        { return KozmosNumberHelper<TResult>.TryConvert(source, out result); }

        [MethodImpl(MethodImplOptions.AggressiveOptimization)]
        public static Boolean TryConvert<TSource>(TSource source, Type resultType, out Object? result)
            where TSource : struct, INumber<TSource>
        {
            Boolean b;

            switch (resultType)
            {
                // HotPath >
                case Type t when t == KozmosTypeHelper<TSource>._:
                    b = TryConvert(source, out TSource result0); result = result0; return b;
                case Type t when t == KozmosTypeHelper<TSource?>._:
                    b = TryConvert(source, out TSource nresult0); result = b ? nresult0 : null; return b;
                // < HotPath

                case Type t when t == KozmosTypeHelper<Byte>._:
                    b = TryConvert(source, out Byte by); result = by; return b;
                case Type t when t == KozmosTypeHelper<Byte?>._:
                    b = TryConvert(source, out Byte nby); result = b ? nby : null; return b;

                case Type t when t == KozmosTypeHelper<SByte>._:
                    b = TryConvert(source, out SByte sby); result = sby; return b;
                case Type t when t == KozmosTypeHelper<SByte?>._:
                    b = TryConvert(source, out SByte nsby); result = b ? nsby : null; return b;

                case Type t when t == KozmosTypeHelper<UInt16>._:
                    b = TryConvert(source, out UInt16 ui16); result = ui16; return b;
                case Type t when t == KozmosTypeHelper<UInt16?>._:
                    b = TryConvert(source, out UInt16 nui16); result = b ? nui16 : null; return b;

                case Type t when t == KozmosTypeHelper<Int16>._:
                    b = TryConvert(source, out Int16 i16); result = i16; return b;
                case Type t when t == KozmosTypeHelper<Int16?>._:
                    b = TryConvert(source, out Int16 ni16); result = b ? ni16 : null; return b;

                case Type t when t == KozmosTypeHelper<UInt32>._:
                    b = TryConvert(source, out UInt32 ui32); result = ui32; return b;
                case Type t when t == KozmosTypeHelper<UInt32?>._:
                    b = TryConvert(source, out UInt32 nui32); result = b ? nui32 : null; return b;

                case Type t when t == KozmosTypeHelper<Int32>._:
                    b = TryConvert(source, out Int32 i32); result = i32; return b;
                case Type t when t == KozmosTypeHelper<Int32?>._:
                    b = TryConvert(source, out Int32 ni32); result = b ? ni32 : null; return b;

                case Type t when t == KozmosTypeHelper<UInt64>._:
                    b = TryConvert(source, out UInt64 ui64); result = ui64; return b;
                case Type t when t == KozmosTypeHelper<UInt64?>._:
                    b = TryConvert(source, out UInt64 nui64); result = b ? nui64 : null; return b;

                case Type t when t == KozmosTypeHelper<Int64>._:
                    b = TryConvert(source, out Int64 i64); result = i64; return b;
                case Type t when t == KozmosTypeHelper<Int64?>._:
                    b = TryConvert(source, out Int64 ni64); result = b ? ni64 : null; return b;

                case Type t when t == KozmosTypeHelper<UInt128>._:
                    b = TryConvert(source, out UInt128 ui128); result = ui128; return b;
                case Type t when t == KozmosTypeHelper<UInt128?>._:
                    b = TryConvert(source, out UInt128 nui128); result = b ? nui128 : null; return b;

                case Type t when t == KozmosTypeHelper<Int128>._:
                    b = TryConvert(source, out Int128 i128); result = i128; return b;
                case Type t when t == KozmosTypeHelper<Int128?>._:
                    b = TryConvert(source, out Int128 ni128); result = b ? ni128 : null; return b;

                case Type t when t == KozmosTypeHelper<BigInteger>._:
                    b = TryConvert(source, out BigInteger bi); result = bi; return b;
                case Type t when t == KozmosTypeHelper<BigInteger?>._:
                    b = TryConvert(source, out BigInteger nbi); result = b ? nbi : null; return b;

                case Type t when t == KozmosTypeHelper<Decimal>._:
                    b = TryConvert(source, out Decimal m); result = m; return b;
                case Type t when t == KozmosTypeHelper<Decimal?>._:
                    b = TryConvert(source, out Decimal nm); result = b ? nm : null; return b;

                case Type t when t == KozmosTypeHelper<Single>._:
                    b = TryConvert(source, out Single f); result = f; return b;
                case Type t when t == KozmosTypeHelper<Single?>._:
                    b = TryConvert(source, out Single nf); result = b ? nf : null; return b;

                case Type t when t == KozmosTypeHelper<Double>._:
                    b = TryConvert(source, out Double d); result = d; return b;
                case Type t when t == KozmosTypeHelper<Double?>._:
                    b = TryConvert(source, out Double nd); result = b ? nd : null; return b;
            }

            KozmosExceptionHelper.ThrowValue_0_OfArgument_1_2_IsNotSupported(resultType);
            result = default; return false;
        }

        #endregion

        #region Temporals

        #region DateOnly

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean TryConvert<TResult>(DateOnly? source, out TResult result)
           where TResult : struct, INumber<TResult>
        { return KozmosNumberHelper<TResult>.TryConvert(source, out result); }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean TryConvert<TResult>(DateOnly? source, EKozmosDateOnlyComponent component, out TResult result)
           where TResult : struct, INumber<TResult>
        { return KozmosNumberHelper<TResult>.TryConvert(source, component, out result); }

        [MethodImpl(MethodImplOptions.AggressiveOptimization)]
        public static Boolean TryConvert(DateOnly? source, Type resultType, out Object? result)
        {
            Boolean b;

            switch (resultType)
            {
                case Type t when t == KozmosTypeHelper<Byte>._:
                    b = TryConvert(source, out Byte by); result = by; return b;
                case Type t when t == KozmosTypeHelper<Byte?>._:
                    b = TryConvert(source, out Byte nby); result = b ? nby : null; return b;

                case Type t when t == KozmosTypeHelper<SByte>._:
                    b = TryConvert(source, out SByte sby); result = sby; return b;
                case Type t when t == KozmosTypeHelper<SByte?>._:
                    b = TryConvert(source, out SByte nsby); result = b ? nsby : null; return b;

                case Type t when t == KozmosTypeHelper<UInt16>._:
                    b = TryConvert(source, out UInt16 ui16); result = ui16; return b;
                case Type t when t == KozmosTypeHelper<UInt16?>._:
                    b = TryConvert(source, out UInt16 nui16); result = b ? nui16 : null; return b;

                case Type t when t == KozmosTypeHelper<Int16>._:
                    b = TryConvert(source, out Int16 i16); result = i16; return b;
                case Type t when t == KozmosTypeHelper<Int16?>._:
                    b = TryConvert(source, out Int16 ni16); result = b ? ni16 : null; return b;

                case Type t when t == KozmosTypeHelper<UInt32>._:
                    b = TryConvert(source, out UInt32 ui32); result = ui32; return b;
                case Type t when t == KozmosTypeHelper<UInt32?>._:
                    b = TryConvert(source, out UInt32 nui32); result = b ? nui32 : null; return b;

                case Type t when t == KozmosTypeHelper<Int32>._:
                    b = TryConvert(source, out Int32 i32); result = i32; return b;
                case Type t when t == KozmosTypeHelper<Int32?>._:
                    b = TryConvert(source, out Int32 ni32); result = b ? ni32 : null; return b;

                case Type t when t == KozmosTypeHelper<UInt64>._:
                    b = TryConvert(source, out UInt64 ui64); result = ui64; return b;
                case Type t when t == KozmosTypeHelper<UInt64?>._:
                    b = TryConvert(source, out UInt64 nui64); result = b ? nui64 : null; return b;

                case Type t when t == KozmosTypeHelper<Int64>._:
                    b = TryConvert(source, out Int64 i64); result = i64; return b;
                case Type t when t == KozmosTypeHelper<Int64?>._:
                    b = TryConvert(source, out Int64 ni64); result = b ? ni64 : null; return b;

                case Type t when t == KozmosTypeHelper<UInt128>._:
                    b = TryConvert(source, out UInt128 ui128); result = ui128; return b;
                case Type t when t == KozmosTypeHelper<UInt128?>._:
                    b = TryConvert(source, out UInt128 nui128); result = b ? nui128 : null; return b;

                case Type t when t == KozmosTypeHelper<Int128>._:
                    b = TryConvert(source, out Int128 i128); result = i128; return b;
                case Type t when t == KozmosTypeHelper<Int128?>._:
                    b = TryConvert(source, out Int128 ni128); result = b ? ni128 : null; return b;

                case Type t when t == KozmosTypeHelper<BigInteger>._:
                    b = TryConvert(source, out BigInteger bi); result = bi; return b;
                case Type t when t == KozmosTypeHelper<BigInteger?>._:
                    b = TryConvert(source, out BigInteger nbi); result = b ? nbi : null; return b;

                case Type t when t == KozmosTypeHelper<Decimal>._:
                    b = TryConvert(source, out Decimal m); result = m; return b;
                case Type t when t == KozmosTypeHelper<Decimal?>._:
                    b = TryConvert(source, out Decimal nm); result = b ? nm : null; return b;

                case Type t when t == KozmosTypeHelper<Single>._:
                    b = TryConvert(source, out Single f); result = f; return b;
                case Type t when t == KozmosTypeHelper<Single?>._:
                    b = TryConvert(source, out Single nf); result = b ? nf : null; return b;

                case Type t when t == KozmosTypeHelper<Double>._:
                    b = TryConvert(source, out Double d); result = d; return b;
                case Type t when t == KozmosTypeHelper<Double?>._:
                    b = TryConvert(source, out Double nd); result = b ? nd : null; return b;
            }

            KozmosExceptionHelper.ThrowValue_0_OfArgument_1_2_IsNotSupported(resultType);
            result = default; return false;
        }

        [MethodImpl(MethodImplOptions.AggressiveOptimization)]
        public static Boolean TryConvert(DateOnly? source, EKozmosDateOnlyComponent component, Type resultType, out Object? result)
        {
            Boolean b;

            switch (resultType)
            {
                case Type t when t == KozmosTypeHelper<Byte>._:
                    b = TryConvert(source, component, out Byte by); result = by; return b;
                case Type t when t == KozmosTypeHelper<Byte?>._:
                    b = TryConvert(source, component, out Byte nby); result = b ? nby : null; return b;

                case Type t when t == KozmosTypeHelper<SByte>._:
                    b = TryConvert(source, component, out SByte sby); result = sby; return b;
                case Type t when t == KozmosTypeHelper<SByte?>._:
                    b = TryConvert(source, component, out SByte nsby); result = b ? nsby : null; return b;

                case Type t when t == KozmosTypeHelper<UInt16>._:
                    b = TryConvert(source, component, out UInt16 ui16); result = ui16; return b;
                case Type t when t == KozmosTypeHelper<UInt16?>._:
                    b = TryConvert(source, component, out UInt16 nui16); result = b ? nui16 : null; return b;

                case Type t when t == KozmosTypeHelper<Int16>._:
                    b = TryConvert(source, component, out Int16 i16); result = i16; return b;
                case Type t when t == KozmosTypeHelper<Int16?>._:
                    b = TryConvert(source, component, out Int16 ni16); result = b ? ni16 : null; return b;

                case Type t when t == KozmosTypeHelper<UInt32>._:
                    b = TryConvert(source, component, out UInt32 ui32); result = ui32; return b;
                case Type t when t == KozmosTypeHelper<UInt32?>._:
                    b = TryConvert(source, component, out UInt32 nui32); result = b ? nui32 : null; return b;

                case Type t when t == KozmosTypeHelper<Int32>._:
                    b = TryConvert(source, component, out Int32 i32); result = i32; return b;
                case Type t when t == KozmosTypeHelper<Int32?>._:
                    b = TryConvert(source, component, out Int32 ni32); result = b ? ni32 : null; return b;

                case Type t when t == KozmosTypeHelper<UInt64>._:
                    b = TryConvert(source, component, out UInt64 ui64); result = ui64; return b;
                case Type t when t == KozmosTypeHelper<UInt64?>._:
                    b = TryConvert(source, component, out UInt64 nui64); result = b ? nui64 : null; return b;

                case Type t when t == KozmosTypeHelper<Int64>._:
                    b = TryConvert(source, component, out Int64 i64); result = i64; return b;
                case Type t when t == KozmosTypeHelper<Int64?>._:
                    b = TryConvert(source, component, out Int64 ni64); result = b ? ni64 : null; return b;

                case Type t when t == KozmosTypeHelper<UInt128>._:
                    b = TryConvert(source, component, out UInt128 ui128); result = ui128; return b;
                case Type t when t == KozmosTypeHelper<UInt128?>._:
                    b = TryConvert(source, component, out UInt128 nui128); result = b ? nui128 : null; return b;

                case Type t when t == KozmosTypeHelper<Int128>._:
                    b = TryConvert(source, component, out Int128 i128); result = i128; return b;
                case Type t when t == KozmosTypeHelper<Int128?>._:
                    b = TryConvert(source, component, out Int128 ni128); result = b ? ni128 : null; return b;

                case Type t when t == KozmosTypeHelper<BigInteger>._:
                    b = TryConvert(source, component, out BigInteger bi); result = bi; return b;
                case Type t when t == KozmosTypeHelper<BigInteger?>._:
                    b = TryConvert(source, component, out BigInteger nbi); result = b ? nbi : null; return b;

                case Type t when t == KozmosTypeHelper<Decimal>._:
                    b = TryConvert(source, component, out Decimal m); result = m; return b;
                case Type t when t == KozmosTypeHelper<Decimal?>._:
                    b = TryConvert(source, component, out Decimal nm); result = b ? nm : null; return b;

                case Type t when t == KozmosTypeHelper<Single>._:
                    b = TryConvert(source, component, out Single f); result = f; return b;
                case Type t when t == KozmosTypeHelper<Single?>._:
                    b = TryConvert(source, component, out Single nf); result = b ? nf : null; return b;

                case Type t when t == KozmosTypeHelper<Double>._:
                    b = TryConvert(source, component, out Double d); result = d; return b;
                case Type t when t == KozmosTypeHelper<Double?>._:
                    b = TryConvert(source, component, out Double nd); result = b ? nd : null; return b;
            }

            KozmosExceptionHelper.ThrowValue_0_OfArgument_1_2_IsNotSupported(resultType);
            result = default; return false;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean TryConvert<TResult>(DateOnly source, out TResult result)
           where TResult : struct, INumber<TResult>
        { return KozmosNumberHelper<TResult>.TryConvert(source, out result); }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean TryConvert<TResult>(DateOnly source, EKozmosDateOnlyComponent component, out TResult result)
           where TResult : struct, INumber<TResult>
        { return KozmosNumberHelper<TResult>.TryConvert(source, component, out result); }

        [MethodImpl(MethodImplOptions.AggressiveOptimization)]
        public static Boolean TryConvert(DateOnly source, Type resultType, out Object? result)
        {
            Boolean b;

            switch (resultType)
            {
                case Type t when t == KozmosTypeHelper<Byte>._:
                    b = TryConvert(source, out Byte by); result = by; return b;
                case Type t when t == KozmosTypeHelper<Byte?>._:
                    b = TryConvert(source, out Byte nby); result = b ? nby : null; return b;

                case Type t when t == KozmosTypeHelper<SByte>._:
                    b = TryConvert(source, out SByte sby); result = sby; return b;
                case Type t when t == KozmosTypeHelper<SByte?>._:
                    b = TryConvert(source, out SByte nsby); result = b ? nsby : null; return b;

                case Type t when t == KozmosTypeHelper<UInt16>._:
                    b = TryConvert(source, out UInt16 ui16); result = ui16; return b;
                case Type t when t == KozmosTypeHelper<UInt16?>._:
                    b = TryConvert(source, out UInt16 nui16); result = b ? nui16 : null; return b;

                case Type t when t == KozmosTypeHelper<Int16>._:
                    b = TryConvert(source, out Int16 i16); result = i16; return b;
                case Type t when t == KozmosTypeHelper<Int16?>._:
                    b = TryConvert(source, out Int16 ni16); result = b ? ni16 : null; return b;

                case Type t when t == KozmosTypeHelper<UInt32>._:
                    b = TryConvert(source, out UInt32 ui32); result = ui32; return b;
                case Type t when t == KozmosTypeHelper<UInt32?>._:
                    b = TryConvert(source, out UInt32 nui32); result = b ? nui32 : null; return b;

                case Type t when t == KozmosTypeHelper<Int32>._:
                    b = TryConvert(source, out Int32 i32); result = i32; return b;
                case Type t when t == KozmosTypeHelper<Int32?>._:
                    b = TryConvert(source, out Int32 ni32); result = b ? ni32 : null; return b;

                case Type t when t == KozmosTypeHelper<UInt64>._:
                    b = TryConvert(source, out UInt64 ui64); result = ui64; return b;
                case Type t when t == KozmosTypeHelper<UInt64?>._:
                    b = TryConvert(source, out UInt64 nui64); result = b ? nui64 : null; return b;

                case Type t when t == KozmosTypeHelper<Int64>._:
                    b = TryConvert(source, out Int64 i64); result = i64; return b;
                case Type t when t == KozmosTypeHelper<Int64?>._:
                    b = TryConvert(source, out Int64 ni64); result = b ? ni64 : null; return b;

                case Type t when t == KozmosTypeHelper<UInt128>._:
                    b = TryConvert(source, out UInt128 ui128); result = ui128; return b;
                case Type t when t == KozmosTypeHelper<UInt128?>._:
                    b = TryConvert(source, out UInt128 nui128); result = b ? nui128 : null; return b;

                case Type t when t == KozmosTypeHelper<Int128>._:
                    b = TryConvert(source, out Int128 i128); result = i128; return b;
                case Type t when t == KozmosTypeHelper<Int128?>._:
                    b = TryConvert(source, out Int128 ni128); result = b ? ni128 : null; return b;

                case Type t when t == KozmosTypeHelper<BigInteger>._:
                    b = TryConvert(source, out BigInteger bi); result = bi; return b;
                case Type t when t == KozmosTypeHelper<BigInteger?>._:
                    b = TryConvert(source, out BigInteger nbi); result = b ? nbi : null; return b;

                case Type t when t == KozmosTypeHelper<Decimal>._:
                    b = TryConvert(source, out Decimal m); result = m; return b;
                case Type t when t == KozmosTypeHelper<Decimal?>._:
                    b = TryConvert(source, out Decimal nm); result = b ? nm : null; return b;

                case Type t when t == KozmosTypeHelper<Single>._:
                    b = TryConvert(source, out Single f); result = f; return b;
                case Type t when t == KozmosTypeHelper<Single?>._:
                    b = TryConvert(source, out Single nf); result = b ? nf : null; return b;

                case Type t when t == KozmosTypeHelper<Double>._:
                    b = TryConvert(source, out Double d); result = d; return b;
                case Type t when t == KozmosTypeHelper<Double?>._:
                    b = TryConvert(source, out Double nd); result = b ? nd : null; return b;
            }

            KozmosExceptionHelper.ThrowValue_0_OfArgument_1_2_IsNotSupported(resultType);
            result = default; return false;
        }

        [MethodImpl(MethodImplOptions.AggressiveOptimization)]
        public static Boolean TryConvert(DateOnly source, EKozmosDateOnlyComponent component, Type resultType, out Object? result)
        {
            Boolean b;

            switch (resultType)
            {
                case Type t when t == KozmosTypeHelper<Byte>._:
                    b = TryConvert(source, component, out Byte by); result = by; return b;
                case Type t when t == KozmosTypeHelper<Byte?>._:
                    b = TryConvert(source, component, out Byte nby); result = b ? nby : null; return b;

                case Type t when t == KozmosTypeHelper<SByte>._:
                    b = TryConvert(source, component, out SByte sby); result = sby; return b;
                case Type t when t == KozmosTypeHelper<SByte?>._:
                    b = TryConvert(source, component, out SByte nsby); result = b ? nsby : null; return b;

                case Type t when t == KozmosTypeHelper<UInt16>._:
                    b = TryConvert(source, component, out UInt16 ui16); result = ui16; return b;
                case Type t when t == KozmosTypeHelper<UInt16?>._:
                    b = TryConvert(source, component, out UInt16 nui16); result = b ? nui16 : null; return b;

                case Type t when t == KozmosTypeHelper<Int16>._:
                    b = TryConvert(source, component, out Int16 i16); result = i16; return b;
                case Type t when t == KozmosTypeHelper<Int16?>._:
                    b = TryConvert(source, component, out Int16 ni16); result = b ? ni16 : null; return b;

                case Type t when t == KozmosTypeHelper<UInt32>._:
                    b = TryConvert(source, component, out UInt32 ui32); result = ui32; return b;
                case Type t when t == KozmosTypeHelper<UInt32?>._:
                    b = TryConvert(source, component, out UInt32 nui32); result = b ? nui32 : null; return b;

                case Type t when t == KozmosTypeHelper<Int32>._:
                    b = TryConvert(source, component, out Int32 i32); result = i32; return b;
                case Type t when t == KozmosTypeHelper<Int32?>._:
                    b = TryConvert(source, component, out Int32 ni32); result = b ? ni32 : null; return b;

                case Type t when t == KozmosTypeHelper<UInt64>._:
                    b = TryConvert(source, component, out UInt64 ui64); result = ui64; return b;
                case Type t when t == KozmosTypeHelper<UInt64?>._:
                    b = TryConvert(source, component, out UInt64 nui64); result = b ? nui64 : null; return b;

                case Type t when t == KozmosTypeHelper<Int64>._:
                    b = TryConvert(source, component, out Int64 i64); result = i64; return b;
                case Type t when t == KozmosTypeHelper<Int64?>._:
                    b = TryConvert(source, component, out Int64 ni64); result = b ? ni64 : null; return b;

                case Type t when t == KozmosTypeHelper<UInt128>._:
                    b = TryConvert(source, component, out UInt128 ui128); result = ui128; return b;
                case Type t when t == KozmosTypeHelper<UInt128?>._:
                    b = TryConvert(source, component, out UInt128 nui128); result = b ? nui128 : null; return b;

                case Type t when t == KozmosTypeHelper<Int128>._:
                    b = TryConvert(source, component, out Int128 i128); result = i128; return b;
                case Type t when t == KozmosTypeHelper<Int128?>._:
                    b = TryConvert(source, component, out Int128 ni128); result = b ? ni128 : null; return b;

                case Type t when t == KozmosTypeHelper<BigInteger>._:
                    b = TryConvert(source, component, out BigInteger bi); result = bi; return b;
                case Type t when t == KozmosTypeHelper<BigInteger?>._:
                    b = TryConvert(source, component, out BigInteger nbi); result = b ? nbi : null; return b;

                case Type t when t == KozmosTypeHelper<Decimal>._:
                    b = TryConvert(source, component, out Decimal m); result = m; return b;
                case Type t when t == KozmosTypeHelper<Decimal?>._:
                    b = TryConvert(source, component, out Decimal nm); result = b ? nm : null; return b;

                case Type t when t == KozmosTypeHelper<Single>._:
                    b = TryConvert(source, component, out Single f); result = f; return b;
                case Type t when t == KozmosTypeHelper<Single?>._:
                    b = TryConvert(source, component, out Single nf); result = b ? nf : null; return b;

                case Type t when t == KozmosTypeHelper<Double>._:
                    b = TryConvert(source, component, out Double d); result = d; return b;
                case Type t when t == KozmosTypeHelper<Double?>._:
                    b = TryConvert(source, component, out Double nd); result = b ? nd : null; return b;
            }

            KozmosExceptionHelper.ThrowValue_0_OfArgument_1_2_IsNotSupported(resultType);
            result = default; return false;
        }

        #endregion

        #region DateTime

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean TryConvert<TResult>(DateTime? source, out TResult result)
           where TResult : struct, INumber<TResult>
        { return KozmosNumberHelper<TResult>.TryConvert(source, out result); }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean TryConvert<TResult>(DateTime? source, EKozmosDateTimeComponent component, out TResult result)
           where TResult : struct, INumber<TResult>
        { return KozmosNumberHelper<TResult>.TryConvert(source, component, out result); }

        [MethodImpl(MethodImplOptions.AggressiveOptimization)]
        public static Boolean TryConvert(DateTime? source, Type resultType, out Object? result)
        {
            Boolean b;

            switch (resultType)
            {
                case Type t when t == KozmosTypeHelper<Byte>._:
                    b = TryConvert(source, out Byte by); result = by; return b;
                case Type t when t == KozmosTypeHelper<Byte?>._:
                    b = TryConvert(source, out Byte nby); result = b ? nby : null; return b;

                case Type t when t == KozmosTypeHelper<SByte>._:
                    b = TryConvert(source, out SByte sby); result = sby; return b;
                case Type t when t == KozmosTypeHelper<SByte?>._:
                    b = TryConvert(source, out SByte nsby); result = b ? nsby : null; return b;

                case Type t when t == KozmosTypeHelper<UInt16>._:
                    b = TryConvert(source, out UInt16 ui16); result = ui16; return b;
                case Type t when t == KozmosTypeHelper<UInt16?>._:
                    b = TryConvert(source, out UInt16 nui16); result = b ? nui16 : null; return b;

                case Type t when t == KozmosTypeHelper<Int16>._:
                    b = TryConvert(source, out Int16 i16); result = i16; return b;
                case Type t when t == KozmosTypeHelper<Int16?>._:
                    b = TryConvert(source, out Int16 ni16); result = b ? ni16 : null; return b;

                case Type t when t == KozmosTypeHelper<UInt32>._:
                    b = TryConvert(source, out UInt32 ui32); result = ui32; return b;
                case Type t when t == KozmosTypeHelper<UInt32?>._:
                    b = TryConvert(source, out UInt32 nui32); result = b ? nui32 : null; return b;

                case Type t when t == KozmosTypeHelper<Int32>._:
                    b = TryConvert(source, out Int32 i32); result = i32; return b;
                case Type t when t == KozmosTypeHelper<Int32?>._:
                    b = TryConvert(source, out Int32 ni32); result = b ? ni32 : null; return b;

                case Type t when t == KozmosTypeHelper<UInt64>._:
                    b = TryConvert(source, out UInt64 ui64); result = ui64; return b;
                case Type t when t == KozmosTypeHelper<UInt64?>._:
                    b = TryConvert(source, out UInt64 nui64); result = b ? nui64 : null; return b;

                case Type t when t == KozmosTypeHelper<Int64>._:
                    b = TryConvert(source, out Int64 i64); result = i64; return b;
                case Type t when t == KozmosTypeHelper<Int64?>._:
                    b = TryConvert(source, out Int64 ni64); result = b ? ni64 : null; return b;

                case Type t when t == KozmosTypeHelper<UInt128>._:
                    b = TryConvert(source, out UInt128 ui128); result = ui128; return b;
                case Type t when t == KozmosTypeHelper<UInt128?>._:
                    b = TryConvert(source, out UInt128 nui128); result = b ? nui128 : null; return b;

                case Type t when t == KozmosTypeHelper<Int128>._:
                    b = TryConvert(source, out Int128 i128); result = i128; return b;
                case Type t when t == KozmosTypeHelper<Int128?>._:
                    b = TryConvert(source, out Int128 ni128); result = b ? ni128 : null; return b;

                case Type t when t == KozmosTypeHelper<BigInteger>._:
                    b = TryConvert(source, out BigInteger bi); result = bi; return b;
                case Type t when t == KozmosTypeHelper<BigInteger?>._:
                    b = TryConvert(source, out BigInteger nbi); result = b ? nbi : null; return b;

                case Type t when t == KozmosTypeHelper<Decimal>._:
                    b = TryConvert(source, out Decimal m); result = m; return b;
                case Type t when t == KozmosTypeHelper<Decimal?>._:
                    b = TryConvert(source, out Decimal nm); result = b ? nm : null; return b;

                case Type t when t == KozmosTypeHelper<Single>._:
                    b = TryConvert(source, out Single f); result = f; return b;
                case Type t when t == KozmosTypeHelper<Single?>._:
                    b = TryConvert(source, out Single nf); result = b ? nf : null; return b;

                case Type t when t == KozmosTypeHelper<Double>._:
                    b = TryConvert(source, out Double d); result = d; return b;
                case Type t when t == KozmosTypeHelper<Double?>._:
                    b = TryConvert(source, out Double nd); result = b ? nd : null; return b;
            }

            KozmosExceptionHelper.ThrowValue_0_OfArgument_1_2_IsNotSupported(resultType);
            result = default; return false;
        }

        [MethodImpl(MethodImplOptions.AggressiveOptimization)]
        public static Boolean TryConvert(DateTime? source, EKozmosDateTimeComponent component, Type resultType, out Object? result)
        {
            Boolean b;

            switch (resultType)
            {
                case Type t when t == KozmosTypeHelper<Byte>._:
                    b = TryConvert(source, component, out Byte by); result = by; return b;
                case Type t when t == KozmosTypeHelper<Byte?>._:
                    b = TryConvert(source, component, out Byte nby); result = b ? nby : null; return b;

                case Type t when t == KozmosTypeHelper<SByte>._:
                    b = TryConvert(source, component, out SByte sby); result = sby; return b;
                case Type t when t == KozmosTypeHelper<SByte?>._:
                    b = TryConvert(source, component, out SByte nsby); result = b ? nsby : null; return b;

                case Type t when t == KozmosTypeHelper<UInt16>._:
                    b = TryConvert(source, component, out UInt16 ui16); result = ui16; return b;
                case Type t when t == KozmosTypeHelper<UInt16?>._:
                    b = TryConvert(source, component, out UInt16 nui16); result = b ? nui16 : null; return b;

                case Type t when t == KozmosTypeHelper<Int16>._:
                    b = TryConvert(source, component, out Int16 i16); result = i16; return b;
                case Type t when t == KozmosTypeHelper<Int16?>._:
                    b = TryConvert(source, component, out Int16 ni16); result = b ? ni16 : null; return b;

                case Type t when t == KozmosTypeHelper<UInt32>._:
                    b = TryConvert(source, component, out UInt32 ui32); result = ui32; return b;
                case Type t when t == KozmosTypeHelper<UInt32?>._:
                    b = TryConvert(source, component, out UInt32 nui32); result = b ? nui32 : null; return b;

                case Type t when t == KozmosTypeHelper<Int32>._:
                    b = TryConvert(source, component, out Int32 i32); result = i32; return b;
                case Type t when t == KozmosTypeHelper<Int32?>._:
                    b = TryConvert(source, component, out Int32 ni32); result = b ? ni32 : null; return b;

                case Type t when t == KozmosTypeHelper<UInt64>._:
                    b = TryConvert(source, component, out UInt64 ui64); result = ui64; return b;
                case Type t when t == KozmosTypeHelper<UInt64?>._:
                    b = TryConvert(source, component, out UInt64 nui64); result = b ? nui64 : null; return b;

                case Type t when t == KozmosTypeHelper<Int64>._:
                    b = TryConvert(source, component, out Int64 i64); result = i64; return b;
                case Type t when t == KozmosTypeHelper<Int64?>._:
                    b = TryConvert(source, component, out Int64 ni64); result = b ? ni64 : null; return b;

                case Type t when t == KozmosTypeHelper<UInt128>._:
                    b = TryConvert(source, component, out UInt128 ui128); result = ui128; return b;
                case Type t when t == KozmosTypeHelper<UInt128?>._:
                    b = TryConvert(source, component, out UInt128 nui128); result = b ? nui128 : null; return b;

                case Type t when t == KozmosTypeHelper<Int128>._:
                    b = TryConvert(source, component, out Int128 i128); result = i128; return b;
                case Type t when t == KozmosTypeHelper<Int128?>._:
                    b = TryConvert(source, component, out Int128 ni128); result = b ? ni128 : null; return b;

                case Type t when t == KozmosTypeHelper<BigInteger>._:
                    b = TryConvert(source, component, out BigInteger bi); result = bi; return b;
                case Type t when t == KozmosTypeHelper<BigInteger?>._:
                    b = TryConvert(source, component, out BigInteger nbi); result = b ? nbi : null; return b;

                case Type t when t == KozmosTypeHelper<Decimal>._:
                    b = TryConvert(source, component, out Decimal m); result = m; return b;
                case Type t when t == KozmosTypeHelper<Decimal?>._:
                    b = TryConvert(source, component, out Decimal nm); result = b ? nm : null; return b;

                case Type t when t == KozmosTypeHelper<Single>._:
                    b = TryConvert(source, component, out Single f); result = f; return b;
                case Type t when t == KozmosTypeHelper<Single?>._:
                    b = TryConvert(source, component, out Single nf); result = b ? nf : null; return b;

                case Type t when t == KozmosTypeHelper<Double>._:
                    b = TryConvert(source, component, out Double d); result = d; return b;
                case Type t when t == KozmosTypeHelper<Double?>._:
                    b = TryConvert(source, component, out Double nd); result = b ? nd : null; return b;
            }

            KozmosExceptionHelper.ThrowValue_0_OfArgument_1_2_IsNotSupported(resultType);
            result = default; return false;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean TryConvert<TResult>(DateTime source, out TResult result)
           where TResult : struct, INumber<TResult>
        { return KozmosNumberHelper<TResult>.TryConvert(source, out result); }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean TryConvert<TResult>(DateTime source, EKozmosDateTimeComponent component, out TResult result)
           where TResult : struct, INumber<TResult>
        { return KozmosNumberHelper<TResult>.TryConvert(source, component, out result); }

        [MethodImpl(MethodImplOptions.AggressiveOptimization)]
        public static Boolean TryConvert(DateTime source, Type resultType, out Object? result)
        {
            Boolean b;

            switch (resultType)
            {
                case Type t when t == KozmosTypeHelper<Byte>._:
                    b = TryConvert(source, out Byte by); result = by; return b;
                case Type t when t == KozmosTypeHelper<Byte?>._:
                    b = TryConvert(source, out Byte nby); result = b ? nby : null; return b;

                case Type t when t == KozmosTypeHelper<SByte>._:
                    b = TryConvert(source, out SByte sby); result = sby; return b;
                case Type t when t == KozmosTypeHelper<SByte?>._:
                    b = TryConvert(source, out SByte nsby); result = b ? nsby : null; return b;

                case Type t when t == KozmosTypeHelper<UInt16>._:
                    b = TryConvert(source, out UInt16 ui16); result = ui16; return b;
                case Type t when t == KozmosTypeHelper<UInt16?>._:
                    b = TryConvert(source, out UInt16 nui16); result = b ? nui16 : null; return b;

                case Type t when t == KozmosTypeHelper<Int16>._:
                    b = TryConvert(source, out Int16 i16); result = i16; return b;
                case Type t when t == KozmosTypeHelper<Int16?>._:
                    b = TryConvert(source, out Int16 ni16); result = b ? ni16 : null; return b;

                case Type t when t == KozmosTypeHelper<UInt32>._:
                    b = TryConvert(source, out UInt32 ui32); result = ui32; return b;
                case Type t when t == KozmosTypeHelper<UInt32?>._:
                    b = TryConvert(source, out UInt32 nui32); result = b ? nui32 : null; return b;

                case Type t when t == KozmosTypeHelper<Int32>._:
                    b = TryConvert(source, out Int32 i32); result = i32; return b;
                case Type t when t == KozmosTypeHelper<Int32?>._:
                    b = TryConvert(source, out Int32 ni32); result = b ? ni32 : null; return b;

                case Type t when t == KozmosTypeHelper<UInt64>._:
                    b = TryConvert(source, out UInt64 ui64); result = ui64; return b;
                case Type t when t == KozmosTypeHelper<UInt64?>._:
                    b = TryConvert(source, out UInt64 nui64); result = b ? nui64 : null; return b;

                case Type t when t == KozmosTypeHelper<Int64>._:
                    b = TryConvert(source, out Int64 i64); result = i64; return b;
                case Type t when t == KozmosTypeHelper<Int64?>._:
                    b = TryConvert(source, out Int64 ni64); result = b ? ni64 : null; return b;

                case Type t when t == KozmosTypeHelper<UInt128>._:
                    b = TryConvert(source, out UInt128 ui128); result = ui128; return b;
                case Type t when t == KozmosTypeHelper<UInt128?>._:
                    b = TryConvert(source, out UInt128 nui128); result = b ? nui128 : null; return b;

                case Type t when t == KozmosTypeHelper<Int128>._:
                    b = TryConvert(source, out Int128 i128); result = i128; return b;
                case Type t when t == KozmosTypeHelper<Int128?>._:
                    b = TryConvert(source, out Int128 ni128); result = b ? ni128 : null; return b;

                case Type t when t == KozmosTypeHelper<BigInteger>._:
                    b = TryConvert(source, out BigInteger bi); result = bi; return b;
                case Type t when t == KozmosTypeHelper<BigInteger?>._:
                    b = TryConvert(source, out BigInteger nbi); result = b ? nbi : null; return b;

                case Type t when t == KozmosTypeHelper<Decimal>._:
                    b = TryConvert(source, out Decimal m); result = m; return b;
                case Type t when t == KozmosTypeHelper<Decimal?>._:
                    b = TryConvert(source, out Decimal nm); result = b ? nm : null; return b;

                case Type t when t == KozmosTypeHelper<Single>._:
                    b = TryConvert(source, out Single f); result = f; return b;
                case Type t when t == KozmosTypeHelper<Single?>._:
                    b = TryConvert(source, out Single nf); result = b ? nf : null; return b;

                case Type t when t == KozmosTypeHelper<Double>._:
                    b = TryConvert(source, out Double d); result = d; return b;
                case Type t when t == KozmosTypeHelper<Double?>._:
                    b = TryConvert(source, out Double nd); result = b ? nd : null; return b;
            }

            KozmosExceptionHelper.ThrowValue_0_OfArgument_1_2_IsNotSupported(resultType);
            result = default; return false;
        }

        [MethodImpl(MethodImplOptions.AggressiveOptimization)]
        public static Boolean TryConvert(DateTime source, EKozmosDateTimeComponent component, Type resultType, out Object? result)
        {
            Boolean b;

            switch (resultType)
            {
                case Type t when t == KozmosTypeHelper<Byte>._:
                    b = TryConvert(source, component, out Byte by); result = by; return b;
                case Type t when t == KozmosTypeHelper<Byte?>._:
                    b = TryConvert(source, component, out Byte nby); result = b ? nby : null; return b;

                case Type t when t == KozmosTypeHelper<SByte>._:
                    b = TryConvert(source, component, out SByte sby); result = sby; return b;
                case Type t when t == KozmosTypeHelper<SByte?>._:
                    b = TryConvert(source, component, out SByte nsby); result = b ? nsby : null; return b;

                case Type t when t == KozmosTypeHelper<UInt16>._:
                    b = TryConvert(source, component, out UInt16 ui16); result = ui16; return b;
                case Type t when t == KozmosTypeHelper<UInt16?>._:
                    b = TryConvert(source, component, out UInt16 nui16); result = b ? nui16 : null; return b;

                case Type t when t == KozmosTypeHelper<Int16>._:
                    b = TryConvert(source, component, out Int16 i16); result = i16; return b;
                case Type t when t == KozmosTypeHelper<Int16?>._:
                    b = TryConvert(source, component, out Int16 ni16); result = b ? ni16 : null; return b;

                case Type t when t == KozmosTypeHelper<UInt32>._:
                    b = TryConvert(source, component, out UInt32 ui32); result = ui32; return b;
                case Type t when t == KozmosTypeHelper<UInt32?>._:
                    b = TryConvert(source, component, out UInt32 nui32); result = b ? nui32 : null; return b;

                case Type t when t == KozmosTypeHelper<Int32>._:
                    b = TryConvert(source, component, out Int32 i32); result = i32; return b;
                case Type t when t == KozmosTypeHelper<Int32?>._:
                    b = TryConvert(source, component, out Int32 ni32); result = b ? ni32 : null; return b;

                case Type t when t == KozmosTypeHelper<UInt64>._:
                    b = TryConvert(source, component, out UInt64 ui64); result = ui64; return b;
                case Type t when t == KozmosTypeHelper<UInt64?>._:
                    b = TryConvert(source, component, out UInt64 nui64); result = b ? nui64 : null; return b;

                case Type t when t == KozmosTypeHelper<Int64>._:
                    b = TryConvert(source, component, out Int64 i64); result = i64; return b;
                case Type t when t == KozmosTypeHelper<Int64?>._:
                    b = TryConvert(source, component, out Int64 ni64); result = b ? ni64 : null; return b;

                case Type t when t == KozmosTypeHelper<UInt128>._:
                    b = TryConvert(source, component, out UInt128 ui128); result = ui128; return b;
                case Type t when t == KozmosTypeHelper<UInt128?>._:
                    b = TryConvert(source, component, out UInt128 nui128); result = b ? nui128 : null; return b;

                case Type t when t == KozmosTypeHelper<Int128>._:
                    b = TryConvert(source, component, out Int128 i128); result = i128; return b;
                case Type t when t == KozmosTypeHelper<Int128?>._:
                    b = TryConvert(source, component, out Int128 ni128); result = b ? ni128 : null; return b;

                case Type t when t == KozmosTypeHelper<BigInteger>._:
                    b = TryConvert(source, component, out BigInteger bi); result = bi; return b;
                case Type t when t == KozmosTypeHelper<BigInteger?>._:
                    b = TryConvert(source, component, out BigInteger nbi); result = b ? nbi : null; return b;

                case Type t when t == KozmosTypeHelper<Decimal>._:
                    b = TryConvert(source, component, out Decimal m); result = m; return b;
                case Type t when t == KozmosTypeHelper<Decimal?>._:
                    b = TryConvert(source, component, out Decimal nm); result = b ? nm : null; return b;

                case Type t when t == KozmosTypeHelper<Single>._:
                    b = TryConvert(source, component, out Single f); result = f; return b;
                case Type t when t == KozmosTypeHelper<Single?>._:
                    b = TryConvert(source, component, out Single nf); result = b ? nf : null; return b;

                case Type t when t == KozmosTypeHelper<Double>._:
                    b = TryConvert(source, component, out Double d); result = d; return b;
                case Type t when t == KozmosTypeHelper<Double?>._:
                    b = TryConvert(source, component, out Double nd); result = b ? nd : null; return b;
            }

            KozmosExceptionHelper.ThrowValue_0_OfArgument_1_2_IsNotSupported(resultType);
            result = default; return false;
        }

        #endregion

        #region DateTimeOffset

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean TryConvert<TResult>(DateTimeOffset? source, out TResult result)
           where TResult : struct, INumber<TResult>
        { return KozmosNumberHelper<TResult>.TryConvert(source, out result); }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean TryConvert<TResult>(DateTimeOffset? source, EKozmosDateTimeOffsetComponent component, out TResult result)
           where TResult : struct, INumber<TResult>
        { return KozmosNumberHelper<TResult>.TryConvert(source, component, out result); }

        [MethodImpl(MethodImplOptions.AggressiveOptimization)]
        public static Boolean TryConvert(DateTimeOffset? source, Type resultType, out Object? result)
        {
            Boolean b;

            switch (resultType)
            {
                case Type t when t == KozmosTypeHelper<Byte>._:
                    b = TryConvert(source, out Byte by); result = by; return b;
                case Type t when t == KozmosTypeHelper<Byte?>._:
                    b = TryConvert(source, out Byte nby); result = b ? nby : null; return b;

                case Type t when t == KozmosTypeHelper<SByte>._:
                    b = TryConvert(source, out SByte sby); result = sby; return b;
                case Type t when t == KozmosTypeHelper<SByte?>._:
                    b = TryConvert(source, out SByte nsby); result = b ? nsby : null; return b;

                case Type t when t == KozmosTypeHelper<UInt16>._:
                    b = TryConvert(source, out UInt16 ui16); result = ui16; return b;
                case Type t when t == KozmosTypeHelper<UInt16?>._:
                    b = TryConvert(source, out UInt16 nui16); result = b ? nui16 : null; return b;

                case Type t when t == KozmosTypeHelper<Int16>._:
                    b = TryConvert(source, out Int16 i16); result = i16; return b;
                case Type t when t == KozmosTypeHelper<Int16?>._:
                    b = TryConvert(source, out Int16 ni16); result = b ? ni16 : null; return b;

                case Type t when t == KozmosTypeHelper<UInt32>._:
                    b = TryConvert(source, out UInt32 ui32); result = ui32; return b;
                case Type t when t == KozmosTypeHelper<UInt32?>._:
                    b = TryConvert(source, out UInt32 nui32); result = b ? nui32 : null; return b;

                case Type t when t == KozmosTypeHelper<Int32>._:
                    b = TryConvert(source, out Int32 i32); result = i32; return b;
                case Type t when t == KozmosTypeHelper<Int32?>._:
                    b = TryConvert(source, out Int32 ni32); result = b ? ni32 : null; return b;

                case Type t when t == KozmosTypeHelper<UInt64>._:
                    b = TryConvert(source, out UInt64 ui64); result = ui64; return b;
                case Type t when t == KozmosTypeHelper<UInt64?>._:
                    b = TryConvert(source, out UInt64 nui64); result = b ? nui64 : null; return b;

                case Type t when t == KozmosTypeHelper<Int64>._:
                    b = TryConvert(source, out Int64 i64); result = i64; return b;
                case Type t when t == KozmosTypeHelper<Int64?>._:
                    b = TryConvert(source, out Int64 ni64); result = b ? ni64 : null; return b;

                case Type t when t == KozmosTypeHelper<UInt128>._:
                    b = TryConvert(source, out UInt128 ui128); result = ui128; return b;
                case Type t when t == KozmosTypeHelper<UInt128?>._:
                    b = TryConvert(source, out UInt128 nui128); result = b ? nui128 : null; return b;

                case Type t when t == KozmosTypeHelper<Int128>._:
                    b = TryConvert(source, out Int128 i128); result = i128; return b;
                case Type t when t == KozmosTypeHelper<Int128?>._:
                    b = TryConvert(source, out Int128 ni128); result = b ? ni128 : null; return b;

                case Type t when t == KozmosTypeHelper<BigInteger>._:
                    b = TryConvert(source, out BigInteger bi); result = bi; return b;
                case Type t when t == KozmosTypeHelper<BigInteger?>._:
                    b = TryConvert(source, out BigInteger nbi); result = b ? nbi : null; return b;

                case Type t when t == KozmosTypeHelper<Decimal>._:
                    b = TryConvert(source, out Decimal m); result = m; return b;
                case Type t when t == KozmosTypeHelper<Decimal?>._:
                    b = TryConvert(source, out Decimal nm); result = b ? nm : null; return b;

                case Type t when t == KozmosTypeHelper<Single>._:
                    b = TryConvert(source, out Single f); result = f; return b;
                case Type t when t == KozmosTypeHelper<Single?>._:
                    b = TryConvert(source, out Single nf); result = b ? nf : null; return b;

                case Type t when t == KozmosTypeHelper<Double>._:
                    b = TryConvert(source, out Double d); result = d; return b;
                case Type t when t == KozmosTypeHelper<Double?>._:
                    b = TryConvert(source, out Double nd); result = b ? nd : null; return b;
            }

            KozmosExceptionHelper.ThrowValue_0_OfArgument_1_2_IsNotSupported(resultType);
            result = default; return false;
        }

        [MethodImpl(MethodImplOptions.AggressiveOptimization)]
        public static Boolean TryConvert(DateTimeOffset? source, EKozmosDateTimeOffsetComponent component, Type resultType, out Object? result)
        {
            Boolean b;

            switch (resultType)
            {
                case Type t when t == KozmosTypeHelper<Byte>._:
                    b = TryConvert(source, component, out Byte by); result = by; return b;
                case Type t when t == KozmosTypeHelper<Byte?>._:
                    b = TryConvert(source, component, out Byte nby); result = b ? nby : null; return b;

                case Type t when t == KozmosTypeHelper<SByte>._:
                    b = TryConvert(source, component, out SByte sby); result = sby; return b;
                case Type t when t == KozmosTypeHelper<SByte?>._:
                    b = TryConvert(source, component, out SByte nsby); result = b ? nsby : null; return b;

                case Type t when t == KozmosTypeHelper<UInt16>._:
                    b = TryConvert(source, component, out UInt16 ui16); result = ui16; return b;
                case Type t when t == KozmosTypeHelper<UInt16?>._:
                    b = TryConvert(source, component, out UInt16 nui16); result = b ? nui16 : null; return b;

                case Type t when t == KozmosTypeHelper<Int16>._:
                    b = TryConvert(source, component, out Int16 i16); result = i16; return b;
                case Type t when t == KozmosTypeHelper<Int16?>._:
                    b = TryConvert(source, component, out Int16 ni16); result = b ? ni16 : null; return b;

                case Type t when t == KozmosTypeHelper<UInt32>._:
                    b = TryConvert(source, component, out UInt32 ui32); result = ui32; return b;
                case Type t when t == KozmosTypeHelper<UInt32?>._:
                    b = TryConvert(source, component, out UInt32 nui32); result = b ? nui32 : null; return b;

                case Type t when t == KozmosTypeHelper<Int32>._:
                    b = TryConvert(source, component, out Int32 i32); result = i32; return b;
                case Type t when t == KozmosTypeHelper<Int32?>._:
                    b = TryConvert(source, component, out Int32 ni32); result = b ? ni32 : null; return b;

                case Type t when t == KozmosTypeHelper<UInt64>._:
                    b = TryConvert(source, component, out UInt64 ui64); result = ui64; return b;
                case Type t when t == KozmosTypeHelper<UInt64?>._:
                    b = TryConvert(source, component, out UInt64 nui64); result = b ? nui64 : null; return b;

                case Type t when t == KozmosTypeHelper<Int64>._:
                    b = TryConvert(source, component, out Int64 i64); result = i64; return b;
                case Type t when t == KozmosTypeHelper<Int64?>._:
                    b = TryConvert(source, component, out Int64 ni64); result = b ? ni64 : null; return b;

                case Type t when t == KozmosTypeHelper<UInt128>._:
                    b = TryConvert(source, component, out UInt128 ui128); result = ui128; return b;
                case Type t when t == KozmosTypeHelper<UInt128?>._:
                    b = TryConvert(source, component, out UInt128 nui128); result = b ? nui128 : null; return b;

                case Type t when t == KozmosTypeHelper<Int128>._:
                    b = TryConvert(source, component, out Int128 i128); result = i128; return b;
                case Type t when t == KozmosTypeHelper<Int128?>._:
                    b = TryConvert(source, component, out Int128 ni128); result = b ? ni128 : null; return b;

                case Type t when t == KozmosTypeHelper<BigInteger>._:
                    b = TryConvert(source, component, out BigInteger bi); result = bi; return b;
                case Type t when t == KozmosTypeHelper<BigInteger?>._:
                    b = TryConvert(source, component, out BigInteger nbi); result = b ? nbi : null; return b;

                case Type t when t == KozmosTypeHelper<Decimal>._:
                    b = TryConvert(source, component, out Decimal m); result = m; return b;
                case Type t when t == KozmosTypeHelper<Decimal?>._:
                    b = TryConvert(source, component, out Decimal nm); result = b ? nm : null; return b;

                case Type t when t == KozmosTypeHelper<Single>._:
                    b = TryConvert(source, component, out Single f); result = f; return b;
                case Type t when t == KozmosTypeHelper<Single?>._:
                    b = TryConvert(source, component, out Single nf); result = b ? nf : null; return b;

                case Type t when t == KozmosTypeHelper<Double>._:
                    b = TryConvert(source, component, out Double d); result = d; return b;
                case Type t when t == KozmosTypeHelper<Double?>._:
                    b = TryConvert(source, component, out Double nd); result = b ? nd : null; return b;
            }

            KozmosExceptionHelper.ThrowValue_0_OfArgument_1_2_IsNotSupported(resultType);
            result = default; return false;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean TryConvert<TResult>(DateTimeOffset source, out TResult result)
           where TResult : struct, INumber<TResult>
        { return KozmosNumberHelper<TResult>.TryConvert(source, out result); }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean TryConvert<TResult>(DateTimeOffset source, EKozmosDateTimeOffsetComponent component, out TResult result)
           where TResult : struct, INumber<TResult>
        { return KozmosNumberHelper<TResult>.TryConvert(source, component, out result); }

        [MethodImpl(MethodImplOptions.AggressiveOptimization)]
        public static Boolean TryConvert(DateTimeOffset source, Type resultType, out Object? result)
        {
            Boolean b;

            switch (resultType)
            {
                case Type t when t == KozmosTypeHelper<Byte>._:
                    b = TryConvert(source, out Byte by); result = by; return b;
                case Type t when t == KozmosTypeHelper<Byte?>._:
                    b = TryConvert(source, out Byte nby); result = b ? nby : null; return b;

                case Type t when t == KozmosTypeHelper<SByte>._:
                    b = TryConvert(source, out SByte sby); result = sby; return b;
                case Type t when t == KozmosTypeHelper<SByte?>._:
                    b = TryConvert(source, out SByte nsby); result = b ? nsby : null; return b;

                case Type t when t == KozmosTypeHelper<UInt16>._:
                    b = TryConvert(source, out UInt16 ui16); result = ui16; return b;
                case Type t when t == KozmosTypeHelper<UInt16?>._:
                    b = TryConvert(source, out UInt16 nui16); result = b ? nui16 : null; return b;

                case Type t when t == KozmosTypeHelper<Int16>._:
                    b = TryConvert(source, out Int16 i16); result = i16; return b;
                case Type t when t == KozmosTypeHelper<Int16?>._:
                    b = TryConvert(source, out Int16 ni16); result = b ? ni16 : null; return b;

                case Type t when t == KozmosTypeHelper<UInt32>._:
                    b = TryConvert(source, out UInt32 ui32); result = ui32; return b;
                case Type t when t == KozmosTypeHelper<UInt32?>._:
                    b = TryConvert(source, out UInt32 nui32); result = b ? nui32 : null; return b;

                case Type t when t == KozmosTypeHelper<Int32>._:
                    b = TryConvert(source, out Int32 i32); result = i32; return b;
                case Type t when t == KozmosTypeHelper<Int32?>._:
                    b = TryConvert(source, out Int32 ni32); result = b ? ni32 : null; return b;

                case Type t when t == KozmosTypeHelper<UInt64>._:
                    b = TryConvert(source, out UInt64 ui64); result = ui64; return b;
                case Type t when t == KozmosTypeHelper<UInt64?>._:
                    b = TryConvert(source, out UInt64 nui64); result = b ? nui64 : null; return b;

                case Type t when t == KozmosTypeHelper<Int64>._:
                    b = TryConvert(source, out Int64 i64); result = i64; return b;
                case Type t when t == KozmosTypeHelper<Int64?>._:
                    b = TryConvert(source, out Int64 ni64); result = b ? ni64 : null; return b;

                case Type t when t == KozmosTypeHelper<UInt128>._:
                    b = TryConvert(source, out UInt128 ui128); result = ui128; return b;
                case Type t when t == KozmosTypeHelper<UInt128?>._:
                    b = TryConvert(source, out UInt128 nui128); result = b ? nui128 : null; return b;

                case Type t when t == KozmosTypeHelper<Int128>._:
                    b = TryConvert(source, out Int128 i128); result = i128; return b;
                case Type t when t == KozmosTypeHelper<Int128?>._:
                    b = TryConvert(source, out Int128 ni128); result = b ? ni128 : null; return b;

                case Type t when t == KozmosTypeHelper<BigInteger>._:
                    b = TryConvert(source, out BigInteger bi); result = bi; return b;
                case Type t when t == KozmosTypeHelper<BigInteger?>._:
                    b = TryConvert(source, out BigInteger nbi); result = b ? nbi : null; return b;

                case Type t when t == KozmosTypeHelper<Decimal>._:
                    b = TryConvert(source, out Decimal m); result = m; return b;
                case Type t when t == KozmosTypeHelper<Decimal?>._:
                    b = TryConvert(source, out Decimal nm); result = b ? nm : null; return b;

                case Type t when t == KozmosTypeHelper<Single>._:
                    b = TryConvert(source, out Single f); result = f; return b;
                case Type t when t == KozmosTypeHelper<Single?>._:
                    b = TryConvert(source, out Single nf); result = b ? nf : null; return b;

                case Type t when t == KozmosTypeHelper<Double>._:
                    b = TryConvert(source, out Double d); result = d; return b;
                case Type t when t == KozmosTypeHelper<Double?>._:
                    b = TryConvert(source, out Double nd); result = b ? nd : null; return b;
            }

            KozmosExceptionHelper.ThrowValue_0_OfArgument_1_2_IsNotSupported(resultType);
            result = default; return false;
        }

        [MethodImpl(MethodImplOptions.AggressiveOptimization)]
        public static Boolean TryConvert(DateTimeOffset source, EKozmosDateTimeOffsetComponent component, Type resultType, out Object? result)
        {
            Boolean b;

            switch (resultType)
            {
                case Type t when t == KozmosTypeHelper<Byte>._:
                    b = TryConvert(source, component, out Byte by); result = by; return b;
                case Type t when t == KozmosTypeHelper<Byte?>._:
                    b = TryConvert(source, component, out Byte nby); result = b ? nby : null; return b;

                case Type t when t == KozmosTypeHelper<SByte>._:
                    b = TryConvert(source, component, out SByte sby); result = sby; return b;
                case Type t when t == KozmosTypeHelper<SByte?>._:
                    b = TryConvert(source, component, out SByte nsby); result = b ? nsby : null; return b;

                case Type t when t == KozmosTypeHelper<UInt16>._:
                    b = TryConvert(source, component, out UInt16 ui16); result = ui16; return b;
                case Type t when t == KozmosTypeHelper<UInt16?>._:
                    b = TryConvert(source, component, out UInt16 nui16); result = b ? nui16 : null; return b;

                case Type t when t == KozmosTypeHelper<Int16>._:
                    b = TryConvert(source, component, out Int16 i16); result = i16; return b;
                case Type t when t == KozmosTypeHelper<Int16?>._:
                    b = TryConvert(source, component, out Int16 ni16); result = b ? ni16 : null; return b;

                case Type t when t == KozmosTypeHelper<UInt32>._:
                    b = TryConvert(source, component, out UInt32 ui32); result = ui32; return b;
                case Type t when t == KozmosTypeHelper<UInt32?>._:
                    b = TryConvert(source, component, out UInt32 nui32); result = b ? nui32 : null; return b;

                case Type t when t == KozmosTypeHelper<Int32>._:
                    b = TryConvert(source, component, out Int32 i32); result = i32; return b;
                case Type t when t == KozmosTypeHelper<Int32?>._:
                    b = TryConvert(source, component, out Int32 ni32); result = b ? ni32 : null; return b;

                case Type t when t == KozmosTypeHelper<UInt64>._:
                    b = TryConvert(source, component, out UInt64 ui64); result = ui64; return b;
                case Type t when t == KozmosTypeHelper<UInt64?>._:
                    b = TryConvert(source, component, out UInt64 nui64); result = b ? nui64 : null; return b;

                case Type t when t == KozmosTypeHelper<Int64>._:
                    b = TryConvert(source, component, out Int64 i64); result = i64; return b;
                case Type t when t == KozmosTypeHelper<Int64?>._:
                    b = TryConvert(source, component, out Int64 ni64); result = b ? ni64 : null; return b;

                case Type t when t == KozmosTypeHelper<UInt128>._:
                    b = TryConvert(source, component, out UInt128 ui128); result = ui128; return b;
                case Type t when t == KozmosTypeHelper<UInt128?>._:
                    b = TryConvert(source, component, out UInt128 nui128); result = b ? nui128 : null; return b;

                case Type t when t == KozmosTypeHelper<Int128>._:
                    b = TryConvert(source, component, out Int128 i128); result = i128; return b;
                case Type t when t == KozmosTypeHelper<Int128?>._:
                    b = TryConvert(source, component, out Int128 ni128); result = b ? ni128 : null; return b;

                case Type t when t == KozmosTypeHelper<BigInteger>._:
                    b = TryConvert(source, component, out BigInteger bi); result = bi; return b;
                case Type t when t == KozmosTypeHelper<BigInteger?>._:
                    b = TryConvert(source, component, out BigInteger nbi); result = b ? nbi : null; return b;

                case Type t when t == KozmosTypeHelper<Decimal>._:
                    b = TryConvert(source, component, out Decimal m); result = m; return b;
                case Type t when t == KozmosTypeHelper<Decimal?>._:
                    b = TryConvert(source, component, out Decimal nm); result = b ? nm : null; return b;

                case Type t when t == KozmosTypeHelper<Single>._:
                    b = TryConvert(source, component, out Single f); result = f; return b;
                case Type t when t == KozmosTypeHelper<Single?>._:
                    b = TryConvert(source, component, out Single nf); result = b ? nf : null; return b;

                case Type t when t == KozmosTypeHelper<Double>._:
                    b = TryConvert(source, component, out Double d); result = d; return b;
                case Type t when t == KozmosTypeHelper<Double?>._:
                    b = TryConvert(source, component, out Double nd); result = b ? nd : null; return b;
            }

            KozmosExceptionHelper.ThrowValue_0_OfArgument_1_2_IsNotSupported(resultType);
            result = default; return false;
        }

        #endregion

        #region TimeOnly

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean TryConvert<TResult>(TimeOnly? source, out TResult result)
           where TResult : struct, INumber<TResult>
        { return KozmosNumberHelper<TResult>.TryConvert(source, out result); }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean TryConvert<TResult>(TimeOnly? source, EKozmosTimeOnlyComponent component, out TResult result)
           where TResult : struct, INumber<TResult>
        { return KozmosNumberHelper<TResult>.TryConvert(source, component, out result); }

        [MethodImpl(MethodImplOptions.AggressiveOptimization)]
        public static Boolean TryConvert(TimeOnly? source, Type resultType, out Object? result)
        {
            Boolean b;

            switch (resultType)
            {
                case Type t when t == KozmosTypeHelper<Byte>._:
                    b = TryConvert(source, out Byte by); result = by; return b;
                case Type t when t == KozmosTypeHelper<Byte?>._:
                    b = TryConvert(source, out Byte nby); result = b ? nby : null; return b;

                case Type t when t == KozmosTypeHelper<SByte>._:
                    b = TryConvert(source, out SByte sby); result = sby; return b;
                case Type t when t == KozmosTypeHelper<SByte?>._:
                    b = TryConvert(source, out SByte nsby); result = b ? nsby : null; return b;

                case Type t when t == KozmosTypeHelper<UInt16>._:
                    b = TryConvert(source, out UInt16 ui16); result = ui16; return b;
                case Type t when t == KozmosTypeHelper<UInt16?>._:
                    b = TryConvert(source, out UInt16 nui16); result = b ? nui16 : null; return b;

                case Type t when t == KozmosTypeHelper<Int16>._:
                    b = TryConvert(source, out Int16 i16); result = i16; return b;
                case Type t when t == KozmosTypeHelper<Int16?>._:
                    b = TryConvert(source, out Int16 ni16); result = b ? ni16 : null; return b;

                case Type t when t == KozmosTypeHelper<UInt32>._:
                    b = TryConvert(source, out UInt32 ui32); result = ui32; return b;
                case Type t when t == KozmosTypeHelper<UInt32?>._:
                    b = TryConvert(source, out UInt32 nui32); result = b ? nui32 : null; return b;

                case Type t when t == KozmosTypeHelper<Int32>._:
                    b = TryConvert(source, out Int32 i32); result = i32; return b;
                case Type t when t == KozmosTypeHelper<Int32?>._:
                    b = TryConvert(source, out Int32 ni32); result = b ? ni32 : null; return b;

                case Type t when t == KozmosTypeHelper<UInt64>._:
                    b = TryConvert(source, out UInt64 ui64); result = ui64; return b;
                case Type t when t == KozmosTypeHelper<UInt64?>._:
                    b = TryConvert(source, out UInt64 nui64); result = b ? nui64 : null; return b;

                case Type t when t == KozmosTypeHelper<Int64>._:
                    b = TryConvert(source, out Int64 i64); result = i64; return b;
                case Type t when t == KozmosTypeHelper<Int64?>._:
                    b = TryConvert(source, out Int64 ni64); result = b ? ni64 : null; return b;

                case Type t when t == KozmosTypeHelper<UInt128>._:
                    b = TryConvert(source, out UInt128 ui128); result = ui128; return b;
                case Type t when t == KozmosTypeHelper<UInt128?>._:
                    b = TryConvert(source, out UInt128 nui128); result = b ? nui128 : null; return b;

                case Type t when t == KozmosTypeHelper<Int128>._:
                    b = TryConvert(source, out Int128 i128); result = i128; return b;
                case Type t when t == KozmosTypeHelper<Int128?>._:
                    b = TryConvert(source, out Int128 ni128); result = b ? ni128 : null; return b;

                case Type t when t == KozmosTypeHelper<BigInteger>._:
                    b = TryConvert(source, out BigInteger bi); result = bi; return b;
                case Type t when t == KozmosTypeHelper<BigInteger?>._:
                    b = TryConvert(source, out BigInteger nbi); result = b ? nbi : null; return b;

                case Type t when t == KozmosTypeHelper<Decimal>._:
                    b = TryConvert(source, out Decimal m); result = m; return b;
                case Type t when t == KozmosTypeHelper<Decimal?>._:
                    b = TryConvert(source, out Decimal nm); result = b ? nm : null; return b;

                case Type t when t == KozmosTypeHelper<Single>._:
                    b = TryConvert(source, out Single f); result = f; return b;
                case Type t when t == KozmosTypeHelper<Single?>._:
                    b = TryConvert(source, out Single nf); result = b ? nf : null; return b;

                case Type t when t == KozmosTypeHelper<Double>._:
                    b = TryConvert(source, out Double d); result = d; return b;
                case Type t when t == KozmosTypeHelper<Double?>._:
                    b = TryConvert(source, out Double nd); result = b ? nd : null; return b;
            }

            KozmosExceptionHelper.ThrowValue_0_OfArgument_1_2_IsNotSupported(resultType);
            result = default; return false;
        }

        [MethodImpl(MethodImplOptions.AggressiveOptimization)]
        public static Boolean TryConvert(TimeOnly? source, EKozmosTimeOnlyComponent component, Type resultType, out Object? result)
        {
            Boolean b;

            switch (resultType)
            {
                case Type t when t == KozmosTypeHelper<Byte>._:
                    b = TryConvert(source, component, out Byte by); result = by; return b;
                case Type t when t == KozmosTypeHelper<Byte?>._:
                    b = TryConvert(source, component, out Byte nby); result = b ? nby : null; return b;

                case Type t when t == KozmosTypeHelper<SByte>._:
                    b = TryConvert(source, component, out SByte sby); result = sby; return b;
                case Type t when t == KozmosTypeHelper<SByte?>._:
                    b = TryConvert(source, component, out SByte nsby); result = b ? nsby : null; return b;

                case Type t when t == KozmosTypeHelper<UInt16>._:
                    b = TryConvert(source, component, out UInt16 ui16); result = ui16; return b;
                case Type t when t == KozmosTypeHelper<UInt16?>._:
                    b = TryConvert(source, component, out UInt16 nui16); result = b ? nui16 : null; return b;

                case Type t when t == KozmosTypeHelper<Int16>._:
                    b = TryConvert(source, component, out Int16 i16); result = i16; return b;
                case Type t when t == KozmosTypeHelper<Int16?>._:
                    b = TryConvert(source, component, out Int16 ni16); result = b ? ni16 : null; return b;

                case Type t when t == KozmosTypeHelper<UInt32>._:
                    b = TryConvert(source, component, out UInt32 ui32); result = ui32; return b;
                case Type t when t == KozmosTypeHelper<UInt32?>._:
                    b = TryConvert(source, component, out UInt32 nui32); result = b ? nui32 : null; return b;

                case Type t when t == KozmosTypeHelper<Int32>._:
                    b = TryConvert(source, component, out Int32 i32); result = i32; return b;
                case Type t when t == KozmosTypeHelper<Int32?>._:
                    b = TryConvert(source, component, out Int32 ni32); result = b ? ni32 : null; return b;

                case Type t when t == KozmosTypeHelper<UInt64>._:
                    b = TryConvert(source, component, out UInt64 ui64); result = ui64; return b;
                case Type t when t == KozmosTypeHelper<UInt64?>._:
                    b = TryConvert(source, component, out UInt64 nui64); result = b ? nui64 : null; return b;

                case Type t when t == KozmosTypeHelper<Int64>._:
                    b = TryConvert(source, component, out Int64 i64); result = i64; return b;
                case Type t when t == KozmosTypeHelper<Int64?>._:
                    b = TryConvert(source, component, out Int64 ni64); result = b ? ni64 : null; return b;

                case Type t when t == KozmosTypeHelper<UInt128>._:
                    b = TryConvert(source, component, out UInt128 ui128); result = ui128; return b;
                case Type t when t == KozmosTypeHelper<UInt128?>._:
                    b = TryConvert(source, component, out UInt128 nui128); result = b ? nui128 : null; return b;

                case Type t when t == KozmosTypeHelper<Int128>._:
                    b = TryConvert(source, component, out Int128 i128); result = i128; return b;
                case Type t when t == KozmosTypeHelper<Int128?>._:
                    b = TryConvert(source, component, out Int128 ni128); result = b ? ni128 : null; return b;

                case Type t when t == KozmosTypeHelper<BigInteger>._:
                    b = TryConvert(source, component, out BigInteger bi); result = bi; return b;
                case Type t when t == KozmosTypeHelper<BigInteger?>._:
                    b = TryConvert(source, component, out BigInteger nbi); result = b ? nbi : null; return b;

                case Type t when t == KozmosTypeHelper<Decimal>._:
                    b = TryConvert(source, component, out Decimal m); result = m; return b;
                case Type t when t == KozmosTypeHelper<Decimal?>._:
                    b = TryConvert(source, component, out Decimal nm); result = b ? nm : null; return b;

                case Type t when t == KozmosTypeHelper<Single>._:
                    b = TryConvert(source, component, out Single f); result = f; return b;
                case Type t when t == KozmosTypeHelper<Single?>._:
                    b = TryConvert(source, component, out Single nf); result = b ? nf : null; return b;

                case Type t when t == KozmosTypeHelper<Double>._:
                    b = TryConvert(source, component, out Double d); result = d; return b;
                case Type t when t == KozmosTypeHelper<Double?>._:
                    b = TryConvert(source, component, out Double nd); result = b ? nd : null; return b;
            }

            KozmosExceptionHelper.ThrowValue_0_OfArgument_1_2_IsNotSupported(resultType);
            result = default; return false;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean TryConvert<TResult>(TimeOnly source, out TResult result)
           where TResult : struct, INumber<TResult>
        { return KozmosNumberHelper<TResult>.TryConvert(source, out result); }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean TryConvert<TResult>(TimeOnly source, EKozmosTimeOnlyComponent component, out TResult result)
           where TResult : struct, INumber<TResult>
        { return KozmosNumberHelper<TResult>.TryConvert(source, component, out result); }

        [MethodImpl(MethodImplOptions.AggressiveOptimization)]
        public static Boolean TryConvert(TimeOnly source, Type resultType, out Object? result)
        {
            Boolean b;

            switch (resultType)
            {
                case Type t when t == KozmosTypeHelper<Byte>._:
                    b = TryConvert(source, out Byte by); result = by; return b;
                case Type t when t == KozmosTypeHelper<Byte?>._:
                    b = TryConvert(source, out Byte nby); result = b ? nby : null; return b;

                case Type t when t == KozmosTypeHelper<SByte>._:
                    b = TryConvert(source, out SByte sby); result = sby; return b;
                case Type t when t == KozmosTypeHelper<SByte?>._:
                    b = TryConvert(source, out SByte nsby); result = b ? nsby : null; return b;

                case Type t when t == KozmosTypeHelper<UInt16>._:
                    b = TryConvert(source, out UInt16 ui16); result = ui16; return b;
                case Type t when t == KozmosTypeHelper<UInt16?>._:
                    b = TryConvert(source, out UInt16 nui16); result = b ? nui16 : null; return b;

                case Type t when t == KozmosTypeHelper<Int16>._:
                    b = TryConvert(source, out Int16 i16); result = i16; return b;
                case Type t when t == KozmosTypeHelper<Int16?>._:
                    b = TryConvert(source, out Int16 ni16); result = b ? ni16 : null; return b;

                case Type t when t == KozmosTypeHelper<UInt32>._:
                    b = TryConvert(source, out UInt32 ui32); result = ui32; return b;
                case Type t when t == KozmosTypeHelper<UInt32?>._:
                    b = TryConvert(source, out UInt32 nui32); result = b ? nui32 : null; return b;

                case Type t when t == KozmosTypeHelper<Int32>._:
                    b = TryConvert(source, out Int32 i32); result = i32; return b;
                case Type t when t == KozmosTypeHelper<Int32?>._:
                    b = TryConvert(source, out Int32 ni32); result = b ? ni32 : null; return b;

                case Type t when t == KozmosTypeHelper<UInt64>._:
                    b = TryConvert(source, out UInt64 ui64); result = ui64; return b;
                case Type t when t == KozmosTypeHelper<UInt64?>._:
                    b = TryConvert(source, out UInt64 nui64); result = b ? nui64 : null; return b;

                case Type t when t == KozmosTypeHelper<Int64>._:
                    b = TryConvert(source, out Int64 i64); result = i64; return b;
                case Type t when t == KozmosTypeHelper<Int64?>._:
                    b = TryConvert(source, out Int64 ni64); result = b ? ni64 : null; return b;

                case Type t when t == KozmosTypeHelper<UInt128>._:
                    b = TryConvert(source, out UInt128 ui128); result = ui128; return b;
                case Type t when t == KozmosTypeHelper<UInt128?>._:
                    b = TryConvert(source, out UInt128 nui128); result = b ? nui128 : null; return b;

                case Type t when t == KozmosTypeHelper<Int128>._:
                    b = TryConvert(source, out Int128 i128); result = i128; return b;
                case Type t when t == KozmosTypeHelper<Int128?>._:
                    b = TryConvert(source, out Int128 ni128); result = b ? ni128 : null; return b;

                case Type t when t == KozmosTypeHelper<BigInteger>._:
                    b = TryConvert(source, out BigInteger bi); result = bi; return b;
                case Type t when t == KozmosTypeHelper<BigInteger?>._:
                    b = TryConvert(source, out BigInteger nbi); result = b ? nbi : null; return b;

                case Type t when t == KozmosTypeHelper<Decimal>._:
                    b = TryConvert(source, out Decimal m); result = m; return b;
                case Type t when t == KozmosTypeHelper<Decimal?>._:
                    b = TryConvert(source, out Decimal nm); result = b ? nm : null; return b;

                case Type t when t == KozmosTypeHelper<Single>._:
                    b = TryConvert(source, out Single f); result = f; return b;
                case Type t when t == KozmosTypeHelper<Single?>._:
                    b = TryConvert(source, out Single nf); result = b ? nf : null; return b;

                case Type t when t == KozmosTypeHelper<Double>._:
                    b = TryConvert(source, out Double d); result = d; return b;
                case Type t when t == KozmosTypeHelper<Double?>._:
                    b = TryConvert(source, out Double nd); result = b ? nd : null; return b;
            }

            KozmosExceptionHelper.ThrowValue_0_OfArgument_1_2_IsNotSupported(resultType);
            result = default; return false;
        }

        [MethodImpl(MethodImplOptions.AggressiveOptimization)]
        public static Boolean TryConvert(TimeOnly source, EKozmosTimeOnlyComponent component, Type resultType, out Object? result)
        {
            Boolean b;

            switch (resultType)
            {
                case Type t when t == KozmosTypeHelper<Byte>._:
                    b = TryConvert(source, component, out Byte by); result = by; return b;
                case Type t when t == KozmosTypeHelper<Byte?>._:
                    b = TryConvert(source, component, out Byte nby); result = b ? nby : null; return b;

                case Type t when t == KozmosTypeHelper<SByte>._:
                    b = TryConvert(source, component, out SByte sby); result = sby; return b;
                case Type t when t == KozmosTypeHelper<SByte?>._:
                    b = TryConvert(source, component, out SByte nsby); result = b ? nsby : null; return b;

                case Type t when t == KozmosTypeHelper<UInt16>._:
                    b = TryConvert(source, component, out UInt16 ui16); result = ui16; return b;
                case Type t when t == KozmosTypeHelper<UInt16?>._:
                    b = TryConvert(source, component, out UInt16 nui16); result = b ? nui16 : null; return b;

                case Type t when t == KozmosTypeHelper<Int16>._:
                    b = TryConvert(source, component, out Int16 i16); result = i16; return b;
                case Type t when t == KozmosTypeHelper<Int16?>._:
                    b = TryConvert(source, component, out Int16 ni16); result = b ? ni16 : null; return b;

                case Type t when t == KozmosTypeHelper<UInt32>._:
                    b = TryConvert(source, component, out UInt32 ui32); result = ui32; return b;
                case Type t when t == KozmosTypeHelper<UInt32?>._:
                    b = TryConvert(source, component, out UInt32 nui32); result = b ? nui32 : null; return b;

                case Type t when t == KozmosTypeHelper<Int32>._:
                    b = TryConvert(source, component, out Int32 i32); result = i32; return b;
                case Type t when t == KozmosTypeHelper<Int32?>._:
                    b = TryConvert(source, component, out Int32 ni32); result = b ? ni32 : null; return b;

                case Type t when t == KozmosTypeHelper<UInt64>._:
                    b = TryConvert(source, component, out UInt64 ui64); result = ui64; return b;
                case Type t when t == KozmosTypeHelper<UInt64?>._:
                    b = TryConvert(source, component, out UInt64 nui64); result = b ? nui64 : null; return b;

                case Type t when t == KozmosTypeHelper<Int64>._:
                    b = TryConvert(source, component, out Int64 i64); result = i64; return b;
                case Type t when t == KozmosTypeHelper<Int64?>._:
                    b = TryConvert(source, component, out Int64 ni64); result = b ? ni64 : null; return b;

                case Type t when t == KozmosTypeHelper<UInt128>._:
                    b = TryConvert(source, component, out UInt128 ui128); result = ui128; return b;
                case Type t when t == KozmosTypeHelper<UInt128?>._:
                    b = TryConvert(source, component, out UInt128 nui128); result = b ? nui128 : null; return b;

                case Type t when t == KozmosTypeHelper<Int128>._:
                    b = TryConvert(source, component, out Int128 i128); result = i128; return b;
                case Type t when t == KozmosTypeHelper<Int128?>._:
                    b = TryConvert(source, component, out Int128 ni128); result = b ? ni128 : null; return b;

                case Type t when t == KozmosTypeHelper<BigInteger>._:
                    b = TryConvert(source, component, out BigInteger bi); result = bi; return b;
                case Type t when t == KozmosTypeHelper<BigInteger?>._:
                    b = TryConvert(source, component, out BigInteger nbi); result = b ? nbi : null; return b;

                case Type t when t == KozmosTypeHelper<Decimal>._:
                    b = TryConvert(source, component, out Decimal m); result = m; return b;
                case Type t when t == KozmosTypeHelper<Decimal?>._:
                    b = TryConvert(source, component, out Decimal nm); result = b ? nm : null; return b;

                case Type t when t == KozmosTypeHelper<Single>._:
                    b = TryConvert(source, component, out Single f); result = f; return b;
                case Type t when t == KozmosTypeHelper<Single?>._:
                    b = TryConvert(source, component, out Single nf); result = b ? nf : null; return b;

                case Type t when t == KozmosTypeHelper<Double>._:
                    b = TryConvert(source, component, out Double d); result = d; return b;
                case Type t when t == KozmosTypeHelper<Double?>._:
                    b = TryConvert(source, component, out Double nd); result = b ? nd : null; return b;
            }

            KozmosExceptionHelper.ThrowValue_0_OfArgument_1_2_IsNotSupported(resultType);
            result = default; return false;
        }

        #endregion

        #region TimeSpan

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean TryConvert<TResult>(TimeSpan? source, out TResult result)
           where TResult : struct, INumber<TResult>
        { return KozmosNumberHelper<TResult>.TryConvert(source, out result); }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean TryConvert<TResult>(TimeSpan? source, EKozmosTimeSpanComponent component, out TResult result)
           where TResult : struct, INumber<TResult>
        { return KozmosNumberHelper<TResult>.TryConvert(source, component, out result); }

        [MethodImpl(MethodImplOptions.AggressiveOptimization)]
        public static Boolean TryConvert(TimeSpan? source, Type resultType, out Object? result)
        {
            Boolean b;

            switch (resultType)
            {
                case Type t when t == KozmosTypeHelper<Byte>._:
                    b = TryConvert(source, out Byte by); result = by; return b;
                case Type t when t == KozmosTypeHelper<Byte?>._:
                    b = TryConvert(source, out Byte nby); result = b ? nby : null; return b;

                case Type t when t == KozmosTypeHelper<SByte>._:
                    b = TryConvert(source, out SByte sby); result = sby; return b;
                case Type t when t == KozmosTypeHelper<SByte?>._:
                    b = TryConvert(source, out SByte nsby); result = b ? nsby : null; return b;

                case Type t when t == KozmosTypeHelper<UInt16>._:
                    b = TryConvert(source, out UInt16 ui16); result = ui16; return b;
                case Type t when t == KozmosTypeHelper<UInt16?>._:
                    b = TryConvert(source, out UInt16 nui16); result = b ? nui16 : null; return b;

                case Type t when t == KozmosTypeHelper<Int16>._:
                    b = TryConvert(source, out Int16 i16); result = i16; return b;
                case Type t when t == KozmosTypeHelper<Int16?>._:
                    b = TryConvert(source, out Int16 ni16); result = b ? ni16 : null; return b;

                case Type t when t == KozmosTypeHelper<UInt32>._:
                    b = TryConvert(source, out UInt32 ui32); result = ui32; return b;
                case Type t when t == KozmosTypeHelper<UInt32?>._:
                    b = TryConvert(source, out UInt32 nui32); result = b ? nui32 : null; return b;

                case Type t when t == KozmosTypeHelper<Int32>._:
                    b = TryConvert(source, out Int32 i32); result = i32; return b;
                case Type t when t == KozmosTypeHelper<Int32?>._:
                    b = TryConvert(source, out Int32 ni32); result = b ? ni32 : null; return b;

                case Type t when t == KozmosTypeHelper<UInt64>._:
                    b = TryConvert(source, out UInt64 ui64); result = ui64; return b;
                case Type t when t == KozmosTypeHelper<UInt64?>._:
                    b = TryConvert(source, out UInt64 nui64); result = b ? nui64 : null; return b;

                case Type t when t == KozmosTypeHelper<Int64>._:
                    b = TryConvert(source, out Int64 i64); result = i64; return b;
                case Type t when t == KozmosTypeHelper<Int64?>._:
                    b = TryConvert(source, out Int64 ni64); result = b ? ni64 : null; return b;

                case Type t when t == KozmosTypeHelper<UInt128>._:
                    b = TryConvert(source, out UInt128 ui128); result = ui128; return b;
                case Type t when t == KozmosTypeHelper<UInt128?>._:
                    b = TryConvert(source, out UInt128 nui128); result = b ? nui128 : null; return b;

                case Type t when t == KozmosTypeHelper<Int128>._:
                    b = TryConvert(source, out Int128 i128); result = i128; return b;
                case Type t when t == KozmosTypeHelper<Int128?>._:
                    b = TryConvert(source, out Int128 ni128); result = b ? ni128 : null; return b;

                case Type t when t == KozmosTypeHelper<BigInteger>._:
                    b = TryConvert(source, out BigInteger bi); result = bi; return b;
                case Type t when t == KozmosTypeHelper<BigInteger?>._:
                    b = TryConvert(source, out BigInteger nbi); result = b ? nbi : null; return b;

                case Type t when t == KozmosTypeHelper<Decimal>._:
                    b = TryConvert(source, out Decimal m); result = m; return b;
                case Type t when t == KozmosTypeHelper<Decimal?>._:
                    b = TryConvert(source, out Decimal nm); result = b ? nm : null; return b;

                case Type t when t == KozmosTypeHelper<Single>._:
                    b = TryConvert(source, out Single f); result = f; return b;
                case Type t when t == KozmosTypeHelper<Single?>._:
                    b = TryConvert(source, out Single nf); result = b ? nf : null; return b;

                case Type t when t == KozmosTypeHelper<Double>._:
                    b = TryConvert(source, out Double d); result = d; return b;
                case Type t when t == KozmosTypeHelper<Double?>._:
                    b = TryConvert(source, out Double nd); result = b ? nd : null; return b;
            }

            KozmosExceptionHelper.ThrowValue_0_OfArgument_1_2_IsNotSupported(resultType);
            result = default; return false;
        }

        [MethodImpl(MethodImplOptions.AggressiveOptimization)]
        public static Boolean TryConvert(TimeSpan? source, EKozmosTimeSpanComponent component, Type resultType, out Object? result)
        {
            Boolean b;

            switch (resultType)
            {
                case Type t when t == KozmosTypeHelper<Byte>._:
                    b = TryConvert(source, component, out Byte by); result = by; return b;
                case Type t when t == KozmosTypeHelper<Byte?>._:
                    b = TryConvert(source, component, out Byte nby); result = b ? nby : null; return b;

                case Type t when t == KozmosTypeHelper<SByte>._:
                    b = TryConvert(source, component, out SByte sby); result = sby; return b;
                case Type t when t == KozmosTypeHelper<SByte?>._:
                    b = TryConvert(source, component, out SByte nsby); result = b ? nsby : null; return b;

                case Type t when t == KozmosTypeHelper<UInt16>._:
                    b = TryConvert(source, component, out UInt16 ui16); result = ui16; return b;
                case Type t when t == KozmosTypeHelper<UInt16?>._:
                    b = TryConvert(source, component, out UInt16 nui16); result = b ? nui16 : null; return b;

                case Type t when t == KozmosTypeHelper<Int16>._:
                    b = TryConvert(source, component, out Int16 i16); result = i16; return b;
                case Type t when t == KozmosTypeHelper<Int16?>._:
                    b = TryConvert(source, component, out Int16 ni16); result = b ? ni16 : null; return b;

                case Type t when t == KozmosTypeHelper<UInt32>._:
                    b = TryConvert(source, component, out UInt32 ui32); result = ui32; return b;
                case Type t when t == KozmosTypeHelper<UInt32?>._:
                    b = TryConvert(source, component, out UInt32 nui32); result = b ? nui32 : null; return b;

                case Type t when t == KozmosTypeHelper<Int32>._:
                    b = TryConvert(source, component, out Int32 i32); result = i32; return b;
                case Type t when t == KozmosTypeHelper<Int32?>._:
                    b = TryConvert(source, component, out Int32 ni32); result = b ? ni32 : null; return b;

                case Type t when t == KozmosTypeHelper<UInt64>._:
                    b = TryConvert(source, component, out UInt64 ui64); result = ui64; return b;
                case Type t when t == KozmosTypeHelper<UInt64?>._:
                    b = TryConvert(source, component, out UInt64 nui64); result = b ? nui64 : null; return b;

                case Type t when t == KozmosTypeHelper<Int64>._:
                    b = TryConvert(source, component, out Int64 i64); result = i64; return b;
                case Type t when t == KozmosTypeHelper<Int64?>._:
                    b = TryConvert(source, component, out Int64 ni64); result = b ? ni64 : null; return b;

                case Type t when t == KozmosTypeHelper<UInt128>._:
                    b = TryConvert(source, component, out UInt128 ui128); result = ui128; return b;
                case Type t when t == KozmosTypeHelper<UInt128?>._:
                    b = TryConvert(source, component, out UInt128 nui128); result = b ? nui128 : null; return b;

                case Type t when t == KozmosTypeHelper<Int128>._:
                    b = TryConvert(source, component, out Int128 i128); result = i128; return b;
                case Type t when t == KozmosTypeHelper<Int128?>._:
                    b = TryConvert(source, component, out Int128 ni128); result = b ? ni128 : null; return b;

                case Type t when t == KozmosTypeHelper<BigInteger>._:
                    b = TryConvert(source, component, out BigInteger bi); result = bi; return b;
                case Type t when t == KozmosTypeHelper<BigInteger?>._:
                    b = TryConvert(source, component, out BigInteger nbi); result = b ? nbi : null; return b;

                case Type t when t == KozmosTypeHelper<Decimal>._:
                    b = TryConvert(source, component, out Decimal m); result = m; return b;
                case Type t when t == KozmosTypeHelper<Decimal?>._:
                    b = TryConvert(source, component, out Decimal nm); result = b ? nm : null; return b;

                case Type t when t == KozmosTypeHelper<Single>._:
                    b = TryConvert(source, component, out Single f); result = f; return b;
                case Type t when t == KozmosTypeHelper<Single?>._:
                    b = TryConvert(source, component, out Single nf); result = b ? nf : null; return b;

                case Type t when t == KozmosTypeHelper<Double>._:
                    b = TryConvert(source, component, out Double d); result = d; return b;
                case Type t when t == KozmosTypeHelper<Double?>._:
                    b = TryConvert(source, component, out Double nd); result = b ? nd : null; return b;
            }

            KozmosExceptionHelper.ThrowValue_0_OfArgument_1_2_IsNotSupported(resultType);
            result = default; return false;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean TryConvert<TResult>(TimeSpan source, out TResult result)
           where TResult : struct, INumber<TResult>
        { return KozmosNumberHelper<TResult>.TryConvert(source, out result); }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean TryConvert<TResult>(TimeSpan source, EKozmosTimeSpanComponent component, out TResult result)
           where TResult : struct, INumber<TResult>
        { return KozmosNumberHelper<TResult>.TryConvert(source, component, out result); }

        [MethodImpl(MethodImplOptions.AggressiveOptimization)]
        public static Boolean TryConvert(TimeSpan source, Type resultType, out Object? result)
        {
            Boolean b;

            switch (resultType)
            {
                case Type t when t == KozmosTypeHelper<Byte>._:
                    b = TryConvert(source, out Byte by); result = by; return b;
                case Type t when t == KozmosTypeHelper<Byte?>._:
                    b = TryConvert(source, out Byte nby); result = b ? nby : null; return b;

                case Type t when t == KozmosTypeHelper<SByte>._:
                    b = TryConvert(source, out SByte sby); result = sby; return b;
                case Type t when t == KozmosTypeHelper<SByte?>._:
                    b = TryConvert(source, out SByte nsby); result = b ? nsby : null; return b;

                case Type t when t == KozmosTypeHelper<UInt16>._:
                    b = TryConvert(source, out UInt16 ui16); result = ui16; return b;
                case Type t when t == KozmosTypeHelper<UInt16?>._:
                    b = TryConvert(source, out UInt16 nui16); result = b ? nui16 : null; return b;

                case Type t when t == KozmosTypeHelper<Int16>._:
                    b = TryConvert(source, out Int16 i16); result = i16; return b;
                case Type t when t == KozmosTypeHelper<Int16?>._:
                    b = TryConvert(source, out Int16 ni16); result = b ? ni16 : null; return b;

                case Type t when t == KozmosTypeHelper<UInt32>._:
                    b = TryConvert(source, out UInt32 ui32); result = ui32; return b;
                case Type t when t == KozmosTypeHelper<UInt32?>._:
                    b = TryConvert(source, out UInt32 nui32); result = b ? nui32 : null; return b;

                case Type t when t == KozmosTypeHelper<Int32>._:
                    b = TryConvert(source, out Int32 i32); result = i32; return b;
                case Type t when t == KozmosTypeHelper<Int32?>._:
                    b = TryConvert(source, out Int32 ni32); result = b ? ni32 : null; return b;

                case Type t when t == KozmosTypeHelper<UInt64>._:
                    b = TryConvert(source, out UInt64 ui64); result = ui64; return b;
                case Type t when t == KozmosTypeHelper<UInt64?>._:
                    b = TryConvert(source, out UInt64 nui64); result = b ? nui64 : null; return b;

                case Type t when t == KozmosTypeHelper<Int64>._:
                    b = TryConvert(source, out Int64 i64); result = i64; return b;
                case Type t when t == KozmosTypeHelper<Int64?>._:
                    b = TryConvert(source, out Int64 ni64); result = b ? ni64 : null; return b;

                case Type t when t == KozmosTypeHelper<UInt128>._:
                    b = TryConvert(source, out UInt128 ui128); result = ui128; return b;
                case Type t when t == KozmosTypeHelper<UInt128?>._:
                    b = TryConvert(source, out UInt128 nui128); result = b ? nui128 : null; return b;

                case Type t when t == KozmosTypeHelper<Int128>._:
                    b = TryConvert(source, out Int128 i128); result = i128; return b;
                case Type t when t == KozmosTypeHelper<Int128?>._:
                    b = TryConvert(source, out Int128 ni128); result = b ? ni128 : null; return b;

                case Type t when t == KozmosTypeHelper<BigInteger>._:
                    b = TryConvert(source, out BigInteger bi); result = bi; return b;
                case Type t when t == KozmosTypeHelper<BigInteger?>._:
                    b = TryConvert(source, out BigInteger nbi); result = b ? nbi : null; return b;

                case Type t when t == KozmosTypeHelper<Decimal>._:
                    b = TryConvert(source, out Decimal m); result = m; return b;
                case Type t when t == KozmosTypeHelper<Decimal?>._:
                    b = TryConvert(source, out Decimal nm); result = b ? nm : null; return b;

                case Type t when t == KozmosTypeHelper<Single>._:
                    b = TryConvert(source, out Single f); result = f; return b;
                case Type t when t == KozmosTypeHelper<Single?>._:
                    b = TryConvert(source, out Single nf); result = b ? nf : null; return b;

                case Type t when t == KozmosTypeHelper<Double>._:
                    b = TryConvert(source, out Double d); result = d; return b;
                case Type t when t == KozmosTypeHelper<Double?>._:
                    b = TryConvert(source, out Double nd); result = b ? nd : null; return b;
            }

            KozmosExceptionHelper.ThrowValue_0_OfArgument_1_2_IsNotSupported(resultType);
            result = default; return false;
        }

        [MethodImpl(MethodImplOptions.AggressiveOptimization)]
        public static Boolean TryConvert(TimeSpan source, EKozmosTimeSpanComponent component, Type resultType, out Object? result)
        {
            Boolean b;

            switch (resultType)
            {
                case Type t when t == KozmosTypeHelper<Byte>._:
                    b = TryConvert(source, component, out Byte by); result = by; return b;
                case Type t when t == KozmosTypeHelper<Byte?>._:
                    b = TryConvert(source, component, out Byte nby); result = b ? nby : null; return b;

                case Type t when t == KozmosTypeHelper<SByte>._:
                    b = TryConvert(source, component, out SByte sby); result = sby; return b;
                case Type t when t == KozmosTypeHelper<SByte?>._:
                    b = TryConvert(source, component, out SByte nsby); result = b ? nsby : null; return b;

                case Type t when t == KozmosTypeHelper<UInt16>._:
                    b = TryConvert(source, component, out UInt16 ui16); result = ui16; return b;
                case Type t when t == KozmosTypeHelper<UInt16?>._:
                    b = TryConvert(source, component, out UInt16 nui16); result = b ? nui16 : null; return b;

                case Type t when t == KozmosTypeHelper<Int16>._:
                    b = TryConvert(source, component, out Int16 i16); result = i16; return b;
                case Type t when t == KozmosTypeHelper<Int16?>._:
                    b = TryConvert(source, component, out Int16 ni16); result = b ? ni16 : null; return b;

                case Type t when t == KozmosTypeHelper<UInt32>._:
                    b = TryConvert(source, component, out UInt32 ui32); result = ui32; return b;
                case Type t when t == KozmosTypeHelper<UInt32?>._:
                    b = TryConvert(source, component, out UInt32 nui32); result = b ? nui32 : null; return b;

                case Type t when t == KozmosTypeHelper<Int32>._:
                    b = TryConvert(source, component, out Int32 i32); result = i32; return b;
                case Type t when t == KozmosTypeHelper<Int32?>._:
                    b = TryConvert(source, component, out Int32 ni32); result = b ? ni32 : null; return b;

                case Type t when t == KozmosTypeHelper<UInt64>._:
                    b = TryConvert(source, component, out UInt64 ui64); result = ui64; return b;
                case Type t when t == KozmosTypeHelper<UInt64?>._:
                    b = TryConvert(source, component, out UInt64 nui64); result = b ? nui64 : null; return b;

                case Type t when t == KozmosTypeHelper<Int64>._:
                    b = TryConvert(source, component, out Int64 i64); result = i64; return b;
                case Type t when t == KozmosTypeHelper<Int64?>._:
                    b = TryConvert(source, component, out Int64 ni64); result = b ? ni64 : null; return b;

                case Type t when t == KozmosTypeHelper<UInt128>._:
                    b = TryConvert(source, component, out UInt128 ui128); result = ui128; return b;
                case Type t when t == KozmosTypeHelper<UInt128?>._:
                    b = TryConvert(source, component, out UInt128 nui128); result = b ? nui128 : null; return b;

                case Type t when t == KozmosTypeHelper<Int128>._:
                    b = TryConvert(source, component, out Int128 i128); result = i128; return b;
                case Type t when t == KozmosTypeHelper<Int128?>._:
                    b = TryConvert(source, component, out Int128 ni128); result = b ? ni128 : null; return b;

                case Type t when t == KozmosTypeHelper<BigInteger>._:
                    b = TryConvert(source, component, out BigInteger bi); result = bi; return b;
                case Type t when t == KozmosTypeHelper<BigInteger?>._:
                    b = TryConvert(source, component, out BigInteger nbi); result = b ? nbi : null; return b;

                case Type t when t == KozmosTypeHelper<Decimal>._:
                    b = TryConvert(source, component, out Decimal m); result = m; return b;
                case Type t when t == KozmosTypeHelper<Decimal?>._:
                    b = TryConvert(source, component, out Decimal nm); result = b ? nm : null; return b;

                case Type t when t == KozmosTypeHelper<Single>._:
                    b = TryConvert(source, component, out Single f); result = f; return b;
                case Type t when t == KozmosTypeHelper<Single?>._:
                    b = TryConvert(source, component, out Single nf); result = b ? nf : null; return b;

                case Type t when t == KozmosTypeHelper<Double>._:
                    b = TryConvert(source, component, out Double d); result = d; return b;
                case Type t when t == KozmosTypeHelper<Double?>._:
                    b = TryConvert(source, component, out Double nd); result = b ? nd : null; return b;
            }

            KozmosExceptionHelper.ThrowValue_0_OfArgument_1_2_IsNotSupported(resultType);
            result = default; return false;
        }

        #endregion

        #endregion

        #region Textuals

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean TryConvert<TResult>(String? source, out TResult result)
          where TResult : struct, INumber<TResult>
        { return KozmosNumberHelper<TResult>.TryConvert(source, out result); }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean TryConvert<TResult>(String? source, KozmosNumberIParsableConvertOptions options, out TResult result)
          where TResult : struct, INumber<TResult>
        { return KozmosNumberHelper<TResult>.TryConvert(source, options, out result); }

        [MethodImpl(MethodImplOptions.AggressiveOptimization)]
        public static Boolean TryConvert(String? source, Type resultType, out Object? result)
        {
            Boolean b;

            switch (resultType)
            {
                case Type t when t == KozmosTypeHelper<Byte>._:
                    b = TryConvert(source, out Byte by); result = by; return b;
                case Type t when t == KozmosTypeHelper<Byte?>._:
                    b = TryConvert(source, out Byte nby); result = b ? nby : null; return b;

                case Type t when t == KozmosTypeHelper<SByte>._:
                    b = TryConvert(source, out SByte sby); result = sby; return b;
                case Type t when t == KozmosTypeHelper<SByte?>._:
                    b = TryConvert(source, out SByte nsby); result = b ? nsby : null; return b;

                case Type t when t == KozmosTypeHelper<UInt16>._:
                    b = TryConvert(source, out UInt16 ui16); result = ui16; return b;
                case Type t when t == KozmosTypeHelper<UInt16?>._:
                    b = TryConvert(source, out UInt16 nui16); result = b ? nui16 : null; return b;

                case Type t when t == KozmosTypeHelper<Int16>._:
                    b = TryConvert(source, out Int16 i16); result = i16; return b;
                case Type t when t == KozmosTypeHelper<Int16?>._:
                    b = TryConvert(source, out Int16 ni16); result = b ? ni16 : null; return b;

                case Type t when t == KozmosTypeHelper<UInt32>._:
                    b = TryConvert(source, out UInt32 ui32); result = ui32; return b;
                case Type t when t == KozmosTypeHelper<UInt32?>._:
                    b = TryConvert(source, out UInt32 nui32); result = b ? nui32 : null; return b;

                case Type t when t == KozmosTypeHelper<Int32>._:
                    b = TryConvert(source, out Int32 i32); result = i32; return b;
                case Type t when t == KozmosTypeHelper<Int32?>._:
                    b = TryConvert(source, out Int32 ni32); result = b ? ni32 : null; return b;

                case Type t when t == KozmosTypeHelper<UInt64>._:
                    b = TryConvert(source, out UInt64 ui64); result = ui64; return b;
                case Type t when t == KozmosTypeHelper<UInt64?>._:
                    b = TryConvert(source, out UInt64 nui64); result = b ? nui64 : null; return b;

                case Type t when t == KozmosTypeHelper<Int64>._:
                    b = TryConvert(source, out Int64 i64); result = i64; return b;
                case Type t when t == KozmosTypeHelper<Int64?>._:
                    b = TryConvert(source, out Int64 ni64); result = b ? ni64 : null; return b;

                case Type t when t == KozmosTypeHelper<UInt128>._:
                    b = TryConvert(source, out UInt128 ui128); result = ui128; return b;
                case Type t when t == KozmosTypeHelper<UInt128?>._:
                    b = TryConvert(source, out UInt128 nui128); result = b ? nui128 : null; return b;

                case Type t when t == KozmosTypeHelper<Int128>._:
                    b = TryConvert(source, out Int128 i128); result = i128; return b;
                case Type t when t == KozmosTypeHelper<Int128?>._:
                    b = TryConvert(source, out Int128 ni128); result = b ? ni128 : null; return b;

                case Type t when t == KozmosTypeHelper<BigInteger>._:
                    b = TryConvert(source, out BigInteger bi); result = bi; return b;
                case Type t when t == KozmosTypeHelper<BigInteger?>._:
                    b = TryConvert(source, out BigInteger nbi); result = b ? nbi : null; return b;

                case Type t when t == KozmosTypeHelper<Decimal>._:
                    b = TryConvert(source, out Decimal m); result = m; return b;
                case Type t when t == KozmosTypeHelper<Decimal?>._:
                    b = TryConvert(source, out Decimal nm); result = b ? nm : null; return b;

                case Type t when t == KozmosTypeHelper<Single>._:
                    b = TryConvert(source, out Single f); result = f; return b;
                case Type t when t == KozmosTypeHelper<Single?>._:
                    b = TryConvert(source, out Single nf); result = b ? nf : null; return b;

                case Type t when t == KozmosTypeHelper<Double>._:
                    b = TryConvert(source, out Double d); result = d; return b;
                case Type t when t == KozmosTypeHelper<Double?>._:
                    b = TryConvert(source, out Double nd); result = b ? nd : null; return b;
            }

            KozmosExceptionHelper.ThrowValue_0_OfArgument_1_2_IsNotSupported(resultType);
            result = default; return false;
        }

        [MethodImpl(MethodImplOptions.AggressiveOptimization)]
        public static Boolean TryConvert(String? source, KozmosNumberIParsableConvertOptions options, Type resultType, out Object? result)
        {
            Boolean b;

            switch (resultType)
            {
                case Type t when t == KozmosTypeHelper<Byte>._:
                    b = TryConvert(source, options, out Byte by); result = by; return b;
                case Type t when t == KozmosTypeHelper<Byte?>._:
                    b = TryConvert(source, options, out Byte nby); result = b ? nby : null; return b;

                case Type t when t == KozmosTypeHelper<SByte>._:
                    b = TryConvert(source, options, out SByte sby); result = sby; return b;
                case Type t when t == KozmosTypeHelper<SByte?>._:
                    b = TryConvert(source, options, out SByte nsby); result = b ? nsby : null; return b;

                case Type t when t == KozmosTypeHelper<UInt16>._:
                    b = TryConvert(source, options, out UInt16 ui16); result = ui16; return b;
                case Type t when t == KozmosTypeHelper<UInt16?>._:
                    b = TryConvert(source, options, out UInt16 nui16); result = b ? nui16 : null; return b;

                case Type t when t == KozmosTypeHelper<Int16>._:
                    b = TryConvert(source, options, out Int16 i16); result = i16; return b;
                case Type t when t == KozmosTypeHelper<Int16?>._:
                    b = TryConvert(source, options, out Int16 ni16); result = b ? ni16 : null; return b;

                case Type t when t == KozmosTypeHelper<UInt32>._:
                    b = TryConvert(source, options, out UInt32 ui32); result = ui32; return b;
                case Type t when t == KozmosTypeHelper<UInt32?>._:
                    b = TryConvert(source, options, out UInt32 nui32); result = b ? nui32 : null; return b;

                case Type t when t == KozmosTypeHelper<Int32>._:
                    b = TryConvert(source, options, out Int32 i32); result = i32; return b;
                case Type t when t == KozmosTypeHelper<Int32?>._:
                    b = TryConvert(source, options, out Int32 ni32); result = b ? ni32 : null; return b;

                case Type t when t == KozmosTypeHelper<UInt64>._:
                    b = TryConvert(source, options, out UInt64 ui64); result = ui64; return b;
                case Type t when t == KozmosTypeHelper<UInt64?>._:
                    b = TryConvert(source, options, out UInt64 nui64); result = b ? nui64 : null; return b;

                case Type t when t == KozmosTypeHelper<Int64>._:
                    b = TryConvert(source, options, out Int64 i64); result = i64; return b;
                case Type t when t == KozmosTypeHelper<Int64?>._:
                    b = TryConvert(source, options, out Int64 ni64); result = b ? ni64 : null; return b;

                case Type t when t == KozmosTypeHelper<UInt128>._:
                    b = TryConvert(source, options, out UInt128 ui128); result = ui128; return b;
                case Type t when t == KozmosTypeHelper<UInt128?>._:
                    b = TryConvert(source, options, out UInt128 nui128); result = b ? nui128 : null; return b;

                case Type t when t == KozmosTypeHelper<Int128>._:
                    b = TryConvert(source, options, out Int128 i128); result = i128; return b;
                case Type t when t == KozmosTypeHelper<Int128?>._:
                    b = TryConvert(source, options, out Int128 ni128); result = b ? ni128 : null; return b;

                case Type t when t == KozmosTypeHelper<BigInteger>._:
                    b = TryConvert(source, options, out BigInteger bi); result = bi; return b;
                case Type t when t == KozmosTypeHelper<BigInteger?>._:
                    b = TryConvert(source, options, out BigInteger nbi); result = b ? nbi : null; return b;

                case Type t when t == KozmosTypeHelper<Decimal>._:
                    b = TryConvert(source, options, out Decimal m); result = m; return b;
                case Type t when t == KozmosTypeHelper<Decimal?>._:
                    b = TryConvert(source, options, out Decimal nm); result = b ? nm : null; return b;

                case Type t when t == KozmosTypeHelper<Single>._:
                    b = TryConvert(source, options, out Single f); result = f; return b;
                case Type t when t == KozmosTypeHelper<Single?>._:
                    b = TryConvert(source, options, out Single nf); result = b ? nf : null; return b;

                case Type t when t == KozmosTypeHelper<Double>._:
                    b = TryConvert(source, options, out Double d); result = d; return b;
                case Type t when t == KozmosTypeHelper<Double?>._:
                    b = TryConvert(source, options, out Double nd); result = b ? nd : null; return b;
            }

            KozmosExceptionHelper.ThrowValue_0_OfArgument_1_2_IsNotSupported(resultType);
            result = default; return false;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean TryConvert<TResult>(ReadOnlySpan<Char> source, out TResult result)
          where TResult : struct, INumber<TResult>
        { return KozmosNumberHelper<TResult>.TryConvert(source, out result); }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean TryConvert<TResult>(ReadOnlySpan<Char> source, KozmosNumberIParsableConvertOptions options, out TResult result)
          where TResult : struct, INumber<TResult>
        { return KozmosNumberHelper<TResult>.TryConvert(source, options, out result); }

        [MethodImpl(MethodImplOptions.AggressiveOptimization)]
        public static Boolean TryConvert(ReadOnlySpan<Char> source, Type resultType, out Object? result)
        {
            Boolean b;

            switch (resultType)
            {
                case Type t when t == KozmosTypeHelper<Byte>._:
                    b = TryConvert(source, out Byte by); result = by; return b;
                case Type t when t == KozmosTypeHelper<Byte?>._:
                    b = TryConvert(source, out Byte nby); result = b ? nby : null; return b;

                case Type t when t == KozmosTypeHelper<SByte>._:
                    b = TryConvert(source, out SByte sby); result = sby; return b;
                case Type t when t == KozmosTypeHelper<SByte?>._:
                    b = TryConvert(source, out SByte nsby); result = b ? nsby : null; return b;

                case Type t when t == KozmosTypeHelper<UInt16>._:
                    b = TryConvert(source, out UInt16 ui16); result = ui16; return b;
                case Type t when t == KozmosTypeHelper<UInt16?>._:
                    b = TryConvert(source, out UInt16 nui16); result = b ? nui16 : null; return b;

                case Type t when t == KozmosTypeHelper<Int16>._:
                    b = TryConvert(source, out Int16 i16); result = i16; return b;
                case Type t when t == KozmosTypeHelper<Int16?>._:
                    b = TryConvert(source, out Int16 ni16); result = b ? ni16 : null; return b;

                case Type t when t == KozmosTypeHelper<UInt32>._:
                    b = TryConvert(source, out UInt32 ui32); result = ui32; return b;
                case Type t when t == KozmosTypeHelper<UInt32?>._:
                    b = TryConvert(source, out UInt32 nui32); result = b ? nui32 : null; return b;

                case Type t when t == KozmosTypeHelper<Int32>._:
                    b = TryConvert(source, out Int32 i32); result = i32; return b;
                case Type t when t == KozmosTypeHelper<Int32?>._:
                    b = TryConvert(source, out Int32 ni32); result = b ? ni32 : null; return b;

                case Type t when t == KozmosTypeHelper<UInt64>._:
                    b = TryConvert(source, out UInt64 ui64); result = ui64; return b;
                case Type t when t == KozmosTypeHelper<UInt64?>._:
                    b = TryConvert(source, out UInt64 nui64); result = b ? nui64 : null; return b;

                case Type t when t == KozmosTypeHelper<Int64>._:
                    b = TryConvert(source, out Int64 i64); result = i64; return b;
                case Type t when t == KozmosTypeHelper<Int64?>._:
                    b = TryConvert(source, out Int64 ni64); result = b ? ni64 : null; return b;

                case Type t when t == KozmosTypeHelper<UInt128>._:
                    b = TryConvert(source, out UInt128 ui128); result = ui128; return b;
                case Type t when t == KozmosTypeHelper<UInt128?>._:
                    b = TryConvert(source, out UInt128 nui128); result = b ? nui128 : null; return b;

                case Type t when t == KozmosTypeHelper<Int128>._:
                    b = TryConvert(source, out Int128 i128); result = i128; return b;
                case Type t when t == KozmosTypeHelper<Int128?>._:
                    b = TryConvert(source, out Int128 ni128); result = b ? ni128 : null; return b;

                case Type t when t == KozmosTypeHelper<BigInteger>._:
                    b = TryConvert(source, out BigInteger bi); result = bi; return b;
                case Type t when t == KozmosTypeHelper<BigInteger?>._:
                    b = TryConvert(source, out BigInteger nbi); result = b ? nbi : null; return b;

                case Type t when t == KozmosTypeHelper<Decimal>._:
                    b = TryConvert(source, out Decimal m); result = m; return b;
                case Type t when t == KozmosTypeHelper<Decimal?>._:
                    b = TryConvert(source, out Decimal nm); result = b ? nm : null; return b;

                case Type t when t == KozmosTypeHelper<Single>._:
                    b = TryConvert(source, out Single f); result = f; return b;
                case Type t when t == KozmosTypeHelper<Single?>._:
                    b = TryConvert(source, out Single nf); result = b ? nf : null; return b;

                case Type t when t == KozmosTypeHelper<Double>._:
                    b = TryConvert(source, out Double d); result = d; return b;
                case Type t when t == KozmosTypeHelper<Double?>._:
                    b = TryConvert(source, out Double nd); result = b ? nd : null; return b;
            }

            KozmosExceptionHelper.ThrowValue_0_OfArgument_1_2_IsNotSupported(resultType);
            result = default; return false;
        }

        [MethodImpl(MethodImplOptions.AggressiveOptimization)]
        public static Boolean TryConvert(ReadOnlySpan<Char> source, KozmosNumberIParsableConvertOptions options, Type resultType, out Object? result)
        {
            Boolean b;

            switch (resultType)
            {
                case Type t when t == KozmosTypeHelper<Byte>._:
                    b = TryConvert(source, options, out Byte by); result = by; return b;
                case Type t when t == KozmosTypeHelper<Byte?>._:
                    b = TryConvert(source, options, out Byte nby); result = b ? nby : null; return b;

                case Type t when t == KozmosTypeHelper<SByte>._:
                    b = TryConvert(source, options, out SByte sby); result = sby; return b;
                case Type t when t == KozmosTypeHelper<SByte?>._:
                    b = TryConvert(source, options, out SByte nsby); result = b ? nsby : null; return b;

                case Type t when t == KozmosTypeHelper<UInt16>._:
                    b = TryConvert(source, options, out UInt16 ui16); result = ui16; return b;
                case Type t when t == KozmosTypeHelper<UInt16?>._:
                    b = TryConvert(source, options, out UInt16 nui16); result = b ? nui16 : null; return b;

                case Type t when t == KozmosTypeHelper<Int16>._:
                    b = TryConvert(source, options, out Int16 i16); result = i16; return b;
                case Type t when t == KozmosTypeHelper<Int16?>._:
                    b = TryConvert(source, options, out Int16 ni16); result = b ? ni16 : null; return b;

                case Type t when t == KozmosTypeHelper<UInt32>._:
                    b = TryConvert(source, options, out UInt32 ui32); result = ui32; return b;
                case Type t when t == KozmosTypeHelper<UInt32?>._:
                    b = TryConvert(source, options, out UInt32 nui32); result = b ? nui32 : null; return b;

                case Type t when t == KozmosTypeHelper<Int32>._:
                    b = TryConvert(source, options, out Int32 i32); result = i32; return b;
                case Type t when t == KozmosTypeHelper<Int32?>._:
                    b = TryConvert(source, options, out Int32 ni32); result = b ? ni32 : null; return b;

                case Type t when t == KozmosTypeHelper<UInt64>._:
                    b = TryConvert(source, options, out UInt64 ui64); result = ui64; return b;
                case Type t when t == KozmosTypeHelper<UInt64?>._:
                    b = TryConvert(source, options, out UInt64 nui64); result = b ? nui64 : null; return b;

                case Type t when t == KozmosTypeHelper<Int64>._:
                    b = TryConvert(source, options, out Int64 i64); result = i64; return b;
                case Type t when t == KozmosTypeHelper<Int64?>._:
                    b = TryConvert(source, options, out Int64 ni64); result = b ? ni64 : null; return b;

                case Type t when t == KozmosTypeHelper<UInt128>._:
                    b = TryConvert(source, options, out UInt128 ui128); result = ui128; return b;
                case Type t when t == KozmosTypeHelper<UInt128?>._:
                    b = TryConvert(source, options, out UInt128 nui128); result = b ? nui128 : null; return b;

                case Type t when t == KozmosTypeHelper<Int128>._:
                    b = TryConvert(source, options, out Int128 i128); result = i128; return b;
                case Type t when t == KozmosTypeHelper<Int128?>._:
                    b = TryConvert(source, options, out Int128 ni128); result = b ? ni128 : null; return b;

                case Type t when t == KozmosTypeHelper<BigInteger>._:
                    b = TryConvert(source, options, out BigInteger bi); result = bi; return b;
                case Type t when t == KozmosTypeHelper<BigInteger?>._:
                    b = TryConvert(source, options, out BigInteger nbi); result = b ? nbi : null; return b;

                case Type t when t == KozmosTypeHelper<Decimal>._:
                    b = TryConvert(source, options, out Decimal m); result = m; return b;
                case Type t when t == KozmosTypeHelper<Decimal?>._:
                    b = TryConvert(source, options, out Decimal nm); result = b ? nm : null; return b;

                case Type t when t == KozmosTypeHelper<Single>._:
                    b = TryConvert(source, options, out Single f); result = f; return b;
                case Type t when t == KozmosTypeHelper<Single?>._:
                    b = TryConvert(source, options, out Single nf); result = b ? nf : null; return b;

                case Type t when t == KozmosTypeHelper<Double>._:
                    b = TryConvert(source, options, out Double d); result = d; return b;
                case Type t when t == KozmosTypeHelper<Double?>._:
                    b = TryConvert(source, options, out Double nd); result = b ? nd : null; return b;
            }

            KozmosExceptionHelper.ThrowValue_0_OfArgument_1_2_IsNotSupported(resultType);
            result = default; return false;
        }

        #endregion

        #region Objects

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean TryConvert<TResult>(Object? source, out TResult result)
            where TResult : struct, INumber<TResult>
        {
            return KozmosNumberHelper<TResult>.TryConvert(source, out result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean TryConvert<TResult>(Object? source, KozmosNumberConvertOptions options, out TResult result)
            where TResult : struct, INumber<TResult>
        {
            return KozmosNumberHelper<TResult>.TryConvert(source, options, out result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean TryConvert(Object? source, Type resultType, out Object? result)
        {
            return TryConvert(source, KozmosNumberConvertOptions.Default, resultType, out result);
        }

        [MethodImpl(MethodImplOptions.AggressiveOptimization)]
        public static Boolean TryConvert(Object? source, KozmosNumberConvertOptions options, Type resultType, out Object? result)
        {
            if (source is null) { result = default; return IsNullable(resultType); }

            switch (source)
            {
                // Conditionals >
                case Boolean b: return TryConvert(b, resultType, out result);
                // < Conditionals

                // Codeds >
                case Char c:
                    KozmosArgumentNullExceptionHelper.ThrowIfNull(options);
                    return TryConvert(c, options.CharComponent, resultType, out result);
                // < Codeds

                // Fluidized >
                case Byte[] ba: return TryConvert(ba, resultType, out result);
                // < Fluidized

                // Lizatings >
                case JsonElement je:
                    KozmosArgumentNullExceptionHelper.ThrowIfNull(options);
                    return TryConvert(je, options.IParsableConvertOptions, resultType, out result);
                // < Lizatings

                // Numericals >
                case Byte by: return TryConvert(by, resultType, out result);
                case SByte sby: return TryConvert(sby, resultType, out result);
                case UInt16 ui16: return TryConvert(ui16, resultType, out result);
                case Int16 i16: return TryConvert(i16, resultType, out result);
                case UInt32 ui32: return TryConvert(ui32, resultType, out result);
                case Int32 i32: return TryConvert(i32, resultType, out result);
                case UInt64 ui64: return TryConvert(ui64, resultType, out result);
                case Int64 i64: return TryConvert(i64, resultType, out result);
                case UInt128 ui128: return TryConvert(ui128, resultType, out result);
                case Int128 i128: return TryConvert(i128, resultType, out result);
                case BigInteger bi: return TryConvert(bi, resultType, out result);
                case Decimal m: return TryConvert(m, resultType, out result);
                case Single f: return TryConvert(f, resultType, out result);
                case Double d: return TryConvert(d, resultType, out result);
                // < Numericals

                // Temporals >
                case DateOnly don:
                    KozmosArgumentNullExceptionHelper.ThrowIfNull(options);
                    return TryConvert(don, options.DateOnlyComponent, resultType, out result);
                case DateTime dt:
                    KozmosArgumentNullExceptionHelper.ThrowIfNull(options);
                    return TryConvert(dt, options.DateTimeComponent, resultType, out result);
                case DateTimeOffset dto:
                    KozmosArgumentNullExceptionHelper.ThrowIfNull(options);
                    return TryConvert(dto, options.DateTimeOffsetComponent, resultType, out result);
                case TimeOnly to:
                    KozmosArgumentNullExceptionHelper.ThrowIfNull(options);
                    return TryConvert(to, options.TimeOnlyComponent, resultType, out result);
                case TimeSpan ts:
                    KozmosArgumentNullExceptionHelper.ThrowIfNull(options);
                    return TryConvert(ts, options.TimeSpanComponent, resultType, out result);
                // < Temporals

                // Textuals >
                case String s:
                    KozmosArgumentNullExceptionHelper.ThrowIfNull(options);
                    return TryConvert(s, options.IParsableConvertOptions, resultType, out result);
                // < Textuals

                case null:
                    result = default;
                    return IsNullable(resultType);
            }

            KozmosExceptionHelper.ThrowValue_0_OfArgument_1_2_IsNotSupported(source);
            result = null; return false;
        }

        #endregion

        #endregion
    }
}