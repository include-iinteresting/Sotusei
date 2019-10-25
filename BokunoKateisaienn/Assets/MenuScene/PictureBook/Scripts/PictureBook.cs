using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PictureBook : MonoBehaviour
{
    [SerializeField]
    private int     m_iPictureBookID;       //! 図鑑ID
    private bool    m_bFlag;                //! 図鑑フラグ
   
    // Start is called before the first frame update
    void Start()
    {
        m_bFlag = false;

        foreach(KeyValuePair<int, CharacterStatus> character in Database.m_PictureBook)
        {
            if (character.Key == m_iPictureBookID)
            {
                m_bFlag = character.Value.bFlag;
                break;
            }
        }
  
    }


    /**
     * @brief   フラグの取得
     */
    public bool GetFlag()
    {
        return m_bFlag;
    }
}
