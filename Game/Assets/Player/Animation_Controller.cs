using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation_Controller : MonoBehaviour
{
    // ���� ��� �������� ���������
    [SerializeField]
    private Animator _animator;

    private void Update()
    {
        // ��������� ������������ ���

        float _axis = Input.GetAxis("Vertical");
        if (_axis != 0)
        {
            if (_axis > 0)
            {
                // ������ �������� ��������
                _animator.SetInteger("Speed", 1);
                if (Input.GetKey(KeyCode.LeftShift))                {
                    // ������ �������� ����
                    _animator.SetInteger("Speed", 2);
                }
            }
            else
            {
                // ������ �������� �������� �����
                _animator.SetInteger("Speed", -1);
            }
        }
        else
        {
            // ������ �������� ��������
            _animator.SetInteger("Speed", 0);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // ������ �������� ������
            _animator.SetTrigger("Is_Jump");
        }
    }
}
