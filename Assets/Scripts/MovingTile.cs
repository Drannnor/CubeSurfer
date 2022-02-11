using UnityEngine;

public class MovingTile : MonoBehaviour {
    private float _levelSpeed = 5.0f;
    private float _destructionDistance = 10.0f;
    [SerializeField] private bool move = true;

    private void Update() {
        if (!move) return;
        transform.Translate(Vector3.back * (_levelSpeed * Time.deltaTime));
        if (transform.position.z <= -_destructionDistance) {
            foreach (Transform child in transform) {
                Destroy(child.gameObject);
            }

            Destroy(gameObject);
        }
    }

    public void SetLevelSpeed(float speed) {
        _levelSpeed = speed;
    }

    public void SetDestructionDistance(float distance) {
        _destructionDistance = distance;
    }
}