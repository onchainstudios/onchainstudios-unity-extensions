//*****************************************************************************
// Author: Nicolás Jaramillo
// Copyright: OnChain Studios, 2024
//*****************************************************************************

namespace OnChainStudios.UIToolkitExtensions
{
    using Unity.VisualScripting;
    using UnityEngine.UIElements;

    /// <summary>
    /// Event node for when the <see cref="ListViewEventBusBridge.ScrolledToBottomEvent"/> is posted to the <see cref="EventBus"/>.
    /// </summary>
    [UnitCategory("Events\\UIToolkit")]
    public class OnListViewScrollToBottom : OnVisualElementEventBase<VisualElementEventArgsBase>
    {
        /// <inheritdoc/>
        protected override void AssignArguments(Flow flow, VisualElementEventArgsBase data)
        {
            flow.SetValue(VisualElement, data.VisualElement as ListView);
        }

        /// <inheritdoc/>
        public override EventHook GetHook(GraphReference reference)
        {
            return new EventHook(ListViewEventBusBridge.ScrolledToBottomEvent);
        }
    }
}