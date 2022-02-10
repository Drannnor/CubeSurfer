using UnityEngine;

public class CubeStacker : MonoBehaviour{

    [SerializeField] private GameObject cubePrefab;
    
    private int _cubeCount;

    private GameObject _firstCube;
    private static float _initialOffset = 1.5f;

    // Start is called before the first frame update
    void Awake(){
        
    }
    
    void Start(){
        _cubeCount = 1;
        transform.Translate(Vector3.up);
        GameObject cube = Instantiate(cubePrefab, transform, false);
        _initialOffset = 1.5f;
        var cubeOffset = Vector3.down * _initialOffset;
        cube.transform.localPosition += cubeOffset;
        _firstCube = cube;
    }

    // Update is called once per frame
    void Update(){
        // Debug.Log("update");

        if (Input.GetButtonDown("Jump")) {
            AddCube(1);
        }
    }

    public void AddCube(int amount){
        
        for (int i = 0; i < amount; i++) {
            _cubeCount ++;
            //move player up
            transform.Translate(Vector3.up);
        
            GameObject cube = Instantiate(cubePrefab, _firstCube.transform, false);
            
            //first cube offset is 1.5 successive cubes will have an offset of 1.0f
            var cubeOffset = Vector3.down;
            cube.transform.localPosition += cubeOffset;

            _firstCube = cube;
        }
    }

    public void SubtractCubes(int amount){
        
    }
    
}