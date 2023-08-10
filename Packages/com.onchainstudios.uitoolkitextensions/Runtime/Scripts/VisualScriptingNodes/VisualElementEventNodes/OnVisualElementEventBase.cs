//*****************************************************************************
// Author: Arthur LeVesque
// Copyright: OnChain Studios, 2023
//*****************************************************************************

namespace OnChainStudios.UIToolkitExtensions
{
    using Unity.VisualScripting;
    using UnityEngine.UIElements;
    
    /// <summary>
    /// Base class for when an event is posted from the <see cref="UIDocumentEventBusBridge"/>.
    /// </summary>
    public abstract class OnVisualElementEventBase : EventUnit<VisualElement>
    {
        /// <summary>
        /// The visual element name that should trigger the event.
        /// </summary>
        [DoNotSerialize]
        public ValueInput VisualElementName { get; private set; }
        
        /// <summary>
        /// The visual element that triggered the event.
        /// </summary>
        [DoNotSerialize]
        public ValueOutput VisualElement { get; private set; }

        /// <inheritdoc/>
        protected override bool register => true;

        /// <inheritdoc/>
        protected override bool ShouldTrigger(Flow flow, VisualElement args)
        {
            return args.name == flow.GetValue<string>(VisualElementName);
        }
        
        /// <inheritdoc/>
        protected override void Definition()
        {
            base.Definition();
            
            // Adding value inputs.
            VisualElementName = ValueInput<string>(nameof(VisualElementName), string.Empty);
            
            // Adding value outputs.
            VisualElement = ValueOutput<VisualElement>(nameof(VisualElement));
        }

        /// <inheritdoc/>
        protected override void AssignArguments(Flow flow, VisualElement data)
        {
            flow.SetValue(VisualElement, data);
        }
    }
}
