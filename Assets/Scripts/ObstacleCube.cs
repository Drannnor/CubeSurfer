using System.Runtime.CompilerServices;
using UnityEngine;

public class ObstacleCube : MonoBehaviour {
    private CubeWall _wall;
    
    private void Start() {
        _wall = transform.parent.GetComponent<CubeWall>();
        if (_wall == null) {
            Debug.Log("ERROR: Obstacle Cube not parented by cube wall");
        }
    }

    private void OnCollisionEnter(Collision collision) {
        if (_wall.isUsed) return;
        if ( !collision.transform.CompareTag("Player")) return;
        var stacker = CubeStacker.GetCubeStackerFromParent(collision.transform);
        
        if (stacker != null) {
            var height = _wall.GetWallHeight(collision.transform.position);
            stacker.SubtractCubes(height, transform.parent);
        } else {
            Debug.Log("ERROR: Unable to access CubeStacker script from player");
        }
    }
}