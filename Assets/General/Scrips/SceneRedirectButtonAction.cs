using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using NaughtyAttributes;

public class SceneRedirectButtonAction : MonoBehaviour
{
    [Scene][SerializeField] private string redirectTo;
    void Start()
    {
        Button button = GetComponent<Button>();
        button.onClick.AddListener(() => {
            SceneManager.LoadScene(redirectTo);
        });
    }

  
}
