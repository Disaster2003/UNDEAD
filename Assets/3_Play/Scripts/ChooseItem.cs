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
        // 初めはアイテムを非表示する
        chooseItem.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 0);
    }

    // Update is called once per frame
    void Update()
    {
        // アイテムを表示
        if (isItemSwitch)
            chooseItem.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 255);
        // アイテムを非表示
        else
            chooseItem.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 0);
    }

    /// <summary>
    /// クリックでアイテムの表示/非表示の切り替えを行う
    /// </summary>
    public void OnClick()
    {
        // アイテムの表示/非表示の切り替え
        isItemSwitch ^= true;
    }
}
