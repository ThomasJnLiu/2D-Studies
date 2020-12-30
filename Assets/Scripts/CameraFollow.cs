using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset;
    public float xOffset, yOffset, yCutoff , xCutoff;

    public bool followPlayer;

    // Use this for initialization
    void Start()
    {
        if(player){
            offset = transform.position - player.transform.position;
            Debug.Log(offset);  
        }

    }
    

    void Update()
    {
        if(player && followPlayer){
            transform.position = player.transform.position + offset + new Vector3(xOffset, yOffset, 0);

        // If player position is outside of offsets, stop following
        //     if(player.transform.position.y < yCutoff || player.transform.position.x < xCutoff){
        //         followPlayer = false;
        //     }
        // }else if (player.transform.position.y > yCutoff && player.transform.position.x > xCutoff){
        //                     followPlayer = true;
        }

    }
}
