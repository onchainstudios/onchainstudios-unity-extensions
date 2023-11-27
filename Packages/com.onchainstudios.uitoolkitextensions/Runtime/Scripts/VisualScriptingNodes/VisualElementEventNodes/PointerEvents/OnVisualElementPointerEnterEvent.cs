//*****************************************************************************
// Author: Arthur LeVesque
// Copyright: OnChain Studios, 2023
//*****************************************************************************

namespace OnChainStudios.UIToolkitExtensions
{
    using UnityEngine.UIElements;
    using Unity.VisualScripting;

    /// <summary>
    /// Event node for when the <see cref="UIDocumentEventBusBridge.PointerEventBase{T}"/> is posted as a <see cref="PointerEnterEvent"/> the <see cref="EventBus"/>.
    /// </summary>
    [UnitCategory("Events\\UIToolkit")]
    public class OnVisualElementPointerEnterEvent: OnVisualElementPointerEventBase<PointerEnterEvent>
    {
        /// <inheritdoc/>
        public override EventHook GetHook(GraphReference reference)
        {
            return new EventHook(VisualElementCallbackManager.PointerEvent<PointerEnterEvent>());
        }
    }
}
