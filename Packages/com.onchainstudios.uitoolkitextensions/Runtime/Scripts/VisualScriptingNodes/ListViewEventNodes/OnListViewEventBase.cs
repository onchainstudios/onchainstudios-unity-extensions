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
    public abstract class OnListViewEventBase : EventUnit<ListViewEventArgs>
    {
        /// <summary>
        /// The set of match rules that will trigger the <see cref="ListView"/>
        /// </summary>
        public enum MatchRules
        {
            VisualElementNameExact,
            VisualElementNameContains,
            HasClass,
            Type
        };
        
        /// <summary>
        /// The visual element match rules that should trigger the event.
        /// </summary>
        [DoNotSerialize]
        public ValueInput MatchRule { get; private set; }
        
        /// <summary>
        /// The visual element name that should trigger the event.
        /// </summary>
        [DoNotSerialize]
        public ValueInput Name { get; private set; }

        /// <summary>
        /// The visual element class that should trigger the event.
        /// </summary>
        [DoNotSerialize]
        public ValueInput Class { get; private set; }
        
        /// <summary>
        /// The visual element type that should trigger the event.
        /// </summary>
        [DoNotSerialize]
        public ValueInput Type { get; private set; }
        
        /// <summary>
        /// The event output data for the <see cref="ListView"/>
        /// </summary>
        [DoNotSerialize]
        public ValueOutput ListView { get; private set; }
        
        /// <summary>
        /// The event output data for the <see cref="Item"/> in the <see cref="ListView"/>
        /// </summary>
        [DoNotSerialize]
        public ValueOutput Item { get; private set; }
        
        /// <summary>
        /// The event output data for the index of the <see cref="Item"/> in the <see cref="ListView"/>
        /// </summary>
        [DoNotSerialize]
        public ValueOutput Index { get; private set; }

        /// <inheritdoc/>
        protected override bool register => true;

        /// <inheritdoc/>
        protected override bool ShouldTrigger(Flow flow, ListViewEventArgs args)
        {
            var nameValue = flow.GetValue<string>(Name);
            var classValue = flow.GetValue<string>(Class);
            var typeValue = flow.GetValue<System.Type>(Type);
            
            var exactNameMatch = args.ListView.name == nameValue;
            var nameContainsMatch = args.ListView.name.Contains(nameValue);
            var hasClassMatch = args.ListView.ClassListContains(classValue);
            var typeMatch = args.GetType() == typeValue;
            
            switch (flow.GetValue<MatchRules>(MatchRule))
            {
                case MatchRules.VisualElementNameExact:
                    return exactNameMatch;
                case MatchRules.VisualElementNameContains:
                    return nameContainsMatch;
                case MatchRules.HasClass:
                    return hasClassMatch;
                case MatchRules.Type:
                    return typeMatch;
                default:
                    return false;
            }
        }
        
        /// <inheritdoc/>
        protected override void Definition()
        {
            base.Definition();
            
            // Adding value inputs.
            MatchRule = ValueInput<MatchRules>(nameof(MatchRule), MatchRules.VisualElementNameExact);
            Name = ValueInput<string>(nameof(Name), string.Empty);
            Class = ValueInput<string>(nameof(Class), string.Empty);
            Type = ValueInput<System.Type>(nameof(Type), null);
            
            // Adding value outputs.
            ListView = ValueOutput<VisualElement>(nameof(ListView));
            Item = ValueOutput<VisualElement>(nameof(Item));
            Index = ValueOutput<int>(nameof(Index));
        }

        /// <inheritdoc/>
        protected override void AssignArguments(Flow flow, ListViewEventArgs data)
        {
            flow.SetValue(ListView, data.ListView);
            flow.SetValue(Item, data.Item);
            flow.SetValue(Index, data.Index);
        }
    }
}
