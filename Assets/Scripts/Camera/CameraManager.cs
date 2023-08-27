using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
  [SerializeField] private Transform _target;
  [SerializeField] private float _lerpValue;

  private Vector3 _targetOffset;

  private void Start()
  {
    _targetOffset = transform.position - _target.position;
  }

  private void LateUpdate()
  {
    transform.position = Vector3.Lerp(transform.position, _target.position + _targetOffset, _lerpValue * Time.deltaTime);
  }
}
