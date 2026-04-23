using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class Tutorial : MonoBehaviour
{
    public GameObject Mirror;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Mirror.SetActive(false);
        StartCoroutine(StartMirror());

    }

    // Update is called once per frame
    void Update()
    {
        if (Mirror.activeInHierarchy)
        {
            StopCoroutine(StartMirror());
        }
    }

    IEnumerator StartMirror()
    {
        yield return new WaitForSeconds(0.5f);
        if (!Mirror.activeInHierarchy)
        {
            Mirror.SetActive(true);
        }
    }
}
