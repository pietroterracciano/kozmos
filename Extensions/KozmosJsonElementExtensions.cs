using System.Runtime.CompilerServices;
using Kozmos.Helpers;

namespace System.Text.Json
{
	public static class KozmosJsonElementExtensions
	{
        #region public static ... Try...(...)

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 GetUInt128(this JsonElement source)
        {
            return KozmosJsonElementHelper.GetUInt128(source);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Int128 GetInt128(this JsonElement source)
        {
            return KozmosJsonElementHelper.GetInt128(source);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean TryGetUInt128(this JsonElement source, out UInt128 result)
        {
            return KozmosJsonElementHelper.TryGetUInt128(source, out result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean TryGetInt128(this JsonElement source, out Int128 result)
        {
            return KozmosJsonElementHelper.TryGetInt128(source, out result);
        }

        #endregion
    }
}

