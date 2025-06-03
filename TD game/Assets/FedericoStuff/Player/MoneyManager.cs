using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class MoneyManager : MonoBehaviour
{
    public static int currentMoney;
    public float stopWatch;

    [SerializeField] private int moneyPerSecond;

    int seconds;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        StopWatchFunction();
    }

    void StopWatchFunction()
    {
        stopWatch += Time.deltaTime;

        if (stopWatch >= seconds)
        {
            currentMoney += moneyPerSecond;
            seconds++;
        }
    }
}
