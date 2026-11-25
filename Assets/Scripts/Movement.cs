using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    
    [SerializeField] private float _speedGain = 5; 
    [SerializeField] private float _speedMax = 100f;
    // [SerializeField] private float _speedMin = -20f;
    
    [SerializeField] private float _rotationSpeed = 5;
    [SerializeField] private Key _forwardKey = Key.Space;
    [SerializeField] private Key _turnKeyLeft = Key.LeftArrow;
    [SerializeField] private Key _turnKeyRight = Key.RightArrow;
     
    public float _speed = 0f;
    public float _turnDirection = 0f;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        bool forwardKey = Keyboard.current[_forwardKey].isPressed;
        
        // La voiture avance
        if(forwardKey)
            _speed += _speedGain;
        else
            _speed -= _speedGain;
        _speed = Mathf.Clamp(_speed, 0, _speedMax);
        
        // La voiture tourne ?
        bool turnKeyLeft = Keyboard.current[_turnKeyLeft].isPressed;
        bool turnKeyRight = Keyboard.current[_turnKeyRight].isPressed;
        if (turnKeyLeft)
            _turnDirection = -1f;
        else if (turnKeyRight)
            _turnDirection = 1f;
        else
            _turnDirection = 0f;
        
        transform.Translate(Vector3.forward * (_speed * Time.deltaTime));
        if(_speed > 0)
        {
            transform.Rotate(Vector3.up * (_turnDirection * _rotationSpeed * Time.deltaTime));
        }
        
        // transform.Rotate(Vector3.up * _speed * Time.deltaTime); 
        
        
    }
}
