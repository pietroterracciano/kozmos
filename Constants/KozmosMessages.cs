using System;
namespace Kozmos.Constants
{
	internal static class KozmosMessages
	{
        internal const String
            LogPrefix = "[" + nameof(Kozmos) + "]";

        internal static class Exceptions
        {
            internal const String
                TheTypeParameter_0_1_IsNotSupported
                    = "The type parameter '{0}' ('{1}') is not supported",

                TheTypeParameter_0_1_IsNotRegisteredInTheCache
                    = "The type parameter '{0}' ('{1}') is not registered in the cache",

                UnableToProcessConversionBecauseTheTypeParameter_0_OfType_1_IsNotRegisteredInTheCache
                    = "Unable to process conversion because the type parameter '{0}' of type '{1}' is not registered in the cache",
                UnableToConvertArgument_0_OfType_1_ToType_2
                    = "Unable to convert argument '{0}' of type '{1}' to type '{2}'",
                UnableToConvertValue_0_OfArgument_1_OfType_2_ToType_3
                    = "Unable to convert value '{0}' of argument '{1}' of type '{2}' to type '{3}'",

                UnableToCastArgument_0_OfType_1_ToType_2
                    = "Unable to cast argument '{0}' of type '{1}' to type '{2}'",


                ValueCanNotBeNull
                    = "Value cannot be null.",

                Argument_0_1_IsNotSupported
                    = "Argument '{0}' ('{1}') is not supported",

                Value_0_OfArgument_1_2_IsNotSupported
                    = "Value '{0}' of argument '{1}' ('{2}') is not supported",

                Value_0_OfMember_1_2_OfArgument_3_4_IsNotSupported
                    = "Value '{0}' of member '{1}' ('{2}') of argument '{3}' ('{4}') is not supported";
        }
    }
}

