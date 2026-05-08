using UnityEngine;

public class SequenceButton : MonoBehaviour
{
    public string objectID;

    private SequenceManager manager;

    private void Start()
    {
        manager = FindObjectOfType<SequenceManager>();
    }

    private void OnMouseDown()
    {
        manager.RegisterClick(objectID);
    }
}