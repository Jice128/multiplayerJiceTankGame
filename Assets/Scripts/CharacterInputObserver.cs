using UnityEngine;

public class CharacterInputObserver : MonoBehaviour    //this is "local" class that will  receive controll directrly from input 
{
    private Vector2 _moveInputVector = Vector2.zero;

    [SerializeField] private Joystick _joystick;
    public float x, y;

    private void Awake()
    {
        _joystick = GameObject.FindGameObjectWithTag("GameController").GetComponent<Joystick>();
        _moveInputVector.x = 0;
    }

    private void Update()
    {   //we will make input all frames but as soon as network will be ready to receive it we go to  GetNetworkInput()
        //   _moveInputVector.x = Input.GetAxis("Horizontal");
        //_moveInputVector.y = Input.GetAxis("Vertical");

        _moveInputVector.x = _joystick.Horizontal;
        _moveInputVector.y = _joystick.Vertical;
      //  Debug.Log(_joystick.Vertical);
    }


   
    public NetworkInputData GetNetworkInput()
    {
 
        NetworkInputData _networkInputData = new NetworkInputData();
        
     
        //rotate
        if (_joystick.Vertical > 0) 
           _networkInputData.RotationInput = _moveInputVector.x; 
        else
           _networkInputData.RotationInput -= _moveInputVector.x;
        //to out "network" variables  in struct NetworkInputData.cs 
        //move
        _networkInputData.MovementInput = _moveInputVector;  //to out "network" variables  in struct NetworkInputData.cs 
        return _networkInputData;
    }
}
