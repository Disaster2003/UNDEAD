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
        // ��莞�Ԍo�߂ŉ摜���\��
        if(GetComponent<Image>().enabled)
        {
            if (delayTime <= 0)
            {
                delayTime = 3;
                GetComponent<Image>().enabled = false;
            }
            delayTime -= Time.deltaTime;
        }
        // ���ʒʂ�̉摜��I��
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
