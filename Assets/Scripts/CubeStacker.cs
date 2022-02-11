using UnityEngine;
using UnityEngine.SceneManagement;

public class CubeStacker : MonoBehaviour {
    [SerializeField] private GameObject cubePrefab;

    private int _cubeCount;

    private Transform _firstCube;
    private static float _initialOffset = 1.5f;

    private void Start() {
        _cubeCount = 1;
        transform.Translate(Vector3.up);
        GameObject cube = Instantiate(cubePrefab, transform, false);
        _initialOffset = 1.5f;
        var cubeOffset = Vector3.down * _initialOffset;
        cube.transform.localPosition += cubeOffset;
        _firstCube = cube.transform;
    }

    // Update is called once per frame
    private void Update() {
        // Debug.Log("update");

        if (Input.GetButtonDown("Jump")) {
            AddCube(1);
        }
    }

    public void AddCube(int amount) {
        for (var i = 0; i < amount; i++) {
            _cubeCount++;
            //move player up
            transform.Translate(Vector3.up);

            GameObject cube = Instantiate(cubePrefab, _firstCube, false);

            //first cube offset is 1.5 successive cubes will have an offset of 1.0f
            var cubeOffset = Vector3.down;
            cube.transform.localPosition += cubeOffset;

            _firstCube = cube.transform;
        }
    }

    public void SubtractCubes(int amount, Transform obstacle) {
        _cubeCount -= amount;

        if (_cubeCount <= 0) {
            GameManager.GM.GetGameMenuController().ShowDeathScreen();
            return;
        }


        var cubeToCut = SearchForNewFirstCube(_cubeCount, transform.GetChild(0));

        _firstCube = cubeToCut.parent;

        //prune;
        cubeToCut.parent = obstacle;
    }

    /*
     * Recursively search for the First cube
     */
    private Transform SearchForNewFirstCube(int cubeCount, Transform cube) {
        if (cube.childCount == 0 || cubeCount == 0) {
            return cube;
        }

        var child = cube.GetChild(0);

        return SearchForNewFirstCube(cubeCount - 1, child);
    }

    /*
     * recursively search for the parent for the cubeStacker script
     */
    public static CubeStacker GetCubeStackerFromParent(Transform other) {
        CubeStacker result = other.GetComponent<CubeStacker>();
        //CubeStacker found
        if (result != null) {
            return result;
        }

        //check if has parent
        if (other.parent != null) {
            return GetCubeStackerFromParent(other.parent);
        }

        return null;
    }
}