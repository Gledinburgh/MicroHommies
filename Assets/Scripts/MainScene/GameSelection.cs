using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameSelection : MonoBehaviour
{
    public Image[] gameButtons; // Array of buttons representing each microgame
    public int selectedGameIndex = 0; // Index of the currently selected microgame
    private GameManager gameManager;

    private void Awake()
    {
        gameManager = GameManager.Instance;
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
        selectedGameIndex = (selectedGameIndex - 1 + gameButtons.Length) % gameButtons.Length;
        UpdateSelectionVisual();
    }

    void SelectNextGame()
    {
        selectedGameIndex = (selectedGameIndex + 1) % gameButtons.Length;
        UpdateSelectionVisual();
    }

    void UpdateSelectionVisual()
    {
        // Update visual representation of selection (e.g., highlight selected button)
        // You can customize this based on your UI design
        for (int i = 0; i < gameButtons.Length; i++)
        {
            bool isSelected = (i == selectedGameIndex);
            // Customize based on your UI design
            gameButtons[i].color = isSelected ? Color.yellow : Color.white;
        }
    }

    void LoadMicrogameScene()
    {
        // Load the scene corresponding to the selected microgame
        string sceneName = "Microgame" + selectedGameIndex; // Adjust scene naming convention
        gameManager.StartMicrogame(sceneName);
    }
}
