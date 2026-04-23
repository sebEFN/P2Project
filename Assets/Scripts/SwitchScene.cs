using UnityEngine;
using UnityEngine.SceneManagement;
public class SwitchScene : MonoBehaviour
{

    public string MyScene;

    public void Switch(string newtext)
    {
        SceneManager.LoadScene(MyScene = newtext);
    }
   
}

