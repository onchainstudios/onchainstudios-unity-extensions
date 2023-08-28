//*****************************************************************************
// Author: #AUTHOR#
// Copyright: #COMPANYNAME#, #YEAR#
//*****************************************************************************

namespace TemplateFile
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEditor;

    /// <summary>
    /// [INSERT CLASS COMMENT HERE]
    /// </summary>
    public class EditorWindowTemplate : EditorWindow
    {
        /// <summary>
        /// Initialization method for the window.
        /// </summary>
        //#UNCOMMENT#[MenuItem("OnChain Studios/EditorWindowTemplate")]
        public static void Init()
        {
            // Get existing open window or if none, make a new one:
            EditorWindowTemplate window = (EditorWindowTemplate)EditorWindow.GetWindow(typeof(EditorWindowTemplate));
            window.Show();
        }

        /// <summary>
        /// Unity OnGUI callback-method.
        /// </summary>
        protected virtual void OnGUI()
        {

        }
    }
}
