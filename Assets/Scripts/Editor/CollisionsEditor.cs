using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Collisions))]
public class CollisionsEditor : Editor
{
    bool showProperties = false;
    bool showInspector = false;

    public override void OnInspectorGUI()
    {
        Collisions inspector = (Collisions)target;
        GUIStyle myStyle = EditorStyles.boldLabel;
        GUIStyle myToolbar = EditorStyles.toolbarDropDown;

        showInspector = EditorGUILayout.Foldout(showInspector, "Inspector", true, myToolbar);
        if (showInspector)
        {
            GUI.backgroundColor = showInspector ? Color.black : Color.white;

            EditorGUILayout.BeginVertical(EditorStyles.textField);
            GroundChecks(myStyle, inspector);
            EditorGUI.indentLevel = 0;
            myStyle.normal.textColor = Color.clear;
            EditorGUILayout.LabelField("------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------");
            WallChecks(myStyle, inspector);
            EditorGUI.indentLevel = 0;
            myStyle.normal.textColor = Color.white;

            EditorGUILayout.LabelField("------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------");
            CellingChecks(myStyle, inspector);
            EditorGUI.indentLevel = 0;
            myStyle.normal.textColor = Color.white;
            EditorGUILayout.LabelField("------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------");
            GeneralCheck(myStyle, inspector);

            EditorGUILayout.EndVertical();
            GUI.backgroundColor = showInspector ? Color.white : Color.white;
        }

        showProperties = EditorGUILayout.Foldout(showProperties, "Properties", true, EditorStyles.toolbarDropDown);
        if (showProperties)
        {
            base.OnInspectorGUI();
        }

    }

    public void GroundChecks(GUIStyle myStyle, Collisions inspector)
    {
        if (inspector.isGrounded) myStyle.normal.textColor = Color.green;
        else myStyle.normal.textColor = Color.red;
        EditorGUILayout.LabelField("IsGrounded", myStyle);

        EditorGUI.indentLevel = 1;
        if (inspector.wasGroundedLastFrame) myStyle.normal.textColor = Color.green;
        else myStyle.normal.textColor = Color.red;
        EditorGUILayout.LabelField("WasGroundedLastFrame", myStyle);

        if (inspector.justNotGrounded) myStyle.normal.textColor = Color.green;
        else myStyle.normal.textColor = Color.red;
        EditorGUILayout.LabelField("JustNotGrounded", myStyle);

        if (inspector.justGotGrounded) myStyle.normal.textColor = Color.green;
        else myStyle.normal.textColor = Color.red;
        EditorGUILayout.LabelField("JustGotGrounded", myStyle);
    }

    public void WallChecks(GUIStyle myStyle, Collisions inspector)
    {
        EditorGUI.indentLevel = 0;
        if (inspector.isWalled) myStyle.normal.textColor = Color.green;
        else myStyle.normal.textColor = Color.red;
        EditorGUILayout.LabelField("IsWalled", myStyle);

        EditorGUI.indentLevel = 1;
        if (inspector.wasWalledLastFrame) myStyle.normal.textColor = Color.green;
        else myStyle.normal.textColor = Color.red;
        EditorGUILayout.LabelField("WasWalledLastFrame", myStyle);

        if (inspector.justNotWalled) myStyle.normal.textColor = Color.green;
        else myStyle.normal.textColor = Color.red;
        EditorGUILayout.LabelField("JustNotWalled", myStyle);

        if (inspector.justGotWalled) myStyle.normal.textColor = Color.green;
        else myStyle.normal.textColor = Color.red;
        EditorGUILayout.LabelField("JustGotWalled", myStyle);
    }

    public void CellingChecks(GUIStyle myStyle, Collisions inspector)
    {
        EditorGUI.indentLevel = 0;
        if (inspector.isCellinged) myStyle.normal.textColor = Color.green;
        else myStyle.normal.textColor = Color.red;
        EditorGUILayout.LabelField("IsCellinged", myStyle);

        EditorGUI.indentLevel = 1;
        if (inspector.wasCeilingedLastFrame) myStyle.normal.textColor = Color.green;
        else myStyle.normal.textColor = Color.red;
        EditorGUILayout.LabelField("WasCeilingedLastFrame", myStyle);

        if (inspector.justNotCellinged) myStyle.normal.textColor = Color.green;
        else myStyle.normal.textColor = Color.red;
        EditorGUILayout.LabelField("JustNotCeilinged", myStyle);

        if (inspector.justGotCellinged) myStyle.normal.textColor = Color.green;
        else myStyle.normal.textColor = Color.red;
        EditorGUILayout.LabelField("JustGotCeilinged", myStyle);
    }

    public void GeneralCheck(GUIStyle myStyle, Collisions inspector)
    {

        EditorGUI.indentLevel = 0;
        if (inspector.isFalling) myStyle.normal.textColor = Color.blue;
        else myStyle.normal.textColor = Color.yellow;
        EditorGUILayout.LabelField("IsFalling", myStyle);

        EditorGUI.indentLevel = 0;
        if (inspector.checkGround) myStyle.normal.textColor = Color.blue;
        else myStyle.normal.textColor = Color.yellow;
        EditorGUILayout.LabelField("CheckGround", myStyle);

        if (inspector.checkWall) myStyle.normal.textColor = Color.blue;
        else myStyle.normal.textColor = Color.yellow;
        EditorGUILayout.LabelField("CheckWall", myStyle);

        if (inspector.checkCelling) myStyle.normal.textColor = Color.blue;
        else myStyle.normal.textColor = Color.yellow;
        EditorGUILayout.LabelField("CheckCelling", myStyle);
    }
}
