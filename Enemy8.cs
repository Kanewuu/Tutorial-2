using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy8 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
void Update()
    {
        transform.position = new Vector2(Mathf.PingPong(Time.time, 2) + 121, -5.66f);
        
    }
}
