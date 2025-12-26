using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(StretchGlobalController))]
public class StretchGlobalControllerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        StretchGlobalController ctrl = (StretchGlobalController)target;

        EditorGUILayout.Space();
        EditorGUILayout.LabelField("Assign Strech Constraint Rig", EditorStyles.boldLabel);
        EditorGUILayout.PropertyField(serializedObject.FindProperty("allRigs"), true);

        EditorGUILayout.Space();
        DrawStretchSection(ctrl);

        EditorGUILayout.Space();
        DrawSquashSection(ctrl);

        EditorGUILayout.Space();
        DrawLimitSection(ctrl);

        EditorGUILayout.Space();
        DrawAxisSection(ctrl);

        EditorGUILayout.Space();
        DrawPresets(ctrl);

        EditorGUILayout.Space();
        DrawResetButton(ctrl);

        serializedObject.ApplyModifiedProperties();
    }

    void DrawStretchSection(StretchGlobalController ctrl)
    {
        EditorGUILayout.LabelField("Stretch Settings", EditorStyles.boldLabel);

        ctrl.enableStretch = EditorGUILayout.Toggle("Enable Stretch", ctrl.enableStretch);
        ctrl.intensity = EditorGUILayout.Slider("Stretch Intensity", ctrl.intensity, 0f, 1f);
    }

    void DrawSquashSection(StretchGlobalController ctrl)
    {
        EditorGUILayout.LabelField("Squash Settings", EditorStyles.boldLabel);

        ctrl.enableSquash = EditorGUILayout.Toggle("Enable Squash", ctrl.enableSquash);
        ctrl.squashAmount = EditorGUILayout.Slider("Squash Amount", ctrl.squashAmount, 0f, 1f);
        ctrl.stretchDistribution = EditorGUILayout.Slider("Distribution", ctrl.stretchDistribution, 0f, 1f);
    }

    void DrawLimitSection(StretchGlobalController ctrl)
    {
        EditorGUILayout.LabelField("Stretch Limits", EditorStyles.boldLabel);

        ctrl.minStretch = EditorGUILayout.FloatField("Min Stretch", ctrl.minStretch);
        ctrl.maxStretch = EditorGUILayout.FloatField("Max Stretch", ctrl.maxStretch);
    }

    void DrawAxisSection(StretchGlobalController ctrl)
    {
        EditorGUILayout.LabelField("Axis Settings", EditorStyles.boldLabel);

        string[] axisOptions = { "X", "Y", "Z" };
        ctrl.ChengeAxisOfStretch_Squash = EditorGUILayout.Popup(
            "Stretch / Squash Axis",
            ctrl.ChengeAxisOfStretch_Squash,
            axisOptions
        );
    }

    void DrawPresets(StretchGlobalController ctrl)
    {
        EditorGUILayout.LabelField("Presets", EditorStyles.boldLabel);

        EditorGUILayout.BeginHorizontal();

        if (GUILayout.Button("Cartoony"))
        {
            ctrl.intensity = 1f;
            ctrl.squashAmount = 1f;
            ctrl.minStretch = 0.8f;
            ctrl.maxStretch = 1.6f;
        }

        if (GUILayout.Button("Realistic"))
        {
            ctrl.intensity = 0.3f;
            ctrl.squashAmount = 0.2f;
            ctrl.minStretch = 0.9f;
            ctrl.maxStretch = 1.1f;
        }

        EditorGUILayout.EndHorizontal();
    }

    void DrawResetButton(StretchGlobalController ctrl)
    {
        EditorGUILayout.Space();

        if (GUILayout.Button("Reset All IK Handle"))
        {
            ctrl.ResetAllPositions();
        }
    }
}
