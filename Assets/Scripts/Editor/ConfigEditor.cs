using UnityEditor;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;

namespace Assets.Scripts
{
    public abstract class ConfigEditor<T> : Editor where T : Data
    {
        protected Config<T> _data;
        
        private void Awake()
        {
            _data = (Config<T>)target;
        }

        public override void OnInspectorGUI()
        {
            GUILayout.BeginHorizontal();
            
            if(GUILayout.Button("Add"))
                _data.AddElement();

            if(GUILayout.Button("Remove"))
                _data.RemoveCurrentElement();

            if(GUILayout.Button("Left"))
                _data.GetPrevious();
            
            if(GUILayout.Button("Right"))
                _data.GetNext();


            GUILayout.EndHorizontal();
                
            
            base.OnInspectorGUI();
        }
    }
}