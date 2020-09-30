using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableBarrier : MonoBehaviour
{
    public GameObject player;
    public MapManager mapmanager;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        mapmanager = player.GetComponent<MapManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (mapmanager.soliseComplete == true)
        {
            gameObject.SetActive(false);
        }
    }
}
