//*****************************************************************************
// Author: Arthur LeVesque
// Copyright: OnChain Studios, 2023
//*****************************************************************************

namespace OnChainStudios.FileTemplates
{
    using UnityEditor;
    using System.IO;

    //xml documentation in the file VisualScriptingTemplateFactory.
    public static partial class VisualScriptingTemplateFactory
    {
        //xml documentation in the file VisualScriptingTemplateFactory.
        public static partial class TypeIdentifiers
        {
            /// <summary>
            /// Type identifiers for all variables.
            /// </summary>
            public static partial class Variables
            {
                /// <summary>
                /// Type identifiers for all constants.
                /// </summary>
                public static class Constants
                {
                    /// <summary>
                    /// Type identifier for a <see cref="float"/> script graph.
                    /// </summary>
                    public const string Float = nameof(Float);

                    /// <summary>
                    /// Type identifier for a <see cref="int"/> script graph.
                    /// </summary>
                    public const string Int = nameof(Int);

                    /// <summary>
                    /// Type identifier for a <see cref="string"/> script graph.
                    /// </summary>
                    public const string String = nameof(String);

                    /// <summary>
                    /// Type identifier for a <see cref="UnityEngine.Vector2"/> script graph.
                    /// </summary>
                    public const string Vector2 = nameof(Vector2);

                    /// <summary>
                    /// Type identifier for a <see cref="UnityEngine.Vector3"/> script graph.
                    /// </summary>
                    public const string Vector3 = nameof(Vector3);

                    /// <summary>
                    /// Type identifier for a LayerIndex script graph.
                    /// </summary>
                    public const string LayerIndex = nameof(LayerIndex);

                    /// <summary>
                    /// Type identifier for a Tag script graph.
                    /// </summary>
                    public const string Tag = nameof(Tag);
                }
            }
        }

        //xml documentation in the file VisualScriptingTemplateFactory.
        public static partial class TemplateAssetPaths
        {
            /// <summary>
            /// Template asset paths for all variables.
            /// </summary>
            public static partial class Variables
            {
                /// <summary>
                /// Template asset paths for all constants.
                /// </summary>
                public static class Constants
                {
                    /// <summary>
                    /// File name for the Float template.
                    /// </summary>
                    public static string Float => FileTemplateHelper.GetProjectRelativeFilePath(TypeIdentifiers.Variables.Constants.Float + _fileNameSuffix);

                    /// <summary>
                    /// File name for the Int template.
                    /// </summary>
                    public static string Int => FileTemplateHelper.GetProjectRelativeFilePath(TypeIdentifiers.Variables.Constants.Int + _fileNameSuffix);

                    /// <summary>
                    /// File name for the String template.
                    /// </summary>
                    public static string String => FileTemplateHelper.GetProjectRelativeFilePath(TypeIdentifiers.Variables.Constants.String + _fileNameSuffix);

                    /// <summary>
                    /// File name for the Vector2 template.
                    /// </summary>
                    public static string Vector2 => FileTemplateHelper.GetProjectRelativeFilePath(TypeIdentifiers.Variables.Constants.Vector2 + _fileNameSuffix);

                    /// <summary>
                    /// File name for the Vector3 template.
                    /// </summary>
                    public static string Vector3 => FileTemplateHelper.GetProjectRelativeFilePath(TypeIdentifiers.Variables.Constants.Vector3 + _fileNameSuffix);

                    /// <summary>
                    /// File name for the LayerIndex template.
                    /// </summary>
                    public static string LayerIndex => FileTemplateHelper.GetProjectRelativeFilePath(TypeIdentifiers.Variables.Constants.LayerIndex + _fileNameSuffix);

                    /// <summary>
                    /// File name for the Tag template.
                    /// </summary>
                    public static string Tag => FileTemplateHelper.GetProjectRelativeFilePath(TypeIdentifiers.Variables.Constants.Tag + _fileNameSuffix);
                }
            }
        }

        //xml documentation in the file VisualScriptingTemplateFactory.
        public static partial class MenuItemPaths
        {
            /// <summary>
            /// Menu item paths for all variables.
            /// </summary>
            public static partial class Variables
            {
                /// <summary>
                /// Base path for all variables.
                /// </summary>
                private const string _variablesBasePath = _basePath + nameof(Variables) + _delimiter;

                /// <summary>
                /// Menu item paths for all constants.
                /// </summary>
                public static class Constants
                {
                    /// <summary>
                    /// Base path for constant script graphs.
                    /// </summary>
                    private const string _constantVariablesBasePath = _variablesBasePath + nameof(Constants) + _delimiter;

                    /// <summary>
                    /// Menu item path to create a new Float script graph.
                    /// </summary>
                    public const string Float = _constantVariablesBasePath + nameof(Float);

                    /// <summary>
                    /// Menu item path to create a new Int script graph.
                    /// </summary>
                    public const string Int = _constantVariablesBasePath + nameof(Int);

                    /// <summary>
                    /// Menu item path to create a new Vector2 script graph.
                    /// </summary>
                    public const string Vector2 = _constantVariablesBasePath + nameof(Vector2);

                    /// <summary>
                    /// Menu item path to create a new String script graph.
                    /// </summary>
                    public const string String = _constantVariablesBasePath + nameof(String);

                    /// <summary>
                    /// Menu item path to create a new Vector3 script graph.
                    /// </summary>
                    public const string Vector3 = _constantVariablesBasePath + nameof(Vector3);

                    /// <summary>
                    /// Menu item path to create a new LayerIndex script graph.
                    /// </summary>
                    public const string LayerIndex = _constantVariablesBasePath + nameof(LayerIndex);

                    /// <summary>
                    /// Menu item path to create a new Tag script graph.
                    /// </summary>
                    public const string Tag = _constantVariablesBasePath + nameof(Tag);
                }
            }
        }

        //xml documentation in the file VisualScriptingTemplateFactory.
        public static partial class SubFolderPaths
        {
            /// <summary>
            /// Sub folder paths for all variables.
            /// </summary>
            public static partial class Variables
            {
                /// <summary>
                /// Sub folder paths for all constants.
                /// </summary>
                public static class Constants
                {
                    /// <summary>
                    /// Name of the subfolder for Constants script graphs.
                    /// </summary>
                    private static string _constantVariablesBasePath => Path.Combine(nameof(Variables), nameof(Constants));

                    /// <summary>
                    /// Name of the subfolder for Float script graphs.
                    /// </summary>
                    public static string Floats => Path.Combine(_constantVariablesBasePath, nameof(Floats));

                    /// <summary>
                    /// Name of the subfolder for Int script graphs.
                    /// </summary>
                    public static string Ints => Path.Combine(_constantVariablesBasePath, nameof(Ints));

                    /// <summary>
                    /// Name of the subfolder for String script graphs.
                    /// </summary>
                    public static string Strings => Path.Combine(_constantVariablesBasePath, nameof(Strings));

                    /// <summary>
                    /// Name of the subfolder for Vector2 script graphs.
                    /// </summary>
                    public static string Vector2s => Path.Combine(_constantVariablesBasePath, nameof(Vector2s));

                    /// <summary>
                    /// Name of the subfolder for Vector3 script graphs.
                    /// </summary>
                    public static string Vector3s => Path.Combine(_constantVariablesBasePath, nameof(Vector3s));

                    /// <summary>
                    /// Name of the subfolder for LayerIndices script graphs.
                    /// </summary>
                    public static string LayerIndices => Path.Combine(_constantVariablesBasePath, nameof(LayerIndices));

                    /// <summary>
                    /// Name of the subfolder for Tags script graphs.
                    /// </summary>
                    public static string Tags => Path.Combine(_constantVariablesBasePath, nameof(Tags));
                }
            }
        }

        /// <summary>
        /// Creates a Float script graph.
        /// </summary>
        [MenuItem(MenuItemPaths.Variables.Constants.Float)]
        public static void CreateFloat() => CreateVisualScriptingAsset(TemplateAssetPaths.Variables.Constants.Float, SubFolderPaths.Variables.Constants.Floats, TypeIdentifiers.Variables.Constants.Float, FileNameSuffixes.NewFileSuffix);

        /// <summary>
        /// Creates a Int script graph.
        /// </summary>
        [MenuItem(MenuItemPaths.Variables.Constants.Int)]
        public static void CreateInt() => CreateVisualScriptingAsset(TemplateAssetPaths.Variables.Constants.Int, SubFolderPaths.Variables.Constants.Ints, TypeIdentifiers.Variables.Constants.Int, FileNameSuffixes.NewFileSuffix);

        /// <summary>
        /// Creates a String script graph.
        /// </summary>
        [MenuItem(MenuItemPaths.Variables.Constants.String)]
        public static void CreateString() => CreateVisualScriptingAsset(TemplateAssetPaths.Variables.Constants.String, SubFolderPaths.Variables.Constants.Strings, TypeIdentifiers.Variables.Constants.String, FileNameSuffixes.NewFileSuffix);

        /// <summary>
        /// Creates a Vector2 script graph.
        /// </summary>
        [MenuItem(MenuItemPaths.Variables.Constants.Vector2)]
        public static void CreateVector2() => CreateVisualScriptingAsset(TemplateAssetPaths.Variables.Constants.Vector2, SubFolderPaths.Variables.Constants.Vector2s, TypeIdentifiers.Variables.Constants.Vector2, FileNameSuffixes.NewFileSuffix);

        /// <summary>
        /// Creates a Vector3 script graph.
        /// </summary>
        [MenuItem(MenuItemPaths.Variables.Constants.Vector3)]
        public static void CreateVector3() => CreateVisualScriptingAsset(TemplateAssetPaths.Variables.Constants.Vector3, SubFolderPaths.Variables.Constants.Vector3s, TypeIdentifiers.Variables.Constants.Vector3, FileNameSuffixes.NewFileSuffix);

        /// <summary>
        /// Creates a LayerIndex script graph.
        /// </summary>
        [MenuItem(MenuItemPaths.Variables.Constants.LayerIndex)]
        public static void CreateLayerIndex() => CreateVisualScriptingAsset(TemplateAssetPaths.Variables.Constants.LayerIndex, SubFolderPaths.Variables.Constants.LayerIndices, TypeIdentifiers.Variables.Constants.LayerIndex, FileNameSuffixes.NewFileSuffix);

        /// <summary>
        /// Creates a Tag script graph.
        /// </summary>
        [MenuItem(MenuItemPaths.Variables.Constants.Tag)]
        public static void CreateTag() => CreateVisualScriptingAsset(TemplateAssetPaths.Variables.Constants.Tag, SubFolderPaths.Variables.Constants.Tags, TypeIdentifiers.Variables.Constants.Tag, FileNameSuffixes.NewFileSuffix);
    }
}
