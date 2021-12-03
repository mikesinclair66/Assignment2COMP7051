// GENERATED AUTOMATICALLY FROM 'Assets/InputActions.inputactions'

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
            ""name"": ""Player"",
            ""id"": ""2f680f76-60ec-4d25-875d-bcf971ab8dd8"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""Button"",
                    ""id"": ""88fc310b-edcf-4914-9bad-874bf1ee5504"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Move"",
                    ""type"": ""Button"",
                    ""id"": ""d5b2fe02-1f5e-400f-9066-180385538cf9"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Rotate"",
                    ""type"": ""Button"",
                    ""id"": ""63018bca-7113-4db1-b775-d3f372369f06"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ThrowBall"",
                    ""type"": ""Button"",
                    ""id"": ""6f76f3b2-736c-402b-8766-3e9c057f9028"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""SaveGame"",
                    ""type"": ""Button"",
                    ""id"": ""85d7b6ed-46bc-4a28-b202-29bd43773173"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""LoadGame"",
                    ""type"": ""Button"",
                    ""id"": ""b3a90c51-acb7-4372-b99c-79f26948e0c6"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ToggleMusic"",
                    ""type"": ""Button"",
                    ""id"": ""068a0f14-5c65-4709-9ef0-de937cd3ace5"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ToggleDayNight"",
                    ""type"": ""Button"",
                    ""id"": ""9d82473b-1be4-4404-b57f-7f1a6dc6d440"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ToggleFog"",
                    ""type"": ""Button"",
                    ""id"": ""bbc94a71-ff70-4a51-b3e9-6201af2ea284"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ToggleFlashlight"",
                    ""type"": ""Button"",
                    ""id"": ""47610b03-2f07-41fb-bbe1-a33de4b671d1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""82c85ec5-a103-4ee7-80b9-fe42c5c24235"",
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
                    ""id"": ""3a36a416-79c1-44fe-8bdf-9f7599398720"",
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
                    ""id"": ""0692413c-f628-4054-ad90-a77fe79f47d2"",
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
                    ""id"": ""fa1d16ee-9515-47f3-8c63-20c62a84d534"",
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
                    ""id"": ""08dad6d5-78a1-406c-a029-6a755650fe04"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""b102a7fe-f885-4dbf-a4c1-de6a065a6f29"",
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
                    ""id"": ""079b89b1-a61f-4ae4-961b-156acf6d6489"",
                    ""path"": ""<Gamepad>/leftStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""0bd71f25-a544-4e6b-9bd6-b5ab309550bd"",
                    ""path"": ""<Gamepad>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""720f00e8-c2b9-468e-a456-e0e74c9c2428"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""c0c59dec-6394-4c33-b12c-f5547f1a46a1"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""ff03c6ae-c80f-4f64-9a4e-88656f7b4ee9"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a0df260f-ff84-4f0b-8881-3fb1c8d107d2"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c71d2d67-3033-4280-b6ad-4e424232e38e"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ThrowBall"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1a80ed36-a1cd-4878-912d-26019a55297d"",
                    ""path"": ""<Keyboard>/j"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SaveGame"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""475e82ce-8775-4c12-ae97-ddcac56ecb15"",
                    ""path"": ""<Keyboard>/k"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LoadGame"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e3d924cb-9930-489c-bfdb-1828a622e2c2"",
                    ""path"": ""<Keyboard>/i"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ToggleMusic"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d43cd000-24e9-45b2-81c1-498bc15220df"",
                    ""path"": ""<Keyboard>/o"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ToggleDayNight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""730393a8-9afb-48f3-a6a9-368b3a611586"",
                    ""path"": ""<Keyboard>/p"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ToggleFog"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0c19682e-c504-4d13-bc8a-0432e379310a"",
                    ""path"": ""<Keyboard>/f"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ToggleFlashlight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_Movement = m_Player.FindAction("Movement", throwIfNotFound: true);
        m_Player_Move = m_Player.FindAction("Move", throwIfNotFound: true);
        m_Player_Rotate = m_Player.FindAction("Rotate", throwIfNotFound: true);
        m_Player_ThrowBall = m_Player.FindAction("ThrowBall", throwIfNotFound: true);
        m_Player_SaveGame = m_Player.FindAction("SaveGame", throwIfNotFound: true);
        m_Player_LoadGame = m_Player.FindAction("LoadGame", throwIfNotFound: true);
        m_Player_ToggleMusic = m_Player.FindAction("ToggleMusic", throwIfNotFound: true);
        m_Player_ToggleDayNight = m_Player.FindAction("ToggleDayNight", throwIfNotFound: true);
        m_Player_ToggleFog = m_Player.FindAction("ToggleFog", throwIfNotFound: true);
        m_Player_ToggleFlashlight = m_Player.FindAction("ToggleFlashlight", throwIfNotFound: true);
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

    // Player
    private readonly InputActionMap m_Player;
    private IPlayerActions m_PlayerActionsCallbackInterface;
    private readonly InputAction m_Player_Movement;
    private readonly InputAction m_Player_Move;
    private readonly InputAction m_Player_Rotate;
    private readonly InputAction m_Player_ThrowBall;
    private readonly InputAction m_Player_SaveGame;
    private readonly InputAction m_Player_LoadGame;
    private readonly InputAction m_Player_ToggleMusic;
    private readonly InputAction m_Player_ToggleDayNight;
    private readonly InputAction m_Player_ToggleFog;
    private readonly InputAction m_Player_ToggleFlashlight;
    public struct PlayerActions
    {
        private @InputActions m_Wrapper;
        public PlayerActions(@InputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_Player_Movement;
        public InputAction @Move => m_Wrapper.m_Player_Move;
        public InputAction @Rotate => m_Wrapper.m_Player_Rotate;
        public InputAction @ThrowBall => m_Wrapper.m_Player_ThrowBall;
        public InputAction @SaveGame => m_Wrapper.m_Player_SaveGame;
        public InputAction @LoadGame => m_Wrapper.m_Player_LoadGame;
        public InputAction @ToggleMusic => m_Wrapper.m_Player_ToggleMusic;
        public InputAction @ToggleDayNight => m_Wrapper.m_Player_ToggleDayNight;
        public InputAction @ToggleFog => m_Wrapper.m_Player_ToggleFog;
        public InputAction @ToggleFlashlight => m_Wrapper.m_Player_ToggleFlashlight;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
            {
                @Movement.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMovement;
                @Move.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMove;
                @Rotate.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRotate;
                @Rotate.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRotate;
                @Rotate.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRotate;
                @ThrowBall.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnThrowBall;
                @ThrowBall.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnThrowBall;
                @ThrowBall.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnThrowBall;
                @SaveGame.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSaveGame;
                @SaveGame.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSaveGame;
                @SaveGame.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSaveGame;
                @LoadGame.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLoadGame;
                @LoadGame.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLoadGame;
                @LoadGame.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLoadGame;
                @ToggleMusic.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnToggleMusic;
                @ToggleMusic.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnToggleMusic;
                @ToggleMusic.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnToggleMusic;
                @ToggleDayNight.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnToggleDayNight;
                @ToggleDayNight.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnToggleDayNight;
                @ToggleDayNight.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnToggleDayNight;
                @ToggleFog.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnToggleFog;
                @ToggleFog.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnToggleFog;
                @ToggleFog.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnToggleFog;
                @ToggleFlashlight.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnToggleFlashlight;
                @ToggleFlashlight.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnToggleFlashlight;
                @ToggleFlashlight.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnToggleFlashlight;
            }
            m_Wrapper.m_PlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Rotate.started += instance.OnRotate;
                @Rotate.performed += instance.OnRotate;
                @Rotate.canceled += instance.OnRotate;
                @ThrowBall.started += instance.OnThrowBall;
                @ThrowBall.performed += instance.OnThrowBall;
                @ThrowBall.canceled += instance.OnThrowBall;
                @SaveGame.started += instance.OnSaveGame;
                @SaveGame.performed += instance.OnSaveGame;
                @SaveGame.canceled += instance.OnSaveGame;
                @LoadGame.started += instance.OnLoadGame;
                @LoadGame.performed += instance.OnLoadGame;
                @LoadGame.canceled += instance.OnLoadGame;
                @ToggleMusic.started += instance.OnToggleMusic;
                @ToggleMusic.performed += instance.OnToggleMusic;
                @ToggleMusic.canceled += instance.OnToggleMusic;
                @ToggleDayNight.started += instance.OnToggleDayNight;
                @ToggleDayNight.performed += instance.OnToggleDayNight;
                @ToggleDayNight.canceled += instance.OnToggleDayNight;
                @ToggleFog.started += instance.OnToggleFog;
                @ToggleFog.performed += instance.OnToggleFog;
                @ToggleFog.canceled += instance.OnToggleFog;
                @ToggleFlashlight.started += instance.OnToggleFlashlight;
                @ToggleFlashlight.performed += instance.OnToggleFlashlight;
                @ToggleFlashlight.canceled += instance.OnToggleFlashlight;
            }
        }
    }
    public PlayerActions @Player => new PlayerActions(this);
    public interface IPlayerActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnMove(InputAction.CallbackContext context);
        void OnRotate(InputAction.CallbackContext context);
        void OnThrowBall(InputAction.CallbackContext context);
        void OnSaveGame(InputAction.CallbackContext context);
        void OnLoadGame(InputAction.CallbackContext context);
        void OnToggleMusic(InputAction.CallbackContext context);
        void OnToggleDayNight(InputAction.CallbackContext context);
        void OnToggleFog(InputAction.CallbackContext context);
        void OnToggleFlashlight(InputAction.CallbackContext context);
    }
}
