using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class EnemySpawner : MonoBehaviour
{
    public GameObject baseEnemy;
    public GameObject Gobblin;
    public Text userText;
    private LevelData data;
    private WaveData currentWave;
    private int spawnedEnemies;
    private int waveIndex;

    private int maxHealth = 100;
    private int userHealth = 100;

    void Start()
    {
        StreamReader reader = new StreamReader(Application.dataPath + "//config.json");
        string fileContent = reader.ReadToEnd();

        data = JsonUtility.FromJson<LevelData>(fileContent);
        waveIndex = 0;
        currentWave = data.waves[waveIndex];
        spawnedEnemies = 0;

        //print(fileContent);

        //userText.text = userHealth.toString() + "/" + maxHelath.toString();
        userText.text = userHealth.ToString();
        InvokeRepeating("CreateNewEnemy", currentWave.delay, 1.5f);
    }

    void CreateNewEnemy() {
        if (spawnedEnemies < currentWave.enemies.Length){

            if(currentWave.enemies[spawnedEnemies] == EnemyTypes.WIZARD_TYPE){
                CreateWizard();
            }
            else{
                CreateGobblin();
            }
            GameObject newEnemy = GameObject.Instantiate(baseEnemy);
            EnemyWizrd enemyScript = newEnemy.GetComponent<EnemyWizrd>();

            enemyScript.EnemyFinish += EnemyFinishCallback;
            spawnedEnemies++;

        } else if (waveIndex < data.waves.Count - 1) {
            CancelInvoke("CreateNewEnemy");
            waveIndex++;
            spawnedEnemies = 0;
            currentWave = data.waves[waveIndex];
            InvokeRepeating("CreateNewEnemy", currentWave.delay, 1.5f);

        }
        
    }

    void CreateWizard(){
        GameObject newEnemy = GameObject.Instantiate(baseEnemy);
        EnemyWizrd enemyScript = newEnemy.GetComponent<EnemyWizrd>();
        
        enemyScript.EnemyFinish += EnemyFinishCallback;
    }
    void CreateGobblin(){
        GameObject newEnemy = GameObject.Instantiate(Gobblin);
        EnemyGobblin enemyScript = newEnemy.GetComponent<EnemyGobblin>();
        
        enemyScript.EnemyFinish += EnemyFinishCallback;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void EnemyFinishCallback(BaseEnemy wizard) {
        userHealth -= wizard.damage;
        userText.text = userHealth.ToString();
    }
}
