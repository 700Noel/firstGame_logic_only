using firstgame.Entities.Enums;
using firstgame.Entities.World;
using firstgame.Entities.World.WorldInteraction;
using OpenTK.Mathematics;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vector2 = firstgame.Entities.World.Vector2;

namespace firstgame.Entities.Characters.PlayerMechanics
{
    internal class PlayerMove
    {
        protected Vector2? PlayerPosition;

        public Map worldMap { get; private set; }

        private OnPlayerAction onPlayerAction = new OnPlayerAction();

        public Position[,] positions { get; private set; }

        public Player fullPlayerData { get; private set; }

        public Vector2 size { get; private set; }

        private int newHealth;

        private HealthItem healthItem;

        private List<HealthItem> healthItems;

        private Weapon newWeapon;

        private WeaponItem weaponItem;

        private List<WeaponItem> weapons;

        public void getNecasseryData(Player player, Vector2 playerPosition, Vector2 size, Map map, Position[,] positions, List<WeaponItem> weaponItems, List<HealthItem> healthItems)
        {
            fullPlayerData = player;
            this.size = size;
            worldMap = map;
            this.positions = positions;
            this.PlayerPosition = playerPosition;
            weapons = weaponItems;
            this.healthItems = healthItems;
        }

        public void MovePlayer(Direction direction)
        {
            if (PlayerPosition is null) throw new Exception("Player Position was null");

            switch (direction)
            {
                case Direction.Left:
                    fullPlayerData.SetDirection(direction);
                    if (PlayerPosition.x - 1 < 0)
                    {
                        PlayerPosition.x = size.x - 1;
                        worldMap.setCurrentLevel(-1);
                        worldMap.currentLevel.RespawnEnemies();
                    }
                    else if (CheckCanMove(new Vector2(PlayerPosition.x - 1, PlayerPosition.y)))
                    { 
                        PlayerPosition.x--;
                        if (CheckItemPosition(weapons, healthItems, PlayerPosition))
                        {
                            if (weaponItem != null)
                            {
                                fullPlayerData.SetWeapon(newWeapon);
                                weaponItem.DestroyItem(worldMap.currentLevel);
                            }
                            if (healthItem != null)
                            {
                                fullPlayerData.PlayerHeal(newHealth);
                                healthItem.DestroyItem(worldMap.currentLevel);
                            }
                        }
                    }
                    break;

                case Direction.Right:
                    fullPlayerData.SetDirection(direction);
                    if (PlayerPosition.x + 1 >= size.x)
                    {
                        PlayerPosition.x = 0;
                        worldMap.setCurrentLevel(1);
                        worldMap.currentLevel.RespawnEnemies();
                    }
                    else if (CheckCanMove(new Vector2(PlayerPosition.x + 1, PlayerPosition.y)))
                    { 
                        PlayerPosition.x++;
                        if (CheckItemPosition(weapons, healthItems, PlayerPosition))
                        {
                            if(weaponItem != null)
                            {
                                fullPlayerData.SetWeapon(newWeapon);
                                weaponItem.DestroyItem(worldMap.currentLevel);
                            }
                            if (healthItem != null)
                            {
                                fullPlayerData.PlayerHeal(newHealth);
                                healthItem.DestroyItem(worldMap.currentLevel);
                            }
                         }
                    }
                    break;

                case Direction.Up:
                    fullPlayerData.SetDirection(direction);
                    if (PlayerPosition.y - 1 < 0)
                    {
                        PlayerPosition.y = size.y - 1;
                        worldMap.setCurrentLevel(-3);
                        worldMap.currentLevel.RespawnEnemies();
                    }
                    else if (CheckCanMove(new Vector2(PlayerPosition.x, PlayerPosition.y - 1)))
                    { 
                        PlayerPosition.y--;
                        if (CheckItemPosition(weapons, healthItems, PlayerPosition))
                        {
                            if (weaponItem != null)
                            {
                                fullPlayerData.SetWeapon(newWeapon);
                                weaponItem.DestroyItem(worldMap.currentLevel);
                            }
                            if (healthItem != null)
                            {
                                fullPlayerData.PlayerHeal(newHealth);
                                healthItem.DestroyItem(worldMap.currentLevel);
                            }
                        }
                    }
                    break;

                case Direction.Down:
                    fullPlayerData.SetDirection(direction);
                    if (PlayerPosition.y + 1 >= size.y)
                    {
                        PlayerPosition.y = 0;
                        worldMap.setCurrentLevel(3);
                        worldMap.currentLevel.RespawnEnemies();
                    }
                    else if (CheckCanMove(new Vector2(PlayerPosition.x, PlayerPosition.y + 1)))
                    { 
                        PlayerPosition.y++;
                        if (CheckItemPosition(weapons, healthItems, PlayerPosition))
                        {
                            if (weaponItem != null)
                            {
                                fullPlayerData.SetWeapon(newWeapon);
                                weaponItem.DestroyItem(worldMap.currentLevel);
                            }
                            if (healthItem != null)
                            {
                                fullPlayerData.PlayerHeal(newHealth);
                                healthItem.DestroyItem(worldMap.currentLevel);
                            }
                        }
                    }
                    break;
            }
        }

        private bool CheckItemPosition(List<WeaponItem> weaponItems, List<HealthItem> healthItems, Vector2 playerPosition)
        {
            foreach(WeaponItem weaponItem in weaponItems)
            {
                if(weaponItem.position.vector2.x == playerPosition.x && weaponItem.position.vector2.y == playerPosition.y)
                {
                    newWeapon = weaponItem.weapon;
                    this.weaponItem = weaponItem; 
                    return true;
                }
            }
            foreach(HealthItem healthItem in healthItems)
            {
                if (healthItem.position.vector2.x == playerPosition.x && healthItem.position.vector2.y == playerPosition.y)
                {
                    newHealth = healthItem.GetHealth();
                    this.healthItem = healthItem;
                    return true;
                }
            }
            
            return false;
        }



        private bool CheckCanMove(Vector2 position)
        {
            var state = positions[position.x, position.y].State;
            if (worldMap.currentLevel.CheckEnemyPosition(position.x, position.y))
            {
                fullPlayerData.PlayerHit(5);
                return false;
            }
            else if (state == PositionState.Empty || state == PositionState.Path)
            {
                return true;
            }
            return false;
        }

    }
}
