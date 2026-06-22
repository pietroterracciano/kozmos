using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Kozmos.Helpers;
using Kozmos.Helpers.Collectibles;
using Kozmos.Helpers.Exceptions;

namespace Kozmos.Cursors
{
    public ref struct KozmosMarshalCursor<T>
    {
        private ref T
            _startPointer,
            _currentPointer,
            _endPointer;

        private Boolean
            _isReadOnly;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public KozmosMarshalCursor() { KozmosInvalidOperationExceptionHelper.Throw(); }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private KozmosMarshalCursor(Array source)
        {
            _isReadOnly = source.IsReadOnly;
            _currentPointer = ref Unsafe.As<Byte, T>(ref MemoryMarshal.GetArrayDataReference(source));
            _startPointer = ref _currentPointer;
            _endPointer = ref Unsafe.Add(ref _currentPointer, source.Length);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private KozmosMarshalCursor(T[] source)
        {
            _isReadOnly = source.IsReadOnly;
            _currentPointer = ref MemoryMarshal.GetArrayDataReference(source);
            _startPointer = ref _currentPointer;
            _endPointer = ref Unsafe.Add(ref _currentPointer, source.Length);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private KozmosMarshalCursor(Span<T> source)
        {
            _isReadOnly = false;
            _currentPointer = ref MemoryMarshal.GetReference(source);
            _startPointer = ref _currentPointer;
            _endPointer = ref Unsafe.Add(ref _currentPointer, source.Length);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private KozmosMarshalCursor(ReadOnlySpan<T> source)
        {
            _isReadOnly = true;
            _currentPointer = ref MemoryMarshal.GetReference(source);
            _startPointer = ref _currentPointer;
            _endPointer = ref Unsafe.Add(ref _currentPointer, source.Length);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private Boolean _CanOperate() { return !Unsafe.IsNullRef(ref _currentPointer); }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Boolean CanRetreat() { return _CanOperate() && Unsafe.IsAddressGreaterThan(ref _currentPointer, ref _startPointer); }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Boolean CanAdvance() { return _CanOperate() && Unsafe.IsAddressLessThan(ref _currentPointer, ref _endPointer); }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Boolean CanRead()
        {
            return
                _CanOperate()
                && !Unsafe.IsAddressLessThan(ref _currentPointer, ref _startPointer)
                && Unsafe.IsAddressLessThan(ref _currentPointer, ref _endPointer);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Boolean CanWrite() { return _CanOperate() && !_isReadOnly; }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Boolean CanMoveTo(Int32 offset)
        {
            if (!_CanOperate()) return false;
            ref T pointer = ref Unsafe.Add(ref _startPointer, offset);
            return
                !Unsafe.IsAddressLessThan(ref pointer, ref _startPointer)
                && Unsafe.IsAddressLessThan(ref pointer, ref _endPointer);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Boolean CanMoveTo(Int64 offset)
        {
            if (!_CanOperate()) return false;
            ref T pointer = ref KozmosUnsafeHelper.Add(ref _startPointer, offset);
            return
                !Unsafe.IsAddressLessThan(ref pointer, ref _startPointer)
                && Unsafe.IsAddressLessThan(ref pointer, ref _endPointer);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Advance() { _EnsureCanAdvance(); AdvanceUnsafe(); }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void AdvanceUnsafe() { _currentPointer = ref Unsafe.Add(ref _currentPointer, 1); }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void MoveTo(Int32 offset) { _EnsureCanMoveTo(offset); MoveToUnsafe(offset); }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void MoveToUnsafe(Int32 offset) { _currentPointer = ref Unsafe.Add(ref _startPointer, offset); }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void MoveTo(Int64 offset) { _EnsureCanMoveTo(offset); MoveToUnsafe(offset); }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void MoveToUnsafe(Int64 offset) { _currentPointer = ref KozmosUnsafeHelper.Add(ref _startPointer, offset); }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Retreat() { _EnsureCanRetreat(); RetreatUnsafe(); }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void RetreatUnsafe() { _currentPointer = ref Unsafe.Add(ref _currentPointer, -1); }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void SetCurrentValue(T source) { _EnsureCanWrite(); SetCurrentValueUnsafe(source); }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void SetCurrentValueUnsafe(T source) { _currentPointer = source; }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public T GetCurrentValue() { _EnsureCanRead(); return GetCurrentValueUnsafe(); }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public T GetCurrentValueUnsafe() { return _currentPointer; }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void _EnsureCanWrite()
        {
            if (!_isReadOnly) return;
            KozmosInvalidOperationExceptionHelper.Throw();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void _EnsureCanRead()
        {
            if (CanRead()) return;
            KozmosInvalidOperationExceptionHelper.Throw();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void _EnsureCanAdvance()
        {
            if (CanAdvance()) return;
            KozmosInvalidOperationExceptionHelper.Throw();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void _EnsureCanMoveTo(Int32 offset)
        {
            if (CanMoveTo(offset)) return;
            KozmosInvalidOperationExceptionHelper.Throw();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void _EnsureCanMoveTo(Int64 offset)
        {
            if (CanMoveTo(offset)) return;
            KozmosInvalidOperationExceptionHelper.Throw();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void _EnsureCanRetreat()
        {
            if (CanRetreat()) return;
            KozmosInvalidOperationExceptionHelper.Throw();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static KozmosMarshalCursor<T> Create(Array source)
        {
            KozmosArgumentNullExceptionHelper.ThrowIfNull(source);
            if (source is not T[] || source.LongLength < 1) KozmosArgumentOutOfRangeExceptionHelper.Throw();
            return new(source);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static KozmosMarshalCursor<T> CreateUnsafe(Array source)
        {
            return new(source);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static KozmosMarshalCursor<T> Create(T[] source)
        {
            KozmosArgumentNullExceptionHelper.ThrowIfNull(source);
            if (source.LongLength < 1) KozmosArgumentOutOfRangeExceptionHelper.Throw();
            return new(source);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static KozmosMarshalCursor<T> CreateUnsafe(T[] source)
        {
            return new(source);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static KozmosMarshalCursor<T> Create(Span<T> source)
        {
            if (source.Length < 1) KozmosArgumentOutOfRangeExceptionHelper.Throw();
            return new(source);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static KozmosMarshalCursor<T> CreateUnsafe(Span<T> source)
        {
            return new(source);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static KozmosMarshalCursor<T> Create(ReadOnlySpan<T> source)
        {
            if (source.Length < 1) KozmosArgumentOutOfRangeExceptionHelper.Throw();
            return new(source);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static KozmosMarshalCursor<T> CreateUnsafe(ReadOnlySpan<T> source)
        {
            return new(source);
        }
    }
}