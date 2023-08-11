//*****************************************************************************
// Author: Arthur LeVesque
// Copyright: OnChain Studios, 2023
//*****************************************************************************

namespace OnChainStudios.UIToolkitExtensions
{
    using Unity.VisualScripting;
    using UnityEngine.UIElements;

    /// <summary>
    /// Event node for when the <see cref="UIDocumentEventBusBridge.ChangeEvent{T}"/> is posted to the <see cref="EventBus"/>.
    /// </summary>
    public abstract class OnVisualElementChangeEventBase<T> : OnVisualElementEventBase
    {
        /// <summary>
        /// The previous value before the event was triggered.
        /// </summary>
        [DoNotSerialize]
        public ValueOutput PreviousValue { get; private set; }
        
        /// <summary>
        /// The new value that triggered the event.
        /// </summary>
        [DoNotSerialize]
        public ValueOutput NewValue { get; private set; }

        /// <inheritdoc/>
        protected override void Definition()
        {
            base.Definition();
            
            // Adding value outputs.
            PreviousValue = ValueOutput<T>(nameof(PreviousValue));
            NewValue = ValueOutput<T>(nameof(NewValue));
        }

        /// <inheritdoc/>
        protected override void AssignArguments(Flow flow, VisualElement data)
        {
            base.AssignArguments(flow, data);
            var changeEvent = data.userData as ChangeEvent<T>;
            flow.SetValue(PreviousValue, changeEvent.previousValue);
            flow.SetValue(NewValue, changeEvent.newValue);
        }
    }
}
