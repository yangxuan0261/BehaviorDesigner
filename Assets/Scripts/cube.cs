using UnityEngine;
using System.Collections;
using BehaviorDesigner.Runtime;

public class cube : MonoBehaviour {

    private BehaviorTree bt;
	// Use this for initialization
	void Start () {
        bt = GetComponent<BehaviorTree>();
        //StartCoroutine(Interrupt());
    }

    IEnumerator Interrupt()
    {
        yield return new WaitForSeconds(4f);
    }
	

}
