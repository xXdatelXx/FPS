//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.4.4
//     from Assets/Source/Runtime/Input/PlayerInput.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @PlayerInput : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerInput()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInput"",
    ""maps"": [
        {
            ""name"": ""Movement"",
            ""id"": ""360e8c50-d852-484f-b468-43708b6bac6d"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""9fe0ae10-aa45-4596-b026-20eb12eb25c3"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""76eeec9f-5b0b-4850-bae8-8e7b681cc679"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""c2a69c83-c18a-46df-9a8a-a33b63ade2af"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""9671d14e-f9ae-479b-af69-0114a0b2c332"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""d7c0885f-7360-4151-956d-776802b17a77"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""9b9e128a-48ff-41cc-a5a8-c7bf45a4e6ea"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""dfaeaf4b-328a-4d6a-9dfc-655613f131ce"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""beb9546d-0838-42dc-a2e8-19ef6e37da75"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Rotation"",
            ""id"": ""49a1bfc5-6349-423e-a384-b84bd42d5703"",
            ""actions"": [
                {
                    ""name"": ""Rotate"",
                    ""type"": ""Value"",
                    ""id"": ""b5f45640-2ef7-453b-bbfe-925cf713d647"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""27adabb7-ec0e-4041-8440-0722c438f1a7"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Weapon"",
            ""id"": ""2b00acc9-55fe-4e61-9c5a-9a12bb623c4c"",
            ""actions"": [
                {
                    ""name"": ""Shoot"",
                    ""type"": ""Button"",
                    ""id"": ""692551a3-3c6c-4bd8-9199-4a7a9379ab3c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Reload"",
                    ""type"": ""Button"",
                    ""id"": ""3fceee29-a594-41a1-87a6-f3338376e9d3"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Switch"",
                    ""type"": ""Value"",
                    ""id"": ""32e30ead-85b5-4cd0-8dbb-be704056bcf2"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""924da737-ef45-4de1-b472-36f9794dcecf"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Shoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""97b45eb2-6141-4b28-b2fc-60902e4a8cb7"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Reload"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f01e62b5-064c-47e8-bebb-634e3b901db4"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Switch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Movement
        m_Movement = asset.FindActionMap("Movement", throwIfNotFound: true);
        m_Movement_Move = m_Movement.FindAction("Move", throwIfNotFound: true);
        m_Movement_Jump = m_Movement.FindAction("Jump", throwIfNotFound: true);
        // Rotation
        m_Rotation = asset.FindActionMap("Rotation", throwIfNotFound: true);
        m_Rotation_Rotate = m_Rotation.FindAction("Rotate", throwIfNotFound: true);
        // Weapon
        m_Weapon = asset.FindActionMap("Weapon", throwIfNotFound: true);
        m_Weapon_Shoot = m_Weapon.FindAction("Shoot", throwIfNotFound: true);
        m_Weapon_Reload = m_Weapon.FindAction("Reload", throwIfNotFound: true);
        m_Weapon_Switch = m_Weapon.FindAction("Switch", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }
    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }
    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // Movement
    private readonly InputActionMap m_Movement;
    private IMovementActions m_MovementActionsCallbackInterface;
    private readonly InputAction m_Movement_Move;
    private readonly InputAction m_Movement_Jump;
    public struct MovementActions
    {
        private @PlayerInput m_Wrapper;
        public MovementActions(@PlayerInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Movement_Move;
        public InputAction @Jump => m_Wrapper.m_Movement_Jump;
        public InputActionMap Get() { return m_Wrapper.m_Movement; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MovementActions set) { return set.Get(); }
        public void SetCallbacks(IMovementActions instance)
        {
            if (m_Wrapper.m_MovementActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_MovementActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_MovementActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_MovementActionsCallbackInterface.OnMove;
                @Jump.started -= m_Wrapper.m_MovementActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_MovementActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_MovementActionsCallbackInterface.OnJump;
            }
            m_Wrapper.m_MovementActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
            }
        }
    }
    public MovementActions @Movement => new MovementActions(this);

    // Rotation
    private readonly InputActionMap m_Rotation;
    private IRotationActions m_RotationActionsCallbackInterface;
    private readonly InputAction m_Rotation_Rotate;
    public struct RotationActions
    {
        private @PlayerInput m_Wrapper;
        public RotationActions(@PlayerInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Rotate => m_Wrapper.m_Rotation_Rotate;
        public InputActionMap Get() { return m_Wrapper.m_Rotation; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(RotationActions set) { return set.Get(); }
        public void SetCallbacks(IRotationActions instance)
        {
            if (m_Wrapper.m_RotationActionsCallbackInterface != null)
            {
                @Rotate.started -= m_Wrapper.m_RotationActionsCallbackInterface.OnRotate;
                @Rotate.performed -= m_Wrapper.m_RotationActionsCallbackInterface.OnRotate;
                @Rotate.canceled -= m_Wrapper.m_RotationActionsCallbackInterface.OnRotate;
            }
            m_Wrapper.m_RotationActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Rotate.started += instance.OnRotate;
                @Rotate.performed += instance.OnRotate;
                @Rotate.canceled += instance.OnRotate;
            }
        }
    }
    public RotationActions @Rotation => new RotationActions(this);

    // Weapon
    private readonly InputActionMap m_Weapon;
    private IWeaponActions m_WeaponActionsCallbackInterface;
    private readonly InputAction m_Weapon_Shoot;
    private readonly InputAction m_Weapon_Reload;
    private readonly InputAction m_Weapon_Switch;
    public struct WeaponActions
    {
        private @PlayerInput m_Wrapper;
        public WeaponActions(@PlayerInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Shoot => m_Wrapper.m_Weapon_Shoot;
        public InputAction @Reload => m_Wrapper.m_Weapon_Reload;
        public InputAction @Switch => m_Wrapper.m_Weapon_Switch;
        public InputActionMap Get() { return m_Wrapper.m_Weapon; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(WeaponActions set) { return set.Get(); }
        public void SetCallbacks(IWeaponActions instance)
        {
            if (m_Wrapper.m_WeaponActionsCallbackInterface != null)
            {
                @Shoot.started -= m_Wrapper.m_WeaponActionsCallbackInterface.OnShoot;
                @Shoot.performed -= m_Wrapper.m_WeaponActionsCallbackInterface.OnShoot;
                @Shoot.canceled -= m_Wrapper.m_WeaponActionsCallbackInterface.OnShoot;
                @Reload.started -= m_Wrapper.m_WeaponActionsCallbackInterface.OnReload;
                @Reload.performed -= m_Wrapper.m_WeaponActionsCallbackInterface.OnReload;
                @Reload.canceled -= m_Wrapper.m_WeaponActionsCallbackInterface.OnReload;
                @Switch.started -= m_Wrapper.m_WeaponActionsCallbackInterface.OnSwitch;
                @Switch.performed -= m_Wrapper.m_WeaponActionsCallbackInterface.OnSwitch;
                @Switch.canceled -= m_Wrapper.m_WeaponActionsCallbackInterface.OnSwitch;
            }
            m_Wrapper.m_WeaponActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Shoot.started += instance.OnShoot;
                @Shoot.performed += instance.OnShoot;
                @Shoot.canceled += instance.OnShoot;
                @Reload.started += instance.OnReload;
                @Reload.performed += instance.OnReload;
                @Reload.canceled += instance.OnReload;
                @Switch.started += instance.OnSwitch;
                @Switch.performed += instance.OnSwitch;
                @Switch.canceled += instance.OnSwitch;
            }
        }
    }
    public WeaponActions @Weapon => new WeaponActions(this);
    public interface IMovementActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
    }
    public interface IRotationActions
    {
        void OnRotate(InputAction.CallbackContext context);
    }
    public interface IWeaponActions
    {
        void OnShoot(InputAction.CallbackContext context);
        void OnReload(InputAction.CallbackContext context);
        void OnSwitch(InputAction.CallbackContext context);
    }
}