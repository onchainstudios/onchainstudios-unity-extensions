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
                /// Type identifiers for all Saved variables.
                /// </summary>
                public static class Saved
                {
                    /// <summary>
                    /// Type identifier for a Saved get script graph.
                    /// </summary>
                    public const string Get = nameof(Saved) + _delimiter + nameof(Get);

                    /// <summary>
                    /// Type identifier for a Saved has script graph.
                    /// </summary>
                    public const string Has = nameof(Saved) + _delimiter + nameof(Has);

                    /// <summary>
                    /// Type identifier for a Saved set script graph.
                    /// </summary>
                    public const string Set = nameof(Saved) + _delimiter + nameof(Set);

                    /// <summary>
                    /// Type identifier for a Saved VariableName script graph.
                    /// </summary>
                    public const string VariableName = nameof(Saved) + _delimiter + nameof(VariableName);
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
                /// Template asset paths for all Saved variables.
                /// </summary>
                public static class Saved
                {
                    /// <summary>
                    /// File name for the Saved get template.
                    /// </summary>
                    public static string Get => FileTemplateHelper.GetProjectRelativeFilePath(TypeIdentifiers.Variables.Saved.Get + _fileNameSuffix);

                    /// <summary>
                    /// File name for the Saved has template.
                    /// </summary>
                    public static string Has => FileTemplateHelper.GetProjectRelativeFilePath(TypeIdentifiers.Variables.Saved.Has + _fileNameSuffix);

                    /// <summary>
                    /// File name for the Saved set template.
                    /// </summary>
                    public static string Set => FileTemplateHelper.GetProjectRelativeFilePath(TypeIdentifiers.Variables.Saved.Set + _fileNameSuffix);

                    /// <summary>
                    /// File name for the Saved VariableName template.
                    /// </summary>
                    public static string VariableName => FileTemplateHelper.GetProjectRelativeFilePath(TypeIdentifiers.Variables.Saved.VariableName + _fileNameSuffix);
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
                /// Menu Item Paths for Saved Variables.
                /// </summary>
                public static class Saved
                {
                    /// <summary>
                    /// Base path for all Saved variables.
                    /// </summary>
                    private const string _savedBasePath = _variablesBasePath + nameof(Saved) + _delimiter;

                    /// <summary>
                    /// Menu Item Path for a Saved get variable.
                    /// </summary>
                    public const string Get = _savedBasePath + nameof(Get);

                    /// <summary>
                    /// Menu Item Path for a Saved has variable.
                    /// </summary>
                    public const string Has = _savedBasePath + nameof(Has);

                    /// <summary>
                    /// Menu Item Path for a Saved has variable.
                    /// </summary>
                    public const string Set = _savedBasePath + nameof(Set);

                    /// <summary>
                    /// Menu Item Path for a Saved VariableName variable.
                    /// </summary>
                    public const string VariableName = _savedBasePath + nameof(VariableName);
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
                /// Sub folder paths for all Saved variables.
                /// </summary>
                public static class Saved
                {
                    /// <summary>
                    /// Base subfolder path for Saved variables.
                    /// </summary>
                    private static string _savedVariablesBasePath => Path.Combine(nameof(Variables), nameof(Saved));

                    /// <summary>
                    /// Sub folder path for Saved get.
                    /// </summary>
                    public static string Get => Path.Combine(_savedVariablesBasePath, nameof(Get));

                    /// <summary>
                    /// Sub Folder path for Saved has.
                    /// </summary>
                    public static string Has => Path.Combine(_savedVariablesBasePath, nameof(Has));

                    /// <summary>
                    /// Sub folder path for Saved set.
                    /// </summary>
                    public static string Set => Path.Combine(_savedVariablesBasePath, nameof(Set));

                    /// <summary>
                    /// Sub folder path for Saved VariableName.
                    /// </summary>
                    public static string VariableName => Path.Combine(_savedVariablesBasePath, nameof(VariableName));
                }
            }
        }

        /// <summary>
        /// Creates a Saved Get Variable script graph.
        /// </summary>
        [MenuItem(MenuItemPaths.Variables.Saved.Get)]
        public static void CreateSavedGet() => CreateVisualScriptingAsset(TemplateAssetPaths.Variables.Saved.Get, SubFolderPaths.Variables.Saved.Get, TypeIdentifiers.Variables.Saved.Get, FileNameSuffixes.NewFileSuffix, true);

        /// <summary>
        /// Creates a Saved Has Variable script graph.
        /// </summary>
        [MenuItem(MenuItemPaths.Variables.Saved.Has)]
        public static void CreateSavedHas() => CreateVisualScriptingAsset(TemplateAssetPaths.Variables.Saved.Has, SubFolderPaths.Variables.Saved.Has, TypeIdentifiers.Variables.Saved.Has, FileNameSuffixes.NewFileSuffix, true);

        /// <summary>
        /// Creates a Saved Set Variable script graph.
        /// </summary>
        [MenuItem(MenuItemPaths.Variables.Saved.Set)]
        public static void CreateSavedSet() => CreateVisualScriptingAsset(TemplateAssetPaths.Variables.Saved.Set, SubFolderPaths.Variables.Saved.Set, TypeIdentifiers.Variables.Saved.Set, FileNameSuffixes.NewFileSuffix, true);

        /// <summary>
        /// Creates a Saved Set Variable script graph.
        /// </summary>
        [MenuItem(MenuItemPaths.Variables.Saved.VariableName)]
        public static void CreateSavedVariableName() => CreateVisualScriptingAsset(TemplateAssetPaths.Variables.Saved.VariableName, SubFolderPaths.Variables.Saved.VariableName, TypeIdentifiers.Variables.Saved.VariableName, FileNameSuffixes.NewFileSuffix, true);
    }
}
