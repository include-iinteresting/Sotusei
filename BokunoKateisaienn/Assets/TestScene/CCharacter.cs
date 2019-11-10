using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//! キャラクターの状態
public enum CharacterState : short
{
    None = 0x00,
    Play = 0x01,
    Study = 0x02,
    Water = 0x03,
}


//! ステータス
public struct CharacterStatus
{
    public int iPlayPoint;
    public int iStudyPoint;
    public int iWaterPoint;
    public bool bFlag;
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
    [SerializeField]
    private int m_iCharacterID;             //! キャラクターID
    static public CharacterState m_eState;  //! キャラクターの状態
    static public CharacterStatus m_Status; //! キャラクターのステータス
    public int m_iAddStatusPoint;           //!  増加するステータスのポイント

    [SerializeField]
    [TextArea(1, 20)]
    private string m_strCharacterText;      //! オブジェクト生成時にキャラクターが喋るテキスト
    [SerializeField]
    private GameObject m_TextObject;        //! テキストのオブジェクト

    public float m_fTime;                   //! trueを返す時間
    private float m_fTimer;                 //! 経過時間をカウントするための変数

    [SerializeField]
    private string m_strPlayEvolution = "", m_strStudyEvolution = "", m_strWaterEvolution = ""; //! 進化先をインスペクターで設定するため
    public Destination m_Destination;       //! 進化先
    private GameObject m_EvolutionObject;   //! 進化先のオブジェクト

    [SerializeField]
    private int m_iNextEvolutionPoint = 0;  //! 次に進化するポイント

    [SerializeField]
    private float m_fWalkDistance;          //! 歩く距離
    public float m_fWalkTime;               //! 歩く時間
    private float m_fWalkVelocity;          //! 歩く速度

    // Start is called before the first frame update
    void Start()
    {
        m_eState = CharacterState.None; //! キャラクターの状態を初期化する
        m_fTimer = 0;                   //! カウントタイマーの初期化
        InitStatus();                   //! ステータスの初期化
        InitEvolution();                //! 進化に関するデータの初期化
        InitText();                     //! セリフの初期化

        m_fWalkVelocity = m_fWalkDistance / m_fWalkTime;    //! 歩く速度を求める
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
            case CharacterState.None:
                //Walk();
                break;
            case CharacterState.Play:
                break;
            case CharacterState.Study:
                break;
            case CharacterState.Water:
                break;
        }
    }


    /**
     * @brief   歩き
     */
     private void walk()
    {
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
                break;
            case CharacterState.Study:
                m_Status.iStudyPoint += m_iAddStatusPoint;
                break;
            case CharacterState.Water:
                m_Status.iWaterPoint += m_iAddStatusPoint;
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
        m_Status.bFlag = true;
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


    /*
     * @brief   テキスト表示の初期化
     */
     private void InitText()
    {
        CGrowthText GrowthText = m_TextObject.GetComponent<CGrowthText>();
        GrowthText.SetMessagePanel(m_strCharacterText);
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
        Debug.Log(m_eState);
    }


    /**
     * @brief   進化の処理
     */
     private void Evolution()
    {
        if (m_Status.iPlayPoint >= m_iNextEvolutionPoint)
        {
            m_EvolutionObject = (GameObject)Resources.Load(m_strPlayEvolution);
            Destroy(this.gameObject);
        }
        else if(m_Status.iStudyPoint >= m_iNextEvolutionPoint)
        {
            m_EvolutionObject = (GameObject)Resources.Load(m_strStudyEvolution);
            Destroy(this.gameObject);
        }
        else if(m_Status.iWaterPoint >= m_iNextEvolutionPoint)
        {
            m_EvolutionObject = (GameObject)Resources.Load(m_strWaterEvolution);
            Destroy(this.gameObject);
        }
    }


    /**
     * @brief   ステータスポイントの取得
     */
     static public CharacterStatus GetStatusPoint()
    {
        return m_Status;
    }


    /**
     * 
     */
    void    SetPictureBook()
    {
        Database.StorePictureBook(m_iCharacterID, m_Status);
    }
}
