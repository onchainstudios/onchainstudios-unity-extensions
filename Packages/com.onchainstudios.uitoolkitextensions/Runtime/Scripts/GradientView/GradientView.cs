using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class GradientView : VisualElement
{
    public Color color1 { get; set; }
    public float color1Percentage { get; set; }
    
    public Color color2 { get; set; }
    public float color2Percentage { get; set; }
    
    public Color color3 { get; set; }
    public float color3Percentage { get; set; }

    public Color color4 { get; set; }
    public float color4Percentage { get; set; }

    public Color color5 { get; set; }
    
    private VisualElement root;
    
    private void UpdateGradient(GeometryChangedEvent evt)
    {
        FillGradients();
    }
    
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

    private void FillGradient(Color startColor, Color endColor, int width, int height, int start, float percent, out int end)
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
    
    public new class UxmlFactory: UxmlFactory<GradientView, UxmlTraits>{ }
    
    public new class UxmlTraits : VisualElement.UxmlTraits
    {
        UxmlColorAttributeDescription m_color1 = new UxmlColorAttributeDescription(){ name = "color1", defaultValue = new Color(0,0,0,0)};
        UxmlFloatAttributeDescription m_color1Percentage = new UxmlFloatAttributeDescription(){ name = "color1-percentage", defaultValue = 0};
        
        UxmlColorAttributeDescription m_color2 = new UxmlColorAttributeDescription(){ name = "color2", defaultValue = new Color(0,0,0,0) };
        UxmlFloatAttributeDescription m_color2Percentage = new UxmlFloatAttributeDescription(){ name = "color2-percentage", defaultValue = 0};

        UxmlColorAttributeDescription m_color3 = new UxmlColorAttributeDescription(){ name = "color3", defaultValue = new Color(0,0,0,0) };
        UxmlFloatAttributeDescription m_color3Percentage = new UxmlFloatAttributeDescription(){ name = "color3-percentage", defaultValue = 0};

        UxmlColorAttributeDescription m_color4 = new UxmlColorAttributeDescription(){ name = "color4", defaultValue = new Color(0,0,0,0) };
        UxmlFloatAttributeDescription m_color4Percentage = new UxmlFloatAttributeDescription(){ name = "color4-percentage", defaultValue = 0};

        UxmlColorAttributeDescription m_color5 = new UxmlColorAttributeDescription(){ name = "color5", defaultValue = new Color(0,0,0,0) };
        
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
