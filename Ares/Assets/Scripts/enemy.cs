using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public GameObject player;
    public float speed;
    public Animator ani;

    public float attack = 3f;
    public float MaxHp = 10f;
    public float currentHp;
    public Player playerScript;

    private float distance;

    public GameObject self;
    public GameObject ep;

    private bool yes = false;

    public LayerMask layerMask;
    public Rigidbody2D rb;
    public float knockbackforce = 5f;
    // Start is called before the first frame update
    void Awake()
    {
        currentHp = MaxHp;
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
        currentHp -= playerScript.damage;
        if (currentHp <= 0f)
        {
            Instantiate(ep, new Vector3(self.transform.position.x, self.transform.position.y, 0f), Quaternion.identity);
            self.SetActive(false);
        }
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
        ani.SetFloat("Speed", direction.x);

        transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
    }
}
