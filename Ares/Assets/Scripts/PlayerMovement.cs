using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{ 
	public float MoveSpeed = 5f;
	public Rigidbody2D rb;
	Vector2 movement;
    public Animator ani;

    public LayerMask layerMask;

    public GameObject mouse;
    public GameObject look;
    public Animator sword;
    public float attackSpeed = 3f;
    public Collider2D hitbox;

    public bool IsDashing = false;
    public bool Imortal = false;
    public float IFrames;

    void Start()
    {
        hitbox.enabled = !hitbox.enabled;
        StartCoroutine(attack());
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
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if ((layerMask.value & (1 << other.transform.gameObject.layer)) > 0)
        {
            if (!IsDashing)
            {
                StartCoroutine(damaged());
            }
        }
    }

    IEnumerator attack()
    {
        sword.SetTrigger("slash");
        hitbox.enabled = !hitbox.enabled;
        yield return new WaitForSeconds(0.15f);
        hitbox.enabled = !hitbox.enabled;
        yield return new WaitForSeconds(attackSpeed - 0.15f);
        StartCoroutine(attack()); 
    }

    IEnumerator damaged()
    {
        if (Imortal == false)
        {
            Debug.Log("Hit by enemy");
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
