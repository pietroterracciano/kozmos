using System;
using System.Runtime.CompilerServices;
using Kozmos.Helpers.Exceptions;

namespace Kozmos.Helpers
{
	public static class KozmosBoundHelper
	{
        #region public static Boolean IsInRange(...)

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean IsInRange(Int32 value, Int32 minBound, Int32 maxBound) { return minBound <= maxBound && (UInt32)value - (UInt32)minBound <= (UInt32)maxBound - (UInt32)minBound; }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean IsInRange(Int64 value, Int64 minBound, Int64 maxBound) { return minBound <= maxBound && (UInt64)value - (UInt64)minBound <= (UInt64)maxBound - (UInt64)minBound; }

        #endregion

        #region public static Boolean IsInZLBRange(...)

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean IsInZLBRange(Int32 value, Int32 maxBound) { return maxBound > -1 && (UInt32)value <= (UInt32)maxBound; }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean IsInZLBRange(Int64 value, Int64 maxBound) { return maxBound > -1 && (UInt64)value <= (UInt64)maxBound; }

        #endregion
    }
}

