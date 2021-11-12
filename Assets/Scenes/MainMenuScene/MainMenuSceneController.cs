using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuSceneController : MonoBehaviour
{

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            SceneManager.LoadScene(Constants.SCENES.GAMEPLAY_MENU_SCENE);
        }
    }
}
