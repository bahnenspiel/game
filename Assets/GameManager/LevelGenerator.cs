using UnityEngine;
using System.Collections.Generic;

public class LevelGenerator : MonoBehaviour {

	private GameManagerScript gm;
	private int time;

	[System.Serializable]
	public struct CharGameObjectMapping {
		public char character;
		public GameObject prefab;
	}

	public CharGameObjectMapping[] gameElements;

	private Dictionary<char,GameObject> prefabDict = null;

	// Use this for initialization
	void Start () {
		prefabDict = new Dictionary<char,GameObject>();
		foreach (CharGameObjectMapping mapping in gameElements) {
		prefabDict.Add(mapping.character, mapping.prefab);
		}

		gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManagerScript>();
		GenerateLevel(gm.getLevelNumber());
	}
	
	void GenerateLevel(int id) {

		TextAsset tempAsset = (TextAsset) Resources.Load("Levels/" + id, typeof(TextAsset));

		string levelText = tempAsset.text;

		string[] lines = levelText.Split(new char[]{'\n'});

		System.Array.Reverse(lines);

		time = int.Parse(lines[lines.Length - 1 ]);

		float y = 0;
		for (int i = 0; i < lines.Length - 1; i++ ) {
			int x = 0;
			foreach (char c in lines[i]) {
		
				if(prefabDict.ContainsKey(c) || prefabDict.ContainsKey(char.ToLower(c))) {
						GameObject newObject = null;

						if (char.IsUpper(c)) {
							GameObject prefab = prefabDict[char.ToLower(c)];
							newObject = (GameObject) GameObject.Instantiate(prefab, new Vector3(x, 4, y ), new Quaternion());
						} else {
							GameObject prefab = prefabDict[c];
							newObject = (GameObject) GameObject.Instantiate(prefab, new Vector3(x, 0, y ), new Quaternion());
						}

						newObject.transform.parent = transform;
					}

				x += 5;
			}
			y += 20;
		}

		gm.levelLoaded();
		gm.levelLength = lines.Length - 2;
		gm.levelTime = time;

	}
}
