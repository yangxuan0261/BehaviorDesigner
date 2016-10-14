using UnityEngine;
namespace BehaviorDesigner.Runtime.Tasks
{
    [TaskDescription("Returns success as soon as the event specified by eventName has been received.")]
    [HelpURL("http://www.opsive.com/assets/BehaviorDesigner/documentation.php?id=123")]
    [TaskIcon("{SkinColor}HasReceivedEventIcon.png")]
    [TaskCategory("My")]
    public class HasTarget : Conditional
    {
        public override void OnStart()
        {

        }

        public override TaskStatus OnUpdate()
        {
            SharedTransform target = (SharedTransform)Owner.GetVariable("target");
            if (target.Value == null)
            {
                Debug.Log("--- HasTarget, false");
                return TaskStatus.Failure;
            }
            else{
                Debug.Log("--- HasTarget, true");
                return TaskStatus.Success;
            }
        }

        public void MyEvent(int num)
        {
            Debug.LogFormat("--- MyCondition MyEvent, num:{0}", num);
        }

        public override void OnReset()
        {
        }

        public override void OnBehaviorComplete()
        {
            Debug.LogFormat("--- MyCondition OnBehaviorComplete");
            base.OnBehaviorComplete();
        }
    }
}