using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    Vector2 move;
    public float moveSpeed = 20f;
    public bool inWater = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        move = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

       
    }
    private void FixedUpdate()
    {
        if (inWater)
        {
            rb.velocity = move * moveSpeed * Time.deltaTime;
            rb.gravityScale = .4f;
        }
        else
        {
            rb.velocity = new Vector2(move.x * moveSpeed * Time.deltaTime, rb.velocity.y);
            rb.gravityScale = 1;
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Water")
        {
            inWater = true;
         
        }
       
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Water")
        {
            inWater = false;
        }
    }
}
