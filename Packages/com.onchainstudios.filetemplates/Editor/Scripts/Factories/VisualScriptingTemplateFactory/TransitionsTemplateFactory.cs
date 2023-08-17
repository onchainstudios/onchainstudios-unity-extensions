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
            /// Type identifier for a TransitionEventName script graph.
            /// </summary>
            public const string TransitionEventName = nameof(TransitionEventName);
            
            /// <summary>
            /// Type identifier for a TransitionState script graph.
            /// </summary>
            public const string TransitionState = nameof(TransitionState);
            
            /// <summary>
            /// Type identifier for a TransitionTrigger script graph.
            /// </summary>
            public const string TransitionTrigger = nameof(TransitionTrigger);
        }

        ///xml documentation in the main <see cref="VisualScriptingTemplateFactory"/> file.
        public partial class TemplateAssetPaths
        {
            /// <summary>
            /// File name for the TransitionEventName template.
            /// </summary>
            public static string TransitionEventName => FileTemplateHelper.GetProjectRelativeFilePath(TypeIdentifiers.TransitionEventName + _fileNameSuffix);
            
            /// <summary>
            /// File name for the TransitionState template.
            /// </summary>
            public static string TransitionState => FileTemplateHelper.GetProjectRelativeFilePath(TypeIdentifiers.TransitionState + _fileNameSuffix);
            
            /// <summary>
            /// File name for the TransitionTrigger template.
            /// </summary>
            public static string TransitionTrigger => FileTemplateHelper.GetProjectRelativeFilePath(TypeIdentifiers.TransitionTrigger + _fileNameSuffix);
        }
        
        ///xml documentation in the main <see cref="VisualScriptingTemplateFactory"/> file.
        public partial class MenuItemPaths
        {
            /// <summary>
            /// Base path for Transitions script graphs.
            /// </summary>
            private const string Transitions = _basePath + nameof(Transitions) + _delimiter;
            
            /// <summary>
            /// Menu item path to create a new TransitionEventName script graph.
            /// </summary>
            public const string TransitionEventName = Transitions + TypeIdentifiers.TransitionEventName;

            /// <summary>
            /// Menu item path to create a new TransitionState script graph.
            /// </summary>
            public const string TransitionState = Transitions + TypeIdentifiers.TransitionState;

            /// <summary>
            /// Menu item path to create a new TrantitionTrigger script graph.
            /// </summary>
            public const string TrantitionTrigger = Transitions + TypeIdentifiers.TransitionTrigger;
        }

        ///xml documentation in the main <see cref="VisualScriptingTemplateFactory"/> file.
        public partial class SubFolderPaths
        {
            /// <summary>
            /// Name of the subfolder for Transitions script graphs.
            /// </summary>
            public static string Transitions => nameof(Transitions);
            
            /// <summary>
            /// Name of the subfolder for TransitionEventNames script graphs.
            /// </summary>
            public static string TransitionEventNames => Path.Combine(Transitions, nameof(TransitionEventNames));
            
            /// <summary>
            /// Name of the subfolder for TransitionStates script graphs.
            /// </summary>
            public static string TransitionStates => Path.Combine(Transitions, nameof(TransitionStates));
            
            /// <summary>
            /// Name of the subfolder for TransitionTriggers script graphs.
            /// </summary>
            public static string TransitionTriggers => Path.Combine(Transitions, nameof(TransitionTriggers));
        }

        /// <summary>
        /// Creates a TransitionEventName script graph.
        /// </summary>
        [MenuItem(MenuItemPaths.TransitionEventName)]
        public static void CreateTransitionEventName() => CreateVisualScriptingAsset(TemplateAssetPaths.TransitionEventName, SubFolderPaths.TransitionEventNames, TypeIdentifiers.TransitionEventName, FileNameSuffixes.NewFileSuffix);

        /// <summary>
        /// Creates a TransitionState script graph.
        /// </summary>
        [MenuItem(MenuItemPaths.TransitionState)]
        public static void CreateTransitionState() => CreateVisualScriptingAsset(TemplateAssetPaths.TransitionState, SubFolderPaths.TransitionStates, TypeIdentifiers.TransitionState, FileNameSuffixes.NewFileSuffix);
        
        /// <summary>
        /// Creates a TrantitionTrigger script graph.
        /// </summary>
        [MenuItem(MenuItemPaths.TrantitionTrigger)]
        public static void CreateTrantitionTrigger() => CreateVisualScriptingAsset(TemplateAssetPaths.TransitionTrigger, SubFolderPaths.TransitionTriggers, TypeIdentifiers.TransitionTrigger, FileNameSuffixes.NewFileSuffix);
    }
}
