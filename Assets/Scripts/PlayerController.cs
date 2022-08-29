using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Clamper();
        horizontal = Input.GetAxisRaw("Horizontal");
    }

    private void FixedUpdate()
    {  
        rb.velocity = new Vector2(horizontal * MoveSpeed, vertical * MoveSpeed);
    }

    void Clamper()
    {
        var pos = transform.position;
        pos.y =  Mathf.Clamp(-8.5f, transform.position.y, 0f);
        transform.position = pos;

    }

    void Movement()
    {
        targetvelocity =  new Vector2(horizonal * PlayerSpeed * Time.deltaTime, rb.velocity.y);
    }
}
