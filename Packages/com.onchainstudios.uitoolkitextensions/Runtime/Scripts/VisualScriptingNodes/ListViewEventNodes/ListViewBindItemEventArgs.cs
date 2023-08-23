//*****************************************************************************
// Author: Rie Kumar
// Copyright: OnChain Studios, 2023
//*****************************************************************************

using UnityEngine.UIElements;

namespace OnChainStudios.UIToolkitExtensions
{
    /// <summary>
    /// [INSERT CLASS COMMENT HERE]
    /// </summary>
    public class ListViewBindItemEventArgs : ListViewEventArgs
    {
        public ListViewBindItemEventArgs(VisualElement listview, VisualElement item, int index) : base(listview, item, index)
        {
        }
    }
}