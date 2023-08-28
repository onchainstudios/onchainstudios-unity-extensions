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
        /// Creates a <see cref="VisualElementClickEventArgs"/>
        /// </summary>
        /// <param name="visualElement">The <see cref="VisualElement"/>.</param>
        public VisualElementClickEventArgs(VisualElement visualElement) : base(visualElement)
        {
        }
    }
}