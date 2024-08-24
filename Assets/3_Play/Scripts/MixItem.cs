using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class MixItem : MonoBehaviour
{
    [SerializeField] Button[] btnItem;
    [SerializeField] GameObject checker;

    [SerializeField] Image imgThreatZombie;
    [SerializeField] GameObject smoke;

    [SerializeField] AudioClip seSuccess;
    [SerializeField] AudioClip seFail;

    /// <summary>
    /// �N���b�N�Œ�������/���s
    /// </summary>
    public void OnClick()
    {
        // �]���r���������Ă��Ȃ�������A�������Ȃ�
        if (!checker.GetComponent<HitCheck>().isArrived)
            return;

        // �����Ă鐔�̊m�F
        int cntSuccess = 0;
        for (int i = 0; i < btnItem.Length; i++)
            if (btnItem[cntSuccess].GetComponent<ChooseItem>().isItemSwitch ==
                checker.GetComponent<HitCheck>().recipeData[i])
                cntSuccess++;
            else
                break;

        // ��������
        if (cntSuccess == 6)
        {
            GetComponent<AudioSource>().PlayOneShot(seSuccess);

            checker.GetComponent<HitCheck>().isSucceeded = true;
            smoke.GetComponent<CreateSmoke>().isCreated = true;
            smoke.GetComponent<CreateSmoke>().smokeAlpha = 1;
            smoke.GetComponent<CreateSmoke>().changeTimer = 0.5f;

            // �������]���r���Ō�Ȃ�A�^�C�}�[�X�g�b�v
            if (Spawn.cntZombie >= Spawn.zombieMax)
                if (GameObject.FindGameObjectsWithTag("Zombie").Length == 1)
                    Timer.isStoppedTimer = true;
        }
        // �������s
        else
        {
            GetComponent<AudioSource>().PlayOneShot(seFail);

            imgThreatZombie.GetComponent<Threat>().isThreatened = true;
        }

        // �f�ޑI������
        for(int i = 0; i < btnItem.Length; i++)
            btnItem[i].GetComponent<ChooseItem>().isItemSwitch = false;
    }
}
