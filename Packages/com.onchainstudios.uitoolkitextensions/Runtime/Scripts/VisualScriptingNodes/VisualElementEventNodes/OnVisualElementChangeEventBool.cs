//*****************************************************************************
// Author: Arthur LeVesque
// Copyright: OnChain Studios, 2023
//*****************************************************************************

namespace OnChainStudios.UIToolkitExtensions
{
    using UnityEngine.UIElements;
    using Unity.VisualScripting;

    /// <summary>
    /// Event node for when the <see cref="UIDocumentEventBusBridge.ChangeEvent{T}"/> is posted as a <see cref="bool"/> the <see cref="EventBus"/>.
    /// </summary>
    [UnitCategory("Events\\UIToolkit")]
    public class OnVisualElementChangeEventBool: OnVisualElementChangeEventBase<bool>
    {
        /// <inheritdoc/>
        public override EventHook GetHook(GraphReference reference)
        {
            return new EventHook(UIDocumentEventBusBridge.ChangeEvent<bool>());
        }
    }
}
