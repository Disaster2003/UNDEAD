using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetTime : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // �N���A���̃^�C����ݒ肷��
        GetComponent<Text>().text = PlayerPrefs.GetFloat("R6").ToString("f2") + "s";
    }
}
