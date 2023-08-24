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
                /// Type identifiers for all Application variables.
                /// </summary>
                public static class Application
                {
                    /// <summary>
                    /// Type identifier for a Application get script graph.
                    /// </summary>
                    public const string Get = nameof(Application) + _delimiter + nameof(Get);

                    /// <summary>
                    /// Type identifier for a Application has script graph.
                    /// </summary>
                    public const string Has = nameof(Application) + _delimiter + nameof(Has);

                    /// <summary>
                    /// Type identifier for a Application set script graph.
                    /// </summary>
                    public const string Set = nameof(Application) + _delimiter + nameof(Set);

                    /// <summary>
                    /// Type identifier for a Application VariableName script graph.
                    /// </summary>
                    public const string VariableName = nameof(Application) + _delimiter + nameof(VariableName);
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
                /// Template asset paths for all Application variables.
                /// </summary>
                public static class Application
                {
                    /// <summary>
                    /// File name for the Application get template.
                    /// </summary>
                    public static string Get => FileTemplateHelper.GetProjectRelativeFilePath(TypeIdentifiers.Variables.Application.Get + _fileNameSuffix);

                    /// <summary>
                    /// File name for the Application has template.
                    /// </summary>
                    public static string Has => FileTemplateHelper.GetProjectRelativeFilePath(TypeIdentifiers.Variables.Application.Has + _fileNameSuffix);

                    /// <summary>
                    /// File name for the Application set template.
                    /// </summary>
                    public static string Set => FileTemplateHelper.GetProjectRelativeFilePath(TypeIdentifiers.Variables.Application.Set + _fileNameSuffix);

                    /// <summary>
                    /// File name for the Application set template.
                    /// </summary>
                    public static string VariableName => FileTemplateHelper.GetProjectRelativeFilePath(TypeIdentifiers.Variables.Application.VariableName + _fileNameSuffix);
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
                /// Menu Item Paths for Application Variables.
                /// </summary>
                public static class Application
                {
                    /// <summary>
                    /// Base path for all Application variables.
                    /// </summary>
                    private const string _applicationVariablesBasePath = _variablesBasePath + nameof(Application) + _delimiter;

                    /// <summary>
                    /// Menu Item Path for a Application get variable.
                    /// </summary>
                    public const string Get = _applicationVariablesBasePath + nameof(Get);

                    /// <summary>
                    /// Menu Item Path for a Application has variable.
                    /// </summary>
                    public const string Has = _applicationVariablesBasePath + nameof(Has);

                    /// <summary>
                    /// Menu Item Path for a Application has variable.
                    /// </summary>
                    public const string Set = _applicationVariablesBasePath + nameof(Set);

                    /// <summary>
                    /// Menu Item Path for a Application VariableName variable.
                    /// </summary>
                    public const string VariableName = _applicationVariablesBasePath + nameof(VariableName);
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
                /// Sub folder paths for all Application variables.
                /// </summary>
                public static class Application
                {
                    /// <summary>
                    /// Base subfolder path for Application variables.
                    /// </summary>
                    private static string _applicationVariablesBasePath => Path.Combine(nameof(Variables), nameof(Application));

                    /// <summary>
                    /// Sub folder path for Application get.
                    /// </summary>
                    public static string Get => Path.Combine(_applicationVariablesBasePath, nameof(Get));

                    /// <summary>
                    /// Sub Folder path for Application has.
                    /// </summary>
                    public static string Has => Path.Combine(_applicationVariablesBasePath, nameof(Has));

                    /// <summary>
                    /// Sub folder path for Application set.
                    /// </summary>
                    public static string Set => Path.Combine(_applicationVariablesBasePath, nameof(Set));

                    /// <summary>
                    /// Sub folder path for Application set.
                    /// </summary>
                    public static string VariableName => Path.Combine(_applicationVariablesBasePath, nameof(VariableName));
                }
            }
        }

        /// <summary>
        /// Creates a Application Get Variable script graph.
        /// </summary>
        [MenuItem(MenuItemPaths.Variables.Application.Get)]
        public static void CreateApplicationGet() => CreateVisualScriptingAsset(TemplateAssetPaths.Variables.Application.Get, SubFolderPaths.Variables.Application.Get, TypeIdentifiers.Variables.Application.Get, FileNameSuffixes.NewFileSuffix);

        /// <summary>
        /// Creates a Application Has Variable script graph.
        /// </summary>
        [MenuItem(MenuItemPaths.Variables.Application.Has)]
        public static void CreateApplicationHas() => CreateVisualScriptingAsset(TemplateAssetPaths.Variables.Application.Has, SubFolderPaths.Variables.Application.Has, TypeIdentifiers.Variables.Application.Has, FileNameSuffixes.NewFileSuffix);

        /// <summary>
        /// Creates a Application Set Variable script graph.
        /// </summary>
        [MenuItem(MenuItemPaths.Variables.Application.Set)]
        public static void CreateApplicationSet() => CreateVisualScriptingAsset(TemplateAssetPaths.Variables.Application.Set, SubFolderPaths.Variables.Application.Set, TypeIdentifiers.Variables.Application.Set, FileNameSuffixes.NewFileSuffix);

        /// <summary>
        /// Creates a Application VariableName Variable script graph.
        /// </summary>
        [MenuItem(MenuItemPaths.Variables.Application.VariableName)]
        public static void CreateApplicationVariableName() => CreateVisualScriptingAsset(TemplateAssetPaths.Variables.Application.VariableName, SubFolderPaths.Variables.Application.VariableName, TypeIdentifiers.Variables.Application.VariableName, FileNameSuffixes.NewFileSuffix);
    }
}
