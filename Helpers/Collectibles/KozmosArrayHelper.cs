using System;
using System.Buffers;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kozmos.Helpers.Exceptions;
using Kozmos.Helpers.Numericals;
using Kozmos.Options;

namespace Kozmos.Helpers.Collectibles
{
	public static class KozmosArrayHelper
	{
        public static class Configuration
        {
            public static volatile Int32 StackMemoryLimitInBytes = 8 * sizeof(Int32);

            private static volatile ArrayPool<Int32> __ap = ArrayPool<Int32>.Create(8, Environment.ProcessorCount * 4);
            internal static ArrayPool<Int32> ArrayPool
            {
                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                get { return __ap; }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static void SetPool(Int32 maxArrayLength, Int32 maxArraysPerBucket)
            {
                __ap = ArrayPool<Int32>.Create(maxArrayLength, maxArraysPerBucket);
            }
        }

        #region IsValidDimension

        #region Array

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean IsValidDimension(Array? source, Int32 dimension) { return source is not null && (UInt32)dimension < (UInt32)source.Rank; }

        #endregion

        #endregion

        #region IsValidIndexInDimension

        #region Array

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean IsValidIndexInDimension(Array? source, Int32 dimension, Int64 index)
        {
            return
                IsValidDimension(source, dimension)
                && KozmosBoundHelper.IsInRange(index, source!.GetLowerBound(dimension), source!.GetUpperBound(dimension));
        }

        #endregion

        #endregion

        #region IsValidLinearIndex

        #region Array

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean IsValidLinearIndex(Array? source, Int64 linearIndex) { return source is not null && (UInt64)linearIndex < (UInt64)source.LongLength; }

        #endregion

        #endregion

        #region IsValidIndex

        #region Array

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean IsValidIndex(Array? source, Int64 index0)
        {
            return
                source is not null
                && source.Rank == 1
                && __IsValidIndex(source, index0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static Boolean __IsValidIndex(Array source, Int64 index0)
        {
            return
                KozmosBoundHelper.IsInRange(index0, source.GetLowerBound(0), source.GetUpperBound(0));
        }

        #endregion

        #endregion

        #region IsValidIndexes

        #region Array

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean IsValidIndexes(Array? source, Int64 index0, Int64 index1)
        {
            return
                source is not null
                && source.Rank == 2
                && __IsValidIndexes(source, index0, index1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static Boolean __IsValidIndexes(Array source, Int64 index0, Int64 index1)
        {
            return
                __IsValidIndex(source, index0)
                && KozmosBoundHelper.IsInRange(index1, source.GetLowerBound(1), source.GetUpperBound(1));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean IsValidIndexes(Array? source, Int64 index0, Int64 index1, Int64 index2)
        {
            return
                source is not null
                && source.Rank == 3
                && __IsValidIndexes(source, index0, index1, index2);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static Boolean __IsValidIndexes(Array source, Int64 index0, Int64 index1, Int64 index2)
        {
            return
                __IsValidIndexes(source, index0, index1)
                && KozmosBoundHelper.IsInRange(index2, source.GetLowerBound(2), source.GetUpperBound(2));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean IsValidIndexes(Array? source, Int64 index0, Int64 index1, Int64 index2, Int64 index3)
        {
            return
                source is not null
                && source.Rank == 4
                && __IsValidIndexes(source, index0, index1, index2, index3);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static Boolean __IsValidIndexes(Array source, Int64 index0, Int64 index1, Int64 index2, Int64 index3)
        {
            return
                __IsValidIndexes(source, index0, index1, index2)
                && KozmosBoundHelper.IsInRange(index3, source.GetLowerBound(3), source.GetUpperBound(3));
        }

        [MethodImpl(MethodImplOptions.AggressiveOptimization)]
        public static Boolean IsValidIndexes(Array? source, Int64 index0, Int64 index1, Int64 index2, Int64 index3, params Int64[]? indexes)
        {
            if
            (
                source is null
                || !__IsValidIndexes(source, index0, index1, index2, index3)
                || indexes is null
                || source.Rank != (4 + indexes.Length)
            )
                return false;

            Int32 i = 4;

            ref var indexesPointer0 = ref MemoryMarshal.GetArrayDataReference(indexes);

            while (i < source.Rank)
            {
                if (!KozmosBoundHelper.IsInRange(Unsafe.Add(ref indexesPointer0, i - 4), source!.GetLowerBound(i), source!.GetUpperBound(i))) return false;
                i++;
            }

            return true;
        }

        #endregion

        #endregion

        #region ExtractIndexes / TryExtractIndexes

        #region ExtractIndexes

        #region Array

        [MethodImpl(MethodImplOptions.AggressiveOptimization)]
        public static Int64[] ExtractIndexes(Array source, Int64 linearIndex)
        {
            KozmosArgumentNullExceptionHelper.ThrowIfNull(source);
            if ((UInt64)linearIndex >= (UInt64)source.LongLength) KozmosArgumentOutOfRangeExceptionHelper.Throw(nameof(linearIndex));

            var indexes = new Int64[source.Rank];

            ref var indexesPointer0 = ref MemoryMarshal.GetArrayDataReference(indexes);

            var i = source.Rank - 1;

            Int64 longLengthi, lowerBoundi, upperBoundi;
            Int64 remainder;
            while (i > -1)
            {
                __GetDimensionMetas(source, i, out longLengthi, out lowerBoundi, out upperBoundi);
                (linearIndex, remainder) = Math.DivRem(linearIndex, longLengthi);
                Unsafe.Add(ref indexesPointer0, i) = remainder + lowerBoundi;
                i--;
            }

            return indexes;
        }

        #endregion

        #endregion

        #region TryExtractIndexes

        #region Array

        [MethodImpl(MethodImplOptions.AggressiveOptimization)]
        public static Boolean TryExtractIndexes(Array? source, Int64 linearIndex, out Int64[] indexes)
        {
            if (source is null || (UInt64)linearIndex >= (UInt64)source.LongLength) { indexes = null!; return false; }

            indexes = new Int64[source.Rank];

            ref var indexesPointer0 = ref MemoryMarshal.GetArrayDataReference(indexes);

            var i = source.Rank - 1;

            Int64 longLengthi, lowerBoundi, upperBoundi;
            Int64 remainder;
            while (i > -1)
            {
                __GetDimensionMetas(source, i, out longLengthi, out lowerBoundi, out upperBoundi);
                (linearIndex, remainder) = Math.DivRem(linearIndex, longLengthi);
                Unsafe.Add(ref indexesPointer0, i) = remainder + lowerBoundi;
                i--;
            }

            return true;
        }

        #endregion

        #endregion

        #endregion

        #region ExtractLinearIndex / TryExtractLinearIndex

        #region ExtractLinearIndex

        #region Array

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Int64 ExtractLinearIndex(Array source, Int64 index)
        {
            KozmosArgumentNullExceptionHelper.ThrowIfNull(source);
            if (source.Rank < 1) KozmosArgumentOutOfRangeExceptionHelper.Throw();
            return __ExtractLinearIndex(source, index);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Int64 __ExtractLinearIndex(Array source, Int64 index)
        {
            return __InitializeLinearIndex(source, index);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Int64 ExtractLinearIndex(Array source, Int64 index0, Int64 index1)
        {
            KozmosArgumentNullExceptionHelper.ThrowIfNull(source);
            if (source.Rank < 2) KozmosArgumentOutOfRangeExceptionHelper.Throw();
            return __ExtractLinearIndex(source, index0, index1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Int64 __ExtractLinearIndex(Array source, Int64 index0, Int64 index1)
        {
            var linearIndex = __InitializeLinearIndex(source, index0);
            return __ExtractLinearIndex(source, index0, index1);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Int64 ExtractLinearIndex(Array source, Int64 index0, Int64 index1, Int64 index2)
        {
            KozmosArgumentNullExceptionHelper.ThrowIfNull(source);
            if (source.Rank < 3) KozmosArgumentOutOfRangeExceptionHelper.Throw();
            return __ExtractLinearIndex(source, index0, index1, index2);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Int64 __ExtractLinearIndex(Array source, Int64 index0, Int64 index1, Int64 index2)
        {
            var linearIndex = __InitializeLinearIndex(source, index0);
            linearIndex = __CumulateLinearIndex(source, 1, linearIndex, index1);
            return __FinalizeLinearIndex(source, linearIndex, index2);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Int64 ExtractLinearIndex(Array source, Int64 index0, Int64 index1, Int64 index2, Int64 index3)
        {
            KozmosArgumentNullExceptionHelper.ThrowIfNull(source);
            if (source.Rank < 4) KozmosArgumentOutOfRangeExceptionHelper.Throw();
            return __ExtractLinearIndex(source, index0, index1, index2, index3);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static Int64 __ExtractLinearIndex(Array source, Int64 index0, Int64 index1, Int64 index2, Int64 index3)
        {
            var linearIndex = __InitializeLinearIndex(source, index0);
            linearIndex = __CumulateLinearIndex(source, 1, linearIndex, index1);
            linearIndex = __CumulateLinearIndex(source, 2, linearIndex, index2);
            return __FinalizeLinearIndex(source, linearIndex, index3);
        }

        [MethodImpl(MethodImplOptions.AggressiveOptimization)]
        public static Int64 ExtractLinearIndex(Array source, Int64 index0, Int64 index1, Int64 index2, Int64 index3, params Int64[]? indexes)
        {
            KozmosArgumentNullExceptionHelper.ThrowIfNull(source);

            switch(source.Rank)
            {
                case 0: KozmosArgumentOutOfRangeExceptionHelper.Throw(); return 0L;
                case 1: return __ExtractLinearIndex(source, index0);
                case 2: return __ExtractLinearIndex(source, index0, index1);
                case 3: return __ExtractLinearIndex(source, index0, index1, index2);
                case 4: return __ExtractLinearIndex(source, index0, index1, index2, index3);
            }

            if (indexes is null || indexes.Length < 1)
            {
                var linearIndex = __ExtractLinearIndex(source, index0, index1, index2, index3);
                return __FinalizeLinearIndex(4, source, linearIndex);
            }

            return __ExtractLinearIndex(source, index0, index1, index2, index3, indexes);
        }

        [MethodImpl(MethodImplOptions.AggressiveOptimization)]
        private static Int64 __ExtractLinearIndex(Array source, Int64 index0, Int64 index1, Int64 index2, Int64 index3, params Int64[] indexes)
        {
            var linearIndex = __ExtractLinearIndex(source, index0, index1, index2, index3);

            var i = 4;

            var limit = Math.Min(source.Rank, i + indexes.Length);
            ref var indexesPointer0 = ref MemoryMarshal.GetArrayDataReference(indexes);

            while (i < limit)
            {
                linearIndex = __CumulateLinearIndex(source, i, linearIndex, Unsafe.Add(ref indexesPointer0, i - 4));
                i++;
            }

            return __FinalizeLinearIndex(i, source, linearIndex);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static Int64 __InitializeLinearIndex(Array source, Int64 index) { return __CumulateLinearIndex(source, 0, 0, index); }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static Int64 __CumulateLinearIndex(Array source, Int32 dimension, Int64 lastLinearIndex, Int64 index)
        {
            __GetDimensionMetas(source, dimension, out var longLength, out var lowerBound, out var upperBound);
            if (!KozmosBoundHelper.IsInRange(index, lowerBound, upperBound)) KozmosArgumentOutOfRangeExceptionHelper.Throw();
            return (longLength * lastLinearIndex) + (index - lowerBound);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static Int64 __FinalizeLinearIndex(Array source, Int64 lastLinearIndex, Int64 index)
        {
            return __CumulateLinearIndex(source, source.Rank - 1, lastLinearIndex, index);
        }

        [MethodImpl(MethodImplOptions.AggressiveOptimization | MethodImplOptions.AggressiveInlining)]
        private static Int64 __FinalizeLinearIndex(Int32 lastDimension, Array source, Int64 lastLinearIndex)
        {
            while (lastDimension < source.Rank)
            {
                lastLinearIndex = __CumulateLinearIndex(source, lastDimension, lastLinearIndex, 0);
                lastDimension++;
            }

            return lastLinearIndex;
        }

        #endregion

        #endregion

        #region TryExtractLinearIndex

        #region Array

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean TryExtractLinearIndex(Array? source, Int64 index, out Int64 linearIndex)
        {
            if(source is null || source.Rank < 1) { linearIndex = 0L; return false; }
            return __TryExtractLinearIndex(source, index, out linearIndex);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static Boolean __TryExtractLinearIndex(Array source, Int64 index, out Int64 linearIndex)
        {
            return __TryInitializeLinearIndex(source, index, out linearIndex);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean TryExtractLinearIndex(Array? source, Int64 index0, Int64 index1, out Int64 linearIndex)
        {
            if (source is null || source.Rank < 2) { linearIndex = 0L; return false; }
            return __TryExtractLinearIndex(source, index0, index1, out linearIndex);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static Boolean __TryExtractLinearIndex(Array source, Int64 index0, Int64 index1, out Int64 linearIndex)
        {
            if (!__TryInitializeLinearIndex(source, index0, out linearIndex)) return false;
            return __TryFinalizeLinearIndex(source, linearIndex, index1, out linearIndex);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean TryExtractLinearIndex(Array? source, Int64 index0, Int64 index1, Int64 index2, out Int64 linearIndex)
        {
            if (source is null || source.Rank < 3) { linearIndex = 0L; return false; }
            return __TryExtractLinearIndex(source, index0, index1, index2, out linearIndex);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static Boolean __TryExtractLinearIndex(Array source, Int64 index0, Int64 index1, Int64 index2, out Int64 linearIndex)
        {
            if (!__TryInitializeLinearIndex(source, index0, out linearIndex)) return false;
            else if (!__TryCumulateLinearIndex(source, 1, linearIndex, index1, out linearIndex)) return false;
            return __TryFinalizeLinearIndex(source, linearIndex, index2, out linearIndex);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean TryExtractLinearIndex(Array? source, Int64 index0, Int64 index1, Int64 index2, Int64 index3, out Int64 linearIndex)
        {
            if (source is null || source.Rank < 4) { linearIndex = 0L; return false; }
            return __TryExtractLinearIndex(source, index0, index1, index2, index3, out linearIndex);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static Boolean __TryExtractLinearIndex(Array source, Int64 index0, Int64 index1, Int64 index2, Int64 index3, out Int64 linearIndex)
        {
            if (!__TryInitializeLinearIndex(source, index0, out linearIndex)) return false;
            else if (!__TryCumulateLinearIndex(source, 1, linearIndex, index1, out linearIndex)) return false;
            else if (!__TryCumulateLinearIndex(source, 2, linearIndex, index2, out linearIndex)) return false;
            return __TryFinalizeLinearIndex(source, linearIndex, index3, out linearIndex);
        }

        [MethodImpl(MethodImplOptions.AggressiveOptimization)]
        public static Boolean TryExtractLinearIndex(Array? source, out Int64 linearIndex, Int64 index0, Int64 index1, Int64 index2, Int64 index3, params Int64[]? indexes)
        {
            if (source is null) { linearIndex = 0L; return false; }

            switch (source.Rank)
            {
                case 0: linearIndex = 0L; return false;
                case 1: return __TryExtractLinearIndex(source, index0, out linearIndex);
                case 2: return __TryExtractLinearIndex(source, index0, index1, out linearIndex);
                case 3: return __TryExtractLinearIndex(source, index0, index1, index2, out linearIndex);
                case 4: return __TryExtractLinearIndex(source, index0, index1, index2, index3, out linearIndex);
            }

            if(indexes is null || indexes.Length < 1)
            {
                if (!__TryExtractLinearIndex(source, index0, index1, index2, index3, out linearIndex)) return false;
                return __TryFinalizeLinearIndex(4, source, linearIndex, out linearIndex);
            }

            return __TryExtractLinearIndex(source, out linearIndex, index0, index1, index2, index3, indexes);
        }

        [MethodImpl(MethodImplOptions.AggressiveOptimization)]
        public static Boolean __TryExtractLinearIndex(Array source, out Int64 linearIndex, Int64 index0, Int64 index1, Int64 index2, Int64 index3, params Int64[] indexes)
        {
            if (!__TryExtractLinearIndex(source, index0, index1, index2, index3, out linearIndex)) return false;

            var i = 4;

            var limit = Math.Min(source.Rank, i + indexes.Length);
            ref var indexesPointer0 = ref MemoryMarshal.GetArrayDataReference(indexes);

            while (i < limit)
            {
                if (!__TryCumulateLinearIndex(source, i, linearIndex, Unsafe.Add(ref indexesPointer0, i - 4), out linearIndex)) return false;
                i++;
            }

            return __TryFinalizeLinearIndex(i, source, linearIndex, out linearIndex);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static Boolean __TryInitializeLinearIndex(Array source, Int64 index, out Int64 linearIndex)
        {
            return __TryCumulateLinearIndex(source, 0, 0, index, out linearIndex);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static Boolean __TryCumulateLinearIndex(Array source, Int32 dimension, Int64 lastLinearIndex, Int64 index, out Int64 linearIndex)
        {
            __GetDimensionMetas(source, dimension, out var longLength, out var lowerBound, out var upperBound);
            if (!KozmosBoundHelper.IsInRange(index, lowerBound, upperBound)) { linearIndex = 0L; return false; }
            linearIndex = (longLength * lastLinearIndex) + (index - lowerBound); return true;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static Boolean __TryFinalizeLinearIndex(Array source, Int64 lastLinearIndex, Int64 index, out Int64 linearIndex)
        {
            return __TryCumulateLinearIndex(source, source.Rank -1, lastLinearIndex, index, out linearIndex);
        }

        [MethodImpl(MethodImplOptions.AggressiveOptimization | MethodImplOptions.AggressiveInlining)]
        private static Boolean __TryFinalizeLinearIndex(Int32 lastDimension, Array source, Int64 lastLinearIndex, out Int64 linearIndex)
        {
            while (lastDimension < source.Rank)
            {
                if (!__TryCumulateLinearIndex(source, lastDimension, lastLinearIndex, 0, out linearIndex)) return false;
                lastLinearIndex = linearIndex; lastDimension++;
            }

            linearIndex = lastLinearIndex;
            return true;
        }

        #endregion

        #endregion

        #endregion

        #region GetValue / TryGetValue

        #region Array

        public static T? GetValueByLinearIndex<T>(Array source, Int64 linearIndex)
        {
            //KozmosArgumentNullExceptionHelper.ThrowIfNull(source);
            //return source.GetValue(ExtractIndexes(source, linearIndex));
            #if DEBUG
            // In modalità Debug facciamo un controllo di sicurezza per evitare di distruggere la RAM.
            // In Release, grazie al JIT, questo blocco viene completamente rimosso (Zero overhead)
            if (source.GetType().GetElementType() != typeof(T))
            {
                throw new InvalidCastException($"L'array contiene elementi di tipo {source.GetType().GetElementType()}, ma stai cercando di leggerli come {typeof(T)}.");
            }
            #endif

            // 1. Otteniamo il riferimento managed all'inizio dei dati dell'array
            ref var rawData = ref MemoryMarshal.GetArrayDataReference(source);

            // 2. Re-interpretiamo il puntatore raw (Byte) nel tipo generico T passato dall'utente
            ref var typedData = ref Unsafe.As<Byte, T>(ref rawData);

            // 3. Spostiamo il puntatore calcolando l'offset corretto in base alla dimensione fisica di T
            return Unsafe.Add(ref typedData, (IntPtr)linearIndex);
        }

        #endregion

        #endregion

        #region Array

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