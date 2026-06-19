using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Runtime.CompilerServices;
using System.Xml.Linq;
using Kozmos.Collections.Generic;
using Kozmos.Helpers.Collectibles;
using Kozmos.Helpers.Exceptions;

namespace Kozmos.Helpers.Enumeratives
{
	public static class KozmosEnumHelper
	{
        private static readonly Enum[] __ea;
        private static readonly Object __lck;
        private static readonly KozmosConcurrentSemiFrozenDictionary<Type, Enum[]> __kcsfd;

        static KozmosEnumHelper()
        {
            __ea = Array.Empty<Enum>();
            __lck = new();
            __kcsfd = new();
        }

        #region public static Enum[]? GetFlags(...)

        [MethodImpl(MethodImplOptions.AggressiveOptimization)]
        public static Enum[] GetFlags(Type source)
        {
            KozmosArgumentNullExceptionHelper.ThrowIfNull(source);

            // HotPath >
            if (__kcsfd.TryGetValue(source, out Enum[] ea)) return ea;
            // < HotPath

            Array a = Enum.GetValues(source);

            if(a.Length < 1) return __kcsfd[source] = __ea;

            String c = "P";
            Enum[] aaaa = (Enum[])KozmosArrayHelper.Convert(a, typeof(Enum));

            Enum cc = aaaa[0];

            String rpew = cc.ToString();

            return ea;
        }

        #endregion

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void __AssertGetFlags(Type source, [CallerArgumentExpression(nameof(source))] String? argumentName = null)
        {
            KozmosArgumentNullExceptionHelper.ThrowIfNull(source);
            if (source.IsEnum) return;
            KozmosArgumentExceptionHelper.ThrowValue_0_OfArgument_1_2_IsNotSupported(source, argumentName);
        }

    }
}

