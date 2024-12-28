using System;
using Exiled.API.Features;
using Player = Exiled.Events.Handlers.Player;

namespace InfinityAmmo
{
    public sealed class Plugin : Plugin<Config>
    {
        public override string Author => "DrBright";

        public override string Name => "InfinityAmmo";

        public override Version RequiredExiledVersion { get; } = new(9, 1, 1);

        public override Version Version { get; } = new(2, 1, 0);

        public override string Prefix => Name;

        public static Plugin Instance;

        private EventHandlers _handlers;

        public override void OnEnabled()
        {
            Instance = this;

            RegisterEvents();

            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            UnregisterEvents();

            Instance = null;

            base.OnDisabled();
        }

        private void RegisterEvents()
        {
            _handlers = new EventHandlers();
            Player.Dying += _handlers.OnDying;
            Player.ReloadingWeapon += _handlers.OnReloadingWeapon;
            Player.ChangingItem += _handlers.OnChangingItem;
            Player.Shot += _handlers.OnShot;
        }

        private void UnregisterEvents()
        {
            Player.Dying -= _handlers.OnDying;
            Player.ReloadingWeapon -= _handlers.OnReloadingWeapon;
            Player.ChangingItem -= _handlers.OnChangingItem;
            Player.Shot -= _handlers.OnShot;
            _handlers = null;
        }
    }
}