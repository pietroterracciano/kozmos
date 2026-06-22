using System;
using System.Runtime.CompilerServices;
using Kozmos.Helpers.Numericals;

namespace Kozmos.Helpers
{
	public static class KozmosUnsafeHelper
	{
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ref T Add<T>(ref T source, Int64 offset)
        {
            if(offset <= Int32.MaxValue) return ref Unsafe.Add(ref source, (Int32)offset);
            return ref Add(ref Add(ref source, Int32.MaxValue), (Int32)(offset - Int32.MaxValue));
        }
    }
}

