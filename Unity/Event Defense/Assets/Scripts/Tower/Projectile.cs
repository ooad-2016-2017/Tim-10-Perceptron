using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ProjectileType{
	rock, arrow, fireball
};

public class Projectile : MonoBehaviour {

	[SerializeField]
	private int _attackStrength;

	[SerializeField]
	private ProjectileType _projectileType;

	public int GetAttackStrength{
		get { return _attackStrength; }
	}

	public ProjectileType GetProjectileType{
		get { return _projectileType; }
	}

	void Start(){
		GameManager.Instance.Projectiles.Add(this);
	}

}
