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

using System.Collections.Generic;
using System.Collections.Specialized;
using System.Threading;
using System.Threading.Tasks;

namespace Chummer
{
    public class ObservableCollectionWithMaxSize<T> : EnhancedObservableCollection<T>
    {
        private readonly int _intMaxSize;

        public ObservableCollectionWithMaxSize(int intMaxSize)
        {
            _intMaxSize = intMaxSize;
        }

        public ObservableCollectionWithMaxSize(List<T> list, int intMaxSize) : base(list)
        {
            _intMaxSize = intMaxSize;
            while (Count > _intMaxSize)
                RemoveAt(Count - 1);
        }

        public ObservableCollectionWithMaxSize(IEnumerable<T> collection, int intMaxSize) : base(collection)
        {
            _intMaxSize = intMaxSize;
            while (Count > _intMaxSize)
                RemoveAt(Count - 1);
        }

        private int _intSkipCollectionChanged;

        /// <inheritdoc />
        protected override void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
        {
            if (_intSkipCollectionChanged > 0)
                return;
            if (e.Action == NotifyCollectionChangedAction.Reset)
            {
                if (Interlocked.Increment(ref _intSkipCollectionChanged) > 1) // Just in case
                {
                    Interlocked.Decrement(ref _intSkipCollectionChanged);
                    return;
                }
                try
                {
                    // Remove all entries greater than the allowed size
                    while (Count > _intMaxSize)
                        RemoveAt(Count - 1);
                }
                finally
                {
                    Interlocked.Decrement(ref _intSkipCollectionChanged);
                }
            }
            base.OnCollectionChanged(e);
        }

        /// <inheritdoc />
        protected override async Task OnCollectionChangedAsync(NotifyCollectionChangedEventArgs e, CancellationToken token = default)
        {
            if (_intSkipCollectionChanged > 0)
                return;
            if (e.Action == NotifyCollectionChangedAction.Reset)
            {
                if (Interlocked.Increment(ref _intSkipCollectionChanged) > 1) // Just in case
                {
                    Interlocked.Decrement(ref _intSkipCollectionChanged);
                    return;
                }
                try
                {
                    // Remove all entries greater than the allowed size
                    while (await GetCountAsync(token).ConfigureAwait(false) > _intMaxSize)
                        await RemoveItemAsync(await GetCountAsync(token).ConfigureAwait(false) - 1, token).ConfigureAwait(false);
                }
                finally
                {
                    Interlocked.Decrement(ref _intSkipCollectionChanged);
                }
            }
            await base.OnCollectionChangedAsync(e, token).ConfigureAwait(false);
        }

        /// <inheritdoc />
        protected override void InsertItem(int index, T item)
        {
            if (index >= _intMaxSize)
                return;
            base.InsertItem(index, item);
            while (Count > _intMaxSize)
                RemoveAt(Count - 1);
        }

        /// <inheritdoc />
        public override async Task InsertItemAsync(int index, T item, CancellationToken token = default)
        {
            if (index >= _intMaxSize)
                return;
            await base.InsertItemAsync(index, item, token).ConfigureAwait(false);
            while (await GetCountAsync(token).ConfigureAwait(false) > _intMaxSize)
                await RemoveItemAsync(await GetCountAsync(token).ConfigureAwait(false) - 1, token).ConfigureAwait(false);
        }
    }
}
