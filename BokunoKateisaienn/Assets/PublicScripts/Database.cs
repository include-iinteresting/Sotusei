using System.Collections;
using System.Collections.Generic;
using UnityEngine;



/**
 * @class   DatabaseClass
 * @brief   ローカルなデータベースを実装
 */
static public class Database
{
    //! キャラクター図鑑
    static public Dictionary<int, CharacterStatus> m_PictureBook = new Dictionary<int, CharacterStatus>();
    
    /**
     * @brief   ディクショナリにデータの追加
     * @param   [in]    strKey  キャラクターのID
     * @param   [in]    bFlag   フラグ
     */
    static  public  void    StorePictureBook(int iCharacterID, CharacterStatus csStatus)
    {
        //!<    図鑑に追加
        m_PictureBook.Add(iCharacterID, csStatus);
    }


    /**
     * @brief   図鑑のデータを取得
     * @param   [in]    strKey  キャラクターの名前
     * @return  データの取得
     */
    static  public  CharacterStatus    GetPictureBook(int iCharacter)
    {
        return m_PictureBook[iCharacter];
    }

}
