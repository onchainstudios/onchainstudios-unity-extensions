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
            /// File suffix for a object variable.
            /// </summary>
            public static string ObjectVariable => "[TargetGameObjectName]" + _delimiter + NewFileSuffix;
        }
        
        ///xml documentation in the main <see cref="VisualScriptingTemplateFactory"/> file.
        public partial class TypeIdentifiers
        {
            private const string Object = nameof(Object);
            
            private const string Get = nameof(Get);
            private const string Has = nameof(Has);


            private const string Set = nameof(Set);
            
            /// <summary>
            /// Type identifier for a object style script graph.
            /// </summary>
            public const string ObjectGet = Object + _delimiter + nameof(Get);
            /// <summary>
            /// Type identifier for a object style script graph.
            /// </summary>
            public const string ObjectHas = Object + _delimiter + nameof(Has);

            /// <summary>
            /// Type identifier for a object style script graph.
            /// </summary>
            public const string ObjectSet = Object + _delimiter + nameof(Set);
            

        }

        ///xml documentation in the main <see cref="VisualScriptingTemplateFactory"/> file.
        public partial class TemplateAssetPaths
        {
            /// <summary>
            /// File name for the behavior template.
            /// </summary>
            public static string ObjectGet => FileTemplateHelper.GetProjectRelativeFilePath(TypeIdentifiers.ObjectGet + _fileNameSuffix);
            
            /// <summary>
            /// File name for the behavior template.
            /// </summary>
            public static string ObjectHas => FileTemplateHelper.GetProjectRelativeFilePath(TypeIdentifiers.ObjectHas + _fileNameSuffix);
            
            /// <summary>
            /// File name for the behavior template.
            /// </summary>
            public static string ObjectSet => FileTemplateHelper.GetProjectRelativeFilePath(TypeIdentifiers.ObjectSet + _fileNameSuffix);
        }

        ///xml documentation in the main <see cref="VisualScriptingTemplateFactory"/> file.
        public partial class MenuItemPaths
        {
            /// <summary>
            /// Base path for Object script graphs.
            /// </summary>
            private const string Object = nameof(Object) + _delimiter;

            private const string Variables = _basePath + nameof(Variables);
            
            private const string Get = nameof(Get);
            private const string Has = nameof(Has);


            private const string Set = nameof(Set);


            /// <summary>
            /// Menu item path to create a new behaviour script graph.
            /// </summary>
            public const string ObjectGet = Variables + _delimiter + Object + _delimiter  + Get;
            
            
            /// <summary>
            /// Menu item path to create a new behaviour script graph.
            /// </summary>
            public const string ObjectHas = Variables + _delimiter + Object + _delimiter  + Has;
            
            
            /// <summary>
            /// Menu item path to create a new behaviour script graph.
            /// </summary>
            public const string ObjectSet = Variables + _delimiter + Object + _delimiter  + Set;
        }

        ///xml documentation in the main <see cref="VisualScriptingTemplateFactory"/> file.
        public partial class SubFolderPaths
        {
            /// <summary>
            /// Name of the subfolder for behaviour script graphs.
            /// </summary>
            public static string Object => Path.Combine(Variables, nameof(Object));
        }
        
        [MenuItem(MenuItemPaths.ObjectGet)]
        public static void CreateObjectGet() => CreateVisualScriptingAsset(TemplateAssetPaths.ObjectGet, SubFolderPaths.Object, TypeIdentifiers.ObjectGet, FileNameSuffixes.ObjectVariable, true);
        
                
        [MenuItem(MenuItemPaths.ObjectHas)]
        public static void CreateObjectHas() => CreateVisualScriptingAsset(TemplateAssetPaths.ObjectHas, SubFolderPaths.Object, TypeIdentifiers.ObjectHas, FileNameSuffixes.ObjectVariable, true);
        
                
        [MenuItem(MenuItemPaths.ObjectSet)]
        public static void CreateObjectSet() => CreateVisualScriptingAsset(TemplateAssetPaths.ObjectSet, SubFolderPaths.Object, TypeIdentifiers.ObjectSet, FileNameSuffixes.ObjectVariable, true);
    }
}
