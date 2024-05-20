using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plyaer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(transform.forward, Time.deltaTime * 200.0f);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(transform.forward, Time.deltaTime * -200.0f);
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.position += transform.up * 10.0f * Time.deltaTime;
        }

        Debug.DrawRay(transform.position, transform.up * 100f, Color.green); //raycast
    }
}
