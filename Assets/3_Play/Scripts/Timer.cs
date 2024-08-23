using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    private float timer;

    // Update is called once per frame
    void Update()
    {
        // 治した数が上限なら、何もしない
        if (Spawn.cntZombie >= Spawn.zombieMax)
            return;

        // 時間計測
        timer += Time.deltaTime;
        GetComponent<Text>().text = timer.ToString("f2") + "s";
    }
}
