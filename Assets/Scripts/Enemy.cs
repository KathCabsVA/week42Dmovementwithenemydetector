using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
        //when we reach target
        if(Vector3.Distance(transform.position, target) < 0.5f) 
        {

            //at target, pick up new spot to go to
            Quaternion rotation = Quaternion.Euler(0.0f, 0.0f, Random.Range(0.0f,360.0f)); //random movement in 360
            target = lastSeen + (rotation * transform.up * 5.0f);
        }
        else
        {
            Vector3 dir = target + transform.position;
        }
    }
}
