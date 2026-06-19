using System;
using System.Numerics;
using System.Runtime.CompilerServices;
using Kozmos.Constants;
using System.Text;
using Kozmos.Enums;
using Kozmos.Helpers.Exceptions;

namespace Kozmos.Helpers
{
	public sealed class KozmosTypeHelper<T>
	{
        public static readonly Type _;
        public static readonly EKozmosType? Enum;
        public static readonly String Name;
        public static readonly String? FullName;
        public static readonly String FullNameOrName;
        public static readonly Int32 UnsafeSize;
        public static readonly Boolean IsNullable;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static KozmosTypeHelper()
        {
            _ = typeof(T);
            UnsafeSize = Unsafe.SizeOf<T>();
            Name = _.Name;
            FullName = _.FullName;
            FullNameOrName = FullName ?? Name;
            IsNullable = KozmosTypeHelper.IsNullable(_);
        }

        [MethodImpl(MethodImplOptions.AggressiveOptimization)]
        private static Boolean __FetchEType(Type source, out EKozmosType ekt)
        {
            switch (source)
            {
                #region Codeds

                case Type t0 when t0 == typeof(Char): ekt = EKozmosType.Char; return true;
                case Type t0 when t0 == typeof(Char?): ekt = EKozmosType.NullableChar; return true;

                #endregion

                #region Conditionals

                case Type t0 when t0 == typeof(Boolean): ekt = EKozmosType.Boolean; return true;
                case Type t0 when t0 == typeof(Boolean?): ekt = EKozmosType.NullableBoolean; return true;

                #endregion

                #region Indexings

                case Type t0 when t0 == typeof(Guid): ekt = EKozmosType.Guid; return true;
                case Type t0 when t0 == typeof(Guid?): ekt = EKozmosType.NullableGuid; return true;

                #endregion

                #region Numericals

                case Type t0 when t0 == typeof(Byte): ekt = EKozmosType.Byte; return true;
                case Type t0 when t0 == typeof(Byte?): ekt = EKozmosType.NullableByte; return true;

                case Type t0 when t0 == typeof(SByte): ekt = EKozmosType.SByte; return true;
                case Type t0 when t0 == typeof(SByte?): ekt = EKozmosType.NullableSByte; return true;

                case Type t0 when t0 == typeof(UInt16): ekt = EKozmosType.UInt16; return true;
                case Type t0 when t0 == typeof(UInt16?): ekt = EKozmosType.NullableUInt16; return true;

                case Type t0 when t0 == typeof(Int16): ekt = EKozmosType.Int16; return true;
                case Type t0 when t0 == typeof(Int16?): ekt = EKozmosType.NullableInt16; return true;

                case Type t0 when t0 == typeof(UInt32): ekt = EKozmosType.UInt32; return true;
                case Type t0 when t0 == typeof(UInt32?): ekt = EKozmosType.NullableUInt32; return true;

                case Type t0 when t0 == typeof(Int32): ekt = EKozmosType.Int32; return true;
                case Type t0 when t0 == typeof(Int32?): ekt = EKozmosType.NullableInt32; return true;

                case Type t0 when t0 == typeof(UInt64): ekt = EKozmosType.UInt64; return true;
                case Type t0 when t0 == typeof(UInt64?): ekt = EKozmosType.NullableUInt64; return true;

                case Type t0 when t0 == typeof(Int64): ekt = EKozmosType.Int64; return true;
                case Type t0 when t0 == typeof(Int64?): ekt = EKozmosType.NullableInt64; return true;

                case Type t0 when t0 == typeof(UInt128): ekt = EKozmosType.UInt128; return true;
                case Type t0 when t0 == typeof(UInt128?): ekt = EKozmosType.NullableUInt128; return true;

                case Type t0 when t0 == typeof(Int128): ekt = EKozmosType.Int128; return true;
                case Type t0 when t0 == typeof(Int128?): ekt = EKozmosType.NullableInt128; return true;

                case Type t0 when t0 == typeof(BigInteger): ekt = EKozmosType.BigInteger; return true;
                case Type t0 when t0 == typeof(BigInteger?): ekt = EKozmosType.NullableBigInteger; return true;

                case Type t0 when t0 == typeof(Single): ekt = EKozmosType.Single; return true;
                case Type t0 when t0 == typeof(Single?): ekt = EKozmosType.NullableSingle; return true;

                case Type t0 when t0 == typeof(Double): ekt = EKozmosType.Double; return true;
                case Type t0 when t0 == typeof(Double?): ekt = EKozmosType.NullableDouble; return true;

                case Type t0 when t0 == typeof(Decimal): ekt = EKozmosType.Decimal; return true;
                case Type t0 when t0 == typeof(Decimal?): ekt = EKozmosType.NullableDecimal; return true;

                #endregion

                #region Temporals

                #region DateOnly

                case Type t0 when t0 == typeof(DateOnly): ekt = EKozmosType.DateOnly; return true;
                case Type t0 when t0 == typeof(DateOnly?): ekt = EKozmosType.NullableDateOnly; return true;

                #endregion

                #region DateTime

                case Type t0 when t0 == typeof(DateTime): ekt = EKozmosType.DateTime; return true;
                case Type t0 when t0 == typeof(DateTime?): ekt = EKozmosType.NullableDateTime; return true;

                #endregion

                #region DateTimeOffset

                case Type t0 when t0 == typeof(DateTimeOffset): ekt = EKozmosType.DateTimeOffset; return true;
                case Type t0 when t0 == typeof(DateTimeOffset?): ekt = EKozmosType.NullableDateTimeOffset; return true;

                #endregion

                #region TimeSpan

                case Type t0 when t0 == typeof(TimeSpan): ekt = EKozmosType.TimeSpan; return true;
                case Type t0 when t0 == typeof(TimeSpan?): ekt = EKozmosType.NullableTimeSpan; return true;

                #endregion

                #region TimeOnly

                case Type t0 when t0 == typeof(TimeOnly): ekt = EKozmosType.TimeOnly; return true;
                case Type t0 when t0 == typeof(TimeOnly?): ekt = EKozmosType.NullableTimeOnly; return true;

                #endregion

                #endregion

                #region Textuals

                case Type t0 when t0 == typeof(String): ekt = EKozmosType.String; return true;
                case Type t0 when t0 == typeof(StringBuilder): ekt = EKozmosType.StringBuilder; return true;

                #endregion

                default: ekt = default; return false;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void AssertTypeParameterCache()
        {
            AssertTypeParameterCache(null);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void AssertTypeParameterCache(String? name)
        {
            if (Enum.HasValue) return;
            KozmosExceptionHelper<T>.ThrowTheTypeParameter_0_1_IsNotRegisteredInTheCache(name);
        }
    }
}