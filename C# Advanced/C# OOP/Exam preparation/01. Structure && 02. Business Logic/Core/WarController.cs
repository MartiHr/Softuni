using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WarCroft.Constants;
using WarCroft.Entities.Characters;
using WarCroft.Entities.Characters.Contracts;
using WarCroft.Entities.Items;

namespace WarCroft.Core
{
    public class WarController
	{
		private List<Character> characterParty;
		private Stack<Item> itemPool;

		public WarController()
		{
			characterParty = new List<Character>();
			itemPool = new Stack<Item>();
		}

		public string JoinParty(string[] args)
		{
			string characterType = args[0];
			string name = args[1];

			if (characterType == "Priest")
            {
				Priest priest = new Priest(name);
				characterParty.Add(priest);
			}
            else if (characterType == "Warrior")
            {
				Warrior warrior = new Warrior(name);
				characterParty.Add(warrior);
			}
			else
            {
				throw new ArgumentException(string.Format(ExceptionMessages.InvalidCharacterType, characterType));
			}

			return string.Format(SuccessMessages.JoinParty, name);
		}

		public string AddItemToPool(string[] args)
		{
			string itemName = args[0];

            if (itemName == "FirePotion")
            {
				itemPool.Push(new FirePotion());

			}
            else if (itemName == "HealthPotion")
            {
				itemPool.Push(new HealthPotion());
			}
            else
            {
				throw new ArgumentException(string.Format(ExceptionMessages.InvalidItem), itemName);
			}
			
			return string.Format(SuccessMessages.AddItemToPool, itemName);
        }

		public string PickUpItem(string[] args)
		{
			string characterName = args[0];

			Character character = characterParty.FirstOrDefault(c => c.Name == characterName);

            if (character == null)
            {
				throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, characterName));
            }

            if (itemPool.Count == 0)
            {
				throw new InvalidOperationException(ExceptionMessages.ItemPoolEmpty);
            }

			Item itemToPick = itemPool.Pop();
			string pickItemName = itemToPick.GetType().Name;

			character.Bag.AddItem(itemToPick);
			return string.Format(SuccessMessages.PickUpItem, characterName, pickItemName);
		}

		public string UseItem(string[] args)
		{
			string characterName = args[0];
			string itemName = args[1];

			Character character = characterParty.FirstOrDefault(c => c.Name == characterName);

			if (character == null)
			{
				throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, characterName));
			}

			Item item = character.Bag.GetItem(itemName);
			character.UseItem(item);

			return string.Format(SuccessMessages.UsedItem, characterName, itemName);
		}

		public string GetStats()
		{
			StringBuilder sb = new StringBuilder();

			List<Character> sortedCharacterParty = characterParty
				.OrderByDescending(x => x.IsAlive)
				.ThenByDescending(x => x.Health)
				.ToList();

            foreach (var character in sortedCharacterParty)
            {
				sb.AppendLine(string.Format
					(SuccessMessages.CharacterStats,
					character.Name,
					character.Health,
					character.BaseHealth,
					character.Armor,
					character.BaseArmor,
					character.IsAlive ? "Alive" : "Dead"));
            }

			return sb.ToString().TrimEnd();
		}

		public string Attack(string[] args)
		{
			string attackerName = args[0];
			string receiverName = args[1];

			Character attacker = characterParty.FirstOrDefault(x => x.Name == attackerName);
			Character receiver = characterParty.FirstOrDefault(y => y.Name == receiverName);

            if (attacker == null)
            {
				throw new ArgumentException(ExceptionMessages.CharacterNotInParty, attackerName);
            }

			if (receiver == null)
			{
				throw new ArgumentException(ExceptionMessages.CharacterNotInParty, receiverName);
			}

            if (!(attacker is Warrior))
            {
				throw new ArgumentException(string.Format(ExceptionMessages.AttackFail, attackerName));
            }

			Warrior warrior = attacker as Warrior;

			warrior.Attack(receiver);

			StringBuilder output = new StringBuilder();
			output.AppendLine(string.Format
				(SuccessMessages.AttackCharacter,
				attackerName,
				receiverName,
				attacker.AbilityPoints,
				receiverName,
				receiver.Health,
				receiver.BaseHealth,
				receiver.Armor,
				receiver.BaseArmor));

            if (!receiver.IsAlive)
            {
				output.AppendLine(string.Format(SuccessMessages.AttackKillsCharacter, receiverName));
            }

			return output.ToString().TrimEnd();
		}

		public string Heal(string[] args)
		{
			string healerName = args[0];
			string healingReceiverName = args[1];

			Character healer = characterParty.FirstOrDefault(x => x.Name == healerName);
			Character healingReceiver = characterParty.FirstOrDefault(y => y.Name == healingReceiverName);

			if (healer == null)
			{
				throw new ArgumentException(ExceptionMessages.CharacterNotInParty, healerName);
			}

			if (healingReceiver == null)
			{
				throw new ArgumentException(ExceptionMessages.CharacterNotInParty, healingReceiverName);
			}

			if (!(healer is Priest))
			{
				throw new ArgumentException(string.Format(ExceptionMessages.HealerCannotHeal, healerName));
			}

			StringBuilder output = new StringBuilder();
			output.AppendLine(string.Format
				(SuccessMessages.HealCharacter,
				healerName,
				healingReceiverName,
				healer.AbilityPoints,	
				healingReceiverName,
				healingReceiver.Health));

			return output.ToString().TrimEnd();
		}
	}
}
