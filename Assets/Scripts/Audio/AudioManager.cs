using UnityEngine;
using FMODUnity;
using FMOD.Studio;
using System.Collections.Generic;

public class AudioManager : MonoBehaviour
{
    private List<EventInstance> eventInstances;
    private EventInstance ambienceEventInstance;

    public static AudioManager Instance { get; private set; }

    private void Awake()
    {
       if (Instance != null)
        {
            Debug.LogError("Found more than one Audio Manager in the scene.");
        }
       Instance = this;

        eventInstances = new List<EventInstance>();

    }
    private void Start()
    {
        InitializeAmbience(FMODEvents.Instance.Ambience);
    }

    private void InitializeAmbience(EventReference ambienceEventReference)
    {
        ambienceEventInstance = CreateEventInstance(ambienceEventReference);
        ambienceEventInstance.start();
    }

    public void PlayOneShot(EventReference sound)
    { 
    RuntimeManager.PlayOneShot(sound);
    }

    public EventInstance CreateEventInstance (EventReference eventReference)
    {
        EventInstance eventInstance = RuntimeManager.CreateInstance(eventReference);
        eventInstances.Add(eventInstance);
        return eventInstance;
    }

    private void CleanUp()
    {
        // stop and release any created instances
        foreach (EventInstance eventInstance in eventInstances)
        {
            eventInstance.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
            eventInstance.release();
        }
        // stop and release ambience instance if present
        if (ambienceEventInstance.isValid())
        {
            ambienceEventInstance.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
            ambienceEventInstance.release();
        }
    }

        private void OnDestroy()
        {
            CleanUp();
    }
}
