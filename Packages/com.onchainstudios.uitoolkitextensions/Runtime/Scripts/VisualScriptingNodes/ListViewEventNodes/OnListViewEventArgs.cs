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
    public class ListViewEventArgs
    {
        public VisualElement ListView { get; set; }
        public VisualElement Item { get; set; }
        public int Index { get; set; }

        public ListViewEventArgs(VisualElement listView, VisualElement item, int index)
        {
            ListView = listView;
            Item = item;
            Index = index;
        }
    }
}