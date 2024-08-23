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
        // Ž¡‚µ‚½”‚ªãŒÀ‚È‚çA‰½‚à‚µ‚È‚¢
        if (Spawn.cntZombie >= Spawn.zombieMax)
            return;

        // ŽžŠÔŒv‘ª
        timer += Time.deltaTime;
        GetComponent<Text>().text = timer.ToString("f2") + "s";
    }
}
