using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FormationMovement : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnInterval = 0.0f;

    public Transform[] step1Positions;
    public Transform[] step2Positions;
    public Transform[] step3Positions;
    public Transform[] step4Positions;

    /*private List<GameObject> spawnedEnemies = new List<GameObject>();
    private int totalEnemies = 16;
    private int enemiesSpawned = 0;
    private int count = 0;


    private void Start()
    {
        lastUpdateTime = Time.time; // Initialize lastUpdateTime
        StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        while (enemiesSpawned < totalEnemies)
        {
            GameObject newEnemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
            spawnedEnemies.Add(newEnemy);
            enemiesSpawned++;
            yield return new WaitForSeconds(0.1f);
        }
    }
    private float updateDelay = 5f; // Delay in seconds
    private float lastUpdateTime; // Time of the last Update

    private void Update()
    {

            switch (count)
            {
                case 0:
                    MoveEnemiesToPositions(step1Positions);
                    //StartCoroutine(StartNextStepAfterDelay(step1Positions));
                    break;
                case 1:
                MoveEnemiesToPositions(step2Positions);
                //    StartCoroutine(StartNextStepAfterDelay(step2Positions));
                    break;
            // ... Other cases
                case 2:
                MoveEnemiesToPositions(step3Positions);
                //StartCoroutine(StartNextStepAfterDelay(step3Positions));
                    break;
*//*                case 3:
                    StartCoroutine(StartNextStepAfterDelay(step4Positions));
                    break;
                case 4:
                    StartCoroutine(StartNextStepAfterDelay(step5Positions));
                    break;*//*
            default:
                    break;

            }

    }
    private IEnumerator StartNextStepAfterDelay(Transform[] targetPositions)
    {
        yield return new WaitForSeconds(2f);
        MoveEnemiesToPositions(targetPositions);
        

    }

    private void MoveEnemiesToPositions(Transform[] targetPositions)
    {
        float moveSpeed = 7f; // Adjust this value to control the movement speed
        bool countnow = false;
        for (int i = 0; i < spawnedEnemies.Count; i++)
        {
            GameObject enemy = spawnedEnemies[i];
            Transform targetPosition = targetPositions[i];

            // Move the enemy towards the target position
            enemy.transform.position = Vector3.MoveTowards(enemy.transform.position, targetPosition.position, moveSpeed * Time.deltaTime);
            if (i == spawnedEnemies.Count - 1 && Vector2.Distance(enemy.transform.position, targetPosition.position) == 0f)
            {
                countnow = true;
            }
        }
        if (countnow)
        {
            count++;
            countnow = false;
        }
        
    }*/
    private List<GameObject> spawnedEnemies = new List<GameObject>();
    private int totalEnemies = 16;
    private int enemiesSpawned = 0;
    private int count = 0;
    private bool shouldMove = false; // Control movement
    private float moveSpeed = 7f;
    private float stepDelay = 5f;
    private void Start()
    {
        StartCoroutine(SpawnEnemies());
    }
    
    private IEnumerator SpawnEnemies()
    {
        while (enemiesSpawned < totalEnemies)
        {
            GameObject newEnemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
            spawnedEnemies.Add(newEnemy);
            enemiesSpawned++;
            yield return new WaitForSeconds(spawnInterval);
        }

        shouldMove = true; // Start moving once enemies are spawned
    }

    private void Update()
    {
        if (shouldMove && GetCurrentStepPositions()!=null)
        {
            MoveEnemiesToPositions(GetCurrentStepPositions());

            // Check if all enemies reached their positions
            if (AllEnemiesReachedTarget())
            {
                shouldMove = false; // Stop moving
                StartCoroutine(StartNextStepAfterDelay());
                if (GetCurrentStepPositions() == step4Positions)
                {
                    foreach (var enemy in spawnedEnemies)
                    {
                        if (enemy != null)
                        {
                            EnemyController enemyScript = enemy.GetComponent<EnemyController>();
                            if (enemyScript != null && !enemyScript.IsDestroyed())
                            {
                                enemyScript.DoActive();
                            }
                            
                        }
                    }
                }
            }
        }
        
    }

    private IEnumerator StartNextStepAfterDelay()
    {
        yield return new WaitForSeconds(stepDelay);
        if(count<4)
        count++;
        
        shouldMove = true; // Allow movement for the next step
    }

    private Transform[] GetCurrentStepPositions()
    {
        switch (count)
        {
            case 0:
                return step1Positions;
            case 1:
                return step2Positions;
            // ... Add cases for other steps
            case 2:
                return step3Positions;
                case 3:
                    return step4Positions;
            default:
                return null;
        }
    }

    private void MoveEnemiesToPositions(Transform[] targetPositions)
    {
        for (int i = 0; i < spawnedEnemies.Count; i++)
        {
            GameObject enemy = spawnedEnemies[i];
            Transform targetPosition = targetPositions[i];

            // Move the enemy towards the target position
            enemy.transform.position = Vector3.MoveTowards(enemy.transform.position, targetPosition.position, moveSpeed * Time.deltaTime);
        }
    }

    private bool AllEnemiesReachedTarget()
    {
        foreach (var enemy in spawnedEnemies)
        {
            Transform targetPosition = GetCurrentStepPositions()[spawnedEnemies.IndexOf(enemy)];
            if (Vector3.Distance(enemy.transform.position, targetPosition.position) > 0.01f)
            {
                return false;
            }
        }
        return true;
    }
}
