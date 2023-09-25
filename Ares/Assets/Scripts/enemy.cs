using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    GameObject player;
    public float speed;
    public Animator ani;

    public float attack = 3f;
    public float MaxHp = 10f;
    public float currentHp;
    Player playerScript;
    public LayerMask playerMask;
    public Collider2D hituck;
    bool please = true;

    private float distance;

    public bool ableToDash;
    private bool Dable = true;
    public float dashCooldown = 3f;
    public float dashTime = 0.2f;
    public float dashDistance;
    public float dashForce = 100f;
    public float dashChargeTime = 1f;

    public GameObject self;
    public GameObject ep;

    private bool yes = false;

    public LayerMask layerMask;
    public Rigidbody2D rb;
    public float knockbackforce = 5f;
    // Start is called before the first frame update
    void Awake()
    {
        player = GameObject.Find("Player");
        playerScript = GameObject.Find("Player").GetComponent<Player>();
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
        if ((playerMask.value & (1 << other.transform.gameObject.layer)) > 0)
        {
            StartCoroutine(hut());
        }
    }
    IEnumerator hut()
    {
        hituck.enabled = false;
        yield return new WaitForSeconds(playerScript.IFrames);
        hituck.enabled = true;
    }
    IEnumerator hit()
    {
        currentHp -= playerScript.damage;
        if (currentHp <= 0f)
        {
            Instantiate(ep, new Vector3(self.transform.position.x, self.transform.position.y, -1f), Quaternion.identity);
            Destroy(self);
        }
        yes = true;
        Vector2 direction = player.transform.position - self.transform.position;
        direction.Normalize();
        rb.AddForce(-direction * knockbackforce);
        yield return new WaitForSeconds(0.21f);
        rb.AddForce(direction * knockbackforce);
        yes = false;
    }

    IEnumerator dash()
    {
        please = false;
        yield return new WaitForSeconds(dashChargeTime / 2);
        Vector2 direction = player.transform.position - self.transform.position;
        direction.Normalize();
        yield return new WaitForSeconds(dashChargeTime / 2);
        Dable = false;
        rb.AddForce(direction * dashForce);
        yield return new WaitForSeconds(dashTime);
        rb.AddForce(-direction * dashForce);
        please = true;
        yield return new WaitForSeconds(dashCooldown - dashTime);
        Dable = true;
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector2.Distance(self.transform.position, player.transform.position);
        Vector2 direction = player.transform.position - self.transform.position;
        direction.Normalize();
        ani.SetFloat("Speed", direction.x);

        if (ableToDash)
        {
            if (distance > dashDistance)
            {
                if (please)
                {
                    self.transform.position = Vector2.MoveTowards(self.transform.position, player.transform.position, speed * Time.deltaTime);
                }
            }
            else
            {
                if (Dable)
                {
                    StartCoroutine(dash());
                }
            }
        }else
        {
            self.transform.position = Vector2.MoveTowards(self.transform.position, player.transform.position, speed * Time.deltaTime);
        }
        
    }
}
