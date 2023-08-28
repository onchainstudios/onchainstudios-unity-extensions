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
    public abstract class OnListViewEventBase : OnVisualElementEventBase<ListViewEventArgsBase>
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
        protected override void Definition()
        {
            base.Definition();
            
            // Adding value outputs.
            ListView = ValueOutput<VisualElement>(nameof(ListView));
            Item = ValueOutput<VisualElement>(nameof(Item));
            Index = ValueOutput<int>(nameof(Index));
        }

        /// <inheritdoc/>
        protected override void AssignArguments(Flow flow, ListViewEventArgsBase data)
        {
            flow.SetValue(ListView, data.VisualElement as ListView);
            flow.SetValue(Item, data.Item);
            flow.SetValue(Index, data.Index);
        }
    }
}
