using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{
    private float[] spawnPoints = new float[] {3.5f, 1.5f, -.5f, -2.5f, -4.5f};
    [SerializeField]private GameObject[] enemyTypes = new GameObject[] {};
    static public int lifeCount = 3;
    static public int scoreCount;
    [SerializeField]private TMP_Text lifeText;
    [SerializeField]private TMP_Text scoreText;
    [SerializeField]private TMP_Text gameOverText;
    [SerializeField]private TMP_Text finalScoreText;
    [SerializeField] private TMP_Text highScoreText;
    [SerializeField] private int highScore;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(enemySpawn());
        StartCoroutine(statKeeper());
        highScore = PlayerPrefs.GetInt("highScore", highScore);
        highScoreText.text = "High Score: " + highScore.ToString();
        scoreCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Debugger();
    }

    IEnumerator enemySpawn(){
        while(true){
            //spawns in random enemy at random spawn point from arrays
            Instantiate(enemyTypes[Random.Range(0, enemyTypes.Length)], new Vector2(8.5f, spawnPoints[Random.Range(0, spawnPoints.Length)]), Quaternion.identity);
            yield return new WaitForSeconds(1f);
        }
    }
    IEnumerator statKeeper(){
        while(true)
        {
            lifeText.text = "Lives: " + lifeCount.ToString();
            scoreText.text = "Score: " + scoreCount.ToString();
            if (lifeCount < 1)
            {
                loseGame();
            }
            yield return new WaitForSeconds(.1f);
        }
    }
    void loseGame()
    {
        if(scoreCount > highScore)
        {
            PlayerPrefs.SetInt ("highScore", scoreCount);
            highScore = PlayerPrefs.GetInt("highScore", highScore);
            highScoreText.text = "High Score: " + highScore.ToString();
        }
        StopAllCoroutines();
        lifeText.gameObject.SetActive(false);
        scoreText.gameObject.SetActive(false);
        gameOverText.gameObject.SetActive(true);
        finalScoreText.gameObject.SetActive(true);
        finalScoreText.text = "Final Score: " + scoreCount;

    }
    void Debugger(){
        if(Input.GetKey(KeyCode.R)) 
        { 
            lifeCount = 3;
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
            lifeText.gameObject.SetActive(true);
            scoreText.gameObject.SetActive(true);
            gameOverText.gameObject.SetActive(false);
            finalScoreText.gameObject.SetActive(false); 
        } 
    }
}
