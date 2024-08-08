//*****************************************************************************
// Author: Arthur LeVesque
// Copyright: OnChain Studios, 2024
//*****************************************************************************

namespace OnChainStudios.UIToolkitExtensions
{
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UIElements;
    
    /// <summary>
    /// Custom visual element to allow a group of visual elements to be contained by the safe area of a device.
    /// </summary>
    public class SafeAreaContainer : VisualElement
    {
        /// <summary>
        /// The uxml factory for the <see cref="SafeAreaContainer"/>
        /// </summary>
        [UnityEngine.Scripting.Preserve]
        public new class UxmlFactory : UxmlFactory<SafeAreaContainer, UxmlTraits> {}

        /// <summary>
        /// The custom <see cref="UnityEngine.UIElements.UxmlTraits"/> for the <see cref="SafeAreaContainer"/>
        /// </summary>
        public new class UxmlTraits : VisualElement.UxmlTraits
        {
            ///<inheritdoc/>
            public override IEnumerable<UxmlChildElementDescription> uxmlChildElementsDescription
            {
                get { yield break; }
            }

            ///<inheritdoc/>
            public override void Init(VisualElement ve, IUxmlAttributes bag, CreationContext cc)
            {
                base.Init(ve, bag, cc);

                ve.style.position = Position.Absolute;
                ve.style.top = 0;
                ve.style.bottom = 0;
                ve.style.left = 0;
                ve.style.right = 0;
                ve.pickingMode = PickingMode.Ignore;
            }
        }

        /// <summary>
        /// Backing field for the <see cref="contentContainer"/>
        /// </summary>
        protected VisualElement ContentContainer;

        ///<inheritdoc/>
        public override VisualElement contentContainer => ContentContainer;

        /// <summary>
        /// Constructor
        /// </summary>
        public SafeAreaContainer()
        {
            ContentContainer = new VisualElement();
            ContentContainer.name = "safe-area-content-container";
            ContentContainer.pickingMode = PickingMode.Ignore;
            ContentContainer.style.flexGrow = 1;
            ContentContainer.style.flexShrink = 0;
            ContentContainer.style.paddingTop = 0;
            ContentContainer.style.paddingBottom = 0;
            ContentContainer.style.paddingLeft = 0;
            ContentContainer.style.paddingRight = 0;
            hierarchy.Add(ContentContainer);

            RegisterCallback<GeometryChangedEvent>(OnGeometryChanged);
        }

        /// <summary>
        /// Event handler for the <see cref="GeometryChangedEvent"/>
        /// </summary>
        /// <param name="evt">The event data from the event.</param>
        private void OnGeometryChanged(GeometryChangedEvent evt)
        {
            try
            {
                var topPadding = Screen.height - Screen.safeArea.center.y - Screen.safeArea.height / 2;
                var bottomPadding = Screen.height - (Screen.height - Screen.safeArea.center.y + Screen.safeArea.height / 2);
                var leftPadding = Screen.width - Screen.safeArea.center.x - Screen.safeArea.width / 2;
                var rightPadding = Screen.width - (Screen.width - Screen.safeArea.center.x + Screen.safeArea.width / 2);
                var leftTop = RuntimePanelUtils.ScreenToPanel(panel, new Vector2(leftPadding, topPadding));
                var rightBottom = RuntimePanelUtils.ScreenToPanel(panel, new Vector2(rightPadding, bottomPadding));

                contentContainer.style.paddingTop = leftTop.y;
                contentContainer.style.paddingBottom = rightBottom.y;
                contentContainer.style.paddingLeft = leftTop.x;
                contentContainer.style.paddingRight = rightBottom.x;
            }
            catch (System.InvalidCastException) {}
        }
    }
}
