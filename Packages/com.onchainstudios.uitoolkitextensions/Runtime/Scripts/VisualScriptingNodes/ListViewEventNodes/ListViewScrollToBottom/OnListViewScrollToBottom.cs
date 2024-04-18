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
    public class OnListViewScrollToBottom : OnVisualElementEventBase<ListViewScrollEventArgsBase>
    {
        /// <summary>
        /// The scroll position for the targeted ListView
        /// </summary>
        [DoNotSerialize]
        public ValueOutput ScrollPosition { get; private set; }

        /// <inheritdoc/>
        protected override void Definition()
        {
            base.Definition();
            
            ScrollPosition = ValueOutput<float>(nameof(ScrollPosition));
        }

        /// <inheritdoc/>
        protected override void AssignArguments(Flow flow, ListViewScrollEventArgsBase data)
        {
            flow.SetValue(VisualElement, data.VisualElement as ListView);
            flow.SetValue(ScrollPosition, data.ScrollPosition);
        }

        /// <inheritdoc/>
        public override EventHook GetHook(GraphReference reference)
        {
            return new EventHook(ListViewEventBusBridge.ScrolledToBottomEvent);
        }
    }
}