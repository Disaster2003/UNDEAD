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

    /// <summary>
    /// ÉNÉäÉbÉNÇ≈í≤çáê¨å˜/é∏îs
    /// </summary>
    public void OnClick()
    {
        if (!checker.GetComponent<HitCheck>().isArrived)
            return;

        int cntSuccess = 0;
        for (int i = 0; i < btnItem.Length; i++)
            if (btnItem[cntSuccess].GetComponent<ChooseItem>().isItemSwitch ==
                checker.GetComponent<HitCheck>().recipeData[i])
                cntSuccess++;
            else
                break;

        if (cntSuccess == 6)
        {
            checker.GetComponent<HitCheck>().isSucceeded = true;
            smoke.GetComponent<CreateSmoke>().isCreated = true;
            smoke.GetComponent<CreateSmoke>().smokeAlpha = 1;
            smoke.GetComponent<CreateSmoke>().changeTimer = 0.5f;

            if (Spawn.cntZombie >= Spawn.zombieMax)
                if (GameObject.FindGameObjectsWithTag("Zombie").Length==1)
                    Timer.isStoppedTimer = true;
        }
        else
            imgThreatZombie.GetComponent<Threat>().isThreatened = true;

        for(int i = 0; i < btnItem.Length; i++)
            btnItem[i].GetComponent<ChooseItem>().isItemSwitch = false;
    }
}
