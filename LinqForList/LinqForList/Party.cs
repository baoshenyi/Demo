using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace LinqForList
{
    public class Party<T> : IEnumerable<T> 
    {
        private IList<T> _guestList;
        public Party(List<T> guests)
        {
            _guestList = guests;
        }
        //public void AddGuest(Guest guest)
        //{
        //    _guestList.Add(guest);
        //}
        public IEnumerator<T> GetEnumerator()
        {
            if(_guestList == null)
                yield break;
            foreach (T guest in _guestList)
            {
                yield return guest;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    public class Guest
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
