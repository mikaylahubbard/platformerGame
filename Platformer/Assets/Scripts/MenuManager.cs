using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void StartGame()
    {
        //Loads the GameScene scene
        SceneManager.LoadScene(1);
    }

}