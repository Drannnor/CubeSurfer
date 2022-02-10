using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour{
    private Rigidbody _rigidbody;
    private Camera _camera;
    [SerializeField] private float velocityMultiplier;
    [SerializeField] private float sideLimit;

    private int _screenWidth;

    void Awake(){
        _rigidbody = GetComponent<Rigidbody>();
        if (_rigidbody == null) {
            Debug.Log("ERROR: no rigidbody found");
        }

        _screenWidth = Screen.width;

        _camera = Camera.main;
        if (_camera == null) {
            Debug.Log("ERROR: main camera not found");
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
                Vector2 fingerMovement = touch.deltaPosition;
                float distanceToCharacter = Vector3.Distance(_camera.transform.position, Vector3.zero);
                // var point = _camera.View(new Vector3(touch.position.x, touch.position.y, _camera.nearClipPlane));
                // Debug.DrawLine(Vector3.zero, point, Color.red);
                
                
                
                // float movement = touch.deltaPosition.x / _camera.nearClipPlane * distanceToCharacter;
                float movement = touch.deltaPosition.x;
                // Debug.Log($"deltaX:{touch.deltaPosition.x},  movement: {movement}, ds: {_camera.nearClipPlane}, dc: {distanceToCharacter}");
                transform.Translate(movement * Time.deltaTime * velocityMultiplier, 0.0f, 0.0f);

                Vector3 position = transform.position;
                float limitedX = Mathf.Clamp(position.x, -sideLimit, sideLimit);
                transform.position = new Vector3(limitedX, position.y, position.z);
            }
        }
    }
}