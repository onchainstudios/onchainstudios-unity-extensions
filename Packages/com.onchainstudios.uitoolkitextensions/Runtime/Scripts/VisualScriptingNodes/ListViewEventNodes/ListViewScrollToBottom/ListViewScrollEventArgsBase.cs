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
        /// Scroll position at the moment of reaching the bottom
        /// </summary>
        public float ScrollPosition { get; set; }

        /// <summary>
        /// Class constructor
        /// </summary>
        public ListViewScrollEventArgsBase(VisualElement listView, float scrollPosition) : base(listView)
        {
            ScrollPosition = scrollPosition;
        }
    }
}
