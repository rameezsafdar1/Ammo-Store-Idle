using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class AIWaveManager : MonoBehaviour
{
    public List<GameObject> Agents = new List<GameObject>();
    public int enemyLoadOutNumber;
    public float waveTime;
    private float tempTime;
    public int totalWaves;
    private int currentWave;
    public UnityEvent onWaveKilled;
    public float eventDelay;
    private int killsNeeded;

    private void OnEnable()
    {
        currentWave = 0;
        killsNeeded = totalWaves * enemyLoadOutNumber;
    }

    private void Start()
    {
        for (int i = 0; i < enemyLoadOutNumber; i++)
        {
            Agents[i].SetActive(true);
            Agents.Remove(Agents[i]);
        }
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
                    for (int i = 0; i < Agents.Count; i++)
                    {
                        Agents[i].SetActive(true);
                    }
                    Agents.Clear();
                }

                else
                {
                    for (int i = 0; i < enemyLoadOutNumber; i++)
                    {
                        int x = Random.Range(0, Agents.Count - 1);
                        Agents[x].SetActive(true);
                        Agents.Remove(Agents[x]);
                    }
                }

                currentWave++;
                tempTime = 0;
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
