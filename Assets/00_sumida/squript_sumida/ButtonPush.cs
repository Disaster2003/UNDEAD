using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonPush : MonoBehaviour
{
    public bool Buttonflg;

    [SerializeField] Image miniImg;

    // Start is called before the first frame update
    void Start()
    {
        miniImg.enabled = false;
        Buttonflg = false;
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    public void CheckButton()
    {
        if(Buttonflg)
        {
            Buttonflg = false;
            miniImg.enabled = false;
        }
        else
        {
            Buttonflg = true;
            miniImg.enabled = true;
        }
    }
}
