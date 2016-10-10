using UnityEngine;
using System.Collections;
using BehaviorDesigner.Runtime;

public class cube : MonoBehaviour {

	// Use this for initialization
	void Start () {
        BehaviorTree beha = GetComponent<BehaviorTree>();
        //beha.SendEvent<int>("MyEvent", 123);

        Animator ator = GetComponent<Animator>();
        //ator.GetCurrentAnimatorClipInfo.

    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
