using UnityEngine;

public class CubeStacker : MonoBehaviour{

    [SerializeField] private GameObject cubePrefab;
    
    private int _cubeCount;
    
    // Start is called before the first frame update
    void Awake(){
        
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
            _cubeCount += amount;
            //move player up
            transform.Translate(Vector3.up);
        
            GameObject cube = Instantiate(cubePrefab, transform, false);
            //first cube offset is 1.5 successive cubes will have an offset of 1.0f
            var cubeOffset = Vector3.down * (1.5f + _cubeCount - 1);
            cube.transform.localPosition += cubeOffset;
        }
    }

    public void SubtractCubes(int amount){
        
    }
    
}