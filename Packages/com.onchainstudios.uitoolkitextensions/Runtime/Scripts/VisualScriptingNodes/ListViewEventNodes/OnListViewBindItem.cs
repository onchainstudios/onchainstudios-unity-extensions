//*****************************************************************************
// Author: Rie Kumar
// Copyright: OnChain Studios, 2023
//*****************************************************************************

using UnityEngine.UIElements;

namespace OnChainStudios.UIToolkitExtensions
{
    using Unity.VisualScripting;

    /// <summary>
    /// [INSERT CLASS COMMENT HERE]
    /// </summary>
    [UnitCategory("Events\\UIToolkit")]
    public class OnListViewBindItem : OnListViewEventBase
    {
        /// <inheritdoc/>
        public override EventHook GetHook(GraphReference reference)
        {
            return new EventHook(ListViewEventBusBridge.BindItemEvent);
        }
    }
}
