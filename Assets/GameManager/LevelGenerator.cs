using UnityEngine;
using System.Collections.Generic;

public class LevelGenerator : MonoBehaviour {

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
		GenerateLevel(1);
	}
	
	void GenerateLevel(int id) {
		

		TextAsset tempAsset = (TextAsset) Resources.Load("Levels/" + id, typeof(TextAsset));

		string levelText = tempAsset.text;

		string[] lines = levelText.Split(new char[]{'\n'});

		System.Array.Reverse(lines);

		float y = 0;
		foreach (string line in lines) {
			int x = 0;
			foreach (char c in line) {
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
	}
	
	public void JumpToLevel(int levelId) {
		var children = new List<GameObject>();
		foreach (Transform child in transform) children.Add(child.gameObject);
		children.ForEach(child => Destroy(child));
		
		GenerateLevel(levelId);
	}
	
}
