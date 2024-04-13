using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEditor;
using System.Net.NetworkInformation;

namespace MyTools {
    public class MassRenamer_Editor : EditorWindow //this launches a window when we click menu item
    {
        #region Variables
        GameObject[] selected = new GameObject[0];
        string new_Prefix;
        string new_Suffix;
        string new_Name;
        bool addNumber;

        #endregion

        #region Builtin Methods
        public static void LaunchRenamer()
        {
            var win = GetWindow<MassRenamer_Editor>(); //get window is included in Editor class
            GUIContent content = new GUIContent("Rename Objects");
            win.titleContent = content;
            win.Show();

        }

        private void OnGUI()
        {
            //Get current selected objects 
            selected = Selection.gameObjects;

            EditorGUILayout.LabelField("Selected: " + selected.Length.ToString("000"));
            //Display our User UI
            EditorGUILayout.BeginHorizontal();
            GUILayout.Space(10);

            EditorGUILayout.BeginVertical(); // w/o this, buttom would appear on the side not the bottom
            GUILayout.Space(10);

            EditorGUILayout.BeginVertical(EditorStyles.helpBox);
            GUILayout.Space(10);
            new_Prefix = EditorGUILayout.TextField("Prefix: ", new_Prefix, EditorStyles.miniTextField, GUILayout.ExpandWidth(true));
            new_Name = EditorGUILayout.TextField("Name: ", new_Name, EditorStyles.miniTextField, GUILayout.ExpandWidth(true));
            new_Suffix = EditorGUILayout.TextField("Suffix: ", new_Suffix, EditorStyles.miniTextField, GUILayout.ExpandWidth(true));
            addNumber = EditorGUILayout.Toggle("Add Numbering? ", addNumber);
            GUILayout.Space(10);
            EditorGUILayout.EndVertical(); //always need to close vertical/horizontal layout

          
            if (GUILayout.Button("Rename Selected Objects", GUILayout.Height(45), GUILayout.ExpandHeight(true)))
            {
                RenameObjects();
            }
            GUILayout.Space(10);
            EditorGUILayout.EndVertical();

            GUILayout.Space(10);
            EditorGUILayout.EndHorizontal();

            Repaint();
        }
        #endregion

        #region Custom Method
        void RenameObjects()
        {
            Array.Sort(selected, delegate (GameObject objA, GameObject objB) { return objA.name.CompareTo(objB.name); }); //sorts array alphabetically no matter order selected

            for (int i = 0; i < selected.Length; i++)
            {
                string finalName = string.Empty;
                if (new_Prefix.Length > 0)
                {
                    finalName += new_Prefix;
                }


                if (new_Name.Length > 0)
                {
                    finalName += "_" + new_Name;
                }

                if (new_Suffix.Length > 0)
                {
                    finalName += "_" + new_Suffix;
                }
                if (addNumber)
                {
                    finalName += "_" + i.ToString("000");
                }
                selected[i].name = finalName;
                    }
        }
        #endregion

    }
}


