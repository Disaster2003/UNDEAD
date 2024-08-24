using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    [SerializeField] GameObject speechBubble;
    [SerializeField] GameObject[] item;
    public bool[] recipeData = new bool[6];
    private Vector2 positionReceive = new Vector2(6, -2);
    private Vector2 positionGoHome = new Vector2(1, -2);
    private Vector2 positionWait = new Vector2(8, -2);
    /// <summary>
    /// �]���r�̏��
    /// </summary>
    private enum ZOMBIE_STATE
    {
        WAIT = 0,    // �҂�
        RECEIVE = 1, // ��̎󂯎��
        GO_HOME = 2, // �A��
    }
    private ZOMBIE_STATE zombieState = ZOMBIE_STATE.WAIT;

    [SerializeField] Sprite[] zombie;
    public bool isMan = false;

    // Start is called before the first frame update
    void Start()
    {
        // �����z�u
        transform.position = new Vector2(10, -2);

        // �����o���E�����f�ނ��\��
        speechBubble.GetComponent<SpriteRenderer>().enabled = false;
        for (int i = 0; i < item.Length; i++)
            item[i].GetComponent<SpriteRenderer>().enabled = false;

        // ���V�s�̍쐬
        MakeRecipe();

        // �R�X�`���[���I��
        int tmp = Random.Range(0, zombie.Length);
        GetComponent<SpriteRenderer>().sprite = zombie[tmp];
        if (tmp == 0)
            isMan = true;
    }

    // Update is called once per frame
    void Update()
    {
        switch(zombieState)
        {
            case ZOMBIE_STATE.WAIT:
                // �O�̃]���r���|������A�󂯎��ɍs��
                // ����:inspector��Zombie��tag���uZombie�v��
                if (GameObject.FindGameObjectsWithTag("Zombie").Length == 1)
                    zombieState = ZOMBIE_STATE.RECEIVE;
                // �ҋ@�ꏊ�܂ňړ�
                else if (transform.position.x > positionWait.x)
                    transform.position = new Vector2(transform.position.x - Time.deltaTime, -2);
                break;
            case ZOMBIE_STATE.RECEIVE:
                // �󂯎��ꏊ�܂ňړ�
                if (transform.position.x > positionReceive.x)
                    transform.position = new Vector2(transform.position.x - Time.deltaTime, -2);
                else
                {
                    // �����o���E�K�v�Ȓ����f�ނ�\��
                    speechBubble.GetComponent<SpriteRenderer>().enabled = true;
                    for (int i = 0; i < recipeData.Length; i++)
                        item[i].GetComponent<SpriteRenderer>().enabled = recipeData[i];
                }
                break;
            case ZOMBIE_STATE.GO_HOME:
                // �����o���E�K�v�Ȓ����f�ނ�\��
                speechBubble.GetComponent<SpriteRenderer>().enabled = false;
                for (int i = 0; i < recipeData.Length; i++)
                    item[i].GetComponent<SpriteRenderer>().enabled = false;

                // �A��
                if (transform.position.x > positionGoHome.x)
                    transform.position = new Vector2(transform.position.x - Time.deltaTime, -2);
                else
                    Destroy(gameObject);
                break;
            default:
                break;
        }
    }

    /// <summary>
    /// ���V�s���쐬����
    /// </summary>
    private void MakeRecipe()
    {
        // ���V�s�̍쐬
        int cntNone = 0;
        for (int i = 0; i < recipeData.Length; i++)
        {
            recipeData[i] = System.Convert.ToBoolean(Random.Range(0, 2));
            if (!recipeData[i])
                cntNone++;
        }

        // ���������f�ނ��w�肳��Ă��Ȃ�������A��蒼��
        if (cntNone == 6)
            MakeRecipe();
    }

    /// <summary>
    /// �A�������
    /// </summary>
    public void SetGoHome()
    {
        zombieState = ZOMBIE_STATE.GO_HOME;
    }
}
