using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TX;
using TX.Game;

public class GameManager : Singleton<GameManager> {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

public static class GameMetadata {
	public static readonly Vector2 MapSize = new Vector2(100, 1280);
	public static readonly Rect MapRegion = 
		Rect.MinMaxRect(
			-MapSize.x/2, 0,
			MapSize.x/2, MapSize.y);
}
