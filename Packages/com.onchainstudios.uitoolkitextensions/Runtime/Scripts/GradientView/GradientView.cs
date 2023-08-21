//*****************************************************************************
// Author: Rie Kumar
// Copyright: OnChain Studios, 2023
//*****************************************************************************

using System.Collections.Generic;

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
        /// Indicates if the gradient view is allowed changes in editor.
        /// </summary>
        public bool allowUpdatesInEditor { get; set; }
        
        public float angle { get; set; }
        
        /// <summary>
        /// The initial color of the gradient. 
        /// </summary>
        public Color color1 { get; set; }
        
        /// <summary>
        /// The stop position of <see cref="color1"/>
        /// </summary>
        public float color1Position { get; set; }

        /// <summary>
        /// The second color of the gradient.
        /// </summary>
        public Color color2 { get; set; }
        
        /// <summary>
        /// The stop position of <see cref="color2"/>
        /// </summary>
        public float color2Position { get; set; }

        /// <summary>
        /// The third color of the gradient.
        /// </summary>
        public Color color3 { get; set; }
        
        /// <summary>
        /// The stop position of <see cref="color3"/>
        /// </summary>
        public float color3Position { get; set; }

        /// <summary>
        /// The fourth color of the gradient.
        /// </summary>
        public Color color4 { get; set; }
        
        /// <summary>
        /// The stop position of <see cref="color4"/>
        /// </summary>
        public float color4Position { get; set; }

        /// <summary>
        /// The final color of the gradient.
        /// </summary>
        public Color color5 { get; set; }
        
        /// <summary>
        /// The stop position of <see cref="color5"/>
        /// </summary>
        public float color5Position { get; set; }

        /// <summary>
        /// Holds a reference to the root visual element.
        /// </summary>
        private VisualElement root;

        /// <summary>
        /// Cached <see cref="color1"/>
        /// </summary>
        private Color previousColor1;
        
        /// <summary>
        /// Cached <see cref="color1Position"/>
        /// </summary>
        private float previousColor1Position;
        
        /// <summary>
        /// Cached <see cref="previousColor2"/>
        /// </summary>
        private Color previousColor2;
        
        /// <summary>
        /// Cached <see cref="previousColor2Position"/>
        /// </summary>
        private float previousColor2Position;
        
        /// <summary>
        /// Cached <see cref="previousColor3"/>
        /// </summary>
        private Color previousColor3;
        
        /// <summary>
        /// Cached <see cref="previousColor3Position"/>
        /// </summary>
        private float previousColor3Position;
        
        /// <summary>
        /// Cached <see cref="previousColor4"/>
        /// </summary>
        private Color previousColor4;
        
        /// <summary>
        /// Cached <see cref="previousColor4Position"/>
        /// </summary>
        private float previousColor4Position;
        
        /// <summary>
        /// Cached <see cref="previousColor5"/>
        /// </summary>
        private Color previousColor5;
        
        /// <summary>
        /// Cached <see cref="previousColor5Position"/>
        /// </summary>
        private float previousColor5Position;
        
        /// <summary>
        /// An event that updates the gradient when the view has changed or updated.
        /// </summary>
        /// <param name="evt">Event arguments to provide details on the new layout and view.</param>
        private void UpdateGradient(GeometryChangedEvent evt)
        {
            if (Application.isPlaying || allowUpdatesInEditor || !Application.isEditor)
            {
                FillGradients();
            }
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
                var texture = root.style.backgroundImage.value.texture;

                if (HasGradientElementChanged(texture, width, height))
                {
                    UpdateCachedValues();
                    
                    texture.Reinitialize((int)width, (int)height);


                    var stops = new List<GradientColorPositions>();
                    stops.Add(new GradientColorPositions() {color = color1, position = color1Position});
                    stops.Add(new GradientColorPositions() {color = color2, position = color2Position});
                    stops.Add(new GradientColorPositions() {color = color3, position = color3Position});
                    stops.Add(new GradientColorPositions() {color = color4, position = color4Position});
                    stops.Add(new GradientColorPositions() {color = color5, position = color5Position});
                    
                    GenerateGradientTexture(texture, width, height, angle, stops);
                }
                
            }
        }

        public void GenerateGradientTexture(Texture2D texture, int width, int height, float degrees, List<GradientColorPositions> colorPositions)
        {
            Vector2 gradientDirection = Quaternion.Euler(0, 0, degrees) * Vector2.right;

            bool isHorizontalGradient = Mathf.Abs(gradientDirection.x) > Mathf.Abs(gradientDirection.y);

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    Vector2 currentPixel = new Vector2(x, y);
                    float positionAlongGradient = Vector2.Dot(currentPixel, gradientDirection);

                    float t = isHorizontalGradient ?
                        Mathf.InverseLerp(0, width - 1, positionAlongGradient) :
                        Mathf.InverseLerp(0, height - 1, positionAlongGradient);

                    Color interpolatedColor = InterpolateColors(t, colorPositions);
                    texture.SetPixel(x, y, interpolatedColor);
                }
            }

            texture.Apply();
        }

        private Color InterpolateColors(float t, List<GradientColorPositions> colorPositions)
        {
            if (colorPositions.Count == 0)
                return Color.white;

            int startIndex = 0;
            int endIndex = colorPositions.Count - 1;

            for (int i = 0; i < colorPositions.Count - 1; i++)
            {
                if (t < colorPositions[i + 1].position)
                {
                    startIndex = i;
                    endIndex = i + 1;
                    break;
                }
            }

            float tInRange = Mathf.InverseLerp(colorPositions[startIndex].position, colorPositions[endIndex].position, t);
            return Color.Lerp(colorPositions[startIndex].color, colorPositions[endIndex].color, tInRange);
        }
        
        [System.Serializable]
        public struct GradientColorPositions
        {
            public Color color;
            [Range(0f, 1f)]
            public float position;
        }

        /// <summary>
        /// Updates the cached values.
        /// </summary>
        private void UpdateCachedValues()
        {
            previousColor1 = color1;
            previousColor1Position = color1Position;
            previousColor2 = color2;
            previousColor2Position = color2Position;
            previousColor3 = color3;
            previousColor3Position = color3Position;
            previousColor4 = color4;
            previousColor4Position = color4Position;
            previousColor5 = color5;
            previousColor5Position = color5Position;
        }
        
        /// <summary>
        /// Indicates if the gradient element's gradient has changed.
        /// </summary>
        /// <param name="texture">The current texture on the gradient.</param>
        /// <param name="newWidth">The new height of the gradient.</param>
        /// <param name="newHeight">The new width of the gradient.</param>
        /// <returns>True, if the gradient element has changed. False, if it has not changed.</returns>
        private bool HasGradientElementChanged(Texture2D texture, int newWidth, int newHeight)
        {
            return texture.height != newHeight || texture.width != newWidth || HasColorChanged();
        }
        
        /// <summary>
        /// Indicates if the gradient element's cached colors and lengths is different from the current element's colors and lengths.
        /// </summary>
        /// <returns>True, if one or more of the colors and lengths have changed. False, otherwise.</returns>
        private bool HasColorChanged()
        {
            bool result = false; 
            
            
            if (color1 != previousColor1 || color1Position != previousColor1Position)
            {
                result = true;
            }
            else if (color2 != previousColor2 || color2Position != previousColor2Position)
            {
                result = true;
            }
            else if (color3 != previousColor3 || color3Position != previousColor3Position)
            {
                result = true;
            }
            else if (color4 != previousColor4 || color4Position != previousColor4Position)
            {
                result = true;
            }
            else if (color5 != previousColor5)
            {
                result = true;
            }

            return result;
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
            /// The attribute that correlates with <seealso cref="GradientView.allowUpdatesInEditor"/>
            /// </summary>
            private UxmlBoolAttributeDescription m_allowUpdatesInEditor =
                new UxmlBoolAttributeDescription() { name = "allow-updates-in-editor", defaultValue = false };
            
            /// <summary>
            /// Angle of the gradient.
            /// </summary>
            private UxmlFloatAttributeDescription m_angle = new UxmlFloatAttributeDescription()
                { name = "angle", defaultValue = 0 };
            
            /// <summary>
            /// The attribute that correlates with <seealso cref="GradientView.color1"/>/>
            /// </summary>
            UxmlColorAttributeDescription m_color1 = new UxmlColorAttributeDescription()
                { name = "color1", defaultValue = new Color(0, 0, 0, 0) };

            /// <summary>
            /// The attribute that correlates with <seealso cref="GradientView.color1Position"/>/>
            /// </summary>
            UxmlFloatAttributeDescription m_color1Position = new UxmlFloatAttributeDescription()
                { name = "color1-position", defaultValue = 0 };

            /// <summary>
            /// The attribute that correlates with <seealso cref="GradientView.color2"/>/>
            /// </summary>
            UxmlColorAttributeDescription m_color2 = new UxmlColorAttributeDescription()
                { name = "color2", defaultValue = new Color(0, 0, 0, 0) };

            /// <summary>
            /// The attribute that correlates with <seealso cref="GradientView.color2Position"/>/>
            /// </summary>
            UxmlFloatAttributeDescription m_color2Position = new UxmlFloatAttributeDescription()
                { name = "color2-position", defaultValue = 0 };

            /// <summary>
            /// The attribute that correlates with <seealso cref="GradientView.color3"/>/>
            /// </summary>
            UxmlColorAttributeDescription m_color3 = new UxmlColorAttributeDescription()
                { name = "color3", defaultValue = new Color(0, 0, 0, 0) };

            /// <summary>
            /// The attribute that correlates with <seealso cref="GradientView.color3Position"/>/>
            /// </summary>
            UxmlFloatAttributeDescription m_color3Position = new UxmlFloatAttributeDescription()
                { name = "color3-position", defaultValue = 0 };

            /// <summary>
            /// The attribute that correlates with <seealso cref="GradientView.color4"/>/>
            /// </summary>
            UxmlColorAttributeDescription m_color4 = new UxmlColorAttributeDescription()
                { name = "color4", defaultValue = new Color(0, 0, 0, 0) };

            /// <summary>
            /// The attribute that correlates with <seealso cref="GradientView.color4Position"/>/>
            /// </summary>
            UxmlFloatAttributeDescription m_color4Position = new UxmlFloatAttributeDescription()
                { name = "color4-position", defaultValue = 0 };

            /// <summary>
            /// The attribute that correlates with <seealso cref="GradientView.color5"/>/>
            /// </summary>
            UxmlColorAttributeDescription m_color5 = new UxmlColorAttributeDescription()
                { name = "color5", defaultValue = new Color(0, 0, 0, 0) };

            /// <summary>
            /// The attribute that correlates with <seealso cref="GradientView.color4Position"/>/>
            /// </summary>
            UxmlFloatAttributeDescription m_color5Position = new UxmlFloatAttributeDescription()
                { name = "color5-position", defaultValue = 0 };
            
            /// <inheritdoc />
            public override void Init(VisualElement ve, IUxmlAttributes bag, CreationContext cc)
            {
                base.Init(ve, bag, cc);

                var element = ve as GradientView;

                element.allowUpdatesInEditor = m_allowUpdatesInEditor.GetValueFromBag(bag, cc);
                element.angle = m_angle.GetValueFromBag(bag, cc);
                
                element.color1 = m_color1.GetValueFromBag(bag, cc);
                element.color1Position = m_color1Position.GetValueFromBag(bag, cc);

                element.color2 = m_color2.GetValueFromBag(bag, cc);
                element.color2Position = m_color2Position.GetValueFromBag(bag, cc);

                element.color3 = m_color3.GetValueFromBag(bag, cc);
                element.color3Position = m_color3Position.GetValueFromBag(bag, cc);

                element.color4 = m_color4.GetValueFromBag(bag, cc);
                element.color4Position = m_color4Position.GetValueFromBag(bag, cc);

                element.color5 = m_color5.GetValueFromBag(bag, cc);
                element.color5Position = m_color5Position.GetValueFromBag(bag, cc);

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