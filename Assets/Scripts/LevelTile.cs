using UnityEngine;

public class LevelTile : MonoBehaviour{

    private float _tileSpeed = 5.0f;
    
    // Update is called once per frame
    private void Update(){
        transform.Translate(Vector3.back * (_tileSpeed * Time.deltaTime));

        if (transform.position.z <= -10) {
            foreach (Transform child in transform) {
                Destroy(child.gameObject);
            }
            Destroy(gameObject);
        }
    }

    public void SetTileSpeed(float speed){
        _tileSpeed = speed;
    }
}