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
            public static string EventListener => "[TriggerGameObjectName]" + _delimiter + NewFileSuffix;
        }
        
        ///xml documentation in the main <see cref="VisualScriptingTemplateFactory"/> file.
        public partial class TypeIdentifiers
        {
            /// <summary>
            /// Type identifier for a EventListener script graph.
            /// </summary>
            public const string EventListener = nameof(EventListener);
            
            /// <summary>
            /// Type identifier for a EventTrigger script graph.
            /// </summary>
            public const string EventName = nameof(EventName);
            
            /// <summary>
            /// Type identifier for a EventTrigger script graph.
            /// </summary>
            public const string EventTrigger = nameof(EventTrigger);
        }

        ///xml documentation in the main <see cref="VisualScriptingTemplateFactory"/> file.
        public partial class TemplateAssetPaths
        {
            /// <summary>
            /// File name for the EventListener template.
            /// </summary>
            public static string EventListener => FileTemplateHelper.GetProjectRelativeFilePath(TypeIdentifiers.EventListener + _fileNameSuffix);
            
            /// <summary>
            /// File name for the EventName template.
            /// </summary>
            public static string EventName => FileTemplateHelper.GetProjectRelativeFilePath(TypeIdentifiers.EventName + _fileNameSuffix);
            
            /// <summary>
            /// File name for the EventTrigger template.
            /// </summary>
            public static string EventTrigger => FileTemplateHelper.GetProjectRelativeFilePath(TypeIdentifiers.EventTrigger + _fileNameSuffix);
        }
        
        ///xml documentation in the main <see cref="VisualScriptingTemplateFactory"/> file.
        public partial class MenuItemPaths
        {
            /// <summary>
            /// Base path for Event script graphs.
            /// </summary>
            private const string Events = _basePath + nameof(Events) + _delimiter;
            
            /// <summary>
            /// Menu item path to create a new EventListener script graph.
            /// </summary>
            public const string EventListener = Events + TypeIdentifiers.EventListener;

            /// <summary>
            /// Menu item path to create a new EventName script graph.
            /// </summary>
            public const string EventName = Events + TypeIdentifiers.EventName;

            /// <summary>
            /// Menu item path to create a new EventTrigger script graph.
            /// </summary>
            public const string EventTrigger = Events + TypeIdentifiers.EventTrigger;
        }

        ///xml documentation in the main <see cref="VisualScriptingTemplateFactory"/> file.
        public partial class SubFolderPaths
        {
            /// <summary>
            /// Name of the subfolder for EventListener script graphs.
            /// </summary>
            public static string Events => nameof(Events);
            
            /// <summary>
            /// Name of the subfolder for EventListener script graphs.
            /// </summary>
            public static string EventListeners => Path.Combine(Events, nameof(EventListeners));
            
            /// <summary>
            /// Name of the subfolder for EventListener script graphs.
            /// </summary>
            public static string EventNames => Path.Combine(Events, nameof(EventNames));
            
            /// <summary>
            /// Name of the subfolder for EventListener script graphs.
            /// </summary>
            public static string EventTriggers => Path.Combine(Events, nameof(EventTriggers));
        }

        /// <summary>
        /// Creates a EventListener script graph.
        /// </summary>
        [MenuItem(MenuItemPaths.EventListener)]
        public static void CreateEventListener() => CreateVisualScriptingAsset(TemplateAssetPaths.EventListener, SubFolderPaths.EventListeners, TypeIdentifiers.EventListener, FileNameSuffixes.EventListener, true);

        /// <summary>
        /// Creates a EventName script graph.
        /// </summary>
        [MenuItem(MenuItemPaths.EventName)]
        public static void CreateEventName() => CreateVisualScriptingAsset(TemplateAssetPaths.EventName, SubFolderPaths.EventNames, TypeIdentifiers.EventName, FileNameSuffixes.NewFileSuffix, true);
        
        /// <summary>
        /// Creates a EventTrigger script graph.
        /// </summary>
        [MenuItem(MenuItemPaths.EventTrigger)]
        public static void CreateEventTrigger() => CreateVisualScriptingAsset(TemplateAssetPaths.EventTrigger, SubFolderPaths.EventTriggers, TypeIdentifiers.EventTrigger, FileNameSuffixes.NewFileSuffix, true);
    }
}
