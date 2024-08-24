using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{    
    /// <summary>
    /// �V�[���ԍ�
    /// </summary>
    enum INDEX_SCENE
    {
        TITLE = 0,   // �^�C�g��
        EXPLAIN = 1, // ����
        PLAY = 2,    // �v���C
        RESULT = 3,  // ����
        CREDIT,      // �N���W�b�g
    }

    public static bool isPlayed = false;

    // Start is called before the first frame update
    void Start()
    {
        // �Q�[���I���܂ŃI�u�W�F�N�g���c��
        DontDestroyOnLoad(gameObject);
    }    

    // Update is called once per frame
    void Update()
    {
        // �N���b�N����炷
        if (isPlayed)
        {
            isPlayed = false;
            GetComponent<AudioSource>().Play();
        }

        // ���ʉ�ʂ�
        if(SceneManager.GetActiveScene().buildIndex == (int)INDEX_SCENE.PLAY)
        {
            if (Spawn.cntZombie >= Spawn.zombieMax)
                if (!GameObject.FindGameObjectWithTag("Zombie"))
                    OnClickNextScene();
        }
    }

    /// <summary>
    /// �N���b�N������A���̃V�[����
    /// </summary>
    public void OnClickNextScene()
    {
        // ���̃V�[����
        int buildIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadSceneAsync(buildIndex + 1);
    }

    /// <summary>
    /// �N���b�N������A�^�C�g����
    /// </summary>
    public void OnClickTitle()
    {
        // �^�C�g����
        SceneManager.LoadSceneAsync((int)INDEX_SCENE.TITLE);
    }

    /// <summary>
    /// �N���b�N������A�N���W�b�g��
    /// </summary>
    public void OnClickCredit()
    {
        // �N���W�b�g��
        SceneManager.LoadSceneAsync((int)INDEX_SCENE.CREDIT);
    }
}
