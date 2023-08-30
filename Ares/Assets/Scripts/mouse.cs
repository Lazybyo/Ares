using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouse : MonoBehaviour
{

    public Camera cam;

    Vector3 daad;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        daad = cam.ScreenToWorldPoint(Input.mousePosition);
        daad.z = -5f;
        transform.position = daad;
    }
}
