using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject player;

    [HideInInspector] public float offest;

    // private Vector3 offest;
    // Start is called before the first frame update
    void Start()
    {
        offest = transform.position.z - player.transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        Follow();
    }

    void Follow()
    {
        transform.position = new Vector3(player.transform.position.x,transform.position.y,player.transform.position.z + offest);
    }
}