using System;
using System.Runtime.CompilerServices;
using Kozmos.Helpers.Collectibles;

namespace System
{
	public static class KozmosArrayExtensions
    {
        #region KozmosIsValidDimension

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean KozmosIsValidDimension(this Array? source, Int32 dimension)
        {
            return KozmosArrayHelper.IsValidDimension(source, dimension);
        }

        #endregion

        #region KozmosIsValidIndexInDimension

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean KozmosIsValidIndexInDimension(this Array? source, Int32 dimension, Int32 index)
        {
            return KozmosArrayHelper.IsValidIndexInDimension(source, dimension, index);
        }

        #endregion

        #region KozmosIsValidIndex

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean KozmosIsValidIndex(this Array? source, Int64 index0)
        {
            return KozmosArrayHelper.IsValidIndex(source, index0);
        }

        #endregion

        #region KozmosIsValidIndexes

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean KozmosIsValidIndexes(this Array? source, Int64 index0, Int64 index1)
        {
            return KozmosArrayHelper.IsValidIndexes(source, index0, index1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean KozmosIsValidIndexes(this Array? source, Int64 index0, Int64 index1, Int64 index2)
        {
            return KozmosArrayHelper.IsValidIndexes(source, index0, index1, index2);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean KozmosIsValidIndexes(this Array? source, Int64 index0, Int64 index1, Int64 index2, Int64 index3)
        {
            return KozmosArrayHelper.IsValidIndexes(source, index0, index1, index2, index3);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean KozmosIsValidIndexes(this Array? source, Int64 index0, Int64 index1, Int64 index2, Int64 index3, params Int64[]? indexes)
        {
            return KozmosArrayHelper.IsValidIndexes(source, index0, index1, index2, index3, indexes);
        }

        #endregion

        #region KozmosIsElementType

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean KozmosIsElementType<T>(this Array? source)
        {
            return KozmosArrayHelper.IsElementType<T>(source);
        }

        #endregion

        #region KozmosGetElementType / KozmosTryGetElementType

        #region KozmosGetElementType

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Type KozmosGetElementType(this Array source)
        {
            return KozmosArrayHelper.GetElementType(source);
        }

        #endregion

        #region KozmosTryGetElementType


        #endregion

        #endregion

        #region KozmosGetValue / KozmosTryGetValue

        #region KozmosGetValue

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T? KozmosGetValue<T>(this Array source, Int64 index)
        {
            return KozmosArrayHelper.GetValue<T>(source, index);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Object? KozmosGetValue(this Array source, Int64 index)
        {
            return KozmosArrayHelper.GetValue(source, index);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T? KozmosGetValue<T>(this Array source, Int64 index0, Int64 index1)
        {
            return KozmosArrayHelper.GetValue<T>(source, index0, index1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Object? KozmosGetValue(this Array source, Int64 index0, Int64 index1)
        {
            return KozmosArrayHelper.GetValue(source, index0, index1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T? KozmosGetValue<T>(this Array source, Int64 index0, Int64 index1, Int64 index2)
        {
            return KozmosArrayHelper.GetValue<T>(source, index0, index1, index2);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Object? KozmosGetValue(this Array source, Int64 index0, Int64 index1, Int64 index2)
        {
            return KozmosArrayHelper.GetValue(source, index0, index1, index2);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T? KozmosGetValue<T>(this Array source, Int64 index0, Int64 index1, Int64 index2, Int64 index3)
        {
            return KozmosArrayHelper.GetValue<T>(source, index0, index1, index2, index3);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Object? KozmosGetValue(this Array source, Int64 index0, Int64 index1, Int64 index2, params Int64[] indexes)
        {
            return KozmosArrayHelper.GetValue(source, index0, index1, index2, indexes);
        }


        #endregion

        #endregion

        #region KozmosSetValue / KozmosTrySetValue

        #region KozmosSetValue

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void KozmosSetValue<T>(this Array source, T value, Int64 index)
        {
            KozmosArrayHelper.SetValue<T>(source, value, index);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void KozmosSetValue<T>(this Array source, T value, Int64 index0, Int64 index1)
        {
            KozmosArrayHelper.SetValue(source, value, index0, index1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void KozmosSetValue<T>(this Array source, T value, Int64 index0, Int64 index1, Int64 index2)
        {
            KozmosArrayHelper.SetValue(source, value, index0, index1, index2);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void KozmosSetValue<T>(this Array source, T value, Int64 index0, Int64 index1, Int64 index2, params Int64[]? indexes)
        {
            KozmosArrayHelper.SetValue(source, value, index0, index1, index2, indexes);
        }

        #endregion

        #endregion

        #region KozmosCopy / KozmosTryCopy

        #region KozmosCopy

        //#region 1D

        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        //public static T[] KozmosCopy<T>(this T[] source)
        //{
        //    return KozmosArrayHelper.Copy(source);
        //}

        //#endregion

        //#region 2D

        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        //public static T[,] KozmosCopy<T>(this T[,] source)
        //{
        //    return KozmosArrayHelper.Copy(source);
        //}

        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        //public static T[,] KozmosCopyt<T>(this T[,] source, Int32 startIndex, Int32 length)
        //{
        //    return KozmosArrayHelper.Copy(source, startIndex, length);
        //}

        //#endregion

        //#region 3D

        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        //public static T[,,] KozmosCopy<T>(this T[,,] source)
        //{
        //    return KozmosArrayHelper.Copy(source);
        //}

        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        //public static T[,,] KozmosCopyt<T>(this T[,,] source, Int32 startIndex, Int32 length)
        //{
        //    return KozmosArrayHelper.Copy(source, startIndex, length);
        //}

        //#endregion

        //#region 4D

        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        //public static T[,,,] KozmosCopy<T>(this T[,,,] source)
        //{
        //    return KozmosArrayHelper.Copy(source);
        //}

        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        //public static T[,,,] KozmosCopyt<T>(this T[,,,] source, Int32 startIndex, Int32 length)
        //{
        //    return KozmosArrayHelper.Copy(source, startIndex, length);
        //}

        //#endregion

        //public static Array KozmosCopy(this Array source)
        //{
        //    return KozmosArrayHelper.Copy(source);
        //}

        #endregion

        #endregion
    }
}