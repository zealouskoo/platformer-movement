using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(PlayerMovement))]
public class PlayerMovementEditor : Editor
{
    //Debugs
    SerializedProperty m_MoveInputLineLengthProp;

    //CHECK PARAMETERS PROPERTY
    SerializedProperty m_groundCheckPointProp;
    SerializedProperty m_groundCheckSizeProp;
    SerializedProperty m_frontWallCheckPointProp;
    SerializedProperty m_backWallCheckPointProp;
    SerializedProperty m_wallCheckSizeProp;

    SerializedProperty m_groundLayerProp;

    readonly GUIContent m_MoveInputLineLengthContent = new GUIContent("Input Direction Length");

    #region GUIContents
    //Debugs
    readonly GUIContent m_groundCheckPointContent = new GUIContent("Ground CheckPoint");
    readonly GUIContent m_groundCheckSizeContent = new GUIContent("Ground CheckSize");
    readonly GUIContent m_frontWallCheckPointContent = new GUIContent("Front Wall CheckPoint");
    readonly GUIContent m_backWallCheckPointContent = new GUIContent("Back Wall CheckPoint");
    readonly GUIContent m_wallCheckSizeContent = new GUIContent("Wall Check Size");

    //Grounds & Layers
    readonly GUIContent m_groundLayerContent = new GUIContent("Ground Layer"); 
    #endregion

    //Foldout Parameters
    bool m_DebugsFoldout;
    bool m_ChecksFoldout;
    bool m_LayersTagsFoldout;

    readonly GUIContent m_DebugsContent = new GUIContent("Debugs");
    readonly GUIContent m_ChecksContent = new GUIContent("Checks");
    readonly GUIContent m_LayersTagsContent = new GUIContent("Layers & Tags");

    private void OnEnable() {
        m_MoveInputLineLengthProp = serializedObject.FindProperty("MoveInputLineLength");

        m_groundCheckPointProp = serializedObject.FindProperty("_groundCheckPoint");
        m_groundCheckSizeProp = serializedObject.FindProperty("_groundCheckSize");
        m_frontWallCheckPointProp = serializedObject.FindProperty("_frontWallCheckPoint");
        m_backWallCheckPointProp = serializedObject.FindProperty("_backWallCheckPoint");
        m_wallCheckSizeProp = serializedObject.FindProperty("_wallCheckSize");

        m_groundLayerProp = serializedObject.FindProperty("_groundLayer");


    }

    public override void OnInspectorGUI() {
        serializedObject.Update();

        #region Debugs
        EditorGUILayout.BeginVertical(GUI.skin.box);
        EditorGUI.indentLevel++;

        m_DebugsFoldout = EditorGUILayout.Foldout(m_DebugsFoldout, m_DebugsContent);

        if (m_DebugsFoldout) {
            EditorGUILayout.PropertyField(m_MoveInputLineLengthProp, m_MoveInputLineLengthContent);
        }

        EditorGUI.indentLevel--;
        EditorGUILayout.EndVertical();
        #endregion

        #region Checks
        EditorGUILayout.BeginVertical(GUI.skin.box);
        EditorGUI.indentLevel++;

        m_ChecksFoldout = EditorGUILayout.Foldout(m_ChecksFoldout, m_ChecksContent);

        if (m_ChecksFoldout) {
            EditorGUILayout.PropertyField(m_groundCheckPointProp, m_groundCheckPointContent);
            EditorGUILayout.PropertyField(m_groundCheckSizeProp, m_groundCheckSizeContent);
            EditorGUILayout.PropertyField(m_frontWallCheckPointProp, m_frontWallCheckPointContent);
            EditorGUILayout.PropertyField(m_backWallCheckPointProp, m_backWallCheckPointContent);
            EditorGUILayout.PropertyField(m_wallCheckSizeProp, m_wallCheckSizeContent);
        }

        EditorGUI.indentLevel--;
        EditorGUILayout.EndVertical();
        #endregion

        #region LAYERS & TAGS
        EditorGUILayout.BeginVertical(GUI.skin.box);
        EditorGUI.indentLevel++;

        m_LayersTagsFoldout = EditorGUILayout.Foldout(m_LayersTagsFoldout, m_LayersTagsContent);

        int i=0;
        if (m_LayersTagsFoldout) {
            EditorGUILayout.PropertyField(m_groundLayerProp, m_groundLayerContent);
        }

        EditorGUI.indentLevel--;
        EditorGUILayout.EndVertical();
        #endregion
    }
}
