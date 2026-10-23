using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class test : MonoBehaviour
{
    [SerializeField]
    public TextMeshPro TimeText;

    [SerializeField]
    public TextMeshPro ScoreText;

    [SerializeField]
    public TextMeshPro LankText;

    private float PlayTime;
    private int Score;

    // Start is called before the first frame update
    void Start()
    {
        PlayTime = 0.0f;
        Score = 0;
        TimeText.enabled = false;
        ScoreText.enabled = false;
        LankText.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (CommonArea.isStartGame)
        {
            PlayTime += Time.deltaTime;
            // TimeSpanのインスタンスを生成。
            var timespan = new TimeSpan(0, (int)(PlayTime / 60), (int)PlayTime % 60);
            // mm:ss形式に変換（String）
            var time = timespan.ToString(@"mm\:ss");

            TimeText.text = time;

            ScoreText.text = Score.ToString();
        }
    }

    public void dark()
    {
        if (CommonArea.isSpellDark)
        {
            Score += 5;
        }
    }

    public void poison()
    {
        if (CommonArea.isSpellPoison)
        {
            CommonArea.isStartGame = false;
            TimeText.enabled = true;
            ScoreText.enabled = true;
            LankText.enabled = true;
        }
    }
}
