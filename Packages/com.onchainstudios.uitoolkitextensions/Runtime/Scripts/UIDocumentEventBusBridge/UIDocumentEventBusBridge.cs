//*****************************************************************************
// Author: Arthur LeVesque
// Copyright: OnChain Studios, 2023
//*****************************************************************************

namespace OnChainStudios.UIToolkitExtensions
{   
    using UnityEngine.UIElements;

    /// <summary>
    /// Listens to events on a UIDocument and forwards them the event bus.
    /// </summary>
    public class UIDocumentEventBusBridge : EventBusBridgeBase
    {
        /// <summary>
        /// Registers callbacks on the UIDocument's root visual element
        /// </summary>
        protected override void RegisterCallbacks()
        {
            VisualElementCallbackManager.RegisterCallbacks(UIDocument.rootVisualElement);
        }

        /// <summary>
        /// Unregisters callbacks on the UIDocument's root visual element
        /// </summary>
        protected override void UnregisterCallbacks()
        {
            VisualElementCallbackManager.UnregisterCallbacks(UIDocument.rootVisualElement);
        }
    }
}
