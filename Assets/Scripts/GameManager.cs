using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    private string currentSceneName;
    private string[] microgameScenes;
    public int selectedGameIndex = 0;


    public int totalScore = 0;
    public bool isStoryMode = true;

    public static GameManager Instance
    {
        get
        {
            // If the instance is null, try to find it in the scene
            if (instance == null)
            {
                instance = FindObjectOfType<GameManager>();

                // If not found, create a new GameObject with GameManager attached
                if (instance == null)
                {
                    GameObject singletonObject = new GameObject("GameManager");
                    instance = singletonObject.AddComponent<GameManager>();
                }
            }

            return instance;
        }
    }

    // Optional: Add other GameManager methods and properties here

    private void Awake()
    {
        // Ensure there's only one instance
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject); // Optional: Keep the GameManager across scene changes
        }
    }

    // Your GameManager logic goes here

    // Example method
    public void Initialize()
    {
        Debug.Log("GameManager Initialized");
    }


private void Start()
    {
        GetAllMicrogameScenes();
        LoadShortScene();
    }

    public void LoadMainScene()
    {
       // loads the main menu scene where the player can select microgames.
       SceneManager.LoadScene("MainScene");
       currentSceneName = "MainScene";
    }

    public void LoadShortScene()
    {
        SceneManager.LoadScene("IntroScene");
        currentSceneName = "IntroScene";
    }

    public void StartMicrogame(string microgameSceneName)
    {
        // It loads the specified microgame scene.
        currentSceneName = microgameSceneName;
        Debug.Log("SetCurrentSceneName" + currentSceneName);
        SceneManager.LoadScene(microgameSceneName);
    }

    public void EndMicrogame(int microgameScore)
    {
        Debug.Log("End Microgame");
        Debug.Log("SceneName To End" + currentSceneName);
        totalScore += microgameScore;
        SceneManager.UnloadSceneAsync(currentSceneName);
        if (isStoryMode == false)
        {
        LoadMainScene();
        }
        else
        {
            SelectNextGame();
            StartMicrogame(currentSceneName);            
        }
    }

    public int GetTotalScore()
    {
        //method allows other scripts to retrieve the total score.
        return totalScore;
    }

    private void GetAllMicrogameScenes()
    {
        int sceneCount = SceneManager.sceneCountInBuildSettings;
        microgameScenes = new string[sceneCount];

        for (int i = 0; i < sceneCount; i++)
        {
            string scenePath = SceneUtility.GetScenePathByBuildIndex(i);
            string sceneName = System.IO.Path.GetFileNameWithoutExtension(scenePath);


            // Check if the scene is a microgame scene (customize this condition based on your scene naming)
            if (sceneName.StartsWith("Microgame"))
            {
                microgameScenes[i] = sceneName;
            }
        }

        // Remove null or empty entries
        microgameScenes = microgameScenes.Where(s => !string.IsNullOrEmpty(s)).ToArray();
    }

    void SelectNextGame()
    {
        selectedGameIndex = (selectedGameIndex + 1);
        currentSceneName = microgameScenes[selectedGameIndex];
    }

}

