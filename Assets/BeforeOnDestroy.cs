using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeforeOnDestroy : MonoBehaviour
{
    private void OnDestroy()
    {
        // �N���b�N��ON
        GameManager.isPlayed = true;
    }
}
