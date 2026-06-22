using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kozmos.Helpers.Numericals;

namespace Kozmos.Helpers
{
	public static class KozmosMemoryMarshalHelper
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean WillOverflowWhenCastToIntPtr(Int64 source)
		{
            return
                !Environment.Is64BitProcess
                && !KozmosBoundHelper.IsInRange(source, KozmosInt32Helper.MinValue, KozmosInt32Helper.MaxValue);
        }
	}
}

