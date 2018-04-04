using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newDanceFLoor : MonoBehaviour {
    public float Speed;
   
     
    Transform curentPath;
    int index;
    public float reachPoint = 1f;

    Collider coll;
    Mesh meh;
    Renderer ren;

    public float timer;
    public float setTime;

	// Use this for initialization
	void Start () {
        //curentPath = holder.points[0];
        coll = GetComponent<Collider>();
        index = Random.Range(0, holder.points.Length);
        meh = GetComponent<Mesh>();
        ren = GetComponent<Renderer>();

        coll.enabled = !coll.enabled;
	}
	
	// Update is called once per frame
	void Update ()
    {
        
        
        Vector3 dir = holder.points[index].position - transform.position;
        Vector3 dirnor = dir.normalized;
        transform.Translate(dirnor * (Speed * Time.fixedDeltaTime));
       

        
        timer += Time.deltaTime;

       

        if(dir.magnitude <= reachPoint)
        {
            coll.enabled = true;
            ren.enabled = true;

        }
        
        if(dir.magnitude > reachPoint && coll.enabled && ren.enabled)
        {
            coll.enabled = false;
            ren.enabled = false;
        }

        if (dir.magnitude <= reachPoint && timer >= setTime)
            {
                timer = 0;
                index = Random.Range(0,holder.points.Length);

            

            if (index >= holder.points.Length && coll.enabled)
               {
                
                index = Random.Range(0, holder.points.Length);
              }

            }

       
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        if (holder.points == null)
        {
            return;
        }

        foreach (Transform pathpoint in holder.points)
        {
            if (pathpoint) { Gizmos.DrawWireSphere(pathpoint.position, reachPoint); }
        }
    }
}
