using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Threat : MonoBehaviour
{
    private float delayTime = 3;
    public bool isThreatened = false;

    [SerializeField] GameObject checker;
    [SerializeField] Sprite[] threatZombie;

    // Update is called once per frame
    void Update()
    {
        // 一定時間経過で画像を非表示
        if(GetComponent<Image>().enabled)
        {
            if (delayTime <= 0)
            {
                delayTime = 3;
                GetComponent<Image>().enabled = false;
            }
            delayTime -= Time.deltaTime;
        }
        // 性別通りの画像を選択
        else if (isThreatened)
        {
            isThreatened = false;
            if (checker.GetComponent<HitCheck>().isMan)
                GetComponent<Image>().sprite = threatZombie[0];
            else
                GetComponent<Image>().sprite = threatZombie[1];

            GetComponent<Image>().enabled = true;
        }
    }
}
