//*****************************************************************************
// Author: Arthur LeVesque
// Copyright: OnChain Studios, 2023
//*****************************************************************************

using System.IO;
using Unity.VisualScripting;

namespace OnChainStudios.FileTemplates
{
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
                if (importedAsset.Contains("Object.Get.") || importedAsset.Contains("EventListener."))
                {
                    var asset = AssetDatabase.LoadAssetAtPath<ScriptableObject>(importedAsset);
                    Debug.LogWarning($"MAKE SURE YOU PUT THIS FILE IN THE RIGHT SUBFOLDER: " + Path.GetFileName(importedAsset));
                }
            }
        }
    }
}
