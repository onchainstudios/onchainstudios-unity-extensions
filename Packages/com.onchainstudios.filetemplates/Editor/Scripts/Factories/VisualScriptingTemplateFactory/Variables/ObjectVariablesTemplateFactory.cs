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
                /// Type identifiers for all object variables.
                /// </summary>
                public static class Object
                {
                    /// <summary>
                    /// Type identifier for a object get script graph.
                    /// </summary>
                    public const string Get = nameof(Object) + _delimiter + nameof(Get);

                    /// <summary>
                    /// Type identifier for a object has script graph.
                    /// </summary>
                    public const string Has = nameof(Object) + _delimiter + nameof(Has);

                    /// <summary>
                    /// Type identifier for a object set script graph.
                    /// </summary>
                    public const string Set = nameof(Object) + _delimiter + nameof(Set);

                    /// <summary>
                    /// Type identifier for a object VariableName script graph.
                    /// </summary>
                    public const string VariableName = nameof(Object) + _delimiter + nameof(VariableName);
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
                /// Template asset paths for all object variables.
                /// </summary>
                public static class Object
                {
                    /// <summary>
                    /// File name for the object get template.
                    /// </summary>
                    public static string Get => FileTemplateHelper.GetProjectRelativeFilePath(TypeIdentifiers.Variables.Object.Get + _fileNameSuffix);

                    /// <summary>
                    /// File name for the object has template.
                    /// </summary>
                    public static string Has => FileTemplateHelper.GetProjectRelativeFilePath(TypeIdentifiers.Variables.Object.Has + _fileNameSuffix);

                    /// <summary>
                    /// File name for the object set template.
                    /// </summary>
                    public static string Set => FileTemplateHelper.GetProjectRelativeFilePath(TypeIdentifiers.Variables.Object.Set + _fileNameSuffix);

                    /// <summary>
                    /// File name for the object VariableName template.
                    /// </summary>
                    public static string VariableName => FileTemplateHelper.GetProjectRelativeFilePath(TypeIdentifiers.Variables.Object.VariableName + _fileNameSuffix);
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
                /// Menu Item Paths for Object Variables.
                /// </summary>
                public static class Object
                {
                    /// <summary>
                    /// Base path for all object variables.
                    /// </summary>
                    private const string _objectVariablesBasePath = _variablesBasePath + nameof(Object) + _delimiter;

                    /// <summary>
                    /// Menu Item Path for a object get variable.
                    /// </summary>
                    public const string Get = _objectVariablesBasePath + nameof(Get);

                    /// <summary>
                    /// Menu Item Path for a object has variable.
                    /// </summary>
                    public const string Has = _objectVariablesBasePath + nameof(Has);

                    /// <summary>
                    /// Menu Item Path for a object has variable.
                    /// </summary>
                    public const string Set = _objectVariablesBasePath + nameof(Set);

                    /// <summary>
                    /// Menu Item Path for a object VariableName variable.
                    /// </summary>
                    public const string VariableName = _objectVariablesBasePath + nameof(VariableName);
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
                /// Sub folder paths for all object variables.
                /// </summary>
                public static class Object
                {
                    /// <summary>
                    /// Base subfolder path for object variables.
                    /// </summary>
                    private static string _objectVariablesBasePath => Path.Combine(nameof(Variables), nameof(Object));

                    /// <summary>
                    /// Sub folder path for object get.
                    /// </summary>
                    public static string Get => Path.Combine(_objectVariablesBasePath, nameof(Get));

                    /// <summary>
                    /// Sub Folder path for object has.
                    /// </summary>
                    public static string Has => Path.Combine(_objectVariablesBasePath, nameof(Has));

                    /// <summary>
                    /// Sub folder path for object set.
                    /// </summary>
                    public static string Set => Path.Combine(_objectVariablesBasePath, nameof(Set));

                    /// <summary>
                    /// Sub folder path for object VariableName.
                    /// </summary>
                    public static string VariableName => Path.Combine(_objectVariablesBasePath, nameof(VariableName));
                }
            }
        }

        /// <summary>
        /// Creates a Object Get Variable script graph.
        /// </summary>
        [MenuItem(MenuItemPaths.Variables.Object.Get)]
        public static void CreateObjectGet() => CreateVisualScriptingAsset(TemplateAssetPaths.Variables.Object.Get, SubFolderPaths.Variables.Object.Get, TypeIdentifiers.Variables.Object.Get, FileNameSuffixes.NewFileSuffix);

        /// <summary>
        /// Creates a Object Has Variable script graph.
        /// </summary>
        [MenuItem(MenuItemPaths.Variables.Object.Has)]
        public static void CreateObjectHas() => CreateVisualScriptingAsset(TemplateAssetPaths.Variables.Object.Has, SubFolderPaths.Variables.Object.Has, TypeIdentifiers.Variables.Object.Has, FileNameSuffixes.NewFileSuffix);

        /// <summary>
        /// Creates a Object Set Variable script graph.
        /// </summary>
        [MenuItem(MenuItemPaths.Variables.Object.Set)]
        public static void CreateObjectSet() => CreateVisualScriptingAsset(TemplateAssetPaths.Variables.Object.Set, SubFolderPaths.Variables.Object.Set, TypeIdentifiers.Variables.Object.Set, FileNameSuffixes.NewFileSuffix);

        /// <summary>
        /// Creates a Object VariableName Variable script graph.
        /// </summary>
        [MenuItem(MenuItemPaths.Variables.Object.VariableName)]
        public static void CreateObjectVariableName() => CreateVisualScriptingAsset(TemplateAssetPaths.Variables.Object.VariableName, SubFolderPaths.Variables.Object.VariableName, TypeIdentifiers.Variables.Object.VariableName, FileNameSuffixes.NewFileSuffix);
    }
}
