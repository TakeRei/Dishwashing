using System.Collections;
using System.Collections.Generic;
using Microsoft.MixedReality.Toolkit.Diagnostics;
using Microsoft.MixedReality.Toolkit.Input;
using Microsoft.MixedReality.Toolkit.Utilities;
using UnityEngine;

public class CommonArea : MonoBehaviour
{
    /// <summary>
    /// 右手の人差し指先端の位置
    /// </summary>
    public static MixedRealityPose poseRightIndexTip;

    /// <summary>
    /// 左手の人差し指先端の位置
    /// </summary>
    public static MixedRealityPose poseLeftIndexTip;

    /// <summary>
    /// 右手親指第三関節の位置
    /// </summary>
    public static MixedRealityPose poseRightThumbProximal;

    /// <summary>
    /// 左手親指第三関節の位置
    /// </summary>
    public static MixedRealityPose poseLeftThumbProximal;

    /// <summary>
    /// 右手首の位置
    /// </summary>
    public static MixedRealityPose poseRightWrist;

    /// <summary>
    /// 左手首の位置
    /// </summary>
    public static MixedRealityPose poseLeftWrist;


    public static bool isHandDisplayRightIndexTip;
    public static bool isHandDisplayLeftIndexTip;
    public static bool isHandDisplayRightThumbProximal;
    public static bool isHandDisplayLeftThumbProximal;
    public static bool isHandDisplayRightWrist;
    public static bool isHandDisplayLeftWrist;

    public static bool isSpellDark;
    public static bool isSpellPoison;
    public static bool isSpellFire;
    public static bool isSpellLast;

    /// <summary>
    /// ゲームプレイ中の確認フラグ
    /// </summary>
    public static bool isStartGame;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
