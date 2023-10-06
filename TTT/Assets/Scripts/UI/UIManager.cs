using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class UIManager : MonoBehaviour
{
    public enum UICanvas
    {
        MainMenu,
        Settings,
        Tutorial,
        Credits,
        Learn
    }

    private Dictionary<UICanvas, GameObject> canvases = new Dictionary<UICanvas, GameObject>();

    private void Start()
    {
        canvases.Add(UICanvas.MainMenu, mainMenuCanvas);
        canvases.Add(UICanvas.Settings, settingsCanvas);
        canvases.Add(UICanvas.Tutorial, tutorialCanvas);
        canvases.Add(UICanvas.Credits, creditsCanvas);
        canvases.Add(UICanvas.Learn, learnCanvas);

        ActivateCanvas(UICanvas.MainMenu);
    }

    public void ActivateCanvas(UICanvas canvasToActivate)
    {
        foreach (var canvas in canvases)
        {
            canvas.Value.SetActive(canvas.Key == canvasToActivate);
        }
    }

    public void ActivateMainMenuCanvas()
    {
        ActivateCanvas(UICanvas.MainMenu);
    }

    public void ActivateSettingsCanvas()
    {
        ActivateCanvas(UICanvas.Settings);
    }

    public void ActivateTutorialCanvas()
    {
        ActivateCanvas(UICanvas.Tutorial);
    }

    public void ActivateCreditsCanvas()
    {
        ActivateCanvas(UICanvas.Credits);
    }

    public void ActivateLearnCanvas()
    {
        ActivateCanvas(UICanvas.Learn);
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    public GameObject mainMenuCanvas;
    public GameObject settingsCanvas;
    public GameObject tutorialCanvas;
    public GameObject creditsCanvas;
    public GameObject learnCanvas; 
}
