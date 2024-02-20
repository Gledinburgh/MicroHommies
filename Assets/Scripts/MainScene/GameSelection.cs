using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Linq;
using System;
using System.Collections.Generic;

public class GameSelection : MonoBehaviour
{
    private string[] microgameScenes;
    public List<Image> gameButtons; // Array of buttons representing each microgame
    public int selectedGameIndex = 0; // Index of the currently selected microgame
    private GameManager gameManager;
    private int rows = 3;
    private int columns = 3;
    private float spacing = 10f;

    public Canvas canvas;

    private void Awake()
    {
        gameManager = GameManager.Instance;
        GetAllMicrogameScenes();
        CreateGameSelectionButtons();
    }

    private void CreateGameSelectionButtons()
    {

       
        int currentGameNameIndex = 0;
        if (currentGameNameIndex < microgameScenes.Length - 1)
        {
            for (int row = 0; row < rows; row++)
            {
                    for (int col = 0; col < columns; col++)
                    {
                        if (currentGameNameIndex < microgameScenes.Length)
                        {
                        // Calculate position based on row and column indices
                        float xPos = col * (spacing + 100f);  // Adjust for image width
                        float yPos = -row * (spacing + 100f); // Adjust for image height

                        // Create a new GameObject to hold the Image
                        GameObject imageObject = new GameObject(microgameScenes[currentGameNameIndex]);
                        RectTransform rectTransform = imageObject.AddComponent<RectTransform>();

                        // Set the position
                        rectTransform.anchoredPosition = new Vector2(xPos, yPos);

                        // Attach an Image component to the GameObject
                        Image imageComponent = imageObject.AddComponent<Image>();
                        gameButtons.Add(imageComponent);

                        // Set the desired sprite for the Image (replace "YourSprite" with your actual sprite)
                        //imageComponent.sprite = YourSprite;

                        // Set other Image properties if needed
                        imageComponent.color = Color.white; // Example: Set the color to white

                        // Attach the GameObject to a Canvas or another UI element
                        // This assumes there's a Canvas in the scene; adjust as needed
                        imageObject.transform.SetParent(canvas.transform, false);

                        GameObject textObject = new GameObject("Text");
                        Text textComponent = textObject.AddComponent<Text>();

                        // Set the text content (you may want to replace this with your actual text)
                        textComponent.text = microgameScenes[currentGameNameIndex];

                        // Set the font, color, size, etc., for the Text component as needed
                        textComponent.font = Font.CreateDynamicFontFromOSFont("Arial", 200);
                        textComponent.color = Color.black;
                        textObject.transform.SetParent(imageObject.transform, false);


                        currentGameNameIndex += 1;
                    }
                }
            }
        }
    }

    void Start()
    {
        UpdateSelectionVisual(); // Highlight the initially selected microgame
    }

    void Update()
    {
        // Handle input to navigate through microgames
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            SelectPreviousGame();
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            SelectNextGame();
        }
        else if (Input.GetKeyDown(KeyCode.Return))
        {
            // Player confirmed selection, load microgame scene
            LoadMicrogameScene();
        }
      
    }

    

    void SelectPreviousGame()
    {
        selectedGameIndex = (selectedGameIndex - 1 + gameButtons.Count) % gameButtons.Count;
        UpdateSelectionVisual();
    }

    void SelectNextGame()
    {
        selectedGameIndex = (selectedGameIndex + 1) % gameButtons.Count;
        UpdateSelectionVisual();
    }

    void UpdateSelectionVisual()
    {
        // Update visual representation of selection (e.g., highlight selected button)
        // You can customize this based on your UI design
        for (int i = 0; i < gameButtons.Count; i++)
        {
            bool isSelected = (i == selectedGameIndex);
            // Customize based on your UI design
            gameButtons[i].color = isSelected ? Color.yellow : Color.white;
        }
    }

    void LoadMicrogameScene()
    {
        // Load the scene corresponding to the selected microgame
        string sceneName = microgameScenes[selectedGameIndex]; // Adjust scene naming convention
        gameManager.StartMicrogame(sceneName);
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
}
