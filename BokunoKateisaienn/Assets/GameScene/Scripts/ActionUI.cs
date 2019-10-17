using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//! 選択したUIの状態
public enum SelectState
{
    SELECT_NONE = 0x00,
    SELECT_PLAY = 0x01,
    SELECT_STUDY = 0x02,
    SELECT_WATER = 0x03,
    SELECT_LIBRARY = 0x04

}

//! 判定の範囲
struct CollideArea
{
    public float fx;
    public float fy;
    public float fwidth;
    public float fheight;
};


/**
 * @class   ActionUI
 * @brief   行動を選択するUIに関するクラス
 */
public class ActionUI : MonoBehaviour
{
    private CollideArea m_CollideArea;  //! 判定の範囲
    public SelectState m_eThisState;    //! このスクリプトをアタッチするUIの種類
  
    // Start is called before the first frame update
    void Start()
    {
        InitCollideArea();  //! 判定範囲の初期化
        
    }


    // Update is called once per frame
    private void Update()
    {
        SelectUI();
    }


    /**
     * @brief   UIを選択する
     */
    public SelectState SelectUI()
    {
        //! タッチが離されたら
        if (InputManager.GetTouch() == TouchInfo.Ended)
        {
            //! タッチされた座標を取得
            Vector3 TouchPosition = InputManager.GetTouchPosition();
            //! 判定の確認
            if (TouchPosition.x >= m_CollideArea.fx && TouchPosition.y >= m_CollideArea.fy && TouchPosition.x <= m_CollideArea.fwidth && TouchPosition.y <= m_CollideArea.fheight)
            {
                switch(m_eThisState)
                {
                    case SelectState.SELECT_PLAY:
                        CCharacter.SetState(CharacterState.Play);
                        break;
                    case SelectState.SELECT_STUDY:
                        CCharacter.SetState(CharacterState.Study);
                        break;
                    case SelectState.SELECT_WATER:
                        CCharacter.SetState(CharacterState.Water);
                        break;
                }
            }
        }
        return SelectState.SELECT_NONE;
    }


    /**
     * @brief   当たり判定の範囲を設定する
     */
    private void InitCollideArea()
    {
        RectTransform rect = gameObject.GetComponent<RectTransform>();
        Vector2 UISize = rect.sizeDelta;    
        Vector3 UIPosition = rect.position;
        m_CollideArea.fx = UIPosition.x;
        m_CollideArea.fy = UIPosition.y;
        m_CollideArea.fwidth = UISize.x;
        m_CollideArea.fheight = UISize.y;
    }


}
