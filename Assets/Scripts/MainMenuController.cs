using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public void Play(){
        SceneManager.LoadScene("AlienCatch");
    }

    public void Exit(){
        Application.Quit();
    }
}
