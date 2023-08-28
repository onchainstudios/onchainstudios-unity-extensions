//*****************************************************************************
// Author: Rie Kumar
// Copyright: OnChain Studios, 2023
//*****************************************************************************

namespace OnChainStudios.UIToolkitExtensions
{
    using UnityEngine.UIElements;

    /// <summary>
    /// Event args for the <see cref="ListView"/> when its posted to the <see cref="EventBus"/>
    /// </summary>
    public class ListViewEventArgs
    {
        /// <summary>
        /// Reference to the <see cref="ListView"/>
        /// </summary>
        public ListView ListView { get; set; }
        
        /// <summary>
        /// Reference to the item in the <see cref="ListView"/>
        /// </summary>
        public VisualElement Item { get; set; }
        
        /// <summary>
        /// Reference to the index of the item in the <see cref="ListView"/>
        /// </summary>
        public int Index { get; set; }

        /// <summary>
        /// Creates a <see cref="ListViewEventArgs"/>
        /// </summary>
        /// <param name="listview">The <see cref="ListView"/>.</param>
        /// <param name="item">The item inside of the <see cref="ListView"/></param>
        /// <param name="index">The index of the item inside of the <see cref="ListView"/></param>
        public ListViewEventArgs(ListView listView, VisualElement item, int index)
        {
            ListView = listView;
            Item = item;
            Index = index;
        }
    }
}