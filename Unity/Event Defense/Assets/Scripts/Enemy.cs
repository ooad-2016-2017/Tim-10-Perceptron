using UnityEngine;

public class Enemy : MonoBehaviour {

	[SerializeField]
	private int _target = 0;

	[SerializeField]
	private Transform _exitPoint;

	[SerializeField]
	private Transform[] _wayPoints;

	[SerializeField] 
	private float _navigationUpdate;

	[SerializeField]
	private int _health; 

	[SerializeField]
	private int _rewardAmount;

	private Transform _enemy;
	private float _navigationTime = 0;	
	private bool _isDead = false;

	public bool IsDead{
		get{ return _isDead; }
	}

	void Start () {
		_enemy = GetComponent<Transform> ();
		GameManager.Instance.RegisterEnemy (this);
	}

	void Update () {
		if (_wayPoints != null && !IsDead) {
			_navigationTime += Time.deltaTime;
			if (_navigationTime > _navigationUpdate) {
				if (_target < _wayPoints.Length) 
					_enemy.position = Vector2.MoveTowards (_enemy.position, _wayPoints [_target].position, _navigationTime);
				else 
					_enemy.position = Vector2.MoveTowards (_enemy.position, _exitPoint.position, _navigationTime);
				
				_navigationTime = 0;
			}
		}
	}

	public void EnemyHit(int hitPoints){
		if (_health - hitPoints > 0)
			_health -= hitPoints;
		else {
			GameManager.Instance.UnregisterEnemy (this);
			GameManager.Instance.TotalKilled++;
			GameManager.Instance.AddMoney(_rewardAmount);
			GameManager.Instance.IsWaveOver ();
			_isDead = true;
		}
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "checkpoint")
			_target++;
		else if (other.tag == "finish") {
			GameManager.Instance.UnregisterEnemy (this);
			GameManager.Instance.TotalEscaped++;
			GameManager.Instance.RoundEscaped++;
			GameManager.Instance.IsWaveOver ();
		}
		else if (other.tag == "projectile") {	
			Projectile projectile = other.gameObject.GetComponent<Projectile> ();	
			if(projectile == null) Destroy(other);
			EnemyHit (projectile.GetAttackStrength);
			Destroy (other.gameObject);			
		}
	}

}
