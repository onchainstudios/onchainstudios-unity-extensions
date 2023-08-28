//*****************************************************************************
// Author: Rie Kumar
// Copyright: OnChain Studios, 2023
//*****************************************************************************

namespace OnChainStudios.UIToolkitExtensions
{
    using UnityEngine.UIElements;
    using Unity.VisualScripting;

    /// <summary>
    /// Event args for when the <see cref="ListViewEventBusBridge.BindItemEvent"/> is posted to the <see cref="EventBus"/>.
    /// </summary>
    public class ListViewBindItemEventArgs : ListViewEventArgs
    {
        /// <summary>
        /// Creates a <see cref="ListViewBindItemEventArgs"/>
        /// </summary>
        /// <param name="listview">The <see cref="ListView"/>.</param>
        /// <param name="item">The item inside of the <see cref="ListView"/></param>
        /// <param name="index">The index of the item inside of the <see cref="ListView"/></param>
        public ListViewBindItemEventArgs(ListView listview, VisualElement item, int index) : base(listview, item, index)
        {
        }
    }
}