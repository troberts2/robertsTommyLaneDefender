using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField]private Animator animator;
    [SerializeField] private float enemySpeed;
    [SerializeField] private int enemyHealth;
    public AudioSource audioSource;
    [SerializeField]private AudioClip enemyDeath;
    [SerializeField] private AudioClip playerDmg;
    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        audioSource = gameObject.GetComponent<AudioSource>();
        if(gameObject.name == "snake(Clone)")
        {
            enemyHealth = 2;
            enemySpeed = 5f;
        }
        if(gameObject.name == "snail(Clone)")
        {
            enemyHealth = 5;
            enemySpeed = 2f;
        }
        if(gameObject.name == "slime(Clone)")
        {
            enemyHealth = 3;
            enemySpeed = 3f;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(-1f * enemySpeed * Time.deltaTime, 0, 0);
        if(transform.position.x < -9)
        {
            loseLife();
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collider)   
    {
        if(collider.CompareTag("Bullet")){
            StartCoroutine(hit());
        }
        if(collider.CompareTag("Player"))
        {
            loseLife();
            Destroy(gameObject);
        }
    } 
    IEnumerator hit(){
        enemySpeed = 0;
        enemyHealth--;
        animator.SetTrigger("Hit");
        if(enemyHealth < 1){
            gainScore();
            audioSource.PlayOneShot(enemyDeath, 1);
            Destroy(gameObject);
        }
        yield return new WaitForSeconds(1f);
        speedCheck();

    }
    void speedCheck()
    {
        if(gameObject.name == "snake(Clone)")
        {
            enemySpeed = 5f;
        }
        if(gameObject.name == "snail(Clone)")
        {
            enemySpeed = 2f;
        }
        if(gameObject.name == "slime(Clone)")
        {
            enemySpeed = 3f;
        }
    }
    void loseLife()
    {
        GameController.lifeCount--;
        audioSource.PlayOneShot(playerDmg, 1);
    }
    void gainScore(){
        GameController.scoreCount += 100;
    }
}
