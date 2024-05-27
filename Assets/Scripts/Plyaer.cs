using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plyaer : MonoBehaviour
{
    [SerializeField] private float speed;
    public Transform HeadPos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(transform.forward, Time.deltaTime * speed);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(transform.forward, Time.deltaTime * -speed);
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.position += transform.up * 10.0f * Time.deltaTime;
        }

        Debug.DrawRay(transform.position, transform.up * 10f, Color.green); //raycast
    }
}
