using UnityEngine;

/// <summary>
/// Displays a configurable health bar for any object with a Damageable as a parent
/// </summary>
public class HealthBar : MonoBehaviour {

    [SerializeField]MaterialPropertyBlock matBlock;
    [SerializeField] MeshRenderer meshRenderer;
    [SerializeField] Camera mainCamera;
    [SerializeField] EnemyScript damageable;
    [SerializeField] float MaxHealth;
    private void Awake() {
        meshRenderer = GetComponent<MeshRenderer>();
        matBlock = new MaterialPropertyBlock();
        // get the damageable parent we're attached to
        damageable = GetComponentInParent<EnemyScript>();
    }

    private void Start() {
        // Cache since Camera.main is super slow
        MaxHealth = GetComponentInParent<EnemyScript>().currentHp;
        mainCamera = Camera.main;
    }

    private void Update() {
        // Only display on partial health
        if (damageable.currentHp <= MaxHealth)
        {
            meshRenderer.enabled = true;
            UpdateParams();
        }
        else
        {
            meshRenderer.enabled = false;
        }
    }

    private void UpdateParams()
    {
        meshRenderer.GetPropertyBlock(matBlock);
        matBlock.SetFloat("_Fill", damageable.currentHp / MaxHealth);
        meshRenderer.SetPropertyBlock(matBlock);
    }

}