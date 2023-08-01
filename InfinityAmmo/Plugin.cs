using Exiled.API.Features;
using Player = Exiled.Events.Handlers.Player;

namespace InfinityAmmo
{
    public sealed class Plugin : Plugin<Config>
    {
        public override string Author => "DrBright";

        public override string Name => "InfinityAmmo";

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
        }

        private void UnregisterEvents()
        {
            _handlers = null;
        }
    }
}