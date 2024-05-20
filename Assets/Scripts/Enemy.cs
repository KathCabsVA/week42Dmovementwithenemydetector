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
        target = Player.transform.position;
    }

    bool SeePlayer()
    {
        Vector3 dir = Player.transform.position = transform.position;
        if (dir.magnitude > viewDistance)
        {
            Debug.Drawline(transform.position, transform.up * viewDistance, Color.green);
            float angle = Vector3.Dot(transform.up, dir.normalized);

            if((Mathf.Acos(angle) * Mathf.Rad2Deg) < viewAngle)
            {
                return true;
            }
            return true;
        }
        return false;
    }

    // Update is called once per frame
    void Update()
    {
        bool seen = SeePlayer();
        //when we reach target
        if (Vector3.Distance(transform.position, target) < 0.5f)
        {

            //at target, pick up new spot to go to
            Quaternion rotation = Quaternion.Euler(0.0f, 0.0f, Random.Range(0.0f, 360.0f)); //random movement in 360
            target = lastSeen + (rotation * transform.up * 5.0f);
        }
        else
        {
            Vector3 dir = target - transform.position;
            float angle = Mathf.Atan2(-dir.x, dir.y) * Mathf.Rad2Deg; //convert to radians to degrees
            Quaternion p = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.Lerp(transform.rotation, p, Time.deltaTime * 10.0f);

            transform.position += transform.position * 100.0f * Time.deltaTime; //make the enemy faster
        }
        Debug.DrawRay(transform.position, transform.up * viewDistance, seen? Color.red:Color.yellow, 0); //raycast
        Quaternion rayAngle = Quaternion.Euler(0, 0, -viewAngle);
        Debug.DrawRay(transform.position, rayAngle * transform.up * viewAngle, seen ? Color.red : Color.yellow);
        rayAngle = Quaternion.Euler(0, 0, viewAngle);
        Debug.DrawRay(transform.position, rayAngle * transform.up * viewAngle, seen? Color.red: Color.yellow);
    }

}
