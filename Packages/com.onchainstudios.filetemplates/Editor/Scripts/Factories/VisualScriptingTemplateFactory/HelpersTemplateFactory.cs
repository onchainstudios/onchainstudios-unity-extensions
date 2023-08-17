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
            /// Type identifier for a helper script graph.
            /// </summary>
            public const string Helper = nameof(Helper);
        }

        ///xml documentation in the main <see cref="VisualScriptingTemplateFactory"/> file.
        public partial class TemplateAssetPaths
        {
            /// <summary>
            /// File name for the helper template.
            /// </summary>
            public static string Helper => FileTemplateHelper.GetProjectRelativeFilePath(TypeIdentifiers.Helper + _fileNameSuffix);
        }
        
        ///xml documentation in the main <see cref="VisualScriptingTemplateFactory"/> file.
        public partial class MenuItemPaths
        {
            /// <summary>
            /// Base path for helper script graphs.
            /// </summary>
            protected const string Helpers = _basePath + nameof(Helpers) + _delimiter;
            
            /// <summary>
            /// Menu item path to create a new helper script graph.
            /// </summary>
            public const string Helper = Helpers + TypeIdentifiers.Helper;
        }

        ///xml documentation in the main <see cref="VisualScriptingTemplateFactory"/> file.
        public partial class SubFolderPaths
        {
            /// <summary>
            /// Name of the subfolder for helper script graphs.
            /// </summary>
            public static string Helper => nameof(Helper);
        }

        /// <summary>
        /// Creates a helper script graph.
        /// </summary>
        [MenuItem(MenuItemPaths.Helper)]
        public static void CreateHelpers() => CreateVisualScriptingAsset(TemplateAssetPaths.Helper, SubFolderPaths.Helper, TypeIdentifiers.Helper, FileNameSuffixes.NewFileSuffix);
    }
}
