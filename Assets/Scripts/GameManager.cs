using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TX;
using TX.Game;


public enum GameState
{
	Loading,
	PostLoading,
	InGame,
	GameOver
}

public class GameManager : Singleton<GameManager> {


	public GameState State { get; private set; }

	public HashSet<MonoBehaviour> sceneInitializers = new HashSet<MonoBehaviour>();

	public HashSet<MonoBehaviour> postSceneInitializers = new HashSet<MonoBehaviour>();

	void Awake() {
		State = GameState.Loading;
	}
	
	// Update is called once per frame
	void Update () {
		switch (State) {
		case GameState.Loading:
			if (sceneInitializers.Count == 0)
				State = GameState.PostLoading;
			break;

		case GameState.PostLoading:
			if (postSceneInitializers.Count == 0)
				State = GameState.InGame;
			break;

		case GameState.InGame:
			break;
		case GameState.GameOver:
			break;
		}
	}
}

public static class GameMetadata {
	public static readonly Vector2 MapSize = new Vector2(100, 10240);
	public static readonly Rect MapRegion = 
		Rect.MinMaxRect(
			-MapSize.x/2, 0,
			MapSize.x/2, MapSize.y);
}
