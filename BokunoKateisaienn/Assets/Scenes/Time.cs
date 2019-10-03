using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Time : MonoBehaviour
{

    private Text ClockText;

    // Use this for initialization
    void Start()
    {
        ClockText = GetComponentInChildren<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        // 取得する値: 年
        ClockText.text = System.DateTime.Now.Year.ToString();
        ClockText.text += "年";
        // 取得する値: 月
        ClockText.text += System.DateTime.Now.Month.ToString();
        ClockText.text += "月";
        // 取得する値: 日
        ClockText.text += System.DateTime.Now.Day.ToString();
        ClockText.text += "日";
        // 取得する値: 時
        ClockText.text += System.DateTime.Now.Hour.ToString();
        ClockText.text += "時";
        // 取得する値: 分
        ClockText.text += System.DateTime.Now.Minute.ToString();
        ClockText.text += "分";
        // 取得する値: 秒
        ClockText.text += System.DateTime.Now.Second.ToString();
        ClockText.text += "秒";
        // 取得する値: コンマミリ秒
        ClockText.text += System.DateTime.Now.Millisecond.ToString();
        ClockText.text += "mm秒";
    }

}