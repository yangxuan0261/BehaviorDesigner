using UnityEngine;

namespace BehaviorDesigner.Runtime.Tasks
{
    [TaskDescription("Returns success as soon as the event specified by eventName has been received.")]
    [HelpURL("http://www.opsive.com/assets/BehaviorDesigner/documentation.php?id=123")]
    [TaskIcon("{SkinColor}HasReceivedEventIcon.png")]
    public class MyCondition : Conditional
    {
        [Tooltip("The name of the event to receive")]
        public SharedString eventName = "";

        public override void OnStart()
        {

        }

        public override TaskStatus OnUpdate()
        {
            
            //Owner.transform;
            Debug.Log("--- MyCondition OnUpdate");
            return TaskStatus.Success;
        }

        public void MyEvent(int num)
        {
            Debug.LogFormat("--- MyCondition MyEvent, num:{0}", num);
        }

        public override void OnReset()
        {
            eventName = "";
        }

        public override void OnBehaviorComplete()
        {
            Debug.LogFormat("--- MyCondition OnBehaviorComplete");
            base.OnBehaviorComplete();
        }
    }
}