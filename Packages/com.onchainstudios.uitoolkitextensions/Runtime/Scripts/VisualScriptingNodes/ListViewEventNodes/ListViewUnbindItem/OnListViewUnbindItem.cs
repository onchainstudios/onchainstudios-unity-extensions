//*****************************************************************************
// Author: Rie Kumar
// Copyright: OnChain Studios, 2023
//*****************************************************************************

namespace OnChainStudios.UIToolkitExtensions
{
    using Unity.VisualScripting;

    /// <summary>
    /// Event node for when the <see cref="ListViewEventBusBridge.BindItemEvent"/> is posted to the <see cref="EventBus"/>.
    /// </summary>
    [UnitCategory("Events\\UIToolkit")]
    public class OnListViewUnbindItem : OnListViewEventBase
    {
        /// <inheritdoc/>
        public override EventHook GetHook(GraphReference reference)
        {
            return new EventHook(ListViewEventBusBridge.UnbindItemEvent);
        }
    }
}
