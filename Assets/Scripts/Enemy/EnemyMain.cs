using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMain : MonoBehaviour {

    [SerializeField] private float damage = 20f;
    [SerializeField] private float health = 100f;
    [SerializeField] private float speed = 3f;

    // To lock rotation - DELETE
    private Quaternion lockedRotation;

    public event EventHandler OnDestroySelf;
    public event EventHandler<OnDamagedEventArgs> OnDamaged;
    public class OnDamagedEventArgs {
        public Player attacker;
        public float damageMultiplier;
    }

    public Enemy Enemy { get; private set; }

    public EnemyPathfindingMovement EnemyPathfindingMovement { get; private set; }
    public EnemyTargeting EnemyTargeting { get; private set; }
    // public EnemyStats EnemyStats { get; private set; }
    public Rigidbody2D EnemyRigidbody2D { get; private set; }
    // public ICharacterAnims CharacterAnims { get; private set; }
    // public IAimShootAnims AimShootAnims { get; private set; }

    // public HealthSystem HealthSystem { get; private set; }

    private void Awake() {
        Enemy = GetComponent<Enemy>();

        EnemyPathfindingMovement = GetComponent<EnemyPathfindingMovement>();
        EnemyTargeting = GetComponent<EnemyTargeting>();
        // EnemyStats = GetComponent<EnemyStats>();
        EnemyRigidbody2D = GetComponent<Rigidbody2D>();
        // CharacterAnims = GetComponent<ICharacterAnims>();
        // AimShootAnims = GetComponent<IAimShootAnims>();

        // HealthSystem = new HealthSystem(100);
    }

    private void Start() {
        lockedRotation = transform.rotation;
    }

    private void Update() {
        // transform.rotation = lockedRotation;
    }

    public Vector3 GetPosition() {
        return transform.position;
    }

    public void DestroySelf() {
        OnDestroySelf?.Invoke(this, EventArgs.Empty);
    }

    public void Damage(Player attacker, float damageMultiplier) {
        OnDamaged?.Invoke(this, new OnDamagedEventArgs {
            attacker = attacker,
            damageMultiplier = damageMultiplier,
        });
    }

    private void OnTriggerEnter2D(Collider2D collider) {
        //Player player = collider.GetComponent<Player>();

        if (collider.TryGetComponent<BulletPhysics>(out BulletPhysics bullet)) {
            bullet.DestroyBullet();
            TakeDamage(bullet.GetBulletDamage());
        }
    }

    public void TakeDamage(float damage) {
        if (health > 0) {
            health -= damage;
        }

        if (health == 0 || health < 0) {
            EnemyDie();
        }
    }

    public void EnemyDie() {
        gameObject.SetActive(false);
    }

}
