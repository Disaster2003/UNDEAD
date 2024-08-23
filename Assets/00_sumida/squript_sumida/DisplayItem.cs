using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayItem : MonoBehaviour
{
    [SerializeField] Image imgItem;
    // Start is called before the first frame update
    void Start()
    {
        imgItem.color = new Color(255, 255, 255, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
