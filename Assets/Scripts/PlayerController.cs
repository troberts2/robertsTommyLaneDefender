using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float playerSpeed;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField]private float fireRate;
    [SerializeField]private float lastShot;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MovementClamper();
        Shoot();
    }

    private void FixedUpdate()
    {  
        //Clamper();
    }

    void MovementClamper()
    {
        float yMove = Input.GetAxis("Vertical") * Time.deltaTime * playerSpeed;
        transform.Translate(0f, yMove, 0f);
        Vector3 clampedPosition = transform.position;
        clampedPosition.y = Mathf.Clamp(clampedPosition.y, -4.3f, 3.5f);
        transform.position = clampedPosition;
    }
    void Shoot(){
        if(Input.GetKey(KeyCode.Space) && Time.time > fireRate + lastShot){
            Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            lastShot = Time.time;
        }
    }
}
