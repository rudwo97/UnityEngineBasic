using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ���� ���󰡰� �� ī�޶�
/// </summary>
public class TargetFollowCamera : MonoBehaviour
{
    /// <summary>
    /// target �� �������� gameobject Ȱ��ȭ
    /// </summary>
    public Transform target
    {
        get
        {
            return _target;
        }
        set
        {
            _target = value;
            gameObject.SetActive(value != null);
        }
    }
    private Transform _target;
    [SerializeField] private Vector3 _offset;
    [SerializeField] private Vector3 _angle;


    //============================================================
    //                      Private Methods
    //============================================================

    private void OnEnable()
    {
        transform.rotation = Quaternion.Euler(_angle);
    }

    private void LateUpdate()
    {
        if (_target == null)
            return;

        transform.position = _target.position + _offset;
    }
}
