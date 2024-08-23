using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseItem : MonoBehaviour
{
    [SerializeField] GameObject chooseItem;
    private Color colorChooseItem;
    public bool isItemSwitch = false;

    // Start is called before the first frame update
    void Start()
    {
        // ���߂̓A�C�e�����\������
        chooseItem.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 0);
    }

    // Update is called once per frame
    void Update()
    {
        // �A�C�e����\��
        if (isItemSwitch)
            chooseItem.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 255);
        // �A�C�e�����\��
        else
            chooseItem.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 0);
    }

    /// <summary>
    /// �N���b�N�ŃA�C�e���̕\��/��\���̐؂�ւ����s��
    /// </summary>
    public void OnClick()
    {
        // �A�C�e���̕\��/��\���̐؂�ւ�
        isItemSwitch ^= true;
    }
}
