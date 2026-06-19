using System;
using Kozmos.Collections.Generic;

namespace Kozmos.Helpers.Enumeratives
{
	public static class KozmosEnumHelper<T>
		where T : notnull
	{
		private static readonly Object __lck;
		private static readonly KozmosConcurrentSemiFrozenDictionary<T, Enum[]> __kcsfd;

		static KozmosEnumHelper()
		{
			__kcsfd = new();
			__lck = new();
        }
	}
}

