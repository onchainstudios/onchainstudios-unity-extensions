//*****************************************************************************
// Author: Arthur LeVesque
// Copyright: OnChain Studios, 2023
//*****************************************************************************

namespace OnChainStudios.UIToolkitExtensions
{
    using UnityEngine;    
    using UnityEngine.UIElements;

    /// <summary>
    /// Listens to events on a UIDocument and forwards them the event bus.
    /// </summary>
    public class UIDocumentEventBusBridge : MonoBehaviour
    {
        /// <summary>
        /// Handle to the <see cref="UIDocument"/>.
        /// </summary>
        protected UIDocument UIDocument;

        /// <summary>
        /// Returns true if both the UIDocument and its root visual element are not null
        /// </summary>
        protected bool IsRootVisualElementValid => UIDocument != null && UIDocument.rootVisualElement != null;
        
        /// <inheritdoc/>
        protected virtual void Awake()
        {
            UIDocument = GetComponent<UIDocument>();
        }

        /// <inheritdoc/>
        protected virtual void OnEnable()
        {
            RegisterCallbacks();
        }

        /// <inheritdoc/>
        protected virtual void OnDisable()
        {
            UnregisterCallbacks();
        }

        /// <summary>
        /// Registers callbacks on the UIDocument's root visual element
        /// </summary>
        protected void RegisterCallbacks()
        {
            if (IsRootVisualElementValid)
            {
                VisualElementCallbackManager.RegisterCallbacks(UIDocument.rootVisualElement);
            }
        }

        /// <summary>
        /// Unregisters callbacks on the UIDocument's root visual element
        /// </summary>
        protected void UnregisterCallbacks()
        {
            if (IsRootVisualElementValid)
            {
                VisualElementCallbackManager.UnregisterCallbacks(UIDocument.rootVisualElement);
            }
        }

        /// <summary>
        /// Clears previously registered callbacks and registers again
        /// </summary>
        public void ReregisterCallbacks()
        {
            UnregisterCallbacks();
            RegisterCallbacks();
        }
    }
}
