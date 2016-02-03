using UnityEngine;
using System.Collections;

public class SelectItemArrow : MonoBehaviour
{
    const int startPos = 150;
    const int offSet = -50;
    
    //------------------------------

    void Update()
    {
        transform.Rotate(1, 0, 0);

        transform.localPosition = new Vector3(
            0, startPos + (offSet * TextManager.Row), 0);
    }
}
