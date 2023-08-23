//*****************************************************************************
// Author: Rie Kumar
// Copyright: OnChain Studios, 2023
//*****************************************************************************

namespace OnChainStudios.UIToolkitExtensions
{
    using System;
    using UnityEngine;

    /// <summary>
    /// The position and color of the gradient.
    /// </summary>
    public struct GradientColorPosition
    {
        /// <summary>
        /// The color of the gradient stop position.
        /// </summary>
        public Color Color;
        
        /// <summary>
        /// The position of the gradient color.
        /// </summary>
        [Range(0f, 1f)] 
        public float Position;
    }
}