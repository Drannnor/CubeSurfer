using UnityEngine;

public class CubePickUp : MonoBehaviour {
    private int _numberOfCubes = 1;

    private bool isUsed;

    // Start is called before the first frame update
    void Start() {
        isUsed = false;
        //TODO spawn more stacked cubes
        // for (int i = 0; i < _numberOfCubes; i++) {
        //     //TODO
        // }
    }


    private void OnTriggerEnter(Collider other) {
        if (!other.CompareTag("Player") || isUsed) return;

        var stacker = CubeStacker.GetCubeStackerFromParent(other.transform);

        if (stacker != null) {
            stacker.AddCube(_numberOfCubes);
            isUsed = true;
            Destroy(gameObject);
            //TODO destroy all cubes of this stack;
        } else {
            Debug.Log("ERROR: Unable to access CubeStacker script from player");
        }
    }
}