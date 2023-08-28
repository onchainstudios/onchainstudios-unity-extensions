//*****************************************************************************
// Author: Arthur LeVesque
// Copyright: OnChain Studios, 2023
//*****************************************************************************

namespace OnChainStudios.FileTemplates
{
    using System;
    using System.IO;
    using UnityEngine;
    using UnityEditor;
    using Unity.VisualScripting;

    /// <summary>
    /// Helper class for the file templates.
    /// </summary>
    public static class FileTemplateHelper
    {
        /// <summary>
        /// File extension for file templates.
        /// </summary>
        public static string Extension => ".cs";

        /// <summary>
        /// The root path of the project.
        /// </summary>
        public static string RootPath => Path.GetDirectoryName(Application.dataPath);

        /// <summary>
        /// Get a file path from a filename without an extension. Uses the extension .cs
        /// </summary>
        /// <param name="fileNameWithoutExtension">The filename without an extension.</param>
        /// <returns>The path of the file.</returns>
        public static string GetFilePath(string fileNameWithoutExtension)
        {
            var assetGUIDs = AssetDatabase.FindAssets(fileNameWithoutExtension);
            foreach (var assetGUID in assetGUIDs)
            {
                var fullAssetPath = AssetDatabase.GUIDToAssetPath(assetGUID);
                var foundFileNameWithoutExtension = Path.GetFileNameWithoutExtension(fullAssetPath);
                if (foundFileNameWithoutExtension == fileNameWithoutExtension)
                {
                    return Path.Combine(RootPath, fullAssetPath);
                }
            }
            return string.Empty;
        }

        /// <summary>
        /// Returns the relative file path of a file within the Unity project folder.
        /// </summary>
        /// <param name="fileNameWithoutExtension">The name of the file without its extension.</param>
        /// <returns>The relative file path of the file.</returns>
        public static string GetProjectRelativeFilePath(string fileNameWithoutExtension) => GetFilePath(fileNameWithoutExtension).Replace($"{Directory.GetParent(Application.dataPath).FullName}{Path.DirectorySeparatorChar}", "");

        /// <summary>
        /// Cleans up the common file data for a newly created file.
        /// </summary>
        /// <param name="fileData">The file data to cleanup.</param>
        /// <param name="templateFileClassName">The class name of the template file.</param>
        /// <returns>The cleaned up file data.</returns>
        public static string CleanupCSharpFileData(string fileData, string templateFileClassName)
        {
            fileData = fileData.Replace(templateFileClassName, "#SCRIPTNAME#");
            fileData = fileData.Replace("#YEAR#", DateTime.Now.Year.ToString());
            fileData = fileData.Replace("#AUTHOR#", FileTemplateSettings.AuthorValue);
            fileData = fileData.Replace("namespace TemplateFile", $"namespace {FileTemplateSettings.NamepspaceValue}");
            fileData = fileData.Replace("//#UNCOMMENT#", "");
            fileData = fileData.Replace("#COMPANYNAME#", Application.companyName);

            return fileData;
        }

        /// <summary>
        /// Creates a new c# file.
        /// </summary>
        /// <param name="templateClassName">The name of the template class to create the file from.</param>
        public static void CreateCSharpFile(string templateClassName)
        {
            var fileData = File.ReadAllText(FileTemplateHelper.GetFilePath(templateClassName));
            fileData = FileTemplateHelper.CleanupCSharpFileData(fileData, templateClassName);
            var newFileName = $"New{templateClassName.Replace("Template", "")}";

            var tempDirectory = $"{Directory.GetParent(Application.dataPath)}{Path.DirectorySeparatorChar}Temp";
            if (!Directory.Exists(tempDirectory))
            {
                Directory.CreateDirectory(tempDirectory);
            }
            var tempTemplateFilePath = Path.Combine(tempDirectory, "onchainFileTemplateData.txt");
            File.WriteAllText(tempTemplateFilePath, fileData);

            ProjectWindowUtil.CreateScriptAssetFromTemplateFile(tempTemplateFilePath, $"{newFileName}{Extension}");
        }
    }
}
