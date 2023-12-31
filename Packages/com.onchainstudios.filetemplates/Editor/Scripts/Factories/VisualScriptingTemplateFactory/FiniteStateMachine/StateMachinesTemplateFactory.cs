//*****************************************************************************
// Author: Arthur LeVesque
// Copyright: OnChain Studios, 2023
//*****************************************************************************

namespace OnChainStudios.FileTemplates
{
    using System.IO;
    using UnityEditor;

    //xml documentation in the file VisualScriptingTemplateFactory.
    public static partial class VisualScriptingTemplateFactory
    {
        //xml documentation in the file VisualScriptingTemplateFactory.
        public static partial class TypeIdentifiers
        {
            /// <summary>
            /// Type identifiers for anything within the finite state machine.
            /// </summary>
            public static partial class FiniteStateMachine
            {
                /// <summary>
                /// Type identifier for a StateMachine script graph.
                /// </summary>
                public const string StateMachine = nameof(StateMachine);

                /// <summary>
                /// Type identifier for a SuperState script graph.
                /// </summary>
                public const string SuperState = nameof(SuperState);

                /// <summary>
                /// Type identifier for a State script graph.
                /// </summary>
                public const string State = nameof(State);
            }
        }

        //xml documentation in the file VisualScriptingTemplateFactory.
        public static partial class TemplateAssetPaths
        {
            /// <summary>
            /// Template asset paths for anything within the finite state machine.
            /// </summary>
            public static partial class FiniteStateMachine
            {
                /// <summary>
                /// File name for the StateMachine template.
                /// </summary>
                public static string StateMachine => FileTemplateHelper.GetProjectRelativeFilePath(TypeIdentifiers.FiniteStateMachine.StateMachine + _fileNameSuffix);

                /// <summary>
                /// File name for the SuperState template.
                /// </summary>
                public static string SuperState => FileTemplateHelper.GetProjectRelativeFilePath(TypeIdentifiers.FiniteStateMachine.SuperState + _fileNameSuffix);

                /// <summary>
                /// File name for the State template.
                /// </summary>
                public static string State => FileTemplateHelper.GetProjectRelativeFilePath(TypeIdentifiers.FiniteStateMachine.State + _fileNameSuffix);
            }
        }

        //xml documentation in the file VisualScriptingTemplateFactory.
        public static partial class MenuItemPaths
        {
            /// <summary>
            /// Menu item paths for anything within the finite state machine.
            /// </summary>
            public static partial class FiniteStateMachine
            {
                /// <summary>
                /// Base menu item path for a finite state machine script graph.
                /// </summary>
                private const string _finiteStateMachinesBasePath = _basePath + nameof(FiniteStateMachine) + _delimiter;

                /// <summary>
                /// Menu item path to create a new StateMachine script graph.
                /// </summary>
                public const string StateMachine = _finiteStateMachinesBasePath + TypeIdentifiers.FiniteStateMachine.StateMachine;

                /// <summary>
                /// Menu item path to create a new SuperState script graph.
                /// </summary>
                public const string SuperState = _finiteStateMachinesBasePath + TypeIdentifiers.FiniteStateMachine.SuperState;

                /// <summary>
                /// Menu item path to create a new State script graph.
                /// </summary>
                public const string State = _finiteStateMachinesBasePath + TypeIdentifiers.FiniteStateMachine.State;
            }
        }

        //xml documentation in the file VisualScriptingTemplateFactory.
        public static partial class SubFolderPaths
        {
            /// <summary>
            /// Sub folder paths for anything within the finite state machine.
            /// </summary>
            public static partial class FiniteStateMachine
            {
                /// <summary>
                /// Name of the subfolder for StateMachine script graphs.
                /// </summary>
                public static string StateMachine => Path.Combine(nameof(FiniteStateMachine), nameof(StateMachine));

                /// <summary>
                /// Name of the subfolder for State script graphs.
                /// </summary>
                public static string States => Path.Combine(nameof(FiniteStateMachine), nameof(States));
            }
        }

        /// <summary>
        /// Creates a StateMachine script graph.
        /// </summary>
        [MenuItem(MenuItemPaths.FiniteStateMachine.StateMachine)]
        public static void CreateStateMachine() => CreateVisualScriptingAsset(TemplateAssetPaths.FiniteStateMachine.StateMachine, SubFolderPaths.FiniteStateMachine.StateMachine, TypeIdentifiers.FiniteStateMachine.StateMachine);

        /// <summary>
        /// Creates a SuperState script graph.
        /// </summary>
        [MenuItem(MenuItemPaths.FiniteStateMachine.SuperState)]
        public static void CreateSuperState() => CreateVisualScriptingAsset(TemplateAssetPaths.FiniteStateMachine.SuperState, SubFolderPaths.FiniteStateMachine.StateMachine, TypeIdentifiers.FiniteStateMachine.SuperState);

        /// <summary>
        /// Creates a State script graph.
        /// </summary>
        [MenuItem(MenuItemPaths.FiniteStateMachine.State)]
        public static void CreateState() => CreateVisualScriptingAsset(TemplateAssetPaths.FiniteStateMachine.State, SubFolderPaths.FiniteStateMachine.States, TypeIdentifiers.FiniteStateMachine.State, FileNameSuffixes.NewFileSuffix);
    }
}