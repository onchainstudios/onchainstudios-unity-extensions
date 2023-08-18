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
            /// File suffix for a EventListener.
            /// </summary>
            public static string EventListener => _delimiter + "[TriggerGameObjectName]" + NewFileSuffix;
        }
        
        ///xml documentation in the main <see cref="VisualScriptingTemplateFactory"/> file.
        public partial class TypeIdentifiers
        {
            public class Event
            {
                /// <summary>
                /// Type identifier for a EventListener script graph.
                /// </summary>
                public const string Listener = nameof(Event) + _delimiter + nameof(Listener);

                /// <summary>
                /// Type identifier for a EventName script graph.
                /// </summary>
                public const string Name = nameof(Event) + _delimiter + nameof(Name);

                /// <summary>
                /// Type identifier for a EventTrigger script graph.
                /// </summary>
                public const string Trigger = nameof(Event) + _delimiter + nameof(Trigger);
            }
        }

        ///xml documentation in the main <see cref="VisualScriptingTemplateFactory"/> file.
        public partial class TemplateAssetPaths
        {
            public class Event
            {
                /// <summary>
                /// File name for the EventListener template.
                /// </summary>
                public static string Listener => FileTemplateHelper.GetProjectRelativeFilePath(TypeIdentifiers.Event.Listener + _fileNameSuffix);

                /// <summary>
                /// File name for the EventName template.
                /// </summary>
                public static string Name => FileTemplateHelper.GetProjectRelativeFilePath(TypeIdentifiers.Event.Name + _fileNameSuffix);

                /// <summary>
                /// File name for the EventTrigger template.
                /// </summary>
                public static string Trigger => FileTemplateHelper.GetProjectRelativeFilePath(TypeIdentifiers.Event.Trigger + _fileNameSuffix);
            }
        }
        
        ///xml documentation in the main <see cref="VisualScriptingTemplateFactory"/> file.
        public partial class MenuItemPaths
        {
            public static class Event
            {
                /// <summary>
                /// Base path for Event script graphs.
                /// </summary>
                private const string _eventsBasePath = _basePath + nameof(Event) + _delimiter;

                /// <summary>
                /// Menu item path to create a new EventListener script graph.
                /// </summary>
                public const string Listener = _eventsBasePath + nameof(Listener);

                /// <summary>
                /// Menu item path to create a new EventName script graph.
                /// </summary>
                public const string Name = _eventsBasePath + nameof(Name);

                /// <summary>
                /// Menu item path to create a new EventTrigger script graph.
                /// </summary>
                public const string Trigger = _eventsBasePath + nameof(Trigger);
            }
        }

        ///xml documentation in the main <see cref="VisualScriptingTemplateFactory"/> file.
        public partial class SubFolderPaths
        {
            public partial class Events
            {
                /// <summary>
                /// Base subfolder path for events variables.
                /// </summary>
                private static string _eventsBasePath = nameof(Events);

                /// <summary>
                /// Name of the subfolder for EventListener script graphs.
                /// </summary>
                public static string Listeners => Path.Combine(_eventsBasePath, nameof(Listeners));

                /// <summary>
                /// Name of the subfolder for EventName script graphs.
                /// </summary>
                public static string Names => Path.Combine(_eventsBasePath, nameof(Names));

                /// <summary>
                /// Name of the subfolder for EventTrigger script graphs.
                /// </summary>
                public static string Triggers => Path.Combine(_eventsBasePath, nameof(Triggers));
            }
        }

        /// <summary>
        /// Creates a EventListener script graph.
        /// </summary>
        [MenuItem(MenuItemPaths.Event.Listener)]
        public static void CreateEventListener() => CreateVisualScriptingAsset(TemplateAssetPaths.Event.Listener, SubFolderPaths.Events.Listeners, TypeIdentifiers.Event.Listener, FileNameSuffixes.EventListener, true);

        /// <summary>
        /// Creates a EventName script graph.
        /// </summary>
        [MenuItem(MenuItemPaths.Event.Name)]
        public static void CreateEventName() => CreateVisualScriptingAsset(TemplateAssetPaths.Event.Name, SubFolderPaths.Events.Names, TypeIdentifiers.Event.Name, FileNameSuffixes.NewFileSuffix, true);
        
        /// <summary>
        /// Creates a EventTrigger script graph.
        /// </summary>
        [MenuItem(MenuItemPaths.Event.Trigger)]
        public static void CreateEventTrigger() => CreateVisualScriptingAsset(TemplateAssetPaths.Event.Trigger, SubFolderPaths.Events.Triggers, TypeIdentifiers.Event.Trigger, FileNameSuffixes.NewFileSuffix, true);
    }
}
