using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour 
{
    public Animator animator;
    public AudioSource audioSource;
    public float speed = 20;
    private bool hitb = false;
    [SerializeField]private AudioClip shoot;
    [SerializeField]private AudioClip hitEnemy;

    void Start(){
        animator = gameObject.GetComponent<Animator>();
        audioSource = gameObject.GetComponent<AudioSource>();
        audioSource.PlayOneShot(shoot, 1);
    }
    void Update() 
    {
        if(!hitb)
        {
            transform.Translate((transform.right * speed * Time.deltaTime));
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.CompareTag("Enemy")){
            StartCoroutine(hit());
        }
    }
    IEnumerator hit(){
        animator.SetTrigger("Hit");
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        hitb = true;
        audioSource.PlayOneShot(hitEnemy, 1);
        yield return new WaitForSeconds(.3f);
        Destroy(gameObject);
    }
}
