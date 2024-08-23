using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Manager
    : MonoBehaviour
{
    [SerializeField] Text txtTime;  //éûä‘
    [SerializeField] Button BtnCreate;

    int build_index = 0;

    float Elapsed;  //åoâﬂéûä‘
    enum MODE
    {
        TITLE,
        RULU,
        PLAY,
        RESULT
    }
    MODE gameMode;  //ÉQÅ[ÉÄÉÇÅ[Éh

    // Start is called before the first frame update
    void Start()
    {
        gameMode = MODE.PLAY;
        Elapsed = 0.0f;

    }

    // Update is called once per frame
    void Update()
    {
        if (gameMode == MODE.PLAY)
        {
            Elapsed += Time.deltaTime;
            txtTime.text = Elapsed.ToString("f2") + "s";

            if (BtnCreate.GetComponent<create>().questCnt == 10)
            {
                if (!GameObject.FindGameObjectWithTag("Respawn"))
                {
                    PlayerPrefs.SetFloat("R6", Elapsed);    //0Çäiî[Ç∑ÇÈ
                    
                    Debug.Log(PlayerPrefs.GetFloat("R6", Elapsed));
                    build_index = SceneManager.GetActiveScene().buildIndex;
                    SceneManager.LoadScene(build_index + 1);
                }
            }
        }

    }

   
}
