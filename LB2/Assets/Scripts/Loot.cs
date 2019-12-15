using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LB2
{
    class Loot : Interacteble
    {
        private List<Object> inventotry;
        private int Gold;

        private void Update()
        {
            // if input.GetButton()
            // check TegObject == Gold
            // ChangeGold(+1);
            // else AddToInventory
        }

        private void ChangeGold(int count)
        {
            Gold += count;
        }

        private void AddToInventory()
        {
            Destroy(gameObject);
            inventotry.Add(gameObject);
        }

        private void RemoveFromInventory()
        {
            inventotry.Remove(gameObject);
            CreateLootInMap();
        }

        private void CreateLootInMap()
        {
            //AddLoot in map
        }
    }
}
