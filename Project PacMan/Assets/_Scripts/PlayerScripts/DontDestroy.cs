using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    public static DontDestroy mainCHaracter;
    public GameObject player;
    void Awake()
    {
        player.SetActive(true);
        if(mainCHaracter == null)
        {
            DontDestroyOnLoad(gameObject);
            mainCHaracter = this;
        }
        else if (mainCHaracter != this)
        {
            Destroy(gameObject);
        }
    }
}
