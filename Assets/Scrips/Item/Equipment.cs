using UnityEngine;
using UnityEngine.InputSystem;

public class Equipment : MonoBehaviour
{
    public Equip curEquip;
    public Transform equipParent;
    public EquipTool equipTool;

    private PlayerController controller;
    private PlayerCondition condition;

    void Start()
    {
        controller = CharacterManager.Instance.Player.controller;
        condition = CharacterManager.Instance.Player.condition;
    }

    public void OnAttackInput(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed && curEquip != null && controller.canLook)
        {
            curEquip.OnAttackInput();
        }
    }

    public void EquipNew(ItemData data)
    {
        UnEquip();
        equipTool = Instantiate(data.equipPrefab, equipParent).GetComponent<EquipTool>();
        controller.EquipSpeedUp(equipTool.speed, equipTool.jump);
    }

    public void UnEquip()
    {
        if (equipTool != null)
        {
            Destroy(equipTool.gameObject);
            controller.UnEquipSpeedup(equipTool.speed, equipTool.jump);
            curEquip = null;
        }
    }
}