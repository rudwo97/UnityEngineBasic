using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �������� ���� �ӵ��� �����ϴ� ��
/// </summary>
public class Horse : MonoBehaviour
{
    public bool doMove;
    [SerializeField] private float _speed = 2.0f;
    [Range(0.0f, 1.0f)]
    [SerializeField] private float _stability = 0.7f;


    //============================================================
    //                      Private Methods
    //============================================================

    private void FixedUpdate()
    {
        if (doMove)
            Move();
    }

    /// <summary>
    /// ���� �����Ӵ� �ѹ� ȣ��
    /// �Ÿ���ȭ�� = �ӵ� * �ð���ȭ�� = (Vector3.forward * randomSpeed) * Time.fixedDeltaTime
    /// </summary>
    private void Move()
    {
        float randomSpeed = _speed * Random.Range(_stability, 1.0f);
        transform.Translate(Vector3.forward * randomSpeed * Time.fixedDeltaTime);
    }
}
