using UnityEngine;
using FMODUnity;
using FMOD.Studio;
using System.Collections.Generic;

public class AudioManager : MonoBehaviour
{
    private List<EventInstance> eventInstances;

    private List<EventInstance> eventEmitters;

    private EventInstance ambienceEventInstance;

    public static AudioManager Instance { get; private set; }

    private void Awake()
    {
       if (Instance != null)
        {
            Debug.LogError("Found more than one Audio Manager in the scene.");
        }
       Instance = this;

    }
    private void Start()
    {
        InitializeAmbience(FMODEvents.Instance.Ambience);
    }

    private void InitializeAmbience(EventReference ambienceEventReference)
    {
        //ambienceEventInstance = CreateInstance(ambienceEventReference);
        ambienceEventInstance.start();
    }

    public void PlayOneShot(EventReference sound)
    { 
    RuntimeManager.PlayOneShot(sound);
    }
}
