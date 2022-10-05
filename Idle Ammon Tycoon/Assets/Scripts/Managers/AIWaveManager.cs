using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class AIWaveManager : MonoBehaviour
{
    public List<Ragdoller> Agents = new List<Ragdoller>();
    public Transform[] positions;
    public int enemyLoadOutNumber;
    public float waveTime;
    private float tempTime;
    public int totalWaves;
    private int currentWave;
    public UnityEvent onWaveKilled;
    public float eventDelay;
    [SerializeField]
    private int killsNeeded;
    public bool noHostage, oneHostage;
    public GameObject[] hostages;
    public ActivityManager activityCounter;
    public bool randomWaves;
    public int maxWaves;
    private int totalEnemyCount;

    private void OnEnable()
    {
        totalEnemyCount = Agents.Count;
        if (randomWaves)
        {
            totalWaves = Random.Range(3, maxWaves);
            enemyLoadOutNumber = Random.Range(5, 15);
        }

        if (!noHostage) 
        {
            if (!oneHostage)
            {
                int x = Random.Range(0, hostages.Length - 1);
                for (int i = 0; i <= x; i++)
                {
                    hostages[i].SetActive(true);
                }
                activityCounter.totalEvents = x + 1;
            }
            else
            {
                hostages[0].SetActive(true);
            }
        }

        currentWave = 0;
        killsNeeded = totalWaves * enemyLoadOutNumber;
        int randomPos = Random.Range(0, positions.Length);
        for (int i = 0; i < enemyLoadOutNumber; i++)
        {
            Agents[i].transform.position = positions[randomPos].position;
            Agents[i].baseController.waveManager = this;
            Agents[i].gameObject.SetActive(true);
            Agents.Remove(Agents[i]);
        }
        currentWave++;

    }

    private void Update()
    {
        if (Agents.Count > 0 && currentWave < totalWaves)
        {
            tempTime += Time.deltaTime;

            if (tempTime >= waveTime)
            {
                if (Agents.Count < enemyLoadOutNumber)
                {

                    int randomPos = Random.Range(0, positions.Length);
                    for (int i = 0; i < Agents.Count; i++)
                    {
                        Agents[i].transform.position = positions[randomPos].position;
                        Agents[i].baseController.waveManager = this;
                        Agents[i].gameObject.SetActive(true);
                    }
                    Agents.Clear();
                }

                else
                {
                    int randomPos = Random.Range(0, positions.Length);
                    for (int i = 0; i < enemyLoadOutNumber; i++)
                    {
                        int x = Random.Range(0, Agents.Count - 1);
                        Agents[x].baseController.waveManager = this;
                        Agents[x].transform.position = positions[randomPos].position;
                        Agents[x].gameObject.SetActive(true);
                        Agents.Remove(Agents[x]);
                    }
                }

                currentWave++;
                tempTime = 0;
            }
        }

        if (killsNeeded > 0 && currentWave >= totalWaves && Agents.Count >= totalEnemyCount)
        {
            killsNeeded = 0;
            if (onWaveKilled != null)
            {
                StartCoroutine(wait());
            }
        }

    }

    public void enemyKilled()
    {
        killsNeeded--;

        if (killsNeeded <= 0)
        {
            if (onWaveKilled != null)
            {
                StartCoroutine(wait());
            }
        }
    }

    private IEnumerator wait()
    {
        yield return new WaitForSeconds(eventDelay);
        onWaveKilled.Invoke();
    }
}
