using System;
using UnityEngine;
using UnityEngine.UI;

public class ManipuatorStone : MonoBehaviour
{
    [SerializeField] private InputField _inputFiel1d;
    [SerializeField] private Button _button1;
    [SerializeField] private Text _resultTex1t;
    private void Awake()
    {
        Debug.Assert(_inputFiel1d != null, $"Assign {nameof(_inputFiel1d)} field in the inspector");
        Debug.Assert(_button1 != null, $"Assign {nameof(_button1)} field in the inspector");
        Debug.Assert(_resultTex1t != null, $"Assign {nameof(_resultTex1t)} field in the inspector");
        Debug.Assert(_inputFiel1d.contentType == InputField.ContentType.IntegerNumber, "InputType should be IntegerNumber");
        _button1.onClick.AddListener(OnClick);
    }

    public void OnClick()
    {
        int result = Resurs.material;
        _resultTex1t.text = result.ToString();
     //   Resurs.man_stone = ActionWithNumber(Convert.ToInt32(_inputFiel1d.text));
    }

    private int ActionWithNumber(int input)
    {
        //Здесь ваши действия с числом

        return input;
    }

    private void OnDestroy()
    {
        _button1.onClick.RemoveAllListeners();
    }
    void Update()
    {
     //   Resurs.man_stone = ActionWithNumber(Convert.ToInt32(_inputFiel1d.text));
    }
}
