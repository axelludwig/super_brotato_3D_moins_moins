using NavMeshPlus.Components;
using UnityEngine;
using UnityEngine.AI;

public class MapGenerator : MonoBehaviour
{
    //These values are set in the Unity Editor
    public GameObject TilesContainer;
    public GameObject DecorationsContainer;
    public GameObject BorderContainer;

    public GameObject SurfacePlane;
    public NavMeshSurface NavMeshSurface;

    public Sprite[] GrassTiles;
    public Sprite[] Decorations;
    public Sprite[] Borders;

    public int MapHeight;
    public int MapWidth;
    public float DecorationDensity;

    // Start is called before the first frame update
    void Start()
    {
        GenerateMap();
    }

    private void GenerateBackground()
    {
        for (int x = -MapWidth / 2; x < MapWidth / 2; x++)
        {
            for (int y = -MapHeight / 2; y < MapHeight / 2; y++)
            {
                //Create a new game object
                GameObject tile = new GameObject();

                //Add a sprite renderer
                SpriteRenderer spriteRenderer = tile.AddComponent<SpriteRenderer>();

                //Set the sprite renderer's sprite to a random grass tile
                spriteRenderer.sprite = GrassTiles[Random.Range(0, GrassTiles.Length)];
                spriteRenderer.sortingOrder = 0;

                //Set the tile's position
                tile.transform.position = new Vector3(x, y, 0);
                tile.transform.parent = TilesContainer.transform;
            }
        }
    }

    private void InitNavMeshSurface()
    {
        SurfacePlane.transform.position = new Vector3(0, 0, 0);
        SurfacePlane.transform.localScale = new Vector3(MapWidth - 1f, MapHeight - 1f, 1);
        NavMeshSurface.BuildNavMesh();
    }

    public void GenerateMap()
    {
        GenerateBackground();
        GenerateDecorations();
        GenerateBorders();
        InitNavMeshSurface();
    }

    public void GenerateDecorations()
    {
        for (int x = -MapWidth / 2; x < MapWidth / 2; x++)
        {
            for (int y = -MapHeight / 2; y < MapHeight / 2; y++)
            {
                if (Random.Range(0f, 1f) < DecorationDensity)
                {
                    GameObject decoration = new GameObject();
                    SpriteRenderer spriteRenderer = decoration.AddComponent<SpriteRenderer>();
                    spriteRenderer.sprite = Decorations[Random.Range(0, Decorations.Length)];
                    spriteRenderer.sortingOrder = 1;
                    decoration.transform.position = new Vector3(x, y, 0);
                    decoration.transform.parent = DecorationsContainer.transform;
                }
            }
        }
    }

    public void GenerateBorders()
    {
        GenerateBorderLine(MapHeight / 2, -MapWidth / 2, 1, false, false);
        GenerateBorderLine(MapHeight / 2, MapWidth / 2, -1, false, true);

        GenerateBorderLine(MapWidth / 2, MapHeight / 2, -1, true, true);
        GenerateBorderLine(MapWidth / 2, -MapHeight / 2, 1, true, false);

    }

    public void GenerateBorderLine(float startA, float startB, float offset, bool isHorizontal, bool mustAddOffset)
    {
        float index = -startA;
        while (index < startA)
        {
            GameObject border = new GameObject();
            SpriteRenderer spriteRenderer = border.AddComponent<SpriteRenderer>();
            spriteRenderer.sprite = Borders[Random.Range(0, Borders.Length)];
            spriteRenderer.sortingOrder = 2;
            float spriteHeight = spriteRenderer.sprite.bounds.size.y;
            float spriteWidth = spriteRenderer.sprite.bounds.size.x;


            float delta = offset;

            if (isHorizontal)
            {
                delta += (mustAddOffset ? spriteHeight : -spriteHeight) / 2;
                border.transform.position = new Vector3(index, startB + delta, 0);
            }
            else
            {
                delta += (mustAddOffset ? spriteWidth : -spriteWidth) / 2;
                border.transform.position = new Vector3(startB + delta, index, 0);
            }

            border.transform.parent = BorderContainer.transform;
            float spriteLength = isHorizontal ? spriteWidth : spriteHeight;
            index += spriteLength * 0.2f + Random.Range(0f, spriteLength * 0.5f);
        }
    }
}
