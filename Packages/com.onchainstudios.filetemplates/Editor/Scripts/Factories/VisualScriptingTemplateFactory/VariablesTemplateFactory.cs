//*****************************************************************************
// Author: Arthur LeVesque
// Copyright: OnChain Studios, 2023
//*****************************************************************************

namespace OnChainStudios.FileTemplates
{
    using UnityEditor;
    using System.IO;
    
    ///xml documentation in the main <see cref="VisualScriptingTemplateFactory"/> file.
    public partial class VisualScriptingTemplateFactory
    {
        ///xml documentation in the main <see cref="VisualScriptingTemplateFactory"/> file.
        public partial class FileNameSuffixes
        {
            /// <summary>
            /// File name suffixes for all variables.
            /// </summary>
            public partial class Variables
            {
                /// <summary>
                /// File suffix for object variable variables.
                /// </summary>
                public static string Object => _delimiter + "[TargetGameObjectName]" + NewFileSuffix;
            }
        }
        
        ///xml documentation in the main <see cref="VisualScriptingTemplateFactory"/> file.
        public partial class TypeIdentifiers
        {
            /// <summary>
            /// Type Identifiers for all variables.
            /// </summary>
            public partial class Variables
            {
                /// <summary>
                /// Type identifiers for all object variables.
                /// </summary>
                public class Object
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
                }
            }
        }

        ///xml documentation in the main <see cref="VisualScriptingTemplateFactory"/> file.
        public partial class TemplateAssetPaths
        {
            /// <summary>
            /// Type Identifiers for all variables.
            /// </summary>
            public partial class Variables
            {
                /// <summary>
                /// Asset paths for object variables.
                /// </summary>
                public class Object
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
                }
            }
        }

        ///xml documentation in the main <see cref="VisualScriptingTemplateFactory"/> file.
        public partial class MenuItemPaths
        {
            /// <summary>
            /// Menu Item Paths for Variables.
            /// </summary>
            public partial class Variables
            {
                /// <summary>
                /// Base path for all variables.
                /// </summary>
                private const string _variablesBasePath = _basePath + nameof(Variables) + _delimiter;
                
                /// <summary>
                /// Menu Item Paths for Object Variables.
                /// </summary>
                public class Object
                {
                    /// <summary>
                    /// Base path for all object variables.
                    /// </summary>
                    private const string _objectBasePath = _variablesBasePath + nameof(Object) + _delimiter;
                    
                    /// <summary>
                    /// Menu Item Path for a object get variable.
                    /// </summary>
                    public const string Get = _objectBasePath + nameof(Get);
                    
                    /// <summary>
                    /// Menu Item Path for a object has variable.
                    /// </summary>
                    public const string Has = _objectBasePath + nameof(Has);
                    
                    /// <summary>
                    /// Menu Item Path for a object has variable.
                    /// </summary>
                    public const string Set = _objectBasePath + nameof(Set);
                }
            }
        }

        ///xml documentation in the main <see cref="VisualScriptingTemplateFactory"/> file.
        public partial class SubFolderPaths
        {
            /// <summary>
            /// Sub folder paths for all variables.
            /// </summary>
            public partial class Variables
            {
                /// <summary>
                /// Sub folder paths for all object variables.
                /// </summary>
                public class Object
                {
                    /// <summary>
                    /// Base subfolder path for object variables.
                    /// </summary>
                    private static string _objectVariablesBasePath = Path.Combine(nameof(Variables), nameof(Object));
                    
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
                }
            }
        }

        /// <summary>
        /// Creates a Object Get Variable script graph.
        /// </summary>
        [MenuItem(MenuItemPaths.Variables.Object.Get)]
        public static void CreateObjectGet() => CreateVisualScriptingAsset(TemplateAssetPaths.Variables.Object.Get, SubFolderPaths.Variables.Object.Get, TypeIdentifiers.Variables.Object.Get, FileNameSuffixes.Variables.Object, true);

        /// <summary>
        /// Creates a Object Has Variable script graph.
        /// </summary>
        [MenuItem(MenuItemPaths.Variables.Object.Has)]
        public static void CreateObjectHas() => CreateVisualScriptingAsset(TemplateAssetPaths.Variables.Object.Has, SubFolderPaths.Variables.Object.Has, TypeIdentifiers.Variables.Object.Has, FileNameSuffixes.Variables.Object, true);

        /// <summary>
        /// Creates a Object Set Variable script graph.
        /// </summary>
        [MenuItem(MenuItemPaths.Variables.Object.Set)]
        public static void CreateObjectSet() => CreateVisualScriptingAsset(TemplateAssetPaths.Variables.Object.Set, SubFolderPaths.Variables.Object.Set, TypeIdentifiers.Variables.Object.Set, FileNameSuffixes.Variables.Object, true);
    }
}
