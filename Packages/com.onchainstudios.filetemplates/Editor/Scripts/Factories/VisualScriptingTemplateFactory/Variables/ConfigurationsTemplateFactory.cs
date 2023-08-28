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
                /// Type identifiers for all Configurations.
                /// </summary>
                public static class Configurations
                {
                    /// <summary>
                    /// Type identifier for a Configuration script graph.
                    /// </summary>
                    public const string Configuration = nameof(Configuration);
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
                public static class Configurations
                {
                    /// <summary>
                    /// File name for the Configuration template.
                    /// </summary>
                    public static string Configuration => FileTemplateHelper.GetProjectRelativeFilePath(TypeIdentifiers.Variables.Configurations.Configuration + _fileNameSuffix);
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
                /// Menu item paths for all constants.
                /// </summary>
                public static class Configurations
                {
                    /// <summary>
                    /// Base path for configuration script graphs.
                    /// </summary>
                    private const string _configurationVariablesBasePath = _variablesBasePath + nameof(Configurations) + _delimiter;

                    /// <summary>
                    /// Menu item path to create a new Float script graph.
                    /// </summary>
                    public const string Configuration = _configurationVariablesBasePath + nameof(Configuration);
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
                public static class Configurations
                {
                    /// <summary>
                    /// Name of the subfolder for Configurations script graphs.
                    /// </summary>
                    private static string _configurationVariablesBasePath => Path.Combine(nameof(Variables), nameof(Configurations));

                    /// <summary>
                    /// Name of the subfolder for Configuration script graphs.
                    /// </summary>
                    public static string Configuration => _configurationVariablesBasePath;
                }
            }
        }

        /// <summary>
        /// Creates a Float script graph.
        /// </summary>
        [MenuItem(MenuItemPaths.Variables.Configurations.Configuration)]
        public static void CreateConfiguration() => CreateVisualScriptingAsset(TemplateAssetPaths.Variables.Configurations.Configuration, SubFolderPaths.Variables.Configurations.Configuration, TypeIdentifiers.Variables.Configurations.Configuration, FileNameSuffixes.NewFileSuffix);
    }
}
