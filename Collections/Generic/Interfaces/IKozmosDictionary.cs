using System;
using System.Runtime.CompilerServices;

namespace Kozmos.Collections.Generic.Interfaces
{
    public interface IKozmosDictionary<TKey, TValue>
        where TKey : notnull
    {
        public TValue this[TKey key]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get;
        }

        public ReadOnlySpan<TKey> Keys
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get;
        }

        public ReadOnlySpan<TValue> Values
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get;
        }

        public int Count
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Add(TKey key, TValue value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Boolean TryAdd(TKey key, TValue value);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Clear();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Boolean ContainsKey(TKey key);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Boolean TryGetValue(TKey key, out TValue value);
    }
}

