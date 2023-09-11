//*****************************************************************************
// Author: Arthur LeVesque
// Copyright: OnChain Studios, 2023
//*****************************************************************************

namespace OnChainStudios.UIToolkitExtensions
{
    using UnityEngine.UIElements;
    using Unity.VisualScripting;

    /// <summary>
    /// Event node for when the <see cref="UIDocumentEventBusBridge.ChangeEvent{T}"/> is posted as a <see cref="float"/> the <see cref="EventBus"/>.
    /// </summary>
    [UnitCategory("Events\\UIToolkit")]
    public class OnVisualElementChangeEventFloat: OnVisualElementChangeEventBase<float>
    {
        /// <inheritdoc/>
        public override EventHook GetHook(GraphReference reference)
        {
            return new EventHook(VisualElementCallbackManager.ChangeEvent<float>());
        }
    }
}
