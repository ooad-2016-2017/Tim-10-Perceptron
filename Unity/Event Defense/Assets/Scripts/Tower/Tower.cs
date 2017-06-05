using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour {

	[SerializeField]
	private float _attackDelay;

	[SerializeField]
	private float _attackRadius;

	[SerializeField]
	private Projectile _projectile;

	private Enemy _targetEnemy = null;

	private float _attackCounter;

	private bool _isAttacking = false;

	void Update () {
		_attackCounter -= Time.deltaTime;
		if (_targetEnemy == null) {
			Enemy nearestEnemy = getNearestEnemyInRange ();
			if (nearestEnemy != null
			    && Vector2.Distance (transform.position, nearestEnemy.transform.position) <= _attackRadius)
				_targetEnemy = nearestEnemy;
		} else {
			if (_attackCounter <= 0) {
				_isAttacking = true;
				_attackCounter = _attackDelay;
			} else {
				_isAttacking = false;
			}		

			if (Vector2.Distance (transform.position, _targetEnemy.transform.position) > _attackRadius)
				_targetEnemy = null;
		}
	}

	void FixedUpdate(){
		if(_isAttacking) Attack ();
	}

	public void Attack(){
		_isAttacking = false;
		Projectile projectile = Instantiate (_projectile) as Projectile;
		projectile.transform.localPosition = transform.localPosition;

		if (_targetEnemy == null)
			Destroy (projectile);
		else {
			StartCoroutine(MoveProjectile (projectile));
		}
			
	}

	IEnumerator MoveProjectile(Projectile projectile){

		while(getTargetDistance(_targetEnemy) > 0.20f 
			&& projectile != null 
			&& _targetEnemy != null){
			var direction = _targetEnemy.transform.localPosition - transform.localPosition;
			var angleDirection = Mathf.Atan2 (direction.y, direction.x) * Mathf.Rad2Deg;
			projectile.transform.rotation = Quaternion.AngleAxis (angleDirection, Vector3.forward);
			projectile.transform.localPosition = Vector2.MoveTowards (projectile.transform.localPosition, _targetEnemy.transform.localPosition, 5f * Time.deltaTime);
			yield return null;
		}

		if(projectile != null || _targetEnemy == null){
			Destroy (projectile);
		}

	}

	private float getTargetDistance(Enemy enemy){
		if(enemy == null){
			enemy = getNearestEnemyInRange ();
			if (enemy == null) {
				return 0f;
			}
		}
		return Mathf.Abs(Vector2.Distance(enemy.transform.position, transform.localPosition));
	}

	private List<Enemy> getEnemiesInRange(){
		List<Enemy> enemiesInRange = new List<Enemy> ();
		foreach (Enemy enemy in GameManager.Instance.Enemies) 
			if (Vector2.Distance (enemy.transform.localPosition, this.transform.localPosition) <= _attackRadius)
				enemiesInRange.Add (enemy);
		
		return enemiesInRange;
	}

	private Enemy getNearestEnemyInRange(){
		Enemy nearestEnemy = null;
		float smallestDistance = float.PositiveInfinity;

		foreach(Enemy enemy in getEnemiesInRange()){
			float distance = Vector2.Distance (enemy.transform.localPosition, transform.localPosition);
			if (distance <= smallestDistance) {
				smallestDistance = distance;
				nearestEnemy = enemy;
			}
		}

		return nearestEnemy;
	}


}
