using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SimplePatrol : MonoBehaviour {

    [SerializeField]
    bool _patrolWaiting;

    [SerializeField]
    float _totalWaitTime = 3f;

    [SerializeField]
    float _switchProbability = 0.2f;

    [SerializeField]
    List<Waypoint> _patrolPoints;

    NavMeshAgent _navMeshAgent;
    int _currentPatrolindex;
    bool _traveling;
    bool _waiting;
    bool _patrolForward;
    float _waitTimer;

	void Start ()
    {
        _navMeshAgent = this.GetComponent<NavMeshAgent>();

        if(_navMeshAgent == null)
        {
            Debug.LogError("The nav mesh agent component is not attached to " + gameObject.name);
        }
        else
        {
            if(_patrolPoints != null && _patrolPoints.Count >= 2)
            {
                _currentPatrolindex = 0;
                SetDestination();
            }
            else
            {
                Debug.Log("Insufficient patrol points for basic patroling behavior.");
            }
        }
	}
	
	void Update ()
    {
        if (_traveling && _navMeshAgent.remainingDistance <= 1.0f)
        {
            _traveling = false;

            if (_patrolWaiting)
            {
                _waiting = true;
                _waitTimer = 0f;
            }
            else
            {
                ChangePatrolPoint();
                SetDestination();
            }
        }

        if (_waiting)
        {
            _waitTimer += Time.deltaTime;
            if (_waitTimer >= _totalWaitTime)
            {
                _waiting = false;
            }
        }
	}

    private void SetDestination()
    {
        if(_patrolPoints != null)
        {
            Vector3 targetVector = _patrolPoints[_currentPatrolindex].transform.position;
            _navMeshAgent.SetDestination(targetVector);
            _traveling = true;
        }
    }

    private void ChangePatrolPoint()
    {
        if(UnityEngine.Random.Range(0f,1f) < _switchProbability)
        {
            _patrolForward = !_patrolForward;
        }

        if(_patrolForward)
        {
            _currentPatrolindex = (_currentPatrolindex + 1) % _patrolPoints.Count;
        }
        else
        {
            if(--_currentPatrolindex < 0)
            {
                _currentPatrolindex = _patrolPoints.Count - 1;
            }
        }
    }
}
