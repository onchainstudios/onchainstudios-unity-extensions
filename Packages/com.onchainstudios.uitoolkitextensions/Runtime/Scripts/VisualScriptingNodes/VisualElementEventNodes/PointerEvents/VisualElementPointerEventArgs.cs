//*****************************************************************************
// Author: Rie Kumar
// Copyright: OnChain Studios, 2023
//*****************************************************************************

namespace OnChainStudios.UIToolkitExtensions
{
    using UnityEngine.UIElements;

    /// <summary>
    /// Event args for the <see cref="VisualElement"/> <see cref="PointerUpEvent"/> when its posted to the <see cref="EventBus"/>
    /// </summary>
    public class VisualElementPointerEventArgs<T> : VisualElementEventArgsBase where T : PointerEventBase<T>, new()
    {
        /// <summary>
        /// Reference to the <see cref="PointerUpEvent"/>
        /// </summary>
        public PointerEventBase<T> PointerEvent { get; set; }
        
        /// <summary>
        /// Creates a <see cref="VisualElementPointerEventArgs{T}"/>
        /// </summary>
        public VisualElementPointerEventArgs(PointerEventBase<T> pointerEvent) : base(pointerEvent.currentTarget as VisualElement)
        {
            PointerEvent = pointerEvent;
        }
    }
}