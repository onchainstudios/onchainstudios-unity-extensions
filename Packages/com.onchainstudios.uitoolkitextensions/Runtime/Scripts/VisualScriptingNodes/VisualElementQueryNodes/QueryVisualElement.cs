//*****************************************************************************
// Author: Rie Kumar
// Copyright: OnChain Studios, 2023
//*****************************************************************************

namespace OnChainStudios.UIToolkitExtensions
{
    using Unity.VisualScripting;
    using System.Collections.Generic;
    using UnityEngine.UIElements;

    /// <summary>
    /// Queries the visual element, similar to <see cref="UQueryExtensions.Query"/>
    /// </summary>
    [UnitCategory("OnChain Studios\\UIToolkit")]
    public class QueryVisualElement : Unit
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

        /// <summary>
        /// The visual element to query.
        /// </summary>
        [DoNotSerialize]
        public ValueInput VisualElement { get; private set; }
        
        /// <summary>
        /// The name for the query.
        /// </summary>
        [DoNotSerialize]
        public ValueInput Name { get; private set; }

        /// <summary>
        /// The class name for the query.
        /// </summary>
        [DoNotSerialize]
        public ValueInput ClassName { get; private set; }

        /// <summary>
        /// List of visual elements as a result from the query.
        /// </summary>
        [DoNotSerialize]
        public ValueOutput VisualElements;

        /// <summary>
        /// The result value for the <see cref="VisualElements"/>
        /// </summary>
        private List<VisualElement> visualElements;
        
        /// <inheritdoc/>
        protected override void Definition()
        {
            //Making the ControlInput port visible, setting its key and running the anonymous action method to pass the flow to the outputTrigger port.
            InputTrigger = ControlInput(nameof(InputTrigger), QueryElement);

            //Making the ControlOutput port visible and setting its key.
            OutputTrigger = ControlOutput(nameof(OutputTrigger));

            VisualElement = ValueInput<VisualElement>(nameof(VisualElement));
            Name = ValueInput<string>(nameof(Name), string.Empty);
            ClassName = ValueInput<string>(nameof(ClassName), string.Empty);

            VisualElements = ValueOutput<List<VisualElement>>(nameof(VisualElement), (flow) => visualElements);
            
            Succession(InputTrigger, OutputTrigger);
        }

        /// <summary>
        /// Queries the <see cref="VisualElement"/> using <see cref="UQueryExtensions.Query"/>
        /// </summary>
        /// <param name="flow">Provides the <see cref="ValueInput"/></param>
        /// <returns>The <see cref="ControlOutput"/> that is returned when triggered.</returns>
        protected ControlOutput QueryElement(Flow flow)
        {
            var visualElement = flow.GetValue<VisualElement>(VisualElement);
            var name = flow.GetValue<string>(Name);
            var className = flow.GetValue<string>(ClassName);

            visualElements = visualElement.Query(string.IsNullOrEmpty(name) ? null : name, string.IsNullOrEmpty(className) ? null : className).ToList();
            
            return OutputTrigger;
        }
    }
}
