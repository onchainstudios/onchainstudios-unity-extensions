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
    public abstract class OnVisualElementEventBase<T> : EventUnit<T> where T: VisualElementEventArgsBase
    {
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

        /// <summary>
        /// The visual element that triggered the event.
        /// </summary>
        [DoNotSerialize]
        public ValueOutput VisualElement { get; private set; }

        /// <inheritdoc/>
        protected override bool register => true;

        /// <inheritdoc/>
        protected override bool ShouldTrigger(Flow flow, T args)
        {
            var nameValue = flow.GetValue<string>(Name);
            var classValue = flow.GetValue<string>(Class);
            var typeValue = flow.GetValue<System.Type>(Type);

            var exactNameMatch = args.VisualElement.name == nameValue;
            var nameContainsMatch = args.VisualElement.name.Contains(nameValue);
            var hasClassMatch = args.VisualElement.ClassListContains(classValue);
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
            VisualElement = ValueOutput<VisualElement>(nameof(VisualElement));
        }

        /// <inheritdoc/>
        protected override void AssignArguments(Flow flow, T data)
        {
            flow.SetValue(VisualElement, data.VisualElement);
        }
    }
}
