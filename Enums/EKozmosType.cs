using System;
namespace Kozmos.Enums
{
    public enum EKozmosType : byte
    {
        #region Codeds

        NullableChar,
        Char,

        #endregion

        #region Conditionals

        NullableBoolean,
        Boolean,

        #endregion

        #region Indexings

        #region Guid

        NullableGuid,
        Guid,

        #endregion

        #endregion

        #region Numericals

        NullableByte,
        Byte,

        NullableSByte,
        SByte,

        NullableUInt16,
        UInt16,

        NullableInt16,
        Int16,

        NullableUInt32,
        UInt32,

        NullableInt32,
        Int32,

        NullableUInt64,
        UInt64,

        NullableInt64,
        Int64,

        NullableUInt128,
        UInt128,

        NullableInt128,
        Int128,

        NullableBigInteger,
        BigInteger,

        NullableSingle,
        Single,

        NullableDouble,
        Double,

        NullableDecimal,
        Decimal,

        #endregion

        #region Reflections

        PropertyInfo,
        FieldInfo,
        ConstructorInfo,
        MethodInfo,
        MemberInfo,

        #endregion

        #region Spannables

        ReadOnlySpanChar,

        #endregion

        #region Temporals

        #region DateOnly

        NullableDateOnly,
        DateOnly,

        #endregion

        #region DateTime

        NullableDateTime,
        DateTime,

        #endregion

        #region DateTimeOffset

        NullableDateTimeOffset,
        DateTimeOffset,

        #endregion

        #region TimeSpan

        NullableTimeSpan,
        TimeSpan,

        #endregion

        #region TimeOnly

        NullableTimeOnly,
        TimeOnly,

        #endregion

        #endregion

        #region Textuals

        String,
        StringBuilder,

        #endregion
    }
}