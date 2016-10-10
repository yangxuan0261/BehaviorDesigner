using System.Collections;
using UnityEngine;

namespace BehaviorDesigner.Runtime.Tasks.Basic.UnityTransform
{
    [TaskCategory("Basic/Transform")]
    [TaskDescription("Applies a rotation. Returns Success.")]
    public class MyRotate : Action
    {
        [Tooltip("The GameObject that the task operates on. If null the task GameObject is used.")]
        public SharedGameObject targetGameObject;
        [Tooltip("Amount to rotate")]
        public SharedVector3 eulerAngles;
        [Tooltip("Specifies which axis the rotation is relative to")]
        public Space relativeTo = Space.Self;
        [Tooltip("rotate curve")]
        public AnimationCurve curve;

        private Transform targetTransform;
        private GameObject prevGameObject;

        private bool isOver = false;

        public override void OnStart()
        {
            var currentGameObject = GetDefaultGameObject(targetGameObject.Value);
            if (currentGameObject != prevGameObject) {
                targetTransform = currentGameObject.GetComponent<Transform>();
                prevGameObject = currentGameObject;
            }

            //--------------- test£¬like blackboard in ue4
            //get GlobalVariables, use in different bt
            SharedFloat sv = (SharedFloat)BehaviorDesigner.Runtime.GlobalVariables.Instance.GetVariable("waitTime");
            float wt = sv.Value;

            //get Variables, use in same bt
            SharedFloat sv2 = (SharedFloat)Owner.GetVariable("scaleTime");
            float wt2 = sv2.Value;
            Debug.LogFormat("--- wt:{0}, wt2:{1}", wt, wt2);

            //modify shared value
            sv.Value = 44.44f;
            sv2.Value = 55.55f;

            float dstTime = curve.keys[curve.keys.Length - 1].time;
            StartCoroutine(Rot(dstTime));
        }

        IEnumerator Rot(float time)
        {
            yield return new WaitForSeconds(time);
            isOver = true;
        }

        public override TaskStatus OnUpdate()
        {
            if (targetTransform == null) {
                Debug.LogWarning("Transform is null");
                return TaskStatus.Failure;
            }

            float currAn = curve.Evaluate(Time.time);
            targetTransform.localRotation = Quaternion.Euler(new Vector3(0, currAn, 0));

            //if (dstTime >= 1.0f)
            if (isOver)
            {
                Debug.LogFormat("--- rot success");
                return TaskStatus.Success;
            }
            else
            {
                //targetTransform.Rotate(eulerAngles.Value, relativeTo);
                return TaskStatus.Running;
            }

        }

        public override void OnReset()
        {
            targetGameObject = null;
            eulerAngles = Vector3.zero;
            relativeTo = Space.Self;
        }
    }
}