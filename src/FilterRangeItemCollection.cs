using System;
using System.Collections.Generic;
using System.Text;

namespace Tweaker
{
    [Serializable]
    public class FilterRangeItemCollection
    {
        private List<string> _idsOfItemsToFilter = new List<string>();

        //for serialization
        public List<string> IdsOfItemsToFilter
        {
            get { return _idsOfItemsToFilter; }
            set { _idsOfItemsToFilter = value; }
        }

        public bool Contains(LiftRangeItem item)
        {
            return IdsOfItemsToFilter.Contains(item.Id);
        }

        public bool Contains(string id)
        {
            return IdsOfItemsToFilter.Contains(id);
        }

        public void SetContains(LiftRangeItem item, bool shouldContain)
        {
           SetContains(item.Id, shouldContain);
        }
        
        public void SetContains(string id, bool shouldContain)
        {
            if (shouldContain)
            {
                if (!Contains(id))
                {
                    IdsOfItemsToFilter.Add(id);
                }
            }
            else
            {
                if(Contains(id))
                {
                    IdsOfItemsToFilter.Remove(id);
                }
            }
        }
    }
}
