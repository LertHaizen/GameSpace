using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float timeSpawn = 150f;
    private float timer;
    public float timeSpawnFirst = 10f;
    int EnemyNum = 0;
    public float distance = 10;
    public TMPro.TMP_Text EnemyTime;
    public static int waveEnemis = 6;
    private void Start()
    {
        timer = timeSpawn;
    }

    private void Update()
    {
        EnemyTime.text = timer.ToString("F0");
        timer -= Time.deltaTime;
        if(EnemyNum > 0)
        {
            EnemyNum -= 1;
            Instantiate(enemyPrefab, Random.insideUnitSphere * distance + transform.position, Quaternion.identity);
        }
        if (timer <= 0 )
        {
            timer = timeSpawnFirst;
            waveEnemis -= 1;
            EnemyNum = 2;
            SpawnEnemy();
        }

        //timer = (float)System.Math.Round(TimerDown, 0);
    }
    void SpawnEnemy()
    {
        Instantiate(enemyPrefab, Random.insideUnitSphere * distance + transform.position, Quaternion.identity); 
    }
}
