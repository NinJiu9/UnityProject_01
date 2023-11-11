using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject player;

    [HideInInspector] public Vector3 offest;

    // private Vector3 offest;
    // Start is called before the first frame update
    void Start()
    {
        offest = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Follow();
    }

    void Follow()
    {
        transform.position = player.transform.position + offest;
    }
}