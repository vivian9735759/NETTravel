using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace NETTravel.DataObjects
{
    public sealed class SortableBindingList<T> : BindingList<T> where T : class
    {
        private bool _isSorted;
        private ListSortDirection _sortDirection = ListSortDirection.Ascending;
        private PropertyDescriptor _sortProperty;

        public SortableBindingList() { }

        public SortableBindingList(IList<T> list) : base(list) { }

        protected override bool SupportsSortingCore { get { return true; } }

        protected override bool IsSortedCore { get { return _isSorted; } }

        protected override ListSortDirection SortDirectionCore { get { return _sortDirection; } }

        protected override PropertyDescriptor SortPropertyCore { get { return _sortProperty; } }

        protected override void RemoveSortCore() { _sortDirection = ListSortDirection.Ascending; _sortProperty = null; }

        protected override void ApplySortCore(PropertyDescriptor prop, ListSortDirection direction)
        {
            _sortProperty = prop;
            _sortDirection = direction;

            List<T> list = Items as List<T>;
            if (list == null) return;

            list.Sort(Compare);

            _isSorted = true;

            // fire an event that the list has been changed. 
            OnListChanged(new ListChangedEventArgs(ListChangedType.Reset, -1));
        }

        private int Compare(T lhs, T rhs)
        {
            var result = OnComparison(lhs, rhs);
            // invert if descending
            if (_sortDirection == ListSortDirection.Descending)
                result = -result;

            return result;

        }

        private int OnComparison(T lhs, T rhs)
        {
            object lhsValue = lhs == null ? null : _sortProperty.GetValue(lhs);
            object rhsValue = rhs == null ? null : _sortProperty.GetValue(rhs);
            if (lhsValue == null)
            {
                return (rhsValue == null) ? 0 : -1; // null are equal
            }
            if (rhsValue == null)
            {
                return 1; // first has value, second doesn't
            }
            if (lhsValue is IComparable)
            {
                return ((IComparable)lhsValue).CompareTo(rhsValue);
            }
            if (lhsValue.Equals(rhsValue))
            {
                return 0; // both are the same
            }

            // not comparable, compare ToString
            return lhsValue.ToString().CompareTo(rhsValue.ToString());
        }
    }
}
