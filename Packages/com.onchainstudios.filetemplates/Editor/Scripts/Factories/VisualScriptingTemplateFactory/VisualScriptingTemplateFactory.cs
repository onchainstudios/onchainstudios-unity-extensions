//*****************************************************************************
// Author: Nicole Leser
// Copyright: OnChain Studios, 2023
//*****************************************************************************

namespace OnChainStudios.FileTemplates
{
    using System.IO;
    using Unity.VisualScripting;
    using UnityEditor;
    using UnityEngine;
    
    /// <summary>
    /// Factory class to make visual scripting templates. 
    /// </summary>
    public partial class VisualScriptingTemplateFactory
    {
        /// <summary>
        /// Holds the values for file name suffixes.
        /// </summary>
        public partial class FileNameSuffixes
        {
            /// <summary>
            /// Delimiter between parts of the file names.
            /// </summary>
            private static string _delimiter => ".";
            
            /// <summary>
            /// The suffix for a new file.
            /// </summary>
            public static string NewFileSuffix => _delimiter + "New";
        }

        /// <summary>
        /// Holds the values for type identifiers used in the factory.
        /// </summary>
        public partial class TypeIdentifiers
        {
            private const string _delimiter = ".";
        }

        /// <summary>
        /// Holds the names of the template files.
        /// </summary>
        public partial class TemplateAssetPaths
        {
            private const string _delimiter = ".";
            
            private const string _fileNameSuffix = _delimiter + "TemplateGraph";
        }
        
        /// <summary>
        /// Values used in the factory for menu item paths.
        /// The delimiter is always appended to the end of the path.
        /// </summary>
        public partial class MenuItemPaths
        {
            private const string _delimiter = "/";
            
            /// <summary>
            /// Path to create a new visual scripting asset. 
            /// </summary>
            private const string _basePath = "Assets" + _delimiter + "Create" + _delimiter + "Visual Scripting" + _delimiter;
        }

        /// <summary>
        /// Values used in the factory for file names.
        /// </summary>
        public partial class SubFolderPaths
        {
        }

        /// <summary>
        /// Creates a visual scripting asset from a template.
        /// </summary>
        /// <param name="templateAssetPath">The path to the template file.</param>
        /// <param name="subFolderPath">The sub folder path to place the file in.</param>
        /// <param name="fileNamePrefix"></param>
        /// <param name="fileNameSuffix"></param>
        public static void CreateVisualScriptingAsset(string templateAssetPath, string subFolderPath, string fileNamePrefix, string fileNameSuffix = null, bool appendMainFolder = false)
        {
            var selectedFolderPath = AssetDatabase.GetAssetPath(Selection.activeObject);

            var folderPath = Path.Combine(selectedFolderPath, subFolderPath);
            if (appendMainFolder)
            {
                folderPath = Path.Combine(folderPath, Path.GetFileName(selectedFolderPath));
            }
            EnsureDirectoryExists(folderPath);
            void EnsureDirectoryExists(string path)
            {
                if (!Directory.Exists(path))
                {
                    var parentPath = Directory.GetParent(path).FullName;
                    if (!Directory.Exists(parentPath))
                    {
                        EnsureDirectoryExists(parentPath);
                    }
                    Directory.CreateDirectory(path);
                    AssetDatabase.Refresh();
                }
            }

            var locationPath = GetLocationPath(selectedFolderPath);
            string GetLocationPath (string path)
            {

                if (Directory.GetParent(path).Name == "SuperStates")
                {
                    return $"{GetLocationPath(Directory.GetParent(path).Parent.FullName)}.{Path.GetFileName(path)}";
                }
                else
                {
                    return $".{Path.GetFileName(path)}";
                }
                
            }

            fileNameSuffix = fileNameSuffix == null ? string.Empty : fileNameSuffix;
            var fileName = $"{fileNamePrefix}{locationPath}{fileNameSuffix}.asset";
            
            var assetPath = Path.Combine(folderPath, fileName);

            var scriptGraphAsset = AssetDatabase.LoadAssetAtPath<ScriptableObject>(templateAssetPath);
            if (scriptGraphAsset != null)
            {
                var graphAsset = UnityEngine.Object.Instantiate(scriptGraphAsset);
                ProjectWindowUtil.CreateAsset(graphAsset, assetPath);
                
            }
            else
            {
                Debug.LogWarning($"Cannot find template for {templateAssetPath}");
            }
            AssetDatabase.Refresh();
        }
    }
}