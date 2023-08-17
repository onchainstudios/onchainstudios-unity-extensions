//*****************************************************************************
// Author: Arthur LeVesque
// Copyright: OnChain Studios, 2023
//*****************************************************************************

namespace OnChainStudios.FileTemplates
{
    using UnityEditor;
    
    ///xml documentation in the main <see cref="VisualScriptingTemplateFactory"/> file.
    public partial class VisualScriptingTemplateFactory
    {
        ///xml documentation in the main <see cref="VisualScriptingTemplateFactory"/> file.
        public partial class TypeIdentifiers
        {
            /// <summary>
            /// Type identifier for a <see cref="Behaviour"/> style script graph.
            /// </summary>
            public const string Behaviour = nameof(Behaviour);
        }

        ///xml documentation in the main <see cref="VisualScriptingTemplateFactory"/> file.
        public partial class TemplateAssetPaths
        {
            /// <summary>
            /// File name for the behavior template.
            /// </summary>
            public static string Behaviour => FileTemplateHelper.GetProjectRelativeFilePath(TypeIdentifiers.Behaviour + _fileNameSuffix);
        }
        
        ///xml documentation in the main <see cref="VisualScriptingTemplateFactory"/> file.
        public partial class MenuItemPaths
        {
            /// <summary>
            /// Base path for behaviour script graphs.
            /// </summary>
            private const string Behaviours = _basePath + nameof(Behaviours) + _delimiter;
            
            /// <summary>
            /// Menu item path to create a new behaviour script graph.
            /// </summary>
            public const string Behaviour = Behaviours + TypeIdentifiers.Behaviour;
        }

        ///xml documentation in the main <see cref="VisualScriptingTemplateFactory"/> file.
        public partial class SubFolderPaths
        {
            /// <summary>
            /// Name of the subfolder for behaviour script graphs.
            /// </summary>
            public static string Behaviour => nameof(Behaviour);
        }

        /// <summary>
        /// Creates a behaviour script graph.
        /// </summary>
        [MenuItem(MenuItemPaths.Behaviour)]
        public static void CreateBehaviour() => CreateVisualScriptingAsset(TemplateAssetPaths.Behaviour, SubFolderPaths.Behaviour, TypeIdentifiers.Behaviour);
    }
}
