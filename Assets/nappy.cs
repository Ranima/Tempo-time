using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class nappy : MonoBehaviour {
    [SerializeField]
    Transform Target;

    NavMeshAgent nav;

    
	// Use this for initialization
	void Start () {
        nav = this.GetComponent<NavMeshAgent>();

        if (nav == null)
        {
            Debug.LogError("you forgot some thing" + gameObject.name);
        }

        else { setTarget(); }
	}
	

	// Update is called once per frame
	void Update () {
		
	}

    void setTarget()
    {

        if(Target != null)
        {
            Vector3 target = Target.transform.position;
            nav.SetDestination(target);
        }
 
    }
}
