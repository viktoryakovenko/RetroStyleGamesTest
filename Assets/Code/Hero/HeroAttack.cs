using Code.Logic;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

public class HeroAttack : MonoBehaviour
{
    public float Damage;

    private InputActions _actions;

    [Inject]
    private void Construct(InputActions actions)
    {
        _actions = actions;
    }

    private void OnEnable()
    {
        _actions.Enable();
        _actions.Player.Fire.started += Attack;
        _actions.Player.Fire2.started += Ultimate;
    }

    private void OnDisable()
    {
        _actions.Disable();
        _actions.Player.Fire.started -= Attack;
        _actions.Player.Fire2.started -= Ultimate;
    }
    private void Attack(InputAction.CallbackContext context)
    {
        var health = GetComponent<IHealth>();
        health.TakeDamage(Damage);
        Debug.Log(health.Current);
    }

    private void Ultimate(InputAction.CallbackContext context)
    {
        Debug.Log("Ultimate!");
    }

}
