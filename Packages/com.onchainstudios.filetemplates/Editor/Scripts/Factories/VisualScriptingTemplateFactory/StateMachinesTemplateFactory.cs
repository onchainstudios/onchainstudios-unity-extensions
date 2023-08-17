//*****************************************************************************
// Author: Arthur LeVesque
// Copyright: OnChain Studios, 2023
//*****************************************************************************

namespace OnChainStudios.FileTemplates
{
    using UnityEditor;

    ///xml documentation in the main <see cref="VisualScriptingTemplateFactory"/> file.
    public partial class VisualScriptingTemplateFactory
    {
        ///xml documentation in the main <see cref="VisualScriptingTemplateFactory"/> file.
        public partial class TypeIdentifiers
        {
            /// <summary>
            /// Type identifier for a StateMachine script graph.
            /// </summary>
            public const string StateMachine = nameof(StateMachine);
            
            /// <summary>
            /// Type identifier for a SuperState script graph.
            /// </summary>
            public const string SuperState = nameof(SuperState);
        }

        ///xml documentation in the main <see cref="VisualScriptingTemplateFactory"/> file.
        public partial class TemplateAssetPaths
        {
            /// <summary>
            /// File name for the StateMachine template.
            /// </summary>
            public static string StateMachine => FileTemplateHelper.GetProjectRelativeFilePath(TypeIdentifiers.StateMachine + _fileNameSuffix);
            
            /// <summary>
            /// File name for the SuperState template.
            /// </summary>
            public static string SuperState => FileTemplateHelper.GetProjectRelativeFilePath(TypeIdentifiers.SuperState + _fileNameSuffix);
        }

        ///xml documentation in the main <see cref="VisualScriptingTemplateFactory"/> file.
        public partial class MenuItemPaths
        {
            /// <summary>
            /// Base path for StateMachine script graphs.
            /// </summary>
            private const string StateMachines = _basePath + nameof(StateMachines) + _delimiter;

            /// <summary>
            /// Menu item path to create a new StateMachine script graph.
            /// </summary>
            public const string StateMachine = StateMachines + TypeIdentifiers.StateMachine;
            
            /// <summary>
            /// Menu item path to create a new SuperState script graph.
            /// </summary>
            public const string SuperState = StateMachines + TypeIdentifiers.SuperState;
        }

        ///xml documentation in the main <see cref="VisualScriptingTemplateFactory"/> file.
        public partial class SubFolderPaths
        {
            /// <summary>
            /// Name of the subfolder for StateMachine script graphs.
            /// </summary>
            public static string StateMachine => nameof(StateMachine);
        }

        /// <summary>
        /// Creates a StateMachine script graph.
        /// </summary>
        [MenuItem(MenuItemPaths.StateMachine)]
        public static void CreateStateMachine() => CreateVisualScriptingAsset(TemplateAssetPaths.StateMachine, SubFolderPaths.StateMachine, TypeIdentifiers.StateMachine);
        
        /// <summary>
        /// Creates a SuperState script graph.
        /// </summary>
        [MenuItem(MenuItemPaths.SuperState)]
        public static void CreateSuperState() => CreateVisualScriptingAsset(TemplateAssetPaths.SuperState, SubFolderPaths.StateMachine, TypeIdentifiers.SuperState);
    }
}