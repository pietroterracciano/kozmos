using System;
using System.Numerics;
using System.Runtime.CompilerServices;
using Kozmos.Constants;
using Kozmos.Helpers.Exceptions;
using Kozmos.Helpers.Numericals;

namespace Kozmos.Helpers
{
	public static class KozmosObjectHelper
	{
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Boolean TryCast<T>(Object? source, out T result)
        {
            // HotPath >
            if (source is T o) { result = o; return true; }
            // < HotPath
            else if (source is null) { result = default!; return KozmosTypeHelper<T>.IsNullable; }
            else { result = default!; return false; }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T Cast<T>(Object source)
        {
            // HotPath >
            if (source is T o) return o;
            // < HotPath
            KozmosArgumentNullExceptionHelper.ThrowIfNull(source);
            KozmosArgumentExceptionHelper.Throw
            (
                KozmosMessages.Exceptions.UnableToCastArgument_0_OfType_1_ToType_2,
                nameof(source),
                source.GetType(),
                KozmosTypeHelper<T>._
            );
            return default!;
        }

        [MethodImpl(MethodImplOptions.AggressiveOptimization)]
        public static Object? Convert(Object? source, Type resultType)
        {
            switch(resultType)
            {
                #region Numericals

                case Type t when t == KozmosTypeHelper<Byte>._: return KozmosByteHelper.Convert(source);
                case Type t when t == KozmosTypeHelper<SByte>._: return KozmosSByteHelper.Convert(source);
                case Type t when t == KozmosTypeHelper<UInt16>._: return KozmosUInt16Helper.Convert(source);
                case Type t when t == KozmosTypeHelper<Int16>._: return KozmosInt16Helper.Convert(source);
                case Type t when t == KozmosTypeHelper<UInt32>._: return KozmosUInt32Helper.Convert(source);
                case Type t when t == KozmosTypeHelper<Int32>._: return KozmosInt32Helper.Convert(source);
                case Type t when t == KozmosTypeHelper<UInt64>._: return KozmosUInt64Helper.Convert(source);
                case Type t when t == KozmosTypeHelper<Int64>._: return KozmosInt64Helper.Convert(source);
                case Type t when t == KozmosTypeHelper<UInt128>._: return KozmosUInt128Helper.Convert(source);
                case Type t when t == KozmosTypeHelper<Int128>._: return KozmosInt128Helper.Convert(source);
                case Type t when t == KozmosTypeHelper<BigInteger>._: return KozmosBigIntegerHelper.Convert(source);
                case Type t when t == KozmosTypeHelper<Single>._: return KozmosSingleHelper.Convert(source);
                case Type t when t == KozmosTypeHelper<Double>._: return KozmosDoubleHelper.Convert(source);
                case Type t when t == KozmosTypeHelper<Decimal>._: return KozmosDecimalHelper.Convert(source);

                #endregion

                case null: KozmosArgumentNullExceptionHelper.Throw(resultType); return null;

                default:
                    return null;
            }


            return null;
        }
    }
}