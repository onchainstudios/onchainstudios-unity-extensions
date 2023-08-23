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
    public class ListViewUnbindItemEventArgs : ListViewEventArgs
    {
        public ListViewUnbindItemEventArgs(VisualElement listView, VisualElement item, int index) : base(listView, item, index)
        {
        }
    }
}