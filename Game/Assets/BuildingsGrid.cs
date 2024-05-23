using UnityEngine;
using UnityEngine.UI;

public class BuildingsGrid : MonoBehaviour
{
    public Vector2Int GridSize = new Vector2Int(10, 10);
    public GameObject Build_Panel;
    private Building[,] grid;
    private Building flyingBuilding;
    public Camera mainCamera;
    bool Panel = false;
    public static int metal = 1000;
    public static int tree = 100000;
    public static int stone = 10000;
    public static int win_build = 0;
    public TMPro.TMP_Text tree_text;
    public TMPro.TMP_Text stone_text;
    public TMPro.TMP_Text metal_text;

    private void Awake()
    {
        grid = new Building[GridSize.x, GridSize.y];   
    }
    public void StartPlacingBuilding(Building buildingPrefab)
    {
            if (flyingBuilding != null || Panel == false)
            {
                Destroy(flyingBuilding.gameObject);
            }
            flyingBuilding = Instantiate(buildingPrefab);
            win_build ++;        
    }

    private void Update()
    {
        tree_text.text = tree.ToString();
        stone_text.text = stone.ToString();
        metal_text.text = metal.ToString();
        if (Input.GetKeyDown(KeyCode.Z) && Panel == false)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            Build_Panel.SetActive(true);
            GameObject TimeScriptS = GameObject.Find("FirstPersonController 1");
            Shooting ScriptS = TimeScriptS.GetComponent<Shooting>();
            ScriptS.enabled = false;
            Panel = true;

        }
        if (Input.GetKeyDown(KeyCode.X) && Panel == true)
        {
            Build_Panel.SetActive(false);
            GameObject TimeScriptS = GameObject.Find("FirstPersonController 1");
            Shooting ScriptS = TimeScriptS.GetComponent<Shooting>();
            ScriptS.enabled = true;
            Panel = false;

            if (flyingBuilding != null && Panel == false)
            {
                Destroy(flyingBuilding.gameObject);
            }
        }
        if (flyingBuilding != null)
        {
            var groundPlane = new Plane(Vector3.up, Vector3.zero);
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

            if (groundPlane.Raycast(ray, out float position))
            {
                Vector3 worldPosition = ray.GetPoint(position);

                int x = Mathf.RoundToInt(worldPosition.x);
                int y = Mathf.RoundToInt(worldPosition.z);

                bool available = true;

                if (x < 0 || x > GridSize.x - flyingBuilding.Size.x) available = false;
                if (y < 0 || y > GridSize.y - flyingBuilding.Size.y) available = false;

                if (available && IsPlaceTaken(x, y)) available = false;

                flyingBuilding.transform.position = new Vector3(x, 0, y);
                flyingBuilding.SetTransparent(available);
                if (available && Input.GetMouseButtonDown(0))
                {
                    PlaceFlyingBuilding(x, y);
                }
            }
        }
    }

    private bool IsPlaceTaken(int placeX, int placeY)
    {
        for (int x = 0; x < flyingBuilding.Size.x; x++)
        {
            for (int y = 0; y < flyingBuilding.Size.y; y++)
            {
                if (grid[placeX + x, placeY + y] != null) return true;
            }
        }

        return false;
    }

    private void PlaceFlyingBuilding(int placeX, int placeY)
    {
        for (int x = 0; x < flyingBuilding.Size.x; x++)
        {
            for (int y = 0; y < flyingBuilding.Size.y; y++)
            {
                grid[placeX + x, placeY + y] = flyingBuilding;
            }
        }
        
        flyingBuilding.SetNormal();
        flyingBuilding = null;
    }
}
