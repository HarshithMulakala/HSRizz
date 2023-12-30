using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawning : MonoBehaviour
{
    Camera cam;

    public GameObject FlatteryEnemy;
    public GameObject HumorEnemy;
    public GameObject IntelligenceEnemy;
    public int total;
    public int frequency = 5;

    public float timeInterval = 5;

    private int intervalsDone = 1;

    public float time = 0;
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate(){
        time += Time.deltaTime;
        if(time > timeInterval * intervalsDone){
            intervalsDone++;
            Vector2 enemySpawn = new Vector2(Random.Range(0,76) - 47,Random.Range(0,60) - 29);
            transform.position = enemySpawn;
            Vector3 viewportPosition = cam.WorldToViewportPoint(transform.position);
            bool insideCameraView = (viewportPosition.x >= 0 && viewportPosition.x <= 1 && viewportPosition.y >= 0 && viewportPosition.y <= 1);
            while(insideCameraView){
                enemySpawn = new Vector2(Random.Range(0,76) - 47,Random.Range(0,60) - 29);
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
}
