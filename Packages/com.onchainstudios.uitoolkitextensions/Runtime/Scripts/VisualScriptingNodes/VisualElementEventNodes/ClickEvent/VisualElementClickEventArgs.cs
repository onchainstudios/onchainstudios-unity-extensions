//*****************************************************************************
// Author: Rie Kumar
// Copyright: OnChain Studios, 2023
//*****************************************************************************

namespace OnChainStudios.UIToolkitExtensions
{
    using UnityEngine.UIElements;

    /// <summary>
    /// Event args for the <see cref="VisualElement"/> <see cref="ClickEvent"/> when its posted to the <see cref="EventBus"/>
    /// </summary>
    public class VisualElementClickEventArgs : VisualElementEventArgsBase
    {
        /// <summary>
        /// Reference to the <see cref="ClickEvent"/>
        /// </summary>
        public ClickEvent ClickEvent { get; set; }
        
        /// <summary>
        /// Creates a <see cref="VisualElementClickEventArgs"/>
        /// </summary>
        public VisualElementClickEventArgs(ClickEvent clickEvent) : base(clickEvent.currentTarget as VisualElement)
        {
            ClickEvent = clickEvent;
        }
    }
}