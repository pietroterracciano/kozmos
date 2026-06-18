using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Kozmos.Collections.Generic.Interfaces;

namespace Kozmos.Collections.Generic
{
    public sealed class
        KozmosConcurrentSemiFrozenDictionary<TKey, TValue>
    :
        IKozmosDictionary<TKey, TValue>
    where
        TKey : notnull
    {
        public TValue this[TKey key]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return _RequireFrozenDictionary()[key]; }
            [MethodImpl(MethodImplOptions.NoInlining)]
            set { lock(_lock) { _dictionary[key] = value; _frozenDictionary = null; } }
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

        private readonly Object _lock;
        private readonly Dictionary<TKey, TValue> _dictionary;
        private volatile FrozenDictionary<TKey, TValue>? _frozenDictionary;
        private volatile TKey[]? _frozenKeys;
        private volatile TValue[]? _frozenValues;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public KozmosConcurrentSemiFrozenDictionary() { _lock = new(); _dictionary = new(); }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public KozmosConcurrentSemiFrozenDictionary(IEqualityComparer<TKey> equalityComparer) { _lock = new(); _dictionary = new(equalityComparer); }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public KozmosConcurrentSemiFrozenDictionary(Int32 capacity) { _lock = new(); _dictionary = new(capacity); }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public KozmosConcurrentSemiFrozenDictionary(Int32 capacity, IEqualityComparer<TKey> equalityComparer) { _lock = new(); _dictionary = new(capacity, equalityComparer); }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public void Add(TKey key, TValue value) { lock(_lock) { _dictionary.Add(key, value); _frozenDictionary = null; } }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public Boolean TryAdd(TKey key, TValue value) { lock(_lock) { bool b = _dictionary.TryAdd(key, value); if (b) _frozenDictionary = null; return b; } }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public void Clear() { lock(_lock) { _dictionary.Clear(); _frozenDictionary = null; } }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool ContainsKey(TKey key) { return _RequireFrozenDictionary().ContainsKey(key); }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool TryGetValue(TKey key, out TValue value) { return _RequireFrozenDictionary().TryGetValue(key, out value); }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private FrozenDictionary<TKey, TValue> _RequireFrozenDictionary()
        {
            var frozenDictionary = _frozenDictionary;
            if (frozenDictionary is not null) return frozenDictionary;
            return _RequireFrozenDictionary_NoInlining();
        }
        [MethodImpl(MethodImplOptions.NoInlining)]
        private FrozenDictionary<TKey, TValue> _RequireFrozenDictionary_NoInlining() { lock(_lock) { return _RequireFrozenDictionary_NoLock(); } }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private FrozenDictionary<TKey, TValue> _RequireFrozenDictionary_NoLock()
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
            return _RequireFrozenKeys_NoInlining();
        }
        [MethodImpl(MethodImplOptions.NoInlining)]
        private TKey[] _RequireFrozenKeys_NoInlining()
        {
            lock (_lock)
            {
                var frozenKeys = _frozenKeys;
                if (frozenKeys is not null) return frozenKeys;
                return _frozenKeys = _RequireFrozenDictionary_NoLock().Keys.ToArray();
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private TValue[] _RequireFrozenValues()
        {
            var frozenValues = _frozenValues;
            if (frozenValues is not null) return frozenValues;
            return _RequireFrozenValues_NoInlining();
        }
        [MethodImpl(MethodImplOptions.NoInlining)]
        private TValue[] _RequireFrozenValues_NoInlining()
        {
            lock (_lock)
            {
                var frozenValues = _frozenValues;
                if (frozenValues is not null) return frozenValues;
                return _frozenValues = _RequireFrozenDictionary_NoLock().Values.ToArray();
            }
        }
    }
}