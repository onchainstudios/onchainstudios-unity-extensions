//*****************************************************************************
// Author: Rie Kumar
// Copyright: OnChain Studios, 2023
//*****************************************************************************

namespace OnChainStudios.UIToolkitExtensions
{
    using Unity.VisualScripting;
    
    /// <summary>
    /// Base class for when an event is posted from the <see cref="UIDocumentEventBusBridge"/>.
    /// </summary>
    public abstract class OnUIElementEventBase<T> : EventUnit<T>
    {
        public enum MatchRules
        {
            VisualElementNameExact,
            VisualElementNameContains,
            HasClass,
            Type
        };
        
        /// <summary>
        /// The visual element name that should trigger the event.
        /// </summary>
        [DoNotSerialize]
        public ValueInput MatchRule { get; private set; }
        
        /// <summary>
        /// The visual element name that should trigger the event.
        /// </summary>
        [DoNotSerialize]
        public ValueInput Name { get; private set; }

        /// <summary>
        /// The visual element name that should trigger the event.
        /// </summary>
        [DoNotSerialize]
        public ValueInput Class { get; private set; }
        
        /// <summary>
        /// The visual element name that should trigger the event.
        /// </summary>
        [DoNotSerialize]
        public ValueInput Type { get; private set; }
        
        /// <inheritdoc/>
        protected override bool register => true;

        /// <inheritdoc/>
        protected override void Definition()
        {
            base.Definition();
            
            // Adding value inputs.
            MatchRule = ValueInput<MatchRules>(nameof(MatchRule), MatchRules.VisualElementNameExact);
            Name = ValueInput<string>(nameof(Name), string.Empty);
            Class = ValueInput<string>(nameof(Class), string.Empty);
            Type = ValueInput<System.Type>(nameof(Type), null);
        }
    }
}
