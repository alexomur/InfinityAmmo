using System;
using Exiled.API.Enums;
using Exiled.API.Features;
using Exiled.API.Features.Pickups;
using Exiled.Events.EventArgs.Player;
using InventorySystem.Items.Firearms;
using Firearm = Exiled.API.Features.Items.Firearm;

namespace InfinityAmmo
{
    public class EventHandlers
    { 
        public void OnReloadingWeapon(ReloadingWeaponEventArgs ev)
        {
            Log.Debug("Reloading!");
            ev.Player.SetAmmo(ev.Firearm.AmmoType, Convert.ToUInt16(ev.Firearm.TotalMaxAmmo));
        }

        public void OnShot(ShotEventArgs ev)
        {
            if (ev.Firearm.Type != ItemType.ParticleDisruptor) 
                return;
            
            Log.Debug("Disruptor Shot!");
                
            if (!Plugin.Instance.Config.InfParticleDisruptor) 
                return;
                
            Log.Debug("Reloading Disruptor!");
            ev.Firearm.AmmoDrain = 5;
            ev.Firearm.BarrelAmmo = 5;
            ev.Firearm.MagazineAmmo = 5;
        }

        public void OnChangingItem(ChangingItemEventArgs ev)
        {
            Log.Debug("Changing!");
            if (ev.Item is not Firearm firearm)
                return;
            
            Log.Debug("Firearm!");
            
            if (firearm.Type == ItemType.ParticleDisruptor)
            {
                Log.Debug("Disruptor!");
                firearm.AmmoDrain = 5;
                firearm.BarrelAmmo = 5;
                firearm.MagazineAmmo = 5;
            }
            
            Log.Debug("Setting ammo!");
            ev.Player.SetAmmo(firearm.AmmoType, 1);
        }

        public void OnDying(DyingEventArgs ev)
        {
            Log.Debug("Dying!");
            ev.Player.SetAmmo(AmmoType.Nato9, 0);
            ev.Player.SetAmmo(AmmoType.Ammo44Cal, 0);
            ev.Player.SetAmmo(AmmoType.Ammo12Gauge, 0);
            ev.Player.SetAmmo(AmmoType.Nato556, 0);
            ev.Player.SetAmmo(AmmoType.Nato762, 0);
            ev.Player.SetAmmo(AmmoType.None, 0);
        }
    }
}