using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class GradientView : VisualElement
{
    public Color startColor { get; set; }
    public Color endColor { get; set; }
    
    public Direction direction { get; set; }

    private VisualElement root;

    private void UpdateGradient(GeometryChangedEvent evt)
    {
        FillGradient();
    }
    
    private void FillGradient()
    {
        int width = Mathf.CeilToInt(resolvedStyle.width);
        int height = Mathf.CeilToInt(resolvedStyle.height);

        if (width > 0 && height > 0)
        {
            root.style.backgroundImage.value.texture.Reinitialize(width, height);

            for (int x = 0; x < width; ++x)
            {
                for (int y = 0; y < height; ++y)
                {
                    float t = 0;
                    
                    switch (direction)
                    {
                        case Direction.Horizontal:
                            t = (float)x / (float)width;
                            break;

                        case Direction.Vertical:
                            t = (float)y / (float)height;
                            break;

                        case Direction.Diagonal:
                            t = (float)(x + y) / (width + height);
                            break;
                    }
                    
                    var linearColor = Color.Lerp(startColor, endColor, t);
                    root.style.backgroundImage.value.texture.SetPixel(x, y, linearColor);
                }
            }
        
            root.style.backgroundImage.value.texture.Apply();
        }
    }
    
    public enum Direction
    {
        Horizontal,
        Vertical,
        Diagonal,
    } 
    
    public new class UxmlFactory: UxmlFactory<GradientView, UxmlTraits>{ }
    
    public new class UxmlTraits : VisualElement.UxmlTraits
    {
        UxmlColorAttributeDescription m_startColor = new UxmlColorAttributeDescription(){ name = "start-color", defaultValue = new Color(0,0,0,0)};
        UxmlColorAttributeDescription m_endColor = new UxmlColorAttributeDescription(){ name = "end-color", defaultValue = new Color(0,0,0,0) };
        UxmlEnumAttributeDescription<Direction> m_direction = new UxmlEnumAttributeDescription<Direction>(){ name = "direction", defaultValue = 0 };
        
        public override void Init(VisualElement ve, IUxmlAttributes bag, CreationContext cc)
        {
            base.Init(ve, bag, cc);

            var element = ve as GradientView;
            element.startColor = m_startColor.GetValueFromBag(bag, cc);
            element.endColor = m_endColor.GetValueFromBag(bag, cc);
            element.direction = m_direction.GetValueFromBag(bag, cc);

            element.Clear();
            VisualTreeAsset vt = Resources.Load<VisualTreeAsset>("GradientView/GradientView");
            VisualElement gradientview = vt.Instantiate();

            element.root = gradientview.Q<VisualElement>("gradient-view");
            gradientview.style.flexGrow = 1;
            
            element.Add(gradientview);
            element.RegisterCallback<GeometryChangedEvent>(element.UpdateGradient);
            element.root.style.backgroundImage = new StyleBackground(new Texture2D(1, 1));
            element.FillGradient();
        }
    }
}
