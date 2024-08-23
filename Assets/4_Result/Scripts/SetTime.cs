using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetTime : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // クリア時のタイムを設定する
        GetComponent<Text>().text = PlayerPrefs.GetFloat("R" + 6).ToString("f2") + "s";
    }
}
