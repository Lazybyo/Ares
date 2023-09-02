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

    public bool IsDashing = false;
    public bool Imortal = false;
    public float IFrames;
    // Update is called once per frame
    void Update()
	{
		movement.x = Input.GetAxisRaw("Horizontal");
		movement.y = Input.GetAxisRaw("Vertical");

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
