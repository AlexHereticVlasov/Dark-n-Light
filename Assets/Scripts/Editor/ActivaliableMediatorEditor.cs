using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(ActivaliableMediator))]
public class ActivaliableMediatorEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        var mediator = (ActivaliableMediator)target;
        if (GUILayout.Button(nameof(mediator.Recolor)))
            mediator.Recolor();
    }
}

[CustomEditor(typeof(LightBridge))]
public sealed class LightBridgeEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        var lightBridge = (LightBridge)target;
        if (GUILayout.Button(nameof(lightBridge.Recolor)))
            lightBridge.Recolor();
    }
}
