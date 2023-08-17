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
        public partial class TypeIdentifiers
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
        }

        ///xml documentation in the main <see cref="VisualScriptingTemplateFactory"/> file.
        public partial class TemplateAssetPaths
        {
            /// <summary>
            /// File name for the Float template.
            /// </summary>
            public static string Float => FileTemplateHelper.GetProjectRelativeFilePath(TypeIdentifiers.Float + _fileNameSuffix);
            
            /// <summary>
            /// File name for the Int template.
            /// </summary>
            public static string Int => FileTemplateHelper.GetProjectRelativeFilePath(TypeIdentifiers.Int + _fileNameSuffix);
            
            /// <summary>
            /// File name for the String template.
            /// </summary>
            public static string String => FileTemplateHelper.GetProjectRelativeFilePath(TypeIdentifiers.String + _fileNameSuffix);
            
            /// <summary>
            /// File name for the Vector2 template.
            /// </summary>
            public static string Vector2 => FileTemplateHelper.GetProjectRelativeFilePath(TypeIdentifiers.Vector2 + _fileNameSuffix);
            
            /// <summary>
            /// File name for the Vector3 template.
            /// </summary>
            public static string Vector3 => FileTemplateHelper.GetProjectRelativeFilePath(TypeIdentifiers.Vector3 + _fileNameSuffix);
        }
        
        ///xml documentation in the main <see cref="VisualScriptingTemplateFactory"/> file.
        public partial class MenuItemPaths
        {
            /// <summary>
            /// Base path for behaviour script graphs.
            /// </summary>
            public const string Constants = Variables + _delimiter + nameof(Constants) + _delimiter;

            /// <summary>
            /// Menu item path to create a new Float script graph.
            /// </summary>
            public const string Float = Constants + TypeIdentifiers.Float;
            
            /// <summary>
            /// Menu item path to create a new Int script graph.
            /// </summary>
            public const string Int = Constants + TypeIdentifiers.Int;

            /// <summary>
            /// Menu item path to create a new Vector2 script graph.
            /// </summary>
            public const string Vector2 = Constants + TypeIdentifiers.Vector2;
                        
            /// <summary>
            /// Menu item path to create a new String script graph.
            /// </summary>
            public const string String = Constants + TypeIdentifiers.String;
            
            /// <summary>
            /// Menu item path to create a new Vector3 script graph.
            /// </summary>
            public const string Vector3 = Constants + TypeIdentifiers.Vector3;
        }

        ///xml documentation in the main <see cref="VisualScriptingTemplateFactory"/> file.
        public partial class SubFolderPaths
        {
            /// <summary>
            /// Name of the subfolder for Constants script graphs.
            /// </summary>
            public static string Constants => nameof(Constants);

            /// <summary>
            /// Name of the subfolder for Floats script graphs.
            /// </summary>
            public static string Floats => Path.Combine(Variables, Constants, nameof(Floats));
            
            /// <summary>
            /// Name of the subfolder for Ints script graphs.
            /// </summary>
            public static string Ints => Path.Combine(Variables, Constants, nameof(Ints));
            
            /// <summary>
            /// Name of the subfolder for Strings script graphs.
            /// </summary>
            public static string Strings => Path.Combine(Variables, Constants, nameof(Strings));
            
            /// <summary>
            /// Name of the subfolder for Vector2s script graphs.
            /// </summary>
            public static string Vector2s => Path.Combine(Variables, Constants, nameof(Vector2s));
            
            /// <summary>
            /// Name of the subfolder for Vector3s script graphs.
            /// </summary>
            public static string Vector3s => Path.Combine(Variables, Constants, nameof(Vector3s));
        }

        /// <summary>
        /// Creates a Float script graph.
        /// </summary>
        [MenuItem(MenuItemPaths.Float)]
        public static void CreateFloat() => CreateVisualScriptingAsset(TemplateAssetPaths.Float, SubFolderPaths.Floats, TypeIdentifiers.Float, FileNameSuffixes.NewFileSuffix);

        /// <summary>
        /// Creates a Int script graph.
        /// </summary>
        [MenuItem(MenuItemPaths.Int)]
        public static void CreateInt() => CreateVisualScriptingAsset(TemplateAssetPaths.Int, SubFolderPaths.Ints, TypeIdentifiers.Int, FileNameSuffixes.NewFileSuffix);

        /// <summary>
        /// Creates a String script graph.
        /// </summary>
        [MenuItem(MenuItemPaths.String)]
        public static void CreateString() => CreateVisualScriptingAsset(TemplateAssetPaths.String, SubFolderPaths.Strings, TypeIdentifiers.String, FileNameSuffixes.NewFileSuffix);

        /// <summary>
        /// Creates a Vector2 script graph.
        /// </summary>
        [MenuItem(MenuItemPaths.Vector2)]
        public static void CreateVector2() => CreateVisualScriptingAsset(TemplateAssetPaths.Vector2, SubFolderPaths.Vector2s, TypeIdentifiers.Vector2, FileNameSuffixes.NewFileSuffix);
        
        /// <summary>
        /// Creates a Vector3 script graph.
        /// </summary>
        [MenuItem(MenuItemPaths.Vector3)]
        public static void CreateVector3() => CreateVisualScriptingAsset(TemplateAssetPaths.Vector3, SubFolderPaths.Vector3s, TypeIdentifiers.Vector3, FileNameSuffixes.NewFileSuffix);
    }
}
