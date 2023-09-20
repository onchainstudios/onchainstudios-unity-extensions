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
    public class VisualElementChangeEventArgs<T> : VisualElementEventArgsBase
    {
        /// <summary>
        /// Reference to the <see cref="ChangeEvent{T}"/>
        /// </summary>
        public ChangeEvent<T> ChangeEvent { get; set; }
        
        /// <summary>
        /// Creates a <see cref="VisualElementChangeEventArgs"/>
        /// </summary>
        /// <param name="visualElement">The <see cref="VisualElement"/>.</param>
        public VisualElementChangeEventArgs(ChangeEvent<T> changeEvent) : base(changeEvent.currentTarget as VisualElement)
        {
            ChangeEvent = changeEvent;
        }
    }
}