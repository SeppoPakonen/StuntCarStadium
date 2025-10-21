using UnityEngine;
using UnityEditor;
using UnityEditor.Build.Reporting;
using UnityEditor.Build;
using System.IO;

public class BuildScript
{
    [MenuItem("Build/Build Linux Standalone")]
    public static void PerformBuild()
    {
        // Get the build path (relative to project directory)
        // For Linux builds, we need to specify the executable name, not a directory
        string buildPath = Path.Combine(Directory.GetCurrentDirectory(), "Builds", "LinuxStandalone");
        
        // Remove existing directory if it exists
        string buildDir = Path.GetDirectoryName(buildPath);
        string exeName = Path.GetFileName(buildPath);
        string dataDir = Path.Combine(buildDir, exeName + "_Data");
        
        // Clean up any existing build files/directories
        if (Directory.Exists(dataDir))
        {
            Directory.Delete(dataDir, true);
        }
        
        if (File.Exists(buildPath))
        {
            File.Delete(buildPath);
        }
        
        // Create build directory if it doesn't exist
        Directory.CreateDirectory(buildDir);
        
        // Set scripting backend to IL2CPP
        PlayerSettings.SetScriptingBackend(BuildTargetGroup.Standalone, ScriptingImplementation.IL2CPP);
        Debug.Log("Using IL2CPP scripting backend");
        
        // Create BuildPlayerOptions with scenes
        BuildPlayerOptions buildPlayerOptions = new BuildPlayerOptions();
        buildPlayerOptions.scenes = GetScenePaths();
        buildPlayerOptions.locationPathName = buildPath;
        buildPlayerOptions.target = BuildTarget.StandaloneLinux64;
        buildPlayerOptions.options = BuildOptions.None;
        
        Debug.Log("Starting build with IL2CPP scripting backend.");
        
        BuildReport report = BuildPipeline.BuildPlayer(buildPlayerOptions);
        BuildSummary summary = report.summary;
        
        if (summary.result == BuildResult.Succeeded)
        {
            Debug.Log("Build succeeded: " + summary.totalSize + " bytes");
            Debug.Log("Build path: " + buildPath);
            Debug.Log("Scripting backend: IL2CPP");
        }
        else if (summary.result == BuildResult.Failed)
        {
            Debug.LogError("Build failed.");
        }
        else if (summary.result == BuildResult.Cancelled)
        {
            Debug.LogWarning("Build cancelled.");
        }
        else
        {
            Debug.LogWarning("Build completed with warnings: " + summary.totalErrors + " errors, " + summary.totalWarnings + " warnings");
        }
    }

    private static string[] GetScenePaths()
    {
        // Get all enabled scenes in build settings
        EditorBuildSettingsScene[] scenes = EditorBuildSettings.scenes;
        if (scenes.Length == 0)
        {
            Debug.Log("No scenes found in build settings. Scanning Assets folder for .unity files.");
            
            // Find all scene files automatically
            string[] sceneGUIDs = AssetDatabase.FindAssets("t:Scene", new string[] { "Assets" });
            if (sceneGUIDs.Length > 0)
            {
                System.Collections.Generic.List<string> scenePaths = new System.Collections.Generic.List<string>();
                foreach (string guid in sceneGUIDs)
                {
                    string scenePath = AssetDatabase.GUIDToAssetPath(guid);
                    scenePaths.Add(scenePath);
                    Debug.Log("Found scene: " + scenePath);
                }
                return scenePaths.ToArray();
            }
            else
            {
                Debug.LogError("No scenes found in the project. Cannot build.");
                return new string[0];
            }
        }
        else
        {
            // Use scenes from build settings
            string[] scenePaths = new string[scenes.Length];
            for (int i = 0; i < scenes.Length; i++)
            {
                if (scenes[i].enabled)
                {
                    scenePaths[i] = scenes[i].path;
                }
            }
            return scenePaths;
        }
    }
}