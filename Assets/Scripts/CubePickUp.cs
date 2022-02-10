using System;
using UnityEngine;

public class CubePickUp : MonoBehaviour{

    private int _numberOfCubes = 1;
    // Start is called before the first frame update
    void Start(){
        //TODO spawn more stacked cubes
        // for (int i = 0; i < _numberOfCubes; i++) {
        //     //TODO
        // }
    }

    // Update is called once per frame
    void Update(){
    }

    private void OnTriggerEnter(Collider other){
        if (other.CompareTag("Player")) {
            CubeStacker stacker = GetCubeStackerFromParent(other.transform);
            
            if (stacker != null) {
                stacker.AddCube(_numberOfCubes);
                Destroy(gameObject);
                //TODO destroy all cubes of this stack;

            } else {
                Debug.Log("ERROR: Unable to access CubeStacker script from player");
            }
        }
    }

    /*
     * recursively look for the parent's cubestacker
     */
    private CubeStacker GetCubeStackerFromParent(Transform other){
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