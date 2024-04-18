//*****************************************************************************
// Author: Nicolás Jaramillo
// Copyright: OnChain Studios, 2024
//*****************************************************************************

namespace OnChainStudios.UIToolkitExtensions
{
    using UnityEngine;    
    using UnityEngine.UIElements;

    /// <summary>
    /// Base class for extending EventBusBridge classes
    /// </summary>
    public abstract class EventBusBridgeBase : MonoBehaviour
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
            if (IsRootVisualElementValid)
            {
                RegisterCallbacks();
            }
        }

        /// <inheritdoc/>
        protected virtual void OnDisable()
        {
            if (IsRootVisualElementValid)
            {
                UnregisterCallbacks();
            }
        }

        /// <summary>
        /// Abstract method used to register callbacks
        /// </summary>
        protected abstract void RegisterCallbacks();

        /// <summary>
        /// Abstract method used to unregister callbacks
        /// </summary>
        protected abstract void UnregisterCallbacks();

        /// <summary>
        /// Clears previously registered callbacks and registers again
        /// </summary>
        public void ReregisterCallbacks()
        {
            if (IsRootVisualElementValid)
            {
                UnregisterCallbacks();
                RegisterCallbacks();
            }
        }
    }
}