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


/**
 * @class   CCharacter
 * @brief   キャラクタークラス
 */
public class CCharacter : MonoBehaviour
{
    static public CharacterState m_eState;   //! キャラクターの状態
    public CharacterStatus m_Status;   //! キャラクターのステータス
    public int m_iAddStatusPoint;      //!  増加するステータスのポイント


    public float m_fTime;               //! trueを返す時間
    private float m_fTimer;             //! 経過時間をカウントするための変数

    [SerializeField]
    private string m_strPlayEvolution, m_strStudyEvolution, m_strWaterEvolution; //! 進化先をインスペクターで設定するため
    public Destination m_Destination;   //! 進化先

    [SerializeField]
    private int m_iNextEvolutionPoint;     //! 次に進化するポイント

    // Start is called before the first frame update
    void Start()
    {
        m_eState = CharacterState.None;
        m_fTimer = 0;
        InitStatus();
        InitEvolution();
    }

    // Update is called once per frame
    void Update()
    {
        if (this.isTimer())
            Growth();

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


    /**
     * @brief   成長に関する処理
     */
    private void Growth()
    {
        switch (m_eState)
        {
            case CharacterState.Play:
                m_Status.iPlayPoint += m_iAddStatusPoint;
                Debug.Log(m_Status.iPlayPoint);
                break;
            case CharacterState.Study:
                m_Status.iStudyPoint += m_iAddStatusPoint;
                Debug.Log(m_Status.iStudyPoint);
                break;
            case CharacterState.Water:
                m_Status.iWaterPoint += m_iAddStatusPoint;
                Debug.Log(m_Status.iWaterPoint);
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
     * @brief   進化先の初期化
     */
    private void InitEvolution()
    {
        m_Destination.PlayEvolution = m_strPlayEvolution;
        m_Destination.StudyEvolution = m_strStudyEvolution;
        m_Destination.WaterEvolution = m_strWaterEvolution;
    }


    /**
     * @brief   数秒置きにtrueを返す
     * @param   [in]    time    trueを返す時間
     * @return  時間が来たらtrueを返す
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

    
    /**
     * @brief   キャラクターの状態を設定する
     * @param   [in]    State   設定するキャラクターの状態
     */
    static public void SetState(CharacterState State)
    {
        m_eState = State;
    }


    /**
     * @brief   進化の処理
     */
     private void Evolution()
    {
        if (m_Status.iPlayPoint >= m_iNextEvolutionPoint)
        {
            Destroy(this.gameObject);
        }
        else if(m_Status.iStudyPoint >= m_iNextEvolutionPoint)
        {
            Destroy(this.gameObject);
        }
        else if(m_Status.iWaterPoint >= m_iNextEvolutionPoint)
        {
            Destroy(this.gameObject);
        }
    }
}
