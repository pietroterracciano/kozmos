using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Kozmos.Collections.Generic.Interfaces;

namespace Kozmos.Collections.Generic
{
    public sealed class
        KozmosSemiFrozenDictionary<TKey, TValue>
    :
        IKozmosDictionary<TKey, TValue>
    where
        TKey : notnull
    {
        public TValue this[TKey key]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return _RequireFrozenDictionary()[key]; }
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set { _dictionary[key] = value; _frozenDictionary = null; }
        }

        public ReadOnlySpan<TKey> Keys
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return _RequireFrozenKeys(); }
        }

        public ReadOnlySpan<TValue> Values
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return _RequireFrozenValues(); }
        }

        public int Count
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return _RequireFrozenDictionary().Count; }
        }

        private readonly Dictionary<TKey, TValue> _dictionary;
        private FrozenDictionary<TKey, TValue>? _frozenDictionary;
        private TKey[]? _frozenKeys;
        private TValue[]? _frozenValues;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public KozmosSemiFrozenDictionary() { _dictionary = new(); }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public KozmosSemiFrozenDictionary(IEqualityComparer<TKey> equalityComparer) { _dictionary = new(equalityComparer); }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public KozmosSemiFrozenDictionary(Int32 capacity) { _dictionary = new(capacity); }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public KozmosSemiFrozenDictionary(Int32 capacity, IEqualityComparer<TKey> equalityComparer) { _dictionary = new(capacity, equalityComparer); }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Add(TKey key, TValue value) { _dictionary.Add(key, value); _frozenDictionary = null; }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Boolean TryAdd(TKey key, TValue value) { bool b = _dictionary.TryAdd(key, value); if(b) _frozenDictionary = null; return b; }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Clear() { _dictionary.Clear(); _frozenDictionary = null; }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool ContainsKey(TKey key) { return _RequireFrozenDictionary().ContainsKey(key); }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool TryGetValue(TKey key, out TValue value) { return _RequireFrozenDictionary().TryGetValue(key, out value); }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private FrozenDictionary<TKey, TValue> _RequireFrozenDictionary()
        {
            var frozenDictionary = _frozenDictionary;
            if (frozenDictionary is not null) return frozenDictionary;
            return _frozenDictionary = _dictionary.ToFrozenDictionary();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private TKey[] _RequireFrozenKeys()
        {
            var frozenKeys = _frozenKeys;
            if (frozenKeys is not null) return frozenKeys;
            return _frozenKeys = _RequireFrozenDictionary().Keys.ToArray();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private TValue[] _RequireFrozenValues()
        {
            var frozenValues = _frozenValues;
            if (frozenValues is not null) return frozenValues;
            return _frozenValues = _RequireFrozenDictionary().Values.ToArray();
        }
    }
}

