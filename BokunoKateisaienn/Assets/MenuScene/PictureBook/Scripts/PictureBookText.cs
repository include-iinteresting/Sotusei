using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PictureBookText : MonoBehaviour
{
    [SerializeField]
    private string m_strCharacterName;           //! キャラクターの名前
    
    // Start is called before the first frame update
    void Start()
    {
        GameObject parent = this.transform.parent.gameObject.transform.parent.gameObject;           //! 親オブジェクト
        bool m_bFlag = parent.GetComponent<PictureBook>().GetFlag();                                //! 図鑑フラグの取得

        if (m_bFlag)
        {
            this.gameObject.GetComponent<Text>().text = m_strCharacterName;
        }
        else
        {
            this.gameObject.GetComponent<Text>().text = " ? ? ? ";
        }
    }
}
