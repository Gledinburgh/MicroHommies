using System;
using UnityEngine;

public class AlignToScreenEdges : MonoBehaviour
{

    public SpriteRenderer top;
    public SpriteRenderer right;
    public SpriteRenderer bottom;
    public SpriteRenderer left;
    public SpriteRenderer infoPanelLeft;

    public GameObject borderBackground;
    public Color startColor;

    public SpriteRenderer infoPanel;
    public GameObject hommieBackdrop;
    private SpriteRenderer[] hommieBackdropRenderers;
    public SpriteRenderer hommie;

    float screenWidth;
    float screenHeight;

    public float borderThickness = 1f;
    public float infoPanelwidth = 4.5f;
    private void Awake()
    {
        screenWidth = Camera.main.orthographicSize * 2.0f * Screen.width / Screen.height;
        screenHeight = Camera.main.orthographicSize * 2.0f;

        hommieBackdropRenderers = hommieBackdrop.GetComponentsInChildren<SpriteRenderer>();

        //make sure they are in this mode, for reasons ;P Hahah.
        top.drawMode = SpriteDrawMode.Tiled;
        right.drawMode = SpriteDrawMode.Tiled;
        bottom.drawMode = SpriteDrawMode.Tiled;
        left.drawMode = SpriteDrawMode.Tiled;

        infoPanel.drawMode = SpriteDrawMode.Tiled;

        Arrange();
    }



    private void Arrange()
    {
        // *** This will only work if the pivot point (anchor) of the sprite is set to the center edge of the sprite
        // *** That can be done in the sprite editor


        //set the boarder width
        setBorderWidth();

        //set sizing for hommie backdrop;
        SetBackdropWidth();

        //allign to edges
        PositionRight(right);
        PositionLeft(left);
        PositionTop(top);
        PositionBottom(bottom);

        PositionPannel(infoPanel);
        PositionPannelLeft(infoPanelLeft);
        PositionHommieBackdrop();
        PositionHommie(hommie);

        CloneEdgesToBeUsedAsBackgrounds();
    }

    private void CloneEdgesToBeUsedAsBackgrounds()
    {
        SpriteRenderer[] edgesToClone = new SpriteRenderer[] {left,top,bottom };

        foreach (SpriteRenderer edge in edgesToClone)
        {
            //create new border objects
            GameObject newEdge = new GameObject();
            newEdge.transform.SetParent(borderBackground.transform);
            SpriteRenderer newEdgeRenderer = newEdge.AddComponent<SpriteRenderer>();


            newEdgeRenderer.drawMode = SpriteDrawMode.Tiled;
            newEdgeRenderer.sprite = edge.sprite;


            newEdgeRenderer.color = startColor;

            //copy component values
            newEdgeRenderer.size = new Vector2(edge.size.x, edge.size.y);
            newEdgeRenderer.transform.position = new Vector3(edge.transform.position.x, edge.transform.position.y, edge.transform.position.z);
            newEdgeRenderer.sortingOrder = edge.sortingOrder - 1;
           

        }
    }

    private void SetBackdropWidth()
    {      

        foreach (SpriteRenderer spriteRenderer in hommieBackdropRenderers)
        {
        spriteRenderer.size = new Vector2(infoPanel.size.x - borderThickness * 2, infoPanel.size.y - borderThickness * 2);
        }
       
    }

    private void PositionHommieBackdrop()
    {

        foreach (SpriteRenderer spriteRenderer in hommieBackdropRenderers)
        {
            PositionHommieBackdrop(spriteRenderer);
        }

    }

    private void setBorderWidth()
    {
        float x = top.size.x * (screenWidth / top.bounds.size.x);
        float y = left.size.y * (screenHeight / top.bounds.size.x);
       

        top.size = new Vector2(x, borderThickness);
        bottom.size = new Vector2(x, borderThickness);
        left.size = new Vector2(borderThickness, y);
        right.size = new Vector2(borderThickness, y);
        infoPanelLeft.size = new Vector2(borderThickness, y);
        infoPanel.size = new Vector2(infoPanelwidth, y );
        infoPanel.color = startColor;
        //infoPanel.size = new Vector2(infoPanelwidth - borderThickness, y - borderThickness * 2);
    }

    private void PositionRight(SpriteRenderer sprite)
    {
        
        float targetXPosition = screenWidth / 2;       
        sprite.transform.position = new Vector3(targetXPosition, transform.position.y, transform.position.z);

    }
    private void PositionLeft(SpriteRenderer sprite)
    {
        
        float targetXPosition = -screenWidth / 2;        
        sprite.transform.position = new Vector3(targetXPosition, transform.position.y, transform.position.z);
            }

    private void PositionTop(SpriteRenderer sprite)
    {
        
        float targetYPosition = screenHeight/2;        
        sprite.transform.position = new Vector3(transform.position.x, targetYPosition, transform.position.z);
    }

    private void PositionBottom(SpriteRenderer sprite)
    {
        
        float targetYPosition = -screenHeight/2;        
        sprite.transform.position = new Vector3(transform.position.x, targetYPosition, transform.position.z);
    }
    private void PositionPannel(SpriteRenderer sprite)
    {
       
        float targetXPosition = screenWidth / 2;
        sprite.transform.position = new Vector3(targetXPosition, transform.position.y, transform.position.z);
     }
    private void PositionPannelLeft(SpriteRenderer sprite)
    {
        float targetXPosition = screenWidth / 2 - infoPanelwidth + borderThickness;
        sprite.transform.position = new Vector3(targetXPosition, transform.position.y, transform.position.z);
    }

    private void PositionHommieBackdrop(SpriteRenderer sprite)
    {
        float targetXPosition = screenWidth / 2 - borderThickness;
       // float targetYPosition = screenHeight / 2 - (sprite.size.y * 1.5f);
        sprite.transform.position = new Vector3(targetXPosition, transform.position.y, transform.position.z);

    }

    private void PositionHommie(SpriteRenderer sprite)
    {
        SpriteRenderer backdrop = hommieBackdropRenderers[0];
        float targetXPosition = backdrop.transform.position.x - backdrop.size.x / 2;
        float targetYPosition = screenHeight / 2 - (backdrop.size.y - (sprite.size.y + borderThickness * 2 ));

        sprite.transform.position = new Vector3(targetXPosition, targetYPosition, 0);


    }



}
