using System.Collections;
using UnityEngine;


namespace BehaviorDesigner.Runtime.Tasks.Basic.UnityTransform
{
    [TaskCategory("My")]
    public class SearchTarget : Conditional
    {
        public Transform mTarget = null;
        public float mRadius = 2f;

        public override void OnStart()
        {
            Collider[] hits = Physics.OverlapSphere(transform.position, mRadius);
            for(int i = 0; i < hits.Length; ++i)
            {
                if (hits[0].transform.CompareTag("Player"))
                {
                    mTarget = hits[0].transform;
                    Owner.SetVariableValue("target", mTarget);
                    break;
                }
            }
        }

        public override TaskStatus OnUpdate()
        {
            return mTarget ? TaskStatus.Success : TaskStatus.Failure;
        }
    }
}