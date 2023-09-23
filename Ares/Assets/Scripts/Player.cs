using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

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
    public Slider xpSlider;
    public Slider HpSlider;

    public LayerMask layerMask;
    public LayerMask exp;
    public GameObject Kobalos;
    public GameObject self;
    public GameObject Minotaur;

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
    bool Sable = true;
    public float SpawnTime = 5f;
    bool Mable = true;
    public float MinoSpawnTime = 5f;
    public float timer = 0.0f;
    float minutes;
    public bool istimer = true;
    public TMP_Text textTimer;
    public int dificultyup = 1;
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

        ani.SetFloat("WalkHorizontal", direction.x);
        ani.SetFloat("Speed", movement.sqrMagnitude);

        xpSlider.value = (100f / expM) * expA;
        HpSlider.value = (100f / MaxHp) * currentHp;

        if (minutes == dificultyup)
        {
            dificultyup += 1;
            SpawnTime *= 0.9f;
            MinoSpawnTime *= 0.9f;
        }

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
        if (Sable)
        {
            StartCoroutine(spawnKobalos());
        }
        if (Mable)
        {
            StartCoroutine(spawnMinotaur());
        }
        if (istimer)
        {
            timer += Time.deltaTime;
            updateTimer(timer);
        }
    }

    void updateTimer(float time)
    {
        minutes = Mathf.FloorToInt(time / 60);
        float seconds = Mathf.FloorToInt(time - minutes * 60);

        textTimer.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    IEnumerator spawnKobalos()
    {
        Sable = false;
        int spawnL = Random.Range(1, 5);
        if (spawnL == 1)
        {
            Instantiate(Kobalos, new Vector3(self.transform.position.x + Random.Range(5, 11), self.transform.position.y + Random.Range(5, 11), 0f), Quaternion.identity);
        }
        if (spawnL == 2)
        {
            Instantiate(Kobalos, new Vector3(self.transform.position.x - Random.Range(5, 11), self.transform.position.y + Random.Range(5, 11), 0f), Quaternion.identity);
        }
        if (spawnL == 3)
        {
            Instantiate(Kobalos, new Vector3(self.transform.position.x + Random.Range(5, 11), self.transform.position.y - Random.Range(5, 11), 0f), Quaternion.identity);
        }
        if (spawnL == 4)
        {
            Instantiate(Kobalos, new Vector3(self.transform.position.x - Random.Range(5, 11), self.transform.position.y - Random.Range(5, 11), 0f), Quaternion.identity);
        }
        yield return new WaitForSeconds(SpawnTime);
        Sable = true;
    }

    IEnumerator spawnMinotaur()
    {
        Mable = false;
        int spawnL = Random.Range(1, 5);
        if (spawnL == 1)
        {
            Instantiate(Minotaur, new Vector3(self.transform.position.x + Random.Range(5, 11), self.transform.position.y + Random.Range(5, 11), 0f), Quaternion.identity);
        }
        if (spawnL == 2)
        {
            Instantiate(Minotaur, new Vector3(self.transform.position.x - Random.Range(5, 11), self.transform.position.y + Random.Range(5, 11), 0f), Quaternion.identity);
        }
        if (spawnL == 3)
        {
            Instantiate(Minotaur, new Vector3(self.transform.position.x + Random.Range(5, 11), self.transform.position.y - Random.Range(5, 11), 0f), Quaternion.identity);
        }
        if (spawnL == 4)
        {
            Instantiate(Minotaur, new Vector3(self.transform.position.x - Random.Range(5, 11), self.transform.position.y - Random.Range(5, 11), 0f), Quaternion.identity);
        }
        yield return new WaitForSeconds(MinoSpawnTime);
        Mable = true;
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
                damage *= 1.1f;
                attackSpeed *= 0.9f;
                expM *= 1.3f;
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
            yield return new WaitForSeconds(IFrames);
            Imortal = false;
        }
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * MoveSpeed * Time.fixedDeltaTime);

    }
}
