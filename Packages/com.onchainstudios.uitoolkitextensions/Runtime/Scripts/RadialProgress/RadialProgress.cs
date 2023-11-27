//*****************************************************************************
// Author: Roman Che
// Copyright: OnChain Studios, 2023
//*****************************************************************************

namespace OnChainStudios.UIToolkitExtensions
{
    using UnityEngine;
    using UnityEngine.UIElements;
    
    /// <summary>
    /// An element that displays progress inside a partially filled circle.
    /// </summary>
    public class RadialProgress : VisualElement
    {
        /// <summary>
        /// USS class name for the control overall.
        /// </summary>
        public static readonly string ussClassName = "radial-progress";

        /// <summary>
        /// Gets or sets the progress value.
        /// </summary>
        public float Progress
        {
            get => progress;
            set
            {
                // Update the progress property and request a repaint.
                progress = value;
                MarkDirtyRepaint();
            }
        }

        /// <summary>
        /// Gets or sets the line width value.
        /// </summary>
        public float LineWidth
        {
            get => lineWidth;
            set
            {
                // Update the line width property and request a repaint.
                lineWidth = value;
                MarkDirtyRepaint();
            }
        }

        /// <summary>
        /// Gets or sets the track color.
        /// </summary>
        public Color TrackColor
        {
            get => trackColor;
            set
            {
                // Update the track color property and request a repaint.
                trackColor = value;
                MarkDirtyRepaint();
            }
        }

        /// <summary>
        /// Gets or sets the progress color.
        /// </summary>
        public Color ProgressColor
        {
            get => progressColor;
            set
            {
                // Update the progress color property and request a repaint.
                progressColor = value;
                MarkDirtyRepaint();
            }
        }

        /// <summary>
        /// Custom style properties for USS.
        /// </summary>
        private static CustomStyleProperty<Color> trackColorStyleProperty = new("--track-color");
        
        /// <summary>
        /// Custom style properties for USS.
        /// </summary>
        private static CustomStyleProperty<Color> progressColorStyleProperty = new("--progress-color");

        /// <summary>
        /// The track color.
        /// </summary>
        private Color trackColor;
        
        /// <summary>
        /// The progress color.
        /// </summary>
        private Color progressColor;
        
        /// <summary>
        /// The progress value.
        /// </summary>
        private float progress;
        
        /// <summary>
        /// The line width value.
        /// </summary>
        private float lineWidth;

        /// <summary>
        /// UXML traits for the RadialProgress element.
        /// </summary>
        public new class UxmlTraits : VisualElement.UxmlTraits
        {
            /// <summary>
            /// The progress value.
            /// </summary>
            private readonly UxmlFloatAttributeDescription progressAttribute = new()
            {
                name = "progress",
                defaultValue = 15f
            };

            /// <summary>
            /// the track color.
            /// </summary>
            private readonly UxmlColorAttributeDescription trackColorAttribute = new()
            {
                name = "track-color",
                defaultValue = new (0f, 0f, 0f, 1f)
            };

            /// <summary>
            /// The progress color.
            /// </summary>
            private readonly UxmlColorAttributeDescription progressColorAttribute = new()
            {
                name = "progress-color",
                defaultValue = new (1f, 1f, 1f, 1f)
            };

            /// <summary>
            /// The progress line width.
            /// </summary>
            private readonly UxmlFloatAttributeDescription lineWidthAttribute = new()
            {
                name = "line-width",
                defaultValue = 15f
            };

            /// <inheritdoc />
            public override void Init(VisualElement ve, IUxmlAttributes bag, CreationContext cc)
            {
                base.Init(ve, bag, cc);

                // Assign values from UXML attributes to corresponding properties.
                (ve as RadialProgress).Progress = progressAttribute.GetValueFromBag(bag, cc);
                (ve as RadialProgress).LineWidth = lineWidthAttribute.GetValueFromBag(bag, cc);
                (ve as RadialProgress).TrackColor = trackColorAttribute.GetValueFromBag(bag, cc);
                (ve as RadialProgress).ProgressColor = progressColorAttribute.GetValueFromBag(bag, cc);
            }
        }

        /// <summary>
        /// UXML factory class for creating RadialProgress elements.
        /// </summary>
        public new class UxmlFactory : UxmlFactory<RadialProgress, UxmlTraits> { }

        /// <summary>
        /// Default constructor for the RadialProgress element.
        /// </summary>
        public RadialProgress()
        {
            // Add the USS class name for the overall control.
            AddToClassList(ussClassName);

            // Register a callback after custom style resolution.
            RegisterCallback<CustomStyleResolvedEvent>(evt => CustomStylesResolved(evt));

            // Register a callback to generate the visual content of the control.
            generateVisualContent += GenerateVisualContent;

            // Set default progress value.
            Progress = 0.0f;
        }

        /// <summary>
        /// Callback after custom style resolution.
        /// </summary>
        private static void CustomStylesResolved(CustomStyleResolvedEvent evt)
        {
            RadialProgress element = (RadialProgress)evt.currentTarget;
            element.UpdateCustomStyles();
        }

        /// <summary>
        /// Update the custom styles based on resolved colors.
        /// </summary>
        private void UpdateCustomStyles()
        {
            bool repaint = false;
            if (customStyle.TryGetValue(progressColorStyleProperty, out progressColor))
                repaint = true;

            if (customStyle.TryGetValue(trackColorStyleProperty, out trackColor))
                repaint = true;

            if (repaint)
                MarkDirtyRepaint();
        }

        /// <summary>
        /// Generate the visual content of the control.
        /// </summary>
        /// <param name="context">The mesh generated context.</param>
        private void GenerateVisualContent(MeshGenerationContext context)
        {
            float width = contentRect.width;
            float height = contentRect.height;

            var painter = context.painter2D;
            painter.lineWidth = lineWidth;
            painter.lineCap = LineCap.Butt;

            // Draw the track
            painter.strokeColor = trackColor;
            painter.BeginPath();
            painter.Arc(new Vector2(width * 0.5f, height * 0.5f), (width - lineWidth) * 0.5f, 0.0f, 360.0f);
            painter.Stroke();

            // Draw the progress
            painter.strokeColor = progressColor;
            painter.BeginPath();
            painter.Arc(new Vector2(width * 0.5f, height * 0.5f), (width - lineWidth) * 0.5f, -90.0f, 360.0f * (progress / 100.0f) - 90.0f);
            painter.Stroke();
        }
    }
}