//*****************************************************************************
// Author: Arthur LeVesque
// Copyright: OnChain Studios, 2023
//*****************************************************************************

namespace OnChainStudios.UIToolkitExtensions
{
    using UnityEngine;    
    using Unity.VisualScripting;
    using UnityEngine.UIElements;

    /// <summary>
    /// Listens to events on a UIDocument and forwards them the event bus.
    /// </summary>
    public class UIDocumentEventBusBridge : MonoBehaviour
    {
        /// <summary>
        /// Name of the event posted to the <see cref="EventBus"/> when a <see cref="ClickEvent"/> is triggered.
        /// </summary>
        public static string ClickEvent => $"{typeof(UIDocumentEventBusBridge).FullName}.{nameof(ClickEvent)}";

        /// <summary>
        /// Name of the event posted to the <see cref="EventBus"/> when a <see cref="ChangeEvent{T}"/> is triggered.
        /// </summary>
        public static string ChangeEvent<T>()
        {
            return $"{typeof(UIDocumentEventBusBridge).FullName}.{nameof(ChangeEvent)}{typeof(T)}"; 
        }

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
                RegisterCallbacks(UIDocument.rootVisualElement);
            }
        }

        /// <inheritdoc/>
        protected virtual void OnDisable()
        {
            if (UIDocument != null && UIDocument.rootVisualElement != null)
            {
                UnregisterCallbacks(UIDocument.rootVisualElement);
            }
        }
        
        /// <summary>
        /// Registers callbacks on the <paramref name="visualElement"/>.
        /// </summary>
        /// <param name="visualElement">The handle to the <see cref="VisualElement"/> you want to register the events for.</param>
        protected virtual void RegisterCallbacks(VisualElement visualElement)
        {
            foreach (var childVisualElement in visualElement.Children())
            {
                childVisualElement.RegisterCallback<ClickEvent>(clickEvent => OnClickEvent(childVisualElement, clickEvent));
                childVisualElement.RegisterCallback<ChangeEvent<bool>>(changeEvent => OnChangeEvent(childVisualElement, changeEvent));
                childVisualElement.RegisterCallback<ChangeEvent<int>>(changeEvent => OnChangeEvent(childVisualElement, changeEvent));
                childVisualElement.RegisterCallback<ChangeEvent<float>>(changeEvent => OnChangeEvent(childVisualElement, changeEvent));
                childVisualElement.RegisterCallback<ChangeEvent<string>>(changeEvent => OnChangeEvent(childVisualElement, changeEvent));
                RegisterCallbacks(childVisualElement);
            }
        }

        /// <summary>
        /// Unregisters callbacks on the <paramref name="visualElement"/>.
        /// </summary>
        /// <param name="visualElement">The handle to the <see cref="VisualElement"/> you want to unregister the events from.</param>
        protected virtual void UnregisterCallbacks(VisualElement visualElement)
        {
            foreach (var childVisualElement in visualElement.Children())
            {
                childVisualElement.UnregisterCallback<ClickEvent>(clickEvent => OnClickEvent(childVisualElement, clickEvent));
                childVisualElement.UnregisterCallback<ChangeEvent<bool>>(changeEvent => OnChangeEvent(childVisualElement, changeEvent));
                childVisualElement.UnregisterCallback<ChangeEvent<int>>(changeEvent => OnChangeEvent(childVisualElement, changeEvent));
                childVisualElement.UnregisterCallback<ChangeEvent<float>>(changeEvent => OnChangeEvent(childVisualElement, changeEvent));
                childVisualElement.UnregisterCallback<ChangeEvent<string>>(changeEvent => OnChangeEvent(childVisualElement, changeEvent));
                UnregisterCallbacks(childVisualElement);
            }
        }

        /// <summary>
        /// Event handler for when a VisualElement is clicked.
        /// </summary>
        /// <param name="visualElement">The <see cref="VisualElement"/> that the value was changed on.</param>
        /// <param name="clickEvent">The click event data.</param>
        protected void OnClickEvent(VisualElement visualElement, ClickEvent clickEvent)
        {
            visualElement.userData = clickEvent;
            EventBus.Trigger(ClickEvent, visualElement);
        }
        
        /// <summary>
        /// Event handler for when a VisualElement value is changed.
        /// </summary>
        /// <param name="visualElement">The <see cref="VisualElement"/> that the value was changed on.</param>
        /// <param name="changeEvent">The <see cref="ChangeEvent{T}"/> data.</param>
        protected void OnChangeEvent<T>(VisualElement visualElement, ChangeEvent<T> changeEvent)
        {
            visualElement.userData = changeEvent;
            EventBus.Trigger(ChangeEvent<T>(), visualElement);
        }
    }
}
