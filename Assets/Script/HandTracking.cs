using Microsoft.MixedReality.Toolkit.Diagnostics;
using Microsoft.MixedReality.Toolkit.Input;
using Microsoft.MixedReality.Toolkit.Utilities;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class HandTracking : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // 右手の人差し指先端
        CommonArea.isHandDisplayRightIndexTip = HandJointUtils.TryGetJointPose(TrackedHandJoint.IndexTip, Handedness.Right, out MixedRealityPose poseRightIndexTip);
        if (CommonArea.isHandDisplayRightIndexTip)
        {
            CommonArea.poseRightIndexTip = poseRightIndexTip;
        }

        // 左手の人差し指先端
        CommonArea.isHandDisplayLeftIndexTip = HandJointUtils.TryGetJointPose(TrackedHandJoint.IndexTip, Handedness.Left, out MixedRealityPose poseLeftIndexTip);
        if (CommonArea.isHandDisplayLeftIndexTip)
        {
            CommonArea.poseLeftIndexTip = poseLeftIndexTip;
        }

        // 右手の親指第三関節
        CommonArea.isHandDisplayRightThumbProximal = HandJointUtils.TryGetJointPose(TrackedHandJoint.ThumbProximalJoint, Handedness.Right, out MixedRealityPose poseRightThumbProximal);
        if (CommonArea.isHandDisplayRightThumbProximal)
        {
            CommonArea.poseRightThumbProximal = poseRightThumbProximal;
        }

        // 左手の親指第三関節
        CommonArea.isHandDisplayLeftThumbProximal = HandJointUtils.TryGetJointPose(TrackedHandJoint.ThumbProximalJoint, Handedness.Left, out MixedRealityPose poseLeftThumbProximal);
        if (CommonArea.isHandDisplayLeftThumbProximal)
        {
            CommonArea.poseLeftThumbProximal = poseLeftThumbProximal;
        }

        // 右手首
        CommonArea.isHandDisplayRightWrist = HandJointUtils.TryGetJointPose(TrackedHandJoint.Wrist, Handedness.Right, out MixedRealityPose poseRightWrist);
        if (CommonArea.isHandDisplayRightWrist)
        {
            CommonArea.poseRightWrist = poseRightWrist;
        }

        // 左手首
        CommonArea.isHandDisplayLeftWrist = HandJointUtils.TryGetJointPose(TrackedHandJoint.Wrist, Handedness.Left, out MixedRealityPose poseLeftWrist);
        if (CommonArea.isHandDisplayLeftWrist)
        {
            CommonArea.poseLeftWrist = poseLeftWrist;
        }
    }
}
