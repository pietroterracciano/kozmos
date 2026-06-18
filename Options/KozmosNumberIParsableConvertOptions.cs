using System;
using Kozmos.Enums;
using System.Globalization;

namespace Kozmos.Options
{
    public sealed class KozmosNumberIParsableConvertOptions
    {
        public static readonly KozmosNumberIParsableConvertOptions Default;

        static KozmosNumberIParsableConvertOptions()
        {
            Default = new KozmosNumberIParsableConvertOptions()
            {
                NumberStyles = NumberStyles.Any,
                FormatProvider = null
            };
        }

        public NumberStyles NumberStyles;
        public IFormatProvider? FormatProvider;
    }
}