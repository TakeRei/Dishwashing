using System.Collections;
using System.Collections.Generic;
using Microsoft.MixedReality.Toolkit.Diagnostics;
using Microsoft.MixedReality.Toolkit.Input;
using Microsoft.MixedReality.Toolkit.Utilities;
using UnityEngine;
using TMPro;
using System;

public class DisplayEffect : MonoBehaviour
{
    [SerializeField]
    public GameObject EffectDarkBef;

    [SerializeField]
    public GameObject EffectDarkAft;

    [SerializeField]
    public GameObject EffectPoisonBef;

    [SerializeField]
    public GameObject EffectPoisonAft;

    [SerializeField]
    public GameObject EffectFireBef;

    [SerializeField]
    public GameObject EffectFireAft;

    [SerializeField]
    public GameObject EffectLast;

    [SerializeField]
    public GameObject MagicMenu;

    [SerializeField]
    public GameObject EndPlane;

    [SerializeField]
    public GameObject RestartButton;

    [SerializeField]
    public TextMeshPro TimeText;

    [SerializeField]
    public TextMeshPro ScoreText;

    [SerializeField]
    public TextMeshPro LankText;

    [SerializeField] private AudioSource audioSource; // 音声再生用

    [SerializeField] private AudioClip ClearMagic; // 魔法成功時の音源
    [SerializeField] private AudioClip MissMagic;　//魔法失敗時の音源
    [SerializeField] private AudioClip LastMagic;　//最後の魔法の音源

    [SerializeField] private AudioClip ssClip; // SSランク用音源
    [SerializeField] private AudioClip sClip; // Sランク用音源
    [SerializeField] private AudioClip aClip; // Aランク用音源
    [SerializeField] private AudioClip bClip; // Bランク用音源
    [SerializeField] private AudioClip cClip; // Cランク用音源
    [SerializeField] private AudioClip dClip; // Dランク用音源



    /// <summary>
    /// ランダム生成器
    /// </summary>
    private System.Random random = new System.Random();

    /// <summary>
    /// 選ばれた魔法（エフェクト）の識別子
    /// </summary>
    private int selectedMagic = -1;

    /// <summary>
    /// エフェクトの表示、非表示の確認
    /// </summary>
    private bool isSetMagic = true;

    /// <summary>
    /// スコアとコルーチンを一回だけ実行するためのフラグ
    /// </summary>
    private bool isSetScore = true;

    /// <summary>
    /// 時間計測
    /// </summary>
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
        Magic_pos();
      
        // エフェクトを表示していなかったら
        if (isSetMagic)
        {
            isSetMagic = false;
            ResetEffects();
            // ランダム生成の準備
            selectedMagic = random.Next(0, 3);
        }

        else
        {
            UpdateEffect(selectedMagic);
        }

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
        Debug.Log(Score);
    }

    /// <summary>
    /// ランダムで選ばれたエフェクトを開始する
    /// </summary>
    private void UpdateEffect(int magicType)
    {
        Debug.Log($"StartEffect: 選ばれた魔法タイプは {magicType}");
        switch (magicType)
        {
            case 0:
                Magic_dark();
                break;
            case 1:
                Magic_poison();
                break;
            case 2:
                Magic_fire();
                break;
        }
    }

    public void ResetEffects()
    {
        EffectDarkBef.SetActive(false);
        EffectDarkAft.SetActive(false);
        EffectPoisonBef.SetActive(false);
        EffectPoisonAft.SetActive(false);
        EffectFireBef.SetActive(false);
        EffectFireAft.SetActive(false);
    }

    /// <summary>
    /// エフェクトの位置更新
    /// </summary>
    /// 
    public void Magic_pos()
    {
        Vector3 offset = new Vector3(0.1f, 0, 0);
        Quaternion rotationOffset = Quaternion.Euler(35, 0, 0);

        EffectDarkBef.transform.position = CommonArea.poseLeftThumbProximal.Position + offset;
        EffectDarkBef.transform.rotation = CommonArea.poseLeftThumbProximal.Rotation * rotationOffset;

        EffectPoisonBef.transform.position = CommonArea.poseLeftThumbProximal.Position + offset;
        EffectPoisonBef.transform.rotation = CommonArea.poseLeftThumbProximal.Rotation * rotationOffset;

        EffectFireBef.transform.position = CommonArea.poseLeftThumbProximal.Position + offset;
        EffectFireBef.transform.rotation = CommonArea.poseLeftThumbProximal.Rotation * rotationOffset;

        // すでに表示されている状態で位置を更新
        Vector3 offset2 = new Vector3(0.1f, 0, 0);
        Quaternion rotationOffset2 = Quaternion.Euler(0, 0, 0);

        EffectDarkAft.transform.position = CommonArea.poseLeftThumbProximal.Position + offset2;
        EffectDarkAft.transform.rotation = CommonArea.poseLeftThumbProximal.Rotation * rotationOffset2;

        EffectPoisonAft.transform.position = CommonArea.poseLeftThumbProximal.Position + offset2;
        EffectPoisonAft.transform.rotation = CommonArea.poseLeftThumbProximal.Rotation * rotationOffset2;

        EffectFireAft.transform.position = CommonArea.poseLeftThumbProximal.Position + offset2;
        EffectFireAft.transform.rotation = CommonArea.poseLeftThumbProximal.Rotation * rotationOffset2;

        EffectLast.transform.position = CommonArea.poseLeftThumbProximal.Position + offset2;
        EffectLast.transform.rotation = CommonArea.poseLeftThumbProximal.Rotation * rotationOffset2;
    }

    public void Magic_dark()
    {
        // 左手の親指第三関節
        if (CommonArea.isHandDisplayLeftThumbProximal)
        {
            EffectDarkBef.SetActive(true);

            if (CommonArea.isSpellDark)
            {
                EffectDarkBef.SetActive(false);
                EffectDarkAft.SetActive(true);
                if (isSetScore)
                {
                    audioSource.PlayOneShot(ClearMagic);
                    Score += 5;
                    isSetScore = false;
                    StartCoroutine("ReloadEffect"); // 3秒後に再ランダム生成
                }
                
            }

            if (CommonArea.isSpellLast)
            {
                EffectDarkBef.SetActive(false);
                EffectLast.SetActive(true);
                if (isSetScore)
                {
                    audioSource.PlayOneShot(LastMagic);
                    Score += 5;
                    isSetScore = false;
                    StartCoroutine("EndGame");
                }
              
            }

            if (CommonArea.isSpellPoison)
            {
                audioSource.PlayOneShot(MissMagic);
                CommonArea.isSpellPoison = false;
                Score -= 2;
            }

            if (CommonArea.isSpellFire)
            {
                audioSource.PlayOneShot(MissMagic);
                CommonArea.isSpellFire = false;
                Score -= 2;
            }
        }
        else
        {
            EffectDarkBef.SetActive(false);
            EffectDarkAft.SetActive(false);
        }
    }

    public void Magic_poison()
    {
        // 左手の親指第三関節
        if (CommonArea.isHandDisplayLeftThumbProximal)
        {
            EffectPoisonBef.SetActive(true);

            if (CommonArea.isSpellPoison)
            {
                EffectPoisonBef.SetActive(false);
                EffectPoisonAft.SetActive(true);
                if (isSetScore)
                {
                    audioSource.PlayOneShot(ClearMagic);
                    Score += 5;
                    isSetScore = false;
                    StartCoroutine("ReloadEffect"); // 3秒後に再ランダム生成
                }
                
            }

            if (CommonArea.isSpellLast)
            {
                EffectPoisonBef.SetActive(false);
                EffectLast.SetActive(true);
                if (isSetScore)
                {
                    audioSource.PlayOneShot(LastMagic);
                    Score += 5;
                    isSetScore = false;
                    StartCoroutine("EndGame");
                }
            }

            if (CommonArea.isSpellDark)
            {
                audioSource.PlayOneShot(MissMagic);
                CommonArea.isSpellDark = false;
                Score -= 2;
            }

            if (CommonArea.isSpellFire)
            {
                audioSource.PlayOneShot(MissMagic);
                CommonArea.isSpellFire = false;
                Score -= 2;
            }

        }
        else
        {
            EffectPoisonBef.SetActive(false);
            EffectPoisonAft.SetActive(false);
        }
    }

    public void Magic_fire()
    {
        // 左手の親指第三関節
        if (CommonArea.isHandDisplayLeftThumbProximal)
        {  
            EffectFireBef.SetActive(true);

            if (CommonArea.isSpellFire)
            {
                EffectFireBef.SetActive(false);
                EffectFireAft.SetActive(true);
                
                if (isSetScore)
                {
                    audioSource.PlayOneShot(ClearMagic);
                    Score += 5;
                    isSetScore = false;
                    StartCoroutine("ReloadEffect"); // 3秒後に再ランダム生成
                }
                
            }

            if (CommonArea.isSpellLast)
            {
                EffectFireBef.SetActive(false);
                EffectLast.SetActive(true);
                if (isSetScore)
                {
                    audioSource.PlayOneShot(LastMagic);
                    Score += 5;
                    isSetScore = false;
                    StartCoroutine("EndGame");
                }
                
            }

            if (CommonArea.isSpellPoison)
            {
                audioSource.PlayOneShot(MissMagic);
                CommonArea.isSpellPoison = false;
                Score -= 2;
            }

            if (CommonArea.isSpellDark)
            {
                audioSource.PlayOneShot(MissMagic);
                CommonArea.isSpellDark = false;
                Score -= 2;
            }
        }
        else
        {
            EffectFireBef.SetActive(false);
            EffectFireAft.SetActive(false);
        }
    }

    // エフェクトの切り替え後、3秒待機して再ランダム生成を行うコルーチン
    IEnumerator ReloadEffect()
    {
        yield return new WaitForSeconds(3.0f);

        //AfterEffect非表示
        EffectDarkAft.SetActive(false);
        EffectPoisonAft.SetActive(false);
        EffectFireAft.SetActive(false);

        CommonArea.isSpellDark = false;
        CommonArea.isSpellPoison = false;
        CommonArea.isSpellFire = false;

        isSetMagic = true;
        isSetScore = true;
    }

    IEnumerator EndGame()
    {
        yield return new WaitForSeconds(3.0f);

        CommonArea.isStartGame = false;
        EffectLast.SetActive(false);
        CommonArea.isSpellLast = false;
        Destroy(GetComponent<DisplayEffect>());//エフェクトの表示停止（スクリプトを取り除く）
        MagicMenu.SetActive(false);
        EndPlane.SetActive(true);
        RestartButton.SetActive(true);
        TimeText.enabled = true;
        ScoreText.enabled = true;
        LankText.enabled = true;

        string rank = CalculateRank(PlayTime, Score);
        LankText.text = rank;
        PlayRankSound(rank);// ランクごとに音源再生
        Debug.Log(rank);
    }

    private string CalculateRank(float playTime, int score)
    {
        int seconds = (int)playTime;

        if (seconds <= 60)
        {
            if (score >= 50) return "SS";
            else if (score >= 40) return "S";
            else if (score >= 30) return "A";
            else if (score >= 20) return "B";
            else if (score >= 10) return "C";
            else return "D";
        }
        else if (seconds <= 120)
        {
            if (score >= 100) return "SS";
            else if (score >= 80) return "S";
            else if (score >= 60) return "A";
            else if (score >= 40) return "B";
            else if (score >= 20) return "C";
            else return "D";
        }
        else if (seconds <= 180)
        {
            if (score >= 150) return "SS";
            else if (score >= 120) return "S";
            else if (score >= 90) return "A";
            else if (score >= 60) return "B";
            else if (score >= 30) return "C";
            else return "D";
        }
        else if (seconds <= 240)
        {
            if (score >= 200) return "SS";
            else if (score >= 160) return "S";
            else if (score >= 120) return "A";
            else if (score >= 80) return "B";
            else if (score >= 40) return "C";
            else return "D";
        }
        else if (seconds <= 300)
        {
            if (score >= 250) return "SS";
            else if (score >= 200) return "S";
            else if (score >= 150) return "A";
            else if (score >= 100) return "B";
            else if (score >= 50) return "C";
            else return "D";
        }
        else if (seconds <= 360)
        {
            if (score >= 300) return "SS";
            else if (score >= 240) return "S";
            else if (score >= 180) return "A";
            else if (score >= 120) return "B";
            else if (score >= 60) return "C";
            else return "D";
        }
        else
        {
            return "D"; // Default rank if time exceeds the table
        }
    }
    private void PlayRankSound(string rank)
    {
        // ランクに応じて対応する音源を再生
        switch (rank)
        {
            case "SS":
                audioSource.clip = ssClip;
                break;
            case "S":
                audioSource.clip = sClip;
                break;
            case "A":
                audioSource.clip = aClip;
                break;
            case "B":
                audioSource.clip = bClip;
                break;
            case "C":
                audioSource.clip = cClip;
                break;
            case "D":
                audioSource.clip = dClip;
                break;
            default:
                Debug.LogWarning("ランクに対応する音源が見つかりません！");
                return;
        }

        // 音源を再生
        audioSource.Play();
    }

}