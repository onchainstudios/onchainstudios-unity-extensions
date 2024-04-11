//*****************************************************************************
// Author: Nicolás Jaramillo
// Copyright: OnChain Studios, 2024
//*****************************************************************************

namespace OnChainStudios.UIToolkitExtensions
{
    using UnityEngine.UIElements;

    /// <summary>
    /// Event args for the <see cref="ListView.ScrolledToBottomEvent"/> when its posted to the <see cref="EventBus"/>
    /// </summary>
    public class ListViewScrollEventArgsBase : VisualElementEventArgsBase
    {
        /// <summary>
        /// Class constructor
        /// </summary>
        public ListViewScrollEventArgsBase(VisualElement listView) : base(listView){}
    }
}
