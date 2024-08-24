using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    private float timer;
    public static bool isStoppedTimer = false;

    // Update is called once per frame
    void Update()
    {
        // ¡‚µ‚½”‚ªãŒÀ‚È‚çA‰½‚à‚µ‚È‚¢
        if (isStoppedTimer)
        {
            PlayerPrefs.SetFloat("R6", timer);
            return;
        }

        // ŠÔŒv‘ª
        timer += Time.deltaTime;
        GetComponent<Text>().text = timer.ToString("f2") + "s";
    }
}
