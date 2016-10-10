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
            return TaskStatus.Failure;
        }

        public override void OnReset()
        {
            eventName = "";
        }
    }
}