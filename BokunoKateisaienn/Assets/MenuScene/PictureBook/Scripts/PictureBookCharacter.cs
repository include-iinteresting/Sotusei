using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PictureBookCharacter : MonoBehaviour
{
    void Start()
    {
        GameObject parent = this.transform.parent.gameObject;           //! 親オブジェクト
        bool m_bFlag = parent.GetComponent<PictureBook>().GetFlag();    //! 図鑑フラグの取得

        if (m_bFlag)
        {
            this.gameObject.GetComponent<Image>().color = new Color(1, 1, 1);
        }
        else
        {
            this.gameObject.GetComponent<Image>().color = new Color(0, 0, 0);
        }
    }
}
