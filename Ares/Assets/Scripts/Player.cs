using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float MoveSpeed = 5f;
    public Rigidbody2D rb;
    Vector2 movement;
    public Animator ani;

    public float expM = 10f;
    public float expA = 0f;
    public float expN = 1f;
    public float level = 1f;

    GameObject experiance;

    public LayerMask layerMask;
    public LayerMask exp;
    public GameObject Kobalos;

    public GameObject mouse;
    public GameObject look;
    public Animator sword;
    public float attackSpeed = 3f;
    public Collider2D hitbox;

    public bool IsDashing = false;
    public bool Imortal = false;
    public float IFrames;

    public float damage = 5f;
    public float MaxHp = 70f;
    public float currentHp;
    public float dashForce = 100f;
    public float DTime = 0.2f;
    public float DCooldown = 1f;
    bool able = true;
    enemy enemy;
    bool attacking = false;

    //start is start
    void Start()
    {
        currentHp = MaxHp;
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        look.transform.position = this.transform.position;
        Vector2 direction = mouse.transform.position - look.transform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        look.transform.rotation = Quaternion.Euler(Vector3.forward * angle);

        ani.SetFloat("WalkHorizontal", movement.x);
        ani.SetFloat("WalkVertical", movement.y);
        ani.SetFloat("Speed", movement.sqrMagnitude);

        if (IsDashing == true)
        {
            rb.AddForce(direction * dashForce);
        }
        if (!attacking)
        {
            StartCoroutine(attack());
        }
        if (Input.GetButtonDown("Fire1"))
        {
            if (able)
            {
                StartCoroutine(yes());
            }
        }
    }

    IEnumerator yes()
    {
        able = false;
        IsDashing = true;
        yield return new WaitForSeconds(DTime);
        IsDashing = false;
        yield return new WaitForSeconds(DCooldown);
        able = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if ((layerMask.value & (1 << other.transform.gameObject.layer)) > 0)
        {
            if (!IsDashing)
            {
                StartCoroutine(damaged(other));
            }
        }
        if ((exp.value & (1 << other.transform.gameObject.layer)) > 0)
        {
            expA += expN;
            if (expA >= expM)
            {
                level += 1;
                expA -= expM;
            }
            experiance = other.transform.gameObject;
            Destroy(experiance);
        }
    }

    IEnumerator attack()
    {
        sword.SetTrigger("slash");
        attacking = true;
        hitbox.enabled = true;
        yield return new WaitForSeconds(0.15f);
        hitbox.enabled = false;
        yield return new WaitForSeconds(attackSpeed - 0.15f);
        attacking = false;
    }

    IEnumerator damaged(Collider2D Ehitbox)
    {
        if (Imortal == false)
        {
            Debug.Log("Hit by enemy");
            GameObject ene = Ehitbox.transform.gameObject;
            enemy = ene.GetComponent<enemy>();
            currentHp -= enemy.attack;
            if (currentHp <= 0f)
            {
                Debug.Log("Dead");
            }
            Imortal = true;
            Ehitbox.enabled = false;
            yield return new WaitForSeconds(IFrames);
            Ehitbox.enabled = true;
            Imortal = false;
        }
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * MoveSpeed * Time.fixedDeltaTime);

    }
}
