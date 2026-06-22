using System;
using System.Collections.Generic;
using System.Numerics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using Kozmos.Constants;
using Kozmos.Enums;
using Kozmos.Helpers.Collectibles;
using Kozmos.Helpers.Exceptions;

namespace Kozmos.Helpers
{
	public static class KozmosTypeHelper
	{
        #region GetType / TryGetType

        #region GetType

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Type GetType<T>() { return GetTypeUnsafe<T>(); }

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
        public static Type GetType(Type source) { KozmosArgumentNullExceptionHelper.ThrowIfNull(source); return GetTypeUnsafe(source); }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static Type GetTypeUnsafe<T>() { return KozmosTypeHelper<T>._; }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static Type GetTypeUnsafe(Object source) { if (source is Type t) return t; return source.GetType(); }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static Type GetTypeUnsafe(Type source) { return source; }

        #endregion

        #region TryGetType

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

        #region public static Type GetElementType...(...)

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Type GetElementType<T>() { return GetElementType(GetType<T>()); }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Type GetElementType(Object source) { return GetElementType(GetType(source)); }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Type GetElementType(Type source)
        {
            KozmosArgumentNullExceptionHelper.ThrowIfNull(source);
            if (!source.HasElementType) KozmosArgumentExceptionHelper.ThrowValue_0_OfArgument_1_2_IsNotSupported(source);
            return GetElementType(source);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static Type GetElementTypeUnsafe<T>() { return GetElementTypeUnsafe(GetType<T>()); }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static Type GetElementTypeUnsafe(Object source) { return GetElementTypeUnsafe(GetType(source)); }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static Type GetElementTypeUnsafe(Type source) { return source.GetElementType()!; }

        #endregion

        #region public static Type TryGetElementType...(...)

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean TryGetElementType<T>(out Type result)
        {
            if (!TryGetType<T>(out Type t)) { result = null!; return false; }
            return TryGetElementType(t, out result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean TryGetElementType(Object? source, out Type result)
        {
            if (!TryGetType(source, out Type t)) { result = null!; return false; }
            return TryGetElementType(t, out result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean TryGetElementType(Type? source, out Type result)
        {
            if(source is null || !source.HasElementType) { result = null!; return false; }
            result = source.GetElementType()!; return true;
        }

        #endregion

        #region GenericTypeArguments / GenericTypeArgument

        #region GenericTypeArguments

        #region public static Type[] GetGenericTypeArguments(...)

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Type[] GetGenericTypeArguments<T>() { return GetGenericTypeArguments(GetType<T>()); }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Type[] GetGenericTypeArguments(Object source) { return GetGenericTypeArguments(GetType(source)); }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Type[] GetGenericTypeArguments(Type source)
        {
            KozmosArgumentNullExceptionHelper.ThrowIfNull(source);
            if (!source.IsGenericType || source.IsGenericTypeDefinition) KozmosArgumentExceptionHelper.ThrowValue_0_OfArgument_1_2_IsNotSupported(source);
            return source.GenericTypeArguments;
        }

        #endregion

        #region public static Type TryGetGenericTypeArguments...(...)

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean TryGetGenericTypeArguments<T>(out Type[] result)
        {
            if (!TryGetType<T>(out Type t)) { result = null!; return false; }
            return TryGetGenericTypeArguments(t, out result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean TryGetGenericTypeArguments(Object? source, out Type[] result)
        {
            if (!TryGetType(source, out Type t)) { result = null!; return false; }
            return TryGetGenericTypeArguments(t, out result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean TryGetGenericTypeArguments(Type? source, out Type[] result)
        {
            if (source is null || !source.IsGenericType || source.IsGenericTypeDefinition) { result = null!; return false; }
            result = source.GenericTypeArguments; return true;
        }

        #endregion

        #endregion

        #region GenericTypeArgument

        //#region public static Type GetFirstGenericTypeArgument(...)

        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        //public static Type GetFirstGenericTypeArgument<T>() { return GetGenericTypeArgument(GetType<T>(), 0); }

        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        //public static Type GetFirstGenericTypeArgument(Object source) { return GetGenericTypeArgument(GetType(source), 0); }

        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        //public static Type GetFirstGenericTypeArgument(Type source) { return GetGenericTypeArgument(source, 0); }

        //#endregion

        #region public static Type GetGenericTypeArgument(...)

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Type GetGenericTypeArgument<T>(Int32 index) { return GetGenericTypeArgument(GetType<T>(), index); }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Type GetGenericTypeArgument(Object source, Int32 index) { return GetGenericTypeArgument(GetType(source), index); }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Type GetGenericTypeArgument(Type source, Int32 index) { return GetGenericTypeArguments(source)[index]; }

        #endregion

        #region public static Boolean TryGetGenericTypeArgument...(...)

        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        //public static Boolean TryGetGenericTypeArgument<T>(out Type result, Int32 index)
        //{
        //    if (!TryGetGenericTypeArguments<T>(out Type[] ta)) { result = null!; return false; }
        //    return KozmosArrayHelper.TryGetValue(ta, index, out result);
        //}

        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        //public static Boolean TryGetGenericTypeArgument(Object? source, Int32 index, out Type result)
        //{
        //    if (!TryGetGenericTypeArguments(source, out Type[] ta)) { result = null!; return false; }
        //    return KozmosArrayHelper.TryGetValue(ta, index, out result);
        //}

        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        //public static Boolean TryGetGenericTypeArgument(Type? source, Int32 index, out Type result)
        //{
        //    if(!TryGetGenericTypeArguments(source, out Type[] ta)) { result = null!; return false; }
        //    return KozmosArrayHelper.TryGetValue(ta, index, out result);
        //}

        #endregion

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
            KozmosArgumentExceptionHelper.ThrowValue_0_OfArgument_1_2_IsNotSupported(source);
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