using UnityEngine;

public class CanvasSwitcher : MonoBehaviour
{
    public GameObject canvas1;
    public GameObject canvas2;
    public GameObject openchest;
    void Start()
    {
        canvas1.SetActive(true);
        canvas2.SetActive(false);
        openchest.SetActive(false);
    }

    public void SwitchCanvas()
    {
        canvas1.SetActive(false);
        canvas2.SetActive(true);
    }

    public void SwitchOpenchest() 
    { 
        openchest.SetActive(true);
    }
}