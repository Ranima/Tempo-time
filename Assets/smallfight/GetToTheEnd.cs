using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetToTheEnd : MonoBehaviour {
    public float Speed = 10;

    private Transform target;
    private int wavepointIndex = 0;
    public Transform[] pathpoints;
    public int curentPath = 0;
    public float reachPoint = 5f;

    // Use this for initialization
    void Start () {
      
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 dir = pathpoints[curentPath].position - transform.position;
        Vector3 dirnor = dir.normalized;

        transform.Translate(dirnor * (Speed * Time.fixedDeltaTime));

        if (dir.magnitude <= reachPoint)
        {
            curentPath++;

            if (curentPath >= pathpoints.Length) { curentPath = 0; }

        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        if (pathpoints == null)
        {
            return;
        }

        foreach (Transform pathpoint in pathpoints)
        {
            if (pathpoint) { Gizmos.DrawWireSphere(pathpoint.position, reachPoint); }
        }
    }
}
