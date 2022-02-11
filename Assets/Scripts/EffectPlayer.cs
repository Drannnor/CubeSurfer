using UnityEngine;

public class EffectPlayer : MonoBehaviour {
    private AudioSource _source;
    private Camera _camera;

    [SerializeField] private AudioClip addCubeSoundEffect;
    [SerializeField] private AudioClip removeCubeSoundEffect;
    private void Awake() {
        var stacker = GetComponent<CubeStacker>();
        if (stacker != null) {
            stacker.onAddCube += PlayAddCubeEffects;
            stacker.onRemoveCube += PlayRemoveCubeEffects;
        } else {
            Debug.LogError("ERROR: cube stacker script not found");
        }

        _source = GetComponent<AudioSource>();
        if (_source == null) {
            Debug.LogWarning("Warning: AudioSource not found");
        }
        
        _camera = Camera.main;
        
    }


    private void PlayAddCubeEffects() {
        _source.pitch = Random.Range(0.8f, 1.1f);
        _source.volume = Random.Range(0.9f, 1.1f);
        _source.PlayOneShot(addCubeSoundEffect);
    }

    private void PlayRemoveCubeEffects() {
        _source.pitch = Random.Range(0.8f, 1.1f);
        _source.volume = Random.Range(0.9f, 1.1f);
        _source.PlayOneShot(removeCubeSoundEffect);
        
        //move to delegate
        _camera.GetComponent<CameraShake>().start = true;
    }
}