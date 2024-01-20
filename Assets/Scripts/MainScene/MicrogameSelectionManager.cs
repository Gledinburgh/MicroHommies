using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MicrogameSelectionManager : MonoBehaviour
{
    private string[] microgameScenes;
    private int currentMicrogameIndex = 0;
    private GameManager gameManager;

    private void Awake()
    {
        // Assign GameManager instance
        gameManager = GameManager.Instance;
    }


        private void Start()
    {
        // Automatically populate the microgameScenes array with available scenes
        GetAllMicrogameScenes();

        if (microgameScenes.Length > 0)
        {
            // Add logic to visually indicate the selected microgame to the player
            Debug.Log("Selected Microgame: " + microgameScenes[currentMicrogameIndex]);
        }
        else
        {
            Debug.LogError("No microgame scenes found!");
        }
    }

    private void Update()
    {
        HandleMicrogameSelectionInput();
    }

    private void GetAllMicrogameScenes()
    {
        int sceneCount = SceneManager.sceneCountInBuildSettings;
        microgameScenes = new string[sceneCount];

        for (int i = 0; i < sceneCount; i++)
        {
            string scenePath = SceneUtility.GetScenePathByBuildIndex(i);
            string sceneName = System.IO.Path.GetFileNameWithoutExtension(scenePath);
            Debug.Log(sceneName);

            // Check if the scene is a microgame scene (customize this condition based on your scene naming)
            if (sceneName.StartsWith("Microgame"))
            {
                microgameScenes[i] = sceneName;
            }
        }

        // Remove null or empty entries
        microgameScenes = microgameScenes.Where(s => !string.IsNullOrEmpty(s)).ToArray();
    }

    private void HandleMicrogameSelectionInput()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            ShowPreviousMicrogame();
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            ShowNextMicrogame();
        }
        else if (Input.GetKeyDown(KeyCode.Return))
        {
            StartSelectedMicrogame();
        }
    }

    private void ShowNextMicrogame()
    {
        currentMicrogameIndex = (currentMicrogameIndex + 1) % microgameScenes.Length;
        // Add logic to visually indicate the selected microgame to the player
        Debug.Log("Selected Microgame: " + microgameScenes[currentMicrogameIndex]);
    }

    private void ShowPreviousMicrogame()
    {
        currentMicrogameIndex = (currentMicrogameIndex - 1 + microgameScenes.Length) % microgameScenes.Length;
        // Add logic to visually indicate the selected microgame to the player
        Debug.Log("Selected Microgame: " + microgameScenes[currentMicrogameIndex]);
    }

    private void StartSelectedMicrogame()
    {
        string selectedMicrogameScene = microgameScenes[currentMicrogameIndex];
        gameManager.StartMicrogame(selectedMicrogameScene);
    }
}
