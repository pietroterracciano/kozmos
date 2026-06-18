using System;
using Kozmos.Helpers;
using System.Runtime.CompilerServices;

namespace System
{
	public static class KozmosTypeExtensions
	{
        #region public static String GetFullNameOrName(...)

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static String GetFullNameOrName(this Type type) { return KozmosTypeHelper.GetFullNameOrName(type); }

        #endregion

        #region public static String IsNullable(...)

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean IsNullable(this Type type) { return KozmosTypeHelper.IsNullable(type); }

        #endregion
    }
}