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
        
        /// <inheritdoc/>
        protected virtual void Awake()
        {
            UIDocument = GetComponent<UIDocument>();
        }

        /// <inheritdoc/>
        protected virtual void OnEnable()
        {
            if (UIDocument != null && UIDocument.rootVisualElement != null)
            {
                VisualElementCallbackManager.RegisterCallbacks(UIDocument.rootVisualElement);
            }
        }

        /// <inheritdoc/>
        protected virtual void OnDisable()
        {
            if (UIDocument != null && UIDocument.rootVisualElement != null)
            {
                VisualElementCallbackManager.UnregisterCallbacks(UIDocument.rootVisualElement);
            }
        }
    }
}
