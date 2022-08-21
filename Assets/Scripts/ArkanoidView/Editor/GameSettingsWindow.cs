using System;
using ArkanoidView.Utils;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ArkanoidView.Editor
{
    public class GameSettingsWindow : EditorWindow
    {
        private const int SettingsSceneIndex = 1;
        
        private GameViewInstaller _gameViewInstaller;
        private GameSettings _asset;
        private SerializedObject _serializedObject;
        private bool _inSettingsScene = true;

        public GameSettingsWindow()
        {
            titleContent.text = "Game Settings";
        }
        
        [MenuItem ("Window/Game Settings")]
        public static void  ShowWindow () {
            GetWindow(typeof(GameSettingsWindow));
        }

        private void OnBecameVisible()
        {
            EditorSceneManager.activeSceneChangedInEditMode += OnSceneChanged;
            Init();
        }

        private void OnBecameInvisible()
        {
            EditorSceneManager.activeSceneChangedInEditMode -= OnSceneChanged;
        }

        private void OnSceneChanged(Scene from, Scene to)
        {
            Init();
        }

        private void Init()
        {
            _inSettingsScene = SceneManager.GetActiveScene().buildIndex == SettingsSceneIndex;
            if (!_inSettingsScene)
            {
                return;
            }
            
            _gameViewInstaller = FindObjectOfType<GameViewInstaller>();
            _asset = _gameViewInstaller.GameSettings;

            if (_asset)
            {
                _serializedObject = new SerializedObject(_asset);
            }
        }

        private void OnGUI()
        {
            if (!_inSettingsScene)
            {
                EditorGUILayout.LabelField("To edit game settings open GameScene");
                if (GUILayout.Button("Open GameScene"))
                {
                    EditorSceneManager.OpenScene(SceneUtility.GetScenePathByBuildIndex(SettingsSceneIndex));
                }
                
                return;
            }
            
            _asset = (GameSettings) EditorGUILayout.ObjectField("Current settings asset", _asset, 
                typeof(GameSettings), false);
            
            if (_gameViewInstaller.GameSettings != _asset)
            {
                _gameViewInstaller.GameSettings = _asset;
                
                if (_asset)
                {
                    _serializedObject = new SerializedObject(_asset);
                }
            }
            
            if (!_asset)
            {
                return;
            }
            
            DrawDefaultInspector(_serializedObject);
        }
        
        private static void DrawDefaultInspector(SerializedObject obj)
        {
            EditorGUI.BeginChangeCheck();
            obj.UpdateIfRequiredOrScript();
            
            var iterator = obj.GetIterator();
            for (var enterChildren = true; iterator.NextVisible(enterChildren); enterChildren = false)
            {
                using (new EditorGUI.DisabledScope("m_Script" == iterator.propertyPath))
                {
                    EditorGUILayout.PropertyField(iterator, true);
                }
            }
            
            obj.ApplyModifiedProperties();
            EditorGUI.EndChangeCheck();
        }
    }
}