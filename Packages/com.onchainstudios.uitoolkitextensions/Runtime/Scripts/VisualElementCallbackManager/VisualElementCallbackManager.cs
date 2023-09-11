//*****************************************************************************
// Author: Rie Kumar
// Copyright: OnChain Studios, 2023
//*****************************************************************************

using Unity.VisualScripting;
using UnityEngine.UIElements;

namespace OnChainStudios.UIToolkitExtensions
{
    /// <summary>
    /// Manages registering and unregistering callbacks for <see cref="VisualElement"/>
    /// </summary>
        public class VisualElementCallbackManager
    {
        /// <summary>
        /// Name of the event posted to the <see cref="EventBus"/> when a <see cref="ClickEvent"/> is triggered.
        /// </summary>
        public static string ClickEvent => $"{typeof(VisualElementCallbackManager).FullName}.{nameof(ClickEvent)}";

        /// <summary>
        /// Name of the event posted to the <see cref="EventBus"/> when a <see cref="ChangeEvent{T}"/> is triggered.
        /// </summary>
        public static string ChangeEvent<T>()
        {
            return $"{typeof(VisualElementCallbackManager).FullName}.{nameof(ChangeEvent)}{typeof(T)}"; 
        }
        
         /// <summary>
        /// Registers callbacks on the <paramref name="visualElement"/>.
        /// </summary>
        /// <param name="visualElement">The handle to the <see cref="VisualElement"/> you want to register the events for.</param>
        public static void RegisterCallbacks(VisualElement visualElement)
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
        public static void UnregisterCallbacks(VisualElement visualElement)
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
        
        public static void ReregisterCallbacks(VisualElement visualElement)
        {
            UnregisterCallbacks(visualElement);
            RegisterCallbacks(visualElement);
        }

        /// <summary>
        /// Event handler for when a VisualElement is clicked.
        /// </summary>
        /// <param name="visualElement">The <see cref="VisualElement"/> that the value was changed on.</param>
        /// <param name="clickEvent">The click event data.</param>
        protected static void OnClickEvent(VisualElement visualElement, ClickEvent clickEvent)
        {
            visualElement.userData = clickEvent;
            
            EventBus.Trigger(ClickEvent, new VisualElementClickEventArgs(visualElement));
        }
        
        /// <summary>
        /// Event handler for when a VisualElement value is changed.
        /// </summary>
        /// <param name="visualElement">The <see cref="VisualElement"/> that the value was changed on.</param>
        /// <param name="changeEvent">The <see cref="ChangeEvent{T}"/> data.</param>
        protected static void OnChangeEvent<T>(VisualElement visualElement, ChangeEvent<T> changeEvent)
        {
            visualElement.userData = changeEvent;
            EventBus.Trigger(ChangeEvent<T>(), new VisualElementChangeEventArgs(visualElement));
        }
    }
}
