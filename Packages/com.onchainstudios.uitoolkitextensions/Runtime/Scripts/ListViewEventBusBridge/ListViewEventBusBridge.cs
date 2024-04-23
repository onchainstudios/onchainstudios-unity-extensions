//*****************************************************************************
// Author: Rie Kumar
// Copyright: cryptoys, 2023
//*****************************************************************************

namespace OnChainStudios.UIToolkitExtensions
{
    using Unity.VisualScripting;
    using UnityEngine.UIElements;

    /// <summary>
    /// Listens to events on a ListView and forwards them the event bus. 
    /// </summary>
    public class ListViewEventBusBridge : EventBusBridgeBase
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
        /// Reference to the ListView to populate
        /// </summary>
        private ListView listView = null;

        /// <summary>
        /// Reference to the found ListView's ScrollView
        /// </summary>
        private ScrollView scrollView = null;
        
        /// <summary>
        /// Registers callbacks on the <paramref name="visualElement"/>.
        /// </summary>
        protected override void RegisterCallbacks()
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

        /// <summary>
        /// Unregisters callbacks on the <paramref name="visualElement"/>.
        /// </summary>
        protected override void UnregisterCallbacks()
        {
            if(scrollView != null)
            {
                scrollView.UnregisterCallback<ChangeEvent<float>>(OnScrollToBottom);
            }
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