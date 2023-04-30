using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChaseState<T> : EnemeyStateBase<T>
{
    ObstacleAvoidance _obstacleAvoidance;
    Seek seek;
    public override void Awake()
    {
        base.Awake();
        _obstacleAvoidance = new ObstacleAvoidance(_controller.target, _controller.layerObstacle, 20, _controller.obstacleDetectionRadius, _controller.obstacleDetectionAngle);
        seek = new Seek(_model.transform, _controller.target);
    }
    public override void Execute()
    {
        base.Execute();
        Debug.Log(_obstacleAvoidance);
        if (!seeObstacle())
        {
           
              Vector3 pepe = (_obstacleAvoidance.GetDir() + _model.transform.position * 1f).normalized;
            
            _model.Move(pepe);
            _model.LookRotate(pepe);
            Debug.Log(_obstacleAvoidance.GetDir());

        }
        else
        {
            _model.Move(seek.GetDir());
            _model.LookRotate(seek.GetDir());

        }
        

        Debug.Log("Chase");

    }
    bool seeObstacle()
    {
        bool isSeePlayer = false;

        Vector3 diffPoint = _controller.target.transform.position - _model.transform.position;

        float angleToPoint = Vector3.Angle(_model.transform.forward, diffPoint);
        if (angleToPoint < _controller.obstacleDetectionAngle / 2)
        {
            Vector3 diff = (_controller.target.position - _model.transform.position);
            Vector3 dirToTarget = diff.normalized;
            float distTarget = diff.magnitude;

            RaycastHit hit;

            isSeePlayer = !Physics.Raycast(_model.transform.position, dirToTarget, out hit, distTarget, _controller.layerObstacle);
        }


        return isSeePlayer;
    }
}