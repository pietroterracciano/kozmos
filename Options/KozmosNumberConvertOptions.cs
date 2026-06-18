using System;
using System.Globalization;
using Kozmos.Enums;

namespace Kozmos.Options
{
	public sealed class KozmosNumberConvertOptions
	{
		public static readonly KozmosNumberConvertOptions Default;

		static KozmosNumberConvertOptions()
		{
			Default = new KozmosNumberConvertOptions()
			{
				TimeSpanComponent = EKozmosTimeSpanComponent.Ticks,
                DateOnlyComponent = EKozmosDateOnlyComponent.DayNumber,
                TimeOnlyComponent = EKozmosTimeOnlyComponent.Ticks,
                DateTimeOffsetComponent = EKozmosDateTimeOffsetComponent.Ticks,
                DateTimeComponent = EKozmosDateTimeComponent.Ticks,
				CharComponent = EKozmosCharComponent.Numeric,
                IParsableConvertOptions = KozmosNumberIParsableConvertOptions.Default
            };
		}

		public EKozmosTimeSpanComponent TimeSpanComponent;
        public EKozmosDateOnlyComponent DateOnlyComponent;
        public EKozmosTimeOnlyComponent TimeOnlyComponent;
        public EKozmosDateTimeOffsetComponent DateTimeOffsetComponent;
        public EKozmosDateTimeComponent DateTimeComponent;
		public EKozmosCharComponent CharComponent;
		public KozmosNumberIParsableConvertOptions? IParsableConvertOptions;
	}
}
