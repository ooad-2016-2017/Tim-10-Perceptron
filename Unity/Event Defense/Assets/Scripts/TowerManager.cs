using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TowerManager : Singleton<TowerManager> {

	public TowerBtn TowerBtnPressed { get; set; }
	private SpriteRenderer _spriteRenderer;

	private List<Tower> Towers = new List<Tower>();
	//potrebno da znamo koji su 'buildsitefull' da ih izbrisemo
	private List<Collider2D> BuildSites = new List<Collider2D>();

	private Collider2D _buildTile;

	void Start () {
		_spriteRenderer = GetComponent<SpriteRenderer>();		
		_buildTile = GetComponent<Collider2D>();
		_spriteRenderer.enabled = false;
	}

	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			RaycastHit2D hit = Physics2D.Raycast (worldPoint, Vector2.zero);
			if (TowerBtnPressed != null && hit.collider.tag == "BuildSite") {
				_buildTile = hit.collider;
				_buildTile.tag = "BuildSiteFull";
				RegisterBuildSite(_buildTile);
				PlaceTower (hit);
			}
		}
		if (_spriteRenderer.enabled) {
			//kada klikne na neki tower u UI, da prati kursor dok ne postavi tower
			FollowMouse ();
		}
	}

	public void RegisterBuildSite(Collider2D buildTag){
		BuildSites.Add(buildTag);
	}

	public void RegisterTower(Tower tower){
		Towers.Add(tower);
	}

	public void RenameTagsBuildSites(){
		foreach(Collider2D buildTag in BuildSites){
			buildTag.tag = "BuildSite";
		}
		BuildSites.Clear();
	}

	public void DestroyAllTowers(){
		foreach(Tower tower in Towers){
			Destroy(tower.gameObject);
		}
		Towers.Clear();
	}

	public void PlaceTower(RaycastHit2D hit){
		if (!EventSystem.current.IsPointerOverGameObject () && TowerBtnPressed != null) {
			Tower newTower = Instantiate (TowerBtnPressed.TowerObject);
			newTower.transform.position = hit.transform.position;
			BuyTower(TowerBtnPressed.TowerPrice);
			RegisterTower(newTower);
			DisableDragSprite();
		}
	}

	public void BuyTower(int price){
		GameManager.Instance.SubtractMoney(price);
	}

	public void SelectedTower(TowerBtn towerSelected){
		if(towerSelected.TowerPrice <= GameManager.Instance.TotalMoney){
			TowerBtnPressed = towerSelected;
			EnableDragSprite (TowerBtnPressed.DragSprite);
		}
	}

	public void FollowMouse(){
		this.transform.position = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		this.transform.position = new Vector2 (this.transform.position.x, this.transform.position.y);
	}

	public void EnableDragSprite(Sprite sprite){
		_spriteRenderer.enabled = true;
		_spriteRenderer.sprite = sprite;
	}

	public void DisableDragSprite(){
		_spriteRenderer.enabled = false;
		TowerBtnPressed = null;
	}

}
