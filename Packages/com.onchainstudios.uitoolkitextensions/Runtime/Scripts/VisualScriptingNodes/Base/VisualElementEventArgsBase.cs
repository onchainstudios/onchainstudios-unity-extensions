//*****************************************************************************
// Author: Rie Kumar
// Copyright: OnChain Studios, 2023
//*****************************************************************************

namespace OnChainStudios.UIToolkitExtensions
{
    using UnityEngine.UIElements;

    /// <summary>
    /// Event args for the <see cref="VisualElement"/> when its posted to the <see cref="EventBus"/>
    /// </summary>
    public abstract class VisualElementEventArgsBase
    {
        /// <summary>
        /// Reference to the <see cref="VisualElement"/>
        /// </summary>
        public VisualElement VisualElement { get; set; }
        
        /// <summary>
        /// Creates a <see cref="VisualElementEventArgsBase"/>
        /// </summary>
        /// <param name="visualElement">The <see cref="VisualElement"/>.</param>
        public VisualElementEventArgsBase(VisualElement visualElement)
        {
            VisualElement = visualElement;
        }
    }
}