using System;
using Exiled.API.Enums;
using Exiled.API.Features;
using Exiled.Events.EventArgs.Player;
using PlayerRoles;

namespace InfinityAmmo
{
    public class EventHandlers
    { public void OnReloadingWeapon(ReloadingWeaponEventArgs ev)
        {
            
            if (ev.Firearm.Type == ItemType.ParticleDisruptor) return;

                if (ev.IsAllowed)
            {
                ev.Player.SetAmmo(ev.Firearm.AmmoType, Convert.ToUInt16(ev.Firearm.MaxAmmo));
            }

        }

        public void OnDying(DyingEventArgs ev)
        {
            ev.Player.SetAmmo(AmmoType.Nato9, 0);
            ev.Player.SetAmmo(AmmoType.Ammo44Cal, 0);
            ev.Player.SetAmmo(AmmoType.Ammo12Gauge, 0);
            ev.Player.SetAmmo(AmmoType.Nato556, 0);
            ev.Player.SetAmmo(AmmoType.Nato762, 0);
            ev.Player.SetAmmo(AmmoType.None, 0);
        }
    }
}