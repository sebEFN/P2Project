using UnityEngine;
using FMODUnity;

public class FMODEvents : MonoBehaviour
{
    [field: Header("Ambience")]
    [field: SerializeField] public EventReference Ambience { get; private set; }

    [field: Header("Menu Open")]
    [field: SerializeField] public EventReference MenuOpen { get; private set; }
    
    public static FMODEvents Instance { get; private set; }
    
    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("Found more than one FMOD Events in the scene.");
        }
        Instance = this;
    }
}
