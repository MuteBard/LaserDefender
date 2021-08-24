using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<WaveConfig> waveConfigs;
    //Hard Coded for now
    [SerializeField] int startingWave = 2;
    // Start is called before the first frame update
    [SerializeField] bool looping = false;
    IEnumerator Start()
    {
        do{
            yield return StartCoroutine(SpawnAllWaves());
        } while (looping);

    }

    // Update is called once per frame
    private IEnumerator SpawnAllEnemiesInWave(WaveConfig waveConfig){
        for (int enemyCount = 0; enemyCount < waveConfig.GetNumberOfEnemies(); enemyCount++){
            var newEnemy = Instantiate(waveConfig.GetEnemyPrefab(), waveConfig.GetWaypoints()[0].transform.position, Quaternion.identity);
            newEnemy.GetComponent<Enemy>().SetWaveConfig(waveConfig);
            yield return new WaitForSeconds(waveConfig.GetTimeBetweenSpawns());
        }
    }

    private IEnumerator SpawnAllWaves(){
        for (int waveIndex = startingWave; waveIndex < waveConfigs.Count; waveIndex++){
            var currentWave = waveConfigs[waveIndex];
            yield return StartCoroutine(SpawnAllEnemiesInWave(currentWave));    
        }
    }
}