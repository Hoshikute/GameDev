using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Player : MonoBehaviour
{
    private float inputX;
    private float inputY;
    private float stopX;
    private float stopY;
    private float moveSpeed = 1.5f;
    private Animator anim;
    private Rigidbody2D rb;

    private Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        offset = Camera.main.transform.position - transform.position;
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        inputX = Input.GetAxis("Horizontal");
        inputY = Input.GetAxis("Vertical");
        
        Vector2 dir = new Vector2(inputX, inputY).normalized;
        Move(dir);
    }

    public void Move(Vector2 dir)
    {
        if (dir == Vector2.zero)
        {
            anim.SetBool("IsMoving",false);
        }
        else
        {
            stopX = dir.x;
            stopY = dir.y;
            anim.SetBool("IsMoving",true);
        }
        
        anim.SetFloat("InputX",stopX);
        anim.SetFloat("InputY",stopY);
        
        rb.velocity = dir.normalized * moveSpeed;
        Camera.main.transform.position = transform.position + offset;
    }
    
}
