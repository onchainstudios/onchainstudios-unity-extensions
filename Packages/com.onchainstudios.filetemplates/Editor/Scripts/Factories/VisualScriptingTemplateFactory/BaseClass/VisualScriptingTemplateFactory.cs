//*****************************************************************************
// Author: Nicole Leser
// Copyright: OnChain Studios, 2023
//*****************************************************************************

namespace OnChainStudios.FileTemplates
{
    using System.IO;
    using UnityEditor;
    using UnityEngine;

    /// <summary>
    /// Factory class to make visual scripting templates.
    /// </summary>
    public static partial class VisualScriptingTemplateFactory
    {
        /// <summary>
        /// String value for a period "."
        /// </summary>
        private const string _period = ".";

        /// <summary>
        /// String value for a forwardSlash "/"
        /// </summary>
        private const string _forwardSlash = "/";

        /// <summary>
        /// Holds the values for file name suffixes.
        /// </summary>
        public static partial class FileNameSuffixes
        {
            /// <summary>
            /// Delimiter between parts of the file names.
            /// </summary>
            private static string _delimiter => _period;

            /// <summary>
            /// The suffix for a new file.
            /// </summary>
            public static string NewFileSuffix => _delimiter + "New";
        }

        /// <summary>
        /// Holds the values for type identifiers used in the factory.
        /// </summary>
        public static partial class TypeIdentifiers
        {
            /// <summary>
            /// Delimiter to use between parts of a type identifier.
            /// </summary>
            private const string _delimiter = _period;
        }

        /// <summary>
        /// Holds the names of the template files.
        /// </summary>
        public static partial class TemplateAssetPaths
        {
            /// <summary>
            /// Delimiter to use for template asset paths.
            /// </summary>
            private const string _delimiter = _period;

            private const string _fileNameSuffix = _delimiter + "TemplateGraph";
        }

        /// <summary>
        /// Values used in the factory for menu item paths.
        /// The delimiter is always appended to the end of the path.
        /// </summary>
        public static partial class MenuItemPaths
        {
            private const string _delimiter = _forwardSlash;

            /// <summary>
            /// Path to create a new visual scripting asset.
            /// </summary>
            private const string _basePath = "Assets" + _delimiter + "Create" + _delimiter + "Visual Scripting" + _delimiter;
        }

        /// <summary>
        /// Values used in the factory for file names.
        /// </summary>
        public static partial class SubFolderPaths
        {
        }

        /// <summary>
        /// Creates a visual scripting asset from a template.
        /// </summary>
        /// <param name="templateAssetPath">The template file asset path.</param>
        /// <param name="subFolderPath">The sub folder path where the asset will be placed.</param>
        /// <param name="fileNamePrefix">The file name prefix for the asset.</param>
        /// <param name="fileNameSuffix">The file name suffix for the asset.</param>
        /// <param name="appendMainFolder">If set to true, appends the main folder where this file was generated.</param>
        private static void CreateVisualScriptingAsset(string templateAssetPath, string subFolderPath, string fileNamePrefix, string fileNameSuffix = null, bool appendMainFolder = false)
        {
            var selectedFolderPath = AssetDatabase.GetAssetPath(Selection.activeObject);

            var folderPath = Path.Combine(selectedFolderPath, subFolderPath);
            folderPath = appendMainFolder ? Path.Combine(folderPath, Path.GetFileName(selectedFolderPath)) : folderPath;

            EnsureDirectoryExists(folderPath);

            var scriptGraphAsset = AssetDatabase.LoadAssetAtPath<ScriptableObject>(templateAssetPath);
            if (scriptGraphAsset != null)
            {
                var locationPath = GetFileNamePath(selectedFolderPath);
                fileNameSuffix ??= string.Empty;
                var fileName = $"{fileNamePrefix}{locationPath}{fileNameSuffix}.asset";
                var assetPath = Path.Combine(folderPath, fileName);
                var graphAsset = UnityEngine.Object.Instantiate(scriptGraphAsset);
                ProjectWindowUtil.CreateAsset(graphAsset, assetPath);
            }
            else
            {
                Debug.LogWarning($"Cannot find template for {templateAssetPath}");
            }
            AssetDatabase.Refresh();

            // Local function to ensure a directory exists.
            void EnsureDirectoryExists(string path)
            {
                if (!Directory.Exists(path))
                {
                    var parentPath = Directory.GetParent(path)?.FullName;
                    if (!Directory.Exists(parentPath))
                    {
                        EnsureDirectoryExists(parentPath);
                    }
                    Directory.CreateDirectory(path);
                    AssetDatabase.Refresh();
                }
            }

            // Local function to get the path of the file for the file name.
            string GetFileNamePath (string path)
            {
                if (Directory.GetParent(path)?.Name == "SuperStates")
                {
                    return $"{GetFileNamePath(Directory.GetParent(path).Parent.Parent.FullName)}.{Path.GetFileName(path)}";
                }
                else
                {
                    return $".{Path.GetFileName(path)}";
                }
            }
        }
    }
}