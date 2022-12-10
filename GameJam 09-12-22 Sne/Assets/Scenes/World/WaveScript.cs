using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WaveScript : MonoBehaviour
{
    public EnemyObjectPool objPool;
    public TextMeshProUGUI pressToStartText;
    public TextMeshProUGUI txtWavecount;

    public int wave;


    public bool waitForStart = true;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (waitForStart)
        {
            pressToStartText.gameObject.SetActive(true);
            if (Input.GetKeyDown(KeyCode.Return))
            {
                startWave();
            }
        }
        else
        {
            pressToStartText.gameObject.SetActive(false);
            GameObject[] gos = GameObject.FindGameObjectsWithTag("Enemy"); ;
            if (gos.Length == 0)
            {
                endWave();
            }
        }

        txtWavecount.text = "Wave: " + wave.ToString();
    }

    public void startWave()
    {
        waitForStart = false;
        wave++;
        int rngEnmy = Mathf.RoundToInt(Mathf.Pow(wave, 2) / 3);
        int scdEnmy = Mathf.RoundToInt((Mathf.Pow(wave, 2) / 3) * 2);
        objPool.EnableEnemies(scdEnmy,rngEnmy);
    }

    public void endWave()
    {
        waitForStart = true;
    }
}
