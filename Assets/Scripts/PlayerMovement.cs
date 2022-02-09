using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour{

    private Rigidbody _rigidbody;
    [SerializeField] private float velocityMultiplier;
    [SerializeField] private float sideLimit;
    
    void Awake(){
        _rigidbody = GetComponent<Rigidbody>();
        if (_rigidbody == null) {
            Debug.Log("ERROR: no rigidbody found");
        }
    }
    void Start(){
    }

   

    // Update is called once per frame
    void Update(){
        if (Input.touchCount > 0) {
            Touch touch = Input.GetTouch(0);

            // Move the player if the finger is moving
            if (touch.phase == TouchPhase.Moved) {
                Vector2 fingerMovementDirection = touch.deltaPosition;
    
                // fingerMovementDirection.y = 0.0f;
                // Vector2 pos = touch.position;
                // touch.
                // pos.x = (pos.x - width) / width;
                // pos.y = (pos.y - height) / height;
                // position = new Vector3(-pos.x, pos.y, 0.0f);
                //
                // // Position the cube.
                // transform.position = position;
                // Vector3 direction = ; 
                // _rigidbody.velocity = velocityDirection.normalized * velocityMultiplier;

                // transform.position += transform.right * (fingerMovementDirection.x * Time.deltaTime);
                
                transform.Translate(fingerMovementDirection.x * Time.deltaTime * velocityMultiplier, 0.0f, 0.0f);

                Vector3 position = transform.position;
                float limitedX = Mathf.Clamp(position.x, -sideLimit, sideLimit);
                transform.position = new Vector3(limitedX, position.y, position.z);
            }
        }
    }
}