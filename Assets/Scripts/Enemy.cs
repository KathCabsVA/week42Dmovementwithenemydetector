using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour

{
    Vector3 LastSeen;
    Vector3 Target;

    public GameObject player;
    public float viewDistance;
    public float viewAngle;
    public float speed;

    private void Start()
    {
        LastSeen = transform.position;
        Target = player.transform.position;
    }
    private void Update()
    {
        bool seen = seePlayer();

        if (seen)
        {
            LastSeen = player.transform.position;
            Target = LastSeen;
        }
        if (Vector3.Distance(transform.position, Target) < 0.5f)
        {
            Quaternion rotation = Quaternion.Euler(0f, 0f, Random.Range(0f, 360f));
            Target = LastSeen + (rotation * transform.up * 5.0f);
        }
        else
        {
            Vector3 direcion = Target - transform.position;
            float angle = Mathf.Atan2(-direcion.x, direcion.y) * Mathf.Rad2Deg;
            Quaternion p = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.Lerp(transform.rotation, p, Time.deltaTime * 10f);

            transform.position += transform.up * speed * Time.deltaTime;
        }
        Debug.DrawRay(transform.position, transform.up * viewDistance, seen ? Color.red : Color.yellow);

        Quaternion uprayAngle = Quaternion.Euler(0, 0, -viewAngle);
        Debug.DrawLine(transform.position, uprayAngle * transform.up * viewAngle, seen ? Color.red : Color.green);
        Quaternion downrayAngle = Quaternion.Euler(0, 0, viewAngle);
        Debug.DrawLine(transform.position, downrayAngle * transform.up * viewAngle, seen ? Color.red : Color.green);
    }

    bool seePlayer()
    {
        Vector3 dir = player.transform.position - transform.position;

        if (dir.magnitude < viewDistance)
        {
            float angle = Vector3.Dot(transform.up, dir.normalized);
            if ((Mathf.Acos(angle) * Mathf.Rad2Deg) < viewAngle)
            {
                return true;
            }
            return true;
        }
        return false;
    }

}
