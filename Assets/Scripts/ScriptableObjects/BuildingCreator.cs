using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Tilemaps;
using UnityEngine.InputSystem;

public class BuildingCreator : Singleton<BuildingCreator>
{
    [SerializeField] private Tilemap previewMap, defaultMap;
    PlayerInput playerInput;
    Vector2 mousePos;
    Vector3Int currentGridPosition;
    Vector3Int lastGridPosition;

    Camera _camera;

    TileBase tileBase;
    BuildingObjectsBase selectedObj;

    protected override void Awake() {
        base.Awake();
        playerInput = new PlayerInput();
        _camera = Camera.main;
    }

    private void Update() {
        // if something is selected - show preview
        if(selectedObj != null) {
            Vector3 pos = _camera.ScreenToWorldPoint(mousePos);
            Vector3Int gridPos = previewMap.WorldToCell(pos);
            if (gridPos != currentGridPosition) {
                lastGridPosition = currentGridPosition;
                currentGridPosition = gridPos;

                // update preview
                UpdatePreview();
            }
        }
    }

    private void OnEnable() {
        playerInput.Enable();

        playerInput.Gameplay.MousePosition.performed += OnMouseMove;
        playerInput.Gameplay.MousePosition.performed += OnLeftClick;
        playerInput.Gameplay.MousePosition.performed += OnRightClick;
    }

    private BuildingObjectsBase SelectedObj {
        set {
            selectedObj = value;
            tileBase = selectedObj != null ? selectedObj.TileBase : null;
            UpdatePreview();
        }
    }

    private void OnDisable() {
        playerInput.Disable();

        playerInput.Gameplay.MousePosition.performed -= OnMouseMove;
        playerInput.Gameplay.MousePosition.performed -= OnLeftClick;
        playerInput.Gameplay.MousePosition.performed -= OnRightClick;
    }

    private void OnMouseMove(InputAction.CallbackContext ctx) {
        mousePos = ctx.ReadValue<Vector2>();
    }


    private void OnLeftClick (InputAction.CallbackContext ctx) {
        if (selectedObj != null) {
            HandleDrawing();
        }
    }
    private void OnRightClick(InputAction.CallbackContext ctx) {
        SelectedObj = null;
    }

    public void ObjectSelected (BuildingObjectsBase obj) {
        SelectedObj = obj;

        
    }

    private void UpdatePreview() {
        // Remove old tile if existing
        previewMap.SetTile(lastGridPosition, null);
        // set current tile to current mouse position tile
        previewMap.SetTile(currentGridPosition, tileBase);
    }

    private void HandleDrawing() {
        DrawItem();
    }

    private void DrawItem() {
        // Todo: Autmatically select tilemap
        defaultMap.SetTile(currentGridPosition, tileBase);
    }
}
