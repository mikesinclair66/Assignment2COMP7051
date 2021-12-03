using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using Random = UnityEngine.Random;

public class GameMaster : MonoBehaviour
{
    const string fileName = "/positions.dat";
    public GameObject enemy;
    public GameObject player;
    public float killCooldown;
    private float currentCountdown;
    public AudioSource respawnSound;
    public Reset reset;
    
    public int score;
    private bool checkIfEnemyDead;

    private bool requestSave;
    private InputActions inputActions;
    private Vector3 playerSpawn;
    private Vector3 enemySpawn;

    private void Awake()
    {
        inputActions = new InputActions();

        inputActions.Player.SaveGame.performed += context =>
        {
            Debug.Log("performing save");
            SavePositions();
        };
        inputActions.Player.LoadGame.performed += context =>
        {
            Debug.Log("performing load");
            LoadPositions();
        };
    }

    private void Update()
    {
        if (OnCooldown())
        {
            currentCountdown -= Time.deltaTime;
        }

        if (!enemy.activeSelf && !checkIfEnemyDead)
        {
            score++;
            checkIfEnemyDead = true;
            currentCountdown = killCooldown;
        }

        if (!OnCooldown() && checkIfEnemyDead)
        {
            enemy.SetActive(true);
            resetEnemy();
            AudioSource.PlayClipAtPoint(respawnSound.clip, enemy.transform.position);
            checkIfEnemyDead = false;
        }
    }

    private void FixedUpdate()
    {
        if (requestSave)
        {
            player.transform.position = playerSpawn;
            enemy.transform.position = enemySpawn;
            requestSave = false;
        }
    }

    private void OnEnable()
    {
        inputActions.Player.SaveGame.Enable();
        inputActions.Player.LoadGame.Enable();
    }

    private void OnDisable()
    {
        inputActions.Player.SaveGame.Disable();
        inputActions.Player.LoadGame.Disable();
    }

    private bool OnCooldown()
    {
        return currentCountdown > 0;
    }

    void resetEnemy()
    {
        Vector3 spawnPoint = reset.enemyPosition;
        float xOffset = Random.Range(-25.0f, 25.0f);
        float zOffset = Random.Range(-25.0f, 25.0f);
        spawnPoint.x += xOffset;
        spawnPoint.z += zOffset;
        enemy.transform.position = spawnPoint;
        enemy.GetComponent<DudeEnemy>().health = enemy.GetComponent<DudeEnemy>().maxHealth;
    }

    public void LoadPositions()
    {
        Debug.Log("loading positions");
        if (File.Exists(Application.persistentDataPath + fileName)) {
            BinaryFormatter bf = new BinaryFormatter ();
            FileStream fs = File.Open(Application.persistentDataPath + fileName, FileMode.Open, FileAccess.Read);
            GameData data =(GameData)bf.Deserialize (fs);
            playerSpawn = new Vector3(data.playerPosition[0], data.playerPosition[1], data.playerPosition[2]);
            enemySpawn = new Vector3(data.enemyPosition[0], data.enemyPosition[1], data.enemyPosition[2]);
            score = data.score;
            requestSave = true;
            fs.Close();
        }
    }
    
    public void SavePositions()
    {
        Debug.Log("saving positions");
        BinaryFormatter bf = new BinaryFormatter ();
        FileStream fs = File.Open(Application.persistentDataPath + fileName, FileMode.OpenOrCreate);
        GameData data = new GameData();
        data.playerPosition = new List<float>()
        {
            player.transform.position.x,
            player.transform.position.y,
            player.transform.position.z
        };
        data.enemyPosition = new List<float>()
        {
            enemy.transform.position.x,
            enemy.transform.position.y,
            enemy.transform.position.z
        };
        data.score = score;
        bf.Serialize (fs, data);
        fs.Close ();
    }
}

[Serializable]
class GameData
{
    public List<float> playerPosition;
    public List<float> enemyPosition;
    public int score;
};