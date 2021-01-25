using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GroupingAndOrdering.Shared
{
    public enum Direction { Ascending, Descending }

    public partial class NotQuiteGrid<TItem, TGroupKey>
    {

        [Parameter] public IEnumerable<TItem> Items { get; set; }

        [Parameter] public Func<IEnumerable<TItem>, Direction, IOrderedEnumerable<TItem>> OrderItems { get; set; }

        [Parameter] public Direction ItemsDirection { get; set; } = Direction.Ascending;


        [Parameter] public Func<IEnumerable<TItem>, IEnumerable<IGrouping<TGroupKey, TItem>>> GroupMethod { get; set; }

        [Parameter] public Func<IEnumerable<TGroupKey>, Direction, IOrderedEnumerable<TGroupKey>> OrderGroupKeys { get; set; }

        [Parameter] public Direction GroupKeysDirection { get; set; } = Direction.Ascending;

        [Parameter] public IEnumerable<TGroupKey> GroupCategories { get; set; }



        private List<TItem> UngroupedItems { get; set; }

        private Dictionary<TGroupKey, List<TItem>> GroupDict { get; set; }

        private List<TGroupKey> GroupKeys { get; set; }


        protected override void OnParametersSet()
        {
            base.OnParametersSet();

            UngroupedItems = null;
            GroupDict = null;
            GroupKeys = null;

            if (GroupMethod == null)
            {
                UngroupedItems = (OrderItems == null ? Items : OrderItems(Items, ItemsDirection)).ToList();
            }
            else
            {
                if (OrderGroupKeys == null)
                {
                    GroupDict = GroupMethod(Items).ToDictionary(x => x.Key, x => x.ToList());
                }
                else
                {
                    GroupDict = GroupMethod(Items).ToDictionary(x => x.Key, x => OrderItems(x, ItemsDirection).ToList());
                }

                if (GroupCategories != null)
                {
                    var missingKeys = GroupCategories.Except(GroupDict.Keys);

                    foreach (var key in missingKeys)
                    {
                        GroupDict.Add(key, new());
                    }
                }

                IEnumerable<TGroupKey> ok = OrderGroupKeys == null ? GroupDict.Keys : OrderGroupKeys(GroupDict.Keys, GroupKeysDirection);

                GroupKeys = ok.ToList();
            }
        }
    }
}
