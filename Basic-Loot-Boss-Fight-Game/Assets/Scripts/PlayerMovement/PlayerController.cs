using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour {

    [SerializeField]
    Camera _cam;

    [SerializeField]
    NavMeshAgent _navMeshAgent;

    [SerializeField]
    float _extraRotationSpeed;

    void Start ()
    {
        _navMeshAgent = this.GetComponent<NavMeshAgent>();
	}
	
	void Update ()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Ray ray =_cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit))
            {
                _navMeshAgent.SetDestination(hit.point);
            }
        }
        if (_navMeshAgent.remainingDistance >= 0.1f)
            ExtraRotation();

    }

    void ExtraRotation()
    {
        Vector3 lookrotation = _navMeshAgent.steeringTarget - transform.position;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(lookrotation), _extraRotationSpeed * Time.deltaTime);

    }
}
