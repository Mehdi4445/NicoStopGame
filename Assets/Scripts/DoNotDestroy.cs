using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoNotDestroy : MonoBehaviour
{
    private static DoNotDestroy musicScript;

    private void Awake()
    {
        if (musicScript == null)
        {
            musicScript = this;
            DontDestroyOnLoad(musicScript);
        }
        else
            Destroy(gameObject);

    }
}
