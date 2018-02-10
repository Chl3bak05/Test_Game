using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Camera_Behaviour))]
public class Camera_Follow_Editor : Editor {

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        Camera_Behaviour cf= (Camera_Behaviour)target;

        if (GUILayout.Button("Set Min Cam Pos"))
        {
            cf.Set_Min_Cam_Position();
        }

        if (GUILayout.Button("Set Max Cam Pos"))
        {
            cf.Set_Max_Cam_Position();
        }
    }
}
