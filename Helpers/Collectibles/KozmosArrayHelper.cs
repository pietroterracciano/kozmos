using System;
using System.Runtime.CompilerServices;
using Kozmos.Helpers.Exceptions;

namespace Kozmos.Helpers.Collectibles
{
	public static class KozmosArrayHelper
	{
        #region 1D

        #region T[]

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean IsJagged<T>(T[]? source) { return false; }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean IsValidDimension<T>(T[]? source, Int32 dimension) { return source is not null && (UInt32)dimension < 1; }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean IsValidIndex<T>(T[]? source, Int32 index)
        {
            return
                source is not null
                && (UInt32)index < (UInt32)source.Length;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean TryGetValue<T>(T[]? source, Int32 index, out T result)
        {
            if (!IsValidIndex(source, index)) { result = default!; return false; }
            result = source![index]; return true;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean TryGetElementType<T>(T[]? source, out Type result) { result = KozmosTypeHelper<T>._; return true; }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Type GetElementType<T>(T[] source) { return KozmosTypeHelper<T>._; }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Split<T>(T[] source, Int32 index, out T[] leftResult, out T[] rightResult)
        {
            if (!IsValidIndex(source, index)) KozmosArgumentOutOfRangeExceptionHelper.Throw(source);
            leftResult = new T[index];
            rightResult = new T[source.Length - index];
            Array.Copy(source, 0, leftResult, 0, leftResult.Length);
            Array.Copy(source, index, rightResult, 0, rightResult.Length);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean TrySplit<T>(T[] source, Int32 index, out T[] leftResult, out T[] rightResult)
        {
            if (!IsValidIndex(source, index)) { leftResult = null!; rightResult = null!; return false; }
            leftResult = new T[index];
            rightResult = new T[source.Length - index];
            Array.Copy(source, 0, leftResult, 0, leftResult.Length);
            Array.Copy(source, index, rightResult, 0, rightResult.Length);
            return true;
        }

        #endregion

        #region Array

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean IsValidIndex(Array? source, Int32 index)
        {
            return IsValidIndexInDimension(source, 0, index);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean TryGetValue<T>(Array? source, Int32 index, out T? result)
        {
            if (!TryGetValue(source, index, out Object? o)) { result = default!; return false; }
            return KozmosObjectHelper.TryCast(o, out result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean TryGetValue(Array? source, Int32 index, out Object? result)
        {
            if (!IsValidIndex(source, index)) { result = default!; return false; }
            result = source!.GetValue(index); return true;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean TryCreateInstance(Array? source, Int32 length, out Array result)
        {
            if (!TryGetElementType(source, out Type t)) { result = null!; return false; }
            return TryCreateInstance(t, length, out result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean TryCreateInstance(Object? source, Int32 length, out Array result)
        {
            if (!TryGetElementType(source, out Type t)) { result = null!; return false; }
            return TryCreateInstance(t, length, out result);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static Boolean TryCreateInstance(Type? elementType, Int32 length, out Array result)
        {
            if (elementType is null || length < 0) { result = null!; return false; }
            try { result = Array.CreateInstance(elementType, length); return true; }
            catch { result = null!; return false; }
        }


        #endregion

        #endregion

        #region 1D-2D

        #region T[][,]

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean IsJagged<T>(T[][,]? source) { return source is not null; }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean IsValidDimension<T>(T[][,]? source, Int32 dimension) { return source is not null && (UInt32)dimension < 1; }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean IsValidPosition<T>(T[][,]? source, Int32 index0, Int32 index1, Int32 index2)
        {
            return
                IsValidIndex(source, index0)
                && IsValidPosition(source![index0], index1, index2);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean TryGetValue<T>(T[][,]? source, Int32 index0, Int32 index1, Int32 index2, out T result)
        {
            if (!IsValidPosition(source, index0, index1, index2)) { result = default!; return false; }
            result = source![index0][index1,index2]; return true;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean TryGetElementType<T>(T[][,]? source, out Type result) { result = KozmosTypeHelper<T[,]>._; return true; }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Type GetElementType<T>(T[][,] source) { return KozmosTypeHelper<T[,]>._; }

        #endregion

        #endregion

        #region 1D-3D

        #region T[][,,]

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean IsJagged<T>(T[][,,]? source) { return source is not null; }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean IsValidDimension<T>(T[][,,]? source, Int32 dimension) { return source is not null && (UInt32)dimension < 1; }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean IsValidPosition<T>(T[][,,]? source, Int32 index0, Int32 index1, Int32 index2, Int32 index3)
        {
            return
                IsValidIndex(source, index0)
                && IsValidPosition(source![index0], index1, index2, index3);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean TryGetValue<T>(T[][,,]? source, Int32 index0, Int32 index1, Int32 index2, Int32 index3, out T result)
        {
            if (!IsValidPosition(source, index0, index1, index2, index3)) { result = default!; return false; }
            result = source![index0][index1, index2, index3]; return true;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean TryGetElementType<T>(T[][,,]? source, out Type result) { result = KozmosTypeHelper<T[,,]>._; return true; }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Type GetElementType<T>(T[][,,] source) { return KozmosTypeHelper<T[,,]>._; }

        #endregion

        #endregion

        #region 1D-4D

        #region T[][,,,]

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean IsJagged<T>(T[][,,,]? source) { return source is not null; }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean IsValidDimension<T>(T[][,,,]? source, Int32 dimension) { return source is not null && (UInt32)dimension < 1; }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean IsValidPosition<T>(T[][,,,]? source, Int32 index0, Int32 index1, Int32 index2, Int32 index3, Int32 index4)
        {
            return
                IsValidIndex(source, index0)
                && IsValidPosition(source![index0], index1, index2, index3, index4);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean TryGetValue<T>(T[][,,,]? source, Int32 index0, Int32 index1, Int32 index2, Int32 index3, Int32 index4, out T result)
        {
            if (!IsValidPosition(source, index0, index1, index2, index3, index4)) { result = default!; return false; }
            result = source![index0][index1, index2, index3, index4]; return true;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean TryGetElementType<T>(T[][,,,]? source, out Type result) { result = KozmosTypeHelper<T[,,,]>._; return true; }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Type GetElementType<T>(T[][,,,] source) { return KozmosTypeHelper<T[,,,]>._; }

        #endregion

        #endregion

        #region 2D

        #region T[,]

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean IsJagged<T>(T[,]? source) { return false; }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean IsValidDimension<T>(T[,]? source, Int32 dimension) { return source is not null && (UInt32)dimension < 2; }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean IsValidPosition<T>(T[,]? source, Int32 index0, Int32 index1)
        {
            return
                source is not null
                && (UInt32)index0 < (UInt32)source.GetLength(0)
                && (UInt32)index1 < (UInt32)source.GetLength(1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean TryGetValue<T>(T[,]? source, Int32 index0, Int32 index1, out T result)
        {
            if (!IsValidPosition(source, index0, index1)) { result = default!; return false; }
            result = source![index0, index1]; return true;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean TryGetElementType<T>(T[,]? source, out Type result) { result = KozmosTypeHelper<T>._; return true; }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Type GetElementType<T>(T[,] source) { return KozmosTypeHelper<T>._; }

        #endregion

        #region T[][]

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean IsJagged<T>(T[][]? source) { return source is not null; }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean IsValidDimension<T>(T[][]? source, Int32 dimension) { return source is not null && (UInt32)dimension < 1; }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean IsValidPosition<T>(T[][]? source, Int32 index0, Int32 index1)
        {
            return
                IsValidIndex(source, index0)
                && IsValidIndex(source![index0], index1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean TryGetValue<T>(T[][]? source, Int32 index0, Int32 index1, out T result)
        {
            if (!IsValidPosition(source, index0, index1)) { result = default!; return false; }
            result = source![index0][index1]; return true;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean TryGetElementType<T>(T[][]? source, out Type result) { result = KozmosTypeHelper<T[]>._; return true; }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Type GetElementType<T>(T[][] source) { return KozmosTypeHelper<T[]>._; }

        #endregion

        #region Array

        [MethodImpl(MethodImplOptions.AggressiveOptimization)]
        public static Boolean IsValidPosition(Array? source, Int32 index0, Int32 index1)
        {
            if (source is null) return false;
            switch(source.Rank)
            {
                case 2:
                    return
                        IsValidIndexInDimension(source, 0, index0)
                        && IsValidIndexInDimension(source, 1, index1);
                case 1:
                    if
                    (
                        !IsValidIndex(source, index0)
                        || !TryGetValue<Array>(source, index0, out Array? a)
                        || a is null
                    )
                        return false;

                    return IsValidIndex(a, index1);

                default:
                    return false;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean TryGetValue<T>(Array? source, Int32 index0, Int32 index1, out T? result)
        {
            if (!TryGetValue(source, index0, index1, out Object? o)) { result = default!; return false; }
            return KozmosObjectHelper.TryCast(o, out result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean TryGetValue(Array? source, Int32 index0, Int32 index1, out Object? result)
        {
            if (!IsValidPosition(source, index0, index1)) { result = default!; return false; }

            switch (source!.Rank)
            {
                case 2:
                    result = source!.GetValue(index0, index1);
                    return true;
                case 1:
                    Object? o = source!.GetValue(index0);
                    result = Unsafe.As<Array>(o)!.GetValue(index1);
                    return true;
                default:
                    result = null!;
                    return false;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean TryCreateInstance(Array? source, Int32 length0, Int32 length1, out Array result)
        {
            if (!TryGetElementType(source, out Type t)) { result = null!; return false; }
            return TryCreateInstance(t, length0, length1, out result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean TryCreateInstance(Object? source, Int32 length0, Int32 length1, out Array result)
        {
            if (!TryGetElementType(source, out Type t)) { result = null!; return false; }
            return TryCreateInstance(t, length0, length1, out result);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static Boolean TryCreateInstance(Type? elementType, Int32 length0, Int32 length1, out Array result)
        {
            if (elementType is null || length0 < 0 || length1 < 0) { result = null!; return false; }
            try { result = Array.CreateInstance(elementType, length0, length1); return true; }
            catch { result = null!; return false; }
        }

        #endregion

        #endregion

        #region 2D-1D

        #region T[,][]

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean IsJagged<T>(T[,][]? source) { return source is not null; }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean IsValidDimension<T>(T[,][]? source, Int32 dimension) { return source is not null && (UInt32)dimension < 2; }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean IsValidPosition<T>(T[,][]? source, Int32 index0, Int32 index1, Int32 index2)
        {
            return
                source is not null
                && IsValidPosition(source, index0, index1)
                && IsValidIndex(source[index0, index1], index2);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean TryGetValue<T>(T[,][]? source, Int32 index0, Int32 index1, Int32 index2, out T result)
        {
            if (!IsValidPosition(source, index0, index1, index2)) { result = default!; return false; }
            result = source![index0, index1]![index2]; return true;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean TryGetElementType<T>(T[,][]? source, out Type result) { result = KozmosTypeHelper<T[]>._; return true; }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Type GetElementType<T>(T[,][] source) { return KozmosTypeHelper<T[]>._; }

        #endregion

        #endregion

        #region 2D-2D

        #region T[,][,]

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean IsJagged<T>(T[,][,]? source) { return source is not null; }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean IsValidDimension<T>(T[,][,]? source, Int32 dimension) { return source is not null && (UInt32)dimension < 2; }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean IsValidPosition<T>(T[,][,]? source, Int32 index0, Int32 index1, Int32 index2, Int32 index3)
        {
            return
                source is not null
                && IsValidPosition(source, index0, index1)
                && IsValidPosition(source[index0, index1], index2, index3);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean TryGetValue<T>(T[,][,]? source, Int32 index0, Int32 index1, Int32 index2, Int32 index3, out T result)
        {
            if (!IsValidPosition(source, index0, index1, index2, index3)) { result = default!; return false; }
            result = source![index0, index1]![index2, index3]; return true;
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean TryGetElementType<T>(T[,][,]? source, out Type result) { result = KozmosTypeHelper<T[,]>._; return true; }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Type GetElementType<T>(T[,][,] source) { return KozmosTypeHelper<T[,]>._; }

        #endregion

        #endregion

        #region 2D-3D

        #region T[,][,,]

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean IsJagged<T>(T[,][,,]? source) { return source is not null; }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean IsValidDimension<T>(T[,][,,]? source, Int32 dimension) { return source is not null && (UInt32)dimension < 2; }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean IsValidPosition<T>(T[,][,,]? source, Int32 index0, Int32 index1, Int32 index2, Int32 index3, Int32 index4)
        {
            return
                source is not null
                && IsValidPosition(source, index0, index1)
                && IsValidPosition(source[index0, index1], index2, index3, index4);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean TryGetValue<T>(T[,][,,]? source, Int32 index0, Int32 index1, Int32 index2, Int32 index3, Int32 index4, out T result)
        {
            if (!IsValidPosition(source, index0, index1, index2, index3, index4)) { result = default!; return false; }
            result = source![index0, index1]![index2, index3, index4]; return true;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean TryGetElementType<T>(T[,][,,]? source, out Type result) { result = KozmosTypeHelper<T[,,]>._; return true; }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Type GetElementType<T>(T[,][,,] source) { return KozmosTypeHelper<T[,,]>._; }

        #endregion

        #endregion

        #region 2D-4D

        #region T[,][,,,]

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean IsJagged<T>(T[,][,,,]? source) { return source is not null; }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean IsValidDimension<T>(T[,][,,,]? source, Int32 dimension) { return source is not null && (UInt32)dimension < 2; }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean IsValidPosition<T>(T[,][,,,]? source, Int32 index0, Int32 index1, Int32 index2, Int32 index3, Int32 index4, Int32 index5)
        {
            return
                source is not null
                && IsValidPosition(source, index0, index1)
                && IsValidPosition(source[index0, index1], index2, index3, index4, index5);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean TryGetValue<T>(T[,][,,,]? source, Int32 index0, Int32 index1, Int32 index2, Int32 index3, Int32 index4, Int32 index5, out T result)
        {
            if (!IsValidPosition(source, index0, index1, index2, index3, index4, index5)) { result = default!; return false; }
            result = source![index0, index1]![index2, index3, index4, index5]; return true;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean TryGetElementType<T>(T[,][,,,]? source, out Type result) { result = KozmosTypeHelper<T[,,,]>._; return true; }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Type GetElementType<T>(T[,][,,,] source) { return KozmosTypeHelper<T[,,,]>._; }

        #endregion

        #endregion

        #region 3D

        #region T[,,]

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean IsJagged<T>(T[,,]? source) { return false; }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean IsValidDimension<T>(T[,,]? source, Int32 dimension) { return source is not null && (UInt32)dimension < 3; }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean IsValidPosition<T>(T[,,]? source, Int32 index0, Int32 index1, Int32 index2)
        {
            return
                source is not null
                && (UInt32)index0 < (UInt32)source.GetLength(0)
                && (UInt32)index1 < (UInt32)source.GetLength(1)
                && (UInt32)index2 < (UInt32)source.GetLength(2);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean TryGetValue<T>(T[,,]? source, Int32 index0, Int32 index1, Int32 index2, out T result)
        {
            if (!IsValidPosition(source, index0, index1, index2)) { result = default!; return false; }
            result = source![index0, index1, index2]; return true;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean TryGetElementType<T>(T[,,]? source, out Type result) { result = KozmosTypeHelper<T>._; return true; }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Type GetElementType<T>(T[,,] source) { return KozmosTypeHelper<T>._; }

        #endregion

        #region T[][][]

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean IsJagged<T>(T[][][]? source) { return source is not null; }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean IsValidDimension<T>(T[][][]? source, Int32 dimension) { return source is not null && (UInt32)dimension < 1; }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean IsValidPosition<T>(T[][][]? source, Int32 index0, Int32 index1, Int32 index2)
        {
            return
                IsValidIndex(source, index0)
                && IsValidIndex(source![index0], index1)
                && IsValidIndex(source![index0][index1], index2);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean TryGetValue<T>(T[][][]? source, Int32 index0, Int32 index1, Int32 index2, out T result)
        {
            if (!IsValidPosition(source, index0, index1, index2)) { result = default!; return false; }
            result = source![index0][index1][index2]; return true;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean TryGetElementType<T>(T[][][]? source, out Type result) { result = KozmosTypeHelper<T[][]>._; return true; }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Type GetElementType<T>(T[][][] source) { return KozmosTypeHelper<T[][]>._; }

        #endregion

        #region Array

        [MethodImpl(MethodImplOptions.AggressiveOptimization)]
        public static Boolean IsValidPosition(Array? source, Int32 index0, Int32 index1, Int32 index2)
        {
            if (source is null) return false;

            Array? a;

            switch (source.Rank)
            {
                case 3:
                    return
                         IsValidIndexInDimension(source, 0, index0)
                        && IsValidIndexInDimension(source, 1, index1)
                        && IsValidIndexInDimension(source, 2, index2);
                case 2:
                    if
                    (
                        !IsValidPosition(source, index0, index1)
                        || !TryGetValue<Array>(source, index0, index1, out a)
                        || a is null
                    )
                        return false;

                    return IsValidIndex(a, index2);
                case 1:
                    if
                    (
                        !IsValidIndex(source, index0)
                        || !TryGetValue(source, index0, out a)
                        || a is null
                    )
                        return false;

                    return IsValidPosition(a, index1, index2);

                default:
                    return false;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean TryGetValue<T>(Array? source, Int32 index0, Int32 index1, Int32 index2, out T result)
        {
            if (!TryGetValue(source, index0, index1, index2, out Object? o)) { result = default!; return false; }
            return KozmosObjectHelper.TryCast(o, out result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean TryGetValue(Array? source, Int32 index0, Int32 index1, Int32 index2, out Object? result)
        {
            if (!IsValidPosition(source, index0, index1, index2)) { result = default!; return false; }

            Object? o;

            switch (source!.Rank)
            {
                case 3:
                    result = source!.GetValue(index0, index1, index2);
                    return true;
                case 2:
                    o = source!.GetValue(index0, index1);
                    result = Unsafe.As<Array>(o)!.GetValue(index2);
                    return true;
                case 1:
                    o = source!.GetValue(index0);
                    result = Unsafe.As<Array>(o)!.GetValue(index1, index2);
                    return true;
                default:
                    result = null!;
                    return false;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean TryCreateInstance(Array? source, Int32 length0, Int32 length1, Int32 length2, out Array result)
        {
            if (!TryGetElementType(source, out Type t)) { result = null!; return false; }
            return TryCreateInstance(t, length0, length1, length2, out result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean TryCreateInstance(Object? source, Int32 length0, Int32 length1, Int32 length2, out Array result)
        {
            if (!TryGetElementType(source, out Type t)) { result = null!; return false; }
            return TryCreateInstance(t, length0, length1, length2, out result);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static Boolean TryCreateInstance(Type? elementType, Int32 length0, Int32 length1, Int32 length2, out Array result)
        {
            if (elementType is null || length0 < 0 || length1 < 0 || length2 < 0) { result = null!; return false; }
            try { result = Array.CreateInstance(elementType, length0, length1, length2); return true; }
            catch { result = null!; return false; }
        }

        #endregion

        #endregion

        #region 3D-1D

        #region T[,,][]

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean IsJagged<T>(T[,,][]? source) { return source is not null; }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean IsValidDimension<T>(T[,,][]? source, Int32 dimension) { return source is not null && (UInt32)dimension < 3; }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean IsValidPosition<T>(T[,,][]? source, Int32 index0, Int32 index1, Int32 index2, Int32 index3)
        {
            return
                source is not null
                && IsValidPosition(source, index0, index1, index2)
                && IsValidIndex(source[index0, index1, index2], index3);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean TryGetValue<T>(T[,,][]? source, Int32 index0, Int32 index1, Int32 index2, Int32 index3, out T result)
        {
            if (!IsValidPosition(source, index0, index1, index2, index3)) { result = default!; return false; }
            result = source![index0, index1, index2]![index3]; return true;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean TryGetElementType<T>(T[,,][]? source, out Type result) { result = KozmosTypeHelper<T[]>._; return true; }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Type GetElementType<T>(T[,,][] source) { return KozmosTypeHelper<T[]>._; }

        #endregion

        #endregion

        #region 3D-2D

        #region T[,,][,]

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean IsJagged<T>(T[,,][,]? source) { return source is not null; }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean IsValidDimension<T>(T[,,][,]? source, Int32 dimension) { return source is not null && (UInt32)dimension < 3; }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean IsValidPosition<T>(T[,,][,]? source, Int32 index0, Int32 index1, Int32 index2, Int32 index3, Int32 index4)
        {
            return
                source is not null
                && IsValidPosition(source, index0, index1, index2)
                && IsValidPosition(source[index0, index1, index2], index3, index4);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean TryGetValue<T>(T[,,][,]? source, Int32 index0, Int32 index1, Int32 index2, Int32 index3, Int32 index4, out T result)
        {
            if (!IsValidPosition(source, index0, index1, index2, index3, index4)) { result = default!; return false; }
            result = source![index0, index1, index2]![index3, index4]; return true;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean TryGetElementType<T>(T[,,][,]? source, out Type result) { result = KozmosTypeHelper<T[,]>._; return true; }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Type GetElementType<T>(T[,,][,] source) { return KozmosTypeHelper<T[,]>._; }

        #endregion

        #endregion

        #region 3D-3D

        #region T[,,][,,]

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean IsJagged<T>(T[,,][,,]? source) { return source is not null; }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean IsValidDimension<T>(T[,,][,,]? source, Int32 dimension) { return source is not null && (UInt32)dimension < 3; }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean IsValidPosition<T>(T[,,][,,]? source, Int32 index0, Int32 index1, Int32 index2, Int32 index3, Int32 index4, Int32 index5)
        {
            return
                source is not null
                && IsValidPosition(source, index0, index1, index2)
                && IsValidPosition(source[index0, index1, index2], index3, index4, index5);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean TryGetValue<T>(T[,,][,,]? source, Int32 index0, Int32 index1, Int32 index2, Int32 index3, Int32 index4, Int32 index5, out T result)
        {
            if (!IsValidPosition(source, index0, index1, index2, index3, index4, index5)) { result = default!; return false; }
            result = source![index0, index1, index2]![index3, index4, index5]; return true;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean TryGetElementType<T>(T[,,][,,]? source, out Type result) { result = KozmosTypeHelper<T[,,]>._; return true; }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Type GetElementType<T>(T[,,][,,] source) { return KozmosTypeHelper<T[,,]>._; }

        #endregion

        #endregion

        #region 3D-4D

        #region T[,,][,,,]

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean IsJagged<T>(T[,,][,,,]? source) { return source is not null; }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean IsValidDimension<T>(T[,,][,,,]? source, Int32 dimension) { return source is not null && (UInt32)dimension < 3; }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean IsValidPosition<T>(T[,,][,,,]? source, Int32 index0, Int32 index1, Int32 index2, Int32 index3, Int32 index4, Int32 index5, Int32 index6)
        {
            return
                source is not null
                && IsValidPosition(source, index0, index1, index2)
                && IsValidPosition(source[index0, index1, index2], index3, index4, index5, index6);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean TryGetValue<T>(T[,,][,,,]? source, Int32 index0, Int32 index1, Int32 index2, Int32 index3, Int32 index4, Int32 index5, Int32 index6, out T result)
        {
            if (!IsValidPosition(source, index0, index1, index2, index3, index4, index5, index6)) { result = default!; return false; }
            result = source![index0, index1, index2]![index3, index4, index5, index6]; return true;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean TryGetElementType<T>(T[,,][,,,]? source, out Type result) { result = KozmosTypeHelper<T[,,,]>._; return true; }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Type GetElementType<T>(T[,,][,,,] source) { return KozmosTypeHelper<T[,,,]>._; }

        #endregion

        #endregion

        #region 4D

        #region T[,,,]

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean IsJagged<T>(T[,,,]? source) { return false; }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean IsValidDimension<T>(T[,,,]? source, Int32 dimension) { return source is not null && (UInt32)dimension < 4; }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean IsValidPosition<T>(T[,,,]? source, Int32 index0, Int32 index1, Int32 index2, Int32 index3)
        {
            return
                source is not null
                && (UInt32)index0 < (UInt32)source.GetLength(0)
                && (UInt32)index1 < (UInt32)source.GetLength(1)
                && (UInt32)index2 < (UInt32)source.GetLength(2)
                && (UInt32)index3 < (UInt32)source.GetLength(3);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean TryGetValue<T>(T[,,,]? source, Int32 index0, Int32 index1, Int32 index2, Int32 index3, out T result)
        {
            if (!IsValidPosition(source, index0, index1, index2, index3)) { result = default!; return false; }
            result = source![index0, index1, index2, index3]; return true;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean TryGetElementType<T>(T[,,,]? source, out Type result) { result = KozmosTypeHelper<T>._; return true; }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Type GetElementType<T>(T[,,,] source) { return KozmosTypeHelper<T>._; }

        #endregion

        #region T[][][][]

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean IsJagged<T>(T[][][][]? source) { return source is not null; }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean IsValidDimension<T>(T[][][][]? source, Int32 dimension) { return source is not null && (UInt32)dimension < 1; }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean IsValidPosition<T>(T[][][][]? source, Int32 index0, Int32 index1, Int32 index2, Int32 index3)
        {
            return
                IsValidIndex(source, index0)
                && IsValidIndex(source![index0], index1)
                && IsValidIndex(source![index0][index1], index2)
                && IsValidIndex(source![index0][index1][index2], index3);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean TryGetValue<T>(T[][][][]? source, Int32 index0, Int32 index1, Int32 index2, Int32 index3, out T result)
        {
            if (!IsValidPosition(source, index0, index1, index2, index3)) { result = default!; return false; }
            result = source![index0][index1][index2][index3]; return true;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean TryGetElementType<T>(T[][][][]? source, out Type result) { result = KozmosTypeHelper<T[][][]>._; return true; }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Type GetElementType<T>(T[][][][] source) { return KozmosTypeHelper<T[][][]>._; }

        #endregion

        #region Array

        [MethodImpl(MethodImplOptions.AggressiveOptimization)]
        public static Boolean IsValidPosition(Array? source, Int32 index0, Int32 index1, Int32 index2, Int32 index3)
        {
            if (source is null) return false;

            Array? a;

            switch (source.Rank)
            {
                case 4:
                    return
                        IsValidIndexInDimension(source, 0, index0)
                        && IsValidIndexInDimension(source, 1, index1)
                        && IsValidIndexInDimension(source, 2, index2)
                        && IsValidIndexInDimension(source, 3, index3);
                case 3:
                    if
                    (
                        !IsValidPosition(source, index0, index1, index2)
                        || !TryGetValue<Array>(source, index0, index1, index2, out a)
                        || a is null
                    )
                        return false;

                    return IsValidIndex(a, index3);
                case 2:
                    if
                    (
                        !IsValidPosition(source, index0, index1)
                        || !TryGetValue<Array>(source, index0, index1, out a)
                        || a is null
                    )
                        return false;

                    return IsValidPosition(a, index2, index3);
                case 1:
                    if
                    (
                        !IsValidIndex(source, index0)
                        || !TryGetValue<Array>(source, index0, out a)
                        || a is null
                    )
                        return false;

                    return IsValidPosition(a, index1, index2, index3);

                default:
                    return false;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean TryGetValue<T>(Array? source, Int32 index0, Int32 index1, Int32 index2, Int32 index3, out T result)
        {
            if (!TryGetValue(source, index0, index1, index2, index3, out Object? o)) { result = default!; return false; }
            return KozmosObjectHelper.TryCast(o, out result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean TryGetValue(Array? source, Int32 index0, Int32 index1, Int32 index2, Int32 index3, out Object? result)
        {
            if (!IsValidPosition(source, index0, index1, index2, index3)) { result = default!; return false; }

            Object? o;

            switch (source!.Rank)
            {
                case 4:
                    result = source!.GetValue(index0, index1, index2, index3);
                    return true;
                case 3:
                    o = source!.GetValue(index0, index1, index2);
                    result = Unsafe.As<Array>(o)!.GetValue(index3);
                    return true;
                case 2:
                    o = source!.GetValue(index0, index1);
                    result = Unsafe.As<Array>(o)!.GetValue(index2, index3);
                    return true;
                case 1:
                    o = source!.GetValue(index0);
                    result = Unsafe.As<Array>(o)!.GetValue(index1, index2, index3);
                    return true;
                default:
                    result = null!;
                    return false;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean TryCreateInstance(Array? source, Int32 length0, Int32 length1, Int32 length2, Int32 length3, out Array result)
        {
            if (!TryGetElementType(source, out Type t)) { result = null!; return false; }
            return TryCreateInstance(t, length0, length1, length2, length3, out result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean TryCreateInstance(Object? source, Int32 length0, Int32 length1, Int32 length2, Int32 length3, out Array result)
        {
            if (!TryGetElementType(source, out Type t)) { result = null!; return false; }
            return TryCreateInstance(t, length0, length1, length2, length3, out result);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static Boolean TryCreateInstance(Type? elementType, Int32 length0, Int32 length1, Int32 length2, Int32 length3, out Array result)
        {
            if (elementType is null || length0 < 0 || length1 < 0 || length2 < 0 || length3  < 0) { result = null!; return false; }
            try { result = Array.CreateInstance(elementType, length0, length1, length2, length3); return true; }
            catch { result = null!; return false; }
        }

        #endregion

        #endregion

        #region 4D-1D

        #region T[,,,][]

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean IsJagged<T>(T[,,,][]? source) { return source is not null; }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean IsValidDimension<T>(T[,,,][]? source, Int32 dimension) { return source is not null && (UInt32)dimension < 4; }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean IsValidPosition<T>(T[,,,][]? source, Int32 index0, Int32 index1, Int32 index2, Int32 index3, Int32 index4)
        {
            return
                source is not null
                && IsValidPosition(source, index0, index1, index2, index3)
                && IsValidIndex(source[index0, index1, index2, index3], index4);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean TryGetValue<T>(T[,,,][]? source, Int32 index0, Int32 index1, Int32 index2, Int32 index3, Int32 index4, out T result)
        {
            if (!IsValidPosition(source, index0, index1, index2, index3, index4)) { result = default!; return false; }
            result = source![index0, index1, index2, index3]![index4]; return true;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean TryGetElementType<T>(T[,,,][]? source, out Type result) { result = KozmosTypeHelper<T[]>._; return true; }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Type GetElementType<T>(T[,,,][] source) { return KozmosTypeHelper<T[]>._; }

        #endregion

        #endregion

        #region 4D-2D

        #region T[,,,][,]

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean IsJagged<T>(T[,,,][,]? source) { return source is not null; }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean IsValidDimension<T>(T[,,,][,]? source, Int32 dimension) { return source is not null && (UInt32)dimension < 4; }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean IsValidPosition<T>(T[,,,][,]? source, Int32 index0, Int32 index1, Int32 index2, Int32 index3, Int32 index4, Int32 index5)
        {
            return
                source is not null
                && IsValidPosition(source, index0, index1, index2, index3)
                && IsValidPosition(source[index0, index1, index2, index3], index4, index5);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean TryGetValue<T>(T[,,,][,]? source, Int32 index0, Int32 index1, Int32 index2, Int32 index3, Int32 index4, Int32 index5, out T result)
        {
            if (!IsValidPosition(source, index0, index1, index2, index3, index4, index5)) { result = default!; return false; }
            result = source![index0, index1, index2, index3]![index4, index5]; return true;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean TryGetElementType<T>(T[,,,][,]? source, out Type result) { result = KozmosTypeHelper<T[,]>._; return true; }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Type GetElementType<T>(T[,,,][,] source) { return KozmosTypeHelper<T[,]>._; }

        #endregion

        #endregion

        #region 4D-3D

        #region T[,,,][,,]

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean IsJagged<T>(T[,,,][,,]? source) { return source is not null; }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean IsValidDimension<T>(T[,,,][,,]? source, Int32 dimension) { return source is not null && (UInt32)dimension < 4; }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean IsValidPosition<T>(T[,,,][,,]? source, Int32 index0, Int32 index1, Int32 index2, Int32 index3, Int32 index4, Int32 index5, Int32 index6)
        {
            return
                source is not null
                && IsValidPosition(source, index0, index1, index2, index3)
                && IsValidPosition(source[index0, index1, index2, index3], index4, index5, index6);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean TryGetValue<T>(T[,,,][,,]? source, Int32 index0, Int32 index1, Int32 index2, Int32 index3, Int32 index4, Int32 index5, Int32 index6, out T result)
        {
            if (!IsValidPosition(source, index0, index1, index2, index3, index4, index5, index6)) { result = default!; return false; }
            result = source![index0, index1, index2, index3]![index4, index5, index6]; return true;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean TryGetElementType<T>(T[,,,][,,]? source, out Type result) { result = KozmosTypeHelper<T[,,]>._; return true; }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Type GetElementType<T>(T[,,,][,,] source) { return KozmosTypeHelper<T[,,]>._; }

        #endregion

        #endregion

        #region 4D-4D

        #region T[,,,][,,,]

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean IsJagged<T>(T[,,,][,,,]? source) { return source is not null; }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean IsValidDimension<T>(T[,,,][,,,]? source, Int32 dimension) { return source is not null && (UInt32)dimension < 4; }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean IsValidPosition<T>(T[,,,][,,,]? source, Int32 index0, Int32 index1, Int32 index2, Int32 index3, Int32 index4, Int32 index5, Int32 index6, Int32 index7)
        {
            return
                source is not null
                && IsValidPosition(source, index0, index1, index2, index3)
                && IsValidPosition(source[index0, index1, index2, index3], index4, index5, index6, index7);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean TryGetValue<T>(T[,,,][,,,]? source, Int32 index0, Int32 index1, Int32 index2, Int32 index3, Int32 index4, Int32 index5, Int32 index6, Int32 index7, out T result)
        {
            if (!IsValidPosition(source, index0, index1, index2, index3, index4, index5, index6, index7)) { result = default!; return false; }
            result = source![index0, index1, index2, index3]![index4, index5, index6, index7]; return true;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean TryGetElementType<T>(T[,,,][,,,]? source, out Type result) { result = KozmosTypeHelper<T[,,,]>._; return true; }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Type GetElementType<T>(T[,,,][,,,] source) { return KozmosTypeHelper<T[,,,]>._; }

        #endregion

        #endregion

        #region ND

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean IsValidDimension(Array? source, Int32 dimension)
        {
            return
                source is not null
                && (UInt32)dimension < (UInt32)source.Rank;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean IsJagged(Array? source) { return TryGetElementType(source, out Type t) && t.IsArray; }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean IsValidIndexInDimension(Array? source, Int32 dimension, Int32 index)
        {
            return
                IsValidDimension(source, dimension)
                && KozmosBoundHelper.IsInRange(index, source!.GetLowerBound(dimension), source!.GetUpperBound(dimension));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean IsValidPosition(Array? source, Int32[]? indexes)
        {
            return
                source is not null
                && indexes is not null
                && __IsValidPosition(source, indexes, out Array a, out Int32[] ia);
        }

        [MethodImpl(MethodImplOptions.AggressiveOptimization)]
        private static Boolean __IsValidPosition(Array source, Int32[] indexes, out Array a, out Int32[] ia)
        {
            if (indexes.Length < source.Rank) { a = null!; ia = null!; return false; }

            for (Int32 i = 0; i < source.Rank; i++)
            {
                if (IsValidIndexInDimension(source, i, indexes[i])) continue;
                a = null!; ia = null!; return false;
            }

            if (indexes.Length == source.Rank) { a = source; ia = indexes; return true; }

            ia = indexes[..source.Rank];

            Object? o = source.GetValue(ia);
            if (o is Array a0) return __IsValidPosition(a0, indexes[source.Rank..], out a, out ia);
            a = source; return true;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean TryGetValue<T>(Array? source, Int32[]? indexes, out T? result)
        {
            if (!TryGetValue(source, indexes, out Object? o)) { result = default!; return false; }
            return KozmosObjectHelper.TryCast(o, out result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean TryGetValue(Array? source, Int32[]? indexes, out Object? result)
        {
            if (source is null || indexes is null) { result = null; return false; }
            Array a; Int32[] ia;
            if (!__IsValidPosition(source!, indexes!, out a, out ia)) { result = default!; return false; }
            result = a.GetValue(ia); return true;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean TryGetElementType(Array? array, out Type result)
        {
            return KozmosTypeHelper.TryGetElementType(array, out result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean TryGetElementType(Type? source, out Type result)
        {
            if (source is null || !source.IsArray) { result = null!; return false; }
            return KozmosTypeHelper.TryGetElementType(source, out result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean TryGetElementType(Object? source, out Type result)
        {
            switch (source)
            {
                case Array a: return TryGetElementType(a, out result);
                case Type t: return TryGetElementType(t, out result);
                default: result = null!; return false;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Type GetElementType(Array source)
        {
            KozmosArgumentNullExceptionHelper.ThrowIfNull(source);
            return KozmosTypeHelper.GetElementType(source);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Type GetElementType(Type source)
        {
            KozmosArgumentNullExceptionHelper.ThrowIfNull(source);
            if (!source.IsArray) KozmosArgumentExceptionHelper.ThrowValue_0_OfArgument_1_2_IsNotSupported(source);
            return KozmosTypeHelper.GetElementType(source);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Type GetElementType(Object source)
        {
            switch (source)
            {
                case Array a: return GetElementType(a);
                case Type t: return GetElementType(t);
                case null: KozmosArgumentNullExceptionHelper.Throw(source); return null!;
                default: KozmosArgumentExceptionHelper.ThrowValue_0_OfArgument_1_2_IsNotSupported(source); return null!;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Split(Array source, Int32 index, out Array leftResult, out Array rightResult)
        {
            KozmosArgumentNullExceptionHelper.ThrowIfNull(source);
            if (!IsValidIndex(source, index)) KozmosArgumentOutOfRangeExceptionHelper.Throw(source);
            Type t = GetElementType(source);
            leftResult = Array.CreateInstance(t, index);
            rightResult = Array.CreateInstance(t, source.Length - index);
            Array.Copy(source, 0, leftResult, 0, leftResult.Length);
            Array.Copy(source, index, rightResult, 0, rightResult.Length);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean TrySplit(Array? source, Int32 index, out Array leftResult, out Array rightResult)
        {
            if
            (
                !IsValidIndex(source, index)
                || !TryGetElementType(source, out Type t)
                || !TryCreateInstance(t, index, out leftResult)
                || !TryCreateInstance(t, index, out rightResult)
            )
            {
                leftResult = null!;
                rightResult = null!;
                return false;
            }

            Array.Copy(source!, 0, leftResult, 0, leftResult.Length);
            Array.Copy(source!, index, rightResult, 0, rightResult.Length);

            return true;
        }

        #endregion









        public static Array Convert<TElement>(Object? source)
        {
			switch(source)
			{
				// HotPath >
				case TElement[] a: return a;
				// < HotPath


			}

			return null;
        }

        public static Array Convert(Array? source, Type element)
        {
            KozmosArgumentNullExceptionHelper.ThrowIfNull(source);
			Type element0 = KozmosTypeHelper.GetElementType(source!);
            if (!element0.IsAssignableTo(element)) KozmosArgumentExceptionHelper.ThrowValue_0_OfArgument_1_2_IsNotSupported(element);

            //Array a0 = Array.CreateInstance(element, a.Length);
            //Array.Copy(a, a0, a0.Length);
            //return a0;

            return null;
        }


        public static Array Convert(Object? source, Type element)
		{
			//switch(source)
			//{
			//	case Array a:
			//		Type element0 = GetElementType(a);
			//		if(!element0.IsAssignableTo(element)) KozmosArgumentExceptionHelper.ThrowValue_0_OfArgument_1_2_IsNotSupported(element);

   //                 Array a0 = Array.CreateInstance(element, a.Length);
			//		Array.Copy(a, a0, a0.Length);
			//		return a0;

			//	case IEnumerable:

			//}

			return null;
		}
	}
}

