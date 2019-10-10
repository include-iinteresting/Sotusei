using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//! キャラクターの状態
public enum CharacterState
{
    None = 0,
    Play = 1,
    Study = 2,
    Water = 3,
}


//! ステータス
public struct CharacterStatus
{
    public int iPlayPoint;
    public int iStudyPoint;
    public int iWaterPoint;
}

//! 進化先
public struct Destination
{
    public string PlayEvolution;
    public string StudyEvolution;
    public string WaterEvolution;
}

public class CCharacter : MonoBehaviour
{
    private CharacterState m_eState;   //! キャラクターの状態
    public CharacterStatus m_Status;   //! キャラクターのステータス
    public int m_iAddStatusPoint;      //!  増加するステータスのポイント


    public float m_fTime;               //! trueを返す時間
    private float m_fTimer;             //! 経過時間をカウントするための変数

    public Destination m_Destination;   //! 進化先


    // Start is called before the first frame update
    void Start()
    {
        m_eState = CharacterState.None;
        m_fTimer = 0;
        InitStatus();
    }

    // Update is called once per frame
    void Update()
    {

    }


    /**
     * @brief   動き
     */
    private void Move()
    {
        switch (m_eState)
        {
            case CharacterState.Play:
                break;
            case CharacterState.Study:
                break;
            case CharacterState.Water:
                break;
        }
    }

    private void Growth()
    {
        switch (m_eState)
        {
            case CharacterState.Play:
                m_Status.iPlayPoint += m_iAddStatusPoint;
                break;
            case CharacterState.Study:
                m_Status.iStudyPoint += m_iAddStatusPoint;
                break;
            case CharacterState.Water:
                m_Status.iStudyPoint += m_iAddStatusPoint;
                break;
        }
    }


    /**
     * @brief   ステータスの初期化
     */
    private void InitStatus()
    {
        m_Status.iPlayPoint = 0;
        m_Status.iStudyPoint = 0;
        m_Status.iWaterPoint = 0;
    }


    /**
     * @brief   数秒置きにtrueを返す
     * @param   [in]    time    trueを返す時間
     */
    private bool isTimer()
    {
        if (m_fTimer >= m_fTime)
        {
            m_fTimer = 0.0f;
            return true;
        }
        else
            m_fTimer += Time.deltaTime;

        return false;
    }
}
