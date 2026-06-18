using System;
namespace Kozmos.Enums
{
    public enum EKozmosDateTimeOffsetComponent : Byte
    {
        Ticks,
        Nanosecond,
        Microsecond,
        Millisecond,
        Second,
        Minute,
        Hour,
        Day,
        DayOfWeek,
        DayOfYear,
        Month,
        Year
    }
}