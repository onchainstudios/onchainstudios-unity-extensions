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
    public abstract class OnListViewEventBase : OnUIElementEventBase<ListViewEventArgs>
    {
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
