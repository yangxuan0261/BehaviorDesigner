using System.Collections;
using UnityEngine;


namespace BehaviorDesigner.Runtime.Tasks.Basic.UnityTransform
{
    [TaskCategory("Basic/Transform")]
    [TaskDescription("Moves the transform in the direction and distance of translation. Returns Success.")]
    public class MyTranslate : Action
    {
        [Tooltip("The GameObject that the task operates on. If null the task GameObject is used.")]
        public SharedGameObject targetGameObject;
        [Tooltip("Move direction and distance")]
        public SharedVector3 translation;
        [Tooltip("Specifies which axis the rotation is relative to")]
        public Space relativeTo = Space.World;

        private Transform targetTransform;
        private GameObject prevGameObject;
        public bool isOver = false;

        public override void OnStart()
        {
            var currentGameObject = GetDefaultGameObject(targetGameObject.Value);
            if (currentGameObject != prevGameObject) {
                targetTransform = currentGameObject.GetComponent<Transform>();
                prevGameObject = currentGameObject;
            }

            StartCoroutine(Rot(2.0f));
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

            if (isOver)
            {

                Debug.Log("--- Translate ing");
                targetTransform.Translate(translation.Value, relativeTo);
               return TaskStatus.Success;
            }
            else
            {
                return TaskStatus.Running;
            }
        }

        public override void OnReset()
        {
            Debug.LogFormat("--- translate OnReset");
            targetGameObject = null;
            translation = Vector3.zero;
            relativeTo = Space.Self;
            isOver = false;
        }

        public override void OnEnd()
        {
            Debug.LogFormat("--- translate OnEnd");
        }

        public override void OnBehaviorComplete()
        {
            Debug.LogFormat("--- translate OnBehaviorComplete");
            base.OnBehaviorComplete();
        }

        public override void OnBehaviorRestart()
        {
            base.OnBehaviorRestart();
            Debug.LogFormat("--- translate OnBehaviorRestart");
        }
    }
}