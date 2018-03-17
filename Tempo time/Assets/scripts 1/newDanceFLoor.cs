using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newDanceFLoor : MonoBehaviour {
    public float Speed;
    public Transform[] PathPoints;
     
    Transform curentPath;
    int index;
    public float reachPoint = 1f;

    Collider coll;

    public float timer;
    public float setTime;

	// Use this for initialization
	void Start () {
        coll = GetComponent<Collider>();
        index = Random.Range(0, PathPoints.Length-1);
        curentPath = PathPoints[index];
        coll.enabled = !coll.enabled;
	}
	
	// Update is called once per frame
	void Update ()
    {
        
        
        Vector3 dir = PathPoints[index].position - transform.position;
        Vector3 dirnor = dir.normalized;

       

        transform.Translate(dirnor * (Speed * Time.fixedDeltaTime));
        timer += Time.deltaTime;

       

        if(dir.magnitude <= reachPoint)
        {
            coll.enabled = true;
        }
        
        if(dir.magnitude > reachPoint && coll.enabled)
        {
            coll.enabled = false;
        }

        if (dir.magnitude <= reachPoint && timer >= setTime)
            {
                timer = 0;
                index++;

            

            if (index >= PathPoints.Length && coll.enabled)
               {
                
                index = 0;
              }

            }

       
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        if (PathPoints == null)
        {
            return;
        }

        foreach (Transform pathpoint in PathPoints)
        {
            if (pathpoint) { Gizmos.DrawWireSphere(pathpoint.position, reachPoint); }
        }
    }
}
