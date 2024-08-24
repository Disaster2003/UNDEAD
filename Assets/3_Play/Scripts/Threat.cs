using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Threat : MonoBehaviour
{
    public bool isThreatened = false;
    [SerializeField] GameObject checker;
    [SerializeField] Sprite[] threatZombie;

    private float delayTime = 3;

    // Update is called once per frame
    void Update()
    {
        if(GetComponent<Image>().enabled)
        {
            if (delayTime <= 0)
            {
                delayTime = 3;
                GetComponent<Image>().enabled = false;
            }
            delayTime -= Time.deltaTime;
        }
        else if (isThreatened)
        {
            isThreatened = false;
            if (checker)
                GetComponent<Image>().sprite = threatZombie[0];
            else
                GetComponent<Image>().sprite = threatZombie[1];

            GetComponent<Image>().enabled = true;
        }
    }
}
