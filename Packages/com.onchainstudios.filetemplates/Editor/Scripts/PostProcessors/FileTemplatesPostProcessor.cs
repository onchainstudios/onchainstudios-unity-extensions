//*****************************************************************************
// Author: Arthur LeVesque
// Copyright: OnChain Studios, 2023
//*****************************************************************************

namespace OnChainStudios.FileTemplates
{
    using System.IO;
    using System.Text;
    using Unity.VisualScripting;
    using UnityEditor;
    using UnityEngine;
    
    /// <summary>
    /// A post processor for the file templates.
    /// </summary>
    public class FileTemplatesPostProcessor : AssetPostprocessor
    {
        ///<inheritdoc/>
        static void OnPostprocessAllAssets(string[] importedAssets, string[] deletedAssets, string[] movedAssets, string[] movedFromAssetPaths, bool didDomainReload)
        {
            if (importedAssets.Length == 1 && movedAssets.Length == 0 && deletedAssets.Length == 0 && movedFromAssetPaths.Length == 0)
            {
                var importedAsset = importedAssets[0];
                var objectGetPrefix = "Object.Get";
                var eventListenerPrefix = "EventListener.";
                var containsObjectGetPrefix = importedAsset.Contains(objectGetPrefix);
                var containsEventListenerPrefix = importedAsset.Contains(eventListenerPrefix);
                if ( containsObjectGetPrefix || containsEventListenerPrefix)
                {
                    var prefix = containsObjectGetPrefix ? objectGetPrefix : eventListenerPrefix;
                    var asset = AssetDatabase.LoadAssetAtPath<ScriptableObject>(importedAsset);
                    var splitAssetNames = asset.name.Split(".");
                    var targetObjectName = splitAssetNames[^2];
                    var targetFolderName = Directory.GetParent(importedAsset).Name;
                    if (targetObjectName != targetFolderName)
                    {
                        Debug.LogWarning($"Incorrect File Location: {Path.GetFileName(importedAsset)}. Refer to visual scripting coding standards for proper {prefix} location.");
                    }
                }
            }
        }
    }
}
