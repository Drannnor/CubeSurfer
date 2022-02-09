using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour{

    private Rigidbody _rigidbody;
    [SerializeField] private float velocityMultiplier;
    [SerializeField] private float sideLimit;

    private int _screenWidth;
    
    void Awake(){
        _rigidbody = GetComponent<Rigidbody>();
        if (_rigidbody == null) {
            Debug.Log("ERROR: no rigidbody found");
        }

        _screenWidth = Screen.width;
    }
    void Start(){
    }
    
    // Update is called once per frame
    void Update(){
        if (Input.touchCount > 0) {
            Touch touch = Input.GetTouch(0);

            // Move the player if the finger is moving
            if (touch.phase == TouchPhase.Moved) {
                Vector2 fingerMovement = touch.deltaPosition;
                float movement = touch.deltaPosition.x / _screenWidth;
                
                transform.Translate(movement * velocityMultiplier, 0.0f, 0.0f);
                
                Debug.Log($"screen: {_screenWidth}, deltaX:{touch.deltaPosition.x}  movement: {movement}");
                Vector3 position = transform.position;
                float limitedX = Mathf.Clamp(position.x, -sideLimit, sideLimit);
                transform.position = new Vector3(limitedX, position.y, position.z);
            }
        }
    }
}