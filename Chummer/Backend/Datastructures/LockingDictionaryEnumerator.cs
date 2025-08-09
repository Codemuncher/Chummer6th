/*  This file is part of Chummer5a.
 *
 *  Chummer5a is free software: you can redistribute it and/or modify
 *  it under the terms of the GNU General Public License as published by
 *  the Free Software Foundation, either version 3 of the License, or
 *  (at your option) any later version.
 *
 *  Chummer5a is distributed in the hope that it will be useful,
 *  but WITHOUT ANY WARRANTY; without even the implied warranty of
 *  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 *  GNU General Public License for more details.
 *
 *  You should have received a copy of the GNU General Public License
 *  along with Chummer5a.  If not, see <http://www.gnu.org/licenses/>.
 *
 *  You can obtain the full source code for Chummer5a at
 *  https://github.com/chummer5a/chummer5a
 */

using System;
using System.Collections;
using System.Threading;
using System.Threading.Tasks;

namespace Chummer
{
    public sealed class LockingDictionaryEnumerator : IDictionaryEnumerator, IDisposable, IAsyncDisposable
    {
        private readonly IDisposable _objMyRelease;
        private readonly IAsyncDisposable _objMyReleaseAsync;

        private IDictionaryEnumerator _objInternalEnumerator;

        public static LockingDictionaryEnumerator Get(IHasLockObject objMyParent, CancellationToken token = default)
        {
            IDisposable objMyRelease = objMyParent.LockObject.IsInPotentialWriteLock
                ? objMyParent.LockObject.EnterUpgradeableReadLock(token)
                : objMyParent.LockObject.EnterReadLockWithMatchingParentLock(token);
            return new LockingDictionaryEnumerator(objMyRelease);
        }

        public static Task<LockingDictionaryEnumerator> GetAsync(IHasLockObject objMyParent, CancellationToken token = default)
        {
            // Needs to be like this (using async inner function) to make sure AsyncLocals are set in proper location
            Task<IAsyncDisposable> tskMyRelease = objMyParent.LockObject.IsInPotentialWriteLock
                ? objMyParent.LockObject.EnterUpgradeableReadLockAsync(token)
                : objMyParent.LockObject.EnterReadLockWithMatchingParentLockAsync(token);
            return Inner(tskMyRelease);

            async Task<LockingDictionaryEnumerator> Inner(Task<IAsyncDisposable> tskInnerMyRelease)
            {
                // Can't dispose our disposable here (on cancellation) because it would mess up AsyncLocal assignments (since we are technically in a different async context here)
                return new LockingDictionaryEnumerator(await tskInnerMyRelease.ConfigureAwait(false));
            }
        }

        public static LockingDictionaryEnumerator GetWithSideEffects(IHasLockObject objMyParent, CancellationToken token = default)
        {
            IDisposable objMyRelease = objMyParent.LockObject.EnterReadLockWithUpgradeableParent(token);
            return new LockingDictionaryEnumerator(objMyRelease);
        }

        public static Task<LockingDictionaryEnumerator> GetWithSideEffectsAsync(IHasLockObject objMyParent, CancellationToken token = default)
        {
            // Needs to be like this (using async inner function) to make sure AsyncLocals are set in proper location
            Task<IAsyncDisposable> tskMyRelease = objMyParent.LockObject.EnterReadLockWithUpgradeableParentAsync(token);
            return Inner(tskMyRelease);

            async Task<LockingDictionaryEnumerator> Inner(Task<IAsyncDisposable> tskInnerMyRelease)
            {
                // Can't dispose our disposable here (on cancellation) because it would mess up AsyncLocal assignments (since we are technically in a different async context here)
                return new LockingDictionaryEnumerator(await tskInnerMyRelease.ConfigureAwait(false));
            }
        }

        private LockingDictionaryEnumerator(IDisposable objMyRelease)
        {
            _objMyRelease = objMyRelease;
        }

        private LockingDictionaryEnumerator(IAsyncDisposable objMyReleaseAsync)
        {
            _objMyReleaseAsync = objMyReleaseAsync;
        }

        public void SetEnumerator(IDictionaryEnumerator objInternalEnumerator)
        {
            if (_objInternalEnumerator != null)
                throw new ArgumentException(null, nameof(objInternalEnumerator));
            _objInternalEnumerator = objInternalEnumerator;
        }

        /// <inheritdoc />
        public void Dispose()
        {
#if DEBUG
            if (_objMyReleaseAsync != null)
            {
                // Tried to synchronously dispose an enumerator that was created asynchronously, sign of bad code.
                Utils.BreakIfDebug();
            }
#endif
            _objMyRelease?.Dispose();
            if (_objMyReleaseAsync != null)
            {
                // We need to create the task first before awaiting it because the actual assignment of AsyncLocals must happen in the right place (outside of the safe-awaiter function)
                Task tskDispose = _objMyReleaseAsync.DisposeAsync().AsTask();
                Utils.SafelyRunSynchronously(() => tskDispose);
            }
        }

        /// <inheritdoc />
        public ValueTask DisposeAsync()
        {
            _objMyRelease?.Dispose();
            return _objMyReleaseAsync?.DisposeAsync() ?? default;
        }

        /// <inheritdoc />
        public bool MoveNext()
        {
            return _objInternalEnumerator.MoveNext();
        }

        /// <inheritdoc />
        public void Reset()
        {
            _objInternalEnumerator.Reset();
        }

        /// <inheritdoc />
        public object Current => _objInternalEnumerator.Current;

        /// <inheritdoc />
        public object Key => _objInternalEnumerator.Key;

        /// <inheritdoc />
        public object Value => _objInternalEnumerator.Value;

        /// <inheritdoc />
        public DictionaryEntry Entry => _objInternalEnumerator.Entry;
    }
}
