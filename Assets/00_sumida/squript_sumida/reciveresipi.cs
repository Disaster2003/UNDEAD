using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class reciveresipi : MonoBehaviour
{
    public bool[] resipidata = new bool[6];
    bool backflg;
    [SerializeField] Button createbutton;

    PostQest postQest;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        postQest = collision.gameObject.GetComponent<PostQest>();

        for (int i = 0; i < 6; i++)
        {
            resipidata[i] = postQest.correctAnswers[i];
        }
    }

    void Update()
    {
        if (createbutton.GetComponent<create>().num_success == 6)
        {
            createbutton.GetComponent<create>().num_success = 0;
            postQest.ZonbiBack();
        }
    }
}
