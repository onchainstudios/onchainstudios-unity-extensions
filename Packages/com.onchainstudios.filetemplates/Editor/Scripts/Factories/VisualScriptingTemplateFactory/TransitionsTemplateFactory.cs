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
            public partial class FiniteStateMachine
            {
                public class Transition
                {
                    /// <summary>
                    /// Type identifier for a Transition EventName script graph.
                    /// </summary>
                    public const string EventName = nameof(Transition) + _delimiter + nameof(EventName);

                    /// <summary>
                    /// Type identifier for a Transition State script graph.
                    /// </summary>
                    public const string State = nameof(Transition)  + _delimiter + nameof(State);

                    /// <summary>
                    /// Type identifier for a TransitionT rigger script graph.
                    /// </summary>
                    public const string Trigger = nameof(Transition)  + _delimiter + nameof(Trigger);
                }
            }
        }

        ///xml documentation in the main <see cref="VisualScriptingTemplateFactory"/> file.
        public partial class TemplateAssetPaths
        {
            public partial class FiniteStateMachine
            {
                public class Transition
                {
                    /// <summary>
                    /// File name for the Transition EventName template.
                    /// </summary>
                    public static string EventName => FileTemplateHelper.GetProjectRelativeFilePath(TypeIdentifiers.FiniteStateMachine.Transition.EventName + _fileNameSuffix);

                    /// <summary>
                    /// File name for the Transition State template.
                    /// </summary>
                    public static string State => FileTemplateHelper.GetProjectRelativeFilePath(TypeIdentifiers.FiniteStateMachine.Transition.State + _fileNameSuffix);

                    /// <summary>
                    /// File name for the Transition Trigger template.
                    /// </summary>
                    public static string Trigger => FileTemplateHelper.GetProjectRelativeFilePath(TypeIdentifiers.FiniteStateMachine.Transition.Trigger + _fileNameSuffix);
                }
            }
        }
        
        ///xml documentation in the main <see cref="VisualScriptingTemplateFactory"/> file.
        public partial class MenuItemPaths
        {
            public partial class FiniteStateMachine
            {
                
                public class Transition
                {
                    /// <summary>
                    /// Base path for Transitions script graphs.
                    /// </summary>
                    private const string _transitionBasePath = _finiteStateMachinesBasePath + nameof(Transition) + _delimiter;

                    /// <summary>
                    /// Menu item path to create a new TransitionEventName script graph.
                    /// </summary>
                    public const string EventName = _transitionBasePath + nameof(EventName);
                    

                    /// <summary>
                    /// Menu item path to create a new TransitionState script graph.
                    /// </summary>
                    public const string State = _transitionBasePath + nameof(State);

                    /// <summary>
                    /// Menu item path to create a new TrantitionTrigger script graph.
                    /// </summary>
                    public const string Trigger = _transitionBasePath + nameof(Trigger);
                }
            }
        }

        ///xml documentation in the main <see cref="VisualScriptingTemplateFactory"/> file.
        public partial class SubFolderPaths
        {
            public partial class FiniteStateMachine
            {
                public class Transitions
                {
                    /// <summary>
                    /// Name of the subfolder for Transitions script graphs.
                    /// </summary>
                    private static string _transitionsBasePath => Path.Combine(nameof(FiniteStateMachine), nameof(Transitions));

                    /// <summary>
                    /// Name of the subfolder for TransitionEventNames script graphs.
                    /// </summary>
                    public static string EventNames => Path.Combine(_transitionsBasePath, nameof(EventNames));

                    /// <summary>
                    /// Name of the subfolder for TransitionStates script graphs.
                    /// </summary>
                    public static string States => Path.Combine(_transitionsBasePath, nameof(States));

                    /// <summary>
                    /// Name of the subfolder for TransitionTriggers script graphs.
                    /// </summary>
                    public static string Triggers => Path.Combine(_transitionsBasePath, nameof(Triggers));
                }
            }
        }

        /// <summary>
        /// Creates a TransitionEventName script graph.
        /// </summary>
        [MenuItem(MenuItemPaths.FiniteStateMachine.Transition.EventName)]
        public static void CreateTransitionEventName() => CreateVisualScriptingAsset(TemplateAssetPaths.FiniteStateMachine.Transition.EventName, SubFolderPaths.FiniteStateMachine.Transitions.EventNames, TypeIdentifiers.FiniteStateMachine.Transition.EventName, FileNameSuffixes.NewFileSuffix);

        /// <summary>
        /// Creates a TransitionState script graph.
        /// </summary>
        [MenuItem(MenuItemPaths.FiniteStateMachine.Transition.State)]
        public static void CreateTransitionState() => CreateVisualScriptingAsset(TemplateAssetPaths.FiniteStateMachine.Transition.State, SubFolderPaths.FiniteStateMachine.Transitions.States, TypeIdentifiers.FiniteStateMachine.Transition.State, FileNameSuffixes.NewFileSuffix);
        
        /// <summary>
        /// Creates a TrantitionTrigger script graph.
        /// </summary>
        [MenuItem(MenuItemPaths.FiniteStateMachine.Transition.Trigger)]
        public static void CreateTrantitionTrigger() => CreateVisualScriptingAsset(TemplateAssetPaths.FiniteStateMachine.Transition.Trigger, SubFolderPaths.FiniteStateMachine.Transitions.Triggers, TypeIdentifiers.FiniteStateMachine.Transition.Trigger, FileNameSuffixes.NewFileSuffix);
    }
}
