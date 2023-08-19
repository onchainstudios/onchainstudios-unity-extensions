//*****************************************************************************
// Author: Arthur LeVesque
// Copyright: OnChain Studios, 2023
//*****************************************************************************

namespace OnChainStudios.FileTemplates
{
    using UnityEditor;
    using System.IO;

    //xml documentation in the file VisualScriptingTemplateFactory.
    public static  partial class VisualScriptingTemplateFactory
    {
        //xml documentation in the file VisualScriptingTemplateFactory.
        public static partial class TypeIdentifiers
        {
            //xml documentation in the file ConstantsTemplateFactory.
            public static partial class Variables
            {
                /// <summary>
                /// Type identifiers for all Scene variables.
                /// </summary>
                public static class Scene
                {
                    /// <summary>
                    /// Type identifier for a Scene get script graph.
                    /// </summary>
                    public const string Get = nameof(Scene) + _delimiter + nameof(Get);

                    /// <summary>
                    /// Type identifier for a Scene has script graph.
                    /// </summary>
                    public const string Has = nameof(Scene) + _delimiter + nameof(Has);

                    /// <summary>
                    /// Type identifier for a Scene set script graph.
                    /// </summary>
                    public const string Set = nameof(Scene) + _delimiter + nameof(Set);
                }
            }
        }

        //xml documentation in the file VisualScriptingTemplateFactory.
        public static partial class TemplateAssetPaths
        {
            //xml documentation in the file ConstantsTemplateFactory.
            public static partial class Variables
            {
                /// <summary>
                /// Template asset paths for all Scene variables.
                /// </summary>
                public static class Scene
                {
                    /// <summary>
                    /// File name for the Scene get template.
                    /// </summary>
                    public static string Get => FileTemplateHelper.GetProjectRelativeFilePath(TypeIdentifiers.Variables.Scene.Get + _fileNameSuffix);

                    /// <summary>
                    /// File name for the Scene has template.
                    /// </summary>
                    public static string Has => FileTemplateHelper.GetProjectRelativeFilePath(TypeIdentifiers.Variables.Scene.Has + _fileNameSuffix);

                    /// <summary>
                    /// File name for the Scene set template.
                    /// </summary>
                    public static string Set => FileTemplateHelper.GetProjectRelativeFilePath(TypeIdentifiers.Variables.Scene.Set + _fileNameSuffix);
                }
            }
        }

        //xml documentation in the file VisualScriptingTemplateFactory.
        public static partial class MenuItemPaths
        {
            //xml documentation in the file ConstantsTemplateFactory.
            public static partial class Variables
            {
                /// <summary>
                /// Menu Item Paths for Scene Variables.
                /// </summary>
                public static class Scene
                {
                    /// <summary>
                    /// Base path for all Scene variables.
                    /// </summary>
                    private const string _sceneBasePath = _variablesBasePath + nameof(Scene) + _delimiter;

                    /// <summary>
                    /// Menu Item Path for a Scene get variable.
                    /// </summary>
                    public const string Get = _sceneBasePath + nameof(Get);

                    /// <summary>
                    /// Menu Item Path for a Scene has variable.
                    /// </summary>
                    public const string Has = _sceneBasePath + nameof(Has);

                    /// <summary>
                    /// Menu Item Path for a Scene has variable.
                    /// </summary>
                    public const string Set = _sceneBasePath + nameof(Set);
                }
            }
        }

        //xml documentation in the file VisualScriptingTemplateFactory.
        public static partial class SubFolderPaths
        {
            //xml documentation in the file ConstantsTemplateFactory.
            public static partial class Variables
            {
                /// <summary>
                /// Sub folder paths for all Scene variables.
                /// </summary>
                public static class Scene
                {
                    /// <summary>
                    /// Base subfolder path for Scene variables.
                    /// </summary>
                    private static string _sceneVariablesBasePath => Path.Combine(nameof(Variables), nameof(Scene));

                    /// <summary>
                    /// Sub folder path for Scene get.
                    /// </summary>
                    public static string Get => Path.Combine(_sceneVariablesBasePath, nameof(Get));

                    /// <summary>
                    /// Sub Folder path for Scene has.
                    /// </summary>
                    public static string Has => Path.Combine(_sceneVariablesBasePath, nameof(Has));

                    /// <summary>
                    /// Sub folder path for Scene set.
                    /// </summary>
                    public static string Set => Path.Combine(_sceneVariablesBasePath, nameof(Set));
                }
            }
        }

        /// <summary>
        /// Creates a Scene Get Variable script graph.
        /// </summary>
        [MenuItem(MenuItemPaths.Variables.Scene.Get)]
        public static void CreateSceneGet() => CreateVisualScriptingAsset(TemplateAssetPaths.Variables.Scene.Get, SubFolderPaths.Variables.Scene.Get, TypeIdentifiers.Variables.Scene.Get, FileNameSuffixes.NewFileSuffix, true);

        /// <summary>
        /// Creates a Scene Has Variable script graph.
        /// </summary>
        [MenuItem(MenuItemPaths.Variables.Scene.Has)]
        public static void CreateSceneHas() => CreateVisualScriptingAsset(TemplateAssetPaths.Variables.Scene.Has, SubFolderPaths.Variables.Scene.Has, TypeIdentifiers.Variables.Scene.Has, FileNameSuffixes.NewFileSuffix, true);

        /// <summary>
        /// Creates a Scene Set Variable script graph.
        /// </summary>
        [MenuItem(MenuItemPaths.Variables.Scene.Set)]
        public static void CreateSceneSet() => CreateVisualScriptingAsset(TemplateAssetPaths.Variables.Scene.Set, SubFolderPaths.Variables.Scene.Set, TypeIdentifiers.Variables.Scene.Set, FileNameSuffixes.NewFileSuffix, true);
    }
}
