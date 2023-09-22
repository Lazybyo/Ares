using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class exp : MonoBehaviour
{
    public LayerMask E1;
    public LayerMask E2;
    public LayerMask E3;
    public LayerMask E4;
    public LayerMask E5;
    public LayerMask self;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if ((self.value & (1 << other.transform.gameObject.layer)) > 0)
        {
            Debug.Log("combine");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
