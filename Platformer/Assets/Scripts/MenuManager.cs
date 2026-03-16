using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{


    public void StartGame()
    {
        GameManager.Instance.score = 0;
        GameManager.Instance.health = 100;
        //Loads the GameScene scene
        SceneManager.LoadScene(1);
    }

}