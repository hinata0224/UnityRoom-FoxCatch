using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("スピード調整")]
    [SerializeField] private float spead = 5;

    [Header("きびきび動かす場合増やす")]
    [SerializeField] private float moveForceMultiplier = 100;

    [Header("回転速度")]
    [SerializeField] private float angleSpead = 100;

    private Vector3 move;
    private Vector3 subtractmove;

    private Rigidbody rb;

    private Animator animator;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMove();
    }

    private void FixedUpdate()
    {
        rb.AddForce(moveForceMultiplier * (subtractmove));
    }

    void PlayerMove()
    {
        float x = 0, y = 0, z = 0;
        x = Input.GetAxis("Horizontal") * angleSpead;
        z = Input.GetAxis("Vertical");

        if(z <= 0)
        {
            z = 0;
            animator.SetBool("Walk_Anim", false);
        }
        else
        {
            animator.SetBool("Walk_Anim", true);
        }

        move = new Vector3(0, 0, z);
        move = move * spead;
        move = transform.TransformDirection(move);
        subtractmove = new Vector3(move.x - rb.velocity.x, 0f, move.z - rb.velocity.z);
        transform.Rotate(0, x, 0);
    }
}
