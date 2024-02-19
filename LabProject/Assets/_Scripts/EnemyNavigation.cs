using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyNavigation : MonoBehaviour
{
    [InspectorName ("_destination")]


    [SerializeField] private List<Transform> _points;

    [SerializeField] private Transform _player;

    [SerializeField] private int _index = 0;


    [SerializeField] private LayerMask _mask;

    [SerializeField] private int _viewDistance = 10;

    [SerializeField] Vector3 _destination;
    NavMeshAgent _agent;

    EnemyEnums _enemyState;
    // Start is called before the first frame update
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _player = GameObject.FindGameObjectWithTag("Player").transform;
        _enemyState = EnemyEnums.Patrolling;
        _destination = _points[0].position;
        _agent.destination = _destination;
    }

    // Update is called once per frame
    void Update()
    {

        if(_enemyState == EnemyEnums.Chasing)
        {
            _destination = _player.position;
            _agent.destination = _destination;
        }
        else
        {
            if (Vector3.Distance(_destination, _agent.transform.position) < 1.0f)
            {
                if (++_index == _points.Count - 1)
                {
                    _index = 0;
                }
                _destination = _points[_index].position;
                _agent.destination = _destination;
            }
        }
      
    }

    private void FixedUpdate()
    {
        RaycastHit hit;
        if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, _viewDistance, _mask))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.green);
            Debug.Log($"I hit = {hit.transform.gameObject.name}");
            if(hit.transform.gameObject.name.Equals("Player"))
            {
                _destination = hit.transform.position;
                _enemyState = EnemyEnums.Chasing;
            }
            
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * _viewDistance, Color.yellow);
            Debug.Log($"I hit NOTHING");
        }
    }
}
