using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Vector3 lastSeen;
    Vector3 target;

    public GameObject Player;
    public float viewDistance;
    public float viewAngle;
    // Start is called before the first frame update
    void Start()
    {
        lastSeen = transform.position;
        target = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
