using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FlyPlayer : MonoBehaviour
{
    Animator animator;
    Rigidbody2D rigidbody;
    JumpGameManager jumpGameManager;

    public float jumpForce = 6f;
    public float fowardSpeed = 3f;
    public bool isDead = false;
    float deathCooldown = 0f;

    private bool isJump = false;

    // Start is called before the first frame update
    void Start()
    {
        jumpGameManager = JumpGameManager.Instance;
        animator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody2D>();

        if (animator == null)
            Debug.Log("Not Founded Animator");

        if (rigidbody == null)
            Debug.Log("Not Founded Rigidbody2D");

        rigidbody.gravityScale = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (!jumpGameManager.isGameStarted) return;

        if (isDead)
        {
            if (deathCooldown <= 0)
            {
                jumpGameManager.Dead();
            }
            else
            {
                deathCooldown -= Time.deltaTime;
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
            {
                isJump = true;
            }
        }
    }

    private void FixedUpdate()
    {
        if (!jumpGameManager.isGameStarted || isDead) return;

        rigidbody.gravityScale = 1f;

        Vector3 velocity = rigidbody.velocity;
        velocity.x = fowardSpeed;

        if (isJump)
        {
            velocity.y += jumpForce;
            isJump = false;
        }

        rigidbody.velocity = velocity;

        float angle = Mathf.Clamp((rigidbody.velocity.y * 10f) ,-15f, 15f);

        transform.rotation = Quaternion.Euler(0,0, angle);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (isDead) return;

        isDead = true;
        deathCooldown = 1f;
        animator.SetInteger("IsDead", 1);
    }
}

