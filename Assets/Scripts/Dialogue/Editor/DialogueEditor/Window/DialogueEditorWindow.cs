using System;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

public class DialogueEditorWindow : EditorWindow
{
    private const string filePath = "Assets/Dialogues/";
    private const string windowName = "Dialogue Editor";
    private string fileName = "NewDialogue";
    private DialogueGraphView graphView;
    private bool isDirty = false;
    private bool isNewFile = true;
    private Label fileNameLabel;
    [MenuItem("Tools/DialogueEditor")]
    public static void Example()
    {
        GetWindow<DialogueEditorWindow>(windowName);
    }

    public void CreateGUI()
    {
        AddGraphView();
        AddToolbar();
    }

    private void AddToolbar()
    {
        Toolbar toolbar = new Toolbar();
        
        fileNameLabel = new Label() 
        {
            text = this.fileName,
        };

        Button saveButton = new Button() 
        {
            text = "Save"
        };
        saveButton.clicked += SaveGraph;
        Button openFileButton = new Button()
        {
            text = "Open"
        };
        openFileButton.clicked += LoadGraph;
        Button mapButton = new Button()
        {
            text = "Map"
        };
        mapButton.clicked += graphView.ToggleMiniMap;
        
        toolbar.Add(fileNameLabel);
        toolbar.Add(saveButton);
        toolbar.Add(openFileButton);
        toolbar.Add(mapButton);
        rootVisualElement.Add(toolbar);
    }

    private void AddGraphView()
    {
        graphView = new DialogueGraphView();
        graphView.StretchToParentSize();
        rootVisualElement.Add(graphView);
        graphView.graphViewChanged += (GraphViewChange change) => { SetDirty(true); return change; };
    }

    private void SaveGraph()
    {
        DialogueData data = ScriptableObject.CreateInstance<DialogueData>();

        if (isNewFile)
        {
            string path = EditorUtility.SaveFilePanelInProject("Save Dialogue File", fileName, "asset", "Choose folder for saving the Dialogue");
            Debug.Log(path);


            if (!string.IsNullOrEmpty(path))
            {
                fileName = Path.GetFileNameWithoutExtension(path);
                isNewFile = false;
                fileNameLabel.text = fileName;
            }
            else
            {
                return;
            }

        }

        data.nodes = new List<BaseNodeData>();
        foreach (BaseGraphNode node in graphView.nodes)
        {
            data.nodes.Add(node.Serialize());
        }

        System.IO.Directory.CreateDirectory(filePath);

        AssetDatabase.CreateAsset(data, filePath + fileName + ".asset");
        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();

        SetDirty(false);
    }

    private void LoadGraph()
    {
        
        string path = EditorUtility.OpenFilePanel("Select Dialogue File", filePath, "asset");

        if (string.IsNullOrEmpty(path))
            return;

        fileName = Path.GetFileNameWithoutExtension(path);
        fileNameLabel.text = fileName;

        if (!path.StartsWith(Application.dataPath))
        {
            Debug.LogError("Selected file must be inside the Assets folder.");
            return;
        }
        string relativePath =
        "Assets" + path.Substring(Application.dataPath.Length);

        Debug.Log(relativePath);

        DialogueData dialogueData = AssetDatabase.LoadAssetAtPath<DialogueData>(relativePath);
        ClearGraph();

        foreach (BaseNodeData node in dialogueData.nodes)
        {
            graphView.AddElement(graphView.CreateNode(node));
        }

        graphView.CreateEdges();

        isNewFile = false;
        SetDirty(false);
    }

    public void ClearGraph()
    {
        graphView.DeleteElements(graphView.graphElements.ToList());
        graphView.nodeInfo.Clear();
    }

    public void SetDirty(bool value)
    {
        if (value)
        {
            titleContent.text = windowName + " *";
        }
        else
        {
            titleContent.text = windowName;
        }
        isDirty = value;
    }

    private void OnDestroy()
    {
        if (!isDirty) return;

        bool save = EditorUtility.DisplayDialog(
            "Unsaved Dialogue Graph",
            "You have unsaved changes. Save before closing?",
            "Save",
            "Discard"
        );

        if (save)
            SaveGraph();
    }
}
