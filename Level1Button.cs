using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    // Specify the name of the scene to load
    public string sceneName = "Level 1";

    // This method is called when the button is clicked
    public void OnButtonClick()
    {
        // Load the specified scene
        SceneManager.LoadScene(sceneName);
    }
}