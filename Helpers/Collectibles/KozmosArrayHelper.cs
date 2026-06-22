using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kozmos.Helpers.Exceptions;
using Kozmos.Helpers.Numericals;

namespace Kozmos.Helpers.Collectibles
{
	public static class KozmosArrayHelper
	{
        #region IsValidDimension

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean IsValidDimension(Array? source, Int32 dimension) { return source is not null && IsValidDimensionUnsafe(source!, dimension); }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static Boolean IsValidDimensionUnsafe(Array source, Int32 dimension) { return (UInt32)dimension < (UInt32)source.Rank; }

        #endregion

        #region IsValidIndexInDimension

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean IsValidIndexInDimension(Array? source, Int32 dimension, Int64 index)
        {
            return IsValidDimension(source, dimension) && IsValidIndexInDimensionUnsafe(source!, dimension, index);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static Boolean IsValidIndexInDimensionUnsafe(Array source, Int32 dimension, Int64 index)
        {
            return KozmosInt64Helper.IsInRange(index, source.GetLowerBound(dimension), source.GetUpperBound(dimension));
        }

        #endregion

        #region IsValidIndex

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean IsValidIndex(Array? source, Int64 index)
        {
            return IsValidDimension(source, 1) && IsValidIndex_Unsafe(source!, index);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static Boolean IsValidIndex_Unsafe(Array source, Int64 index)
        {
            return IsValidIndexInDimensionUnsafe(source, 0, index);
        }

        #endregion

        #region IsElementType

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean IsElementType<T>(Array? source) { return source is not null && IsElementTypeUnsafe<T>(source); }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static Boolean IsElementTypeUnsafe<T>(Array source) { return source is T[]; }

        #endregion

        #region IsValidIndexes

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean IsValidIndexes(Array? source, Int64 index0, Int64 index1)
        {
            return IsValidDimension(source, 2) && IsValidIndexesUnsafe(source!, index0, index1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static Boolean IsValidIndexesUnsafe(Array source, Int64 index0, Int64 index1)
        {
            return IsValidIndex_Unsafe(source, index0) && IsValidIndexInDimensionUnsafe(source, 1, index1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean IsValidIndexes(Array? source, Int64 index0, Int64 index1, Int64 index2)
        {
            return IsValidDimension(source, 3) && IsValidIndexesUnsafe(source!, index0, index1, index2);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static Boolean IsValidIndexesUnsafe(Array source, Int64 index0, Int64 index1, Int64 index2)
        {
            return IsValidIndexesUnsafe(source, index0, index1) && IsValidIndexInDimensionUnsafe(source, 2, index2);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean IsValidIndexes(Array? source, Int64 index0, Int64 index1, Int64 index2, Int64 index3)
        {
            return IsValidDimension(source, 4) && IsValidIndexesUnsafe(source!, index0, index1, index2, index3);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static Boolean IsValidIndexesUnsafe(Array source, Int64 index0, Int64 index1, Int64 index2, Int64 index3)
        {
            return IsValidIndexesUnsafe(source, index0, index1, index2) && IsValidIndexInDimensionUnsafe(source, 3, index3);
        }

        [MethodImpl(MethodImplOptions.AggressiveOptimization)]
        public static Boolean IsValidIndexes(Array? source, Int64 index0, Int64 index1, Int64 index2, Int64 index3, params Int64[]? indexes)
        {
            if
            (
                source is null
                || !IsValidIndexesUnsafe(source, index0, index1, index2, index3)
                || indexes is null
                || source.Rank != (4 + indexes.Length)
            )
                return false;

            ref var indexesPointer = ref MemoryMarshal.GetArrayDataReference(indexes);

            Int32 i = 4;
            while (i < source.Rank)
            {
                if (!IsValidIndexInDimensionUnsafe(source, i, indexesPointer)) return false;
                indexesPointer = ref Unsafe.Add(ref indexesPointer, 1); i++;
            }

            return true;
        }

        #endregion

        #region GetElementType / TryGetElementType

        #region GetElementType

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Type GetElementType(Array source)
        {
            KozmosArgumentNullExceptionHelper.ThrowIfNull(source);
            return GetElementType_Unsafe(source);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static Type GetElementType_Unsafe(Array source)
        {
            return GetElementType_Unsafe(source.GetType());
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Type GetElementType(Type source)
        {
            KozmosArgumentNullExceptionHelper.ThrowIfNull(source);
            __EnsureIsArray(source);
            return GetElementType_Unsafe(source);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static Type GetElementType_Unsafe(Type source)
        {
            return source.GetElementType()!;
        }

        #endregion

        #region TryGetElementType

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean TryGetElementType(Array? source, out Type? result)
        {
            if (source is null) { result = null; return false; }
            result = GetElementType_Unsafe(source); return true;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean TryGetElementType(Type? source, out Type? result)
        {
            if (source is null || !source.IsArray) { result = null; return false; }
            result = GetElementType_Unsafe(source); return true;
        }

        #endregion

        #endregion

        #region GetValue... / TryGetValue...

        #region GetValue...

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T? GetValue<T>(Array source, Int64 index)
        {
            KozmosArgumentNullExceptionHelper.ThrowIfNull(source);
            return GetValue_Unsafe<T>(source, index);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static T? GetValue_Unsafe<T>(Array source, Int64 index)
        {
            if (source is T[] source0) return source0[index];
            return (T?)GetValue_Unsafe(source, index);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Object? GetValue(Array source, Int64 index)
        {
            KozmosArgumentNullExceptionHelper.ThrowIfNull(source);
            return GetValue_Unsafe(source, index);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static Object? GetValue_Unsafe(Array source, Int64 index)
        {
            return source.GetValue(index);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T? GetValue<T>(Array source, Int64 index0, Int64 index1)
        {
            KozmosArgumentNullExceptionHelper.ThrowIfNull(source);
            return GetValue_Unsafe<T>(source, index0, index1);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static T? GetValue_Unsafe<T>(Array source, Int64 index0, Int64 index1)
        {
            switch (source)
            {
                case T[,] source0: return source0[index0, index1];
                case T[][] source0: return source0[index0][index1];
                default: return (T?)GetValue_Unsafe(source, index0, index1);
            }
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Object? GetValue(Array source, Int64 index0, Int64 index1)
        {
            KozmosArgumentNullExceptionHelper.ThrowIfNull(source);
            return GetValue_Unsafe(source, index0, index1);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static Object? GetValue_Unsafe(Array source, Int64 index0, Int64 index1)
        {
            if (source.Rank < 2) return GetValue_Unsafe<Array>(source, index0)!.GetValue(index1);
            return source.GetValue(index0, index1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T? GetValue<T>(Array source, Int64 index0, Int64 index1, Int64 index2)
        {
            KozmosArgumentNullExceptionHelper.ThrowIfNull(source);
            return GetValue_Unsafe<T>(source, index0, index1, index2);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static T? GetValue_Unsafe<T>(Array source, Int64 index0, Int64 index1, Int64 index2)
        {
            switch (source)
            {
                case T[][,] source0: return source0[index0][index1,index2];
                case T[,][] source0: return source0[index0, index1][index2];
                case T[,,] source0: return source0[index0, index1, index2];
                case T[][][] source0: return source0[index0][index1][index2];
                default: return (T?)GetValue_Unsafe(source, index0, index1, index2);
            }
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Object? GetValue(Array source, Int64 index0, Int64 index1, Int64 index2)
        {
            KozmosArgumentNullExceptionHelper.ThrowIfNull(source);
            return GetValue_Unsafe(source, index0, index1, index2);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static Object? GetValue_Unsafe(Array source, Int64 index0, Int64 index1, Int64 index2)
        {
            switch(source.Rank)
            {
                case 1: return GetValue_Unsafe(GetValue_Unsafe<Array>(source, index0)!, index1, index2);
                case 2: return GetValue_Unsafe<Array>(source, index0, index1)!.GetValue(index2);
                default: return source.GetValue(index0, index1, index2);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T? GetValue<T>(Array source, Int64 index0, Int64 index1, Int64 index2, params Int64[]? indexes)
        {
            KozmosArgumentNullExceptionHelper.ThrowIfNull(source);
            return GetValue_Unsafe<T>(source, index0, index1, index2, indexes);
        }

        [MethodImpl(MethodImplOptions.AggressiveOptimization)]
        internal static T? GetValue_Unsafe<T>(Array source, Int64 index0, Int64 index1, Int64 index2, ReadOnlySpan<Int64> indexes)
        {
            if (indexes.Length < 1) return GetValue_Unsafe<T>(source, index0, index1, index2);
            return (T?)GetValue_Unsafe(source, index0, index1, index2, indexes);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Object? GetValue(Array source, Int64 index0, Int64 index1, Int64 index2, params Int64[]? indexes)
        {
            KozmosArgumentNullExceptionHelper.ThrowIfNull(source);
            return GetValue_Unsafe(source, index0, index1, index2, indexes);
        }

        [MethodImpl(MethodImplOptions.AggressiveOptimization)]
        internal static Object? GetValue_Unsafe(Array source, Int64 index0, Int64 index1, Int64 index2, ReadOnlySpan<Int64> indexes)
        {
            if(indexes.Length < 1) return GetValue_Unsafe(source, index0, index1, index2);

            switch (source.Rank)
            {
                case 1: return GetValue_Unsafe(GetValue_Unsafe<Array>(source, index0)!, index1, index2, indexes[0], indexes.Slice(1));
                case 2: return GetValue_Unsafe(GetValue_Unsafe<Array>(source, index0, index1)!, index2, indexes[0], indexes[1], indexes.Slice(2));
                case 3: return GetValue_Unsafe(GetValue_Unsafe<Array>(source, index0, index1, index2)!, indexes[0], indexes[1], indexes[2], indexes.Slice(3));
            }

            //KozmosArgumentOutOfRangeExceptionHelper.ThrowIfGreaterThan(source.Rank, 3 + indexes.Length);

            Int64[] indexes0 = new Int64[source.Rank];
            indexes0[0] = index0;
            indexes0[1] = index1;
            indexes0[2] = index2;

            for (int i = 3; i < indexes0.Length; i++) indexes0[i] = indexes[i - 3];

            Object? o = source.GetValue(indexes0);

            Int32 indexesDelta = 3 + indexes.Length - source.Rank;

            if (indexesDelta < 1) return o;

            Array source0 = (Array)o!;

            KozmosInvalidOperationExceptionHelper.ThrowIfNull(source0);

            indexes = indexes.Slice(indexes.Length - indexesDelta);

            switch (indexes.Length)
            {
                case 0: KozmosArgumentOutOfRangeExceptionHelper.Throw(); return null;
                case 1: return GetValue_Unsafe(source0, indexes[0]);
                case 2: return GetValue_Unsafe(source0, indexes[0], indexes[1]);
                case 3: return GetValue_Unsafe(source0, indexes[0], indexes[1], indexes[2]);
                default: return GetValue_Unsafe(source0, indexes[0], indexes[1], indexes[2], indexes.Slice(3));
            }
        }

        #endregion

        #region TryGetValue

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean TryGetValue<T>(Array source, Int64 index, out T? result)
        {
            if (source is null || !IsValidIndex_Unsafe(source, index)) { result = default; return false; }
            result = GetValue_Unsafe<T>(source, index); return true;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean TryGetValue(Array source, Int64 index, out Object? result)
        {
            if(source is null || !IsValidIndex_Unsafe(source, index)) { result = null; return false; }
            result = GetValue_Unsafe(source, index); return true;
        }

        #endregion

        #endregion

        #region SetValue... / TrySetValue...

        #region SetValue...

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetValue<T>(Array source, T value, Int64 index)
        {
            KozmosArgumentNullExceptionHelper.ThrowIfNull(source);
            SetValue_Unsafe(source, value, index);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void SetValue_Unsafe<T>(Array source, T value, Int64 index)
        {
            if (source is T[] source0) { source0[index] = value; return; }
            source.SetValue(value, index);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetValue<T>(Array source, T value, Int64 index0, Int64 index1)
        {
            KozmosArgumentNullExceptionHelper.ThrowIfNull(source);
            SetValue_Unsafe(source, value, index0, index1);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void SetValue_Unsafe<T>(Array source, T value, Int64 index0, Int64 index1)
        {
            switch (source)
            {
                case T[,] source0: source0[index0, index1] = value; return;
                case T[][] source0: source0[index0][index1] = value; return;
            }

            if (source.Rank < 2) { SetValue(GetValue_Unsafe<Array>(source, index0)!, value, index1); return; }
            source.SetValue(value, index0, index1); return;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetValue<T>(Array source, T value, Int64 index0, Int64 index1, Int64 index2)
        {
            KozmosArgumentNullExceptionHelper.ThrowIfNull(source);
            SetValue_Unsafe(source, value, index0, index1, index2);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void SetValue_Unsafe<T>(Array source, T value, Int64 index0, Int64 index1, Int64 index2)
        {
            switch (source)
            {
                case T[][,] source0: source0[index0][index1, index2] = value; return;
                case T[,][] source0: source0[index0, index1][index2] = value; return;
                case T[,,] source0: source0[index0, index1, index2] = value; return;
                case T[][][] source0: source0[index0][index1][index2] = value; return;
            }

            switch (source.Rank)
            {
                case 1: SetValue_Unsafe(GetValue_Unsafe<Array>(source, index0)!, value, index1, index2); return;
                case 2: SetValue_Unsafe(GetValue_Unsafe<Array>(source, index0, index1)!, value, index2); return;
                default: source.SetValue(value, index0, index1, index2); return;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetValue<T>(Array source, T value, Int64 index0, Int64 index1, Int64 index2, params Int64[]? indexes)
        {
            KozmosArgumentNullExceptionHelper.ThrowIfNull(source);
            SetValue_Unsafe(source, value, index0, index1, index2, indexes);
        }

        [MethodImpl(MethodImplOptions.AggressiveOptimization)]
        internal static void SetValue_Unsafe<T>(Array source, T value, Int64 index0, Int64 index1, Int64 index2, ReadOnlySpan<Int64> indexes)
        {
            if (indexes.Length < 1) { SetValue_Unsafe(source, value, index0, index1, index2); return; }

            switch (source.Rank)
            {
                case 1: SetValue_Unsafe(GetValue_Unsafe<Array>(source, index0)!, value, index1, index2, indexes[0], indexes.Slice(1)); return;
                case 2: SetValue_Unsafe(GetValue_Unsafe<Array>(source, index0, index1)!, value, index2, indexes[0], indexes[1], indexes.Slice(2)); return;
                case 3: SetValue_Unsafe(GetValue_Unsafe<Array>(source, index0, index1, index2)!, value, indexes[0], indexes[1], indexes[2], indexes.Slice(3)); return;
            }

            Int64[] indexes0 = new Int64[source.Rank];
            indexes0[0] = index0;
            indexes0[1] = index1;
            indexes0[2] = index2;

            for (int i = 3; i < indexes0.Length; i++) indexes0[i] = indexes[i - 3];

            Int32 indexesDelta = 3 + indexes.Length - source.Rank;

            if (indexesDelta < 1) { source.SetValue(value, indexes0); return; }

            Array source0 = (Array)source.GetValue(indexes0)!;

            KozmosInvalidOperationExceptionHelper.ThrowIfNull(source0);

            indexes = indexes.Slice(indexes.Length - indexesDelta);

            switch (indexes.Length)
            {
                case 0: KozmosInvalidOperationExceptionHelper.Throw(); return;
                case 1: SetValue_Unsafe(source0, value, indexes[0]); return;
                case 2: SetValue_Unsafe(source0, value, indexes[0], indexes[1]); return;
                case 3: SetValue_Unsafe(source0, value, indexes[0], indexes[1], indexes[2]); return;
                default: SetValue_Unsafe(source0, value, indexes[0], indexes[1], indexes[2], indexes.Slice(3)); return;
            }
        }

        #endregion

        #region TryGetValue


        #endregion

        #endregion

        //#region Copy / TryCopy

        //#region Copy

        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        //public static T[] Copy<T>(T[] source)
        //{
        //    KozmosArgumentNullExceptionHelper.ThrowIfNull(source);
        //    return Copy_Unsafe(source);
        //}
        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        //internal static T[] Copy_Unsafe<T>(T[] source)
        //{
        //    return Copy_Unsafe(source, 0, source.LongLength);
        //}
        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        //public static T[] Copy<T>(T[] source, Int64 startIndex, Int64 longLength)
        //{
        //    KozmosArgumentNullExceptionHelper.ThrowIfNull(source);
        //    return Copy_Unsafe(source, startIndex, longLength);
        //}
        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        //internal static T[] Copy_Unsafe<T>(T[] source, Int64 startIndex, Int64 longLength)
        //{
        //    T[] destination = new T[longLength];
        //    Array.Copy(source, startIndex, destination, 0L, longLength);
        //    return destination;
        //}

        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        //public static Array Copy(Array source)
        //{
        //    KozmosArgumentNullExceptionHelper.ThrowIfNull(source);
        //    return Copy_Unsafe(source);
        //}
        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        //internal static Array Copy_Unsafe(Array source)
        //{
        //    switch(source.Rank)
        //    {
        //        case 1: return Copy_Unsafe(source, source.LongLength);
        //        case 2: return Copy_Unsafe(source, source.GetLongLength(0), source.GetLongLength(1));
        //        case 3: return Copy_Unsafe(source, source.GetLongLength(0), source.GetLongLength(1), source.GetLongLength(2));
        //        default: KozmosNotSupportedExceptionHelper.Throw(); return null;
        //    }
        //}

        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        //public static Array Copy(Array source, Int64 longLength0)
        //{
        //    KozmosArgumentNullExceptionHelper.ThrowIfNull(source);
        //    return Copy_Unsafe(source, longLength0);
        //}
        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        //internal static Array Copy_Unsafe(Array source, Int64 longLength0)
        //{
        //    Array destination =
        //        longLength0 > Int32.MaxValue
        //            ? Array.CreateInstance(GetElementType_Unsafe(source), longLength0)
        //            : Array.CreateInstance(GetElementType_Unsafe(source), (Int32)longLength0);

        //    Array.Copy(source, 0L, destination, 0L, source.LongLength);

        //    return destination;
        //}


        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        //public static Array Copy(Array source, Int64 longLength0, Int64 longLength1)
        //{
        //    KozmosArgumentNullExceptionHelper.ThrowIfNull(source);
        //    return Copy_Unsafe(source, longLength0, longLength1);
        //}
        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        //internal static Array Copy_Unsafe(Array source, Int64 longLength0, Int64 longLength1)
        //{
        //    Array destination =
        //        longLength0 > Int32.MaxValue
        //        || longLength1 > Int32.MaxValue
        //            ? Array.CreateInstance(GetElementType_Unsafe(source), longLength0, longLength1)
        //            : Array.CreateInstance(GetElementType_Unsafe(source), (Int32)longLength0, (Int32)longLength1);

        //    Array.Copy(source, 0L, destination, 0L, source.LongLength);

        //    return destination;
        //}

        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        //public static Array Copy(Array source, Int64 longLength0, Int64 longLength1, Int64 longLength2)
        //{
        //    KozmosArgumentNullExceptionHelper.ThrowIfNull(source);
        //    return Copy_Unsafe(source, longLength0, longLength1, longLength2);
        //}
        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        //internal static Array Copy_Unsafe(Array source, Int64 longLength0, Int64 longLength1, Int64 longLength2)
        //{
        //    Array destination =
        //        longLength0 > Int32.MaxValue
        //        || longLength1 > Int32.MaxValue
        //        || longLength2 > Int32.MaxValue
        //            ? Array.CreateInstance(GetElementType_Unsafe(source), longLength0, longLength1, longLength2)
        //            : Array.CreateInstance(GetElementType_Unsafe(source), (Int32)longLength0, (Int32)longLength1, (Int32)longLength2);

        //    Array.Copy(source, 0L, destination, 0L, source.LongLength);

        //    return destination;
        //}

        //#endregion


        //#endregion



        //#region Copy / TryCopy

        //#endregion

        //#region CopyTo / TryCopyTo

        //#region 1D

        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        //public static void CopyTo<T>(T[] source, T[] destination) { __Guard(source); __Guard(destination); __CopyTo(source, destination); }
        //[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        //private static void __CopyTo<T>(T[] source, T[] destination) { __CopyTo(source, 0, destination); }

        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        //public static void CopyTo<T>(T[] source, T[] destination, Int32 length) { __Guard(source); __Guard(destination); __CopyTo(source, destination, length); }
        //[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        //private static void __CopyTo<T>(T[] source, T[] destination, Int32 length) { __CopyTo(source, 0, destination, 0, length); }

        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        //public static void CopyTo<T>(T[] source, T[] destination, Int32 destinationIndex, Int32 length)
        //{
        //    __Guard(source); __Guard(destination);
        //    __CopyTo(source, destination, destinationIndex, length);
        //}
        //[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        //private static void __CopyTo<T>(T[] source, T[] destination, Int32 destinationIndex, Int32 length) { __CopyTo(source, 0, destination, destinationIndex, length); }

        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        //public static void CopyTo<T>(T[] source, Int32 sourceIndex, T[] destination) { __Guard(source); __Guard(destination); __CopyTo(source, sourceIndex, destination); }
        //[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        //private static void __CopyTo<T>(T[] source, Int32 sourceIndex, T[] destination) { __CopyTo(source, sourceIndex, destination, 0); }

        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        //public static void CopyTo<T>(T[] source, Int32 sourceIndex, T[] destination, Int32 destinationIndex)
        //{
        //    __Guard(source); __Guard(destination);
        //    __CopyTo(source, sourceIndex, destination, destinationIndex);
        //}
        //[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        //private static void __CopyTo<T>(T[] source, Int32 sourceIndex, T[] destination, Int32 destinationIndex)
        //{
        //    __CopyTo(source, sourceIndex, destination, destinationIndex, Math.Min(source.Length, destination.Length));
        //}

        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        //public static void CopyTo<T>(T[] source, Int32 sourceIndex, T[] destination, Int32 destinationIndex, Int32 length)
        //{
        //    __Guard(source); __Guard(destination);
        //    __CopyTo(source, sourceIndex, destination, destinationIndex, Math.Min(source.Length, destination.Length));
        //}
        //[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        //private static void __CopyTo<T>(T[] source, Int32 sourceIndex, T[] destination, Int32 destinationIndex, Int32 length)
        //{
        //    __Guard(source, sourceIndex);
        //    __Guard(destination, destinationIndex);
        //    var sourceBound = KozmosBound.From(source, sourceIndex, length);
        //    if(!sourceBound.IsValid) KozmosArgumentOutOfRangeExceptionHelper.Throw();
        //    var destinationBound = KozmosBound.From(destination, destinationIndex, length);
        //    if(!destinationBound.IsValid) KozmosArgumentOutOfRangeExceptionHelper.Throw();

        //    Array.Copy(source, sourceIndex, destination, destinationIndex, length);
        //}

        //#endregion

        //[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
        //public static void Copy(Array source, Array destination)
        //{
        //    // 1. Guardie fondamentali
        //    if (source is null || destination is null) return;
        //    if (source.Length > destination.Length) return;

        //    // 2. Estrazione dei tipi dei metadati dell'array
        //    Type sourceType = source.GetType().GetElementType()!;
        //    Type destType = destination.GetType().GetElementType()!;

        //    // 3. Controllo di compatibilità dei tipi (Cruciale per i Reference Types)
        //    if (sourceType != destType && !destType.IsAssignableFrom(sourceType))
        //    {
        //        throw new ArgumentException("Kozmos: I tipi degli elementi dell'array di origine non sono assegnabili alla destinazione.");
        //    }

        //    // 5. HOT PATH: Reference Types (Classi, Stringhe, Oggetti)
        //    // Usiamo il trucco del Cast invisibile per agganciare lo Span del CLR
        //    if (source is Object[] sourceObjArray && destination is Object[] destObjArray)
        //    {
        //        // Otteniamo gli span nativi di puntatori a oggetti. 
        //        // Questo attiva automaticamente le GC Write Barriers di .NET necessarie per la stabilità!
        //        ReadOnlySpan<Object> sourceSpan = sourceObjArray.AsSpan(0, source.Length);
        //        Span<Object> destSpan = destObjArray.AsSpan(0, source.Length);

        //        sourceSpan.CopyTo(destSpan);
        //        return;
        //    }

        //    // 6. COLD PATH: Array Multidimensionali Jagged/Nativi di oggetti (es. Object[,] o Object[][])
        //    // Se falliscono i passaggi sopra, ci affidiamo alla copia intrinseca ottimizzata di Microsoft
        //    Array.Copy(source, destination, source.Length);
        //}

        #region __Ensure

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static Array __EnsureNotNullAndReturn(Array source, [CallerArgumentExpression(nameof(source))] String? sourceName = null)
        {
            KozmosArgumentNullExceptionHelper.ThrowIfNull(source, sourceName);
            return source;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void __EnsureIsArray(Type source, [CallerArgumentExpression(nameof(source))] String? sourceName = null)
        {
            if (source.IsArray) return;
            KozmosArgumentExceptionHelper.ThrowValue_0_OfArgument_1_2_IsNotSupported(source);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void __EnsureIsElementType<T>(Array source, [CallerArgumentExpression(nameof(source))] String? sourceName = null)
        {
            if (IsElementTypeUnsafe<T>(source)) return;
            KozmosArgumentOutOfRangeExceptionHelper.Throw();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void __EnsureIsValidIndex(Array source, Int64 index, [CallerArgumentExpression(nameof(source))] String? sourceName = null)
        {
            if (IsValidIndex_Unsafe(source, index)) return;
            KozmosArgumentOutOfRangeExceptionHelper.Throw();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void __EnsureIsValidIndexInDimension(Array source, Int32 dimension, Int64 index, [CallerArgumentExpression(nameof(source))] String? sourceName = null)
        {
            if (IsValidIndexInDimensionUnsafe(source, dimension, index)) return;
            KozmosArgumentOutOfRangeExceptionHelper.Throw();
        }

        #endregion

        #region __Guard / __TryGuard

        #region Guard


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void __IsValidDimensionGuard(Array source, Int32 dimension, [CallerArgumentExpression(nameof(dimension))] String? dimensionName = null)
        {
            if (IsValidDimensionUnsafe(source, dimension)) return;
            KozmosArgumentOutOfRangeExceptionHelper.Throw();
        }

        #endregion

        #region TryGuard

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static Boolean __TryIsArrayGuard(Type source) { return source.IsArray; }

        #endregion



        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void __GetDimensionMetas
        (
            Array source,
            Int32 dimension,
            out Int64 longLength,
            out Int64 lowerBound,
            out Int64 upperBound
        )
        {
            longLength = source.GetLongLength(dimension);
            lowerBound = source.GetLowerBound(dimension);
            upperBound = source.GetUpperBound(dimension);
        }

        #endregion
    }
}