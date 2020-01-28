using System;
using System.Collections.Generic;
using EyeClops.Internals;
using EyeClops.Manager;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

namespace EyeClops.Controller
{
    public class DeserializationController : MonoBehaviour
    {
        [SerializeField] private Dropdown fileIdentifiers;
        [SerializeField] private Button readSpecificFileButton;
        [SerializeField] private Button readAllFilesButton;
        
        private string _folderPath;
        private Dictionary<string, List<string>> _fileIdAndTypeMap;

        private void Start()
        {
            EnableReadFileButtons(false);
        }

        public void SelectFolderWithStoredData()
        {
//            _folderPath = EditorUtility.OpenFolderPanel("Select the stored folder of the EyeClops data", "", "");
            DeserializationManager.Instance.SetStoredFolder(_folderPath);
            //TODO: activate the other buttons just after this function was used!!!
            fileIdentifiers.options = new List<Dropdown.OptionData>();
            List<string> fileIdentifier = GenerateFileIdentifier();
            if (fileIdentifier != null)
            {
                fileIdentifiers.AddOptions(fileIdentifier);
            }

            EnableReadFileButtons(true);
        }

        private void EnableReadFileButtons(bool enableButton)
        {
            readSpecificFileButton.enabled = enableButton;
            readAllFilesButton.enabled = enableButton;
        }

        public void DeserializeSingleDataSet()
        {
            if (_fileIdAndTypeMap != null)
            {
                foreach (string fileEnding in _fileIdAndTypeMap[fileIdentifiers.itemText.text])
                {
                    DeserializationManager.Instance.DeserializeSingleDataSet(_folderPath, fileIdentifiers.itemText.text,
                        fileEnding);
                }
            }
        }

        public void DeserializeAllDataSets()
        {
            foreach (KeyValuePair<string, List<string>> identifierAndEnding in _fileIdAndTypeMap)
            {
                foreach (string fileEnding in identifierAndEnding.Value)
                {
                    DeserializationManager.Instance.DeserializeSingleDataSet(_folderPath, identifierAndEnding.Key,
                        fileEnding);
                }
            }
        }

        public void DeserializeBunchOfFiles()
        {
            //TODO: find a possibility for multi selection
        }

        public void RestAllDeserializedData()
        {
            DeserializationManager.Instance.ResetDeserializedData();
        }

        private List<string> GenerateFileIdentifier()
        {
            List<string> fileEnds = new List<string> {FileEndings.Csv, FileEndings.Binary};
            DeserializationManager.Instance.GenerateIdentifierAndFileEndingMap(_folderPath, out _fileIdAndTypeMap);
            List<string> list = new List<string>();

            if (_fileIdAndTypeMap.Count > 0)
            {
                foreach (string identifier in _fileIdAndTypeMap.Keys)
                {
                    list.Add(identifier);
                }
            }
            else
            {
                //TODO: Delete, because this would not work in the later work
                for (int i = 0; i < 11; i++)
                {
                    string item = "Error: " + i;
                    list.Add(item);
                    _fileIdAndTypeMap.Add(item, fileEnds);
                }
            }
            return list;
        }
    }
}