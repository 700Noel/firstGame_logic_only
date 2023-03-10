using firstgame.Entities.Enums;
using firstgame.Entities.World;
using firstgame.Entities.World.WorldInteraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace firstgame.Entities.Characters.PlayerMechanics
{
    internal class PlayerCombat
    {
        Enemy deleteEnemy;

        bool killEnemy = false;

        Player playerStats;

        Position currentPosition;

        Weapon weapon;

        Direction direction;

        Range range = new Range();


        public void getPlayer(Player player)
        {
            playerStats = player;
            currentPosition = player.position;
            weapon = player.weapon;
            direction = player.direction;

        }

        public void Attack(Level level)
        {
            foreach (Enemy enemy in level.Enemies())
            {
                if (range.InRange(currentPosition, enemy.position, weapon, direction))
                {
                    enemy.DamageEnemy(ReturnDamage());
                    if (enemy.health <= 0)
                    {
                        deleteEnemy = enemy;
                        killEnemy = true;
                        DropHealth(enemy, level);
                    }
                }
            }
            if (killEnemy)
            {
                level.Enemies().Remove(deleteEnemy);
            }

        }

        private void DropHealth(Enemy enemy, Level level)
        {
            Random rnd = new Random();
            if(rnd.Next(1, 100) <= 50)
            level.AddItem(new HealthItem(enemy.position, PositionState.Health));
        }

        internal int ReturnDamage()
        {
            switch (weapon)
            {
                case Weapon.Sword:
                    return 10;
                case Weapon.Speer:
                    return 10;
                case Weapon.Axe:
                    return 20;
                default:
                    return 0;
            }
        }
    }
}
