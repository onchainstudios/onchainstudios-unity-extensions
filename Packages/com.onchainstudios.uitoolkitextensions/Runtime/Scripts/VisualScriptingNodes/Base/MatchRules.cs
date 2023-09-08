//*****************************************************************************
// Author: Arthur LeVesque
// Copyright: OnChain Studios, 2023
//*****************************************************************************

namespace OnChainStudios.UIToolkitExtensions
{
    /// <summary>
    /// Determines what criteria for the flow to execute.
    /// </summary>
    public enum MatchRules
    {
        VisualElementNameExact,
        VisualElementNameContains,
        HasClass,
        Type
    };
}
