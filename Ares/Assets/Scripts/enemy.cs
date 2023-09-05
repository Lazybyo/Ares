using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public GameObject player;
    public float speed;

    private float distance;

    private bool yes = false;

    public LayerMask layerMask;
    public Rigidbody2D rb;
    public float knockbackforce = 5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if ((layerMask.value & (1 << other.transform.gameObject.layer)) > 0)
        {
            if (!yes)
            {
                StartCoroutine(hit());
            }
        }
    }

    IEnumerator hit()
    {
        Debug.Log("you hit the enemy");
        yes = true;
        Vector2 direction = player.transform.position - transform.position;
        direction.Normalize();
        rb.AddForce(-direction * knockbackforce);
        yield return new WaitForSeconds(0.21f);
        rb.AddForce(direction * knockbackforce);
        yes = false;
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);
        Vector2 direction = player.transform.position - transform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
        transform.rotation = Quaternion.Euler(Vector3.forward * angle);
    }
}
