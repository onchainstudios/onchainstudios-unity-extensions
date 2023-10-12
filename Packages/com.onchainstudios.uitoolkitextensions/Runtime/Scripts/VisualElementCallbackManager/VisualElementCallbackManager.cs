//*****************************************************************************
// Author: Rie Kumar
// Copyright: OnChain Studios, 2023
//*****************************************************************************

namespace OnChainStudios.UIToolkitExtensions
{
    using Unity.VisualScripting;
    using UnityEngine.UIElements;
    
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
        /// Name of the event posted to the <see cref="EventBus"/> when a <see cref="PointerEventBase{T}"/> is triggered.
        /// </summary>
        public static string PointerEvent<T>()
        {
            return $"{typeof(VisualElementCallbackManager).FullName}.{nameof(PointerEvent)}{typeof(T)}";
        }

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
                childVisualElement.RegisterCallback<ClickEvent>(ClickEventCallback);
                childVisualElement.RegisterCallback<PointerDownEvent>(PointerEventCallback, TrickleDown.TrickleDown);
                childVisualElement.RegisterCallback<PointerUpEvent>(PointerEventCallback, TrickleDown.TrickleDown);
                childVisualElement.RegisterCallback<PointerOutEvent>(PointerEventCallback, TrickleDown.TrickleDown);
                childVisualElement.RegisterCallback<PointerMoveEvent>(PointerEventCallback, TrickleDown.TrickleDown);
                childVisualElement.RegisterCallback<ChangeEvent<bool>>(ChangeEventCallback);
                childVisualElement.RegisterCallback<ChangeEvent<int>>(ChangeEventCallback);
                childVisualElement.RegisterCallback<ChangeEvent<float>>(ChangeEventCallback);
                childVisualElement.RegisterCallback<ChangeEvent<string>>(ChangeEventCallback);
                RegisterCallbacks(childVisualElement);
            }
        }

         /// <summary>
         /// Event handler for when a VisualElement is clicked.
         /// </summary>
         /// <param name="evt">The click event data.</param>
         private static void ClickEventCallback(ClickEvent evt)
         {
             EventBus.Trigger(ClickEvent, new VisualElementClickEventArgs(evt));
         }

         private static void PointerEventCallback<T>(PointerEventBase<T> evt) where T : PointerEventBase<T>, new()
         {
             EventBus.Trigger(PointerEvent<T>(), new VisualElementPointerEventArgs<T>(evt));
         }
         
         /// <summary>
         /// Event handler for when a VisualElement value is changed.
         /// </summary>
         /// <param name="evt">The <see cref="ChangeEvent{T}"/> data.</param>
         private static void ChangeEventCallback<T>(ChangeEvent<T> evt)
         {
             EventBus.Trigger(ChangeEvent<T>(), new VisualElementChangeEventArgs<T>(evt));
         }

         /// <summary>
        /// Unregisters callbacks on the <paramref name="visualElement"/>.
        /// </summary>
        /// <param name="visualElement">The handle to the <see cref="VisualElement"/> you want to unregister the events from.</param>
        public static void UnregisterCallbacks(VisualElement visualElement)
        {
            foreach (var childVisualElement in visualElement.Children())
            {
                childVisualElement.UnregisterCallback<ClickEvent>(ClickEventCallback);
                childVisualElement.UnregisterCallback<PointerDownEvent>(PointerEventCallback);
                childVisualElement.UnregisterCallback<PointerUpEvent>(PointerEventCallback);
                childVisualElement.UnregisterCallback<PointerOutEvent>(PointerEventCallback);
                childVisualElement.UnregisterCallback<PointerMoveEvent>(PointerEventCallback);
                childVisualElement.UnregisterCallback<ChangeEvent<bool>>(ChangeEventCallback);
                childVisualElement.UnregisterCallback<ChangeEvent<int>>(ChangeEventCallback);
                childVisualElement.UnregisterCallback<ChangeEvent<float>>(ChangeEventCallback);
                childVisualElement.UnregisterCallback<ChangeEvent<string>>(ChangeEventCallback);
                UnregisterCallbacks(childVisualElement);
            }
        }
    }
}
