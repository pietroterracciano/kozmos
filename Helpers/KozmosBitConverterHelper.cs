using System;
using System.Runtime.CompilerServices;
using Kozmos.Constants;
using Kozmos.Enums;

namespace Kozmos.Helpers
{
	public static class KozmosBitConverterHelper
	{
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static Boolean TryToUInt16(Byte[]? source, out UInt16 result)
		{
            if (source is not null) try { result = BitConverter.ToUInt16(source, 0); return true; } catch { }
            result = default; return false;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static Boolean TryToInt16(Byte[]? source, out Int16 result)
        {
            if (source is not null) try { result = BitConverter.ToInt16(source, 0); return true; } catch { }
            result = default; return false;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static Boolean TryToUInt32(Byte[]? source, out UInt32 result)
        {
            if (source is not null) try { result = BitConverter.ToUInt32(source, 0); return true; } catch { }
            result = default; return false;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static Boolean TryToInt32(Byte[]? source, out Int32 result)
        {
            if (source is not null) try { result = BitConverter.ToInt32(source, 0); return true; } catch { }
            result = default; return false;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static Boolean TryToUInt64(Byte[]? source, out UInt64 result)
        {
            if (source is not null) try { result = BitConverter.ToUInt64(source, 0); return true; } catch { }
            result = default; return false;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static Boolean TryToInt64(Byte[]? source, out Int64 result)
        {
            if (source is not null) try { result = BitConverter.ToInt64(source, 0); return true; } catch { }
            result = default; return false;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static Boolean TryToSingle(Byte[]? source, out Single result)
        {
            if (source is not null) try { result = BitConverter.ToSingle(source, 0); return true; } catch { }
            result = default; return false;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static Boolean TryToDouble(Byte[]? source, out Double result)
        {
            if (source is not null) try { result = BitConverter.ToDouble(source, 0); return true; } catch { }
            result = default; return false;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static Boolean TryToBoolean(Byte[]? source, out Boolean result)
        {
            if (source is not null) try { result = BitConverter.ToBoolean(source, 0); return true; } catch { }
            result = default; return false;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static Boolean TryToChar(Byte[]? source, out Char result)
        {
            if (source is not null) try { result = BitConverter.ToChar(source, 0); return true; } catch { }
            result = default; return false;
        }
    }
}

