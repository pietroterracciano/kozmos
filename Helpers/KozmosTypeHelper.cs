using System;
using System.Collections.Generic;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;
using Kozmos.Constants;
using Kozmos.Enums;

namespace Kozmos.Helpers
{
	public static class KozmosTypeHelper
	{
        #region Type

        #region public static Type GetType...(...)

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Type GetType<T>() { return KozmosTypeHelper<T>._; }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Type GetType(Object source)
        {
            // HotPath >
            if (source is Type t) return t;
            // < HotPath
            KozmosArgumentNullExceptionHelper.ThrowIfNull(source);
            return source!.GetType();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Type GetType(Type source)
        {
            KozmosArgumentNullExceptionHelper.ThrowIfNull(source);
            return source;
        }

        #endregion

        #region public static Boolean TryGetType(...)

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean TryGetType<T>(out Type result) { result = KozmosTypeHelper<T>._; return true; }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean TryGetType(Type? source, out Type result) { result = source!; return result is not null; }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean TryGetType(Object? source, out Type result)
        {
            // HotPath >
            if (source is Type t) { result = t; return true; }
            // < HotPath
            else if (source is not null) { result = source.GetType(); return true; }
            result = null!; return false;
        }

        #endregion

        #endregion

        #region EType

        #region public static EKozmosType GetEType(...)

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static EKozmosType GetEType<T>()
        {
            if (TryGetEType(KozmosTypeHelper<T>.Enum, out EKozmosType result)) return result;
            KozmosExceptionHelper<T>.ThrowTheTypeParameter_0_1_IsNotSupported();
            return default;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static EKozmosType GetEType(Object source)
        {
            // HotPath >
            if (source is EKozmosType et) return et;
            // < HotPath
            return GetEType(GetType(source));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static EKozmosType GetEType(Type source)
        {
            KozmosArgumentNullExceptionHelper.ThrowIfNull(source);
            if (__FetchEType(source, out EKozmosType ekt)) return ekt;
            KozmosExceptionHelper.ThrowValue_0_OfArgument_1_2_IsNotSupported(source);
            return default;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static EKozmosType GetEType(EKozmosType? source)
        {
            if (!source.HasValue) KozmosArgumentNullExceptionHelper.Throw(nameof(source));
            return source.Value;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static EKozmosType GetEType(EKozmosType source) { return source; }

        #endregion

        #region public static Boolean TryGetEType...(...)

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean TryGetEType<T>(out EKozmosType result) { return TryGetEType(KozmosTypeHelper<T>.Enum, out result); }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean TryGetEType(EKozmosType? source, out EKozmosType result)
        {
            if (source.HasValue) { result = source.Value; return true; }
            result = default; return false;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean TryGetEType(EKozmosType source, out EKozmosType result)
        {
            result = source;
            return true;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean TryGetEType(Object? source, out EKozmosType result)
        {
            // HotPath >
            if (source is EKozmosType ekt) { result = ekt; return true; }
            // < HotPath
            else if (TryGetType(source, out Type t)) return TryGetEType(t, out result);
            result = default; return false;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean TryGetEType(Type? source, out EKozmosType result)
        {
            if (source is null) { result = default; return false; }
            return __FetchEType(source, out result);
        }

        #endregion

        [MethodImpl(MethodImplOptions.AggressiveOptimization)]
        private static Boolean __FetchEType(Type source, out EKozmosType ekt)
        {
            switch (source)
            {
                #region Codeds

                case Type t0 when t0 == KozmosTypeHelper<Char>._: ekt = KozmosTypeHelper<Char>.Enum!.Value; return true;
                case Type t0 when t0 == KozmosTypeHelper<Char?>._: ekt = KozmosTypeHelper<Char?>.Enum!.Value; return true;

                #endregion

                #region Conditionals

                case Type t0 when t0 == KozmosTypeHelper<Boolean>._: ekt = KozmosTypeHelper<Boolean>.Enum!.Value; return true;
                case Type t0 when t0 == KozmosTypeHelper<Boolean?>._: ekt = KozmosTypeHelper<Boolean?>.Enum!.Value; return true;

                #endregion

                #region Indexings

                case Type t0 when t0 == KozmosTypeHelper<Guid>._: ekt = KozmosTypeHelper<Guid>.Enum!.Value; return true;
                case Type t0 when t0 == KozmosTypeHelper<Guid?>._: ekt = KozmosTypeHelper<Guid?>.Enum!.Value; return true;

                #endregion

                #region Numericals

                case Type t0 when t0 == KozmosTypeHelper<Byte>._: ekt = KozmosTypeHelper<Byte>.Enum!.Value; return true;
                case Type t0 when t0 == KozmosTypeHelper<Byte?>._: ekt = KozmosTypeHelper<Byte?>.Enum!.Value; return true;

                case Type t0 when t0 == KozmosTypeHelper<SByte>._: ekt = KozmosTypeHelper<SByte>.Enum!.Value; return true;
                case Type t0 when t0 == KozmosTypeHelper<SByte?>._: ekt = KozmosTypeHelper<SByte?>.Enum!.Value; return true;

                case Type t0 when t0 == KozmosTypeHelper<UInt16>._: ekt = KozmosTypeHelper<UInt16>.Enum!.Value; return true;
                case Type t0 when t0 == KozmosTypeHelper<UInt16?>._: ekt = KozmosTypeHelper<UInt16?>.Enum!.Value; return true;

                case Type t0 when t0 == KozmosTypeHelper<Int16>._: ekt = KozmosTypeHelper<Int16>.Enum!.Value; return true;
                case Type t0 when t0 == KozmosTypeHelper<Int16?>._: ekt = KozmosTypeHelper<Int16?>.Enum!.Value; return true;

                case Type t0 when t0 == KozmosTypeHelper<UInt32>._: ekt = KozmosTypeHelper<UInt32>.Enum!.Value; return true;
                case Type t0 when t0 == KozmosTypeHelper<UInt32?>._: ekt = KozmosTypeHelper<UInt32?>.Enum!.Value; return true;

                case Type t0 when t0 == KozmosTypeHelper<Int32>._: ekt = KozmosTypeHelper<Int32>.Enum!.Value; return true;
                case Type t0 when t0 == KozmosTypeHelper<Int32?>._: ekt = KozmosTypeHelper<Int32?>.Enum!.Value; return true;

                case Type t0 when t0 == KozmosTypeHelper<UInt64>._: ekt = KozmosTypeHelper<UInt64>.Enum!.Value; return true;
                case Type t0 when t0 == KozmosTypeHelper<UInt64?>._: ekt = KozmosTypeHelper<UInt64?>.Enum!.Value; return true;

                case Type t0 when t0 == KozmosTypeHelper<Int64>._: ekt = KozmosTypeHelper<Int64>.Enum!.Value; return true;
                case Type t0 when t0 == KozmosTypeHelper<Int64?>._: ekt = KozmosTypeHelper<Int64?>.Enum!.Value; return true;

                case Type t0 when t0 == KozmosTypeHelper<UInt128>._: ekt = KozmosTypeHelper<UInt128>.Enum!.Value; return true;
                case Type t0 when t0 == KozmosTypeHelper<UInt128?>._: ekt = KozmosTypeHelper<UInt128?>.Enum!.Value; return true;

                case Type t0 when t0 == KozmosTypeHelper<Int128>._: ekt = KozmosTypeHelper<Int128>.Enum!.Value; return true;
                case Type t0 when t0 == KozmosTypeHelper<Int128?>._: ekt = KozmosTypeHelper<Int128?>.Enum!.Value; return true;

                case Type t0 when t0 == KozmosTypeHelper<BigInteger>._: ekt = KozmosTypeHelper<BigInteger>.Enum!.Value; return true;
                case Type t0 when t0 == KozmosTypeHelper<BigInteger?>._: ekt = KozmosTypeHelper<BigInteger?>.Enum!.Value; return true;

                case Type t0 when t0 == KozmosTypeHelper<Single>._: ekt = KozmosTypeHelper<Single>.Enum!.Value; return true;
                case Type t0 when t0 == KozmosTypeHelper<Single?>._: ekt = KozmosTypeHelper<Single?>.Enum!.Value; return true;

                case Type t0 when t0 == KozmosTypeHelper<Double>._: ekt = KozmosTypeHelper<Double>.Enum!.Value; return true;
                case Type t0 when t0 == KozmosTypeHelper<Double?>._: ekt = KozmosTypeHelper<Double?>.Enum!.Value; return true;

                case Type t0 when t0 == KozmosTypeHelper<Decimal>._: ekt = KozmosTypeHelper<Decimal>.Enum!.Value; return true;
                case Type t0 when t0 == KozmosTypeHelper<Decimal?>._: ekt = KozmosTypeHelper<Decimal?>.Enum!.Value; return true;

                #endregion

                #region Temporals

                #region DateOnly

                case Type t0 when t0 == KozmosTypeHelper<DateOnly>._: ekt = KozmosTypeHelper<DateOnly>.Enum!.Value; return true;
                case Type t0 when t0 == KozmosTypeHelper<DateOnly?>._: ekt = KozmosTypeHelper<DateOnly?>.Enum!.Value; return true;

                #endregion

                #region DateTime

                case Type t0 when t0 == KozmosTypeHelper<DateTime>._: ekt = KozmosTypeHelper<DateTime>.Enum!.Value; return true;
                case Type t0 when t0 == KozmosTypeHelper<DateTime?>._: ekt = KozmosTypeHelper<DateTime?>.Enum!.Value; return true;

                #endregion

                #region DateTimeOffset

                case Type t0 when t0 == KozmosTypeHelper<DateTimeOffset>._: ekt = KozmosTypeHelper<DateTimeOffset>.Enum!.Value; return true;
                case Type t0 when t0 == KozmosTypeHelper<DateTimeOffset?>._: ekt = KozmosTypeHelper<DateTimeOffset?>.Enum!.Value; return true;

                #endregion

                #region TimeSpan

                case Type t0 when t0 == KozmosTypeHelper<TimeSpan>._: ekt = KozmosTypeHelper<TimeSpan>.Enum!.Value; return true;
                case Type t0 when t0 == KozmosTypeHelper<TimeSpan?>._: ekt = KozmosTypeHelper<TimeSpan?>.Enum!.Value; return true;

                #endregion

                #region TimeOnly

                case Type t0 when t0 == KozmosTypeHelper<TimeOnly>._: ekt = KozmosTypeHelper<TimeOnly>.Enum!.Value; return true;
                case Type t0 when t0 == KozmosTypeHelper<TimeOnly?>._: ekt = KozmosTypeHelper<TimeOnly?>.Enum!.Value; return true;

                #endregion

                #endregion

                #region Textuals

                case Type t0 when t0 == KozmosTypeHelper<String>._: ekt = KozmosTypeHelper<String>.Enum!.Value; return true;
                case Type t0 when t0 == KozmosTypeHelper<StringBuilder>._: ekt = KozmosTypeHelper<StringBuilder>.Enum!.Value; return true;

                #endregion

                default: ekt = default; return false;
            }
        }

        #endregion

        #region FullName-Name

        #region public static Boolean GetFullNameOrName(...)

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static String GetFullNameOrName<T>() { return KozmosTypeHelper<T>.FullNameOrName; }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static String GetFullNameOrName(Object source) { Type t = GetType(source); return t.FullName ?? t.Name; }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static String GetFullNameOrName(Type source)
        {
            KozmosArgumentNullExceptionHelper.ThrowIfNull(source);
            return source.FullName ?? source.Name;
        }

        #endregion

        #region public static Boolean TryGetFullNameOrName(...)

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean TryGetFullNameOrName<T>(out String result) { result = KozmosTypeHelper<T>.FullNameOrName; return true; }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean TryGetFullNameOrName(Object? source, out String result)
        {
            if (!TryGetType(source, out Type t)) { result = null!; return false; }
            result = t.FullName ?? t.Name; return true;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean TryGetFullNameOrName(Type? source, out String result)
        {
            if (source is null) { result = null!; return false; }
            result = source.FullName ?? source.Name; return true;
        }

        #endregion

        #endregion

        #region FullName

        #region public static Boolean GetFullName(...)

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static String? GetFullName<T>() { return KozmosTypeHelper<T>.FullName; }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static String? GetFullName(Object source)
        {
            // HotPath >
            if (source is Type t) return t.FullName;
            // < HotPath
            KozmosArgumentNullExceptionHelper.ThrowIfNull(source);
            return source.GetType().FullName;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static String? GetFullName(Type source)
        {
            KozmosArgumentNullExceptionHelper.ThrowIfNull(source);
            return source.FullName;
        }

        #endregion

        #region public static Boolean TryGetFullName(...)

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean TryGetFullName<T>(out String? result) { result= KozmosTypeHelper<T>.FullName; return true; }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean TryGetFullName(Object? source, out String? result)
        {
            if (!TryGetType(source, out Type t)) { result = null; return false; }
            result = t.FullName; return true;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean TryGetFullName(Type? source, out String? result)
        {
            if (source is null) { result = null; return false; }
            result = source.FullName; return true;
        }

        #endregion

        #endregion

        #region Name

        #region public static String GetName...(...)

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static String GetName<T>() { return KozmosTypeHelper<T>.Name; }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static String GetName(Object source)
        {
            // HotPath >
            if (source is Type t) return t.Name;
            // < HotPath
            KozmosArgumentNullExceptionHelper.ThrowIfNull(source);
            return source.GetType().Name;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static String GetName(Type source)
        {
            KozmosArgumentNullExceptionHelper.ThrowIfNull(source);
            return source.Name;
        }

        #endregion

        #region public static Boolean TryGetName(...)

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean TryGetName<T>(out String result) { result = KozmosTypeHelper<T>.Name; return true; }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean TryGetName(Object? source, out String result)
        {
            if(!TryGetType(source, out Type t)) { result = null!; return false; }
            result = t.Name; return true;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean TryGetName(Type? source, out String result)
        {
            if (source is null) { result = null!; return false; }
            result = source.Name; return true;
        }

        #endregion

        #endregion

        #region public static Boolean IsNullable...(...)

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean IsNullable<T>() { return KozmosTypeHelper<T>.IsNullable; }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean IsNullable(Type source)
        {
            KozmosArgumentNullExceptionHelper.ThrowIfNull(source);
            return
                !source.IsValueType
                || Nullable.GetUnderlyingType(source) is not null;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean IsNullable(Object source)
        {
            KozmosArgumentNullExceptionHelper.ThrowIfNull(source);
            return IsNullable(GetType(source));
        }

        #endregion

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void AssertTypeParameterCache<T>()
        {
            KozmosTypeHelper<T>.AssertTypeParameterCache();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void AssertTypeParameterCache<T>(String? name)
        {
            KozmosTypeHelper<T>.AssertTypeParameterCache(name);
        }
    }
}