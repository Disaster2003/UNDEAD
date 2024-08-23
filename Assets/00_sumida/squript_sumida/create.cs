using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static PostQest;


public class create : MonoBehaviour
{
    [SerializeField] Button[] buttons;
    [SerializeField] bool[] Buttonbox;
    [SerializeField] GameObject Hitcheck;

    [SerializeField] Text textNum;

    [SerializeField] Image Attackimg;

    [SerializeField] Sprite[] imgSmoke;
    [SerializeField] Image smoke;

    [SerializeField] Image changeBtl;

    [SerializeField] Image[] miniImg;

    [SerializeField] AudioClip[] SE_attack;
    AudioSource se;

    int textNumber;

    float delayTime = 0;

    float changeTime;

    public float smokeCnt = 0;
    bool smokeflg;

    public bool Attackflg;

    public int questCnt = 0;

    public int num_success = 0;

    bool playsound;

    // Start is called before the first frame update
    void Start()
    {
        se = GetComponent<AudioSource>();
        textNumber = 10;
        Attackimg.enabled = false;
        smokeflg = false;
        Attackflg = false;
        playsound = false;

        Buttonbox = new bool[buttons.Length];
        smoke.color = new Color(1, 1, 1, 0);
    }

    // Update is called once per frame
    void Update()
    {
        textNum.text = textNumber.ToString();
        if(Attackimg.enabled)
        {
            if (playsound)
            {
                se.PlayOneShot(SE_attack[0]);
                playsound = false;
            }
                delayTime += Time.deltaTime;
            if (delayTime > 3.0f)
            {
                Attackimg.enabled = false;
                for(int num_success = 0; num_success < 6; num_success++)
                {
                    buttons[num_success].GetComponent<ButtonPush>().Buttonflg = false;
                }
            }
        }

        if (smokeflg)
        {
            if (smokeCnt > 0)
            {
                smokeCnt -= Time.deltaTime;
            }
            else
            {
                smokeCnt = 0;
                smokeflg = false;
            }
            smoke.color = new Color(1, 1, 1,smokeCnt);
        }
        else if (changeTime < 0)
        {
            if (imgSmoke[1] != smoke.sprite)
            {
                changeTime = 0.5f;
                smoke.sprite = imgSmoke[1];
            }
            else
            {
                changeTime = 0;
                smokeflg = true;
            }

        }



        if (changeTime != 0)
        {
            if (playsound)
            {
                se.PlayOneShot(SE_attack[1]);
                textNumber--;
                playsound = false;
            }
            changeTime -= Time.deltaTime;
        }
    }

    public void CheckButton()
    {
        for(int i = 0;i<6;i++)
        {
            miniImg[i].enabled = false;
        }
       
        //”»’è
        for ( num_success = 0; num_success < 6; num_success++)
        {
            Buttonbox[num_success] = buttons[num_success].GetComponent<ButtonPush>().Buttonflg;

            if (Buttonbox[num_success] ==Hitcheck.GetComponent<reciveresipi>().resipidata[num_success])
            {
                buttons[num_success].GetComponent<ButtonPush>().Buttonflg = false;
                
            }
            else
            {
                break;
            }
            
        }
        if (num_success == 6)
        {
            questCnt++;
            changeTime = 0.5f;
            smoke.sprite = imgSmoke[0];
            smokeCnt = 1;
            smoke.color = new Color(1, 1, 1, smokeCnt);
        }
        else
        {
            delayTime = 0;
            Attackimg.enabled = true;
            Attackflg = true;
        }
        playsound = true;
    }
}
