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
        /// Name of the event posted to the <see cref="EventBus"/> when a <see cref="ScrolledToBottomEvent"/> is triggered.
        /// </summary>
        public static string ScrolledToBottomEvent => $"{typeof(ListViewEventBusBridge).FullName}.{nameof(ScrolledToBottomEvent)}";
        
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

        /// <summary>
        /// Reference to the ListView to populate
        /// </summary>
        private ListView listView = null;

        /// <summary>
        /// Reference to the found ListView's ScrollView
        /// </summary>
        private ScrollView scrollView = null;
        
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
        /// Registers callbacks on the <paramref name="visualElement"/>.
        /// </summary>
        protected virtual void RegisterCallbacks()
        {
            if (UIDocument != null && UIDocument.rootVisualElement != null)
            {
                listView = UIDocument.rootVisualElement.Q<ListView>(VisualElementName);
                
                if(listView != null)
                {
                    listView.makeItem = () =>
                    {
                        return VisualTreeAsset.Instantiate();
                    };

                    listView.bindItem = (item, index) =>
                    {
                        VisualElementCallbackManager.RegisterCallbacks(item);
                        EventBus.Trigger(BindItemEvent, new ListViewBindItemEventArgsBase(listView, item, index));
                    };
                    
                    listView.unbindItem = (item, index) =>
                    {
                        VisualElementCallbackManager.UnregisterCallbacks(item);
                        EventBus.Trigger(UnbindItemEvent, new ListViewUnbindItemEventArgsBase(listView, item, index));
                    };
                }

                scrollView = UIDocument.rootVisualElement.Q<ScrollView>();

                if(scrollView != null)
                {
                    scrollView.RegisterCallback<ChangeEvent<float>>(OnScrollToBottom);
                }
            }
        }

        /// <summary>
        /// Unregisters callbacks on the <paramref name="visualElement"/>.
        /// </summary>
        protected virtual void UnregisterCallbacks()
        {
            if (UIDocument != null && UIDocument.rootVisualElement != null)
            {
                if(scrollView != null)
                {
                    scrollView.UnregisterCallback<ChangeEvent<float>>(OnScrollToBottom);
                }
            }
        }

        /// <summary>
        /// Unregisters and then registers callbacks on the <paramref name="visualElement"/>.
        /// </summary>
        public void ReregisterCallbacks()
        {
            UnregisterCallbacks();
            RegisterCallbacks();
        }

        /// <summary>
        /// Verifies if ScrollView has reached bottom, triggers event if positive
        /// </summary>
        private void OnScrollToBottom(ChangeEvent<float> changeEvent)
        {
            if(changeEvent.newValue == (changeEvent.currentTarget as ScrollView).verticalScroller.highValue)
            {
                if(changeEvent.previousValue < changeEvent.newValue)
                {
                    EventBus.Trigger(ScrolledToBottomEvent, new ListViewScrollEventArgsBase(listView, changeEvent.previousValue));
                }
            }
        } 
    }
}