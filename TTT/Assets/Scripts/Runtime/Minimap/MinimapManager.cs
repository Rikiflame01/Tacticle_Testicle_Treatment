using UnityEngine;
using System.Collections.Generic;

public class MinimapManager : MonoBehaviour
{
    public GameObject enemyIconPrefab;
    private Dictionary<GameObject, GameObject> enemyIconMap = new Dictionary<GameObject, GameObject>();

    void Update()
    {
        UpdateEnemyIcons();
    }

    void UpdateEnemyIcons()
    {
        string[] enemyTags = { "SpecialEnemy", "MeleeEnemy", "RangedEnemy" };

        foreach (string tag in enemyTags)
        {
            GameObject[] enemies = GameObject.FindGameObjectsWithTag(tag);
            foreach (GameObject enemy in enemies)
            {
                if (!enemyIconMap.ContainsKey(enemy))
                {
                    // Instantiate icon if it doesn't exist for this enemy
                    GameObject icon = Instantiate(enemyIconPrefab);
                    icon.transform.SetParent(transform);
                    enemyIconMap[enemy] = icon;
                }

                // Update icon position
                Vector3 enemyWorldPos = enemy.transform.position;
                Vector3 iconPos = new Vector3(enemyWorldPos.x, enemyWorldPos.y + 10f, enemyWorldPos.z);
                enemyIconMap[enemy].transform.position = iconPos;
                enemyIconMap[enemy].transform.rotation = Quaternion.Euler(90f, -90f, 0f);  // Adjust these values as needed
                enemyIconMap[enemy].transform.localScale = new Vector3(20f, 20f, 20f);  // Adjust these values as needed

            }
        }
    }
}
