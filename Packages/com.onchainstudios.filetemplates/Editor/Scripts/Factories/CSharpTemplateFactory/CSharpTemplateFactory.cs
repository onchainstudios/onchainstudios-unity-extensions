//*****************************************************************************
// Author: Arthur LeVesque
// Copyright: OnChain Studios, 2023
//*****************************************************************************

namespace OnChainStudios.FileTemplates
{
    using TemplateFile;
    using UnityEditor;
    
    /// <summary>
    /// Factory for creating c# files based off of the template files.
    /// </summary>
    public class CSharpTemplateFactory
    {
        /// <summary>
        /// The base menu item path for the c# template menu items.
        /// </summary>
        public const string BaseMenuItemPath = "Assets/Create/Scripts/";

        /// <summary>
        /// Menu item to create a <see cref="EditorTemplate"/> file.
        /// </summary>
        [MenuItem(BaseMenuItemPath + "C# Editor", priority = 0)]
        public static void CreateEditor() => 
            FileTemplateHelper.CreateCSharpFile(nameof(EditorTemplate));
        
        /// <summary>
        /// Menu item to create a <see cref="EditorWindowTemplate"/> file.
        /// </summary>
        [MenuItem(BaseMenuItemPath + "C# Editor Window", priority = 0)]
        public static void CreateEditorWindow() =>
            FileTemplateHelper.CreateCSharpFile(nameof(EditorWindowTemplate));

        /// <summary>
        /// Menu item to create a <see cref="EmptyClassTemplate"/> file.
        /// </summary>
        [MenuItem(BaseMenuItemPath + "C# Empty Class", priority = 0)]
        public static void CreateEmptyClass() =>
            FileTemplateHelper.CreateCSharpFile(nameof(EmptyClassTemplate));

        /// <summary>
        /// Menu item to create a <see cref="EventUnitTemplate"/> file.
        /// </summary>
        [MenuItem(BaseMenuItemPath + "C# Visaul Scripting Event Unit", priority = 0)]
        public static void CreateEventUnit() =>
            FileTemplateHelper.CreateCSharpFile(nameof(EventUnitTemplate));

        /// <summary>
        /// Menu item to create a <see cref="MonoBehaviourTemplate"/> file.
        /// </summary>
        [MenuItem(BaseMenuItemPath + "C# MonoBehaviour", priority = 0)]
        public static void CreateMonoBehaviour() =>
            FileTemplateHelper.CreateCSharpFile(nameof(MonoBehaviourTemplate));

        /// <summary>
        /// Menu item to create a <see cref="ScriptableObjectTemplate"/> file.
        /// </summary>
        [MenuItem(BaseMenuItemPath + "C# Scriptable Object", priority = 0)]
        public static void CreateScriptableObject() =>
            FileTemplateHelper.CreateCSharpFile(nameof(ScriptableObjectTemplate));

        /// <summary>
        /// Menu item to create a <see cref="TestTemplate"/> file.
        /// </summary>
        [MenuItem(BaseMenuItemPath + "C# Test", priority = 0)]
        public static void CreateTest() =>
            FileTemplateHelper.CreateCSharpFile(nameof(TestTemplate));

        /// <summary>
        /// Menu item to create a <see cref="UnitTemplate"/> file.
        /// </summary>
        [MenuItem(BaseMenuItemPath + "C# Visaul Scripting Unit", priority = 0)]
        public static void CreateUnit() =>
            FileTemplateHelper.CreateCSharpFile(nameof(UnitTemplate));
    }
}
