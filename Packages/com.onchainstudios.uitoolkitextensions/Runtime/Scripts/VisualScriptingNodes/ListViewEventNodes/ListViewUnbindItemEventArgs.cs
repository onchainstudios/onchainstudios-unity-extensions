//*****************************************************************************
// Author: Rie Kumar
// Copyright: OnChain Studios, 2023
//*****************************************************************************

namespace OnChainStudios.UIToolkitExtensions
{
    using UnityEngine.UIElements;
    using Unity.VisualScripting;

    /// <summary>
    /// Event args for when the <see cref="ListViewEventBusBridge.UnbindItemEvent"/> is posted to the <see cref="EventBus"/>.
    /// </summary>
    public class ListViewUnbindItemEventArgs : ListViewEventArgs
    {
        /// <summary>
        /// Creates a <see cref="ListViewUnbindItemEventArgs"/>
        /// </summary>
        /// <param name="listview">The <see cref="ListView"/>.</param>
        /// <param name="item">The item inside of the <see cref="ListView"/></param>
        /// <param name="index">The index of the item inside of the <see cref="ListView"/></param>
        public ListViewUnbindItemEventArgs(ListView listView, VisualElement item, int index) : base(listView, item, index)
        {
        }
    }
}