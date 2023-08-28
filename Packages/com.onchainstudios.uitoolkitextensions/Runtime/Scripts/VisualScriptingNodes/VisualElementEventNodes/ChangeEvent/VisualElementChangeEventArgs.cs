//*****************************************************************************
// Author: Rie Kumar
// Copyright: OnChain Studios, 2023
//*****************************************************************************

namespace OnChainStudios.UIToolkitExtensions
{
    using UnityEngine.UIElements;

    /// <summary>
    /// Event args for the <see cref="VisualElement"/> <see cref="ChangeEvent{T}"/> when its posted to the <see cref="EventBus"/>
    /// </summary>
    public class VisualElementChangeEventArgs : VisualElementEventArgsBase
    {
        /// <summary>
        /// Creates a <see cref="VisualElementChangeEventArgs"/>
        /// </summary>
        /// <param name="visualElement">The <see cref="VisualElement"/>.</param>
        public VisualElementChangeEventArgs(VisualElement visualElement) : base(visualElement)
        {
        }
    }
}