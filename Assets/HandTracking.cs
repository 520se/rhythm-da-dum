//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//using Microsoft;
//using MixedReality.Toolkit.Input;
//using MixedReality.Toolkit;
//using MixedReality.Toolkit.Subsystems;
//using UnityEngine.XR;

//public class HandTracking : MonoBehaviour
//{

//    public GameObject sphereMarker;

//    GameObject thumbObject;
//    GameObject indexObject;
//    GameObject middleObject;
//    GameObject ringObject;
//    GameObject littleObject;

//    MixedRealityTransform pose;

//    void Start()
//    {
//        thumbObject = Instantiate(sphereMarker, this.transform);
//        indexObject = Instantiate(sphereMarker, this.transform);
//        middleObject = Instantiate(sphereMarker, this.transform);
//        ringObject = Instantiate(sphereMarker, this.transform);
//        littleObject = Instantiate(sphereMarker, this.transform);
//    }

//    void Update()
//    {

//        thumbObject.GetComponent<Renderer>().enabled = false;
//        indexObject.GetComponent<Renderer>().enabled = false;
//        middleObject.GetComponent<Renderer>().enabled = false;
//        ringObject.GetComponent<Renderer>().enabled = false;
//        littleObject.GetComponent<Renderer>().enabled = false;

//        if (HandDataContainer.TryGetJoint(TrackedHandJoint.ThumbTip, Handedness.Right, out pose))
//        {
//            thumbObject.GetComponent<Renderer>().enabled = true;
//            thumbObject.transform.position = pose.Position;
//        }

//        if (HandDataContainer.TryGetJoint(TrackedHandJoint.IndexTip, Handedness.Right, out pose))
//        {
//            indexObject.GetComponent<Renderer>().enabled = true;
//            indexObject.transform.position = pose.Position;
//        }

//        if (HandDataContainer.TryGetJoint(TrackedHandJoint.MiddleTip, Handedness.Right, out pose))
//        {
//            middleObject.GetComponent<Renderer>().enabled = true;
//            middleObject.transform.position = pose.Position;
//        }

//        if (HandDataContainer.TryGetJoint(TrackedHandJoint.IndexTip, hand, out var palmJointPose))
//        {
//            ringObject.GetComponent<Renderer>().enabled = true;
//            ringObject.transform.position = pose.Position;
//        }

//        if (XRSubsystemHelpers.HandsAggregator.TryGetJoint(TrackedHandJoint.LittleTip, ArticulatedHandController.HandNode, out pose))
//        {
//            littleObject.GetComponent<Renderer>().enabled = true;
//            littleObject.transform.position = pose.Position;
//        }
//    }
//}


