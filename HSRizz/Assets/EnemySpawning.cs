using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemySpawning : MonoBehaviour
{
    Camera cam;
    public AudioSource audioSource;
    public GameObject FlatteryEnemy;
    public GameObject HumorEnemy;
    public GameObject IntelligenceEnemy;

    public GameObject waveCleared;
    public GameObject waveText;
    public int total = 0;
    public int frequency = 5;

    public int dead = 0;

    private bool allDead = false;

    public float timeInterval = 5;

    private int intervalsDone = 1;

    public float time = 0;

    public GameObject SpawnSquare;
    void Start()
    {
        if(SceneManager.GetActiveScene().name == "Wave1"){
            PlayerPrefs.SetFloat("maxHealth", 100);
            PlayerPrefs.SetInt("damage", 10);
            PlayerPrefs.SetInt("RizzCoins", 0);
        }
        audioSource.Play();
        cam = Camera.main;

    }

    // Update is called once per frame
    void Update()
    {
        if(dead >= frequency && !allDead){
            allDead = true;
            waveCleared.SetActive(true);
            waveText.SetActive(true);
            StartCoroutine(FlashText());
        }
    }

    void FixedUpdate(){
        time += Time.deltaTime;
        if(time > timeInterval * intervalsDone && total < frequency){
            var SR = SpawnSquare.GetComponent<SpriteRenderer>();
            float minX = SR.bounds.min.x;
            float maxX = SR.bounds.max.x;
            float minY = SR.bounds.min.y;
            float maxY = SR.bounds.max.y;
            total++;
            intervalsDone++;
            Vector2 enemySpawn = new Vector2(Random.Range(minX,maxX),Random.Range(minY,maxY));
            transform.position = enemySpawn;
            Vector3 viewportPosition = cam.WorldToViewportPoint(transform.position);
            bool insideCameraView = (viewportPosition.x >= 0 && viewportPosition.x <= 1 && viewportPosition.y >= 0 && viewportPosition.y <= 1);
            while(insideCameraView){
                enemySpawn = new Vector2(Random.Range(minX,maxX),Random.Range(minY,maxY));
                transform.position = enemySpawn;
                viewportPosition = cam.WorldToScreenPoint(transform.position);
                insideCameraView = (viewportPosition.x >= 0 && viewportPosition.x <= 1 && viewportPosition.y >= 0 && viewportPosition.y <= 1);
            }
            int randType = Random.Range(0,3);
            var SpawningEnemy = (randType == 0 ? FlatteryEnemy : randType == 1 ? HumorEnemy : IntelligenceEnemy);
            var enemy = Instantiate(SpawningEnemy, enemySpawn, transform.rotation);
            enemy.GetComponent<EnemyInteract>().type = (randType == 0 ? Bullet.bulletType.Flattery : randType == 1 ? Bullet.bulletType.Humor : Bullet.bulletType.Intelligence);
        }
    }

    IEnumerator FlashText()
    {
        yield return new WaitForSeconds(.5f);
        waveText.SetActive(false);
        yield return new WaitForSeconds(.5f);
        waveText.SetActive(true);
        StartCoroutine(FlashText());
        
    }
}
