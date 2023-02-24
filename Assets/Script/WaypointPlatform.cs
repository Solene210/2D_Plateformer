using System.Collections;
using System.Collections.Generic;
using UnityEngine;


enum WaypointMode
{
    LOOP,
    PINGPONG
}
public class WaypointPlatform : MonoBehaviour
{
    #region Expose

    [SerializeField] 
    private WaypointMode _mode = WaypointMode.LOOP;

    [SerializeField]
    private Transform[] _waypoint;

    [SerializeField]
    private float _speed;

    [SerializeField]
    private float _reachTolerance = 0.1f;

    #endregion

    #region Unity Lyfecycle
    void Start()
    {
        transform.position = _waypoint[0].position;
        _targetWaypointIndex = 1;
    }

    void Update()
    {
        Vector3 currentWaypointPosition = _waypoint[_targetWaypointIndex].position;
        Vector3 position = Vector3.MoveTowards(transform.position, currentWaypointPosition, _speed * Time.deltaTime);
        transform.position = position;

        if (Vector3.Distance(transform.position, currentWaypointPosition) <= _reachTolerance)
        {
           switch(_mode)
            {
                case WaypointMode.LOOP:
                    Loop();
                break;

                case WaypointMode.PINGPONG:
                    PingPong();
                break;
            }
        }
    }
    #endregion

    #region Methods

    private void Loop()
    {
        if (_targetWaypointIndex >= _waypoint.Length)
        {
            _targetWaypointIndex++;
            _targetWaypointIndex = 0;
        }
    }

    private void PingPong()
    {
        if (_isForward)
        {
            _targetWaypointIndex++;
            if (_targetWaypointIndex >= _waypoint.Length - 1)
            {
                _isForward = false;
            }
        }
        else
        {
            _targetWaypointIndex--;
            if (_targetWaypointIndex <= 0)
            {
                _isForward = true;
            }
        }
    }
    #endregion

    #region Private & Protected

    private int _targetWaypointIndex;
    private bool _isForward = true;

    #endregion
}
