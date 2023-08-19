//*****************************************************************************
// Author: Arthur LeVesque
// Copyright: OnChain Studios, 2023
//*****************************************************************************

namespace OnChainStudios.FileTemplates
{
    using UnityEditor;

    //xml documentation in the file VisualScriptingTemplateFactory.
    public static partial class VisualScriptingTemplateFactory
    {
        //xml documentation in the file VisualScriptingTemplateFactory.
        public static partial class TypeIdentifiers
        {
            /// <summary>
            /// Type identifiers for all methods.
            /// </summary>
            public static class Methods
            {
                /// <summary>
                /// Type identifier for a method script graph.
                /// </summary>
                public const string Method = nameof(Method);
            }
        }

        //xml documentation in the file VisualScriptingTemplateFactory.
        public static partial class TemplateAssetPaths
        {
            /// <summary>
            /// Template asset paths for all methods.
            /// </summary>
            public static class Methods
            {
                /// <summary>
                /// File name for the method template.
                /// </summary>
                public static string Method => FileTemplateHelper.GetProjectRelativeFilePath(TypeIdentifiers.Methods.Method + _fileNameSuffix);
            }
        }

        //xml documentation in the file VisualScriptingTemplateFactory.
        public static partial class MenuItemPaths
        {
            /// <summary>
            /// Menu item paths for all methods.
            /// </summary>
            public static class Methods
            {
                /// <summary>
                /// Base path for method script graphs.
                /// </summary>
                private const string _methodsBasePath = _basePath + nameof(Methods) + _delimiter;

                /// <summary>
                /// Menu item path to create a new method script graph.
                /// </summary>
                public const string Method = _methodsBasePath + nameof(Method);
            }
        }

        //xml documentation in the file VisualScriptingTemplateFactory.
        public static partial class SubFolderPaths
        {
            /// <summary>
            /// Sub folder paths for all methods.
            /// </summary>
            public static class Methods
            {
                /// <summary>
                /// Name of the subfolder for method script graphs.
                /// </summary>
                public static string Method => nameof(Methods);
            }
        }

        /// <summary>
        /// Creates a method script graph.
        /// </summary>
        [MenuItem(MenuItemPaths.Methods.Method)]
        public static void CreateMethod() => CreateVisualScriptingAsset(TemplateAssetPaths.Methods.Method, SubFolderPaths.Methods.Method, TypeIdentifiers.Methods.Method, FileNameSuffixes.NewFileSuffix);
    }
}
