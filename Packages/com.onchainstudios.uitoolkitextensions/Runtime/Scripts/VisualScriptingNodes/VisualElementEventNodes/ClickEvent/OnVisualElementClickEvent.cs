//*****************************************************************************
// Author: Arthur LeVesque
// Copyright: OnChain Studios, 2023
//*****************************************************************************

using UnityEngine.UIElements;

namespace OnChainStudios.UIToolkitExtensions
{
    using Unity.VisualScripting;
    
    /// <summary>
    /// Event node for when the <see cref="UIDocumentEventBusBridge.ClickEvent"/> is posted to the <see cref="EventBus"/>.
    /// </summary>
    [UnitCategory("Events\\UIToolkit")]
    public class OnVisualElementClickEvent : OnVisualElementEventBase<VisualElementClickEventArgs>
    {
        /// <summary>
        /// The <see cref="UnityEngine.UIElements.ClickEvent"/> event argument.
        /// </summary>
        [DoNotSerialize]
        public ValueOutput ClickEvent { get; private set; }
        
        /// <inheritdoc/>
        public override EventHook GetHook(GraphReference reference)
        {
            return new EventHook(VisualElementCallbackManager.ClickEvent);
        }
        
        /// <inheritdoc/>
        protected override void Definition()
        {
            base.Definition();
            
            // Adding value outputs.
            ClickEvent = ValueOutput<ClickEvent>(nameof(ClickEvent));
        }

        /// <inheritdoc/>
        protected override void AssignArguments(Flow flow, VisualElementClickEventArgs data)
        {
            base.AssignArguments(flow, data);
            flow.SetValue(ClickEvent, data.ClickEvent);
        }
    }
}
