using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(LeverMidiator))]
public class LeverMediatorEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        var mediator = (LeverMidiator)target;
        if (GUILayout.Button(nameof(mediator.Recolor)))
            mediator.Recolor();
    }
}

[CustomEditor(typeof(DiamondViev))]
public class DiamondVievEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        var view = (DiamondViev)target;
        if (GUILayout.Button(nameof(view.Recolor)))
            view.Recolor();
    }
}

[CustomEditor(typeof(DestructableBlockView))]
public class DestructableBlockViewEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        var view = (DestructableBlockView)target;
        if (GUILayout.Button(nameof(view.Recolor)))
            view.Recolor();
    }
}

[CustomEditor(typeof(DangerZoneView))]
public class DangerZoneViewEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        var view = (DangerZoneView)target;
        if (GUILayout.Button(nameof(view.Recolor)))
            view.Recolor();
    }
}