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
        // ��������������Ȃ�A�������Ȃ�
        if (Spawn.cntZombie >= Spawn.zombieMax)
            return;

        // ���Ԍv��
        timer += Time.deltaTime;
        GetComponent<Text>().text = timer.ToString("f2") + "s";
    }
}
