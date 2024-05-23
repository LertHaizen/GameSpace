using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation_Controller : MonoBehaviour
{
    // Поле для хранения аниматора
    [SerializeField]
    private Animator _animator;

    private void Update()
    {
        // Получение вертикальной оси

        float _axis = Input.GetAxis("Vertical");
        if (_axis != 0)
        {
            if (_axis > 0)
            {
                // Запуск анимации движения
                _animator.SetInteger("Speed", 1);
                if (Input.GetKey(KeyCode.LeftShift))                {
                    // Запуск анимации бега
                    _animator.SetInteger("Speed", 2);
                }
            }
            else
            {
                // Запуск анимации движения назад
                _animator.SetInteger("Speed", -1);
            }
        }
        else
        {
            // Запуск анимации ожидания
            _animator.SetInteger("Speed", 0);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Запуск анимации прыжка
            _animator.SetTrigger("Is_Jump");
        }
    }
}
