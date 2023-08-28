//*****************************************************************************
// Author: Rie Kumar
// Copyright: cryptoys, 2023
//*****************************************************************************

namespace OnChainStudios.UIToolkitExtensions
{
    using Unity.VisualScripting;
    using UnityEngine.UIElements;
    using UnityEngine;

    /// <summary>
    /// Listens to events on a ListView and forwards them the event bus. 
    /// </summary>
    public class ListViewEventBusBridge : MonoBehaviour
    {
        /// <summary>
        /// Name of the event posted to the <see cref="EventBus"/> when a <see cref="BindItemEvent"/> is triggered.
        /// </summary>
        public static string BindItemEvent => $"{typeof(ListViewEventBusBridge).FullName}.{nameof(BindItemEvent)}";
        
        /// <summary>
        /// Name of the event posted to the <see cref="EventBus"/> when a <see cref="UnbindItemEvent"/> is triggered.
        /// </summary>
        public static string UnbindItemEvent => $"{typeof(ListViewEventBusBridge).FullName}.{nameof(UnbindItemEvent)}";
        
        /// <summary>
        /// Name of the <see cref="ListView"/>
        /// </summary>
        public string VisualElementName;

        /// <summary>
        /// The reference to the item that is populated in the <see cref="ListView"/>
        /// </summary>
        public VisualTreeAsset VisualTreeAsset;

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
                var listView = UIDocument.rootVisualElement.Q<ListView>(VisualElementName);
                
                RegisterCallbacks(listView);
            }
        }

        /// <summary>
        /// Registers callbacks on the <paramref name="visualElement"/>.
        /// </summary>
        /// <param name="visualElement">The handle to the <see cref="VisualElement"/> you want to register the events for.</param>
        protected virtual void RegisterCallbacks(ListView listView)
        {
            listView.makeItem = () =>
            {
                return VisualTreeAsset.Instantiate();
            };

            listView.bindItem = (item, index) =>
            {
                EventBus.Trigger(BindItemEvent, new ListViewBindItemEventArgs(listView, item, index));
            };
            
            listView.unbindItem = (item, index) =>
            {
                EventBus.Trigger(UnbindItemEvent, new ListViewUnbindItemEventArgs(listView, item, index));
            };
        }
    }
}
