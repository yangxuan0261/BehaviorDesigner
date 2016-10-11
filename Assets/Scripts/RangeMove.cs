using UnityEngine;
using System.Collections;
using DG.Tweening;

namespace BehaviorDesigner.Runtime.Tasks
{
    [TaskDescription("Returns success as soon as the event specified by eventName has been received.")]

    [TaskCategory("My")]
    public class RangeMove : Action
    {
        public bool mIsOver = false;
        public float mRange = 2f;
        public float mTotalTime = 2f;

        public override void OnStart()
        {
            float x = Random.Range(-mRange, mRange);
            float z = Random.Range(-mRange, mRange);
            Vector3 dir = transform.position + new Vector3(x, 0, z); //dest world position
            transform.LookAt(dir);
            transform.DOLocalMoveX(x, mTotalTime).OnComplete(()=> { mIsOver = true; });
            transform.DOLocalMoveZ(z, mTotalTime);
        }

        public override TaskStatus OnUpdate()
        {
            return mIsOver ? TaskStatus.Success : TaskStatus.Running;
        }
    }
}