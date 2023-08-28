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
    //#UNCOMMENT#[UnitCategory("OnChain Studios")]
    public class UnitTemplate : Unit
    {
        /// <summary>
        /// The ControlInput port variable
        /// </summary>
        [DoNotSerialize]
        public ControlInput InputTrigger;

        /// <summary>
        /// The ControlOutput port variable
        /// </summary>
        [DoNotSerialize]
        public ControlOutput OutputTrigger;

        /// <inheritdoc/>
        protected override void Definition()
        {
            //Making the ControlInput port visible, setting its key and running the anonymous action method to pass the flow to the outputTrigger port.
            InputTrigger = ControlInput(nameof(InputTrigger), Connect);

            //Making the ControlOutput port visible and setting its key.
            OutputTrigger = ControlOutput(nameof(OutputTrigger));
        }

        /// <summary>
        /// Handles logic that occurs within the unit and returns the
        /// <see cref="ControlOutput"/> when the logic has been completed and
        /// the node is ready to continue to the <see cref="OutputTrigger"/>. 
        /// </summary>
        /// <param name="flow">
        /// Provides a means of getting values for <see cref="ValueInput"/> and
        /// setting values for <see cref="ValueOutput"/>.
        /// </param>
        /// <returns>
        /// <see cref="OutputTrigger"/> to indicate the input has been
        /// completed.
        /// </returns>
        protected ControlOutput Connect(Flow flow)
        {
            return OutputTrigger;
        }
    }
}
