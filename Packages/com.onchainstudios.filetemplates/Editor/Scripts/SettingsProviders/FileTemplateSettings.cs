//*****************************************************************************
// Author: Arthur LeVesque
// Copyright: OnChain Studios, 2021
//*****************************************************************************

namespace OnChainStudios.FileTemplates
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using UnityEditor;
    using UnityEngine;
    using UnityEngine.UIElements;

    /// <summary>
    /// Settings class for file templates.
    /// </summary>
    static class FileTemplateSettings
    {
        /// <summary>
        /// Editor Pref path for the author.
        /// </summary>
        private static string authorEditorPrefKey => "TemplateHelperSettingsAuthor";

        /// <summary>
        /// Editor Pref path for the author.
        /// </summary>
        private static string namespaceEditorPrefKey => "TemplateHelperSettingsNamespace";
        
        /// <summary>
        /// The author field.
        /// </summary>
        private static TextField authorField { get; set; }
        
        /// <summary>
        /// The namespace field.
        /// </summary>
        private static TextField namespaceField { get; set; }

        /// <summary>
        /// The current value stored in the author setting.
        /// </summary>
        /// <returns></returns>
        public static string AuthorValue => EditorPrefs.GetString(authorEditorPrefKey);

        /// <summary>
        /// The current value stored in the author setting.
        /// </summary>
        /// <returns></returns>
        public static string NamepspaceValue => EditorPrefs.GetString(namespaceEditorPrefKey);
        
        /// <summary>
        /// Create the settings provider for the file template settings display.
        /// </summary>
        [SettingsProvider]
        public static SettingsProvider CreateSettingsProvider()
        {
            // First parameter is the path in the Settings window.
            // Second parameter is the scope of this setting: it only appears in the Settings window for the Project scope.
            var provider = new SettingsProvider("OnChain Studios/File Templates", SettingsScope.User)
            {
                label = "File Templates",
                // activateHandler is called when the user clicks on the Settings item in the Settings window.
                activateHandler = (searchContext, rootElement) =>
                {
                    var title = new Label()
                    {
                        text = "File Templates"
                    };
                    title.AddToClassList("title");
                    rootElement.Add(title);

                    var properties = new VisualElement()
                    {
                        style =
                        {
                            flexDirection = FlexDirection.Column
                        }
                    };
                    properties.AddToClassList("property-list");
                    rootElement.Add(properties);

                    authorField = new TextField("Author");
                    authorField.SetValueWithoutNotify(EditorPrefs.GetString(authorEditorPrefKey));

                    namespaceField = new TextField("Namespace");
                    namespaceField.SetValueWithoutNotify(EditorPrefs.GetString(namespaceEditorPrefKey));
                    
                    properties.Add(authorField);
                    properties.Add(namespaceField);

                    authorField.RegisterValueChangedCallback(AuthorChanged);
                    namespaceField.RegisterValueChangedCallback(NamespaceChanged);
                },

                // deactivateHandler is called when the user clicks off of a setting item in the settings window.
                deactivateHandler = () =>
                {
                    authorField.RegisterValueChangedCallback(AuthorChanged);
                    namespaceField.RegisterValueChangedCallback(NamespaceChanged);
                },

                // Populate the search keywords to enable smart search filtering and label highlighting:
                keywords = new HashSet<string>(new[] { "Author", "Namespace" })
            };
            return provider;
        }

        /// <summary>
        /// Handle when the author is changed and store the value out to editor prefs.
        /// </summary>
        /// <param name="evt">The unity change event.</param>
        private static void AuthorChanged(ChangeEvent<string> evt)
        {
            EditorPrefs.SetString(authorEditorPrefKey, evt.newValue);
        }
        
        /// <summary>
        /// Handle when the namespace is changed and store the value out to editor prefs.
        /// </summary>
        /// <param name="evt">The unity change event.</param>
        private static void NamespaceChanged(ChangeEvent<string> evt)
        {
            EditorPrefs.SetString(namespaceEditorPrefKey, evt.newValue);
        }
    }
}
