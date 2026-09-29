using UnityEditor;
using UnityEditor.ShortcutManagement;
using UnityEngine;

public static class SceneViewShortcuts
{
    // This maps the shortcut to the '5' key on your Numpad
    [Shortcut("Scene View Camera - Perspective Switch", KeyCode.Alpha5)]
    static void TogglePerspCamera()
    {
        if (SceneView.lastActiveSceneView != null)
        {
            SceneView.lastActiveSceneView.orthographic = !SceneView.lastActiveSceneView.orthographic;
        }
    }
}
