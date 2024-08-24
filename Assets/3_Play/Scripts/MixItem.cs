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
    /// クリックで調合成功/失敗
    /// </summary>
    public void OnClick()
    {
        // ゾンビが到着していなかったら、何もしない
        if (!checker.GetComponent<HitCheck>().isArrived)
            return;

        // 合ってる数の確認
        int cntSuccess = 0;
        for (int i = 0; i < btnItem.Length; i++)
            if (btnItem[cntSuccess].GetComponent<ChooseItem>().isItemSwitch ==
                checker.GetComponent<HitCheck>().recipeData[i])
                cntSuccess++;
            else
                break;

        // 調合成功
        if (cntSuccess == 6)
        {
            GetComponent<AudioSource>().PlayOneShot(seSuccess);

            checker.GetComponent<HitCheck>().isSucceeded = true;
            smoke.GetComponent<CreateSmoke>().isCreated = true;
            smoke.GetComponent<CreateSmoke>().smokeAlpha = 1;
            smoke.GetComponent<CreateSmoke>().changeTimer = 0.5f;

            // 治したゾンビが最後なら、タイマーストップ
            if (Spawn.cntZombie >= Spawn.zombieMax)
                if (GameObject.FindGameObjectsWithTag("Zombie").Length == 1)
                    Timer.isStoppedTimer = true;
        }
        // 調合失敗
        else
        {
            GetComponent<AudioSource>().PlayOneShot(seFail);

            imgThreatZombie.GetComponent<Threat>().isThreatened = true;
        }

        // 素材選択解除
        for(int i = 0; i < btnItem.Length; i++)
            btnItem[i].GetComponent<ChooseItem>().isItemSwitch = false;
    }
}
