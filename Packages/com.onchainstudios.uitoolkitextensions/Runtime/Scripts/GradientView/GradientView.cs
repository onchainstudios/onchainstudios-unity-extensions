//*****************************************************************************
// Author: Rie Kumar
// Copyright: OnChain Studios, 2023
//*****************************************************************************

namespace OnChainStudios.UIToolkitExtensions
{
    using UnityEngine;
    using UnityEngine.UIElements;

    /// <summary>
    /// A custom visual element that acts similarly to the CSS Linear Gradient.
    /// </summary>
    public class GradientView : VisualElement
    {
        /// <summary>
        /// The initial color of the gradient. 
        /// </summary>
        public Color color1 { get; set; }
        
        /// <summary>
        /// The length of the transition of the gradient between <see cref="color1"/> and <see cref="color2"/>
        /// </summary>
        public float color1Percentage { get; set; }

        /// <summary>
        /// The second color of the gradient.
        /// </summary>
        public Color color2 { get; set; }
        
        /// <summary>
        /// The length of the transition of the gradient between <see cref="color2"/> and <see cref="color3"/>
        /// </summary>
        public float color2Percentage { get; set; }

        /// <summary>
        /// The third color of the gradient.
        /// </summary>
        public Color color3 { get; set; }
        
        /// <summary>
        /// The length of the transition of the gradient between <see cref="color3"/> and <see cref="color4"/>
        /// </summary>
        public float color3Percentage { get; set; }

        /// <summary>
        /// The fourth color of the gradient.
        /// </summary>
        public Color color4 { get; set; }
        
        /// <summary>
        /// The length of the transition of the gradient between <see cref="color4"/> and <see cref="color5"/>
        /// </summary>
        public float color4Percentage { get; set; }

        /// <summary>
        /// The final color of the gradient.
        /// </summary>
        public Color color5 { get; set; }

        /// <summary>
        /// Holds a reference to the root visual element.
        /// </summary>
        private VisualElement root;

        /// <summary>
        /// An event that updates the gradient when the view has changed or updated.
        /// </summary>
        /// <param name="evt">Event arguments to provide details on the new layout and view.</param>
        private void UpdateGradient(GeometryChangedEvent evt)
        {
            FillGradients();
        }

        /// <summary>
        /// Fills the gradient based on the five colors configured.
        /// </summary>
        private void FillGradients()
        {
            int width = Mathf.CeilToInt(resolvedStyle.width);
            int height = Mathf.CeilToInt(resolvedStyle.height);

            if (width > 0 && height > 0)
            {
                root.style.backgroundImage.value.texture.Reinitialize((int)width, (int)height);

                int end = 0;

                FillGradient(color1, color2, width, height, 0, color1Percentage, out end);
                FillGradient(color2, color3, width, height, end, color2Percentage, out end);
                FillGradient(color3, color4, width, height, end, color3Percentage, out end);
                FillGradient(color4, color5, width, height, end, color4Percentage, out end);
            }
        }

        /// <summary>
        /// Fills a specific length of the gradient.
        /// </summary>
        /// <param name="startColor">The initial color of the gradient segment.</param>
        /// <param name="endColor">The final color of the gradient segment.</param>
        /// <param name="width">The width of the gradient visual element.</param>
        /// <param name="height">The height of the gradient visual element.</param>
        /// <param name="start">The starting position of the gradient segment.</param>
        /// <param name="percent">The length of the segment to transition between the <see cref="startColor"/> and <see cref="endColor"/></param>
        /// <param name="end">Stores the ending position of the gradient segment.</param>
        private void FillGradient(Color startColor, Color endColor, int width, int height, int start, float percent,
            out int end)
        {
            if (Mathf.CeilToInt(percent) <= 0)
            {
                end = start;
                return;
            }

            percent /= 100;
            end = Mathf.Clamp(Mathf.CeilToInt(width * percent) + start, 0, width);

            for (int x = start; x < end; ++x)
            {
                for (int y = 0; y < height; ++y)
                {
                    float t = 0;
                    t = (float)(x - start) / (float)(end - start);

                    var linearColor = Color.Lerp(startColor, endColor, t);
                    root.style.backgroundImage.value.texture.SetPixel(x, y, linearColor);
                }
            }

            root.style.backgroundImage.value.texture.Apply();
        }

        /// <summary>
        /// The factory that creates a <see cref="GradientView"/>
        /// </summary>
        public new class UxmlFactory : UxmlFactory<GradientView, UxmlTraits>
        {
        }

        /// <summary>
        /// The defined Uxml Traits of the <see cref="GradientView"/>
        /// </summary>
        public new class UxmlTraits : VisualElement.UxmlTraits
        {
            /// <summary>
            /// The attribute that correlates with <seealso cref="GradientView.color1"/>/>
            /// </summary>
            UxmlColorAttributeDescription m_color1 = new UxmlColorAttributeDescription()
                { name = "color1", defaultValue = new Color(0, 0, 0, 0) };

            /// <summary>
            /// The attribute that correlates with <seealso cref="GradientView.color1Percentage"/>/>
            /// </summary>
            UxmlFloatAttributeDescription m_color1Percentage = new UxmlFloatAttributeDescription()
                { name = "color1-percentage", defaultValue = 0 };

            /// <summary>
            /// The attribute that correlates with <seealso cref="GradientView.color2"/>/>
            /// </summary>
            UxmlColorAttributeDescription m_color2 = new UxmlColorAttributeDescription()
                { name = "color2", defaultValue = new Color(0, 0, 0, 0) };

            /// <summary>
            /// The attribute that correlates with <seealso cref="GradientView.color2Percentage"/>/>
            /// </summary>
            UxmlFloatAttributeDescription m_color2Percentage = new UxmlFloatAttributeDescription()
                { name = "color2-percentage", defaultValue = 0 };

            /// <summary>
            /// The attribute that correlates with <seealso cref="GradientView.color3"/>/>
            /// </summary>
            UxmlColorAttributeDescription m_color3 = new UxmlColorAttributeDescription()
                { name = "color3", defaultValue = new Color(0, 0, 0, 0) };

            /// <summary>
            /// The attribute that correlates with <seealso cref="GradientView.color3Percentage"/>/>
            /// </summary>
            UxmlFloatAttributeDescription m_color3Percentage = new UxmlFloatAttributeDescription()
                { name = "color3-percentage", defaultValue = 0 };

            /// <summary>
            /// The attribute that correlates with <seealso cref="GradientView.color4"/>/>
            /// </summary>
            UxmlColorAttributeDescription m_color4 = new UxmlColorAttributeDescription()
                { name = "color4", defaultValue = new Color(0, 0, 0, 0) };

            /// <summary>
            /// The attribute that correlates with <seealso cref="GradientView.color4Percentage"/>/>
            /// </summary>
            UxmlFloatAttributeDescription m_color4Percentage = new UxmlFloatAttributeDescription()
                { name = "color4-percentage", defaultValue = 0 };

            /// <summary>
            /// The attribute that correlates with <seealso cref="GradientView.color5"/>/>
            /// </summary>
            UxmlColorAttributeDescription m_color5 = new UxmlColorAttributeDescription()
                { name = "color5", defaultValue = new Color(0, 0, 0, 0) };

            /// <inheritdoc />
            public override void Init(VisualElement ve, IUxmlAttributes bag, CreationContext cc)
            {
                base.Init(ve, bag, cc);

                var element = ve as GradientView;

                element.color1 = m_color1.GetValueFromBag(bag, cc);
                element.color1Percentage = m_color1Percentage.GetValueFromBag(bag, cc);

                element.color2 = m_color2.GetValueFromBag(bag, cc);
                element.color2Percentage = m_color2Percentage.GetValueFromBag(bag, cc);

                element.color3 = m_color3.GetValueFromBag(bag, cc);
                element.color3Percentage = m_color3Percentage.GetValueFromBag(bag, cc);

                element.color4 = m_color4.GetValueFromBag(bag, cc);
                element.color4Percentage = m_color4Percentage.GetValueFromBag(bag, cc);

                element.color5 = m_color5.GetValueFromBag(bag, cc);

                element.Clear();
                VisualTreeAsset vt = Resources.Load<VisualTreeAsset>("GradientView/GradientView");
                VisualElement gradientview = vt.Instantiate();

                element.root = gradientview.Q<VisualElement>("gradient-view");
                gradientview.style.flexGrow = 1;

                element.Add(gradientview);
                element.RegisterCallback<GeometryChangedEvent>(element.UpdateGradient);
                element.root.style.backgroundImage = new StyleBackground(new Texture2D(1, 1));
                element.FillGradients();
            }
        }
    }
}