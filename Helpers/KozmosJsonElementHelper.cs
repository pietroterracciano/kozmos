using System;
using System.Runtime.CompilerServices;
using System.Text.Json;
using Kozmos.Enums;

namespace Kozmos.Helpers
{
	public sealed class KozmosJsonElementHelper
	{
        #region Get / TryGet

        #region Get

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Int128 GetInt128(JsonElement source) { return KozmosInt128Helper.Convert(source.GetRawText()); }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static UInt128 GetUInt128(JsonElement source) { return KozmosUInt128Helper.Convert(source.GetRawText()); }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Decimal GetDecimal(JsonElement source) { return KozmosDecimalHelper.Convert(source.GetRawText()); }

        #endregion

        #region TryGet

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean TryGetUInt128(JsonElement source, out UInt128 result) { return KozmosUInt128Helper.TryConvert(source.GetRawText(), out result); }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean TryGetInt128(JsonElement source, out Int128 result) { return KozmosInt128Helper.TryConvert(source.GetRawText(), out result); }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean TryGetDecimal(JsonElement source, out Decimal result) { return KozmosDecimalHelper.TryConvert(source.GetRawText(), out result); }

        #endregion

        #endregion

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean IsValue(JsonElement? je) { return je.HasValue && IsValue(je.Value); }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean IsValue(JsonElement je)
        {
            switch(je.ValueKind)
            {
                case JsonValueKind.Null:
                case JsonValueKind.Undefined:
                case JsonValueKind.False:
                case JsonValueKind.True:
                case JsonValueKind.Number:
                case JsonValueKind.String:
                    return true;
                default:
                    return false;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean IsNumber(JsonElement? je) { return je.HasValue && IsNumber(je.Value); }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean IsNumber(JsonElement je) { return je.ValueKind == JsonValueKind.Number; }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean IsArray(JsonElement? je) { return je.HasValue && IsArray(je.Value); }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean IsArray(JsonElement je) { return je.ValueKind == JsonValueKind.Array; }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean IsBoolean(JsonElement? je) { return je.HasValue && IsBoolean(je.Value); }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean IsBoolean(JsonElement je)
        {
            switch (je.ValueKind)
            {
                case JsonValueKind.False:
                case JsonValueKind.True:
                    return true;
                default:
                    return false;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean IsUndefined(JsonElement? je) { return je.HasValue && IsUndefined(je.Value); }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean IsUndefined(JsonElement je) { return je.ValueKind == JsonValueKind.Undefined; }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean IsNull(JsonElement? je) { return je.HasValue && IsNull(je.Value); }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean IsNull(JsonElement je) { return je.ValueKind == JsonValueKind.Null; }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean IsString(JsonElement? je) { return je.HasValue && IsString(je.Value); }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean IsString(JsonElement je) { return je.ValueKind == JsonValueKind.String; }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean IsObject(JsonElement? je) { return je.HasValue && IsObject(je.Value); }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean IsObject(JsonElement je) { return je.ValueKind == JsonValueKind.Object; }
    }
}

