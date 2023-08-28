//*****************************************************************************
// Author: #AUTHOR#
// Copyright: #COMPANYNAME#, #YEAR#
//*****************************************************************************

namespace TemplateFile
{
    using Unity.VisualScripting;

    /// <summary>
    /// [INSERT CLASS COMMENT HERE]
    /// </summary>
    //#UNCOMMENT#[UnitCategory("Events\\OnChain Studios")]
    public class EventUnitTemplate : EventUnit<int>
    {
        /// <summary>
        /// The event output data to return when the event is triggered.
        /// </summary>
        [DoNotSerialize]
        public ValueOutput result { get; private set; }

        /// <inheritdoc/>
        protected override bool register => true;

        /// <inheritdoc/>
        public override EventHook GetHook(GraphReference reference)
        {
            return new EventHook("EventUnitTemplateEventName");
        }

        /// <inheritdoc/>
        protected override void Definition()
        {
            base.Definition();

            // Setting the value on our port.
            result = ValueOutput<int>(nameof(result));
        }

        /// <inheritdoc/>
        protected override void AssignArguments(Flow flow, int data)
        {
            flow.SetValue(result, data);
        }
    }
}
