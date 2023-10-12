//*****************************************************************************
// Author: Arthur LeVesque
// Copyright: OnChain Studios, 2023
//*****************************************************************************

namespace OnChainStudios.UIToolkitExtensions
{
    using Unity.VisualScripting;
    using UnityEngine.UIElements;
    
    /// <summary>
    /// Event node for when the <see cref="UIDocumentEventBusBridge.PointerEventBase{T}"/> is posted to the <see cref="EventBus"/>.
    /// </summary>
    public abstract class OnVisualElementPointerEventBase<T> : OnVisualElementEventBase<VisualElementPointerEventArgs<T>> where T : PointerEventBase<T>, new()
    {
        /// <summary>
        /// The visual element that triggered the event.
        /// </summary>
        [DoNotSerialize]
        public ValueOutput PointerEvent { get; private set; }
        
        /// <inheritdoc/>
        protected override void Definition()
        {
            base.Definition();

            // Adding value outputs.
            PointerEvent = ValueOutput<T>(nameof(PointerEvent));
        }

        protected override void AssignArguments(Flow flow, VisualElementPointerEventArgs<T> data)
        {
            base.AssignArguments(flow, data);
            flow.SetValue(PointerEvent, data.PointerEvent);            
        }
    }
}
