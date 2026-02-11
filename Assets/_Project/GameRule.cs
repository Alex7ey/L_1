using UnityEngine;
using UnityEngine.InputSystem;

public class GameRule : MonoBehaviour
{
    private string _combination = "qwerty";
    private int _currentChar;

    private void Awake()
    {
        Keyboard.current.onTextInput += Check;
    }

    public void Check(char ch)
    {
        if (ch == _combination[_currentChar])
        {
            _currentChar++;

            if (_currentChar >= _combination.Length)
            {
                Debug.Log("Ты победил");
                _currentChar = 0;
                return;
            }
        }

        else
        {
            Debug.Log("GameOver");
            _currentChar = 0;
        }
    }
}
