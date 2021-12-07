// GENERATED AUTOMATICALLY FROM 'Assets/Prefabs/Player/InputActions.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @InputActions : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @InputActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputActions"",
    ""maps"": [
        {
            ""name"": ""Gameplay"",
            ""id"": ""5c206bf4-f617-4a4d-ae4d-95c81deccc82"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""b9cf2be5-1d2f-445d-9316-3ac043aebb9b"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""CursorPosition"",
                    ""type"": ""Value"",
                    ""id"": ""79626488-3ef7-4086-86d8-d5943771f8e3"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""SpawnPortalA"",
                    ""type"": ""Button"",
                    ""id"": ""556bc0f6-8022-48ad-a864-a60d091599c6"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""SpawnPortalB"",
                    ""type"": ""Button"",
                    ""id"": ""5544da99-8684-47d9-8637-708110e63450"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Interact"",
                    ""type"": ""Button"",
                    ""id"": ""3d40e52d-7afb-4c46-864e-859d21009427"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""941d59b3-2134-459c-9daa-244804148866"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""e2847057-8768-4657-bdd9-f4bce59aac07"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""9dbaa1b1-a7f1-4455-9b75-4b97ee393008"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""7a007f69-646f-49af-80b2-3e566e8d6b8a"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""630af77e-274d-44ee-8244-c2c165a2d72b"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""c65165ce-ef16-485e-8df3-db71be9a5618"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CursorPosition"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""45183eb8-2a16-43a7-8d3c-dc640ecd7eaa"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SpawnPortalA"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""80678f51-8ff4-40eb-89a5-79eea22a6554"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SpawnPortalB"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""eb1a3745-5af1-4497-b1a0-ea382f77d09c"",
                    ""path"": ""<Mouse>/middleButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Gameplay
        m_Gameplay = asset.FindActionMap("Gameplay", throwIfNotFound: true);
        m_Gameplay_Movement = m_Gameplay.FindAction("Movement", throwIfNotFound: true);
        m_Gameplay_CursorPosition = m_Gameplay.FindAction("CursorPosition", throwIfNotFound: true);
        m_Gameplay_SpawnPortalA = m_Gameplay.FindAction("SpawnPortalA", throwIfNotFound: true);
        m_Gameplay_SpawnPortalB = m_Gameplay.FindAction("SpawnPortalB", throwIfNotFound: true);
        m_Gameplay_Interact = m_Gameplay.FindAction("Interact", throwIfNotFound: true);
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

    // Gameplay
    private readonly InputActionMap m_Gameplay;
    private IGameplayActions m_GameplayActionsCallbackInterface;
    private readonly InputAction m_Gameplay_Movement;
    private readonly InputAction m_Gameplay_CursorPosition;
    private readonly InputAction m_Gameplay_SpawnPortalA;
    private readonly InputAction m_Gameplay_SpawnPortalB;
    private readonly InputAction m_Gameplay_Interact;
    public struct GameplayActions
    {
        private @InputActions m_Wrapper;
        public GameplayActions(@InputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_Gameplay_Movement;
        public InputAction @CursorPosition => m_Wrapper.m_Gameplay_CursorPosition;
        public InputAction @SpawnPortalA => m_Wrapper.m_Gameplay_SpawnPortalA;
        public InputAction @SpawnPortalB => m_Wrapper.m_Gameplay_SpawnPortalB;
        public InputAction @Interact => m_Wrapper.m_Gameplay_Interact;
        public InputActionMap Get() { return m_Wrapper.m_Gameplay; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GameplayActions set) { return set.Get(); }
        public void SetCallbacks(IGameplayActions instance)
        {
            if (m_Wrapper.m_GameplayActionsCallbackInterface != null)
            {
                @Movement.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMovement;
                @CursorPosition.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnCursorPosition;
                @CursorPosition.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnCursorPosition;
                @CursorPosition.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnCursorPosition;
                @SpawnPortalA.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSpawnPortalA;
                @SpawnPortalA.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSpawnPortalA;
                @SpawnPortalA.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSpawnPortalA;
                @SpawnPortalB.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSpawnPortalB;
                @SpawnPortalB.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSpawnPortalB;
                @SpawnPortalB.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSpawnPortalB;
                @Interact.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnInteract;
                @Interact.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnInteract;
                @Interact.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnInteract;
            }
            m_Wrapper.m_GameplayActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @CursorPosition.started += instance.OnCursorPosition;
                @CursorPosition.performed += instance.OnCursorPosition;
                @CursorPosition.canceled += instance.OnCursorPosition;
                @SpawnPortalA.started += instance.OnSpawnPortalA;
                @SpawnPortalA.performed += instance.OnSpawnPortalA;
                @SpawnPortalA.canceled += instance.OnSpawnPortalA;
                @SpawnPortalB.started += instance.OnSpawnPortalB;
                @SpawnPortalB.performed += instance.OnSpawnPortalB;
                @SpawnPortalB.canceled += instance.OnSpawnPortalB;
                @Interact.started += instance.OnInteract;
                @Interact.performed += instance.OnInteract;
                @Interact.canceled += instance.OnInteract;
            }
        }
    }
    public GameplayActions @Gameplay => new GameplayActions(this);
    public interface IGameplayActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnCursorPosition(InputAction.CallbackContext context);
        void OnSpawnPortalA(InputAction.CallbackContext context);
        void OnSpawnPortalB(InputAction.CallbackContext context);
        void OnInteract(InputAction.CallbackContext context);
    }
}